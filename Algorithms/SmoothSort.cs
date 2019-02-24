using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class SmoothSort
    {
        #region spécialisation
        public class Trie_elem_indicéf : Trie<elem_indicéf, indicef_comparer>
        {
            public static void smoothSort(elem_indicéf[] data)
            {
                smoothSort(data, new indicef_comparer());
            }
        }
        public class Trie_elem_indicé : Trie<elem_indicé, indice_comparer>
        {
            public static void smoothSort(elem_indicé[] data)
            {
                smoothSort(data, new indice_comparer());
            }
        }
        #endregion

        public class Trie<T, TC> where TC : IComparer<T>
        {
            /* An algorithm developed by Edsger Dijkstra based on the same principle as
     * heapsort.  By using a postorder traversal of a heap-like structure, O(n)
     * time complexity is achieved for already-sorted data.
     * Time complexity:
     * O(n log n) worst case
     * O(n) best case
     * Working memory:
     * O(1) all cases
     */
            private static void up(ref int b, ref int c)
            {
                int temp = b + c + 1;
                c = b;
                b = temp;
            }
            private static void down(ref int b, ref int c)
            {
                int temp = b - c - 1;
                b = c;
                c = temp;
            }
            private static void sift(int r, int b, int c, T[] data, TC Comp)
            {
                while (b >= 3)
                {
                    int r2 = r - b + c;

                    if (Comp.Compare(data[r2], data[r - 1]) < 0)//data[r2] < data[r - 1])
                    {
                        r2 = r - 1;
                        down(ref b, ref c);
                    }

                    if (Comp.Compare(data[r], data[r2]) >= 0)//data[r] >= data[r2])
                    {
                        b = 1;
                    }
                    else
                    {
                        swap(ref data[r], ref data[r2]);
                        r = r2;
                        down(ref b, ref c);
                    }
                }
            }
            private static void trinkle(int r, int p, int b, int c, T[] data, TC Comp)
            {
                while (p > 0)
                {
                    int r3;

                    while (p % 2 == 0)
                    {
                        p /= 2;
                        up(ref b, ref c);
                    }
                    r3 = r - b;

                    if (p == 1 || Comp.Compare(data[r3], data[r]) <= 0)//data[r3] <= data[r])
                    {
                        p = 0;
                    }
                    else
                    {
                        p--;
                        if (b == 1)
                        {
                            swap(ref data[r], ref data[r3]);
                            r = r3;
                        }
                        else if (b >= 3)
                        {
                            int r2 = r - b + c;
                            if (Comp.Compare(data[r2], data[r - 1]) < 0)//data[r2] < data[r - 1])
                            {
                                r2 = r - 1;
                                down(ref b, ref c);
                                p *= 2;
                            }

                            if (Comp.Compare(data[r3], data[r2]) >= 0)//data[r3] >= data[r2])
                            {
                                swap(ref data[r], ref data[r3]);
                                r = r3;
                            }
                            else
                            {
                                swap(ref data[r], ref data[r2]);
                                r = r2;
                                down(ref b, ref c);
                                p = 0;
                            }
                        }
                    }
                }
                sift(r, b, c, data, Comp);
            }

            private static void semitrinkle(int r, int p, int b, int c, T[] data, TC Comp)
            {
                int r1 = r - c;
                if (Comp.Compare(data[r1], data[r]) > 0)//data[r1] > data[r])
                {
                    swap(ref data[r], ref data[r1]);
                    trinkle(r1, p, b, c, data, Comp);
                }
            }

            private static void swap(ref T x, ref T y)
            {
                T temp = x;
                x = y;
                y = temp;
            }

            public static void smoothSort(T[] data, TC Comp)
            {
                if (data.Length <= 1)
                    return;
                int q = 1, r = 0, p = 1, b = 1, c = 1;

                while (q != data.Length)
                {
                    if (p % 8 == 3)
                    {
                        sift(r, b, c, data, Comp);
                        p = (p + 1) / 4;
                        up(ref b, ref c); up(ref b, ref c);
                    }
                    else if (p % 4 == 1)
                    {
                        if (q + c < data.Length)
                        {
                            sift(r, b, c, data, Comp);
                        }
                        else
                        {
                            trinkle(r, p, b, c, data, Comp);
                        }
                        do
                        {
                            down(ref b, ref c);
                            p *= 2;
                        } while (b != 1);
                        p++;
                    }
                    q++; r++;
                }
                trinkle(r, p, b, c, data, Comp);

                while (q != 1)
                {
                    q--;
                    if (b == 1)
                    {
                        r--; p--;
                        while (p % 2 == 0)
                        {
                            p /= 2;
                            up(ref b, ref c);
                        }
                    }
                    else if (b >= 3)
                    {
                        p--;
                        r += c - b;
                        if (p != 0) semitrinkle(r, p, b, c, data, Comp);
                        down(ref b, ref c);
                        p = 2 * p + 1;
                        r += c;
                        semitrinkle(r, p, b, c, data, Comp);
                        down(ref b, ref c);
                        p = 2 * p + 1;
                    }
                }
            }

        }


        #region comparaisons
        public struct elem_indicéf
        {
            public float indice;
            public object elem;
            public int indiceOrig;//n'est pas rempli par le code, optionnel si besoin est.
        }

        public class indicef_comparer : IComparer<elem_indicéf>
        {
            #region IComparer<elem_indicéf> Membres

            int IComparer<elem_indicéf>.Compare(elem_indicéf x, elem_indicéf y)
            {
                if (x.indice < y.indice)
                    return -1;
                else if (x.indice > y.indice)
                    return 1;
                else
                    return 0;
                //return x.indice - y.indice;
            }

            #endregion
        }

        public struct elem_indicé
        {
            public int indice;
            public object elem;
            public int indiceOrig;//n'est pas rempli par le code, optionnel si besoin est
        }

        public class indice_comparer : IComparer<elem_indicé>
        {
            #region IComparer<elem_indicé> Membres

            int IComparer<elem_indicé>.Compare(elem_indicé x, elem_indicé y)
            {
                return x.indice - y.indice;
            }

            #endregion
        }

        public class int_comparer : IComparer<int>
        {
            #region IComparer<int> Membres //public car dans l'interface...

            int IComparer<int>.Compare(int x, int y)
            {
                return x - y;
            }

            #endregion
        }
        #endregion

        
    }
}
