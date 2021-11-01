using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BasicExercises
{
    /// <summary>
    /// This new Exercise is to show WHY we want to use Interfaces. 
    /// Replace theStore in your original implementation from Exercise2 with the new
    /// <see cref="IRepository{T}"/>
    /// </summary>
    public class Exercise3: IStoreInventory
    {
        private readonly IRepository<InventoryItem> theStore;
        public Exercise3(IRepository<InventoryItem> repository) => theStore = repository;

        public InventoryItem Buy(string name, int count)
        {
            if ( count <= 0 )
            {
                throw new InvalidOperationException("Item count can not be negative or zero!");
            }
            var item = GetByName(name);
            if (item.Name != null)
            {
                if ( count > item.Count )
                {
                    throw new InvalidOperationException("Don't have enough item/s in the stock to buy!");
                }
                item.Count -= count;
                theStore.Update(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase), item);
            }
            return item;
        }

        public InventoryItem[] GetAll()
        {
            return theStore.GetAll();
        }

        public InventoryItem GetByName(string name)
        {
            return theStore.Get( item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase) );
        }

        public InventoryItem Stock(string name, int count)
        {
            if ( count <= 0 )
            {
                throw new InvalidOperationException("Item count can not be negative or zero!");
            }
            var item = GetByName(name);
            if (item.Name != null)
            {
                item.Count += count;
                theStore.Update(item => item.Name.Equals(name, StringComparison.OrdinalIgnoreCase), item);
            } 
            else 
            {
                item = new InventoryItem
                    {
                        Name = name,
                        Count = count
                    };
                theStore.Add(item);
            }
            return item;
        }
    }

}
