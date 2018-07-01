using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EFCore.EF_CORE;
using EFCore.iOS.Dependencies;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(SQLConnectionDependency))]
namespace EFCore.iOS.Dependencies
{
    public class SQLConnectionDependency : ISQLLiteConnection
    {
        public string GetDbPath(string dbname)
        {
            var libFolder = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, dbname);
        }
    }
}