using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public class Saving
    {
        private DateTime _lastWithdrawDate;

        public DateTime LastWithdrawDate
        {
            get { return _lastWithdrawDate; }
            set { _lastWithdrawDate = value; }
        }

        public Saving()
        {
            _lastWithdrawDate = DateTime.Now;
        }
    }
}
