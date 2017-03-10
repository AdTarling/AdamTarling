using System.Collections.Generic;
using System.Linq;

namespace adamtarling.web.ExtensionMethods
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> enumerable)
        {
            var collection = enumerable as ICollection<T>;

            if (collection != null)
            {
                return collection.Count < 1;
            }

            return enumerable == null || !enumerable.Any();
        }
    }
}