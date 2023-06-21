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
                    return;
                }
                _limit = value;
            }
        }

        public Current() { }
        public Current(string number, Users user) : base(number, user)
        {
            Number = number;
            User = user;
        }

        public Current(string number, Users user, decimal sold) : this(number, user)
        {
            SetSold(sold);
        }
        public Current(string number, decimal limit, Users user) : this(number, user)
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
            base.Withdraw(amount, Limit);
        }

        public override string ToString()
        {
            return base.ToString() + $"Limite négative : -{Limit} EUR";
        }
    }
}
