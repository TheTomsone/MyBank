using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public class Saving : Account
    {
        private DateTime _lastWithdrawDate;

        public DateTime LastWithdrawDate
        {
            get { return _lastWithdrawDate; }
            set { _lastWithdrawDate = value; }
        }

        public Saving(Users user)
        {
            Limit = 0;
            User = user;
        }
        public override void Withdraw(decimal amount)
        {
            if (amount < 0)
            {
                Console.Write("Impossible d'entrer un montant négatif...");
                Console.ReadKey();
                return;
            }
            if (Sold - amount < 0)
            {
                Console.Write("Vous êtes fauché ! Appuyez sur une touche...");
                Console.ReadKey();
                return;
            }
            LastWithdrawDate = DateTime.Now;
            base.Withdraw(amount);
        }
        public override void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                Console.Write("Impossible d'entrer un montant négatif...");
                Console.ReadKey();
                return;
            }
            base.Deposit(amount);
        }

        public override string ToString()
        {
            string text = "Compte Épargne : \n\n" + base.ToString();
            if (LastWithdrawDate == DateTime.MinValue)
            {
                return text + "Dernier retrait : Auncun retrait enregistré";
            }
            return text + $"Dernier retrait : {LastWithdrawDate}";
        }


    }
}
