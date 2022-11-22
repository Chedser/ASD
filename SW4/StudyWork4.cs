/*
StudyWork4.cs – Листинг программы для 4-й лабораторной работы
* Вариант 2
*******************************************************************
* Имя файла : StudyWork4.cs
* Резюме : Программа написанная на языке программирования С#
* Описание :  Реализовать алгоритмы поиска, вставки, 
* удаления элементов таблицы и распечатки таблицы 
* и метод ре-хэширования таблицы при увеличении размера данных
* Автор : Морозов Олег группа 21-ИВТз-3
******************************************************************
*/

using System;

namespace StudyWork4
{
    class StudyWork4
    {
        /* Дробная часть */
       static double Fractional(double number) { return (number - (ulong)number); }

        /* Хеш-функция */
       static ulong Hash(ulong key, ulong size, ulong[] table) {

            const double FIBO = 0.6180339887;

            ulong hash;
            double fract = Fractional(key * FIBO);
                        
            hash = (ulong)(size * fract);           // Вычисление хеша

            /* Поиск элемента в таблице */
            for (int i = 0; i < table.Length; i++)
            {

                if (table[hash] != 0) // Слот не пуст 
                {

                    /* Вычисление нового хеша */
                    for (int j = 0; j < table.Length; j++)
                    {

                        ulong new_hash = (hash + (ulong)(2 * j) + (ulong)(j * j));
                        if (table[new_hash] == 0)
                        {
                            hash = new_hash;
                            break;
                        }
                    }
                }
            }

                return hash;

        }

        /* Получить значение по хешу */
        static ulong GetValue(ulong hash, ulong[] table) {
            return table[hash];
        }

        /* Установка значения */
        static void SetValue(ulong key, ulong size, ulong[] table) {
            ulong hash = Hash(key, size, table);
            table[hash] = key;
        }

        /* Удаление значения */
        static void DeleteValue(ulong key, ulong size, ulong[] table) {
            ulong hash = Hash(key, size, table);
            table[hash] = 0;
        }

        /* Печать значений таблицы */
        static void Print(ulong[] table) {
            for(int i = 0; i < table.Length; i++) {

                if (table[i] != 0)
                {
                    Console.WriteLine("{0} {1}", i, table[i]);
                }
            
            }
        }
    
        static void Main(string[] args)
        {
      
            string key_txt;     						// Строка для ввода пользователя
            ulong key;          						// Ключ
            ulong size = (ulong)Math.Pow(10, 11) - 2; 	// Размер таблицы
            ulong[] table = new ulong[size];         	// Массив для хранения ключей

            int max_length = 13;            			//Максимальная длина ключа
            int min_length = 11;            			//Минимальная длина ключа

		   /* Ввод значения */
            while (true)
            {
                try {
                    Console.WriteLine("Enter phone number");
                    key_txt = Console.ReadLine();
                    key = Convert.ToUInt64(key_txt);

                        if (key_txt == "0000000000000" ||
                            key_txt == "9999999999999" ||
                            key_txt.Length > max_length ||
                            key_txt.Length < min_length ||
                            key <= 0)
                        {
                            Console.WriteLine("\nWrong input");
                            continue;
                        }

                        break;
                    }
                catch (Exception ex) {
                    Console.WriteLine("\nWrong input");
                }

            }

            SetValue(key, size, table); 			    // Установка значения
            Console.WriteLine("\nHash and value");
            Print(table);								// Печать хеша и значения

        }
     
     }
}

