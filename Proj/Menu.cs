using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj
{

    public static class Menu
    {
        static string VipUsername = "Vip";
        static string NonVipUsername = "NonVip";
        static double balance = 0;
        static double earnings = 0;
        static double totalEarnings = 0;

        static List<string> Options = new List<string>();

        private static void mainOptions()
        {
            Options.Add("1.Balance");
            Options.Add("2.Load Time");
            Options.Add("3.Earn History");
            Options.Add("4.Logout");
        }

        public static void MenuOptions(string username)
        {

            while (true)
            {
                if (Options.Contains("1.Balance") && Options.Contains("2.Load Time") && Options.Contains("3.Earn History") && Options.Contains("4.Logout"))
                {

                }
                else { mainOptions(); }

                Console.ForegroundColor = ConsoleColor.Green;

                for (int x = 0; x < Options.Count; x++)
                {
                    Console.WriteLine($"{Options[x]}");
                }
                Console.ResetColor();

                int.TryParse(Console.ReadLine(), out int choice);

                int loopexiter = 0;

                switch (choice)
                {
                    
                    case 1:
                        Console.Clear();
                        Balance();
                        break;

                    case 2:
                        Console.Clear();
                        LoadTime(username);
                        break;

                    case 3:
                        ShowEarnings();
                        continue;

                    case 4:
                        loopexiter = 1;
                        Console.Clear();
                        Console.WriteLine("Successfully logged out. Thank you for choosing JESCOMPSHOP!");
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                if (loopexiter != 0) 
                {
                    break;
                }
            }
        }

        public static void Balance()
        {
            Console.WriteLine($"Your balance is {balance} ");
            Console.WriteLine("Do you want to load balance? Y/N?");
            string choice = Console.ReadLine().ToUpper();
            
            switch (choice)
            {
                case "Y":
                    Console.WriteLine("Enter balance you want to add: ");

                    int.TryParse(Console.ReadLine(), out int add);

                    balance += add;
                    totalEarnings += add;
                    break;
                case "N":
                    Console.WriteLine($"BALANCE: {balance}");
                    break;
                default:
                    break;
            }
            Console.Clear();
        }

        public static void LoadTime(string username)
        {
            while (true)
            {
                Console.Write("Enter time to load (in hours): ");

                if (double.TryParse(Console.ReadLine(), out double hours) && hours >= 0)
                {
                    if (hours > 0)
                    {
                        double costPerHour;

                        if (username == VipUsername)
                        {
                            costPerHour = 30;
                        }
                        else if (username == NonVipUsername)
                        {
                            costPerHour = 20;
                        }
                        else
                        {
                            Console.WriteLine("Invalid username.");
                            break;
                        }

                        //computation
                        double cost = hours * costPerHour;

                        if (cost > balance)
                        {
                            Console.WriteLine("Insufficient balance. Please load a higher amount.");
                        }
                        else
                        {
                            earnings += balance;
                            balance -= cost;
                            Console.WriteLine($"Successfully loaded {hours} hours for {cost} PHP. Your new balance is: {balance}");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid time. Please enter a positive value.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    // Continues the loop till the system receives a valid input
                }
            }
        }
        public static void ShowEarnings()
        {
            Console.Clear();
            Console.WriteLine($"Your total earnigs are: {totalEarnings} pesos");
        }
        public static int Logout(int loopexiter)
        {
            loopexiter = 1;
            Console.Clear();
            Console.WriteLine("Successfully logged out. Thank you for choosing JESCOMPSHOP!");
            return loopexiter;
        }
    }
}