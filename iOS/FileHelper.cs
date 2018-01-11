using System;
using System.IO;
using Xamarin.Forms;
using MasterQ.iOS;
using Foundation;

[assembly: Dependency(typeof(FileHelper))]
namespace MasterQ.iOS
{
    [Preserve (AllMembers = true)] //alexpook link all
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }

            return Path.Combine(libFolder, filename);
        }
    }
}
