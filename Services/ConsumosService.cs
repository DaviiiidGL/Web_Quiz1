using WEB_Quiz1.Interfaces;
using WEB_Quiz1.Models;
using WEB_Quiz1.Services;

namespace WEB_Quiz1.Services;

public class ConsumosService : IConsumosService
{
    private static List<Consumos> _consumos = new List<Consumos>
    {
        new Consumos{id = Guid.NewGuid(), nombreUsuario = "Manuel Mejia", metrosCubicos = 3, tarifa = 10000, total=30000, isActive = true},
        new Consumos{id = Guid.NewGuid(), nombreUsuario = "Profe ponme 5", metrosCubicos = 4, tarifa = 15000, total=60000},
    };

    // Obtener todos
    public List<Consumos> GetAll() => _consumos.Where(c => c.isActive).ToList();

    // Obtener por id
    public Consumos getById(Guid id) => _consumos.FirstOrDefault(c => c.id == id);

    // Crear consumo
    public Consumos Create(Consumos newConsumo)
    {
        
        newConsumo.id = Guid.NewGuid();
        newConsumo.total = newConsumo.tarifa * newConsumo.metrosCubicos;
        _consumos.Add(newConsumo);
        return newConsumo;
    }

    // Update
    public bool Update(Guid id, Consumos consumoEdited)
    {
        var ConsumoExiste = getById(id);
        if (ConsumoExiste == null) return false;
        
        ConsumoExiste.nombreUsuario = consumoEdited.nombreUsuario;
        ConsumoExiste.metrosCubicos = consumoEdited.metrosCubicos;
        ConsumoExiste.tarifa = consumoEdited.tarifa;
        ConsumoExiste.total = consumoEdited.metrosCubicos * consumoEdited.tarifa;
        return true;
    }
    
    // Soft Delete
    public bool ChangeStatus(Guid id)
    {
        var existe = getById(id);
        if (existe == null) return false;

        existe.isActive = existe.isActive ? false : true;

        return true;
    }
    
    // Obtener total
    public double getTotal(Guid id)
    {
        var Consumo = getById(id);

        if (Consumo == null) return 0;
        
        return Consumo.total;
    }
}