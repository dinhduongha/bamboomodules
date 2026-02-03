using System.Collections.Generic;
using System.Threading.Tasks;
using Bamboo.Core.Models;
using Volo.Abp.Domain.Repositories;

public partial class StockLocationAppService
{
    // Method cũ giữ nguyên...

    /// <summary>
    /// Tìm các location (kho/xe) gần nhất với vị trí hiện tại
    /// </summary>
    // public async Task<List<StockLocation>> GetNearbyLocationsAsync(decimal lat, decimal lng, int maxDistanceMeters = 5000)
    // {
    //     var point = GeographyHelper.CreatePoint(lng, lat);

    //     return await IRepository.GetListAsync(
    //         x => EF.Functions.ST_DWithin(x.Geom, point, maxDistanceMeters),
    //         x => x.OrderBy(l => EF.Functions.ST_Distance(l.Geom, point))
    //     );
    // }

    // /// <summary>
    // /// Tìm location theo H3 kRing (nhanh hơn ST_DWithin khi số lượng lớn)
    // /// </summary>
    // public async Task<List<StockLocation>> GetNearbyByH3Async(decimal lat, decimal lng, int ringSize = 5)
    // {
    //     var currentH3 = await _dbContext.Database.SqlQuery<string>(
    //         $"SELECT h3_lat_lng_to_cell({lat}, {lng}, 9)"
    //     ).SingleAsync();

    //     var nearbyH3 = await _dbContext.Database.SqlQuery<string[]>(
    //         $"SELECT h3_kRing({currentH3}, {ringSize})"
    //     ).SingleAsync();

    //     return await Repository.GetListAsync(l => nearbyH3.Contains(l.H3Index));
    // }
}