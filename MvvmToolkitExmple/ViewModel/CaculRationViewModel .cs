using Microsoft.Maui.Controls;
using MvvmToolkitExmple.Entities;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace MvvmToolkitExmple.ViewModel
{
    public class CaculRationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Forage> Forages { get; set; }

        private double ingestionCapacity = 100;
        public double IngestionCapacity
        {
            get => ingestionCapacity;
            set
            {
                ingestionCapacity = value;
                OnPropertyChanged(nameof(IngestionCapacity));
            }
        }

        private double totalKgMS;
        public double TotalKgMS
        {
            get => totalKgMS;
            set
            {
                totalKgMS = value;
                OnPropertyChanged(nameof(TotalKgMS));
            }
        }

        private string alertMessage;
        public string AlertMessage
        {
            get => alertMessage;
            set
            {
                alertMessage = value;
                OnPropertyChanged(nameof(AlertMessage));
            }
        }

        private string alertColor;
        public string AlertColor
        {
            get => alertColor;
            set
            {
                alertColor = value;
                OnPropertyChanged(nameof(AlertColor));
            }
        }

        public ICommand CalculateCommand { get; }

        public CaculRationViewModel()
        {
            
            Forages = new ObservableCollection<Forage>
            {
                new Forage { Name = "Betteraves Fourragères", PercentMS = 13 },
                new Forage { Name = "Paille de Pois", PercentMS = 86 },
                new Forage { Name = "Paille d'Avoine", PercentMS = 88 },
                new Forage { Name = "Paille d'Orge", PercentMS = 88 },
                new Forage { Name = "Paille de Blé", PercentMS = 88 },
                new Forage { Name = "Paille de Colza", PercentMS = 88 }
            };

         
            CalculateCommand = new Command(CalculateTotalKgMS);
        }

    
        private void CalculateKgMS(Forage forage)
        {
            forage.KgMS = forage.KgMB * (forage.PercentMS / 100); 
        }

        
        private void CalculateTotalKgMS()
        {
            
            foreach (var forage in Forages)
            {
                CalculateKgMS(forage);
            }

           
            TotalKgMS = Forages.Sum(f => f.KgMS);

            
            if (TotalKgMS < IngestionCapacity - 10)
            {
                AlertMessage = "Alerte : La capacité d’ingestion de votre vache n’est pas saturée." +
                    " Augmentez la quantité des fourrages distribuées.";
                AlertColor = "Orange";
            }
            else if (TotalKgMS > IngestionCapacity + 10)
            {
                AlertMessage = "Alerte : La capacité d’ingestion de votre vache est sursaturée." +
                    " Diminuez la quantité des fourrages distribuées.";
                AlertColor = "Red";
            }
            else
            {
                AlertMessage = "La capacité d’ingestion de votre vache est équilibrée.";
                AlertColor = "Green";
            }

            OnPropertyChanged(nameof(AlertMessage));
            OnPropertyChanged(nameof(AlertColor));
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    
   
}
