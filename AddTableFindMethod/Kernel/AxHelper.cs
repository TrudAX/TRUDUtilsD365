using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Dynamics.AX.Metadata.Core.MetaModel;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Core;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation;
using Microsoft.Dynamics.Framework.Tools.MetaModel.Automation.Tables;
using Microsoft.Dynamics.Framework.Tools.ProjectSystem;

using Metadata = Microsoft.Dynamics.AX.Metadata;
using Microsoft.Dynamics.AX.Metadata.MetaModel;
using Microsoft.Dynamics.Framework.Tools.Extensibility;
using EnvDTE;
using System.Globalization;

namespace TRUDUtilsD365.Kernel
{
    public class AxHelper
    {
        private Metadata.Providers.IMetadataProvider metadataProvider = null;
        private Metadata.Service.IMetaModelService metaModelService = null;
        private Metadata.MetaModel.ModelSaveInfo modelSaveInfo = null;

        public Metadata.Providers.IMetadataProvider MetadataProvider
        {
            get
            {
                if (this.metadataProvider == null)
                {
                    this.metadataProvider = DesignMetaModelService.Instance.CurrentMetadataProvider;
                }
                return this.metadataProvider;
            }
        }
        public Metadata.MetaModel.ModelSaveInfo ModelSaveInfo
        {
            get
            {
                if (this.modelSaveInfo == null)
                {
                    VSProjectNode activeProjectNode = AxHelper.GetActiveProjectNode();
                    var modelInfo = activeProjectNode.GetProjectsModelInfo(true);
                    modelSaveInfo = new Metadata.MetaModel.ModelSaveInfo(modelInfo);
                }

                return modelSaveInfo;
            }
        }

        public Metadata.Service.IMetaModelService MetaModelService
        {
            get
            {
                if (this.metaModelService == null)
                {
                    this.metaModelService = DesignMetaModelService.Instance.CurrentMetaModelService;
                }
                return this.metaModelService;
            }
        }

        static VSProjectNode GetActiveProjectNode()
        {
            DTE dte = CoreUtility.ServiceProvider.GetService(typeof(DTE)) as DTE;
            if (dte == null)
            {
                throw new NotSupportedException(string.Format(CultureInfo.InvariantCulture, "No service for DTE found. The DTE must be registered as a service for using this API.", new object[0]));
            }

            Array array = dte.ActiveSolutionProjects as Array;
            if (array != null && array.Length > 0)
            {
                Project project = array.GetValue(0) as Project;
                if (project != null)
                {
                    return project.Object as VSProjectNode;
                }
            }
            return null;
        }

        public  void AppendToActiveProject(INamedObject edt)
        {
            
            VSProjectNode activeProjectNode = AxHelper.GetActiveProjectNode();

            activeProjectNode.AddModelElementsToProject(new List<MetadataReference>
            {
                new MetadataReference(edt.Name, edt.GetType())
            });

        }
    }
}