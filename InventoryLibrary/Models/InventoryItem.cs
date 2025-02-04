using System.ComponentModel;

namespace InventoryLibrary.Models
{
    public class InventoryItem : INotifyPropertyChanged
    {
        private string _name;
        private string _category;
        private int _quantity;

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value; 
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                if (_category != value)
                {
                    _category = value; 
                    OnPropertyChanged(nameof(Category));
                }
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (_quantity != value)
                {
                    _quantity = value; 
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
