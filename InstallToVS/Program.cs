using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace InstallToVS
{
    public class FileUnblocker
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool DeleteFile(string name);

        public bool Unblock(string fileName)
        {
            return DeleteFile(fileName + ":Zone.Identifier");
        }
    }
    class Program
    {
        private const string DllName1     = "TRUDUtilsD365.dll";
        private const string DllName2     = "TRUDUtilsD365.pdb";
        private const string SettingsName = "TRUDUtilsD365Settings.xml";

        private const string AddinFolder = "AddinExtensions";

        static void Main(string[] args)
        {
            try
            {
                FileUnblocker unblocker = new FileUnblocker();
                string extensionFolderName = FindExtensionFolder();
                Console.WriteLine($"VS extension folder: {extensionFolderName}");
                string sourcePath = Path.Combine(Environment.CurrentDirectory, DllName1);
                unblocker.Unblock(sourcePath);
                string targetPath = Path.Combine(extensionFolderName, DllName1);
                File.Copy(sourcePath, targetPath, true);

                sourcePath = Path.Combine(Environment.CurrentDirectory, DllName2);
                unblocker.Unblock(sourcePath);
                targetPath = Path.Combine(extensionFolderName, DllName2);
                File.Copy(sourcePath, targetPath, true);

                sourcePath = Path.Combine(Environment.CurrentDirectory, SettingsName);
                if (File.Exists(sourcePath))
                {
                    unblocker.Unblock(sourcePath);
                    targetPath = Path.Combine(extensionFolderName, SettingsName);
                    File.Copy(sourcePath, targetPath, true);
                }

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
            String path="";

            path = Environment.GetEnvironmentVariable("DynamicsVSTools");

            if (string.IsNullOrEmpty(path))
            {
                path = ExtractFolderPathFromRegistry();
            }
            if (string.IsNullOrEmpty(path))
            {
                throw new ApplicationException("Could not find D365FO tools in Windows registry.");
            }

            return Path.Combine(path, AddinFolder);
            //}

        }
        static string ExtractFolderPathFromRegistry()
        {
            string registryKeyPath = @"SOFTWARE\Classes\dynamics\shell\open\command";
            try
            {
                using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKeyPath))
                {
                    if (key != null)
                    {
                        string value = key.GetValue(null) as string; // Get (Default) value
                        if (!string.IsNullOrEmpty(value))
                        {
                            string pattern = @"C:\\Program Files\\Microsoft Visual Studio\\2022\\(Community|Enterprise|Professional)\\Common7\\IDE\\Extensions\\[^\\]+";
                            Match match = Regex.Match(value, pattern, RegexOptions.IgnoreCase);

                            if (match.Success)
                            {
                                return match.Value;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error accessing registry: {ex.Message}");
            }

            return null;
        }
    }
}
