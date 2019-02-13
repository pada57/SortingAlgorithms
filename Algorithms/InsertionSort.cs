using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    public static class InsertionSort
    {
        /*
         * procédure tri_insertion(tableau T, entier n)
      pour i de 1 à n - 1
          # mémoriser T[i] dans x
          x ← T[i]
          # décaler vers la droite les éléments de T[0]..T[i-1] qui sont plus grands que x (en partant de T[i-1])
          j ← i
          tant que j > 0 et T[j - 1] > x
              T[j] ← T[j - 1]
              j ← j - 1
          fin tant que
          # placer x dans le "trou" laissé par le décalage
          T[j] ← x
     fin pour
  fin procédure */
        public static void Sort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int valI = array[i];

                int j = i;
                while (j > 0 && array[j - 1] > valI)
                {
                    array[j] = array[j - 1];
                    j--;
                }

                array[j] = valI;
            }
        }
    }
}
