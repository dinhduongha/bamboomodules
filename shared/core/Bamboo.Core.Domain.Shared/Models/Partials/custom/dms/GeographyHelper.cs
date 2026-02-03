using System.Collections.Generic;
using System.Linq;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;

namespace Bamboo.Core.Helpers;

public static class GeographyHelper
{
    private static readonly GeometryFactory GeometryFactory = new GeometryFactory(new PrecisionModel(), 4326);

    /// <summary>
    /// Tạo Point từ longitude và latitude (SRID = 4326)
    /// </summary>
    public static Point CreatePoint(double longitude, double latitude)
    {
        return GeometryFactory.CreatePoint(new Coordinate(longitude, latitude));
    }

    /// <summary>
    /// Tạo Point từ string WKT (Well-Known Text), ví dụ: "POINT(105.8542 21.0285)"
    /// </summary>
    public static Point FromWkt(string wkt)
    {
        var reader = new WKTReader(GeometryFactory);
        return (Point)reader.Read(wkt);
    }

    /// <summary>
    /// Tính khoảng cách giữa 2 điểm (đơn vị: mét)
    /// </summary>
    public static double DistanceMeters(Point point1, Point point2)
    {
        return point1.Distance(point2) * 111320; // approximate meters (có thể dùng ST_Distance trong DB)
    }

    /// <summary>
    /// Tạo Polygon từ danh sách tọa độ (clockwise order)
    /// </summary>
    public static Polygon CreatePolygon(List<(double lng, double lat)> coordinates)
    {
        var coords = coordinates.Select(c => new Coordinate(c.lng, c.lat)).ToArray();
        return GeometryFactory.CreatePolygon(coords);
    }

    /// <summary>
    /// Chuyển Point sang Geography để dùng với PostGIS (nếu cần)
    /// </summary>
    public static NetTopologySuite.Geometries.Geometry ToGeography(this Point point)
    {
        return point; // NetTopologySuite tự handle khi mapping sang geography
    }
}