using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace SimuladorTransacional
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<Transacao> transacoes = new Queue<Transacao>();
            List<Tuple<string, char, char>> uso = new List<Tuple<string, char, char>>();

            using (StreamReader f = new StreamReader("Transacoes.txt"))
            {
                while (!f.EndOfStream)
                    transacoes.Enqueue(new Transacao(f.ReadLine()));
            }

            while(transacoes.Count != 0)
            {
                Transacao t = transacoes.Dequeue();
                Tuple <char, char> a = t.transacoes.Peek();
                
                if (uso.Any(n => n.Item2 == 'w' && n.Item3 == a.Item2) || (uso.Any(n => n.Item2 == 'r' && n.Item3 == a.Item2) && a.Item1 == 'w'))
                    transacoes.Enqueue(t);
                else
                {                    
                    uso.Add(new Tuple<string, char, char>(t.nome, a.Item1, a.Item2));
                    Console.WriteLine(t.nome + ": " + a.Item1 + " " + a.Item2);
                    t.transacoes.Dequeue();

                    if (t.transacoes.Count > 0)
                        transacoes.Enqueue(t);

                    if (t.transacoes.Count == 0)
                    {
                        Console.WriteLine(t.nome + ": " + "commit");
                        uso.RemoveAll(n => n.Item1 == t.nome);
                    }

                }                
            }

            Console.ReadKey();
        }
    }
}
