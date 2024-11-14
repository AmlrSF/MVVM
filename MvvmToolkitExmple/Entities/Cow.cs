using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmToolkitExmple.Entities
{
    class Cow
    {
        public double PoidsVif { get; set; }             
        public double ProductionLait { get; set; }      
        public double NoteEtatCorps { get; set; }        
        public string Parite { get; set; }               
        public int SemaineLactation { get; set; }        
        public int SemaineGestation { get; set; }      
        public int Age { get; set; }                     

       
        public bool IsValid()
        {
            return PoidsVif >= 450 && PoidsVif <= 800 &&
                   ProductionLait >= 5 && ProductionLait <= 60 &&
                   NoteEtatCorps >= 0 && NoteEtatCorps <= 5 &&
                   (Parite == "Primipare" || Parite == "Multipare" || Parite == "Tarie") &&
                   SemaineLactation >= 0 &&
                   SemaineGestation >= 0 &&
                   Age >= 0;
        }
    }
}
