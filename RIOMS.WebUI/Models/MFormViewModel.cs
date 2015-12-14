using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RIOMS.Domain;
namespace RIOMS.WebUI.Models
{
    public class MFormViewModel
    {
        Defaulter total=new Defaulter();
        IEnumerable<Defaulter> cessDefaulters;
        public MFormViewModel(IEnumerable<Defaulter> argcessDefaulters)
        {
        //    cessDefaulters = argcessDefaulters;
        //    total.Current = argcessDefaulters.Sum(d => d.Current.GetValueOrDefault());
        //    total.Previous = argcessDefaulters.Sum(d => d.Previous.GetValueOrDefault());
        //    total.Second = argcessDefaulters.Sum(d => d.Second.GetValueOrDefault());
        //    total.Third = argcessDefaulters.Sum(d => d.Third.GetValueOrDefault());
        //    total.MoreThanThree = argcessDefaulters.Sum(d => d.MoreThanThree.GetValueOrDefault());
        }

       public IEnumerable<Defaulter> CessDefaulters
       {
           get { return cessDefaulters; }
       }
       public Defaulter Total { get {

           return total;
       } }
    }
}