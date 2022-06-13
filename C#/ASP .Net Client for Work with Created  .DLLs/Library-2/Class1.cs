using System;
using Library_1;

namespace Library_2
{
    public class KI3_Class_2
    {
        static KI3_Class_1 C1 = new KI3_Class_1();
        public static int F2(int x, int y)
        {
            return 2 * C1.F1(x, y) + 5;
        }
    }
}
