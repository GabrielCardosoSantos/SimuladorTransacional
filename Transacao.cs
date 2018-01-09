using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorTransacional
{
    public class Transacao
    {
        public string nome { get; set; }
        public Queue<Tuple<char, char>> transacoes { get; set; }

        public Transacao(String s)
        {
            nome = s.Substring(0, 2);
            s = s.Replace(" ", "");
            s = s.Replace("(", "");
            s = s.Replace(")", "");
            s = s.Remove(0, 3);
            transacoes = new Queue<Tuple<char, char>>();
            String[] m = s.Split(',');

            foreach(String aux in m)
            {
                Tuple<char, char> t = new Tuple<char, char>(aux[0], aux[1]);
                transacoes.Enqueue(t);
            }
        }        
    }
}
