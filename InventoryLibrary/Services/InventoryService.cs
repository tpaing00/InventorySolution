using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using InventoryLibrary.Models;

namespace InventoryLibrary.Services
{
    public class InventoryService
    {
        public ObservableCollection<InventoryItem> InventoryItems { get; private set; } = new ObservableCollection<InventoryItem>();


    }
}
