using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ApplyExtrasConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureIrModelFieldAccess();
            modelBuilder.ConfigureMrpWorkcenterCategory();
            modelBuilder.ConfigureMrpWorkcenterExtra();
            modelBuilder.ConfigureResCurrencyExtra();
            modelBuilder.ConfigureResOrganization();
            modelBuilder.ConfigureResTeam();

            modelBuilder.ConfigureDmsAchievementLog();
            modelBuilder.ConfigureDmsAdvancedAnalytics();
            modelBuilder.ConfigureDmsAIInsight();
            modelBuilder.ConfigureDmsBIReportConfig();
            modelBuilder.ConfigureDmsClaim();
            modelBuilder.ConfigureDmsDailyCheckpoint();
            modelBuilder.ConfigureDmsDeliveryZone();
            modelBuilder.ConfigureDmsDemandForecast();
            modelBuilder.ConfigureDmsDistributorPortalConfig();
            modelBuilder.ConfigureDmsEB2BOrder();
            modelBuilder.ConfigureDmsGeofence();
            modelBuilder.ConfigureDmsImageAnalysis();
            modelBuilder.ConfigureDmsMessagingChannelConfig();
            modelBuilder.ConfigureDmsNoSaleReason();
            modelBuilder.ConfigureDmsOutletInventoryCheck();
            modelBuilder.ConfigureDmsOutletVisit();
            modelBuilder.ConfigureDmsPlanogram();
            modelBuilder.ConfigureDmsPlanogramCheck();
            modelBuilder.ConfigureDmsPOSMDeployment();
            modelBuilder.ConfigureDmsPromotionApplication();
            modelBuilder.ConfigureDmsPromotionScheme();
            modelBuilder.ConfigureDmsProvisionOrder();
            modelBuilder.ConfigureDmsReturnOrder();
            modelBuilder.ConfigureDmsRoute();
            modelBuilder.ConfigureDmsRouteLine();
            modelBuilder.ConfigureDmsRouteTemplate();
            modelBuilder.ConfigureDmsRouteTemplateLine();
            modelBuilder.ConfigureDmsSalesKPI();
            modelBuilder.ConfigureDmsShopDisplayAudit();
            modelBuilder.ConfigureDmsTargetAssignment();
            modelBuilder.ConfigureDmsTradePromotion();
            modelBuilder.ConfigureDmsVMIProposal();
            modelBuilder.ConfigureDmsVoiceNote();

        }

    }

}
