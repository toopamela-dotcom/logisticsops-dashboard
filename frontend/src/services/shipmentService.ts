import type { Shipment } from '../types/shipment';

export async function getShipments(): Promise<Shipment[]> {
  const response = await fetch('/api/shipments');
  if (!response.ok) {
    throw new Error(`Failed to load shipments (HTTP ${response.status})`);
  }
  return response.json();
}