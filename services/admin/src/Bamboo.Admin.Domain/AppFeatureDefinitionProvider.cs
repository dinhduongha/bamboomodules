using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Validation.StringValues;
using Bamboo.Admin.Localization;
using Bamboo.Admin.Domain.Shared;

public class BambooFeatureDefinitionProvider : FeatureDefinitionProvider
{
    public override void Define(IFeatureDefinitionContext context)
    {
        FeatureGroupDefinition GetOrAddGroup(string name, LocalizableString displayName)
        {
            var existing = context.GetGroupOrNull(name);
            return existing ?? context.AddGroup(name, displayName);
        }

        // =====================================================
        // GROUPS
        // =====================================================
        var systemGroup = GetOrAddGroup(AppFeatures.GroupSystem, L("Feature:System"));
        var businessGroup = GetOrAddGroup(AppFeatures.GroupBusiness, L("Feature:Business"));
        var securityGroup = GetOrAddGroup(AppFeatures.GroupSecurity, L("Feature:Securities"));
        var uiGroup = GetOrAddGroup(AppFeatures.GroupUI, L("Feature:UI"));

        // =====================================================
        // SYSTEM – CORE
        // =====================================================
        AddFeatureSafe(systemGroup, AppFeatures.System.MultiCompany, defaultValue: "true");
        AddFeatureSafe(systemGroup, AppFeatures.System.MultiCurrency, defaultValue: "true");
        AddFeatureSafe(systemGroup, AppFeatures.System.Uom, defaultValue: "true");
        AddFeatureSafe(systemGroup, AppFeatures.System.FiscalYear, defaultValue: "true");
        AddFeatureSafe(systemGroup, AppFeatures.System.ProductVariant, defaultValue: "true");

        // =====================================================
        // SYSTEM – LEVEL 0 (HOST ENGINES)
        // =====================================================
        //RegisterEngines(systemGroup);
        RegisterAllEngines(systemGroup);

        // =====================================================
        // BUSINESS – LEVEL 1 (MODULES)
        // =====================================================
        RegisterBusinessModulesAndSubFeatures(systemGroup, businessGroup);

        // =====================================================
        // SECURITY
        // =====================================================
        RegisterSimpleGroup(securityGroup, typeof(AppFeatures.Securities), defaultValue: "false");

        // =====================================================
        // UI
        // =====================================================
        RegisterSimpleGroup(uiGroup, typeof(AppFeatures.UI), defaultValue: "true");
    }

    // =====================================================
    // REGISTRATIONS
    // =====================================================

    private static void RegisterAllEngines(FeatureGroupDefinition group)
    {
        var engineType = typeof(AppFeatures.System.Engine);
        var fields = engineType.GetFields(BindingFlags.Public | BindingFlags.Static);

        foreach (var field in fields)
        {
            var engineName = (string)field.GetValue(null)!;
            if (string.IsNullOrEmpty(engineName)) continue;

            // Check if feature already exists to avoid duplicates
            if (group.Features.Any(f => f.Name == engineName)) continue;

            AddFeatureSafe(group, engineName, "true");
        }
    }
    private static void RegisterBusinessModulesAndSubFeatures(
        FeatureGroupDefinition systemGroup,
        FeatureGroupDefinition businessGroup)
    {
        var moduleEngineMap = new Dictionary<string, string>
        {
            { AppFeatures.Business.Accounting, AppFeatures.System.Engine.AccountingEngine },
            { AppFeatures.Business.Appointment, AppFeatures.System.Engine.AppointmentEngine },
            { AppFeatures.Business.Crm, AppFeatures.System.Engine.SalesEngine },
            { AppFeatures.Business.Dashboard, AppFeatures.System.Engine.DashboardEngine },
            { AppFeatures.Business.Equity, AppFeatures.System.Engine.EquityEngine },
            { AppFeatures.Business.ESG, AppFeatures.System.Engine.ESGEngine },
            { AppFeatures.Business.Event, AppFeatures.System.Engine.EventEngine },
            { AppFeatures.Business.Fleet, AppFeatures.System.Engine.FleetEngine },
            { AppFeatures.Business.Helpdesk, AppFeatures.System.Engine.HelpdeskEngine },
            { AppFeatures.Business.Hr, AppFeatures.System.Engine.HrEngine },
            { AppFeatures.Business.IoT, AppFeatures.System.Engine.IoTBarcodeEngine },
            { AppFeatures.Business.Livechat, AppFeatures.System.Engine.LivechatEngine },
            { AppFeatures.Business.Lunch, AppFeatures.System.Engine.LunchEngine },
            { AppFeatures.Business.Maintenance, AppFeatures.System.Engine.MaintenanceEngine },
            { AppFeatures.Business.Marketing, AppFeatures.System.Engine.MarketingEngine },
            { AppFeatures.Business.Mrp, AppFeatures.System.Engine.MrpEngine },
            { AppFeatures.Business.Pos, AppFeatures.System.Engine.PosEngine },
            { AppFeatures.Business.Project, AppFeatures.System.Engine.ProjectEngine },
            { AppFeatures.Business.Purchase, AppFeatures.System.Engine.PurchaseEngine },
            { AppFeatures.Business.Quality, AppFeatures.System.Engine.QualityEngine },
            { AppFeatures.Business.Sale, AppFeatures.System.Engine.SalesEngine },
            { AppFeatures.Business.Stock, AppFeatures.System.Engine.StockEngine },
            { AppFeatures.Business.Subscription, AppFeatures.System.Engine.SubscriptionEngine },
            { AppFeatures.Business.Survey, AppFeatures.System.Engine.SurveyEngine },
            { AppFeatures.Business.Timesheet, AppFeatures.System.Engine.TimesheetEngine },
            { AppFeatures.Business.Website, AppFeatures.System.Engine.WebsiteEngine },
        };

        foreach (var kvp in moduleEngineMap)
        {
            var moduleName = kvp.Key;
            var engineName = kvp.Value;

            // Tìm Engine đã đăng ký (cha)
            //var engineFeature = systemGroup.Features.FirstOrDefault(f => f.Name == engineName);
            // if (engineFeature == null)
            // {
            //     throw new InvalidOperationException($"Engine {engineName} not found!");
            // }
            var engineFeature = FindFeatureInGroup(systemGroup, engineName);
            if (engineFeature == null) continue;

            if (engineFeature.Children.Any(c => c.Name == moduleName))
                continue;

            // Default value cho module: true cho core, false cho optional/Enterprise
            var defaultValue = IsCoreModule(moduleName) ? "true" : "false";

            var moduleFeature = FindFeatureInGroup(businessGroup, moduleName);
            if (moduleFeature != null)
                continue;

            AddFeatureSafe(businessGroup, moduleName, defaultValue, true, true);
            //
            // Đăng ký Module làm child của Engine
            // moduleFeature = engineFeature.CreateChild(
            //     name: moduleName,
            //     defaultValue: defaultValue,
            //     displayName: L(moduleName.Replace(".", "_")),
            //     valueType: new ToggleStringValueType(),
            //     isVisibleToClients: true,
            //     isAvailableToHost: true
            // );

            // Optional: Tag Enterprise
            //if (defaultValue == "false")
            //    moduleFeature.Tags.Add("Enterprise");
        }

        // Sau khi có tất cả modules (cha), đăng ký sub-features đệ quy
        RegisterFeaturesRecursive(businessGroup, typeof(AppFeatures.Business), isRootCall: true);
    }

    private static bool IsCoreModule(string moduleName)
    {
        var core = new[] {
            AppFeatures.Business.Accounting,
            AppFeatures.Business.Sale,
            AppFeatures.Business.Purchase,
            AppFeatures.Business.Stock,
            AppFeatures.Business.Pos,
            AppFeatures.Business.Project,
            AppFeatures.Business.Hr,
            AppFeatures.Business.Website,
            AppFeatures.Business.Timesheet,
            AppFeatures.Business.Crm
        };
        return core.Contains(moduleName);
    }

    private static void RegisterSimpleGroup(
        FeatureGroupDefinition group,
        Type container,
        string defaultValue)
    {
        foreach (var field in container.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy))
        {
            var featureName = field.GetValue(null)?.ToString();

            if (string.IsNullOrWhiteSpace(featureName)) continue;

            // Prevent duplicate registration if feature already exists in the group
            if (group.Features.Any(f => f.Name == featureName)) continue;
            group.AddFeature(
                featureName,
                defaultValue: defaultValue
            );
        }
    }


    private static void RegisterFeaturesRecursive(
    FeatureGroupDefinition group,
    Type type,
    bool isRootCall = true)  // Thêm flag để biết đây là call gốc
    {
        var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                         .Where(f => f.FieldType == typeof(string))
                         .ToList();

        foreach (var field in fields)
        {
            var featureName = field.GetValue(null)?.ToString();
            if (string.IsNullOrEmpty(featureName) || !featureName.StartsWith("Business."))
                continue;

            var parts = featureName.Split('.');
            if (parts.Length < 3) continue;

            var parentName = string.Join(".", parts.Take(parts.Length - 1));
            var featureKey = parts.Last();

            // Chỉ tạo level 1 (module) khi là root call
            FeatureDefinition parentFeature;
            if (isRootCall && parentName == "Business")
            {
                // Tạo level 1 ngay dưới Business group
                if (group.Features.Any(f => f.Name == featureName))
                    continue; // Tránh duplicate

                parentFeature = group.AddFeature(
                    name: featureName,
                    defaultValue: IsCoreModule(featureName) ? "true" : "false",
                    valueType: new ToggleStringValueType(),
                    displayName: LocalizableString.Create<AdminResource>(featureKey)
                );
            }
            else
            {
                // Tìm parent (level 1) đã tồn tại
                parentFeature = FindFeatureInGroup(group, parentName);
                if (parentFeature == null)
                    continue; // Bỏ qua nếu cha chưa tồn tại
            }

            // Tạo child (level 2 hoặc sâu hơn)
            if (parentFeature.Children.Any(c => c.Name == featureName))
                continue;

            parentFeature.CreateChild(
                name: featureName,
                defaultValue: "false",
                valueType: new ToggleStringValueType(),
                //displayName: new FixedLocalizableString(parts.Last())
                displayName: LocalizableString.Create<AdminResource>(featureKey)
            );
        }

        // Đệ quy vào nested types (AI, Accounting, Sale, ...)
        // Nhưng KHÔNG tạo level 1 ở đây nữa
        var nestedTypes = type.GetNestedTypes(BindingFlags.Public);
        foreach (var nestedType in nestedTypes)
        {
            RegisterFeaturesRecursive(group, nestedType, isRootCall: false);
        }
    }

    // Helper: Tìm feature trong toàn bộ hierarchy (đệ quy nếu cần)
    private static void AddFeatureSafe(FeatureGroupDefinition group, string name, string defaultValue, bool isVisibleToClients = false, bool isAvailableToHost = true, LocalizableString displayName = null)
    {
        if (FindFeatureInGroup(group, name) == null)
        {
            group.AddFeature(
                name,
                defaultValue: defaultValue,
                displayName: displayName != null
                    ? displayName
                    : LocalizableString.Create<AdminResource>(name),
                valueType: new ToggleStringValueType(),
                isVisibleToClients: isVisibleToClients,
                isAvailableToHost: isAvailableToHost

            );
        }
    }
    private static FeatureDefinition FindFeatureInGroup(FeatureGroupDefinition group, string name)
    {
        var feature = group.Features.FirstOrDefault(f => f.Name == name);
        if (feature != null) return feature;

        foreach (var f in group.Features)
        {
            var found = FindInChildren(f, name);
            if (found != null) return found;
        }
        return null;
    }

    private static FeatureDefinition FindInChildren(FeatureDefinition feature, string name)
    {
        if (feature.Children.Any(c => c.Name == name))
            return feature.Children.First(c => c.Name == name);

        foreach (var child in feature.Children)
        {
            var found = FindInChildren(child, name);
            if (found != null) return found;
        }
        return null;
    }
    private static LocalizableString L(string name)
        => LocalizableString.Create<AdminResource>(name);
}
