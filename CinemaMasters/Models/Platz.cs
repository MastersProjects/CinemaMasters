//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CinemaMasters.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Platz
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Platz()
        {
            this.ReservierungHasPlatz = new HashSet<ReservierungHasPlatz>();
        }
    
        public int Id { get; set; }
        public int ReiheId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservierungHasPlatz> ReservierungHasPlatz { get; set; }
        public virtual Reihe Reihe { get; set; }
    }
}
