using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;

namespace Bamboo.Domain.Shared.Extensions // Thay đổi namespace theo dự án của bạn
{
    public static class TranslationExtensions
    {
        /// <summary>
        /// Lấy giá trị ngôn ngữ hiện tại từ Dictionary<string, string> của Odoo
        /// </summary>
        public static string GetTranslatedValue(this Dictionary<string, string>? translations, string fallbackValue = "")
        {
            if (translations == null || translations.Count == 0)
                return fallbackValue;

            // Chuyển đổi format của .NET ("vi-VN") sang chuẩn Odoo ("vi_VN")
            var currentCulture = CultureInfo.CurrentUICulture.Name.Replace("-", "_");
            var currentLang = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName; // "vi", "en"

            // 1. Ưu tiên khớp chính xác (VD: vi_VN)
            if (translations.TryGetValue(currentCulture, out var exactMatch))
                return exactMatch;

            // 2. Khớp theo mã ngôn ngữ 2 chữ cái (Fallback)
            var partialMatch = translations.FirstOrDefault(x => x.Key.StartsWith(currentLang + "_"));
            if (!string.IsNullOrEmpty(partialMatch.Value))
                return partialMatch.Value;

            // 3. Fallback về tiếng Anh mặc định của Odoo
            if (translations.TryGetValue("en_US", out var enMatch))
                return enMatch;

            // 4. Nếu không có gì, lấy đại giá trị đầu tiên trong Dictionary
            return translations.Values.FirstOrDefault() ?? fallbackValue;
        }

        /// <summary>
        /// Dùng cho các trường Sparse hoặc chưa map Dictionary (chuỗi JSONB thô)
        /// </summary>
        public static string GetTranslatedValueFromJson(this string? jsonbString, string fallbackValue = "")
        {
            if (string.IsNullOrWhiteSpace(jsonbString))
                return fallbackValue;

            try
            {
                // Thêm tùy chọn để tránh phân biệt hoa thường nếu cần
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(jsonbString, options);

                return dict.GetTranslatedValue(fallbackValue);
            }
            catch
            {
                // Nếu JSON không hợp lệ, trả về nguyên gốc hoặc fallback
                return fallbackValue;
            }
        }
    }
}
/*
// Khi map Entity sang DTO:
var dto = new ProductDto
{
    Id = entity.Id,
    // Hàm extension sẽ tự kiểm tra Culture hiện tại (do Middleware của Abp tự set) và trả về text đúng
    Name = entity.Name.GetTranslatedValue() 
};
*/