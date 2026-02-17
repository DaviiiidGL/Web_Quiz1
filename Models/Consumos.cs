using System.ComponentModel.DataAnnotations;

namespace WEB_Quiz1.Models;

public class Consumos
{
    public Guid id { get; set; }
    
    public string nombreUsuario { get; set; }
    
    public double metrosCubicos { get; set; }
    public double tarifa { get; set; }
    public double total { get; set; }
    public bool isActive = true;
}