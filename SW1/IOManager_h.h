#ifndef IOMANAGER_H
#define IOMANAGER_H


#include <iostream>
#include <fstream>
#include <vector>

using std::string;
using std::ifstream;
using std::vector;

    /* Вспомогательный класс для работы с файлами */
    class IOManager {

    public:

        static bool IsDigit(string str); //Проверка на цифру
        static vector<string> SplitString(string str, string delimiter); // Разделение строки
        /* Создание записи в файле */
        static void CreateRecords(int* records, int recordsCount, string fileName, const char* delimiter);
        /* Чтение значений из файла в массив */
        static void SetRecords(int* a, int count, string  fileName, string delimiter);

    };

#endif
