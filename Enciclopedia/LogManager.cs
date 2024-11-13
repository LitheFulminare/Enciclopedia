using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Enciclopedia
{
    internal class LogManager
    {
        private static TreeNode<string>? _mostAccessedMonster;
        private static TreeNode<string>? _mostAccessedCard;

        public static bool isDebugEnabled = false;

        public static TreeNode<string>? MostAccessedMonster => _mostAccessedMonster;
        public static TreeNode<string>? MostAccessedCard => _mostAccessedCard;

        /* 
        -> do AVA:
        - Um acesso sempre se inicia na página inicial (Home).
        - Um caracter numérico(0-9) significa que o usuário navegou para uma subcategoria da página atual, usando o caracter como índice.
        - Se o caracter é 'b', significa que o usuário voltou para a categoria anterior, pai da página em que está.
        */

        // lê o log, pega as paginas acessadas e registra esses acessos
        public static void RegisterLog(List<string> accessLog, TreeNode<string> homeNode)
        {
            // loop para cada linha na lista de log
            for (int i = 0; i < accessLog.Count; i++)
            {
                if (isDebugEnabled) Console.WriteLine($"\nRegistrando o log {accessLog[i]}");

                // o log sempre começa na home
                TreeNode<string> previousCategory = homeNode;
                TreeNode<string> currentPage = homeNode;

                // loop para cada caractere de um log em particular
                for (int j = 0; j < accessLog[i].Length; j++)
                {
                    if (isDebugEnabled) Console.WriteLine($"Lendo o char {accessLog[i][j]}");

                    // 'b' siginifica que ele voltou para a pagina anterior
                    if (accessLog[i][j] == 'b')
                    {
                        previousCategory = currentPage.Parent;
                        currentPage = previousCategory;
                        currentPage?.AddAccess();

                        if (isDebugEnabled) Console.WriteLine($"-> Usuário voltou para a pagina {currentPage.pageName}");

                        continue;
                    }

                    int childIndex = int.Parse(accessLog[i][j].ToString());

                    // childPage é a pagina que vai ser acessada
                    TreeNode<string> childPage = currentPage.GetChild(childIndex);

                    if (childPage == null)
                    {
                        if (isDebugEnabled) Console.WriteLine($"Tentativa de acessar a página de índice {childIndex} falhou");
                        continue;
                    }
                    
                    // checa de a página é uma categoria ou subcategoria
                    if (childPage.GetChild(0) != null)
                    {
                        if (childPage.Parent == homeNode)
                        {
                            previousCategory = homeNode;
                        }
                        else
                        {
                            previousCategory = currentPage;
                        }          
                    }

                    if (isDebugEnabled) Console.WriteLine($"-> Usuario accesou a pag {childPage.pageName}");

                    currentPage = childPage;
                    currentPage.AddAccess();
                }
            }
        }

        public static void SetMostAccessedPages(TreeNode<string> node)
        {
            if (node == null) return;

            if (node.pageType == PageType.Card)
            {
                SetMostAccessedCard(node);
                return;
            }

            if (node.pageType == PageType.Monster)
            {
                SetMostAccessedMonster(node);
            }
        }

        private static void SetMostAccessedCard(TreeNode<string> node)
        {
            if (_mostAccessedCard == null)
            {
                _mostAccessedCard = node;
                return;
            }

            if (node.Access > _mostAccessedCard.Access)
            {
                _mostAccessedCard = node;
            }
        }

        private static void SetMostAccessedMonster(TreeNode<string> node)
        {
            if (_mostAccessedMonster == null)
            {
                _mostAccessedMonster = node;
                return;
            }

            if (node.Access > _mostAccessedMonster.Access)
            {
                _mostAccessedMonster = node;
            }
        }
    }
}
