using MvvmToolkitExmple.Infrastucture;

using SQLite;
using System;
using System.IO;
using System.Resources;

namespace MvvmToolkitExmple
{
    public class ApplicationContext
    {

        public SQLiteAsyncConnection Database { get; }
        public static DaoContext DataContext { get; private set; }
        public static ResourceManager Resource { get; private set; }
        public const string DatabaseFilename = "GPP.db3";//Gestion de Produits pour Pharmacie

        public const SQLiteOpenFlags Flags =
          // open the database in read/write mode
          SQLiteOpenFlags.ReadWrite |
          // create the database if it doesn't exist
          SQLiteOpenFlags.Create |
          // enable multi-threaded database access
          SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
        public ApplicationContext(ResourceManager resource)
        {
            Resource = resource;
            DataContext = new DaoContext();
        }

    }
}
