import type { Shipment } from '../types/shipment';

interface Props {
  shipments: Shipment[];
}

const statusLabel: Record<Shipment['status'], string> = {
  Pending: 'Pending',
  InTransit: 'In transit',
  Delivered: 'Delivered',
};

export function ShipmentTable({ shipments }: Props) {
  return (
    <table className="shipment-table">
      <caption>Shipments</caption>
      <thead>
        <tr>
          <th scope="col">ID</th>
          <th scope="col">Tracking</th>
          <th scope="col">Carrier</th>
          <th scope="col">Route</th>
          <th scope="col">Est. delivery</th>
          <th scope="col">Status</th>
          <th scope="col">Cost</th>
        </tr>
      </thead>
      <tbody>
        {shipments.map((s) => (
          <tr key={s.shipmentId} className={s.isDelayed ? 'row-delayed' : undefined}>
            <td>{s.shipmentId}</td>
            <td>{s.trackingNumber ?? <em>Missing</em>}</td>
            <td>{s.carrier}</td>
            <td>{s.origin} → {s.destination}</td>
            <td>{s.estimatedDeliveryDate}</td>
            <td>
              {statusLabel[s.status]}
              {s.isDelayed && <span className="badge badge-delayed">Delayed</span>}
            </td>
            <td>${s.shippingCost.toFixed(2)}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}