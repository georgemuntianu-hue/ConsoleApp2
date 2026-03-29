using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GestiunePieseAuto;

namespace StocareDate
{
    public class AdministrarePieseFisierText
    {
        private string numeFisier;

        public AdministrarePieseFisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
        }

        public void AdaugaPiesa(PiesaAuto piesa)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine($"{piesa.Nume};{piesa.CodPiesa};{piesa.Pret};{piesa.Locatie};{piesa.EsteDisponibilOnline}");
            }
        }

        public List<PiesaAuto> GetPiese()
        {
            List<PiesaAuto> lista = new List<PiesaAuto>();

            if (!File.Exists(numeFisier))
                return lista;

            string[] linii = File.ReadAllLines(numeFisier);

            foreach (string linie in linii)
            {
                string[] date = linie.Split(';');

                PiesaAuto piesa = new PiesaAuto(
                    date[0],
                    date[1],
                    double.Parse(date[2]),
                    date[3],
                    bool.Parse(date[4])
                );

                lista.Add(piesa);
            }

            return lista;
        }

        public List<PiesaAuto> CautaPiesa(string termen)
        {
            List<PiesaAuto> lista = GetPiese();

            return lista.Where(p =>
                p.Nume.ToLower().Contains(termen.ToLower()) ||
                p.CodPiesa.ToLower() == termen.ToLower()
            ).ToList();
        }

        public List<PiesaAuto> FiltreazaDupaPret(double pretMaxim)
        {
            List<PiesaAuto> lista = GetPiese();

            return lista.Where(p => p.Pret <= pretMaxim).ToList();
        }

        public void ModificaPret(string cod, double pretNou)
        {
            List<PiesaAuto> lista = GetPiese();

            foreach (var piesa in lista)
            {
                if (piesa.CodPiesa == cod)
                {
                    piesa.Pret = pretNou;
                }
            }

            using (StreamWriter sw = new StreamWriter(numeFisier, false))
            {
                foreach (var piesa in lista)
                {
                    sw.WriteLine($"{piesa.Nume};{piesa.CodPiesa};{piesa.Pret};{piesa.Locatie};{piesa.EsteDisponibilOnline}");
                }
            }
        }
    }
}