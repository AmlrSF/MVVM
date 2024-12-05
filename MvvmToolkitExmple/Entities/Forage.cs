using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmToolkitExmple.Entities
{
    public class Forage : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public double PercentMS { get; set; }

        private double kgMB;
        public double KgMB
        {
            get => kgMB;
            set
            {
                if (kgMB != value)
                {
                    kgMB = value;
                    OnPropertyChanged(nameof(KgMB));
                }
            }
        }

        private double kgMS;
        public double KgMS
        {
            get => kgMS;
            set
            {
                kgMS = value;
                OnPropertyChanged(nameof(KgMS));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
