using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    internal class Program
    {
        class Kniga : IComparable, ICloneable
        {
            public string Tit { get; set; }
            public string Avtor { get; set; }
            public Kniga(string tit, string avtor)
            {
                Tit = tit;
                Avtor = avtor;
            }
            public Kniga() : this("", "") { }
            public void Print()
            {
                Console.WriteLine($" Имя {Tit}\n Автор {Avtor} \n");
            }
            public int CompareTo(object objekt)
            {
                if (objekt is Kniga)
                    return Tit.CompareTo((objekt as Kniga).Tit);
                throw new NotImplementedException();
            }
            public class SortByTitle : IComparer
            {
                int IComparer.Compare(object objekt1, object objekt2)
                {
                    if (objekt1 is Kniga && objekt2 is Kniga)
                        return (objekt1 as Kniga).Tit.CompareTo((objekt2 as Kniga).Tit);

                    throw new NotImplementedException();
                }
            }
            public class SortByAuthor : IComparer
            {
                int IComparer.Compare(object objekt1, object objekt2)
                {
                    if (objekt1 is Kniga && objekt2 is Kniga)
                        return (objekt1 as Kniga).Avtor.CompareTo((objekt2 as Kniga).Avtor);

                    throw new NotImplementedException();
                }
            }
            public object Clone()
            {
                return new Kniga(Tit, Avtor);
            }
        }

        class Library : IEnumerable
        {
            public Kniga[] list;
            public Library(int dlina)
            {
                list = new Kniga[dlina];
                for (int i = 0; i < dlina; i++)
                    list[i] = new Kniga();
            }
            public Library() : this(1) { }
            public Library(Kniga[] kniga)
            {
                list = new Kniga[kniga.Length];
                for (int i = 0; i < kniga.Length; i++)
                    list[i] = new Kniga(kniga[i].Tit, kniga[i].Avtor);
            }
            public void Print()
            {
                for (int i = 0; i < list.Length; i++)
                    list[i].Print();
            }
            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < list.Length; i++)
                    yield return list[i];
            }
        }

        static void Main(string[] args)
        {
            Kniga[] arr = new Kniga[3];
            arr[0] = new Kniga("Шерлок Холмс", "Иван Литовский");
            arr[1] = new Kniga("Cyperpunk бегущий по краю", "Estevich Stushenko");
            arr[2] = new Kniga("Буратино", "Олексія Миколайовича Толстого");
            Library l = new Library(arr);
            Array.Sort(arr, new Kniga.SortByTitle());
            foreach (Kniga temp in l)
                temp.Print();
        }
    }
}
