using System.Collections.Generic;

public class MagazinAuto
{
    // Listă care stochează toate obiectele de tip PiesaAuto
    private List<PiesaAuto> inventar;

    // Metodă pentru adăugarea unei piese noi în stoc
    public void AdaugaPiesa(PiesaAuto piesa) { }

    // Metodă pentru căutare după Nume sau Cod
    public List<PiesaAuto> CautaPiesa(string termenCautare) { return null; }

    // Metodă pentru filtrare după preț maxim
    public List<PiesaAuto> FiltreazaDupaPret(double pretMaxim) { return null; }

    // Metodă pentru filtrare după locație (Fizic/Online)
    public List<PiesaAuto> FiltreazaDupaLocatie(string locatie) { return null; }
}