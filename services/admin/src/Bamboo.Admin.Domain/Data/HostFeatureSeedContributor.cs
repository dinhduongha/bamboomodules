using System.Threading.Tasks;
using Bamboo.Admin.Domain.Shared;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Features;

public class HostFeatureSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IFeatureManager _featureManager;
    public HostFeatureSeedContributor(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
    }
    public async Task SeedDataAsync(DataSeedContext context)
    {
        // Chỉ chạy cho Host
        if (context.TenantId != null)
            return;

        // ===== CORE SYSTEM =====
        await SetGlobal(AppFeatures.System.MultiCompany, true);
        await SetGlobal(AppFeatures.System.MultiCurrency, true);
        await SetGlobal(AppFeatures.System.Uom, true);
        await SetGlobal(AppFeatures.System.FiscalYear, true);
        await SetGlobal(AppFeatures.System.ProductVariant, true);

        // ===== MAIN ENGINES =====

        await SetGlobal(AppFeatures.System.Engine.AccountingEngine, false);
        await SetGlobal(AppFeatures.System.Engine.AppointmentEngine, false);
        await SetGlobal(AppFeatures.System.Engine.DashboardEngine, false);
        await SetGlobal(AppFeatures.System.Engine.EquityEngine, false);
        await SetGlobal(AppFeatures.System.Engine.ESGEngine, false);
        await SetGlobal(AppFeatures.System.Engine.EventEngine, false);
        await SetGlobal(AppFeatures.System.Engine.FleetEngine, false);
        await SetGlobal(AppFeatures.System.Engine.HelpdeskEngine, false);
        await SetGlobal(AppFeatures.System.Engine.HrEngine, false);
        await SetGlobal(AppFeatures.System.Engine.IoTBarcodeEngine, false);
        await SetGlobal(AppFeatures.System.Engine.LivechatEngine, false);
        await SetGlobal(AppFeatures.System.Engine.LunchEngine, false);
        await SetGlobal(AppFeatures.System.Engine.MaintenanceEngine, false);
        await SetGlobal(AppFeatures.System.Engine.MarketingEngine, false);
        await SetGlobal(AppFeatures.System.Engine.MrpEngine, true);
        await SetGlobal(AppFeatures.System.Engine.PosEngine, true);
        await SetGlobal(AppFeatures.System.Engine.ProjectEngine, false);
        await SetGlobal(AppFeatures.System.Engine.PurchaseEngine, false);
        await SetGlobal(AppFeatures.System.Engine.QualityEngine, false);
        await SetGlobal(AppFeatures.System.Engine.SalesEngine, true);
        await SetGlobal(AppFeatures.System.Engine.StockEngine, true);
        await SetGlobal(AppFeatures.System.Engine.SubscriptionEngine, false);
        await SetGlobal(AppFeatures.System.Engine.SurveyEngine, false);
        await SetGlobal(AppFeatures.System.Engine.TimesheetEngine, false);
        await SetGlobal(AppFeatures.System.Engine.WebsiteEngine, false);
    }

    private async Task SetGlobal(string featureName, bool value)
    {
        var currentValue = await _featureManager.GetOrNullAsync(
                                featureName,
                                providerName: "G",
                                providerKey: null
                            );

        if (currentValue != null) return;
        await _featureManager.SetAsync(
            featureName,
            value.ToString().ToLowerInvariant(),
            providerName: "G",
            null
        );
    }
}
