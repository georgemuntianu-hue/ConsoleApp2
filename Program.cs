using System;
using System.Collections.Generic;
using GestiunePieseAuto;
using StocareDate;

namespace GestiunePieseAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            AdministrarePieseFisierText admin =
                new AdministrarePieseFisierText("piese.txt");

            bool continua = true;

            while (continua)
            {
                Console.WriteLine("\n--- MENU GESTIUNE PIESE AUTO ---");
                Console.WriteLine("1. Adauga Piesa");
                Console.WriteLine("2. Afiseaza Toate Piesele");
                Console.WriteLine("3. Cauta dupa Nume/Cod");
                Console.WriteLine("4. Filtrare dupa Pret Maxim");
                Console.WriteLine("5. Modifica Pretul unei Piese");
                Console.WriteLine("0. Iesire");
                Console.Write("Alege optiunea: ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Console.Write("Nume piesa: ");
                        string nume = Console.ReadLine();

                        Console.Write("Cod piesa: ");
                        string cod = Console.ReadLine();

                        Console.Write("Pret: ");
                        double pret = double.Parse(Console.ReadLine());

                        Console.Write("Locatie (Oras): ");
                        string loc = Console.ReadLine();

                        Console.Write("Este disponibila online? (da/nu): ");
                        bool online = Console.ReadLine().ToLower() == "da";

                        PiesaAuto pusaNoua = new PiesaAuto(nume, cod, pret, loc, online);

                        admin.AdaugaPiesa(pusaNoua);

                        Console.WriteLine("Piesa a fost salvata!");
                        break;

                    case "2":
                        AfiseazaLista(admin.GetPiese());
                        break;

                    case "3":
                        Console.Write("Introdu numele sau codul: ");
                        string termen = Console.ReadLine();

                        AfiseazaLista(admin.CautaPiesa(termen));
                        break;

                    case "4":
                        Console.Write("Introdu pretul maxim: ");
                        double pMax = double.Parse(Console.ReadLine());

                        AfiseazaLista(admin.FiltreazaDupaPret(pMax));
                        break;

                    case "5":
                        Console.Write("Introdu codul piesei: ");
                        string codMod = Console.ReadLine();

                        Console.Write("Introdu pretul nou: ");
                        double pretNou = double.Parse(Console.ReadLine());

                        admin.ModificaPret(codMod, pretNou);

                        Console.WriteLine("Pret modificat!");
                        break;

                    case "0":
                        continua = false;
                        break;
                }
            }
        }

        static void AfiseazaLista(List<PiesaAuto> lista)
        {
            if (lista.Count == 0)
                Console.WriteLine("Nu s-au gasit rezultate.");
            else
                lista.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
