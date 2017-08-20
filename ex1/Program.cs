using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLib;

namespace ex1
{
    internal class Program
    {
        private static int[] unite(int[] first, int[] end, out int price)
        {
            // метод, объединяющий два блока
            // return   - объединенный блок 
            // price    - кол-во операций
            // first    - первый блок
            // end      - второй

            var ans = new int[2];
            ans[0] = first[0];
            ans[1] = end[1];

            price = ans[0] * ans[1];
            return ans;
        }


        private static void Main()
        {
            // задача сводится к стандартной в дискретке задаче
            // о порядке перемножения матриц (расставления скобок, по сути)
            // использовано динамическое двумерное программирование

            // инициализация кол-ва блоков и выделение памяти
            var num = Ask.Num("Введите количество блоков: ", 1, 100);
            var matrix = new List<int[]>();
            
            // ввод всех блоков
            for (var i = 0; i < num; i++)
            {
                var cur = new int[2];
                cur[0] = Ask.Num("Введите число m: ", 0, 100);
                cur[1] = Ask.Num("Введите число k: ", 0, 100);

                matrix.Add(cur);
            }
        }
    }
}
