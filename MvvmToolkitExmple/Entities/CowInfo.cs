using SQLite;

namespace MvvmToolkitExmple.Entities
{
    class CowInfo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string weight { get; set; }
       
        public int Age { get; set; }
    }
}
