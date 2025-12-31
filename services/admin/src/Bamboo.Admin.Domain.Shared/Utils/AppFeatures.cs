namespace Bamboo.Admin.Domain.Shared;

public static class AppFeatures
{
    public const string GroupSystem = "System";
    public const string GroupBusiness = "Business";
    public const string GroupUI = "UI";
    public const string GroupSecurity = "Security";

    public static class System
    {
        public const string MultiCompany = "System.MultiCompany";
        public const string MultiCurrency = "System.MultiCurrency";
        public const string Uom = "System.Uom";
        public const string FiscalYear = "System.FiscalYear";
        public const string ProductVariant = "System.ProductVariant";

        // =====================================================
        // LEVEL 0 – HOST ENGINES
        // =====================================================

        public static class Engine
        {
            public const string AccountingEngine = "System.AccountingEngine";
            public const string AppointmentEngine = "System.AppointmentEngine";
            public const string DashboardEngine = "System.DashboardEngine";
            public const string EquityEngine = "System.EquityEngine";         // Mới Odoo 19
            public const string ESGEngine = "System.ESGEngine";               // Mới Odoo 19
            public const string EventEngine = "System.EventEngine";
            public const string FleetEngine = "System.FleetEngine";
            public const string HelpdeskEngine = "System.HelpdeskEngine";
            public const string HrEngine = "System.HrEngine";
            public const string IoTBarcodeEngine = "System.IoTBarcodeEngine"; // Thường Enterprise
            public const string LivechatEngine = "System.LivechatEngine";
            public const string LunchEngine = "System.LunchEngine";
            public const string MaintenanceEngine = "System.MaintenanceEngine";
            public const string MarketingEngine = "System.MarketingEngine";
            public const string MrpEngine = "System.MrpEngine";
            public const string PosEngine = "System.PosEngine";
            public const string ProjectEngine = "System.ProjectEngine";
            public const string PurchaseEngine = "System.PurchaseEngine";
            public const string QualityEngine = "System.QualityEngine";       // Thường Enterprise
            public const string SalesEngine = "System.SalesEngine";
            public const string StockEngine = "System.StockEngine";
            public const string SubscriptionEngine = "System.SubscriptionEngine";
            public const string SurveyEngine = "System.SurveyEngine";
            public const string TimesheetEngine = "System.TimesheetEngine";
            public const string WebsiteEngine = "System.WebsiteEngine";

        }
    }

    public static class Business
    {
        // ========== LEVEL 1 – MODULE ==========

        public const string Accounting = "Business.Accounting";
        public const string Appointment = "Business.Appointment";
        public const string Crm = "Business.Crm";
        public const string Dashboard = "Business.Dashboard";
        public const string Documents = "Business.Documents";         // Thường Enterprise
        public const string Equity = "Business.Equity";
        public const string ESG = "Business.ESG";                      // Mới Odoo 19 – Carbon footprint, emissions, CSRD
        public const string Event = "Business.Event";
        public const string FieldService = "Business.FieldService";   // Thường Enterprise
        public const string Fleet = "Business.Fleet";
        public const string Helpdesk = "Business.Helpdesk";
        public const string Hr = "Business.Hr";
        public const string IoT = "Business.IoT";
        public const string Livechat = "Business.Livechat";
        public const string Lunch = "Business.Lunch";
        public const string Maintenance = "Business.Maintenance";
        public const string Marketing = "Business.Marketing";
        public const string Mrp = "Business.Mrp";
        public const string PLM = "Business.PLM";                      // Product Lifecycle Management - Thường Enterprise
        public const string Pos = "Business.Pos";
        public const string Project = "Business.Project";
        public const string Purchase = "Business.Purchase";
        public const string Quality = "Business.Quality";
        public const string Rental = "Business.Rental";                // Thường Enterprise
        public const string Sale = "Business.Sale";
        public const string Sign = "Business.Sign";                    // Thường Enterprise
        public const string Stock = "Business.Stock";
        public const string Subscription = "Business.Subscription";
        public const string Survey = "Business.Survey";
        public const string Timesheet = "Business.Timesheet";
        public const string Website = "Business.Website";

        // =================================================
        // LEVEL 2 – AI (mới – tích hợp xuyên suốt Odoo 19)
        // =================================================
        public const string AIAgents = "Business.AI.Agents";                   // AI agents, livechat leads
        public const string AIFieldFilling = "Business.AI.FieldFilling";       // Tự động điền field bằng AI
        public const string AIVoiceTranscription = "Business.AI.VoiceTranscription"; // Transcribe meetings/dictate
        public const string AIWebGeneration = "Business.AI.WebGeneration";     // Tạo web page từ prompt
        public const string AIChatterSummary = "Business.AI.ChatterSummary";   // Tóm tắt thread/email
        public const string AIServerActions = "Business.AI.ServerActions";     // AI trong automated actions

        // =================================================
        // LEVEL 2 – CRM
        // =================================================
        public const string CrmLead = "Business.Crm.CrmLead";
        public const string CrmAllLeads = "Business.Crm.AllLeads";
        public const string CrmOpportunity = "Business.Crm.Opportunity";
        public const string CrmActivity = "Business.Crm.Activity";
        public const string CrmPipeline = "Business.Crm.Pipeline";
        public const string CrmLostReason = "Business.Crm.LostReason";     // Thêm
        public const string CrmLeadScoring = "Business.Crm.LeadScoring";   // Thường Enterprise // // Cải tiến AI trong 19
        public const string CrmContact = "Business.Crm.Contact";
        public const string CrmStage = "Business.Crm.Stage";
        public const string CrmTag = "Business.Crm.Tag";
        public const string CrmReporting = "Business.Crm.Reporting";


        // =================================================
        // LEVEL 2 – SALE
        // =================================================
        public const string SaleWarning = "Business.Sale.Warning";
        public const string SaleDiscountPerLine = "Business.Sale.DiscountPerLine";
        public const string SaleProforma = "Business.Sale.Proforma";
        public const string SaleOrderTemplate = "Business.Sale.OrderTemplate";
        public const string SaleQuotation = "Business.Sale.Quotation";

        public const string RecurringRevenue = "Business.Sale.RecurringRevenue";
        public const string SaleMargin = "Business.Sale.Margin";                  // Thêm: Hiển thị lợi nhuận
        public const string SalePricelist = "Business.Sale.Pricelist";            // Thêm
        public const string SaleCommission = "Business.Sale.Commission";          // Thêm (tính năng mới 18+)
        public const string SaleProductCatalog = "Business.Sale.ProductCatalog";  // Thêm (Odoo 17+)
        public const string QuoteBuilder = "Business.Sale.QuoteBuilder";       // Mới UX quoting nhanh
        public const string SaleAbandonedCartPostActivation = "Business.Sale.AbandonedCartPostActivation"; // (Toggleable) Chỉ gửi email cho cart sau khi bật feature

        public const string SaleOrder = "Business.Sale.Order";
        public const string SaleDelivery = "Business.Sale.Delivery";
        public const string SaleInvoice = "Business.Sale.Invoice";
        public const string SaleReturn = "Business.Sale.Return";

        // =================================================
        // LEVEL 2 – ACCOUNTING
        // =================================================
        public const string AccountingInvoice = "Business.Accounting.Invoice";
        public const string AccountingAnalytic = "Business.Accounting.Analytic";
        public const string AccountingCashRounding = "Business.Accounting.CashRounding";
        public const string AccountingPartialPurchase = "Business.Accounting.PartialPurchase";
        public const string AccountingRecurring = "Business.Accounting.RecurringRevenue";
        public const string AccountingFiscalLock = "Business.Accounting.FiscalLock";
        public const string AccountingAsset = "Business.Accounting.Asset";
        public const string AccountingBudget = "Business.Accounting.Budget";
        public const string AnalyticAccounting = "Business.AnalyticAccounting";

        public const string AccountingBankSync = "Business.Accounting.BankSync";         // Thêm (thường Enterprise)
        public const string AccountingConsolidation = "Business.Accounting.Consolidation";// Thêm (thường Enterprise)
        public const string AccountingDeferredRevenue = "Business.Accounting.DeferredRevenue";
        public const string AccountingAuditReport = "Business.Accounting.AuditReport";   // Mới: Powerful audit creator
        public const string AccountingFollowUpWhatsApp = "Business.Accounting.FollowUpWhatsApp"; // Mới
        public const string AccountingBankReconciliationUX = "Business.Accounting.BankReconciliationUX"; // Revamp lớn
        public const string AccountingSalesReceipts = "Business.Accounting.SalesReceipts";       // (Toggleable) Activate sales receipts (không phải invoice)
        public const string AccountingWithholdingTaxOnPayment = "Business.Accounting.WithholdingTaxOnPayment"; // (Toggleable) Áp dụng withholding trực tiếp trên payment
        public const string AccountingLightAuditTrail = "Business.Accounting.LightAuditTrail";   // (Toggleable) Light audit trail mặc định cho tất cả (mới Odoo 19)
        public const string AccountingTaxableSupplyDate = "Business.Accounting.TaxableSupplyDate"; // (Toggleable) Activate ở các country yêu cầu
        public const string AccountingReviewInvoicesFlag = "Business.Accounting.ReviewInvoicesFlag"; // Flag hóa đơn cần review

        public const string AccountingPayment = "Business.Accounting.Payment";
        public const string AccountingTax = "Business.Accounting.Tax";
        public const string AccountingLockDate = "Business.Accounting.LockDate";
        public const string AccountingBank = "Business.Accounting.Bank";
        public const string AccountingReconciliation = "Business.Accounting.Reconciliation";


        // =================================================
        // LEVEL 2 – PURCHASE
        // =================================================
        public const string PurchaseWarning = "Business.Purchase.Warning";
        public const string PurchaseAlternatives = "Business.Purchase.Alternatives";
        public const string PurchaseAutoDone = "Business.Purchase.AutoDone";
        public const string PurchaseTender = "Business.Purchase.Tender";          // Thêm: RFQ đấu thầu
        public const string PurchaseBlanketOrder = "Business.Purchase.BlanketOrder";// Thêm

        public const string PurchaseReceipt = "Business.Purchase.Receipt";
        public const string PurchaseBill = "Business.Purchase.Bill";
        public const string PurchaseReturn = "Business.Purchase.Return";

        // =================================================
        // LEVEL 2 – STOCK
        // =================================================
        public const string StockWarning = "Business.Stock.Warning";
        public const string StockMultiLocation = "Business.Stock.MultiLocation";
        public const string StockLotTracking = "Business.Stock.LotTracking";
        public const string StockOwnerTracking = "Business.Stock.OwnerTracking";
        public const string StockReceptionReport = "Business.Stock.ReceptionReport";
        public const string StockExpirationDate = "Business.Stock.ExpirationDate";
        public const string StockBarcode = "Business.Stock.Barcode";
        public const string StockDropShipping = "Business.Stock.DropShipping";
        public const string StockInterWarehouse = "Business.Stock.InterWarehouse"; // Thêm
        public const string StockLandedCosts = "Business.Stock.LandedCosts";       // Thêm
        public const string StockProductConfigurator = "Business.Stock.ProductConfigurator";
        public const string StockPackagesNested = "Business.Stock.PackagesNested"; // Mới: Packages within packages
        public const string StockReplenishOnOrderMTO = "Business.Stock.ReplenishOnOrderMTO";     // (Toggleable) Activate route MTO riêng
        public const string StockNestedPackages = "Business.Stock.NestedPackages";               // (Toggleable) Packages within packages (mới 19)
        public const string StockWhatsAppShippingNotifications = "Business.Stock.WhatsAppShippingNotifications"; // (Toggleable) Gửi thông báo vận chuyển qua WhatsApp
        public const string StockInventory = "Business.Stock.Inventory";
        public const string StockTransfer = "Business.Stock.Transfer";
        public const string StockPicking = "Business.Stock.Picking";
        public const string StockInventoryAdjust = "Business.Stock.InventoryAdjust";

        //
        // =================================================
        // LEVEL 2 – MRP
        // =================================================
        public const string MrpRouting = "Business.Mrp.Routing";
        public const string MrpByProduct = "Business.Mrp.ByProduct";
        public const string MrpWorkOrder = "Business.Mrp.WorkOrder";
        public const string MrpWorkOrderDependencies = "Business.Mrp.WorkOrderDependencies";
        public const string MrpQualityControl = "Business.Mrp.QualityControl"; // Thêm
        public const string MrpSubcontracting = "Business.Mrp.Subcontracting"; // Thêm
        public const string MrpMultipleLotsPerMO = "Business.Mrp.MultipleLotsPerMO"; // Mới Odoo 19


        // =================================================
        // LEVEL 2 – PROJECT / TIMESHEET
        // =================================================
        public const string ProjectMilestone = "Business.Project.Milestone";
        public const string ProjectRecurringTask = "Business.Project.RecurringTask";
        public const string ProjectDependencies = "Business.Project.Dependencies";
        public const string ProjectRating = "Business.Project.Rating";              // Thêm
        public const string ProjectProfitability = "Business.Project.Profitability";// Thêm (thường Enterprise)
        public const string ProjectGanttEnhancements = "Business.Project.GanttEnhancements"; // Mới UX
        public const string ProjectGanttSmartZoomAndBuffer = "Business.Project.GanttSmartZoomAndBuffer"; // (Toggleable) Smart zoom + buffer time trong Gantt
        public const string ProjectTask = "Business.Project.Task";
        public const string ProjectStage = "Business.Project.Stage";
        public const string ProjectMember = "Business.Project.Member";
        public const string ProjectBudget = "Business.Project.Budget";

        public const string TimesheetApproval = "Business.Timesheet.Approval";
        public const string TimesheetEntry = "Business.Timesheet.Entry";
        public const string TimesheetValidation = "Business.Timesheet.Validation";
        public const string TimesheetBilling = "Business.Timesheet.Billing";

        // =================================================
        // LEVEL 2 – HR
        // =================================================
        public const string HrAttendance = "Business.Hr.Attendance";
        public const string HrExpense = "Business.Hr.Expense";
        public const string HrLeave = "Business.Hr.Leave";
        public const string HrRecruitment = "Business.Hr.Recruitment";
        public const string HrTimesheet = "Business.Hr.Timesheet";
        public const string HrPayroll = "Business.Hr.Payroll";
        public const string HrAppraisal = "Business.Hr.Appraisal";            // Thêm (thường Enterprise)
        public const string HrContracts = "Business.Hr.Contracts";            // Thêm
        public const string HrSkillsManagement = "Business.Hr.SkillsManagement";// Thêm
        public const string HrEmployee = "Business.Hr.Employee";
        public const string HrContract = "Business.Hr.Contract";
        public const string HrDepartment = "Business.Hr.Department";
        public const string HrJob = "Business.Hr.Job";

        // =================================================
        // LEVEL 2 – POS
        // =================================================

        public const string PosPreset = "Business.Pos.Preset";
        public const string PosDiscount = "Business.Pos.Discount";
        public const string PosMultiPayment = "Business.Pos.MultiPayment";
        public const string PosLoyalty = "Business.Pos.Loyalty";              // Thêm
        public const string PosKitchenDisplay = "Business.Pos.KitchenDisplay";// Thêm (thường Enterprise)
        public const string PosSession = "Business.Pos.Session";
        public const string PosOrder = "Business.Pos.Order";
        public const string PosPayment = "Business.Pos.Payment";
        public const string PosReceipt = "Business.Pos.Receipt";
        public const string PosReturn = "Business.Pos.Return";

        // =================================================
        // LEVEL 2 – WEBSITE / MARKETING
        // =================================================
        public const string WebsiteMulti = "Business.Website.Multi";
        public const string WebsiteProductFeed = "Business.Website.ProductFeed";
        public const string MarketingMailing = "Business.Marketing.Mailing";
        public const string MarketingCampaign = "Business.Marketing.Campaign";
        public const string eCommerce = "Business.eCommerce";
        public const string eCommerceWishlist = "Business.eCommerce.Wishlist";
        public const string eCommerceProductComparison = "Business.eCommerce.ProductComparison";
        public const string eCommerceSEOImprovements = "Business.eCommerce.SEOImprovements"; // Mới 19
        public const string eCommerceGoogleMerchantCenterSync = "Business.eCommerce.GoogleMerchantCenterSync"; // (Toggleable) Sync sản phẩm với Google Merchant
        public const string eCommerceClickAndCollect = "Business.eCommerce.ClickAndCollect";     // (Toggleable) Cải tiến Click & Collect

        public const string WebsitePage = "Business.Website.Page";
        public const string WebsiteMenu = "Business.Website.Menu";
        public const string WebsiteTheme = "Business.Website.Theme";
        public const string WebsiteAsset = "Business.Website.Asset";
        public const string WebsiteBanner = "Business.Website.Banner";

        // =================================================
        // LEVEL 2 – OTHERS
        // =================================================
        public const string SurveyEnable = "Business.Survey.Enable";
        public const string EventRegistrationDesk = "Business.Event.RegistrationDesk";
        public const string FleetEnable = "Business.Fleet.Enable";
        public const string LivechatEnable = "Business.Livechat.Enable";
        public const string LunchEnable = "Business.Lunch.Enable";
        public const string DashboardEnable = "Business.Dashboard.Enable";
        public const string HelpdeskTicket = "Business.Helpdesk.Ticket";
        public const string SubscriptionRecurring = "Business.Subscription.Recurring";
        public const string AppointmentBooking = "Business.Appointment.Booking";
    }

    public static class Securities
    {
        public const string ExportData = "Security.ExportData";
        public const string DocumentAccess = "Security.DocumentAccess";
        public const string PartnerCrossTenant = "Security.PartnerCrossTenant";
        public const string ControllerExpose = "Security.ControllerExpose";
        public const string SanitizeOverride = "Security.SanitizeOverride";
        public const string ValidateBankAccount = "Security.ValidateBankAccount";
        public const string AccountSecured = "Security.AccountSecured";
        public const string AuditLog = "Security.AuditLog";               // Thêm
        public const string TwoFactorAuth = "Security.TwoFactorAuth";     // Thêm
        public const string LightAuditTrailDefault = "Security.LightAuditTrailDefault"; // Mới Odoo 19
    }

    public static class UI
    {
        public const string SaleWarning = "UI.SaleWarning";
        public const string PurchaseWarning = "UI.PurchaseWarning";
        public const string StockWarning = "UI.StockWarning";
        public const string SendReminder = "UI.SendReminder";
        public const string ReceptionReport = "UI.ReceptionReport";
        public const string DeliveryInvoiceAddress = "UI.DeliveryInvoiceAddress";
        public const string DarkMode = "UI.DarkMode";                    // Thêm (nếu bạn hỗ trợ theme)
        public const string AdvancedSearch = "UI.AdvancedSearch";       // Thêm (tính năng Odoo 17+)
        public const string ModernCompactUI = "UI.ModernCompactUI";         // Revamp lớn Odoo 19
        public const string PWAPullToRefresh = "UI.PWAPullToRefresh";       // Mới mobile
        public const string GanttSmartZoom = "UI.GanttSmartZoom";
    }
}
