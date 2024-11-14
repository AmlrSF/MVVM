using SQLite;

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
    }
}
