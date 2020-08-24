using System;
using System.Collections.Generic;
using System.Text;

namespace ArrayListHomeWork
{
    public class Errors
    {
        public static void IndexError()
        {
            throw new Exception("Индекс не может быть больше массива.");
        }

        public static void EmptyArray()
        {
            throw new Exception("Пустой массив.");
        }
    }
}
