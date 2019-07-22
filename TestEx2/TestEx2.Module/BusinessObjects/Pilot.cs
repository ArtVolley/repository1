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


    public class Pilot : XPObject
    {
        public Pilot(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        private string _name;
        private Airport _airport;
        private int count;



        [RuleRequiredField]
        [DisplayName("Имя")]
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetPropertyValue("Имя", ref _name, value);
            }
        }



        [Association("Airport-Pilots")]
        [DisplayName("Аэропорт")]
        public Airport Airport
        {
            get
            {
                return _airport;
            }
            set
            {
                SetPropertyValue("Аэропорт", ref _airport, value);
            }
        }



        [Association("Pilot-Planes")]
        [DisplayName("Прикрепленные самолеты")]
        public XPCollection<Plane> OwnPlane
        {
            get
            {
                return GetCollection<Plane>("OwnPlane");
            }
        }

  
        [DisplayName("Кол-во самолетов")]
        public int QtyPlanes
        {
            get
            {
                return OwnPlane.Count; ;
            }
        }



        [Association("Plane-WhoCanUse")]
        [DisplayName("Разрешенные самолеты")]
        public XPCollection<Plane> AllowedPlanes
        {
            get
            {
                return GetCollection<Plane>("AllowedPlanes");
            }
        }

        //библиотека
        protected override void OnSaving()
        {
            if ((Class1.check(this, OwnPlane))&& (Class1.check(this, AllowedPlanes)))
            {
                base.OnSaving();
            }
            else throw new Exception("Ошибка");
        }





    }
}