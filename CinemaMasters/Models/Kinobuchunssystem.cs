using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaMasters.Models
{
    public class Kinobuchunssystem
    {
        public List<Vorstellung> Vorstellungen { get; set; }
        public List<Kinobesucher> Kunden { get; set; }

        public Vorstellung findeVorstellung(DateTime zeit, Film film)
        {
            //ToDo
            return null;
        }

        public void reservierenPlatz(Vorstellung vorstellung, Platz platz)
        {
            //ToDo
        }


        public void stornierePlatz(Vorstellung vorstellung, Platz platz)
        {
            //ToDo
        }
    }
}