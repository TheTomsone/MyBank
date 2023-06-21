using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public class SoldException : Exception
    {
        public SoldException() : base("Votre solde est insufisant !") { }
        public SoldException(string? message) : base(message) { }
    }
}
