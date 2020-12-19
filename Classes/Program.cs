using System;

namespace Bills_Reminder_app
{
    class Program
    {
        static void startupQuestions()
        {
            Console.WriteLine("");
        }
        static void billInputQuestions()
        {
            Console.WriteLine("Enter the name of the bill");
            Console.WriteLine("How much is each payment of the bill");
        }
        static void Main(string[] rgs)
        {
            billInputQuestions();
        }
    }
}
