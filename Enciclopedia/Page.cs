using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enciclopedia
{
    internal class Page
    {
        private string _name;
        private int _accessCount= 0;

        public int AccessCount => _accessCount;

        public Page(string name)
        {
            _name = name;
        }
    }
}
