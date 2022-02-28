/**********************************************************
* Автор: Седельников П.В                                  *
* Дата: 14.02.2022                                        *
* Задача: 1. Базовые понятия языка С#, Подазадча №1       *
* Ссылка: https://onlinegdb.com/KvcfX4w6-                 *
**********************************************************/

using System;
class FirstTask {
    public static long Pow(long Number, int Degree) {
        long NewNumber = Number;
        
        for (int DegreeIndex = 1; DegreeIndex < Degree; DegreeIndex++) {
            NewNumber *= Number;
        }
        
        return NewNumber;
    }
    
    static void Main() {
        long Number = Convert.ToInt64((Console.ReadLine()));
        int Degree = Convert.ToInt32((Console.ReadLine()));
    
        Console.WriteLine(Pow(Number, Degree));
    }
}

