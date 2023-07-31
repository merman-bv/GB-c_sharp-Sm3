/*
Принимает на вход пятизначное число и проверяет, является ли оно палиндромом.
        14212 -> нет
        23432 -> да
        12821 -> да
*/

// Очистим косоль
Console.Clear();

#region --- 01. Input operations ---

// Попросим ввести пятизначное число
int n5 = GetNumberFromUser("Введите целое пятизначное число: ", "Ошибка ввода данных!");

// Проверим что число пятизначное, разделив на 10000, 
// Получим челое число больше нуля и меньше 9
// Иначе запустим тестовые примеры
int check = n5/10000;
if (check == 0  || check >9 )
{
    int testRes = 0;
    while( testRes == 0 )
    {
        testRes = RunTest();
    }
    n5 = testRes;
}

#endregion --- 01. Input operations ---


#region --- 02. Business logic ---

string outString = $"<{n5}> ";

int firstNum = GetRank(n5, 1);
int secondNum = GetRank(n5, 2);
int centreNum = GetRank(n5, 3);
int lastNextNum = GetRank(n5, 4);
int lastNum = n5 % 10;
outString = outString + $"{firstNum}, {secondNum}, {centreNum}, {lastNextNum}, {lastNum}";
if ( firstNum ==  lastNum && secondNum == lastNextNum ) outString = outString + " -> Да";
else outString = outString + " -> НЕТ";

#endregion --- 02. Business logic ---


#region --- 03. Output operations ---
Console.WriteLine(outString);
#endregion --- 03. Output operations ---


// -------------------------Определение методов ---------------------------------

// Определяем функцию, выполняющую ввод целого числа с консоли
static int GetNumberFromUser(string message, string errorMessage)
{   
    while(true)
    {
        try
        {
            Console.Write(message);
            return int.Parse(Console.ReadLine() ?? "");            
        }
        catch (Exception exc)
        {
            Console.WriteLine($"{errorMessage} {exc.Message}");        
        }
    }
}

static int GetRank(int number, int position)
{
    int rank = 0 ;
    if ( position == 1 ) rank = 9;
    if ( position == 2 ) rank = 99;
    if ( position == 3 ) rank = 999;
    if ( position == 4 ) rank = 9999;
    while (number > rank)
    {
        number /=10;
        //Console.WriteLine($"{number} ");
    }
    //Console.WriteLine($"<{number%10}> ");
    return number % 10;
}

static int RunTest()
{
    Console.WriteLine(@"Выбрать номер тестового примера 
    Пример 1: 14212 -> нет
    Пример 2: 23432 -> да
    Пример 3: 12821 -> да");

    int example = GetNumberFromUser("Введите номер примера: ", "Ошибка ввода данных!");

    if (example == 1)
    {
        // Пример 2: 14212 -> нет
        return 14212;
    }
    else if (example == 2)
    {
        // Пример 2: 23432 -> да
        return 23432;
    }
    else if (example == 3)
    {
        // Пример 3: 12821 -> да
        return 12821;
    }
    return 0;
}
// ---------------------- Конец определения методов ----------------------------