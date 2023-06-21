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
            private set { _lastWithdrawDate = value; }
        }

        public Saving() { }
        public Saving(string number, Users user) : base(number, user)
        {
            Number = number;
            User = user;
        }

        public Saving(string number, Users user, decimal sold) : base(number, user, sold)
        {
            Number = number;
            User = user;
            SetSold(sold);
        }

        protected override decimal CalculatingInterest()
        {
            return Sold * (decimal)0.45;
        }
        public override void Withdraw(decimal amount)
        {
            decimal oldSold = Sold;
            base.Withdraw(amount);
            if (oldSold > Sold)
            {
                LastWithdrawDate = DateTime.Now;
            }
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
