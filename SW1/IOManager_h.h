#ifndef IOMANAGER_H
#define IOMANAGER_H


#include <iostream>
#include <fstream>
#include <vector>

using std::string;
using std::ifstream;
using std::vector;

    /* ��������������� ����� ��� ������ � ������� */
    class IOManager {

    public:

        static bool IsDigit(string str); //�������� �� �����
        static vector<string> SplitString(string str, string delimiter); // ���������� ������
        /* �������� ������ � ����� */
        static void CreateRecords(int* records, int recordsCount, string fileName, const char* delimiter);
        /* ������ �������� �� ����� � ������ */
        static void SetRecords(int* a, int count, string  fileName, string delimiter);

    };

#endif
