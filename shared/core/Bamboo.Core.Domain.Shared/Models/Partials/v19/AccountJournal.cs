using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class AccountJournal
{
    [Column("non_deductible_account_id")]
    public Guid? NonDeductibleAccountId { get; set; }

    [Column("invoice_template_pdf_report_id")]
    public Guid? InvoiceTemplatePdfReportId { get; set; }

    [Column("incoming_einvoice_notification_email")]
    public string? IncomingEinvoiceNotificationEmail { get; set; }

    [Column("is_self_billing")]
    public bool? IsSelfBilling { get; set; }

    [Column("check_sequence_id")]
    public Guid? CheckSequenceId { get; set; }

    [Column("bank_check_printing_layout")]
    public string? BankCheckPrintingLayout { get; set; }

    [Column("check_manual_sequencing")]
    public bool? CheckManualSequencing { get; set; }

    [Column("l10n_latam_use_documents")]
    public bool? L10nLatamUseDocuments { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CheckSequenceId")]
    public virtual IrSequence? CheckSequence { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EmployeeJournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("EmployeeJournal")] // One2many
    public virtual ICollection<HrExpensePostWizard> HrExpensePostWizard { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("InvoiceTemplatePdfReportId")]
    public virtual IrActReportXml? InvoiceTemplatePdfReport { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CurrentJournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CurrentJournal")] // One2many
    public virtual ICollection<L10nLatamCheck> L10nLatamCheck { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DestinationJournalId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("DestinationJournal")] // One2many
    public virtual ICollection<L10nLatamPaymentMassTransfer> L10nLatamPaymentMassTransfer { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("NonDeductibleAccountId")]
    public virtual AccountAccount? NonDeductibleAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountStockJournalId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("AccountStockJournal")] // One2many
    public virtual ICollection<ResCompany> ResCompanyAccountStockJournal { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PeppolSelfBillingReceptionJournalId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("PeppolSelfBillingReceptionJournal")] // One2many
    public virtual ICollection<ResCompany> ResCompanyPeppolSelfBillingReceptionJournal { get; set; }



}