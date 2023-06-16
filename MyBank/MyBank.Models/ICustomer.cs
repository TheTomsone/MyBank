using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public interface ICustomer
    {
        public decimal Sold { get; }

        public void Withdraw(decimal amount);

        public void Deposit(decimal amount);
    }
}
