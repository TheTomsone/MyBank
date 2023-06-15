using MyBank.MyBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Controllers
{
    public class BankController : Controller
    {
        public BankController()
        {
            MainProgramLoop();
        }

        private void MainProgramLoop()
        {
            bool isFinish = false;
            Bank bank = new Bank("MyBank");
            Users user;
            Current current;
            while (!isFinish)
            {
                decimal number;
                Console.Clear();
                foreach (string currentNum in bank.CurrentsList.Keys)
                {
                    Console.WriteLine(DisplayUsersCurrents(currentNum));
                }
                KeyInput = Console.ReadKey(true).Key;
                switch (KeyInput)
                {
                    case ConsoleKey.Insert:
                        user = new Users();
                        current = new Current(user);
                        bank.Add(current);
                        break;
                    case ConsoleKey.Escape:
                        isFinish = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private void CurrentLoop(Current current)
        {
            bool isFinish = false;
            Bank bank = new Bank("MyBank");
            while (!isFinish)
            {
                decimal number;
                Console.Clear();
                Console.WriteLine(DisplayCurrent(bank.CurrentsList[current.Number].User, current));
                KeyInput = Console.ReadKey(true).Key;
                switch (KeyInput)
                {
                    case ConsoleKey.Enter:
                        number = ReadDecimal("Entrez le montant à déposer >> ");
                        current.Deposit(number);
                        break;
                    case ConsoleKey.Delete:
                        number = ReadDecimal("Entrez le montant à retirer >> ");
                        current.Withdraw(number);
                        break;
                    case ConsoleKey.Escape:
                        isFinish = true;
                        break;
                    default:
                        break;
                }
            }
        }
        private static decimal ReadDecimal(string msg = "Entrez un nombre decimal >> ")
        {
            decimal number;
            do
            {
                Console.Write(msg);
            } while (!decimal.TryParse(Console.ReadLine(), out number));
            return number;
        }
        private StringBuilder DisplayUsersCurrents(string number)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("- ");
            sb.Append(number);
            sb.AppendLine();
            return sb;
        }
        private static StringBuilder DisplayCurrent(Users user, Current current)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(user);
            sb.AppendLine();
            sb.Append('=', 50);
            sb.AppendLine();
            sb.Append(current);
            sb.AppendLine();
            sb.Append('=', 50);
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine($"|ENTER|\t Dépôt\n|DELETE| Retrait\n|ESC|\t Quitter");
            return sb;
        }
    }
}
