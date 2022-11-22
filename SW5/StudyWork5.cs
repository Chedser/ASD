using System;

/*
StudyWork5.cs – Листинг программы для 5-й лабораторной работы
* Вариант 2
*******************************************************************
* Имя файла : StudyWork5.cs
* Резюме : Программа написанная на языке программирования С#
* Описание :  Реализовать «быструю» сортировку
* Автор : Морозов Олег группа 21-ИВТз-3
******************************************************************
*/

namespace StudyWork5
{
    class StudyWork5
    {
        /* Индекс последнего элемента неотсортированной части */
        static int Partition(int[] array, int low, int high)
        {

            int pivot = array[high];    // Верхнее значение

            int lowIndex = (low - 1);   // Индекс нижнего значения

            /* Перестановка значений */
            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    lowIndex++;

                    int temp = array[lowIndex];
                    array[lowIndex] = array[j];
                    array[j] = temp;
                }
            }

            int tmp = array[lowIndex + 1];
            array[lowIndex + 1] = array[high];
            array[high] = tmp;

            return lowIndex + 1;
        }

        /* Быстрая сортировка */
        static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int partitionIndex = Partition(array, low, high);

                /* Рекурсивно отсортировать значения */
                QuickSort(array, low, partitionIndex - 1);
                QuickSort(array, partitionIndex + 1, high);
            }
        }

        /* Печать массива */
        static void Print(int[] arr)
        {
            foreach (Object i in arr)
            {
                Console.WriteLine(i);
            }

        }

        /* Генерация случайной последовательности */
        static int[] GenerateSequence(int size, int max) 
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++) {
                arr[i] = new Random().Next(1, max);
            }
            return arr;
        }

        static void Main(string[] args)
        {

            int size = new Random().Next(7, 10);            // Размер массива
            int max = new Random().Next(8, 10);             // Максимальное значение

            int[] arr = GenerateSequence(size, max);        // Генерация случайной последовательности

            Console.WriteLine("Elements before sort");

            Print(arr);                                     // Отображение элементов до сортировки 

            QuickSort(arr, 0, arr.Length - 1);              // Сортировка значений

            Console.WriteLine("\nElements after sort");

            Print(arr);                                     // Отображение элементов после сортировки 

        }
    }
}
