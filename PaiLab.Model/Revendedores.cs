using System.Collections.Generic;

namespace   PaiLab.Model
{
    public class Revendedores
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public int VentasRealizadas { get; set; }

        // Nuevas propiedades para progresión:
        public int Nivel { get; set; }
        public int Experiencia { get; set; }
        public List<Misiones> MisionesActivas { get; set; }
        public List<Beneficios> BeneficiosEncontrados { get; set; }

        // Constructor
        public Revendedores()
        {
            Nivel = 0;
            Experiencia = 0;
            MisionesActivas = new List<Misiones>();
            BeneficiosEncontrados = new List<Beneficios>();
        }

    }
}
