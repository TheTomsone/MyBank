using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public class Account
    {
        private string _number;
        private decimal _sold;
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
        public Users User
        {
            get { return _user; }
            set { _user = value; }
        }
        public virtual void Withdraw(decimal amount)
        {
            Withdraw(amount,0);
        }
        public void Withdraw(decimal amount, decimal limit)
        {
            if (amount < 0)
            {
                return;
            }
            if (Sold - amount < -limit)
            {
                return;
            }
            Sold -= amount;
        }
        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                return;
            }
            Sold += amount;
        }
        public override string ToString()
        {
            return $"Numéro de compte : {Number}\n----------\n" +
                   $"Solde : {Sold} EUR\n----------\n";
        }
        public static decimal operator +(decimal value, Account account)
        {
            return value + (account.Sold > 0 ? account.Sold : 0);
        }
    }
}
