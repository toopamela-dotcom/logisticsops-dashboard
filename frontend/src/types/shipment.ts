export type ShipmentStatus = 'Pending' | 'InTransit' | 'Delivered';

export interface Shipment {
  shipmentId: number;
  trackingNumber: string | null;
  carrier: string;
  origin: string;
  destination: string;
  shipDate: string;
  estimatedDeliveryDate: string;
  actualDeliveryDate: string | null;
  status: ShipmentStatus;
  shippingCost: number;
  isDelayed: boolean;
}