using WEB_Quiz1.Models;

namespace WEB_Quiz1.Interfaces;

public interface IConsumosService
{
    List<Consumos> GetAll();
    Consumos getById(Guid id);
    Consumos Create(Consumos consumo);
    bool Update(Guid id, Consumos consumo);
    bool ChangeStatus(Guid id);

    double getTotal(Guid id);


}