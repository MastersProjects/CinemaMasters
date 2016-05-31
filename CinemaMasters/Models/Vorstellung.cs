using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaMasters.Models
{
    public class Vorstellung
    {
        public DateTime Zeit { get; set; }
        public Film Film { get; set; }

        public void verwalten()
        {
            //ToDo
        }

        public void reservieren(Kinosaal kinosaal)
        {
            //ToDo
        }
    }
}