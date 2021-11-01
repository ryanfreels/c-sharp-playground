using System;

namespace BasicExercises
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Retrieve from the repository an item using a <see cref="Predicate{T}"/>
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T Get(Func<T, bool> predicate);
        /// <summary>
        /// Retrieve all items from the Repository
        /// </summary>
        /// <returns></returns>
        T[] GetAll();
        /// <summary>
        /// Update an item in the Repository
        /// </summary>
        /// <param name="predicate">A <see cref="Predicate{T}"/> to identify the item to update.</param>
        /// <param name="item">The item to update</param>
        /// <returns>The original value</returns>
        T Update(Func<T, bool> predicate, T item);
        /// <summary>
        /// Add an item to the Repository
        /// </summary>
        /// <param name="item"></param>
        void Add(T item);
    }

}
