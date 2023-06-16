using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public interface IBanker : ICustomer
    {
        string Number { get; }
        Users User { get; }
        void ApplyInterest();
    }
}
