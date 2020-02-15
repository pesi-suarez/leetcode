using System.Collections.Generic;

//TODO: Mirar cómo sería la implementación de una tabla de hash.
//TODO: Intentar no tenerlo todo público.

//NOTA: Tardé 1:15 en resolver el problema. La solución está en el top 1% de las más rápidas.
//NOTA: Me equivoqué al no tener en cuenta que podía haber operaciones de actualización (put de una key ya existente).
//NOTA: Pero el resto del planteamiento estuvo correcto a la primera, incluidos los casos extremos.
namespace p146LruCache
{
    public class LRUCache
    {
        public class Item
        {
            public int Key { get; set; }
            public int Value { get; set; }
            public Item Next { get; set; }
            public Item Previous { get; set; }
        }

        public Dictionary<int, Item> Cache { get; set; }
        public int MaxCapacity { get; set; }
        public Item First { get; set; }
        public Item Last { get; set; }

        public LRUCache(int capacity)
        {
            Cache = new Dictionary<int, Item>();
            MaxCapacity = capacity;
        }

        public int Get(int key)
        {
            if (!Cache.ContainsKey(key))
                return -1;
            Item item = Cache[key];
            Use(item, key);

            return item.Value;
        }

        private void Use(Item item, int key)
        {
            //Para el primer elemento no hay que hacer nada, pero así forzamos el flujo.
            if (First.Key == key)
            {

            }
            //Último elemento. 
            else if (Last.Key == key)
            {
                Item next = item.Next;
                next.Previous = null;
                First.Next = item;
                item.Previous = First;
                item.Next = null;
                First = item;
                Last = next;
            }
            //Elemento en el medio.
            else
            {
                Item previous = item.Previous;
                Item next = item.Next;
                previous.Next = next;
                next.Previous = previous;
                First.Next = item;
                item.Previous = First;
                item.Next = null;
                First = item;
            }
        }

        public void Put(int key, int value)
        {
            if (Cache.ContainsKey(key))
            {
                Item item = Cache[key];
                item.Value = value;
                Use(item, key);
                return;
            }

            //Miramos si tenemos que echar a alguien.
            //En tal caso, reasignamos el último elemento como el siguiente del último y eliminamos el último.
            if (Cache.Count == MaxCapacity)
            {
                Item aux = Last;
                if (MaxCapacity != 1)
                    Last = aux.Next;
                Cache.Remove(aux.Key);
            }

            //En cualquier caso, guardamos el nuevo en el diccionario y reasignamos siguiente del primero antiguo como el nuevo elemento y el primero nuevo, también como el nuevo elemento.
            Item newItem = new Item
            {
                Key = key,
                Value = value,
                Next = null,
                Previous = First
            };

            if (Cache.Count == 0)
                Last = newItem;
            else
                First.Next = newItem;

            Cache.Add(key, newItem);
            First = newItem;
        }
    }
}
