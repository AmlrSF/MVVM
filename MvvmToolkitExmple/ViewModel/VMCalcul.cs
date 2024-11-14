using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmToolkitExmple.business;
using MvvmToolkitExmple.Entities;
using System;

namespace MvvmToolkitExmple.ViewModel
{
    internal partial class VMCalcul : ObservableObject
    {
        private readonly CalculationService _calculationService;

        public Cow CowData { get; set; }

        public VMCalcul()
        {
            _calculationService = new CalculationService();
            CowData = new Cow();
            LoadCMD = new RelayCommand(CalculateCI);
        }

       
        [ObservableProperty]
        private double resultCI;

        public IRelayCommand LoadCMD { get; }

        private void CalculateCI()
        {
            ResultCI = _calculationService.CalculateCI(
                     CowData.PoidsVif,
                     CowData.ProductionLait,
                     CowData.NoteEtatCorps,
                     CowData.Parite,
                     CowData.SemaineLactation,
                     CowData.SemaineGestation,
                     CowData.Age);
        }
    }
}
