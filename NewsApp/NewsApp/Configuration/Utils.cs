using System.IO;
using System.Reflection;

namespace NewsApp.Configuration
{
    public static class Utils
    {
        public static void ExtractSavedResource(string filename, string location)
        {
            var a = Assembly.GetExecutingAssembly();
            using (var resFileStream = a.GetManifestResourceStream(filename))
            {
                if (resFileStream != null)
                {
                    var full = Path.Combine(location, filename);
                    using (var stream = File.Create(full))
                    {
                        resFileStream.CopyTo(stream);
                    }
                }
            }
        }
    }
}
