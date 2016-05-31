using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaMasters.Models
{
    public class Platz
    {
        public int Platznummer { get; set; }
        public bool Reserviert { get; set; }

        public void reservieren(Platz platz)
        {
            //ToDo
        }

        public void loeschen(Platz platz)
        {
            //ToDo
        }

        public bool erhalteStatus(Platz platz)
        {
            //ToDo
            return false;
        }
    }
}