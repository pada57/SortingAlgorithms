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

        public static void Sort(int[] tree)
        {
            for (int i = tree.Length / 2; i > 0; i--)
            {
                Sieve(tree, i, tree.Length);
            }
            
        }

        private static void Sieve(int[] tree, int i, int length)
        {
            throw new NotImplementedException();
        }
    }
}
