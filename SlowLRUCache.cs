public class LRUCache
  {
      class Cache
      {
          public int key { get; set; }
          public int value { get; set; }
          public int hits { get; set; }
      }

      private int capacity = 0;
      private List<Cache> storage;
      public LRUCache(int capacity)
      {
          storage = new List<Cache>();
          this.capacity = capacity;
      }

      public int Get(int key)
      {
          var elem = storage.FirstOrDefault(o => o.key == key);
          if (elem == null)
          {
              return -1;
          }
          else
          {
              ResetHits();
              elem.hits = 1;
              storage = storage.OrderBy(o => o.hits).ToList();
              return elem.value;
          }
      }

      private void ResetHits()
      {
          foreach (var store in storage)
          {
              store.hits = 0;
          }
      }

      public void Put(int key, int value)
      {
          var existing = storage.FirstOrDefault(o => o.key == key);
          if (existing != null)
          {
              storage.Remove(existing);
          }
          else
          {
              if (storage.Count >= capacity)
              {
                  storage.Remove(storage.First());
              }
          }
          storage.Add(new Cache()
          {
              key = key,
              value = value,
              hits = 0
          });
          ResetHits();
      }
  }
