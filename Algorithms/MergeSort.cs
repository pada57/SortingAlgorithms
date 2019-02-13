using CommonStuff;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class MergeSort
    {
        /*entrée ː un tableau T
        sortie ː une permutation triée de T
        fonction triFusion(T[1, …, n])
                si n ≤ 1
                        renvoyer T
                sinon
                        renvoyer fusion(triFusion(T[1, …, n/2]), triFusion(T[n/2 + 1, …, n]))
        entrée ː deux tableaux triés A et B
        sortie : un tableau trié qui contient exactement les éléments des tableaux A et B
        fonction fusion(A[1, …, a], B[1, …, b])
                si A est le tableau vide
                        renvoyer B
                si B est le tableau vide
                        renvoyer A
                si A[1] ≤ B[1]
                        renvoyer A[1] :: fusion(A[2, …, a], B)
                sinon
                        renvoyer B[1] :: fusion(A, B[2, …, b])
              */

        public static List<int> Sort(List<int> list)
        {
            if (list.Count < 2)
            {
                return list;
            }

            return Merge(Sort(list.GetRange(0, list.Count - list.Count / 2)), Sort(list.GetRange(list.Count / 2, list.Count - list.Count / 2)));
        }

        private static List<int> Merge(List<int> list1, List<int> list2)
        {

            if (list1.Count == 0)
            {
                return list2;
            }
            if (list2.Count == 0)
            {
                return list1;
            }
            List<int> result = new List<int>();
            if (list1[0] > list2[0])
            {
                result.Add(list2[0]);
                result.AddRange(Merge(list1, list2.GetRange(1, list2.Count - 1)));
                return result;
            }

            result.Add(list1[0]);
            result.AddRange(Merge(list1.GetRange(1, list1.Count - 1), list2));

            return result;
        }
    }
}
