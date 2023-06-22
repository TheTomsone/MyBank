using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public class Bank
    {
        private Dictionary<string, Account> _accountsList;

        public string Name
        {
            get { return "MyBank"; }
        }
        public Dictionary<string, Account> AccountsList
        { 
            get
            {
                return _accountsList ??= new Dictionary<string, Account>();
            }
        }

        public Account this[string number]
        {
            get
            {
                AccountsList.TryGetValue(number, out Account current);
                return current;
            }
        }

        public void Add(Account current)
        {
            current.BelowZeroEvent += BelowZeroAction;
            AccountsList.Add(current.Number, current);
        }
        public void Delete(string number)
        {
            AccountsList.Remove(number);
        }
        public decimal TotalCurrents(Users user)
        {
            //decimal total = 0;
            //foreach (Account item in AccountsList.Values)
            //{
            //    if (item.User == user)
            //    {
            //        total += item;
            //    }
            //}
            //return total;
            return AccountsList.Values.Where(item => item.User == user).Sum(item => item.Sold);
        }
        public void BelowZeroAction(Account a)
        {
            Console.WriteLine($"Le compte {a.Number} vient de passer en négatif");
        }
    }
}
