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
