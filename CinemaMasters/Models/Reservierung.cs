using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaMasters.Models
{
    public class Reservierung
    {
        public Vorstellung Vorstellung { get; set; }
        public Reihe Reihe { get; set; }
        public List<Platz> Plaetze {get;set;}

        public void reservieren(Vorstellung vorstellung)
        {
            //ToDo
        }
    }
}