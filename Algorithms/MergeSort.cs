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

        public static void Sort(int[] input, int low, int high)
        {
            if (low < high)
            {
                int middle = (low / 2) + (high / 2);
                Sort(input, low, middle);
                Sort(input, middle + 1, high);
                Merge(input, low, middle, high);
            }
        }

        public static void Sort(int[] input)
        {
            Sort(input, 0, input.Length - 1);
        }

        private static void Merge(int[] input, int low, int middle, int high)
        {

            int left = low;
            int right = middle + 1;
            int[] tmp = new int[(high - low) + 1];
            int tmpIndex = 0;

            while ((left <= middle) && (right <= high))
            {
                if (input[left] < input[right])
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                }
                else
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                }
                tmpIndex = tmpIndex + 1;
            }

            if (left <= middle)
            {
                while (left <= middle)
                {
                    tmp[tmpIndex] = input[left];
                    left = left + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            if (right <= high)
            {
                while (right <= high)
                {
                    tmp[tmpIndex] = input[right];
                    right = right + 1;
                    tmpIndex = tmpIndex + 1;
                }
            }

            for (int i = 0; i < tmp.Length; i++)
            {
                input[low + i] = tmp[i];
            }

        }

    }
}
