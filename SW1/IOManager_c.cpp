
#ifndef IOMANAGER_C
#define IOMANAGER_C

#include "IOManager_h.h"
#include <string>
#include <vector>
#include <fstream>

using std::cout;

bool IOManager::IsDigit(string str) 
{

    if (str.empty()) { return false; }

    bool isDigit = true;

    for (char s : str) 
    {

        if (!isdigit(s)) 
        {

            isDigit = false;
            break;

        }

    }

    return isDigit;

}

vector<string> IOManager::SplitString(string str, string delimiter) 
{

    std::vector<std::string> splittedString;
    int startIndex = 0;
    int  endIndex = 0;
    while ((endIndex = str.find(delimiter, startIndex)) < str.size())
    {
        std::string val = str.substr(startIndex, endIndex - startIndex);
        splittedString.push_back(val);
        startIndex = endIndex + delimiter.size();
    }
    if (startIndex < str.size())
    {
        std::string val = str.substr(startIndex);
        splittedString.push_back(val);
    }
    return splittedString;

}

void IOManager::CreateRecords(int* records, int recordsCount, string fileName, const char* delimiter) 
{
    std::ofstream fout(fileName, std::ios::out);

    if (!fout.is_open()) 
    {
        cout << "File opening error\n";
        exit(1);
    }

    for (int i = 0; i < recordsCount; i++) { fout << records[i] << delimiter; }

    fout.flush();
    fout.close();

}

void IOManager::SetRecords(int* arr, int count, string  fileName, string delimiter) {
    ifstream fin(fileName);

    if (!fin.is_open()) { throw std::runtime_error("File opening error\n"); }

    string str;

    std::getline(fin, str);

    fin.close();

    vector<string> digits = SplitString(str, delimiter);

    for (int i = 0; i < digits.size(); i++) 
    {
        if (!IsDigit(digits[i])) {
            throw std::runtime_error("Damaged file\n");
            break;
        }
    }

    for (int i = 0; i < count; i++) { arr[i] = std::stoi(digits[i]); }

}

#endif
