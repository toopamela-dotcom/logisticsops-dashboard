import { useEffect, useState } from 'react';
import { ShipmentTable } from '../components/ShipmentTable';
import { getShipments } from '../services/shipmentService';
import type { Shipment } from '../types/shipment';

export function DashboardPage() {
  const [shipments, setShipments] = useState<Shipment[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    getShipments()
      .then(setShipments)
      .catch((e: Error) => setError(e.message))
      .finally(() => setLoading(false));
  }, []);

  const delayedCount = shipments.filter((s) => s.isDelayed).length;

  return (
    <main>
      <h1>LogisticsOps Dashboard</h1>
      {loading && <p>Loading shipments…</p>}
      {error && <p role="alert">Error: {error}</p>}
      {!loading && !error && (
        <>
          <p>
            {shipments.length} shipments, <strong>{delayedCount} delayed</strong>
          </p>
          <ShipmentTable shipments={shipments} />
        </>
      )}
    </main>
  );
}