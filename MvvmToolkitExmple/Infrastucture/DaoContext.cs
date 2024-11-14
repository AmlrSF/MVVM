using MvvmToolkitExmple.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvvmToolkitExmple.Infrastucture
{
    public class DaoContext
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(
                ApplicationContext.DatabasePath,
                ApplicationContext.Flags);
        });

        public static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;
        readonly Action<Exception> OnError;
        public DaoContext()
        {
            OnError = new Action<Exception>((x) => {
                Console.WriteLine("erreur DaoContext : " + x.Message);
                //throw x; 
            });
            InitializeAsync().SafeFireAndForget(false, OnError);
        }
        async Task InitializeAsync()
        {
            
        }
    }
}
