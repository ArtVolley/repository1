using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using TestEx2.Module.BusinessObjects;

namespace TestEx2.Module
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppWindowControllertopic.aspx.
    public partial class Generate : WindowController
    {
        public Generate()
        {
            InitializeComponent();
            // Target required Windows (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target Window.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void Generation_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            string connectionString = MSSqlConnectionProvider.GetConnectionString("ART-LAPTOP\\SQLEXPRESS", "TestEx2");
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);
            Session session = new Session();
            for (int i = 1; i < 101; i++)
            {
                Airport a = new Airport(session);
                a.NameOfAirport = "Аэропорт " + i.ToString();
                Pilot b = new Pilot(session);
                b.Name = "Пилот " + i.ToString() + "0";
                Pilot c = new Pilot(session);
                c.Name = "Пилот " + i.ToString() + "1";
                Plane d = new Plane(session);
                d.NameOfPlane = "Самолет " + i.ToString() + "0";
                Plane f = new Plane(session);
                f.NameOfPlane = "Самолет " + i.ToString() + "1";
                Plane g = new Plane(session);
                g.NameOfPlane = "Самолет " + i.ToString() + "2";
                Plane h = new Plane(session);
                h.NameOfPlane = "Самолет " + i.ToString() + "3";
                Plane j = new Plane(session);
                j.NameOfPlane = "Самолет " + i.ToString() + "4";
                b.OwnPlane.Add(d);
                b.AllowedPlanes.Add(f);
                b.AllowedPlanes.Add(g);
                c.OwnPlane.Add(h);
                c.OwnPlane.Add(j);
                c.AllowedPlanes.Add(f);
                c.AllowedPlanes.Add(g);
                c.AllowedPlanes.Add(d);

                b.Airport = a;
                c.Airport = a;
                d.Airport = a;
                f.Airport = a;
                g.Airport = a;
                h.Airport = a;
                j.Airport = a;

                a.Save();
                b.Save();
                c.Save();
                d.Save();
                f.Save();
                g.Save();
                h.Save();
                j.Save();
                
            }
            //session.ClearDatabase();

        }
    }
}
