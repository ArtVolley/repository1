using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DisplayNameAttribute = DevExpress.Xpo.DisplayNameAttribute;
using ForTestEx2;

namespace TestEx2.Module.BusinessObjects
{
    [DefaultClassOptions]


    public class Airport : XPObject
    {
        public Airport(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        private string _nameofairport;
        private int count;

        //  private string _pilots;

        

        [RuleUniqueValue]
        [RuleRequiredField]
        [DisplayName("Название")]
        public string NameOfAirport
        {
            get
            {
                return _nameofairport;
            }
            set
            {

                SetPropertyValue("Название", ref _nameofairport, value);
            }
        }




        [Association("Airport-Pilots")]
        [DisplayName("Пилоты")]
        public XPCollection<Pilot> Pilots
        {
            get
            {
                return GetCollection<Pilot>("Pilots");
            }
        }

        [DisplayName("Кол-во пилотов")]
        public int QtyPilots
        {
            get
            {
                return Pilots.Count;
            }
        }



        [Association("Airport-Planes")]
        [DisplayName("Самолеты")]
        public XPCollection<Plane> Planes
        {
            get
            {
                return GetCollection<Plane>("Planes");
            }
        }



        [DisplayName("Кол-во самолетов")]
        public int QtyPlanes
        {
            get
            {
                return Planes.Count;
            }
        }

        //библиотека

        protected override void OnSaving()
        {
            if ((Class1.CheckAirportAccordance(this, Planes))&&(Class1.CheckAirportAccordance(this, Pilots)))
            {
                base.OnSaving();
            }
            else throw new Exception("Ошибка");
        }
        
    
    }
}
