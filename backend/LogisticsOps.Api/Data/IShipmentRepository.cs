using LogisticsOps.Api.Models;

namespace LogisticsOps.Api.Data;

public interface IShipmentRepository
{
    Task<IReadOnlyList<Shipment>> GetAllAsync();
    Task<Shipment?> GetByIdAsync(int id);
}