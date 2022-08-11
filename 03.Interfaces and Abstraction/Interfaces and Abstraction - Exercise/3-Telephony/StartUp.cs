using System;
using System.Linq;

namespace _3_Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();

            string[] numbers = firstLine.Split();
            string[] websites = secondLine.Split();

            foreach (var item in numbers)
            {
                if (!item.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid number!");
                }
                else if (item.Length == 7)
                {
                    StationaryPhone stPhone = new StationaryPhone(item);
                    Console.WriteLine(stPhone.Dial());
                }
                else if (item.Length == 10)
                {
                    Smartphone smPhone = new Smartphone(null, item);
                    Console.WriteLine(smPhone.Call());
                }
            }

            foreach (var item in websites)
            {
                if (item.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Smartphone smPhone = new Smartphone(item, null);
                    Console.WriteLine(smPhone.Browse());
                }
            }

        }
    }
}
