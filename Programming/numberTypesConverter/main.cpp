/**********************************************************
* Автор: Седельников П.В                                  *
* Дата: 25.12.2021                                        *
* Задача: 03 Перевод арабских чисел                       *
* Ссылка: https://onlinegdb.com/OYJGtdrVY                 *
**********************************************************/

#include <iostream>
#include <string> 
#include <fstream> 
#include <stdio.h>

using namespace std;

int getOperationType() {
    int operationType;
    
    cout << "Выберите тип операции:" << endl;
    cout << "1) Арабские > Римские" << endl;
    cout << "2) Римские > Арабские" << endl;
    cout << "Тип операции: ";
    cin >> operationType;
    cout << endl;
    
    return operationType;
}

int getArabicNumber() {
    int arabicNumber;
    
    cout << "Введите арабское число: ";
    cin >> arabicNumber;
    
    return arabicNumber;
}

string getRomanNumber() {
    string romanNumber;
    
    cout << "Введите римское число: ";
    cin >> romanNumber;
    
    return romanNumber;
}

string encodeArabicToRoman(int arabicNumber) {
    string romanNumber = "";
    while (arabicNumber > 0) {
        if (arabicNumber >= 1000) {
            arabicNumber -= 1000;
            romanNumber += "M";
        } else if (arabicNumber >= 900) {
            arabicNumber -= 900;
            romanNumber += "CM";
        } else if (arabicNumber >= 500) {
            arabicNumber -= 500;
            romanNumber += "D";
        } else if (arabicNumber >= 400) {
            arabicNumber -= 400;
            romanNumber += "CD";
        } else if (arabicNumber >= 100) {
            arabicNumber -= 100;
            romanNumber += "C";
        } else if (arabicNumber >= 90) {
            arabicNumber -= 90;
            romanNumber += "XC";
        } else if (arabicNumber >= 50) {
            arabicNumber -= 50;
            romanNumber += "L";
        } else if (arabicNumber >= 40) {
            arabicNumber -= 40;
            romanNumber += "XL";
        } else if (arabicNumber >= 10) {
            arabicNumber -= 10;
            romanNumber += "X";
        } else if (arabicNumber >= 9) {
            arabicNumber -= 9;
            romanNumber += "IX";
        } else if (arabicNumber >= 5) {
            arabicNumber -= 5;
            romanNumber += "V";
        } else if (arabicNumber >= 4) {
            arabicNumber -= 4;
            romanNumber += "IV";
        } else {
            arabicNumber -= 1;
            romanNumber += "I";
        }
    }
    return romanNumber;
}

int encodeRomanToArabic(string romanNumber) {
    int arabicNumber = 0;
    int romanNumberLength = romanNumber.length();
    
    char previousSymbol = '-';
    for (int symbolIndex = 0; symbolIndex < romanNumberLength; ++symbolIndex) {
        char symbol = romanNumber[symbolIndex];
        if (symbol == 'M') {
            if (previousSymbol == 'C') {
                arabicNumber -= 100;
                arabicNumber += 900;;
            } else {
                arabicNumber += 1000;
            }
            previousSymbol = 'M';
        } else if (symbol == 'C') {
            if (previousSymbol == 'X') {
                arabicNumber -= 10;
                arabicNumber += 90;;
            } else {
                arabicNumber += 100;
            }
            previousSymbol = 'C';
        } else if (symbol == 'D') {
            if (previousSymbol == 'C') {
                arabicNumber -= 100;
                arabicNumber += 400;;
            } else {
                arabicNumber += 500;
            }
            previousSymbol = 'D';
        } else if (symbol == 'L') {
            if (previousSymbol == 'X') {
                arabicNumber -= 10;
                arabicNumber += 40;;
            } else {
                arabicNumber += 50;
            }
            previousSymbol = 'L';
        } else if (symbol == 'X') {
            if (previousSymbol == 'I') {
                arabicNumber -= 1;
                arabicNumber += 9;;
            } else {
                arabicNumber += 10;
            }
            previousSymbol = 'X';
        } else if (symbol == 'V') {
            if (previousSymbol == 'I') {
                arabicNumber -= 1;
                arabicNumber += 4;;
            } else {
                arabicNumber += 5;
            }
            previousSymbol = 'V';
        } else if (symbol == 'I') {
            arabicNumber += 1;
            previousSymbol = 'I';
        }
    }
    
    return arabicNumber;
}

int main() {
    setlocale(LC_ALL, "ru");
    
    int operationType = getOperationType();
    if (operationType == 1) {
        int arabicNumber = getArabicNumber();
        string romanNumber = encodeArabicToRoman(arabicNumber);
        cout << "Конвертированное римское число: " << romanNumber;
    } else if (operationType == 2) {
        string romanNumber = getRomanNumber();
        int arabicNumber = encodeRomanToArabic(romanNumber);
        cout << "Конвертированное арабское число: " << arabicNumber;
    } else {
        cout << "Неверный тип операции!";
    }
    
    return 0;
}