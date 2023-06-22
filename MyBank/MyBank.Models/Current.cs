using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public class Current : Account
    {

        private decimal _limit;
        public decimal Limit
        {
            get { return _limit; }
            private set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Le montant de la ligne de crédit est inférieur à zéro !");
                }
                _limit = value;
            }
        }

        public Current(string number, Users user) : base(number, user) { }

        public Current(string number, Users user, decimal sold) : base(number, user, sold) { }
        public Current(string number, decimal limit, Users user) : base(number, user)
        {
            Limit = limit;
        }

        protected override decimal CalculatingInterest()
        {
            //if (Sold < 0)
            //{
            //    return Sold * (decimal)0.03;
            //}
            //return Sold * (decimal)0.0975;
            return Sold * (Sold >= 0 ? 0.03M : .0975M);
        }
        public override void Withdraw(decimal amount)
        {
            if (Sold >= 0 && Sold - amount < 0)
            {
                RaiseBelowZeroEvent(this);
            }
            base.Withdraw(amount, Limit);
        }

        public override string ToString()
        {
            return base.ToString() + $"Limite négative : -{Limit} EUR";
        }
    }
}
