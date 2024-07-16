using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj
{
    public static class Accounts
    {
        const string VipUsername = "Vip";
        const string VipPassword = "Vip123";

        const string NonVipUsername = "NonVip";
        const string NonVipPassword = "NonVip123";
        const int MaxLoginAttempts = 3;

        static bool LogInAcc = false;
        static string username;
        static string password;

        public static void Login()
        {

            int attempts = 0;

            while (!LogInAcc && attempts < MaxLoginAttempts)
            {
                attempts++;

                //Login
                Console.Write("Enter Username: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                username = Console.ReadLine();
                Console.ResetColor();

                Console.Write("Enter Password: ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                password = Console.ReadLine();
                Console.ResetColor();
                Console.Clear();

                if (username == VipUsername && password == VipPassword)
                {
                    LogInAcc = true;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Welcome, VIP user! ");
                    Console.ResetColor();
                    Menu.MenuOptions(username);
                }
                
                else if (username == NonVipUsername && password == NonVipPassword)
                {
                    LogInAcc = true;
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Welcome, Non-VIP user! Have fun!");
                    Console.ResetColor();
                    Menu.MenuOptions(username);
                }

                else
                {
                    Console.WriteLine($"Invalid username or password. Attempts remaining: {MaxLoginAttempts - attempts}");
                }
            }
            if (!LogInAcc)
            {
                Console.WriteLine("Maximum login attempts reached. Access denied.");
            }
        }
    }
}