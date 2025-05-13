using System.Collections.Generic;
using PaiLab.Model;

public class Misiones
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Dificultad { get; set; }
    public int RecompensaId { get; set; }

    // NUEVO: lista de ID de lugares asociados
    public List<int> LugaresDeReventaId { get; set; } = new List<int>();

}

