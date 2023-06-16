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
            //MainProgramLoop();
            Bank bank = new Bank();
            Users user = new Users();
            Account savingAccount = new Saving();
            savingAccount.User = user;
            Console.WriteLine(savingAccount);
            Console.WriteLine("================================================");
            savingAccount.Deposit(50);
            savingAccount.Withdraw(20);
            Console.WriteLine(savingAccount);
            Console.WriteLine("================================================");
            savingAccount.ApplyInterest();
            Console.WriteLine(savingAccount);


            Account currentAccount = new Current();
            currentAccount.User = user;
            Console.WriteLine(currentAccount);
            Console.WriteLine("================================================");
            currentAccount.Deposit(50);
            currentAccount.Withdraw(20);
            Console.WriteLine(currentAccount);
            Console.WriteLine("================================================");
            currentAccount.ApplyInterest();
            Console.WriteLine(currentAccount);
            Console.ReadKey();
        }

        private void MainProgramLoop()
        {
            bool isFinish = false;
            Bank bank = new Bank();
            Users user;
            Current current;
            while (!isFinish)
            {
                decimal number;
                Console.Clear();
                KeyInput = Console.ReadKey(true).Key;
                switch (KeyInput)
                {
                    case ConsoleKey.Insert:
                        user = new Users();
                        current = new Current();
                        current.User = user;
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
        private void CurrentLoop(Account account)
        {
            bool isFinish = false;
            Bank bank = new Bank();
            while (!isFinish)
            {
                decimal number;
                Console.Clear();
                Console.WriteLine(DisplayAccount(bank.AccountsList[account.Number].User, account));
                KeyInput = Console.ReadKey(true).Key;
                switch (KeyInput)
                {
                    case ConsoleKey.Enter:
                        number = ReadDecimal("Entrez le montant à déposer >> ");
                        account.Deposit(number);
                        break;
                    case ConsoleKey.Delete:
                        number = ReadDecimal("Entrez le montant à retirer >> ");
                        account.Withdraw(number);
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
        private static StringBuilder DisplayAccount(Users user, Account account)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(user);
            sb.AppendLine();
            sb.Append('=', 50);
            sb.AppendLine();
            sb.Append(account);
            sb.AppendLine();
            sb.Append('=', 50);
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine($"|ENTER|\t Dépôt\n|DELETE| Retrait\n|ESC|\t Quitter");
            return sb;
        }
    }
}
