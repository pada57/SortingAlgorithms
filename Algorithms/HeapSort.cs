using CommonStuff;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class HeapSort
    {
        /*
         * fonction triParTas(arbre, longueur) :
                pour i := longueur/2 à 1
                    tamiser(arbre, i, longueur)
                fin pour
                pour i := longueur à 2
                    échanger arbre[i] et arbre[1]
                    tamiser(arbre, 1, i-1)
                fin pour
            fin fonction
         * 
         * fonction tamiser(arbre, nœud, n) :
        (* descend arbre[nœud] à sa place, sans dépasser l'indice n *)
        k := nœud
        j := 2k
        tant que j ≤ n
            si j < n et arbre[j] < arbre[j+1]
                j := j+1
            fin si
            si arbre[k] < arbre[j]
                échanger arbre[k] et arbre[j]
                k := j
                j := 2k
            sinon
                j := n+1
            fin si
        fin tant que
    fin fonction
*/

        public static void Sort(int[] array)
        {
            int n = array.Length;
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(array, n, i);
            for (int i = n - 1; i >= 0; i--)
            {
                array.Swap(0, i);
                Heapify(array, i, 0);
            }
        }
        static void Heapify(int[] array, int n, int i)
        {
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;
            if (left < n && array[left] > array[largest])
                largest = left;
            if (right < n && array[right] > array[largest])
                largest = right;
            if (largest != i)
            {
                array.Swap(i, largest);
                Heapify(array, n, largest);
            }
        }
    }
}
