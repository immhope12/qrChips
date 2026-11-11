namespace qrChips.Models
{
    public class Asistencia
    {
        public int Id { get; set; }
        public string EmpleadoId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Tipo { get; set; } // "Ingreso" o "Egreso"
    }
}