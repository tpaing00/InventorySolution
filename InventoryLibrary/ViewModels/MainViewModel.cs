using InventoryLibrary.Models;
using InventoryLibrary.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xceed.Wpf.Toolkit;

namespace InventoryLibrary.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly InventoryService _inventoryService = new();
        private string _searchText = string.Empty;
        private InventoryItem _selectedItem;
        public ObservableCollection<InventoryItem> InventoryList { get; private set; }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged(nameof(SearchText));
                SearchItems();
            }
        }

        private string _itemName;
        public string ItemName
        {
            get => _itemName;
            set { _itemName = value; OnPropertyChanged(nameof(ItemName)); OnPropertyChanged(nameof(CanAdd)); }
        }

        private string _itemCategory;
        public string ItemCategory
        {
            get => _itemCategory;
            set { _itemCategory = value; OnPropertyChanged(nameof(ItemCategory)); OnPropertyChanged(nameof(CanAdd)); }
        }

        private int _itemQuantity;
        public int ItemQuantity
        {
            get => _itemQuantity;
            set { _itemQuantity = value; OnPropertyChanged(nameof(ItemQuantity)); }
        }
        public InventoryItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                OnPropertyChanged(nameof(CanEditOrDelete));
                if (_selectedItem != null)
                {
                    ItemName = _selectedItem.Name;
                    ItemCategory = _selectedItem.Category;
                    ItemQuantity = _selectedItem.Quantity;
                }
            }
        }

        public MainViewModel()
        {
            InventoryList = new ObservableCollection<InventoryItem>(_inventoryService.InventoryList);
        }

        public bool CanEditOrDelete => SelectedItem != null;
        public bool CanAdd => !string.IsNullOrWhiteSpace(ItemName) && !string.IsNullOrWhiteSpace(ItemCategory);

        public void AddItem()
        {
            if (!string.IsNullOrWhiteSpace(ItemName) && !string.IsNullOrWhiteSpace(ItemCategory) && ItemQuantity > 0)
            {
                var newItem = new InventoryItem { Name = ItemName, Category = ItemCategory, Quantity = ItemQuantity };
                if (!InventoryList.Any(i => i.Name == newItem.Name))
                {
                    _inventoryService.AddItem(newItem);
                    InventoryList.Add(newItem);
                    ClearInputs();
                }
                else
                {
                    Console.WriteLine("Duplicate item detected");
                }
            }
        }

        public void EditItem()
        {
            if (SelectedItem != null)
            {
                var updatedItem = new InventoryItem
                {
                    Name = ItemName,
                    Category = ItemCategory,
                    Quantity = ItemQuantity
                };

                _inventoryService.EditItem(SelectedItem, updatedItem);
                int index = InventoryList.IndexOf(SelectedItem);
                if (index != -1)
                {
                    InventoryList[index] = updatedItem;
                }
                ClearInputs();
            }
        }

        public void DeleteItem()
        {
            if (SelectedItem != null)
            {
                _inventoryService.DeleteItem(SelectedItem);
                InventoryList.Remove(SelectedItem);
                ClearInputs();
            }
        }

        private void SearchItems()
        {
            var filtered = _inventoryService.InventoryList
                .Where(item => string.IsNullOrEmpty(SearchText) ||
                               item.Name.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase) ||
                               item.Category.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase))
                .ToList();

            InventoryList.Clear();
            foreach (var item in filtered) InventoryList.Add(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private void ClearInputs()
        {
            ItemName = string.Empty;
            ItemCategory = string.Empty;
            ItemQuantity = 0;
            SelectedItem = null;

            OnPropertyChanged(nameof(CanAdd));
            OnPropertyChanged(nameof(CanEditOrDelete));
        }
    }
}
