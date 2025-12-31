using System;
using System.Threading.Tasks;
using Bamboo.Admin.Domain.Shared;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.FeatureManagement;

public class TenantFeatureSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IFeatureManager _featureManager;
    private Guid? TenantId;
    public TenantFeatureSeedContributor(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {

    }
    public async Task SeedDataAsync(DataSeedContext context)
    {
        if (context.TenantId == null)
            return;
        TenantId = context.TenantId;


        // ===== BUSINESS =====
        await Set(AppFeatures.Business.Sale, true);
        await Set(AppFeatures.Business.Pos, true);
        await Set(AppFeatures.Business.Stock, true);
        await Set(AppFeatures.Business.Mrp, true);
        await Set(AppFeatures.Business.CrmLead, true);
        await Set(AppFeatures.Business.AnalyticAccounting, false);
        await Set(AppFeatures.Business.RecurringRevenue, false);
        await Set(AppFeatures.Business.PosPreset, false);

        // ===== UI =====
        await Set(AppFeatures.UI.SaleWarning, true);
        await Set(AppFeatures.UI.PurchaseWarning, true);
        await Set(AppFeatures.UI.StockWarning, true);

        // ===== SECURITY (OFF by default) =====
        await Set(AppFeatures.Securities.ExportData, false);
        await Set(AppFeatures.Securities.PartnerCrossTenant, false);
        await Set(AppFeatures.Securities.ControllerExpose, false);

    }

    private async Task Set(string featureName, bool value)
    {
        await _featureManager.SetForTenantAsync(
            (Guid)TenantId,
            name: featureName,
            value: value.ToString().ToLowerInvariant()
        );
    }
}
