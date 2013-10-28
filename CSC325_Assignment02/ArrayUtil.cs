using System;
using System.Collections.Generic;

namespace CSC325_Assignment02
{
    class ArrayUtil <T>
    {
        public static T findMin<T>(T[]arr, Func<T, T, bool>comparison)
        {
            T min = arr[0];

            for (int i = 0; i < arr.Length; i++ )
            {
                min = comparison(min, arr[i]) ? min : arr[i]; // min recieves smaller value of two arguments of comparison(T, T)
            }

            return min;
        }

        public static int find<T>(T[] arr, T target, Func<T, T, bool> equal)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if(equal(target, arr[i]))
                    return i;
            }
            return -1;
        }

    }
}
