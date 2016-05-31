using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaMasters.Models
{
    public class Kinobesucher
    {
        public string Telefonnummer { get; set; }
        public List<Reservierung> reservierungen { get; set; }

        public void reservieren()
        {
            //ToDo
        }
    }
}