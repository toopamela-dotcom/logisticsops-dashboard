using LogisticsOps.Api.Models;

namespace LogisticsOps.Api.Data;

public class InMemoryShipmentRepository : IShipmentRepository
{
    private readonly List<Shipment> _shipments =
        SeedData.Create(DateOnly.FromDateTime(DateTime.Today));

    public Task<IReadOnlyList<Shipment>> GetAllAsync() =>
        Task.FromResult<IReadOnlyList<Shipment>>(_shipments);

    public Task<Shipment?> GetByIdAsync(int id) =>
        Task.FromResult(_shipments.FirstOrDefault(s => s.ShipmentId == id));
}
