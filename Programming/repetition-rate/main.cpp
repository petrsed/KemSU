/**********************************************************
* Автор: Седельников П.В                                  *
* Дата: 24.12.2021                                        *
* Задача: 01 Частота повторений                           *
* Ссылка: https://onlinegdb.com/WoCn5pqPN                 *
**********************************************************/

#include <iostream>
#include <string> 
#include <fstream> 
#include <stdio.h>
#include <vector>

using namespace std;

vector<string> getAllTwoLettersCombinations() {
    string combination = "";
    vector<string> twoLettersCombinations;
    string firstLetter, secondLetter;
    
    for (int firstLetterIndex = 0; firstLetterIndex < 26; firstLetterIndex++) {
        firstLetter = 97 + firstLetterIndex;
        for (int secondLetterIndex = 0; secondLetterIndex < 26; secondLetterIndex++) {
            secondLetter = 97 + secondLetterIndex;
            combination = firstLetter+secondLetter;
            twoLettersCombinations.push_back(combination);
        }
    }
    
    return twoLettersCombinations;
}

vector<string> getAllOneLettersCombinations() {
    vector<string> oneLettersCombinations;
    string letter;
    
    for (int letterIndex = 0; letterIndex < 26; letterIndex++) {
        letter = 97 + letterIndex;
        oneLettersCombinations.push_back(letter);
    }
    
    return oneLettersCombinations;
}

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
        } else {
            checkingIndex = 0;
        }
    }
    
    return numberOfOccurrences;
}

void printAnountsOfCombinations(string text, vector<string> oneLettersCombinations,
                                vector<string> twoLettersCombinations) {
    string combination = "";
    int combinationAmountOfOccurrences = 0;
    
    int oneLettersCombinationsAmount = oneLettersCombinations.size();
    int twoLettersCombinationsAmount = twoLettersCombinations.size();
    
    cout << "Количество однобуквенных комбинаций:" << endl;
    for (int combinationIndex = 0; combinationIndex < oneLettersCombinationsAmount; ++combinationIndex) {
        combination = oneLettersCombinations[combinationIndex];
        combinationAmountOfOccurrences = countNumberOfOccurrences(combination, text);
        if (combinationAmountOfOccurrences != 0) {
            cout << combination << " - " << combinationAmountOfOccurrences << endl;
        }
    }
    
    cout << endl;
    
    cout << "Количество двухбуквенных комбинаций:" << endl;
    for (int combinationIndex = 0; combinationIndex < twoLettersCombinationsAmount; ++combinationIndex) {
        combination = twoLettersCombinations[combinationIndex];
        combinationAmountOfOccurrences = countNumberOfOccurrences(combination, text);
        if (combinationAmountOfOccurrences != 0) {
            cout << combination << " - " << combinationAmountOfOccurrences << endl;
        }
    }
}

int main() {
    setlocale(LC_ALL, "ru");
    
    string text = getText("data.txt");
    vector<string> oneLettersCombinations = getAllOneLettersCombinations();
    vector<string> twoLettersCombinations = getAllTwoLettersCombinations();
    
    printAnountsOfCombinations(text, oneLettersCombinations, twoLettersCombinations);
}
