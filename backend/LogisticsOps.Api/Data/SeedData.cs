using LogisticsOps.Api.Models;

namespace LogisticsOps.Api.Data;

public static class SeedData
{
    // Dates are offsets from "today" (negative = in the past), so the
    // sample data always contains delayed shipments no matter when you run it.
    public static List<Shipment> Create(DateOnly today) =>
    [
        S(today,  1, "1Z999AA10000000001", "UPS",   "Atlanta, GA",      "Chicago, IL",       -12, -8, -9,  ShipmentStatus.Delivered, 42.50m),
        S(today,  2, "794600000002",       "FedEx", "Memphis, TN",      "Dallas, TX",        -10, -6, -4,  ShipmentStatus.Delivered, 58.20m),
        S(today,  3, "DHL0000000003",      "DHL",   "Miami, FL",        "New York, NY",       -9, -5, null, ShipmentStatus.InTransit, 71.00m),
        S(today,  4, "9400000000000000004","USPS",  "Atlanta, GA",      "Charlotte, NC",      -3,  1, null, ShipmentStatus.InTransit, 14.75m),
        S(today,  5, "1Z999AA10000000005", "UPS",   "Columbus, OH",     "Nashville, TN",      -7, -3, -3,  ShipmentStatus.Delivered, 33.10m),
        S(today,  6, "794600000006",       "FedEx", "Los Angeles, CA",  "Seattle, WA",        -5,  0, null, ShipmentStatus.InTransit, 64.40m),
        S(today,  7, "DHL0000000007",      "DHL",   "Houston, TX",      "Denver, CO",        -14, -9, -9,  ShipmentStatus.Delivered, 88.90m),
        S(today,  8, null,                 "UPS",   "Atlanta, GA",      "Orlando, FL",        -1,  3, null, ShipmentStatus.Pending,   22.30m),
        S(today,  9, "9400000000000000009","USPS",  "Phoenix, AZ",      "Las Vegas, NV",      -8, -4, -5,  ShipmentStatus.Delivered, 12.60m),
        S(today, 10, "794600000010",       "FedEx", "Chicago, IL",      "Detroit, MI",        -6, -2, null, ShipmentStatus.InTransit, 29.95m),
        S(today, 11, "DHL0000000011",      "DHL",   "Newark, NJ",       "Boston, MA",         -2,  2, null, ShipmentStatus.InTransit, 36.80m),
        S(today, 12, "1Z999AA10000000012", "UPS",   "Savannah, GA",     "Jacksonville, FL",  -11, -7, -5,  ShipmentStatus.Delivered, 27.45m),
        S(today, 13, "794600000013",       "FedEx", "Indianapolis, IN", "Kansas City, MO",     0,  4, null, ShipmentStatus.Pending,   41.00m),
        S(today, 14, null,                 "USPS",  "Minneapolis, MN",  "Milwaukee, WI",      -4,  0, null, ShipmentStatus.InTransit,  9.85m),
        S(today, 15, "1Z999AA10000000015", "UPS",   "Portland, OR",     "San Francisco, CA", -13, -9, -9,  ShipmentStatus.Delivered, 52.75m),
        S(today, 16, "DHL0000000016",      "DHL",   "Dallas, TX",       "Atlanta, GA",        -7, -3, null, ShipmentStatus.InTransit, 95.30m),
        S(today, 17, "794600000017",       "FedEx", "Philadelphia, PA", "Pittsburgh, PA",     -3,  1, null, ShipmentStatus.InTransit, 24.15m),
        S(today, 18, "1Z999AA10000000018", "UPS",   "Charlotte, NC",    "Richmond, VA",       -9, -5, -6,  ShipmentStatus.Delivered, 31.20m),
        S(today, 19, "9400000000000000019","USPS",  "Orlando, FL",      "Tampa, FL",          -2,  1, null, ShipmentStatus.InTransit,  8.40m),
        S(today, 20, "DHL0000000020",      "DHL",   "San Diego, CA",    "Salt Lake City, UT",-10, -6, -3,  ShipmentStatus.Delivered, 79.60m),
    ];

    private static Shipment S(
        DateOnly today, int id, string? tracking, string carrier,
        string origin, string destination,
        int shipOffset, int etaOffset, int? deliveredOffset,
        ShipmentStatus status, decimal cost) => new()
    {
        ShipmentId = id,
        TrackingNumber = tracking,
        Carrier = carrier,
        Origin = origin,
        Destination = destination,
        ShipDate = today.AddDays(shipOffset),
        EstimatedDeliveryDate = today.AddDays(etaOffset),
        ActualDeliveryDate = deliveredOffset is null ? null : today.AddDays(deliveredOffset.Value),
        Status = status,
        ShippingCost = cost
    };
}