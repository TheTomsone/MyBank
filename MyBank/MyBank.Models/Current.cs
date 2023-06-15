using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public class Current : Account
    {

        public Current(Users user)
        {
            Limit = 1000;
            User = user;
        }

        public override string ToString()
        {
            return base.ToString() + $"Limite négative : -{Limit} EUR";
        }
    }
}
