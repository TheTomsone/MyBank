using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.MyBank.Controllers
{
    public class Controller
    {
        private ConsoleKey _keyInput;

        public ConsoleKey KeyInput
        {
            get { return _keyInput; }
            set { _keyInput = value; }
        }
    }
}
