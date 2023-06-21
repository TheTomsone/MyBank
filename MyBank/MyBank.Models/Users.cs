using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Models
{
    public class Users
    {
        private string _name;
        private string _firstname;
        private DateTime _birth;

        public string Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        public string Firstname
        {
            get { return _firstname; }
            private set { _firstname = value; }
        }
        public DateTime Birth
        {
            get { return _birth; }
            private set { _birth = value; }
        }

        public Users()
        {
            Name = ReadString("Entrez votre nom >> ");
            Firstname = ReadString("Entrez votre prénom >> ");
            Birth = ReadDateTime(ReadInt("JOUR >> "), ReadInt("MOIS >> "), ReadInt("ANNÉE >> "));
        }

        public static bool operator ==(Users user1, Users user2)
        {
            return user1.Name == user2.Name && user1.Firstname == user2.Firstname && user1.Birth == user2.Birth;
        }
        public static bool operator !=(Users user1, Users user2)
        {
            return !(user1 == user2);
        }
        public override string ToString()
        {
            return $"Prénom : {Firstname}\t\t{Birth}\nNom    : {Name}";
        }
        public DateTime ReadDateTime(int day, int month, int year, int hour = 0, int minute = 0, int second = 0)
        {
            DateTime date = new(year, month, day, hour, minute, second);
            return date;
        }
        private int ReadInt(string msg = "Entrez un nombre >> ")
        {
            int number;
            do
            {
                Console.Write(msg);
            } while (!int.TryParse(Console.ReadLine(), out number));
            return number;
        }
        private string ReadString(string msg = "Entrez un texte >> ")
        {
            string text;
            do
            {
                Console.Write(msg);
                text = Console.ReadLine();
            } while (text.Trim() is null);
            return text;
        }
    }
}
