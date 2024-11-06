using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enciclopedia
{
    internal class FileReader
    {
        public static List<string> CreateList(string filepath)
        {
            List<string> list = new List<string>();

            string[] lines = File.ReadAllLines(filepath);
            list.AddRange(lines);

            return list;
        }
    }
}
