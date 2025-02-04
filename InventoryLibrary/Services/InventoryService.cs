using InventoryLibrary.Models;
using System.Collections.ObjectModel;

namespace InventoryLibrary.Services
{
    public class InventoryService
    {
        public ObservableCollection<InventoryItem> InventoryList { get; } = new()
        {
            new InventoryItem { Name = "Laptop", Category = "Electronics", Quantity = 5 },
            new InventoryItem { Name = "Desk Chair", Category = "Furniture", Quantity = 10 }
        };

        public void AddItem(InventoryItem item)
        {
            if (!InventoryList.Any(i => i.Name == item.Name && i.Category == item.Category))
            {
                InventoryList.Add(item);
            }
        }

        public void EditItem(InventoryItem oldItem, InventoryItem newItem)
        {
            var index = InventoryList.IndexOf(oldItem);
            if (index != -1)
            {
                InventoryList[index] = newItem;
            }
        }

        public void DeleteItem(InventoryItem item)
        {
            InventoryList.Remove(item);
        }
    }
}

