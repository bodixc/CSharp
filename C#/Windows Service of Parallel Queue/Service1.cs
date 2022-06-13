using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Timers;
using System.IO;
using Microsoft.Win32;

namespace SPS_Lab_3
{
    public partial class Service1 : ServiceBase
    {
        Task_Queue TQ;
        Thread TH;
        public Service1()
        {
            InitializeComponent();
        }
        protected override void OnStart(string[] args)
        {
            TQ = new Task_Queue();
            TH = new Thread(new ThreadStart(TQ.Initialization));
            TH.Start();
        }
        protected override void OnStop()
        {
            TH.Abort();
            TH = new Thread(new ThreadStart(TQ.Deactivation));
            TH.Start();
            TH.Abort();
        }
        class Task_Queue
        {
            FileSystemWatcher watcher, watcher2;
            List<string> Claims = new List<string>();
            List<string> Tasks = new List<string>();
            List<string> Threads = new List<string>();
            RegistryKey key, key1;
            int Task_Execution_Duration , Task_Claim_Check_Period , Task_Execution_Quantity;
            System.Timers.Timer t, t1;
            int Working = 0;
            Thread TH1, TH2, TH3;
            public void Initialization()
            {
                watcher = new FileSystemWatcher(@"C:\Task_Queue\Claims", "*.bin");
                watcher.NotifyFilter = NotifyFilters.FileName;
                watcher.EnableRaisingEvents = true;
                watcher.Renamed += Create_Task;
                key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                key1 = key.OpenSubKey(@"SOFTWARE\Task_Queue\Parameters");
                Task_Execution_Duration = Int32.Parse(key1.GetValue("Task_Execution_Duration").ToString());
                Task_Claim_Check_Period = Int32.Parse(key1.GetValue("Task_Claim_Check_Period").ToString());
                Task_Execution_Quantity = Int32.Parse(key1.GetValue("Task_Execution_Quantity").ToString());
                key.Close();
                t = new System.Timers.Timer(Task_Claim_Check_Period * 100);
                t.Elapsed += new ElapsedEventHandler(Take_Task);
                t.Enabled = true;
                watcher2 = new FileSystemWatcher(@"C:\Task_Queue\Tasks", "*.bin");
                watcher2.EnableRaisingEvents = true;
                watcher2.Created += Watch_Task;
                t1 = new System.Timers.Timer(2000);
                t1.Elapsed += new ElapsedEventHandler(Load_Task);
                t1.Enabled = true;
            }
            public void Deactivation()
            {
                TH1.Abort();
                TH2.Abort();
                TH3.Abort();
            }
            public bool PassFormat(string p)
            {
                Regex R = new Regex("^Task_[0-9]{4}$");
                Match M = R.Match(p);
                return M.Success;
            }
            public void Create_Task(object source, FileSystemEventArgs e) 
            { 
                string TaskName = e.Name.Remove(e.Name.IndexOf('.'));
                bool v = PassFormat(TaskName);
                if (v)
                {
                    if (!Claims.Contains(TaskName))
                    {
                        Claims.Add(TaskName);
                        Claims.Sort();
                    }
                    else
                    {
                        WriteLog($"ПОМИЛКА розміщення заявки {TaskName}. Номер вже існує...");
                        File.Delete(e.FullPath);
                    }
                }
                else
                {
                    WriteLog($"ПОМИЛКА розміщення заявки {TaskName}. Некоректний синтаксис...");
                    File.Delete(e.FullPath);
                }
            }
            public void Take_Task(object source, ElapsedEventArgs e)
            {
                if (Claims.Count != 0)
                {
                    WriteLog($"Задача {Claims[0]} успішно прийнята в обробку...");
                    var f = File.Create($@"C:\Task_Queue\Tasks\{Claims[0]}.bin");
                    f.Close();
                    var CQ1 = File.Create($@"C:\Task_Queue\Claims\{Claims[0]}-Queued.txt");
                    CQ1.Close();
                    File.Delete($@"C:\Task_Queue\Claims\{Claims[0]}.bin");
                    Claims.RemoveAt(0);
                }
            }
            public void Watch_Task(object source, FileSystemEventArgs e)
            {
                Tasks.Add(e.FullPath);
            }
            public void Load_Task(object source, ElapsedEventArgs e)
            {
                if (Task_Execution_Quantity == 1)
                {
                    if (Tasks.Count != 0)
                    {
                        if (Working < 1)
                        {
                            TH1 = new Thread(new ThreadStart(Do_Task));
                            TH1.Start();
                            Threads.Add("TH1");
                        }
                    }
                }
                else if (Task_Execution_Quantity == 2)
                {
                    if (Tasks.Count != 0)
                    {
                        if (Working < 1)
                        {
                            TH1 = new Thread(new ThreadStart(Do_Task));
                            TH1.Start();
                            Threads.Add("TH1");
                        }
                        else if (Working < 2)
                        {
                            TH2 = new Thread(new ThreadStart(Do_Task));
                            TH2.Start();
                            Threads.Add("TH2");
                        }
                    }
                }
                else if (Task_Execution_Quantity == 3)
                {
                    if (Tasks.Count != 0)
                    {
                        if (Working < 1)
                        {
                            TH1 = new Thread(new ThreadStart(Do_Task));
                            TH1.Start();
                            Threads.Add("TH1");
                        }
                        else if (Working < 2)
                        {
                            TH2 = new Thread(new ThreadStart(Do_Task));
                            TH2.Start();
                            Threads.Add("TH2");
                        }
                        else if (Working < 3)
                        {
                            TH3 = new Thread(new ThreadStart(Do_Task));
                            TH3.Start();
                            Threads.Add("TH3");
                        }
                    }
                }
            }
            public void Do_Task()
            {
                string Task = Tasks[0];
                string oldName = "";
                string newName;
                Tasks.RemoveAt(0);
                Working += 1;
                var count = Task_Execution_Duration / 2 + 1;
                var size = 1000 / (Task_Execution_Duration / 2);
                var last = 1000 % (Task_Execution_Duration / 2);
                File.Delete($@"C:\Task_Queue\Claims\{Task.Substring(20, 9)}-Queued.txt");
                for (int i = 0; i < count; i++)
                {
                    var b = GetByteArray(size);
                    if (i == count - 1)
                    {
                        b = GetByteArray(last);
                    }
                    FileStream fs = new FileStream(Task, FileMode.Append, FileAccess.Write);
                    fs.Write(b, 0, b.Length);
                    fs.Close();
                    FileInfo fi = new FileInfo(Task);
                    newName = $@"C:\Task_Queue\Claims\{Task.Substring(20, 9)}-{fi.Length / 10}-Queued.txt";
                    var CQ = File.Create(newName);
                    CQ.Close();
                    if (i != 0)
                    {
                        File.Delete(oldName);
                    }
                    oldName = newName;
                    if (((int)fi.Length) == 1000)
                    {
                        WriteLog($"Задача {Task.Substring(20, 9)} успішно ВИКОНАНА!");
                        Working -= 1;
                        if (Threads.Contains("TH1"))
                        {
                            TH1.Abort();
                            Threads.Remove("TH1");
                        }
                        else if (Threads.Contains("TH2"))
                        {
                            TH2.Abort();
                            Threads.Remove("TH2");
                        }
                        else if (Threads.Contains("TH3"))
                        {
                            TH3.Abort();
                            Threads.Remove("TH3");
                        }
                    }
                    Thread.Sleep(2000);
                }
            }

            public byte[] GetByteArray(int bytes)
            {
                Random rnd = new Random();
                Byte[] b = new Byte[bytes];
                rnd.NextBytes(b);
                return b;
            }
            public void WriteLog(string z)
            {
                using (StreamWriter F = new StreamWriter($@"C:\Task_Queue\Logs\TaskQueue.log", true))
                {
                    F.WriteLine("---------------" + DateTime.Now + "---------------" + "\n" + z);
                }
            }
        }
    }
}
