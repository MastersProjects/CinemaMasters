using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaMasters.Models
{
    public class Film
    {
        public string Titel { get; set; }
        public DateTime Dauer { get; set; }
        public int Altersfreigabe { get; set; }
        public List<string> Darsteller { get; set; }
        public List<string> Regisseure { get; set; }
        public string Sprache { get; set; }

        public void verwalten()
        {
            //ToDo
        }

        public void zuweisen(Vorstellung vorstellung)
        {
            //ToDo
        }
    }
}