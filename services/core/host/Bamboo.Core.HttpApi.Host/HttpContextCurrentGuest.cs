// FileName: Bamboo.Core.HttpApi.Host/Services/HttpContextCurrentGuest.cs
using System;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Volo.Abp.DependencyInjection;

using Bamboo.Core.Carts;

namespace Bamboo.Core.Web.Services
{
    // Đăng ký với DI là Scoped, mỗi request sẽ có 1 instance
    public class HttpContextCurrentGuest : ICurrentGuest, IScopedDependency
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpContextCurrentGuest(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        // Logic đọc header nằm ở đây, hoàn toàn tách biệt khỏi Domain
        public Guid? CartId
        {
            get
            {
                if (_httpContextAccessor.HttpContext?.Request.Headers
                    .TryGetValue("X-Guest-Cart-Id", out StringValues val) == true)
                {
                    if (Guid.TryParse(val, out Guid guestCartId))
                    {
                        return guestCartId;
                    }
                }
                return null;
            }
        }
    }
}