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
                if (_name != value.Trim())
                {
                    _name = value.Trim(); 
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public string Category
        {
            get => _category;
            set
            {
                if (_category != value.Trim())
                {
                    _category = value.Trim(); 
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
