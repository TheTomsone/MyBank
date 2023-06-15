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
            set
            {
                if (value < 0)
                {
                    return;
                }
                _limit = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Limite négative : -{Limit} EUR";
        }
    }
}
