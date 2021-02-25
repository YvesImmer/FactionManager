using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace M120Projekt.Data
{
    public class Faction
    {
        #region Datenbankschicht
        [Key]
        public Int64 FactionId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public DateTime EditDate { get; set; }
        [Required]
        public Boolean Aktiv { get; set; }
        [Required]
        public Byte Relationship { get; set; }
        #endregion
        #region Applikationsschicht
        public Faction() { }

        public static List<Faction> LesenAlle()
        {
            using (var db = new Context())
            {
                return (from record in db.Faction select record).ToList();
            }
        }
        public static Faction LesenID(Int64 FactionId)
        {
            using (var db = new Context())
            {
                return (from record in db.Faction where record.FactionId == FactionId select record).FirstOrDefault();
            }
        }
        public static List<Faction> LesenAttributGleich(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Faction where record.Name == suchbegriff select record).ToList();
            }
        }
        public static List<Faction> LesenAttributWie(String suchbegriff)
        {
            using (var db = new Context())
            {
                return (from record in db.Faction where record.Name.Contains(suchbegriff) select record).ToList();
            }
        }
        public Int64 Erstellen()
        {
            if (this.Name == null || this.Name == "") this.Name = "leer";
            if (this.EditDate == null) this.EditDate = DateTime.MinValue;
            using (var db = new Context())
            {
                db.Faction.Add(this);
                db.SaveChanges();
                return this.FactionId;
            }
        }
        public Int64 Aktualisieren()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return this.FactionId;
            }
        }
        public void Loeschen()
        {
            using (var db = new Context())
            {
                db.Entry(this).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        public override string ToString()
        {
            return FactionId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
