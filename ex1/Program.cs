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
        private static void Main()
        {
            while (true)
            {
                // решение через динамическое программирование

                // инициализация кол-ва блоков и выделение памяти
                var num = Ask.Num("Введите количество блоков: ", 1, 100);

                int[] leftParams  = new int[num],           // левый параметр
                      rightParams = new int[num];           // правый параметр
                var cost = new int[num, num];               // массив стоимостей соединения блоков

                // ввод блоков
                for (int i = 0; i < num; i++)
                {
                    leftParams[i] = Ask.Num("Введите левый параметр: ");
                    rightParams[i] = Ask.Num("Введите правый параметр: ");
                }

                // 
                for (int length = 1; length <= num; length++)
                {
                    for (int left = 0; left + length - 1 < num; left++)
                    {
                        var right = left + length - 1;
                        if (length == 1) cost[left, right] = 0;
                        else
                        {
                            var min = int.MaxValue;
                            for (int k = left; k < right; k++)
                                min = Math.Min(min, cost[left, k] + cost[k + 1, right]);
                            cost[left, right] = min + leftParams[left] * rightParams[right];
                         }
                    }
                }

                Console.WriteLine("Ans: " + cost[0, num-1]);
                OC.Stay();
            }
        }
    }
}
