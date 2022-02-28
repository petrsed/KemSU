/**********************************************************
* Автор: Седельников П.В                                  *
* Дата: 14.02.2022                                        *
* Задача: 1. Базовые понятия языка С#, Подазадча №2       *
* Ссылка: https://www.onlinegdb.com/edit/iQaFCRrCS        *
**********************************************************/

using System;
class Second {
    static void GetNewNumber(string Number) {
        for (int SymbolIndex = 0; SymbolIndex < Number.Length; ++SymbolIndex) {
            if (SymbolIndex != 1) {
                Console.Write(Number[SymbolIndex]);
            }
        }
        
        Console.Write(Number[1]);
    }
    
    static void Main() {
        string Number = (Console.ReadLine());
    
        GetNewNumber(Number);
    }
}
