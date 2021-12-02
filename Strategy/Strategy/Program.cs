using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        public interface Sort
        {
            void SortTab(int[] input);
        }

        public class BubbleSort : Sort
        {
            public void SortTab(int[] input)
            {
                var itemMoved = false;
                do
                {
                    itemMoved = false;
                    for (int i = 0; i < input.Count() - 1; i++)
                    {
                        if (input[i] > input[i + 1])
                        {
                            var lowerValue = input[i + 1];
                            input[i + 1] = input[i];
                            input[i] = lowerValue;
                            itemMoved = true;
                        }
                    }
                } while (itemMoved);
            }
        }

        public class InsertionSort : Sort
        {
            public void SortTab(int[] input)
            {
                for (int i = 0; i < input.Count(); i++)
                {
                    var item = input[i];
                    var currentIndex = i;

                    while (currentIndex > 0 && input[currentIndex - 1] > item)
                    {
                        input[currentIndex] = input[currentIndex - 1];
                        currentIndex--;
                    }

                    input[currentIndex] = item;
                }
            }
        }

        public class SelectionSort : Sort
        {
            public void SortTab(int[] input)
            {
                for (var i = 0; i < input.Length; i++)
                {
                    var min = i;
                    for (var j = i + 1; j < input.Length; j++)
                    {
                        if (input[min] > input[j])
                        {
                            min = j;
                        }
                    }

                    if (min != i)
                    {
                        var lowerValue = input[min];
                        input[min] = input[i];
                        input[i] = lowerValue;
                    }
                }
            }
        }

        public class Strategy
        {
            private Sort sortType;

            public Strategy(Sort sort)
            {
                this.sortType = sort;
            }

            public void setSortType(Sort sort)
            {
                this.sortType = sort;
            }

            public void executeSort(int[] input)
            {
                sortType.SortTab(input);
            }
        }

        static void Main(string[] args)
        {
            Strategy strategy;
            int[] tab = { 6, 7, 3, 1, 6, 12, 64, 83, 2, 53 };

            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.D1)
            {
                strategy = new Strategy(new BubbleSort());
            }
            else if (key.Key == ConsoleKey.D2)
            {
                strategy = new Strategy(new SelectionSort());
            }
            else
            {
                strategy = new Strategy(new InsertionSort());
            }

            strategy.executeSort(tab);

            Console.WriteLine();

            foreach(int x in tab)
            {
                Console.Write(x + " ");
            }


        }
    }
}
