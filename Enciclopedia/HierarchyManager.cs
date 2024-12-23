﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enciclopedia
{
    internal class HierarchyManager
    {
        public static TreeNode<string> CreateHierarchyFromList(List<string> pageList)
        {
            if (pageList == null) return new TreeNode<string>("");

            TreeNode<string> homeNode = new TreeNode<string>("Home");

            // usado no foreach pra adicionar categorias e subcategorias
            // são removidos no final
            TreeNode<string> category = homeNode.AddChild("category");
            TreeNode<string> subcategory = category.AddChild("subcategory");

            // loop pra adicionar as paginas ao node 'Home'
            foreach (string? page in pageList)
            {
                if (page == null || !page.Contains('.')) continue;

                int dotCount = CountCharacters(page, '.');

                // vê quantos ponto tem para e decide se adiciona a Home, a última categoria criada, ou a última subcategoria criada
                switch (dotCount)
                {
                    case 1: category = homeNode.AddChild(page); break;
                    case 2: subcategory = category.AddChild(page); break;
                    case 3: 
                        TreeNode<string> newPage = subcategory.AddChild(page);

                        // .Parent.Parent acessa a categoria que é pai da subcagoria
                        if (newPage.Parent?.Parent?.pageName == ".Monsters")
                        {
                            newPage.pageType = PageType.Monster;
                        }
                        else if (newPage.Parent?.Parent?.pageName == ".Cards")
                        {
                            newPage.pageType = PageType.Card;
                        }
                        else
                        {
                            throw new Exception("Invalid category");
                        }

                        break;
                }
            }

            // remove os nodes temporários 'category' e 'subcategory'
            homeNode.RemoveChildByIndex(0);

            return homeNode;
        }

        private static int CountCharacters(string value, char character)
        {
            int count = 0;

            foreach (char c in value)
            {
                if (c == character) count++;
                else break;
            }

            return count;
        }
    }
}
