/**********************************************************
* Автор: Седельников П.В                                  *
* Дата: 24.12.2021                                        *
* Задача: 01 Частота повторений                           *
* Ссылка: https://onlinegdb.com/NJ9aAA7Gu                 *
**********************************************************/

#include <iostream>
#include <string> 
#include <fstream> 
#include <stdio.h>

using namespace std;

string getText(string fileName) {
    fstream file;
    string text;
    char line;
    char nextLineSymbol = '\n';
    
    file.open(fileName);
    while (file.get(line)) {
        if (line != nextLineSymbol) {
            text += line;
        } else {
            text += " ";
        }
    }
    return text;
}

int countNumberOfOccurrences(string needLine, string text) {
    int textLength = text.length();
    int needLineLength = needLine.length();
    int checkingIndex = 0;
    int numberOfOccurrences = 0;
    
    for (int symbolIndex = 0; symbolIndex < textLength; ++symbolIndex) {
        char symbol = text[symbolIndex];
        char needSymbol = needLine[checkingIndex];
        if (symbol == needSymbol) {
            ++checkingIndex;
            if (checkingIndex == needLineLength) {
                ++numberOfOccurrences;
                checkingIndex = 0;
            }
        }
    }
    
    return numberOfOccurrences;
}

int main() {
    setlocale(LC_ALL, "ru");
    
    string text = getText("data.txt");
    
    string needLine;
    cout << "Введите подстроку для поиска: ";
    cin >> needLine;
    
    int numberOfOccurrences = countNumberOfOccurrences(needLine, text);
    cout << "\nКоличество вхождений подстроки '" << needLine << "' в заданный текст: " << numberOfOccurrences;
}
