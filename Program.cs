using System;
using System.Collections.Generic;
using GestiunePieseAuto;

namespace GestiunePieseAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            MagazinAuto magazin = new MagazinAuto();
            bool continua = true;

            while (continua)
            {
                Console.WriteLine("\n--- MENU GESTIUNE PIESE AUTO ---");
                Console.WriteLine("1. Adauga Piesa (Citire date)");
                Console.WriteLine("2. Afiseaza Toate Piesele");
                Console.WriteLine("3. Cauta dupa Nume/Cod");
                Console.WriteLine("4. Filtrare dupa Pret Maxim");
                Console.WriteLine("0. Iesire");
                Console.Write("Alege optiunea: ");

                string optiune = Console.ReadLine();

                switch (optiune)
                {
                    case "1":
                        Console.Write("Nume piesa: "); string nume = Console.ReadLine();
                        Console.Write("Cod piesa: "); string cod = Console.ReadLine();
                        Console.Write("Pret: "); double pret = double.Parse(Console.ReadLine());
                        Console.Write("Locatie (Oras): "); string loc = Console.ReadLine();
                        Console.Write("Este disponibila online? (da/nu): ");
                        bool online = Console.ReadLine().ToLower() == "da";

                        PiesaAuto pusaNoua = new PiesaAuto(nume, cod, pret, loc, online);
                        magazin.AdaugaPiesa(pusaNoua);

                        Console.WriteLine("Piesa a fost salvata!");
                        break;

                    case "2":
                        AfiseazaLista(magazin.GetToatePiesele());
                        break;

                    case "3":
                        Console.Write("Introdu numele sau codul: ");
                        string termen = Console.ReadLine();
                        AfiseazaLista(magazin.CautaPiesa(termen));
                        break;

                    case "4":
                        Console.Write("Introdu pretul maxim: ");
                        double pMax = double.Parse(Console.ReadLine());
                        AfiseazaLista(magazin.FiltreazaDupaPret(pMax));
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
