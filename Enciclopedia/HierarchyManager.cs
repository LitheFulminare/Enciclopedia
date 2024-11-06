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
        public static TreeNode<string> CreateHierarchyFromList(List<string?> pageList)
        {
            TreeNode<string> homeNode = new TreeNode<string>("Home");

            // usado no foreach pra adicionar categorias e subcategorias

            TreeNode<string> category = homeNode.AddChild("default");
            TreeNode<string> subcategory = category.AddChild("default");

            foreach (string? page in pageList)
            {
                if (page == null || !page.Contains('.')) continue;

                int dotCount = CountCharacters(page, '.');

                if (dotCount == 1) category = homeNode.AddChild(page); 
                if (dotCount == 2) subcategory = category.AddChild(page);
                if (dotCount == 3) subcategory.AddChild(page);

                // logica aqui
            }

            return homeNode;
        }

        private static int CountCharacters(string value, char character)
        {
            int count = 0;

            foreach (char c in value)
            {
                if (c == character) count++;
            }

            return count;
        }
    }
}
