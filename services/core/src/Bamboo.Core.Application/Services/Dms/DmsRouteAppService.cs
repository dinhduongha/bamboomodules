using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IDmsRouteAppService : IGenericAppService<DmsRoute>
    {
        Task StartRouteAsync(Guid routeId);
        Task CompleteRouteAsync(Guid routeId);
        Task AssignVehicleAsync(Guid routeId, Guid vehicleId);
        Task OptimizeRouteAsync(Guid routeId); // Tích hợp route optimization
    }
}

namespace Bamboo.Core.Application.Services
{
    [Module("Dms", Category = "SupplyChain", Depends = new[] { "stock", "sale", "fleet" })]
    public class DmsRouteAppService : GenericAppService<DmsRoute>, IDmsRouteAppService
    {
        public DmsRouteAppService(
            IRepository<DmsRoute, Guid> repository,
            ICurrentTenant currentTenant,
            IDistributedCache cache,
            IDomainParser domainParser,
            IModelTypeRegistry modelTypeRegistry)
            : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
        }

        public async Task StartRouteAsync(Guid routeId)
        {
            var route = await Repository.GetAsync(routeId);
            route.Status = "in_progress";
            await Repository.UpdateAsync(route);
        }

        public async Task CompleteRouteAsync(Guid routeId)
        {
            var route = await Repository.GetAsync(routeId);
            route.Status = "completed";
            await Repository.UpdateAsync(route);
        }

        public async Task AssignVehicleAsync(Guid routeId, Guid vehicleId)
        {
            var route = await Repository.GetAsync(routeId);
            route.VehicleId = vehicleId;
            await Repository.UpdateAsync(route);
        }

        public async Task OptimizeRouteAsync(Guid routeId)
        {
            var route = await Repository.GetAsync(routeId);
            // Logic tối ưu lộ trình (có thể gọi external service như OR-Tools)
            route.TotalDistanceKm = CalculateOptimizedDistance(route); // placeholder
            await Repository.UpdateAsync(route);
        }

        private decimal CalculateOptimizedDistance(DmsRoute route)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Tự động tạo lộ trình động cho ngày cụ thể từ template phù hợp.
        /// - Tìm template khớp với ngày (DayOfWeek, Frequency).
        /// - Copy template lines sang route mới.
        /// - Thêm outlet động (đơn mới, tồn thấp, key account).
        /// - Sắp xếp lại sequence theo khoảng cách tối ưu.
        /// </summary>
        /// <param name="date">Ngày cần tạo route (thường là DateTime.Today)</param>
        /// <param name="userId">NVBH (ResUser Id)</param>
        /// <returns>Id của DmsRoute mới tạo</returns>
        // public async Task<Guid> GenerateDailyRouteFromTemplateAsync(DateTime date, Guid userId)
        // {
        //     // 1. Lấy thông tin user (để biết kho/xe khởi đầu)
        //     var user = await _userRepository.GetAsync(userId);
        //     var startLocationId = user.ProvisionLocationId ?? user.DefaultSalesmanLocationId;
        //     if (startLocationId == null)
        //     {
        //         throw new UserFriendlyException("User không có vị trí khởi đầu (kho hoặc xe).");
        //     }

        //     var dayOfWeek = (int)date.DayOfWeek; // 0=Sunday, 1=Monday, ..., 6=Saturday
        //     var weekOfMonth = (date.Day - 1) / 7 + 1; // Tuần trong tháng (1-5)

        //     // 2. Tìm template phù hợp với ngày hôm nay
        //     var templateQuery = await _routeTemplateRepository.GetQueryableAsync();
        //     var template = templateQuery
        //         .Where(t => t.IsActive)
        //         .Where(t => t.Frequency == "weekly" && t.DayOfWeek == dayOfWeek ||
        //                     t.Frequency == "biweekly" && t.DayOfWeek == dayOfWeek && (weekOfMonth % 2 == 1) ||
        //                     t.Frequency == "monthly" && t.WeekOfMonth == weekOfMonth)
        //         .FirstOrDefault();

        //     if (template == null)
        //     {
        //         throw new UserFriendlyException($"Không tìm thấy template lộ trình cho ngày {date:dd/MM/yyyy}.");
        //     }

        //     // 3. Tạo DmsRoute mới (daily route)
        //     var dailyRoute = new DmsRoute
        //     {
        //         TenantId = template.TenantId,
        //         OrganizationUnitId = template.OrganizationUnitId,
        //         RouteCode = $"Route-{date:yyyyMMdd}-{userId.ToString().Substring(0, 8)}",
        //         PlannedDate = date,
        //         Status = "planned",
        //         VehicleId = user.CurrentVehicleId,
        //         PlannedByUserId = userId,
        //         RouteTemplateId = template.Id,
        //         IsDynamic = true, // Đánh dấu là route động
        //         Date = date
        //     };

        //     await _routeRepository.InsertAsync(dailyRoute);
        //     await _unitOfWorkManager.Current.SaveChangesAsync(); // Lưu để có Id

        //     // 4. Copy các line từ template sang route mới
        //     var templateLines = await _routeTemplateLineRepository.GetListAsync(l => l.TemplateId == template.Id);
        //     var dailyLines = new List<DmsRouteLine>();

        //     foreach (var tl in templateLines.OrderBy(l => l.Sequence))
        //     {
        //         var dailyLine = new DmsRouteLine
        //         {
        //             TenantId = tl.TenantId,
        //             OrganizationUnitId = tl.OrganizationUnitId,
        //             RouteId = dailyRoute.Id,
        //             StockPickingId = null, // Sẽ cập nhật sau nếu có picking
        //             Sequence = tl.Sequence,
        //             EstimatedArrivalTime = null, // Sẽ tính lại realtime
        //             ResPartnerId = tl.ResPartnerId // Copy outlet
        //         };
        //         dailyLines.Add(dailyLine);
        //     }

        //     // 5. Thêm outlet động (dynamic outlets)
        //     // 5.1: Outlet có đơn hàng mới hôm nay (EB2BOrder)
        //     var newOrders = await _eb2bOrderRepository.GetListAsync(o => o.Timestamp.Date == date.Date && o.OrderStatus == "pending");
        //     var newOutletsFromOrders = newOrders.Select(o => o.ResPartnerId).Distinct().ToList();

        //     // 5.2: Outlet có tồn kho thấp (VMI đề xuất)
        //     var vmiProposals = await _vmiProposalRepository.GetListAsync(p => p.ApprovalStatus == "approved" && p.ProposedQty > 0);
        //     var lowStockOutlets = vmiProposals.Select(p => p.ResPartnerId).Distinct().ToList();

        //     // 5.3: Key account cần ưu tiên (nếu chưa có trong template)
        //     var keyAccounts = await _resPartnerRepository.GetListAsync(p => p.IsKeyAccount && !newOutletsFromOrders.Contains(p.Id) && !lowStockOutlets.Contains(p.Id));

        //     // Kết hợp tất cả outlet động cần thêm
        //     var dynamicOutlets = newOutletsFromOrders
        //         .Union(lowStockOutlets)
        //         .Union(keyAccounts.Select(k => k.Id))
        //         .Distinct()
        //         .ToList();

        //     // Thêm vào route nếu chưa có
        //     int nextSequence = templateLines.Any() ? templateLines.Max(l => l.Sequence) + 1 : 1;
        //     foreach (var outletId in dynamicOutlets)
        //     {
        //         if (!dailyLines.Any(l => l.ResPartnerId == outletId))
        //         {
        //             dailyLines.Add(new DmsRouteLine
        //             {
        //                 RouteId = dailyRoute.Id,
        //                 ResPartnerId = outletId,
        //                 Sequence = nextSequence++,
        //                 EstimatedArrivalTime = null
        //             });
        //         }
        //     }

        //     // 6. Sắp xếp lại sequence theo khoảng cách tối ưu (từ vị trí khởi đầu)
        //     var optimizedOrder = await OptimizeRouteOrderAsync(startLocationId.Value, dailyLines.Select(l => l.ResPartnerId).ToList());

        //     // Áp dụng thứ tự mới
        //     for (int i = 0; i < optimizedOrder.Count; i++)
        //     {
        //         var line = dailyLines.First(l => l.ResPartnerId == optimizedOrder[i]);
        //         line.Sequence = i + 1;
        //     }

        //     // 7. Lưu tất cả line mới
        //     await _routeLineRepository.InsertManyAsync(dailyLines);

        //     // 8. Cập nhật route với thông tin tổng hợp
        //     dailyRoute.TotalDistanceKm = await CalculateTotalDistanceAsync(dailyLines);
        //     dailyRoute.EstimatedTimeHours = await CalculateTotalTimeAsync(dailyLines);
        //     await _routeRepository.UpdateAsync(dailyRoute);

        //     return dailyRoute.Id;
        // }

        // // Helper: Tối ưu thứ tự outlet theo khoảng cách (có thể dùng Google Maps API hoặc OR-Tools)
        // private async Task<List<Guid>> OptimizeRouteOrderAsync(Guid startLocationId, List<Guid> outletIds)
        // {
        //     // Placeholder: Lấy tọa độ start + tất cả outlet
        //     // Gọi Google Distance Matrix API hoặc algorithm TSP (Traveling Salesman Problem)
        //     // Trả về list outletIds theo thứ tự tối ưu

        //     // Ví dụ đơn giản (chỉ sắp xếp theo latitude giảm dần)
        //     var locations = await GetLocationsWithGeoAsync(outletIds);
        //     var startGeo = await GetLocationGeoAsync(startLocationId);

        //     return locations
        //         .OrderBy(l => CalculateDistance(startGeo, l.Geo))
        //         .Select(l => l.Id)
        //         .ToList();
        // }

        // Các helper khác (CalculateTotalDistanceAsync, CalculateTotalTimeAsync, GetLocationsWithGeoAsync...)
        // Có thể implement sau khi có API key hoặc algorithm cụ thể
    }
}