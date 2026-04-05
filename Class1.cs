public class PiesaAuto
{
    // Atribute / Proprietăți
    public string Nume { get; set; }
    public string CodPiesa { get; set; }
    public double Pret { get; set; }
    public string Locatie { get; set; }
    public bool EsteDisponibilOnline { get; set; }

    // Constructor pentru inițializarea obiectului
    public PiesaAuto(string nume, string cod, double pret, string locatie, bool online) { }

    // Metodă pentru afișarea detaliilor sub formă de text
    public override string ToString() { return string.Empty; }
}