using System;
using System.Threading.Tasks;

namespace Bamboo.Core.Application.Services
{
    // 1. ResUserAppService (partial)
    public partial class ResUsersAppService
    {
        // Các method custom cho DMS (nếu cần thêm logic)
        // Ví dụ:
        public async Task AssignSalesmanLocationAsync(Guid userId, Guid locationId)
        {
            var user = await Repository.GetAsync(userId);
            user.DefaultSalesmanLocationId = locationId;
            await Repository.UpdateAsync(user);
        }
    }

    // 2. ProductAppService (partial)
    public partial class ProductAppService
    {
        // Custom nếu cần, ví dụ tính volume/weight
    }

    // 3. StockLocationAppService (partial)
    public partial class StockLocationAppService
    {
        public async Task AssignVehicleToLocationAsync(Guid locationId, Guid vehicleId)
        {
            var location = await Repository.GetAsync(locationId);
            location.VehicleId = vehicleId;
            location.LocationType = "vehicle";
            await Repository.UpdateAsync(location);
        }
    }

    // 4. StockPickingAppService (partial)
    public partial class StockPickingAppService
    {
        public async Task ValidatePickingAsync(Guid pickingId)
        {
            var picking = await Repository.GetAsync(pickingId);
            picking.DeliveryStatus = "delivered";
            await Repository.UpdateAsync(picking);
        }
    }

    // 5. StockMoveAppService (partial)
    public partial class StockMoveAppService
    {
        // Custom move logic nếu cần
    }

    // 6. SaleOrderAppService (partial)
    public partial class SaleOrderAppService
    {
        // Custom cho delivery priority nếu cần
    }

    // 7. ResPartnerAppService (partial)
    public partial class ResPartnerAppService
    {
        public async Task UpdateGeofenceAsync(Guid partnerId, int radius)
        {
            var partner = await Repository.GetAsync(partnerId);
            partner.GeofenceRadiusMeters = radius;
            await Repository.UpdateAsync(partner);
        }
    }

    // 8. FleetVehicleAppService (partial)
    public partial class FleetVehicleAppService
    {
        public async Task UpdateGpsDataAsync(Guid vehicleId, decimal lat, decimal lng)
        {
            var vehicle = await Repository.GetAsync(vehicleId);
            vehicle.LastGpsLatitude = lat;
            vehicle.LastGpsLongitude = lng;
            vehicle.LastGpsTime = DateTime.UtcNow;
            await Repository.UpdateAsync(vehicle);
        }
    }
}