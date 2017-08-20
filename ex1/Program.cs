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
        private static int Min(List<int> array)
        {
            // поиск минимума в массиве
            // ans - число само, 
            // ind - его индекс
            var ind = 0;
            var ans = array[0];
            var length = array.Count;

            // поиск
            for (var i = 1; i < length; i++)
            {
                if (array[i] >= ans) continue;
                ans = array[i];
                ind = i;
            }

            return ind;
        }
        private static void Main()
        {
            while (true)
            {
                // обработать искл ситуевины, когда num = 1!
                // инициализация кол-ва блоков и выделение памяти
                var num = Ask.Num("Введите количество блоков: ", 1, 100);
                
                var matrix = new List<int>(num+1);              // храним блоки
                var count = new List<int>(num-1);               // храним результаты вычислений
                var sum = 0;                                    // число технологических операций
                int del;                                        // соединяемый блок

                // ввод всех блоков
                for (var i = 0; i <= num; i++)
                    matrix.Add(Ask.Num("Введите число: ", 0, 100));

                // первый расчет
                for (var i = 0; i < num-1; i++)
                    count.Add(matrix[i] * matrix[i + 2]);

                while (matrix.Count > 3)
                {
                    del = Min(count) + 1;                       // удаляемое число
                    sum += matrix[del - 1] * matrix[del + 1];   // вычисление кол-ва операций
                    matrix.RemoveAt(del);
                    count.RemoveAt(del-1);
                    if (count.Count >= del)count[del - 1] = matrix[del - 1] * matrix[del + 1];
                    if (count.Count >= del - 1 && del > 1) count[del - 2] = matrix[del - 2] * matrix[del];
                }

                sum += count[0];                   // вычисление последней операции

                // вывод ответа
                Console.WriteLine("Ans: " + sum);
                OC.Stay();
            }
        }
    }
}
