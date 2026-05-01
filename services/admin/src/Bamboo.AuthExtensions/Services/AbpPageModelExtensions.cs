using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;

public static class AbpPageModelExtensions
{
    public static string GetPagedUrl(this PageModel page, object inputDto)
    {
        var routeValues = new RouteValueDictionary(inputDto);

        // Xóa các key phân trang mặc định của ABP
        routeValues.Remove("CurrentPage");
        routeValues.Remove("SkipCount");
        routeValues.Remove("MaxResultCount"); // Thường giữ nguyên size khi đổi trang

        return page.Url.Page(null, routeValues); // null nghĩa là trang hiện tại
    }
}