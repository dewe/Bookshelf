using System.Collections.Generic;

namespace API.Services
{
    public static class SimpleStore<T>
    {
        private static IEnumerable<T> _items = new List<T>();

        public static IEnumerable<T> Items()
        {
            return _items;
        }

        public static void SetItems(IEnumerable<T> items)
        {
            _items = items;
        }

        public static IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}