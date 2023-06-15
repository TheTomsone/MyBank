using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank
{
    public class Bank
    {
        string _name;
        private Dictionary<string, Current> _currentsList;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Dictionary<string, Current> CurrentsList
        { 
            get
            {
                return _currentsList ??= new Dictionary<string, Current>();
            }
        }

        public Current this[string number]
        {
            get
            {
                CurrentsList.TryGetValue(number, out Current current);
                return current;
            }
        }

        public Bank(string name)
        {
            Name = name;
        }

        public void Add(Current current)
        {
            CurrentsList.Add(current.Number, current);
        }
        public void Delete(string number)
        {
            CurrentsList.Remove(number);
        }
        public decimal TotalCurrents(Users user)
        {
            decimal total = 0;
            foreach (Current item in CurrentsList.Values)
            {
                if (item.User == user)
                {
                    total = total + item.Sold;
                }
            }
            return total;
        }
    }
}
