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

        public static void ComputeData(List<string?> accessLog, TreeNode<string> pageTree)
        {
            if (accessLog == null) return;

            // loop para cada linha na lista de log
            for (int i = 0; i < accessLog.Count; i++)
            {
                // loop para cada caractere de um log em particular
                for (int j = 0; j < accessLog[i].Length; j++)
                {

                }
            }
        }
    }
}
