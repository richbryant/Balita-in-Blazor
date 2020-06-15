using System;
using System.Linq;
using LanguageExt;

namespace Balita.Data
{
    public static class Extensions
    {
        public static IQueryable<TSource> TakeOption<TSource>(this IQueryable<TSource> source, Option<int> count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (count.IsNone) return source;

            var countVal = count.Match(Some: x => x, None: () => 0);

            return source.Take(countVal);
        }
    }
}
