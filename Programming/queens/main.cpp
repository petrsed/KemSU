/**********************************************************
* Автор: Седельников П.В                                  *
* Дата: 26.12.2021                                        *
* Задача: 04 Восемь ферзей                                *
* Ссылка: https://onlinegdb.com/GUHU_MPiG                 *
**********************************************************/

#include <iostream>
#include <stdio.h>
#include <string> 

using namespace std;

int amountSolutions = 0;
const int boardHeight = 8;
const int boardWidth = 8;
string boardLetters[boardHeight] = {"H", "G", "F", "E", "D", "C", "B", "A"};
int board[boardHeight][boardWidth];

void printBoard() {
    int QueenIndex = 0;
    
    for (int heightIndex = 0; heightIndex < boardHeight + 1; ++heightIndex) {
        for (int widthIndex = 0; widthIndex < boardWidth + 1; ++widthIndex) {
            if (heightIndex == 0) {
                if (widthIndex != 0) {
                    cout << widthIndex << " ";
                } else {
                    cout << "  ";
                }
            } else if (widthIndex == 0) {
                cout << boardLetters[heightIndex - 1] << " ";
            } else if (board[heightIndex - 1][widthIndex - 1]) {
                ++QueenIndex;
                cout << QueenIndex << " ";
            } else {
                cout << "0 ";
            }
        }
        cout << endl;
    }
}

bool tryQueen(int maxHeight, int widthIndex) {
    for (int heightIndex = 1; heightIndex <= maxHeight && widthIndex + heightIndex < boardHeight; heightIndex++) {
        if (board[maxHeight - heightIndex][widthIndex + heightIndex]) {
            return false;
        }
    }
    
    for (int heightIndex = 1; heightIndex <= maxHeight && widthIndex - heightIndex >= 0; heightIndex++) {
        if (board[maxHeight - heightIndex][widthIndex - heightIndex]) {
            return false;
        }
    }
    
    for (int heightIndex = 0; heightIndex < maxHeight; heightIndex++) {
        if (board[heightIndex][widthIndex]) {
            return false;
        }
    }
    
    return true;
}
 
void setQueen(int heightIndex) {
    if (heightIndex == boardHeight) {
        amountSolutions++;
        cout << "Вариант " << amountSolutions << ":" << endl;
        printBoard();
        cout << endl;
        return;
    }
    
    for (int widthIndex = 0; widthIndex < boardWidth; widthIndex++) {
        if (tryQueen(heightIndex, widthIndex)) {
            board[heightIndex][widthIndex] = 1;
            setQueen(heightIndex + 1);
            board[heightIndex][widthIndex] = 0;
        }
    }
}

void getSolutions() {
    int heightIndex = 0;
    
    if (heightIndex == boardHeight) {
        amountSolutions++;
        cout << "Вариант " << amountSolutions << ":" << endl;
        printBoard();
    }
    
    for (int widthIndex = 0; widthIndex < boardWidth; widthIndex++) {
        if (tryQueen(heightIndex, widthIndex)) {
            board[heightIndex][widthIndex] = 1;
            setQueen(heightIndex + 1);
            board[heightIndex][widthIndex] = 0;
        }
    }
}

int main() {
    setlocale(LC_ALL, "ru");
    
    getSolutions();
    cout << "Найдено решений: " << amountSolutions << endl;

    return 0;
}
