using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.ViewModels.Singletons
{
    public sealed class MainViewModelSingleton
    {
        public MainViewModel Item { get; set; }

        private static MainViewModelSingleton _Instance;

        public static MainViewModelSingleton Instance
        {
            get 
            {
                if (_Instance == null)
                {
                    _Instance = new MainViewModelSingleton();
                }
                return _Instance; 
            }
            set 
            { 
                _Instance = value; 
            }
        }

        private MainViewModelSingleton() { }

    }
}
