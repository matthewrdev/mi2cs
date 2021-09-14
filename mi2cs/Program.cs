using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using mi2cs.Helpers;

namespace mi2cs
{
    public static class MainClass
    {
        private const string Endpoint = "https://raw.githubusercontent.com/Templarian/MaterialDesign/master/meta.json";

        public static async Task Main(string[] args)
        {
            var exportPath = AssemblyHelper.EntryAssemblyDirectory;
            if (args != null && args.Any())
            {
                exportPath = args.First();
            }

            var outputPath = Path.Combine(exportPath, "mi2cs-output");

            if (Directory.Exists(outputPath))
            {
                Directory.Delete(outputPath, true);
            }

            Directory.CreateDirectory(outputPath);
            
            var icons = await MaterialIconDownloader.DownloadIconCodes(Endpoint);
            var code = CodeWriter.Write(icons);
            
            Console.WriteLine("Writing output file...");
            File.WriteAllText(Path.Combine(outputPath, "MaterialIcons.cs"), code);
            
            Console.WriteLine($"Opening output directory at {outputPath}...");
            OpenFileHelper.OpenAndSelect(outputPath);
        }
    }
}
