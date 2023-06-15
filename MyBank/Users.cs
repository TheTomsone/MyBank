﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank
{
    public class Users
    {
        private string _name;
        private string _firstname;
        private DateTime _birth;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }
        public DateTime Birth
        {
            get { return _birth; }
            set { _birth = value; }
        }

        public Users()
        {
            Name = ReadString("Entrez votre nom >> ");
            Firstname = ReadString("Entrez votre prénom >> ");
            Birth = ReadDateTime(ReadInt("JOUR >> "), ReadInt("MOIS >> "), ReadInt("ANNÉE >> "));
        }

        public DateTime ReadDateTime(int day, int month, int year, int hour = 0, int minute = 0, int second = 0)
        {
            DateTime date = new(year, month, day, hour, minute, second);
            return date;
        }

        public override string ToString()
        {
            return $"Prénom : {Firstname}\t\t{Birth}\nNom    : {Name}";
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
