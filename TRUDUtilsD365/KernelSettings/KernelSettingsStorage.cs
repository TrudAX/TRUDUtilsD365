using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Dynamics.Ax.Xpp;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using TRUDUtilsD365.Kernel;


namespace TRUDUtilsD365.KernelSettings
{
    class KernelSettingsStorage
    {        
        private string GetFilePath()
        {
            string fileName = "TRUDUtilsD365Settings.xml";// _" + Common.CommonUtil.GetCurrentModel().Name + ".json";
            string settingsFolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string filePath = "";
            if (!string.IsNullOrEmpty(settingsFolder))
            {
                filePath = Path.Combine(settingsFolder, fileName);
            }
            return filePath;
        }


        public void SaveSettings(AxModelSettings axModelSettings)
        {
            var filePath = this.GetFilePath();

            try
            {
                var xmlDocument = new XmlDocument();
                var serializer = new DataContractSerializer(axModelSettings.GetType());
                using (var sw = new StringWriter())
                {
                    using (var writer = new XmlTextWriter(sw))
                    {
                        writer.Formatting = Formatting.Indented; // indent the Xml so it's human readable
                        serializer.WriteObject(writer, axModelSettings);
                        writer.Flush();
                    }
                }
                /*
                using (var stream = new MemoryStream())
                {
                    serializer.Serialize(stream, axModelSettings);
                    stream.Position = 0;
                    xmlDocument.Load(stream);
                    xmlDocument.Save(filePath);
                    stream.Close();
                }
                */
            }
            catch (Exception ex)
            {
                CoreUtility.HandleExceptionWithErrorMessage(ex);
            }
           
        }

        public AxModelSettings LoadSettings()
        {
            AxModelSettings axModelSettings = null;
            //XmlDocument doc = new XmlDocument();
            //var xsSubmit = new DataContractSerializer(typeof(AxModelSettings));
            var filePath = this.GetFilePath();

            if (File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.Open);
                XmlDictionaryReader reader =
                    XmlDictionaryReader.CreateTextReader(fs, new XmlDictionaryReaderQuotas());
                DataContractSerializer ser = new DataContractSerializer(typeof(AxModelSettings));

                // Deserialize the data and read it from the instance.
                axModelSettings = (AxModelSettings)ser.ReadObject(reader, true);
                reader.Close();
                fs.Close();
                /*
                doc.Load(filePath);

                using (TextReader reader = new StringReader(doc.InnerXml))
                {
                    axModelSettings = (AxModelSettings)xsSubmit.Deserialize(reader);
                }
                */
            }

            return axModelSettings ?? (axModelSettings = new AxModelSettings());
        }
    }
}
