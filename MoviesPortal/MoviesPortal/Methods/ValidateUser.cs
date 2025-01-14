﻿using MoviesPortal.Data;
using MoviesPortal.DataLayer.Models;
using System.Security;
using System.Threading;
namespace MoviesPortal.Methods
{
    public class ValidateUser
    {
        public static string ValidateUserLogin(List<User> Users)
        {
            bool isMatch;
            string input;
            string password = "";
            do
            {
                isMatch = false;
                Console.WriteLine(">>> Input your login:");
                input = Console.ReadLine();
                

                if (CheckInputValue.CheckInputLogin(input))
                {
                    foreach (var item in Users)
                    {
                        if (input == item.Name)
                        {
                            password = item.Password;
                            LoggedUser.UserName = input;
                            isMatch = true;
                            break;
                        }
                    }
                    
                    if (isMatch != true)
                    {
                        Console.WriteLine("[!] Inputted login no matches with that in database. Try again.");
                    }
                    
                }

            } while (!isMatch);

            return password;
        }

        public void ValidateUserPassword(string password)
        {
            bool isMatch;
            string input;
            do
            {
                isMatch = false;
                Console.WriteLine(">>> Input your password:");
                var inputPassword = MaskInputString();                
                input = new System.Net.NetworkCredential(string.Empty, inputPassword).Password;

                if (CheckInputValue.CheckInputPassword(input))
                    {
                        if (password == input)//
                        {
                            Console.Clear();
                            Console.WriteLine($"[+] Inputted password matches with that in database.");
                            isMatch = true;
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine($"[!] Inputted password no matches with that in database. Try again.");
                            isMatch = false;

                        }

                    }
                

            } while (!isMatch);

        }

        public static string CreateUserLogin(List<User> Users)
        {
            bool isMatch;
            string input;

            do
            {
                isMatch = false;
                Console.WriteLine(">>> Create your new login!\n(if you type 'help' you will see the rules with should contains your login).");
                input = Console.ReadLine();

                if (input == "help")
                {
                    Console.WriteLine("Your new login should:\n+ min 5 letters,\n+ lenght min 7, max 15 symbols,\n+ can contains stings and integers,\n- no spaces," +
                        "\n- no special symbols,\n- no only integers.\nPress any button to back to login creator");
                    Console.ReadKey();
                    LoggedUser.WhoIsLogged();
                    isMatch = true;

                }
                else if (CheckInputValue.CheckInputLogin(input))
                {
                    // Verification that input login matches with any login in database
                    foreach (var item in Users)
                    {
                        if (input == item.Name)
                        {
                            Console.WriteLine($"[!] Inputted login matches with that in database. Try Again.");
                            isMatch = true;
                            break;
                        }
                    }

                    if (isMatch == false)
                    {
                        //Console.WriteLine($"[+] Inputted login no matches with that in database. Now create your password.");
                        isMatch = false;
                    }
                }
                else
                {
                    isMatch = true;
                }

            } while (isMatch);

            return input;

        }

        public static string CreateUserPassword()
        {

            bool isMatch = false;
            string input;
            string password = "";

            do
            {
                Console.WriteLine(">>> Create your password!\n(if you type 'help' you will see the rules with should contains your login).");
                var inputPassword = MaskInputString();
                input = new System.Net.NetworkCredential(string.Empty, inputPassword).Password;

                if (input == "help")
                {
                    Console.WriteLine("Your password should:\n+ min 4 letters,\n+ lenght min 8, max 20 symbols,\n+ min 2 digits,\n+ min 1 special symbol\n+ min 1 upper and lower letter,\n- no spaces," +
                       "\n- no only integers.\nPress any button to back to password creator");
                    Console.ReadKey();
                    LoggedUser.WhoIsLogged();
                    isMatch = true;
                }
                else if (CheckInputValue.CheckInputPassword(input) == true)
                {

                    Console.WriteLine($"[+] Inputted password meets all requirements.");
                    password = input;
                    isMatch = false;

                }
                else
                {
                    isMatch = true;
                }

            } while (isMatch);

            return password;
        }

        public static SecureString MaskInputString()
        {
            SecureString pass = new SecureString();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    pass.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (pass.Length > 0)
                    {
                        pass.RemoveAt(pass.Length - 1);
                        Console.Write("\b \b");
                    }                    
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            { 
                return pass;
            }
        }
    }
}
