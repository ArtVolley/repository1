using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.ExpressApp.ConditionalAppearance;
using DisplayNameAttribute = DevExpress.Xpo.DisplayNameAttribute;
//using DevExpress.ExpressApp.Utils;

using ForTestEx2;

namespace TestEx2.Module.BusinessObjects
{
    [DefaultClassOptions]

    public class Plane : XPObject
    {
        public Plane(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();

        }

        private string _nameofplane;
        private Airport _airport;
        //   private Pilot _pilot;


        [Appearance("CategoryColoredInListView", AppearanceItemType = "ViewItem", TargetItems = "NameOfPlane",
        Criteria = "contains([NameOfPlane], 'a')||contains([NameOfPlane], 'A')", Context = "ListView", FontColor = "Green", Priority = 1)]
        [RuleUniqueValue]
        [RuleRequiredField]
        [Size(199)]
        [DisplayName("Номер")]
        public string NameOfPlane
        {
            get
            {
                return _nameofplane;
            }
            set
            {
                SetPropertyValue("Имя", ref _nameofplane, value);
            }
        }


        [Association("Airport-Planes")]
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
        [DisplayName("Ответственные пилоты")]
        public XPCollection<Pilot> Pilot
        {
            get
            {
                return GetCollection<Pilot>("Pilot");
            }
        }


        [Association("Plane-WhoCanUse")]
        [DisplayName("Кто может летать")]

        public XPCollection<Pilot> WhoCanUse 
        {
            get
            {
                return GetCollection<Pilot>("WhoCanUse");
            }
        }

        //библиотека
        protected override void OnSaving()
        {
            if ((Class1.check(this, Pilot))&&(Class1.check(this, WhoCanUse)))
            {
                base.OnSaving();
            }
            else throw new Exception("Ошибка");
        }

    }
}
