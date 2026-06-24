using System;
using System.Text;
using System.Collections.Generic;
using System.Text.Json;


namespace Baufflaechenverwaltung
{
    public enum Nutzung
    {
        Gewerbe, Landwirtschaft, Forst, Wohnnutzung, Brachfläche
    }

    public enum Bebaubarkeit
    {
        Ja, Nein, Auflagen
    }

    public enum FlaechenStatus
    {
        Frei, Reserviert, Bebaut
    }

    public enum ProjektStatus
    {
        AntragEingereicht, Genehmigt, Abgelehnt, InBearbeitung, Abgeschlossen
    }

    public class Antragsteller
    {
        public string Name { get; set; } = string.Empty;
        public string Kontaktdaten { get; set; } = string.Empty;
        public string Firma { get; set; } = string.Empty;
    }

    public class Bauflaeche
    {
        public string FlurstueckNummer { get; set; } = string.Empty;
        public double Groesse { get; set; }
        public string Lage { get; set; } = string.Empty;
        public Nutzung AktuelleNutzung { get; set; }
        public Bebaubarkeit Bebaubarkeit { get; set; }
        public string BPlanNummer { get; set; } = string.Empty;
        public decimal Bodenrichtwert { get; set; }
        public string Eigentuemer { get; set; } = string.Empty;
        public FlaechenStatus Status { get; set; } = FlaechenStatus.Frei;

        public void FlaecheReservieren()
        {
            if (Status == FlaechenStatus.Bebaut) {
                return;
            }
            Status = FlaechenStatus.Reserviert;
        }

        public void SaveToJSON(string filePath)
        {
            String json = JsonSerializer.Serialize(this);
            File.WriteAllText(filePath, json);
        }

        public void LoadFromJSON(string filePath)
        {
            String json = File.ReadAllText(filePath);
            Bauflaeche? bf = JsonSerializer.Deserialize<Bauflaeche>(json);
            if (bf == null) {
                Console.WriteLine("Datei nicht gefunden!");
                return;
            }
            FlurstueckNummer = bf.FlurstueckNummer;
            Groesse = bf.Groesse;
            Lage = bf.Lage;
            AktuelleNutzung = bf.AktuelleNutzung;
            Bebaubarkeit = bf.Bebaubarkeit;
            BPlanNummer = bf.BPlanNummer;
            Bodenrichtwert = bf.Bodenrichtwert;
            Eigentuemer = bf.Eigentuemer;
            Status = bf.Status;
        }
    }

    public class Grundstueck
    {
        public string Bezeichnung { get; set; } = string.Empty;
        public List<Bauflaeche> Bauflaechen { get; set; } = new List<Bauflaeche>();

        public void PrintFlaechen()
        {
            Console.WriteLine("Flure | Größe | Lage | Nutzung | Bebaubar | BPlan Nr. | Bodenrichtwert | Eigentuemer | Status");
            Console.WriteLine("–––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––");
            foreach (Bauflaeche f in Bauflaechen) {
                Console.WriteLine($"{f.FlurstueckNummer} | {f.Groesse} | {f.Lage} | {f.AktuelleNutzung} | {f.Bebaubarkeit} | {f.BPlanNummer} | {f.Bodenrichtwert} | {f.Eigentuemer} | {f.Status}");
            }
        }
    }

    public class Bauvorhaben
    {
        public string Titel { get; set; } = string.Empty;
        public Antragsteller Antragsteller { get; set; } = new Antragsteller();
        public string GeplanteNutzung { get; set; } = string.Empty;
        public DateTime Beginn { get; set; }
        public DateTime Fertigstellung { get; set; }
        public ProjektStatus Status { get; set; }
        public List<Bauflaeche> ZugeordneteFlaechen { get; set; } = new List<Bauflaeche>();

        public void StatusAktualisieren(ProjektStatus neuerStatus)
        {
            Status = neuerStatus;
        }

        public void SaveToJSON(string filePath)
        {
            String json = JsonSerializer.Serialize(this);
            File.WriteAllText(filePath, json);
        }

        public void LoadFromJSON(string filePath)
        {
            String json = File.ReadAllText(filePath);
            Bauvorhaben? bv = JsonSerializer.Deserialize<Bauvorhaben>(json);
            if (bv == null) {
                Console.WriteLine("Datei nicht gefunden!");
                return;
            }
            Titel = bv.Titel;
            Antragsteller = bv.Antragsteller;
            GeplanteNutzung = bv.GeplanteNutzung;
            Beginn = bv.Beginn;
            Fertigstellung = bv.Fertigstellung;
            Status = bv.Status;
            ZugeordneteFlaechen = bv.ZugeordneteFlaechen;
        }
    }

    class Program
    {
        public static void SaveVorhabenToTXT(string filePath, List<Bauvorhaben> vorhaben) {
            StringBuilder sb = new();

            foreach (Bauvorhaben v in vorhaben) {
                sb.AppendLine($"––– {v.Titel} –––");
                sb.AppendLine($"Antragsteller:   {v.Antragsteller.Name}, {v.Antragsteller.Kontaktdaten}, {v.Antragsteller.Firma}");
                sb.AppendLine($"Nutzung:         {v.GeplanteNutzung}");
                sb.AppendLine($"Beginn:          {v.Beginn}");
                sb.AppendLine($"Fertigstellung:  {v.Fertigstellung}");
                sb.AppendLine($"Status:          {v.Status}");
                sb.Append($"Flächen: ");
                foreach (Bauflaeche f in v.ZugeordneteFlaechen) {
                    sb.Append($"{f.Lage},");
                }
                sb.AppendLine();
                sb.AppendLine();
            }

            File.WriteAllText(filePath, sb.ToString());
        } 

        static void Main(string[] args)
        {
            Bauvorhaben vorhaben = new();
            Bauflaeche flaeche1 = new();
            vorhaben.ZugeordneteFlaechen.Add(flaeche1);

            if (File.Exists("Bauvorhaben.json")) {
                vorhaben.LoadFromJSON("Bauvorhaben.json");
            } else {
                vorhaben = new Bauvorhaben
                {
                    Titel = "Neubau Wohnanlage",
                    Antragsteller = new Antragsteller { Name = "Erika Musterfrau", Firma = "Bau GmbH" },
                    GeplanteNutzung = "Wohngebäude",
                    Beginn = DateTime.Now.AddMonths(1),
                    Fertigstellung = DateTime.Now.AddYears(1),
                    Status = ProjektStatus.AntragEingereicht
                };
            }

            if (File.Exists("Bauflaeche.json")) {
                flaeche1.LoadFromJSON("Bauflaeche.json");
            } else {
                // Demonstration der Funktionalität
                flaeche1 = new Bauflaeche
                {
                    FlurstueckNummer = "0015 00012 001/002",
                    Groesse = 500.0,
                    Lage = "Leipzig-Nord",
                    AktuelleNutzung = Nutzung.Brachfläche,
                    Bebaubarkeit = Bebaubarkeit.Ja,
                    BPlanNummer = "BP-2022-089 – Wohngebiet Leipzig-Nord",
                    Bodenrichtwert = 500m,
                    Eigentuemer = "Max Mustermann"
                };
            }

            var grundstueck = new Grundstueck { Bezeichnung = "Grundstück Nord" };
            grundstueck.Bauflaechen.Add(flaeche1);

            flaeche1.FlaecheReservieren();
            vorhaben.StatusAktualisieren(ProjektStatus.Genehmigt);

            Console.WriteLine($"Bauvorhaben '{vorhaben.Titel}' Status: {vorhaben.Status}");
            Console.WriteLine($"Fläche {flaeche1.FlurstueckNummer} Status: {flaeche1.Status}");

            grundstueck.PrintFlaechen();

            vorhaben.SaveToJSON("Bauvorhaben.json");
            flaeche1.SaveToJSON("Bauflaeche.json");

            SaveVorhabenToTXT("VorhabenListe.txt", new List<Bauvorhaben> {vorhaben});
        }
    }
}