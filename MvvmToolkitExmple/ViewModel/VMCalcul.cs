using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MvvmToolkitExmple.business;
using MvvmToolkitExmple.Entities;
using MvvmToolkitExmple.Infrastucture;
using MvvmToolkitExmple.Infrastucture;
using MvvmToolkitExmple.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MvvmToolkitExmple.ViewModel
{
    internal partial class VMCalcul : ObservableObject
    {
        private readonly CalculationService _calculationService;
        private readonly IDAOCow<CowInfo> _daoCows;

        public Cow CowData { get; set; }

        public ObservableCollection<CowInfo> CowsList { get; set; }

        public VMCalcul()
        {
            _calculationService = new CalculationService();
            _daoCows = new SqliteDaoCommandCows();
            CowData = new Cow();
            CowsList = new ObservableCollection<CowInfo>();
            LoadCMD = new RelayCommand(async () => await CalculateCI());
            LoadAllCowsCommand = new RelayCommand(async () => await LoadAllCows());
        }        }

        [ObservableProperty]
        private double resultCI;

        public IRelayCommand LoadCMD { get; }
        public IRelayCommand LoadAllCowsCommand { get; }

        private async Task CalculateCI()
        {
            if (IsValid())
            {
                ResultCI = _calculationService.CalculateCI(
                    CowData.PoidsVif,
                    CowData.ProductionLait,
                    CowData.NoteEtatCorps,
                    CowData.Parite,
                    CowData.SemaineLactation,
                    CowData.SemaineGestation,
                    CowData.Age);

                var cowInfo = new CowInfo
                {
                    weight = CowData.PoidsVif.ToString(),
                    Age = CowData.Age
                };

                await _daoCows.CreateAsync(cowInfo);
                await LoadAllCows(); 
            }
            else
            {
                Console.WriteLine("Cow data is not valid.");
            }
        }

        private async Task LoadAllCows()
        {
            var cows = await _daoCows.ReadAllAsync();
            CowsList.Clear();
            foreach (var cow in cows)
            {
                CowsList.Add(cow);
            }
        }

        public bool IsValid()
        {
            return CowData.PoidsVif >= 450 && CowData.PoidsVif <= 800 &&
                   CowData.ProductionLait >= 5 && CowData.ProductionLait <= 60 &&
                   CowData.NoteEtatCorps >= 0 && CowData.NoteEtatCorps <= 5 &&
                   (CowData.Parite == "Primipare" || CowData.Parite == "Multipare" || CowData.Parite == "Tarie") &&
                   CowData.SemaineLactation >= 0 &&
                   CowData.SemaineGestation >= 0 &&
                   CowData.Age >= 0;
        }
    }
}
