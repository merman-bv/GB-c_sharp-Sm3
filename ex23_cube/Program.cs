/*
Принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.
        3 -> 1, 8, 27
        5 -> 1, 8, 27, 64, 125
*/

Console.Clear();

#region --- 01. Input operations ---

int nn = GetNumberFromUser("Введите целое число N: ", "Ошибка ввода данных!");

#endregion --- 01. Input operations ---


#region --- 02. Business logic ---

string outString = $"{nn} -> ";
int count = 1;
while (count <= nn)
{
    outString  = outString  + Math.Pow(count, 3);
    if (count == nn)
    {
        outString = outString + ".";
    }
    else
    {
        outString = outString + ", ";
    }
    count ++;
}

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


// ---------------------- Конец определения методов ----------------------------