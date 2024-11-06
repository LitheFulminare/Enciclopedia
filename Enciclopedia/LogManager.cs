using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enciclopedia
{
    internal class LogManager
    {
        private static string? _mostAccessedMonster;
        private static string? _mostAccessedCard;

        public string? MostAccessedMonster => _mostAccessedMonster;
        public string? MostAccessedCard => _mostAccessedCard;

        /* 
        -> do AVA:
        - Um acesso sempre se inicia na página inicial (Home).
        - Um caracter numérico(0-9) significa que o usuário navegou para uma subcategoria da página atual, usando o caracter como índice.
        - Se o caracter é 'b', significa que o usuário voltou para a categoria anterior, pai da página em que está.
        */

        public static void ComputeData(List<string> accessLog, TreeNode<string> pageTree)
        {
            //if (accessLog == null) return;

            // loop para cada linha na lista de log
            for (int i = 0; i < accessLog.Count; i++)
            {
                Console.WriteLine($"Checando o log {accessLog[i]}");

                // o log sempre começa na home
                TreeNode<string> previousCategory = pageTree;
                TreeNode<string> currentCategory = pageTree;

                // loop para cada caractere de um log em particular
                for (int j = 0; j < accessLog[i].Length; j++)
                {
                    Console.WriteLine($"Checando o char {accessLog[i][j]}");

                    // 'b' siginifica que ele voltou para a pagina anterior
                    if (accessLog[i][j] == 'b')
                    {
                        Console.WriteLine("Usuário voltou para a anterior");
                        currentCategory = previousCategory;
                        continue;
                    }

                    TreeNode<string> childPage = currentCategory.GetChild(accessLog[i][j]);
                    //Console.WriteLine($"Pagina é nula");
                    if (childPage != null)
                    {
                        Console.WriteLine($"Usuario accesou a pag {childPage}");

                        currentCategory = childPage;
                        currentCategory.AddAccess();
                        continue;
                    }

                    Console.WriteLine("Tentativa de acessar uma página invalida");
                }
            }
        }
    }
}
