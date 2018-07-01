using EFCore.EF_CORE;
using EFCore.UWP.Dependecies;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLConnectionDependency))]
namespace EFCore.UWP.Dependecies
{
    public class SQLConnectionDependency : ISQLLiteConnection
    {
        public string GetDbPath(string dbname)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, dbname);
        }
    }
}
