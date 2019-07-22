using DevExpress.ExpressApp;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Xpo;
using DevExpress.Persistent.BaseImpl;
using System;
using System.Collections.Generic;
using TestEx2.Module.BusinessObjects;
using TestEx2.Module.Reports;

using DevExpress.DataAccess.Sql;
//using DevExpress.DataAccess.Sql.SqlDataSource;

namespace TestEx2.Module
{
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.ModuleBase.
    public sealed partial class TestEx2Module : ModuleBase {
        public TestEx2Module() {
            InitializeComponent();
			BaseObject.OidInitializationMode = OidInitializationMode.AfterConstruction;
        }
 
        public override void Setup(XafApplication application) {
            base.Setup(application);
            // Manage various aspects of the application UI and behavior at the module level.
        }
        public override void CustomizeTypesInfo(ITypesInfo typesInfo) {
            base.CustomizeTypesInfo(typesInfo);
            CalculatedPersistentAliasHelper.CustomizeTypesInfo(typesInfo);
        }




        public override IEnumerable<ModuleUpdater> GetModuleUpdaters(
            IObjectSpace objectSpace, Version versionFromDB)
        {
            ModuleUpdater updater = new DatabaseUpdate.Updater(objectSpace, versionFromDB);
            PredefinedReportsUpdater predefinedReportsUpdater =
                new PredefinedReportsUpdater(Application, objectSpace, versionFromDB);
            //predefinedReportsUpdater.AddPredefinedReport<ReportPilots>(
            ///"Report about pilots", typeof(Pilot));
            return new ModuleUpdater[] { updater, predefinedReportsUpdater };
        }


    }
}
