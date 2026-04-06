using System;
using System.Collections.Generic;
using System.Linq;
using GestiunePieseAuto;

namespace GestiunePieseAuto
{
    // --- CLASA 1: Definirea obiectului ---
    public class PiesaAuto
    {
        public string Nume { get; set; }
        public string CodPiesa { get; set; }
        public double Pret { get; set; }
        public string Locatie { get; set; }
        public bool EsteDisponibilOnline { get; set; }

        // Constructor completat pentru a salva datele
        public PiesaAuto(string nume, string cod, double pret, string locatie, bool online)
        {
            Nume = nume;
            CodPiesa = cod;
            Pret = pret;
            Locatie = locatie;
            EsteDisponibilOnline = online;
        }

        // Metodă pentru afișarea detaliilor (Suprascrisă)
        public override string ToString()
        {
            string tip = EsteDisponibilOnline ? "Online" : "Magazin Fizic";
            return $"Cod: {CodPiesa} | {Nume} | Pret: {Pret} RON | Locatie: {Locatie} ({tip})";
        }
    }

    // --- CLASA 2: Gestiunea listei (Vectorul de obiecte) ---
    public class MagazinAuto
    {
        private List<PiesaAuto> inventar = new List<PiesaAuto>();

        public void AdaugaPiesa(PiesaAuto piesa)
        {
            inventar.Add(piesa);
        }

        public List<PiesaAuto> GetToatePiesele() => inventar;

        public List<PiesaAuto> CautaPiesa(string termenCautare)
        {
            return inventar.Where(p => p.Nume.ToLower().Contains(termenCautare.ToLower()) ||
                                     p.CodPiesa.ToLower() == termenCautare.ToLower()).ToList();
        }

        public List<PiesaAuto> FiltreazaDupaPret(double pretMaxim)
        {
            return inventar.Where(p => p.Pret <= pretMaxim).ToList();
        }

        public List<PiesaAuto> FiltreazaDupaLocatie(string locatie)
        {
            return inventar.Where(p => p.Locatie.ToLower() == locatie.ToLower()).ToList();
        }
    }

    // --- CLASA 3: Punctul de pornire al programului ---
    class Program
    {
        static void Main(string[] args)
@@ -90,9 +33,9 @@ static void Main(string[] args)
                        Console.Write("Este disponibila online? (da/nu): ");
                        bool online = Console.ReadLine().ToLower() == "da";

        // Cream obiectul folosind constructorul si il adaugam in vector
        PiesaAuto pusaNoua = new PiesaAuto(nume, cod, pret, loc, online);
        magazin.AdaugaPiesa(pusaNoua);

                        Console.WriteLine("Piesa a fost salvata!");
                        break;

@@ -119,11 +62,12 @@ static void Main(string[] args)
            }
}

// Metoda auxiliara pentru a nu repeta codul de afisare
static void AfiseazaLista(List<PiesaAuto> lista)
{
    if (lista.Count == 0) Console.WriteLine("Nu s-au gasit rezultate.");
    else lista.ForEach(p => Console.WriteLine(p.ToString()));
    if (lista.Count == 0)
        Console.WriteLine("Nu s-au gasit rezultate.");
    else
        lista.ForEach(p => Console.WriteLine(p.ToString()));
}
    }
}