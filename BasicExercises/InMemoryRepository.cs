using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BasicExercises
{
    public class InMemoryRepository<T> : IRepository<T>
    {
        private readonly Collection<T> _collection = new();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public T Get(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public T[] GetAll()
        {
            throw new NotImplementedException();
        }

        public T Update(Func<T, bool> predicate, T item)
        {
            throw new NotImplementedException();
        }
    }
}
