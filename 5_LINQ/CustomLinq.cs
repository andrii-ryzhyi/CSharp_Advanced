using System;
using System.Collections.Generic;

namespace IteaLinq
{
    public static class CustomLinq
    {
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
<<<<<<< HEAD
                if (predicate(item))
                    yield return item;
=======
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
>>>>>>> b98c0122454e40247b55ad6a0cd6f2bf3579d819
        }
    }
}
