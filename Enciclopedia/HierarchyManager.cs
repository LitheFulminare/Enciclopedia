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
        public static TreeNode<string> CreateHierarchyFromList(List<string?> list)
        {
            TreeNode<string> homeNode = new TreeNode<string>("Home");

            foreach (string? item in list)
            {
                if (item == null || !item.Contains('.')) break;
            }

            return homeNode;
        }
    }
}
