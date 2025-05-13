namespace PaiLab.Model
{
    public class Beneficios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int TipoBeneficioId { get; set; }
        public int? LugaresDeReventaId { get; set; }
        public int? RevendedoresId { get; set; }

        // Propiedad de navegación
        public TipoBeneficio TipoBeneficio { get; set; }

    }
}
