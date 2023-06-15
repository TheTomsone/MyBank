using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank
{
    public class Current
    {
        private string _number;
        private decimal _sold;
        private decimal _limit;
        private Users _user;

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }
        public decimal Sold
        {
            get { return _sold; }
            private set { _sold = value; }
        }
        public decimal Limit
        {
            get { return _limit; }
            set 
            { 
                if (value < 0)
                {
                    return;
                }
                _limit = value;
            }
        }
        public Users User
        {
            get { return _user; }
            set { _user = value; }
        }

        public Current(Users user)
        {
            Random r = new Random();
            int number = r.Next(10,99);
            Number = $"BE{number} 0018 6831 5077";
            Sold = 0;
            Limit = 1000;
            //User = new Users(ReadString("Entrez votre nom >> "), ReadString("Entrez votre prénom >> "));
            User = user;
        }

        public void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.Write("Impossible d'entrer un montant négatif...");
                Console.ReadKey();
                return;
            }
            if (Sold - amount < -Limit )
            {
                Console.Write("Vous êtes fauché ! Appuyez sur une touche...");
                Console.ReadKey();
                return;
            }
            Sold -= amount;
        }
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.Write("Impossible d'entrer un montant négatif...");
                Console.ReadKey();
                return;
            }
            Sold += amount;
        }
        public override string ToString()
        {
            return $"Numéro de compte : {Number}\n----------\n" +
                   $"Limite négative : -{Limit} EUR\n----------\n" +
                   $"Solde : {Sold} EUR";
        }
        public static decimal operator +(decimal value, Current current2)
        {
            return value + current2.Sold;
        }
    }
}
