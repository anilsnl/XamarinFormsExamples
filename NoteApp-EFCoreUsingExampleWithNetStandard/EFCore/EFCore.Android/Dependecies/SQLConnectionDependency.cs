using EFCore.Droid.Dependecies;
using EFCore.EF_CORE;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLConnectionDependency))]
namespace EFCore.Droid.Dependecies
{
    public class SQLConnectionDependency : ISQLLiteConnection
    {
        public string GetDbPath(string dbname)
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbname);
        }
    }
}