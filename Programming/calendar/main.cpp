/**********************************************************
* Автор: Седельников П.В                                  *
* Дата: 24.12.2021                                        *
* Задача: 02 Каледарь в консоли                           *
* Ссылка: https://onlinegdb.com/3-2Gt7S9n                 *
**********************************************************/

#include <iostream>
#include <string> 
#include <fstream> 
#include <stdio.h>

using namespace std;

string monthNames[12] = {"Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"};
string dayNames[7] = {"ПН", "ВТ", "СР", "ЧТ", "ПТ", "СБ", "ВС"};

bool isLeepYear(int year) {
    if (year % 400 == 0) {
        return true;
    } else if (year % 100 == 0) {
        return false;
    } else if (year % 4 == 0) {
        return true;
    } else {
        return false;
    }
}

int getFirstDayIndex(int year) {
    int dayIndex = 5;
    
    for (int yearIndex = 1600; yearIndex < year; ++yearIndex) {
        if (isLeepYear(yearIndex)) {
            dayIndex += 2;
        } else {
            dayIndex += 1;
        }
    }
    
    dayIndex %= 7;
    return dayIndex;
}

int firstDayIndex = 0;

int getdaysInMonth(int monthIndex, int year) {
    if (monthIndex != 1) {
        if (monthIndex == 3 || monthIndex == 5 || monthIndex == 8 || monthIndex == 10) {
            return 30;
        } else {
            return 31;
        }
    } else {
        if (isLeepYear(year)) {
            return 29;
        } else {
            return 28;
        }
    }
}

void drawMonth(int year, int monthIndex) {
    bool calendarIsDrawed = false;
    int daysInMonth = getdaysInMonth(monthIndex, year);
    int dayNumber = 1;
    cout << monthNames[monthIndex] << ":" << endl;
    
    for (int dayIndex = 0; dayIndex < 7; ++dayIndex) {
        cout << dayNames[dayIndex] << "\t";
    }
    cout << endl;
    
    for (int lineIndex = 0; lineIndex < 6; ++lineIndex) {
        for (int dayIndex = 0; dayIndex < 7; ++dayIndex) {
            if (!calendarIsDrawed) {
                if (firstDayIndex != 0) {
                    cout << "  \t"; 
                    --firstDayIndex;
                } else {
                    if (dayNumber <= daysInMonth) {
                        cout << dayNumber << "\t";
                        if (dayNumber == daysInMonth) {
                            calendarIsDrawed = true;
                            firstDayIndex = dayIndex + 1;
                            firstDayIndex %= 7;
                            break;
                        }
                        ++dayNumber;
                    } else {
                        firstDayIndex = dayIndex;
                        break;
                    }
                }
            }
        }
        cout << endl;
    }
    
    cout << endl << endl << endl;
}

void drawCalendar(int year) {
    firstDayIndex = getFirstDayIndex(year);
    
    for (int monthIndex = 0; monthIndex < 12; ++monthIndex) {
        drawMonth(year, monthIndex);
    }
}

int main() {
    setlocale(LC_ALL, "ru");
    
    int year;
    cout << "Введите год: ";
    cin >> year;
    
    drawCalendar(year);
}
