//Напишите программу, которая принимает на вход координаты точки (X и Y), причём X ≠ 0 и Y ≠ 0 
//и выдаёт номер четверти плоскости, в которой находится эта точка.
// -------------------------- Начало программы ----------------------------------
#region --- 00. Configuration ---
Console.Clear();
Console.Title = "Задача 17. Определение номера четверти по заданным координатам";

Console.OutputEncoding = System.Text.Encoding.UTF8;
var curConsoleColor = Console.ForegroundColor;
Console.ForegroundColor = ConsoleColor.DarkGreen;
Console.WriteLine(@"************************************************************************
Напишите программу, которая принимает на вход координаты точки (X и Y),
        причём X ≠ 0 и Y ≠ 0 и выдаёт номер четверти плоскости,
                в которой находится эта точка.
************************************************************************");
Console.ForegroundColor = curConsoleColor;
#endregion

#region --- 01. Input operations ---

int dimension; // Тип пространства для расчетов 2 - плоскости 3 - объем 
int x1, y1, z1, x2, y2, z2; // Координаты точек

// string errorMessage = "!!!Ошибка ввода даннyых. Ничего не введено";
dimension = GetNumberFromUser("Выбирете тип расчеты (2 -для плоскости или 3 -для объема): ", "Ошибка ввода данных!");

// Проверим что получено от пользователя
// Если, что то отличное от 2 или 3 запускаем тестовое задание
if (dimension != 2 && dimension != 3 )
{
    RunTest(out dimension, out x1, out y1, out z1, out x2, out y2, out z2);
}
else
{
    // Запустим процедуру получения координат точек А и В 
    // Для плоскости - переменная dimension = 2
    // Для побъема - переменная dimension = 3
    GetCoords(dimension, out x1, out y1, out z1, out x2, out y2, out z2);
}

#endregion --- 01. Input operations ---

#region --- 02. Business logic ---

double distance; // Расстояние между точками
string outString = "!!!START"; // Строка с сообщением
try
{
    // Вызов метода, расчета растояния между двумя точками 
    // по переданным координатам A(x1 и y1) B(x2 и y2) если на плоскости
    // или A(x1, y1, z1) B(x2, y2, z2) если в объеме
    // Результат вызова присваивается переменной distance.
    if (dimension == 2)
    {
        // Расчеты на плоскости
        distance = GetDistanceByCoords(x1, y1, x2, y2);
        outString = $"{dimension} Растояние между точками A({x1},{y1}) и B({x2},{y2}) равно: {distance}";
    }
    else if (dimension == 3)
    {
        // Расчеты в объеме
        distance = GetDistanceByCoords3(x1, y1, z1, x2, y2, z2);
        outString = $"{dimension} Растояние между точками A({x1},{y1},{z1}) и B({x2},{y2},{z2}) равно: {distance}";
    }
    else
    {
        // А для вего прочего рассчетов НЕТ
        outString = $"{dimension} Размерность пространства отличается от 2 или 3";
        //Console.WriteLine($"Размерность пространства отличается от 2 или 3");
        return;
    }
}
catch(Exception exc)
{
    Console.WriteLine($"ОШИБКА! {exc.Message}");
    return; // Завершение программы в случае ошибки
}
#endregion --- 02. Business logic ---

#region --- 03. Output operations ---
Console.WriteLine(outString);
#endregion --- 03. Output operations ---
// -------------------------- Конец программы ----------------------------------


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

// Определяем функцию, принимающую четыре аргумента 
// (координаты точек A(x1, y1) и B(x2, y2)
// и возвращающую растояние между точками
static double GetDistanceByCoords(int x1, int y1, int x2, int y2)
{
    double distance = Math.Sqrt(Math.Pow((x2-x1), 2)+Math.Pow((y2-y1), 2));
    return distance;
}

// Определяем функцию, принимающую шесть аргумента 
// (координаты точек A(x1, y1, z1) и B(x2, y2, z2)
// и возвращающую растояние между точками
static double GetDistanceByCoords3(int x1, int y1, int z1, int x2, int y2, int z2)
{
    double distance = Math.Sqrt(Math.Pow((x2-x1), 2) + Math.Pow((y2-y1), 2) + Math.Pow((z2-z1), 2));
    return distance;
}

// Определяем метод для ввода координат на плоскости или в объеме
// В случае плоскости dimension=2 пропускаем координаты Z
// Для двух точек A и B на плоскости четыре координаты, в объеме шесть координат
static void GetCoords(int dimension, out int x1, out int y1, out int z1, out int x2, out int y2, out int z2)
{
    x1=0; y1=0; z1=0; x2=0; y2=0; z2=0;
    if (dimension == 2 || dimension == 3)
    {
        // Вызов метода, запрашивающего у пользователя целое число. Введённое число присваивается переменной x1
        x1 = GetNumberFromUser("Введите целое число, для точки А по оси X: ", "Ошибка ввода данных!");
        // Вызов метода, запрашивающего у пользователя целое число. Введённое число присваивается переменной y1
        y1 = GetNumberFromUser("Введите целое число, для точки А, по оси Y: ", "Ошибка ввода данных!");
        if (dimension == 3)
        {
            z1 = GetNumberFromUser("Введите целое число, для точки А, по оси Z: ", "Ошибка ввода данных!");
        }
    }

    if (dimension == 2 || dimension ==3)
    {
        // Вызов метода, запрашивающего у пользователя целое число. Введённое число присваивается переменной x2
        x2 = GetNumberFromUser("Введите целое число, для точки B по оси X: ", "Ошибка ввода данных!");
        // Вызов метода, запрашивающего у пользователя целое число. Введённое число присваивается переменной y2
        y2 = GetNumberFromUser("Введите целое число, для точки B, по оси Y: ", "Ошибка ввода данных!");
        if (dimension == 3)
        {
            z2 = GetNumberFromUser("Введите целое число, для точки B, по оси Z: ", "Ошибка ввода данных!");
        }
    }

}

// Определяем метод запускающую тестовые примеры
static void RunTest(out int dimension, out int x1, out int y1, out int z1, out int x2, out int y2, out int z2)
{
    dimension = 0; x1 = 0; y1 = 0; z1 = 0; x2 = 0; y2 = 0; z2 = 0;
    Console.WriteLine(@"************************************************************************
Выбрать номер примера для теста программы, 
        Пример 1: A (3,6,8); B (2,1,-7), -> 15.84
        Пример 2: A (3,6); B (2,1) -> 5,09
        Пример 3: A (7,-5, 0); B (1,-1,9) -> 11.5
        Пример 4: A (7,-5); B (1,-1) -> 7,21
************************************************************************");

    int example = GetNumberFromUser("Введите целое число, номер примера: ", "Ошибка ввода данных!");

    if (example == 1)
    {
        // A (3,6,8); B (2,1,-7), -> 15.84
        ///*
        x1 = 3; y1 = 6; z1 = 8;
        x2 = 2; y2 = 1; z2 = -7;
        dimension = 3;
        //*/
    }
    else if (example == 2)
    {
        // A (3,6,); B (2,1), -> 5.09
        x1 = 3; y1 = 6; z1 = 0;
        x2 = 2; y2 = 1; z2 = 0;
        dimension = 2;
    }
    else if (example == 3)
    {
        // A (7,-5, 0); B (1,-1,9) -> 11.53
        x1 = 7; y1 = -5; z1 = 0;
        x2 = 1; y2 = -1; z2 = 9;
        dimension = 3;
    }
    else if (example == 4)
    {
        // A (7,-5); B (1,-1) -> 7,21
        x1 = 7; y1 = -5; z1 = 0;
        x2 = 1; y2 = -1; z2 = 0;
        dimension = 2;        
    }
}

// ---------------------- Конец определения методов ----------------------------