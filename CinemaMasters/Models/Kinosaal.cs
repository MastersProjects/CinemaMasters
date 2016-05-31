using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaMasters.Models
{
    public class Kinosaal
    {
        public int AnzahlReihen { get; set; }
        public int anzahlPlaetze { get; set; }
        public List<Reihe> Reihen {get;set;}
        public List<Vorstellung> Vorstellungen { get; set; }

        public void reservieren(Reihe reihe)
        {
            //ToDo
        }

        public void verwalten(Reihe reihe)
        {
            //ToDo
        }

        public void platzSuchen(Reihe reihe)
        {
            //ToDo
        }
    }
}