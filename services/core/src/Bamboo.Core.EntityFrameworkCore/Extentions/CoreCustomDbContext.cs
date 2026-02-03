using System;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public partial class CoreDbContext
{

    public virtual DbSet<IrModelFieldAccess> IrModelFieldAccesses { get; set; }
    public virtual DbSet<ResOrganization> ResOrganizations { get; set; }
    public virtual DbSet<ResTeam> ResTeams { get; set; }
    public virtual DbSet<MrpWorkcenterCategory> MrpWorkcenterCategories { get; set; }

    // DMS
    // 1-2: Core Infrastructure & User/Location / Secondary Sales & Route
    public virtual DbSet<DmsGeofence> DmsGeofences { get; set; }
    public virtual DbSet<DmsDeliveryZone> DmsDeliveryZone { get; set; }
    public virtual DbSet<DmsRoute> DmsRoute { get; set; }
    public virtual DbSet<DmsRouteLine> DmsRouteLine { get; set; }
    public virtual DbSet<DmsRouteTemplate> DmsRouteTemplates { get; set; }
    public virtual DbSet<DmsRouteTemplateLine> DmsRouteTemplateLines { get; set; }
    public virtual DbSet<DmsDailyCheckpoint> DmsDailyCheckpoint { get; set; }
    public virtual DbSet<DmsProvisionOrder> DmsProvisionOrder { get; set; }
    public virtual DbSet<DmsOutletVisit> DmsOutletVisit { get; set; }
    public virtual DbSet<DmsShopDisplayAudit> DmsShopDisplayAudit { get; set; }
    public virtual DbSet<DmsNoSaleReason> DmsNoSaleReason { get; set; }

    // 3: Claim, Return & KPI (Promotion, Claim, KPI)
    public virtual DbSet<DmsPromotionScheme> DmsPromotionScheme { get; set; }
    public virtual DbSet<DmsPromotionApplication> DmsPromotionApplication { get; set; }
    public virtual DbSet<DmsClaim> DmsClaim { get; set; }
    public virtual DbSet<DmsReturnOrder> DmsReturnOrder { get; set; }
    public virtual DbSet<DmsTargetAssignment> DmsTargetAssignment { get; set; }
    public virtual DbSet<DmsAchievementLog> DmsAchievementLog { get; set; }
    public virtual DbSet<DmsSalesKPI> DmsSalesKPI { get; set; }

    // 4: Trade Marketing, POSM, VMI & BI (Advanced Distribution & Reporting)
    public virtual DbSet<DmsTradePromotion> DmsTradePromotion { get; set; }
    public virtual DbSet<DmsPOSMDeployment> DmsPOSMDeployment { get; set; }
    public virtual DbSet<DmsVMIProposal> DmsVMIProposal { get; set; }
    public virtual DbSet<DmsBIReportConfig> DmsBIReportConfig { get; set; }
    public virtual DbSet<DmsOutletInventoryCheck> DmsOutletInventoryCheck { get; set; }
    public virtual DbSet<DmsDemandForecast> DmsDemandForecast { get; set; }
    public virtual DbSet<DmsPlanogram> DmsPlanogram { get; set; }
    public virtual DbSet<DmsPlanogramCheck> DmsPlanogramCheck { get; set; }

    //5: Omnichannel, AI & Nâng cao (AI, Messaging, Distributor Portal)
    public virtual DbSet<DmsVoiceNote> DmsVoiceNote { get; set; }
    public virtual DbSet<DmsEB2BOrder> DmsEB2BOrder { get; set; }
    public virtual DbSet<DmsMessagingChannelConfig> DmsMessagingChannelConfig { get; set; }
    public virtual DbSet<DmsAIInsight> DmsAIInsight { get; set; }
    public virtual DbSet<DmsImageAnalysis> DmsImageAnalysis { get; set; }
    public virtual DbSet<DmsDistributorPortalConfig> DmsDistributorPortalConfig { get; set; }
    public virtual DbSet<DmsAdvancedAnalytics> DmsAdvancedAnalytics { get; set; }

}