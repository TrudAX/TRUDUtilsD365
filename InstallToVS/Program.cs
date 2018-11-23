using System;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace InstallToVS
{
    class Program
    {
        private const string DllName1     = "TRUDUtilsD365.dll";
        private const string DllName2     = "TRUDUtilsD365.pdb";
        private const string AddinFolder = "AddinExtensions";

        static void Main(string[] args)
        {
            try
            {
                string extensionFolderName = FindExtensionFolder();
                Console.WriteLine($"VS extension folder: {extensionFolderName}");
                string sourcePath = Path.Combine(Environment.CurrentDirectory, DllName1);
                string targetPath = Path.Combine(extensionFolderName, DllName1);
                File.Copy(sourcePath, targetPath, true);

                sourcePath = Path.Combine(Environment.CurrentDirectory, DllName2);
                targetPath = Path.Combine(extensionFolderName, DllName2);
                File.Copy(sourcePath, targetPath, true);

                Console.WriteLine("Setup finished! Close and enjoy!");

            }
            catch (Exception ee)
            {
                Console.Error.WriteLine(ee);
                Console.Error.WriteLine("Seems that an issue prevented me from doing my job :(");
            }

            Console.ReadLine();
        }
        private static string FindExtensionFolder()
        {
            /*
            using (var extensionsRegKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\VisualStudio\14.0\ExtensionManager\EnabledExtensions"))
            {
                string path = "";
                if (extensionsRegKey != null)
                {
                    string axToolsKeyName = extensionsRegKey.GetValueNames()
                        .FirstOrDefault(name => name.StartsWith("DynamicsRainierVSTools"));
                    if (axToolsKeyName != null)
                    {
                        path = (string) extensionsRegKey.GetValue(axToolsKeyName);
                    }
                }
                */
            string path = "";
            RegistryKey d365Key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\VisualStudio\14.0_Config\AutomationProperties\Dynamics 365");
            if (d365Key != null)
            {
                string package = (string) d365Key.GetValue("Package");

                RegistryKey pathKey =
                    Registry.CurrentUser.OpenSubKey(
                        $@"SOFTWARE\Microsoft\VisualStudio\14.0_Config\BindingPaths\{package}");
                if (pathKey != null)
                {
                    path = pathKey.GetValueNames()[0];
                }
            }

            if (string.IsNullOrEmpty(path))
            {
                throw new ApplicationException("Could not find D365FO tools in Windows registry.");
            }
            return Path.Combine(path, AddinFolder);
            //}

        }
    }
}
