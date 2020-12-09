using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Bamboo.Stock.EntityFrameworkCore
{
    public class StockModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public StockModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}