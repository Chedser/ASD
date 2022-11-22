/*
StudyWork1.cpp – Листинг программы для 1-ой лабораторной работы
* Вариант 2
*******************************************************************
* Имя файла : StudyWork1.cpp
* Резюме : Программа написанная на языке программирования С++
* Описание :  В списке А размера N необходимо каждый элемент заменить 
на ближайший следующий за ним элемент, который больше него. 
Если такого элемента нет, то заменить его на ноль
ПРИМЕР А = 1 3 2 5 3 4
ОТВЕТ А = 3 5 5 0 4 0
* Автор : Морозов Олег группа 21-ИВТз-3
******************************************************************
*/
#include <iostream>
#include <string>
#include "LinkedList.h"
#include "IOManager_h.h"
using std::cout;
using std::cin;
using std::endl;

const string FILENAME = "data.txt";

/* Прототип функции замены ближайшего максимального элемента */
template<typename T> void replace_nearests_max(LinkedList<T>* list);

    int main() {
        LinkedList<int>* list = new LinkedList<int>();  		// Создание списка
        int count = 6; 											// Количеcтво элементов списка
        int A[] = { 1, 3, 2, 5, 3, 4 }; 						// Массив для списка

        /* ЧТЕНИЕ ЗНАЧЕНИЙ ИЗ ФАЙЛА */
        IOManager::CreateRecords(A, count, FILENAME, " ");  	// Создание записи
        IOManager::SetRecords(A, count, FILENAME, " "); 		// Чтение значений в массив

        /*Заполнение списка*/
        for (int i = 0; i < count; i++) { list->push(A[i]); }

        cout << "List1 elements before replace" << endl;
        list->print();  										// Печать элементов списка
        replace_nearests_max<int>(list); 						// Замена ближайших максимальных элементов списка
        cout << "List1 elements after replace" << endl;
        list->print(); 											// Печать элементов списка после замены
        
        list->clear(); 											// Очистка элементов списка
        
        cout << "Input count of elements for list2:" << endl;

        string count2_str;

        cin >> count2_str;

        /* Проверка правильности ввода */
        while (!IOManager::IsDigit(count2_str) || std::stoi(count2_str) <= 1) 
        {
            cout << "Wrong input" << endl;
            cout << "Input count of elements for list2:" << endl;
            cin >> count2_str;
        }

        count = std::stoi(count2_str);

        string current_element_str;

        /* Ввод элементов */
        for (int i = 0; i < count; ) 
        {
            cout << "Input element " << i + 1 << ":" << endl;
            cin >> current_element_str;
            cout << endl;

            /* Проверка правильности ввода */
            if (!IOManager::IsDigit(current_element_str)) 
            {
                cout << "Wrong input" << endl;
                continue;

            }
 
                list->push(std::stoi(current_element_str));
                ++i; 

        }

        cout << "List2 elements before replace" << endl;
        list->print();  				// Печать элементов списка
        replace_nearests_max<int>(list); // Замена близжайших максимальных элементов списка
        cout << "List2 elements after replace" << endl;
        list->print(); 					// Печать элементов списка после замены

        list->clear(); 					// Очистка элементов списка
   
        delete list;

        system("PAUSE");

        return 0;
    }

    /* Определение функции замены ближайшего максимального элемента */
    template<typename T> void replace_nearests_max(LinkedList<T>* list) 
    {
        if (list->is_empty()) throw 1;

        int j = 0;

        for (int i = 0; i < list->count(); i++) 
        {
            for (j = i + 1; j < list->count(); j++) 
            {
                if (list->get_by_index(j) > list->get_by_index(i)) 
                {
                    list->replace(i, list->get_by_index(j));
                    break;
                }
            }
            if (j == list->count()) list->replace(i, 0);
        }
    }

