using System;
using System.Diagnostics;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // KlasseA
            Data.Faction klasseA1 = new Data.Faction();
            klasseA1.Name = "Artikel 1";
            klasseA1.EditDate = DateTime.Today;
            Int64 klasseA1Id = klasseA1.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA1Id);
        }
        public static void DemoACreateKurz()
        {
            Data.Faction klasseA2 = new Data.Faction { Name = "Artikel 2", BooleanAttribut = true, EditDate = DateTime.Today };
            Int64 klasseA2Id = klasseA2.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA2Id);
        }

        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Faction klasseA in Data.Faction.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.KlasseAId + " Name:" + klasseA.Name);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // KlasseA ändert Attribute
            Data.Faction klasseA1 = Data.Faction.LesenID(1);
            klasseA1.Name = "Artikel 1 nach Update";
            klasseA1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.Faction.LesenID(2).Loeschen();
            Debug.Print("Artikel mit Id 2 gelöscht");
        }
        #endregion
    }
}
