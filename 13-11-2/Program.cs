
using System;

class UserRegistration
{
    public static void RegisterUser(string username, int age)
    {
        if (username == null || username.Length < 2)
            throw new ArgumentException("Имя пользователя должно содержать не менее 2 символов");

        if (age < 18 || age > 120)
            throw new ArgumentOutOfRangeException(nameof(age), "Возраст должен быть в диапазоне от 18 до 120 лет");

        Console.WriteLine($"Пользователь {username} успешно зарегистрирован!");
    }
}

class PaymentProcessor
{
    static void ProcessTransaction()
    {
        throw new InvalidOperationException("Сбой соединения с сервером");
    }

    static void ExecutePayment()
    {
        try
        {
            ProcessTransaction();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Лог сервиса]: Логгируем ошибку {ex.Message}");
            throw;
        }
    }

    public static void Run()
    {
        try
        {
            ExecutePayment();
        }
        catch (Exception ex)
        {
            Console.WriteLine("[Внешний обработчик]:");
            Console.WriteLine(ex.StackTrace);
        }
    }
}

class DataParser
{
    public static double ParseAndDivide(string[] data, int index, int divisor)
    {
        if (data == null)
            throw new NullReferenceException("Массив не должен быть null");

        if (index < 0 || index >= data.Length)
            throw new IndexOutOfRangeException("Индекс вне диапазона");

        int number = int.Parse(data[index]);

        if (divisor == 0)
            throw new DivideByZeroException("Деление на ноль");

        return (double)number / divisor;
    }
}

class Program
{
    static void Main()
    {


        try
        {
            UserRegistration.RegisterUser("A", 15);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"[Ошибка аргумента]: {ex.Message}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"[Некорректное имя]: {ex.Message}");
        }


        PaymentProcessor.Run();



        try
        {
            double result = DataParser.ParseAndDivide(
                new string[] { "100", "abc" }, 1, 0);

            Console.WriteLine($"Результат: {result}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Деление на ноль!");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Неверный формат числа!");
        }
        catch (IndexOutOfRangeException ex)
        {
            Console.WriteLine("Индекс вне диапазона!");
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine("Массив равен null!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Общая ошибка: {ex.Message}");
        }
    }
}
