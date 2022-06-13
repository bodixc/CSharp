using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Library_1;
using Library_2;
using Library_3;

namespace F4_WebService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public int F4(int x, int y)
        {
            KI3_Class_3 C3 = new KI3_Class_3();
            return 7 * KI3_Class_2.F2(x, y) - 3 * C3.F3(x, y);
        }

        public DataTable GetAllElements()
        {
            string DB = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Hardware_Store; Integrated Security = True";
            string Query = "select * from Building_Materials as x inner join Store_branch as y on x.Branch_ID = y.ID;";
            using (SqlConnection Conn = new SqlConnection(DB))
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                Conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(Query, DB);
                da.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
        }
        public DataTable GetElementByID(int ID)
        {
            string DB = "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Hardware_Store; Integrated Security = True";
            string Query = $"select * from Building_Materials where Item_ID = {ID};";
            using (SqlConnection Conn = new SqlConnection(DB))
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                Conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(Query, DB);
                da.Fill(ds);
                dt = ds.Tables[0];
                return dt;
            }
        }
    }
}
