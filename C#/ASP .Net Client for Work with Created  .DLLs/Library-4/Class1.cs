using System;
using Library_2;
using Library_3;

namespace Library_4
{
    public static class KI3_Class_4
    {
        static KI3_Class_3 C3 = new KI3_Class_3();
        public static int F4(int x, int y)
        {
            return 7 * KI3_Class_2.F2(x, y) - 3 * C3.F3(x, y);
        }
    }

}






