using System;
using System.Collections.Generic;

namespace Pool
{
    public class Pool<T> where T : new()
    {
        private Queue<T> objects;
        private int count;

        public Pool(int count)
        {
            this.count = count;
            objects = new Queue<T>(count);

            for (int i = 0; i < count; i++)
            {
                objects.Enqueue(new T());
            }
        }

        public T GetObject()
        {
            if (objects.Count == 0)
            {
                objects.Enqueue(new T());
            }

            return objects.Dequeue();
        }

        public void ReturnObject(T entity)
        {
            objects.Enqueue(entity);
        }
    }

    public class PoolGuard<T> : IDisposable
    {
        private Pool<T> pool;
        private T pooledObject;

        public PoolGuard(Pool<T> pool)
        {
            this.pool = pool;
            pooledObject = pool.GetObject();
        }

        public T GetObject()
        {
            return pooledObject;
        }

        public void Dispose()
        {
            pool.ReturnObject(pooledObject);
        }
    }
}
