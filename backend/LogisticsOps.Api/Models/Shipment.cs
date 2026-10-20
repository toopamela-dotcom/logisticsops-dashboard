namespace LogisticsOps.Api.Models;

public class Shipment
{
    public int ShipmentId { get; set; }
    public string? TrackingNumber { get; set; }
    public required string Carrier { get; set; }
    public required string Origin { get; set; }
    public required string Destination { get; set; }
    public DateOnly ShipDate { get; set; }
    public DateOnly EstimatedDeliveryDate { get; set; }
    public DateOnly? ActualDeliveryDate { get; set; }
    public ShipmentStatus Status { get; set; }
    public decimal ShippingCost { get; set; }

    // A shipment is delayed if it is undelivered and past its estimate.
    public bool IsDelayed(DateOnly today) =>
        Status != ShipmentStatus.Delivered && today > EstimatedDeliveryDate;
}