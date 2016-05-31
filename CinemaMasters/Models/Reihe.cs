using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaMasters.Models
{
    public class Reihe
    {
        public int Nummer { get; set; }
        public List<Platz> Plaetze { get; set; }

        public List<Platz> erhalteFreiePlaetze(Reihe reihe)
        {
            //ToDo
            return null;
        }
    }
}