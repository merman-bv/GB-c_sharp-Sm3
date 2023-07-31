/*  
По заданному номеру четверти, показывает диапазон 
возможных координат точек в этой четверти (x и y).
*/
// -------------------------- Начало программы ----------------------------------

#region --- 01. Input operations ---
// Вызов метода, запрашивающего у пользователя целое число. Введённое число присваивается переменной x
int Quarter = GetNumberQuarterFromUser();
if (Quarter > 4) 
{
    Console.WriteLine($"ОШИБКА! Введенное число {Quarter} не соответствует ни одной четверти ");
    return;
}
#endregion --- 01. Input operations ---

#region --- 02. Business logic ---
string Coords;
try
{
    // Вызов метода, возвращающего номер четверти по переданным координатам x и y.
    // Результат вызова присваивается переменной quarter.
    Coords = GetCoordsByQuarter(Quarter);
}
catch(Exception exc)
{
    Console.WriteLine($"ОШИБКА! {exc.Message}");
    return; // Завершение программы в случае ошибки
}
#endregion --- 02. Business logic ---

#region --- 03. Output operations ---
Console.WriteLine($"Диапазон возможных координат этой <{Quarter}> четверти: {Coords}");
#endregion --- 03. Output operations ---
// -------------------------- Конец программы ----------------------------------

// -------------------------Определение методов ---------------------------------
// Определяем функцию, выполняющую ввод целого числа с консоли
static int GetNumberQuarterFromUser()
{   
    while(true)
    {
        try
        {
            Console.Write("Введите целое число: ");
            int num = int.Parse(Console.ReadLine() ?? "");
            return num;
        }
        catch (Exception exc)
        {
            Console.WriteLine($"Ошибка ввода данных! {exc.Message}");        
        }
    }
}
// Определяем функцию, принимающую один аргумента (номер цетверти)
// и возвращающую 
// 
static string GetCoordsByQuarter(int Quarter)
{
    if (Quarter == 1) 
    {
        return "x > 0 && y > 0";
    }
    else if (Quarter == 2)
    {
            return "x < 0 && y > 0";
    }
    else if (Quarter == 3)
    {
            return "x < 0 && y < 0";
    }
    else if (Quarter == 4)
    {
            return "x > 0 && y < 0";
    }
    else 
    {
            throw new Exception("Точка попадает на оси координат!");
    }
    /*
    if(x > 0 && y > 0)
        return 1;
    else if(x < 0 && y > 0)
        return 2;
    else if(x < 0 && y < 0)
        return 3;
    else if(x > 0 && y < 0)
        return 4;
    else
        throw new Exception("Точка попадает на оси координат!");
    */
    //return 0;
}

// ---------------------- Конец определения методов ----------------------------