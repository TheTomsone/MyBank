using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public abstract class Account : ICustomer, IBanker
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

        public Account() { }
        public Account(string number, Users user)
        {
            Number = number;
            User = user;
        }
        public Account(string number, Users user, decimal sold) : this(number, user)
        {
            Sold = sold;
        }

        protected abstract decimal CalculatingInterest();
        public void ApplyInterest()
        {
            Sold += CalculatingInterest();
        }
        public virtual void Withdraw(decimal amount)
        {
            Withdraw(amount,0);
        }
        protected void Withdraw(decimal amount, decimal limit)
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
        public void SetSold(decimal value)
        {
            Sold = value;
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
