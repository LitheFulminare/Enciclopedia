using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enciclopedia
{
    internal class HierarchyManager
    {
        public static void CreateHierarchyFromList(List<string?> list)
        {
            foreach (string? item in list)
            {
                if (item == null) break;

                if (!item.Contains('.'))
                {
                    TreeNode<string> homeNode = new TreeNode<string>("Home");
                    Console.WriteLine("Found no dot");
                }
            }
        }
    }
}
