using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("res_users")]
//[Index("CreateDate", Name = "res_users__create_date_index")]
//[Index("GoogleCalendarAccountId", Name = "res_users_google_token_uniq", IsUnique = true)]
//[Index("PartnerId", Name = "res_users__partner_id_index")]
//[Index("Login", "WebsiteId", Name = "res_users_login_key", IsUnique = true)]
//[Index("OauthProviderId", "OauthUid", Name = "res_users_uniq_users_oauth_provider_oauth_uid", IsUnique = true)]
public partial class ResUsers
{

    [Column("livechat_username")]
    public string? LivechatUsername { get; set; }

    [Column("google_calendar_account_id")]
    public Guid? GoogleCalendarAccountId { get; set; }


    [Column("microsoft_calendar_sync_token")]
    public string? MicrosoftCalendarSyncToken { get; set; }

    [Column("microsoft_synchronization_stopped")]
    public bool? MicrosoftSynchronizationStopped { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountAccountTemplate) is commented out
    // public virtual ICollection<AccountAccountTemplate> AccountAccountTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountAccountTemplate) is commented out
    // public virtual ICollection<AccountAccountTemplate> AccountAccountTemplateWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountBankStatementImport) is commented out
    // public virtual ICollection<AccountBankStatementImport> AccountBankStatementImportCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountBankStatementImportJournalCreation) is commented out
    // public virtual ICollection<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreationCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountBankStatementImportJournalCreation) is commented out
    // public virtual ICollection<AccountBankStatementImportJournalCreation> AccountBankStatementImportJournalCreationWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountBankStatementImport) is commented out
    // public virtual ICollection<AccountBankStatementImport> AccountBankStatementImportWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountChartTemplate) is commented out
    // public virtual ICollection<AccountChartTemplate> AccountChartTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountChartTemplate) is commented out
    // public virtual ICollection<AccountChartTemplate> AccountChartTemplateWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountFiscalPositionAccountTemplate) is commented out
    // public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountFiscalPositionAccountTemplate) is commented out
    // public virtual ICollection<AccountFiscalPositionAccountTemplate> AccountFiscalPositionAccountTemplateWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountFiscalPositionTaxTemplate) is commented out
    // public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountFiscalPositionTaxTemplate) is commented out
    // public virtual ICollection<AccountFiscalPositionTaxTemplate> AccountFiscalPositionTaxTemplateWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountFiscalPositionTemplate) is commented out
    // public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountFiscalPositionTemplate) is commented out
    // public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplateWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountGroupTemplate) is commented out
    // public virtual ICollection<AccountGroupTemplate> AccountGroupTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountGroupTemplate) is commented out
    // public virtual ICollection<AccountGroupTemplate> AccountGroupTemplateWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountInvoiceSend) is commented out
    // public virtual ICollection<AccountInvoiceSend> AccountInvoiceSendCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountInvoiceSend) is commented out
    // public virtual ICollection<AccountInvoiceSend> AccountInvoiceSendWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("SaleActivityUserId")]
    // [NotMapped] // One2many 
    // [InverseProperty("SaleActivityUser")] // One2many // Peer relationship (AccountJournal) is commented out
    // public virtual ICollection<AccountJournal> AccountJournalSaleActivityUser { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountReconcileModelLineTemplate) is commented out
    // public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountReconcileModelLineTemplate) is commented out
    // public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplateWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountReconcileModelTemplate) is commented out
    // public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountReconcileModelTemplate) is commented out
    // public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplateWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountTaxRepartitionLineTemplate) is commented out
    // public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountTaxRepartitionLineTemplate) is commented out
    // public virtual ICollection<AccountTaxRepartitionLineTemplate> AccountTaxRepartitionLineTemplateWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountTaxTemplate) is commented out
    // public virtual ICollection<AccountTaxTemplate> AccountTaxTemplateCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountTaxTemplate) is commented out
    // public virtual ICollection<AccountTaxTemplate> AccountTaxTemplateWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountTourUploadBill) is commented out
    // public virtual ICollection<AccountTourUploadBill> AccountTourUploadBillCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountTourUploadBillEmailConfirm) is commented out
    // public virtual ICollection<AccountTourUploadBillEmailConfirm> AccountTourUploadBillEmailConfirmCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountTourUploadBillEmailConfirm) is commented out
    // public virtual ICollection<AccountTourUploadBillEmailConfirm> AccountTourUploadBillEmailConfirmWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountTourUploadBill) is commented out
    // public virtual ICollection<AccountTourUploadBill> AccountTourUploadBillWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (AccountUnreconcile) is commented out
    // public virtual ICollection<AccountUnreconcile> AccountUnreconcileCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (AccountUnreconcile) is commented out
    // public virtual ICollection<AccountUnreconcile> AccountUnreconcileWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsChar) is commented out
    // public virtual ICollection<BaseImportTestsModelsChar> BaseImportTestsModelsCharCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsCharNoreadonly) is commented out
    // public virtual ICollection<BaseImportTestsModelsCharNoreadonly> BaseImportTestsModelsCharNoreadonlyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsCharNoreadonly) is commented out
    // public virtual ICollection<BaseImportTestsModelsCharNoreadonly> BaseImportTestsModelsCharNoreadonlyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsCharReadonly) is commented out
    // public virtual ICollection<BaseImportTestsModelsCharReadonly> BaseImportTestsModelsCharReadonlyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsCharReadonly) is commented out
    // public virtual ICollection<BaseImportTestsModelsCharReadonly> BaseImportTestsModelsCharReadonlyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsCharRequired) is commented out
    // public virtual ICollection<BaseImportTestsModelsCharRequired> BaseImportTestsModelsCharRequiredCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsCharRequired) is commented out
    // public virtual ICollection<BaseImportTestsModelsCharRequired> BaseImportTestsModelsCharRequiredWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsCharStates) is commented out
    // public virtual ICollection<BaseImportTestsModelsCharStates> BaseImportTestsModelsCharStatesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsCharStates) is commented out
    // public virtual ICollection<BaseImportTestsModelsCharStates> BaseImportTestsModelsCharStatesWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsCharStillreadonly) is commented out
    // public virtual ICollection<BaseImportTestsModelsCharStillreadonly> BaseImportTestsModelsCharStillreadonlyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsCharStillreadonly) is commented out
    // public virtual ICollection<BaseImportTestsModelsCharStillreadonly> BaseImportTestsModelsCharStillreadonlyWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsChar) is commented out
    // public virtual ICollection<BaseImportTestsModelsChar> BaseImportTestsModelsCharWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsComplex) is commented out
    // public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsComplex) is commented out
    // public virtual ICollection<BaseImportTestsModelsComplex> BaseImportTestsModelsComplexWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsFloat) is commented out
    // public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloatCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsFloat) is commented out
    // public virtual ICollection<BaseImportTestsModelsFloat> BaseImportTestsModelsFloatWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsM2o) is commented out
    // public virtual ICollection<BaseImportTestsModelsM2o> BaseImportTestsModelsM2oCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsM2oRelated) is commented out
    // public virtual ICollection<BaseImportTestsModelsM2oRelated> BaseImportTestsModelsM2oRelatedCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsM2oRelated) is commented out
    // public virtual ICollection<BaseImportTestsModelsM2oRelated> BaseImportTestsModelsM2oRelatedWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsM2oRequired) is commented out
    // public virtual ICollection<BaseImportTestsModelsM2oRequired> BaseImportTestsModelsM2oRequiredCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsM2oRequiredRelated) is commented out
    // public virtual ICollection<BaseImportTestsModelsM2oRequiredRelated> BaseImportTestsModelsM2oRequiredRelatedCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsM2oRequiredRelated) is commented out
    // public virtual ICollection<BaseImportTestsModelsM2oRequiredRelated> BaseImportTestsModelsM2oRequiredRelatedWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsM2oRequired) is commented out
    // public virtual ICollection<BaseImportTestsModelsM2oRequired> BaseImportTestsModelsM2oRequiredWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsM2o) is commented out
    // public virtual ICollection<BaseImportTestsModelsM2o> BaseImportTestsModelsM2oWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsO2mChild) is commented out
    // public virtual ICollection<BaseImportTestsModelsO2mChild> BaseImportTestsModelsO2mChildCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsO2mChild) is commented out
    // public virtual ICollection<BaseImportTestsModelsO2mChild> BaseImportTestsModelsO2mChildWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsO2m) is commented out
    // public virtual ICollection<BaseImportTestsModelsO2m> BaseImportTestsModelsO2mCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsO2m) is commented out
    // public virtual ICollection<BaseImportTestsModelsO2m> BaseImportTestsModelsO2mWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (BaseImportTestsModelsPreview) is commented out
    // public virtual ICollection<BaseImportTestsModelsPreview> BaseImportTestsModelsPreviewCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (BaseImportTestsModelsPreview) is commented out
    // public virtual ICollection<BaseImportTestsModelsPreview> BaseImportTestsModelsPreviewWriteU { get; set; }


    // [Many2one]
    [ForeignKey("GoogleCalendarAccountId")]
    public virtual GoogleCalendarCredentials? GoogleCalendarAccount { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (GoogleCalendarCredentials) is commented out
    // public virtual ICollection<GoogleCalendarCredentials> GoogleCalendarCredentialsCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (GoogleCalendarCredentials) is commented out
    // public virtual ICollection<GoogleCalendarCredentials> GoogleCalendarCredentialsWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (HrApplicantSkill) is commented out
    // public virtual ICollection<HrApplicantSkill> HrApplicantSkillCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (HrApplicantSkill) is commented out
    // public virtual ICollection<HrApplicantSkill> HrApplicantSkillWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("HrResponsibleId")]
    // [NotMapped] // One2many 
    // [InverseProperty("HrResponsible")] // One2many // Peer relationship (HrJob) is commented out
    // public virtual ICollection<HrJob> HrJobHrResponsible { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (HrLeaveStressDay) is commented out
    // public virtual ICollection<HrLeaveStressDay> HrLeaveStressDayCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (HrLeaveStressDay) is commented out
    // public virtual ICollection<HrLeaveStressDay> HrLeaveStressDayWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("ResponsibleId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Responsible")] // One2many // Peer relationship (HrLeaveType) is commented out
    // public virtual ICollection<HrLeaveType> HrLeaveTypeResponsible { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (HrPlanActivityType) is commented out
    // public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("ResponsibleId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ResponsibleNavigation")] // One2many // Peer relationship (HrPlanActivityType) is commented out
    // public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeResponsibleNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (HrPlanActivityType) is commented out
    // public virtual ICollection<HrPlanActivityType> HrPlanActivityTypeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (HrPlan) is commented out
    // public virtual ICollection<HrPlan> HrPlanCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (HrPlanWizard) is commented out
    // public virtual ICollection<HrPlanWizard> HrPlanWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (HrPlanWizard) is commented out
    // public virtual ICollection<HrPlanWizard> HrPlanWizardWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (HrPlan) is commented out
    // public virtual ICollection<HrPlan> HrPlanWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (IrProperty) is commented out
    // public virtual ICollection<IrProperty> IrPropertyCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (IrProperty) is commented out
    // public virtual ICollection<IrProperty> IrPropertyWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (IrServerObjectLines) is commented out
    // public virtual ICollection<IrServerObjectLines> IrServerObjectLinesCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (IrServerObjectLines) is commented out
    // public virtual ICollection<IrServerObjectLines> IrServerObjectLinesWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("AliasUserId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AliasUser")] // One2many // Peer relationship (MailAlias) is commented out
    // public virtual ICollection<MailAlias> MailAliasAliasUser { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (MailChannel) is commented out
    // public virtual ICollection<MailChannel> MailChannelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (MailChannelMember) is commented out
    // public virtual ICollection<MailChannelMember> MailChannelMemberCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (MailChannelMember) is commented out
    // public virtual ICollection<MailChannelMember> MailChannelMemberWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (MailChannelRtcSession) is commented out
    // public virtual ICollection<MailChannelRtcSession> MailChannelRtcSessionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (MailChannelRtcSession) is commented out
    // public virtual ICollection<MailChannelRtcSession> MailChannelRtcSessionWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (MailChannel) is commented out
    // public virtual ICollection<MailChannel> MailChannelWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (MailShortcode) is commented out
    // public virtual ICollection<MailShortcode> MailShortcodeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (MailShortcode) is commented out
    // public virtual ICollection<MailShortcode> MailShortcodeWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (MailingContactListRel) is commented out
    // public virtual ICollection<MailingContactListRel> MailingContactListRelCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (MailingContactListRel) is commented out
    // public virtual ICollection<MailingContactListRel> MailingContactListRelWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (MrpDocument) is commented out
    // public virtual ICollection<MrpDocument> MrpDocumentCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (MrpDocument) is commented out
    // public virtual ICollection<MrpDocument> MrpDocumentWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (MrpImmediateProduction) is commented out
    // public virtual ICollection<MrpImmediateProduction> MrpImmediateProductionCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (MrpImmediateProductionLine) is commented out
    // public virtual ICollection<MrpImmediateProductionLine> MrpImmediateProductionLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (MrpImmediateProductionLine) is commented out
    // public virtual ICollection<MrpImmediateProductionLine> MrpImmediateProductionLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (MrpImmediateProduction) is commented out
    // public virtual ICollection<MrpImmediateProduction> MrpImmediateProductionWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (NoteNote) is commented out
    // public virtual ICollection<NoteNote> NoteNoteCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("UserId")]
    // [NotMapped] // One2many 
    // [InverseProperty("User")] // One2many // Peer relationship (NoteNote) is commented out
    // public virtual ICollection<NoteNote> NoteNoteUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (NoteNote) is commented out
    // public virtual ICollection<NoteNote> NoteNoteWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (NoteStage) is commented out
    // public virtual ICollection<NoteStage> NoteStageCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("UserId")]
    // [NotMapped] // One2many 
    // [InverseProperty("User")] // One2many // Peer relationship (NoteStage) is commented out
    // public virtual ICollection<NoteStage> NoteStageUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (NoteStage) is commented out
    // public virtual ICollection<NoteStage> NoteStageWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (NoteTag) is commented out
    // public virtual ICollection<NoteTag> NoteTagCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (NoteTag) is commented out
    // public virtual ICollection<NoteTag> NoteTagWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (PaymentIcon) is commented out
    // public virtual ICollection<PaymentIcon> PaymentIconCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (PaymentIcon) is commented out
    // public virtual ICollection<PaymentIcon> PaymentIconWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (PosSessionCheckProductWizard) is commented out
    // public virtual ICollection<PosSessionCheckProductWizard> PosSessionCheckProductWizardCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (PosSessionCheckProductWizard) is commented out
    // public virtual ICollection<PosSessionCheckProductWizard> PosSessionCheckProductWizardWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (ProjectCreateSaleOrder) is commented out
    // public virtual ICollection<ProjectCreateSaleOrder> ProjectCreateSaleOrderCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (ProjectCreateSaleOrderLine) is commented out
    // public virtual ICollection<ProjectCreateSaleOrderLine> ProjectCreateSaleOrderLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (ProjectCreateSaleOrderLine) is commented out
    // public virtual ICollection<ProjectCreateSaleOrderLine> ProjectCreateSaleOrderLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (ProjectCreateSaleOrder) is commented out
    // public virtual ICollection<ProjectCreateSaleOrder> ProjectCreateSaleOrderWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (PurchaseRequisitionType) is commented out
    // public virtual ICollection<PurchaseRequisitionType> PurchaseRequisitionTypeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (PurchaseRequisitionType) is commented out
    // public virtual ICollection<PurchaseRequisitionType> PurchaseRequisitionTypeWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (RepairFee) is commented out
    // public virtual ICollection<RepairFee> RepairFeeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (RepairFee) is commented out
    // public virtual ICollection<RepairFee> RepairFeeWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (RepairLine) is commented out
    // public virtual ICollection<RepairLine> RepairLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (RepairLine) is commented out
    // public virtual ICollection<RepairLine> RepairLineWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (RepairOrderMakeInvoice) is commented out
    // public virtual ICollection<RepairOrderMakeInvoice> RepairOrderMakeInvoiceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (RepairOrderMakeInvoice) is commented out
    // public virtual ICollection<RepairOrderMakeInvoice> RepairOrderMakeInvoiceWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (ResConfigInstaller) is commented out
    // public virtual ICollection<ResConfigInstaller> ResConfigInstallerCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (ResConfigInstaller) is commented out
    // public virtual ICollection<ResConfigInstaller> ResConfigInstallerWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (RestaurantPrinter) is commented out
    // public virtual ICollection<RestaurantPrinter> RestaurantPrinterCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (RestaurantPrinter) is commented out
    // public virtual ICollection<RestaurantPrinter> RestaurantPrinterWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (SnailmailConfirmInvoice) is commented out
    // public virtual ICollection<SnailmailConfirmInvoice> SnailmailConfirmInvoiceCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (SnailmailConfirmInvoice) is commented out
    // public virtual ICollection<SnailmailConfirmInvoice> SnailmailConfirmInvoiceWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (StockAssignSerial) is commented out
    // public virtual ICollection<StockAssignSerial> StockAssignSerialCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (StockAssignSerial) is commented out
    // public virtual ICollection<StockAssignSerial> StockAssignSerialWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (StockImmediateTransfer) is commented out
    // public virtual ICollection<StockImmediateTransfer> StockImmediateTransferCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (StockImmediateTransferLine) is commented out
    // public virtual ICollection<StockImmediateTransferLine> StockImmediateTransferLineCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (StockImmediateTransferLine) is commented out
    // public virtual ICollection<StockImmediateTransferLine> StockImmediateTransferLineWriteU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (StockImmediateTransfer) is commented out
    // public virtual ICollection<StockImmediateTransfer> StockImmediateTransferWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("CreatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CreateU")] // One2many // Peer relationship (StockSchedulerCompute) is commented out
    // public virtual ICollection<StockSchedulerCompute> StockSchedulerComputeCreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("LastModifierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WriteU")] // One2many // Peer relationship (StockSchedulerCompute) is commented out
    // public virtual ICollection<StockSchedulerCompute> StockSchedulerComputeWriteU { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResUsers'
    // [One2many] [ForeignKey("UserId")]
    // [NotMapped] // One2many 
    // [InverseProperty("User")] // One2many // Peer relationship (WebTourTour) is commented out
    // public virtual ICollection<WebTourTour> WebTourTour { get; set; }

}
