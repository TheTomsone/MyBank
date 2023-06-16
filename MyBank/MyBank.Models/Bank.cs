using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public class Bank
    {
        string _name;
        private Dictionary<string, Account> _accountsList;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
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

        public Bank(string name)
        {
            Name = name;
        }

        public void Add(Account current)
        {
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
    }
}
