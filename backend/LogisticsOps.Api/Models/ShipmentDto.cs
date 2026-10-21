namespace LogisticsOps.Api.Models;

public record ShipmentDto(
    int ShipmentId,
    string? TrackingNumber,
    string Carrier,
    string Origin,
    string Destination,
    DateOnly ShipDate,
    DateOnly EstimatedDeliveryDate,
    DateOnly? ActualDeliveryDate,
    ShipmentStatus Status,
    decimal ShippingCost,
    bool IsDelayed)
{
    public static ShipmentDto FromShipment(Shipment s, DateOnly today) => new(
        s.ShipmentId, s.TrackingNumber, s.Carrier, s.Origin, s.Destination,
        s.ShipDate, s.EstimatedDeliveryDate, s.ActualDeliveryDate,
        s.Status, s.ShippingCost, s.IsDelayed(today));
}