﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace alamapp.Infrastructure.Event
{
   public static class IEnumerableExtensions
    {
       public static void ForEach<T>(this IEnumerable<T> source,Action<T> action)
       {
           foreach (T item in source)
               action(item);
       }
    }
}
