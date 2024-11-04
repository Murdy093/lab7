using System;
using System.Threading;

class Program
{
    static void DisplayMessage(object parameters)
    {
        if (parameters is string message)
        {
            Console.WriteLine("Повiдомлення: " + message);
        }
        else
        {
            var paramArray = parameters as object[];
            if (paramArray != null && paramArray.Length == 2 &&
                paramArray[0] is string name && paramArray[1] is int age)
            {
                Console.WriteLine($"Iм'я: {name}, Вiк: {age}");
            }
        }
    }

    static void Main()
    {
        
        Thread thread1 = new Thread(new ParameterizedThreadStart(DisplayMessage));
        thread1.Start("Привiт, свiте!");

        
        var parameters = new object[] { "Олександр", 25 };
        Thread thread2 = new Thread(new ParameterizedThreadStart(DisplayMessage));
        thread2.Start(parameters);

        
        thread1.Join();
        thread2.Join();
        Console.ReadKey();
    }
}
