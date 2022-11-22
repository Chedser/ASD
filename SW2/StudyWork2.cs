/*
StudyWork2.cpp – Листинг программы для 2-ой лабораторной работы
* Вариант 2
*******************************************************************
* Имя файла : StudyWork2.cpp
* Резюме : Программа написанная на языке программирования С#
* Описание :  Даны две разреженные матрицы (Ленточный строчный формат). 
* Сложить их и результат занести в разреженную матрицу CS
******************************************************************
*/
using System;
using System.Collections;

namespace StudyWork2
{
    class StudyWork2
    {

        static void Main(string[] args)
        {

            /* Количество строк и столбцов */
            int rows1 = 0;
            int cols1 = 0;
            int rows2 = 0;
            int cols2 = 0;

            /* Переменные для валидации ввода */
            bool is_valid_input = false;
            bool is_valid_rows1 = false;
            bool is_valid_cols1 = false;
            bool is_valid_rows2 = false;
            bool is_valid_cols2 = false;

            Console.WriteLine("First matrix");

            /* Валидация ввода */
            while (!is_valid_input) {

                try {

                    if (!is_valid_rows1) {
                        Console.WriteLine("Enter count of rows");
                        rows1 = Convert.ToInt32(Console.ReadLine());

                        if (rows1 <= 0)
                        {
                            Console.WriteLine("Wrong input");
                            continue;
                        }

                    }

                    is_valid_rows1 = true;

                    if (!is_valid_cols1)
                    {

                        Console.WriteLine("Enter count of cols");

                        cols1 = Convert.ToInt32(Console.ReadLine());

                        if (cols1 <= 0)
                        {
                            Console.WriteLine("Wrong input");
                            continue;
                        }

                    }

                    is_valid_cols1 = true;

                    if (!is_valid_rows2) {

                        Console.WriteLine("\nSecond matrix");
                        Console.WriteLine("Enter count of rows");
                        rows2 = Convert.ToInt32(Console.ReadLine());

                        if (rows2 <= 0)
                        {
                            Console.WriteLine("Wrong input");
                            continue;
                        }

                        if (rows1 != rows2)
                        {
                            Console.WriteLine("Rows must be equals\n");
                            continue;
                        }

                    }

                    is_valid_rows2 = true;

                    if (!is_valid_cols2)
                    {

                        Console.WriteLine("Enter count of cols");

                        cols2 = Convert.ToInt32(Console.ReadLine());

                        if (cols2 <= 0)
                        {
                            Console.WriteLine("Wrong input");
                            continue;
                        }

                        if (cols1 != cols2)
                        {
                            Console.WriteLine("Cols must be equals\n");
                            continue;
                        }

                    }

                    is_valid_cols2 = true;
                    is_valid_input = true;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("\nWrong input");
                }

            }

            Matrix sm1 = new Matrix(rows1, cols1, 1);
            Matrix sm2 = new Matrix(rows2, cols2, 1);

            Console.WriteLine("\nMatrix1");
            sm1.Print();

            Console.WriteLine("\nMatrix2");
            sm2.Print();

            Matrix sm3 = sm1.Add(ref sm2);          // Сложение элементов матриц

            Console.WriteLine("\nSum of matrixes");
            sm3.Print();

            ArrayList sparsedMatrix = sm3.Sparse(); // Разреженная матрица

            Console.WriteLine("Sparsed matrix");
            PrintSparsedMatrix(sparsedMatrix);      // Отображение разреженной матрицы

        }

        static void PrintSparsedMatrix(ArrayList matrix) {
            foreach (ArrayList list in matrix) {
                foreach (int element in list)
                {
                    Console.Write(element + " ");
                }
                Console.WriteLine("\n");
            }
        } 
    }
}

