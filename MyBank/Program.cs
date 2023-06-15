using System.Text;

namespace MyBank
{
    public class Program
    {
        private static ConsoleKey key;
        private static void Main(string[] args)
        {
            //Bank bank = new Bank("MyBank");
            //Current newCurrent = new Current();
            //bank.Add(newCurrent);
            //Console.WriteLine(bank.CurrentsList["BE80 0018 6831 5077"]);
            //MyBank(newUser);
            MyBank();


        }

        private static void MyBank()
        {
            bool isFinish = false;
            Bank bank = new Bank("MyBank");
            Users user = new Users();
            Current current1 = new Current(user);
            bank.Add(current1);
            current1.Deposit(1000);
            Console.WriteLine(current1);
            Current current2 = new Current(user);
            bank.Add(current2);
            current2.Deposit(1500);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine(current2);
            bank.TotalCurrents(user);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine(current1);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine(current2);
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine(bank.TotalCurrents(user));


            while (!isFinish)
            {
                decimal number;
                Console.Clear();
                Console.WriteLine(DisplayCurrent(bank.CurrentsList[current.Number].User, current));
                key = Console.ReadKey(true).Key;
                switch (key)
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