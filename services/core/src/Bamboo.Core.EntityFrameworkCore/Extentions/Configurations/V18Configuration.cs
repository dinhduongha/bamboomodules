using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ApplyV18Configurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureAccountFiscalPositionTax();
            modelBuilder.ConfigureAccountPeppolServiceWizard();
            modelBuilder.ConfigureAccountReconcileModelPartnerMapping();
            modelBuilder.ConfigureBusPresence();
            modelBuilder.ConfigureCandidateSendMail();
            modelBuilder.ConfigureChatRoom();
            modelBuilder.ConfigureChooseDeliveryPackage();
            modelBuilder.ConfigureEventMeetingRoom();
            modelBuilder.ConfigureHrAttendanceOvertime();
            modelBuilder.ConfigureHrCandidate();
            modelBuilder.ConfigureHrCandidateSkill();
            modelBuilder.ConfigureHrContract();
            modelBuilder.ConfigureHrContractAdvantageTemplate();
            modelBuilder.ConfigureHrContributionRegister();
            modelBuilder.ConfigureHrEmployeeSkillLog();
            modelBuilder.ConfigureHrExpenseSheet();
            modelBuilder.ConfigureHrPayrollStructure();
            modelBuilder.ConfigureHrPayslip();
            modelBuilder.ConfigureHrPayslipEmployees();
            modelBuilder.ConfigureHrPayslipInput();
            modelBuilder.ConfigureHrPayslipLine();
            modelBuilder.ConfigureHrPayslipRun();
            modelBuilder.ConfigureHrPayslipWorkedDays();
            modelBuilder.ConfigureHrRuleInput();
            modelBuilder.ConfigureHrSalaryRule();
            modelBuilder.ConfigureHrSalaryRuleCategory();
            modelBuilder.ConfigureMailGroup();
            modelBuilder.ConfigureMailGroupMember();
            modelBuilder.ConfigureMailGroupMessage();
            modelBuilder.ConfigureMailGroupMessageReject();
            modelBuilder.ConfigureMailGroupModeration();
            modelBuilder.ConfigureMailResendMessage();
            modelBuilder.ConfigureMailResendPartner();
            modelBuilder.ConfigureMailWizardInvite();
            modelBuilder.ConfigureMembershipInvoice();
            modelBuilder.ConfigureMembershipMembershipLine();
            modelBuilder.ConfigureMrpBatchProduce();
            modelBuilder.ConfigurePaymentProviderOnboardingWizard();
            modelBuilder.ConfigurePayslipLinesContributionRegister();
            modelBuilder.ConfigureProcurementGroup();
            modelBuilder.ConfigureProductFetchImageWizard();
            modelBuilder.ConfigureProductPackaging();
            modelBuilder.ConfigureProjectCreateInvoice();
            modelBuilder.ConfigureResPartnerAutocompleteSync();
            modelBuilder.ConfigureResPartnerTitle();
            modelBuilder.ConfigureSaleOrderCancel();
            modelBuilder.ConfigureSaleOrderOption();
            modelBuilder.ConfigureSaleOrderTemplateOption();
            modelBuilder.ConfigureSalePaymentProviderOnboardingWizard();
            modelBuilder.ConfigureSmsResend();
            modelBuilder.ConfigureSmsResendRecipient();
            modelBuilder.ConfigureSnailmailLetterFormatError();
            modelBuilder.ConfigureSnailmailLetterMissingRequiredFields();
            modelBuilder.ConfigureStockChangeProductQty();
            modelBuilder.ConfigureStockPackageLevel();
            modelBuilder.ConfigureStockQuantPackage();
            modelBuilder.ConfigureStockTrackConfirmation();
            modelBuilder.ConfigureStockTrackLine();
            modelBuilder.ConfigureStockValuationLayer();
            modelBuilder.ConfigureStockValuationLayerRevaluation();
            modelBuilder.ConfigureUomCategory();
            modelBuilder.ConfigureWebEditorConverterTest();
            modelBuilder.ConfigureWebEditorConverterTestSub();
        }

        public static void ConfigureV18Compat(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountAccount>(entity =>
            {
                entity.Property(e => e.Deprecated).HasColumnName("deprecated");

                // entity.HasMany(d => d.AccountJournal).WithMany(p => p.AccountAccount)
                entity.HasMany<AccountJournal>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountAccountAccountJournalRel",
                        r => r.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("AccountJournalId")
                            .HasConstraintName("account_account_account_journal_rel_account_journal_id_fkey"),
                        l => l.HasOne<AccountAccount>().WithMany()
                            .HasForeignKey("AccountAccountId")
                            .HasConstraintName("account_account_account_journal_rel_account_account_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountAccountId", "AccountJournalId").HasName("account_account_account_journal_rel_pkey");
                            j.ToTable("account_account_account_journal_rel");
                            j.HasIndex(new[] { "AccountJournalId", "AccountAccountId" }, "account_account_account_journ_account_journal_id_account_ac_idx");
                            j.IndexerProperty<Guid>("AccountAccountId").HasColumnName("account_account_id");
                            j.IndexerProperty<Guid>("AccountJournalId").HasColumnName("account_journal_id");
                        });

            });

            modelBuilder.Entity<AccountAccountTag>(entity =>
            {
                entity.Property(e => e.TaxNegate).HasColumnName("tax_negate");

            });
            modelBuilder.Entity<AccountBankStatementLine>(entity =>
            {
                //entity.HasIndex(e => new { e.JournalId, e.TenantId, e.InternalIndex }, "account_bank_statement_line_unreconciled_idx").HasFilter("((NOT is_reconciled) OR (is_reconciled IS NULL))");

            });
            modelBuilder.Entity<AccountEdiProxyClientUser>(entity =>
            {
                // entity.HasIndex(e => new { e.EdiIdentification, e.ProxyType, e.EdiMode }, "account_edi_proxy_client_user_unique_active_edi_identification")
                //     .IsUnique()
                //     .HasFilter("(active = true)");
                entity.Property(e => e.PeppolVerificationCode).HasColumnName("peppol_verification_code");
            });
            modelBuilder.Entity<AccountFullReconcile>(entity =>
            {

                entity.HasIndex(e => e.ExchangeMoveId, "account_full_reconcile__exchange_move_id_index").HasFilter("(exchange_move_id IS NOT NULL)");
                entity.Property(e => e.ExchangeMoveId).HasColumnName("exchange_move_id");

                //entity.HasOne(d => d.ExchangeMove).WithMany(p => p.AccountFullReconcile)
                entity.HasOne(d => d.ExchangeMove).WithMany()
                    .HasForeignKey(d => d.ExchangeMoveId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_full_reconcile_exchange_move_id_fkey");

            });
            modelBuilder.Entity<AccountJournal>(entity =>
            {
                entity.Property(e => e.AutocheckOnPost).HasColumnName("autocheck_on_post");

                // entity.HasMany(d => d.Account1).WithMany(p => p.Journal)
                entity.HasMany(d => d.Account1).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "JournalAccountControlRel",
                        r => r.HasOne<AccountAccount>().WithMany()
                            .HasForeignKey("AccountId")
                            .HasConstraintName("journal_account_control_rel_account_id_fkey"),
                        l => l.HasOne<AccountJournal>().WithMany()
                            .HasForeignKey("JournalId")
                            .HasConstraintName("journal_account_control_rel_journal_id_fkey"),
                        j =>
                        {
                            j.HasKey("JournalId", "AccountId").HasName("journal_account_control_rel_pkey");
                            j.ToTable("journal_account_control_rel");
                            j.HasIndex(new[] { "AccountId", "JournalId" }, "journal_account_control_rel_account_id_journal_id_idx");
                            j.IndexerProperty<Guid>("JournalId").HasColumnName("journal_id");
                            j.IndexerProperty<Guid>("AccountId").HasColumnName("account_id");
                        });

            });
            modelBuilder.Entity<AccountLockException>(entity =>
            {
                //entity.HasIndex(e => new { e.TenantId, e.UserId, e.EndDatetime }, "account_lock_exception_company_id_end_datetime_idx").HasFilter("(active = true)");

            });
            modelBuilder.Entity<AccountMove>(entity =>
            {
                //entity.HasIndex(e => e.ExpenseSheetId, "account_move__expense_sheet_id_index").HasFilter("(expense_sheet_id IS NOT NULL)");
                //entity.HasIndex(e => e.StockMoveId, "account_move__stock_move_id_index").HasFilter("(stock_move_id IS NOT NULL)");
                //entity.HasIndex(e => e.JournalId, "account_move_checked_idx").HasFilter("(checked = false)");
                //entity.HasIndex(e => new { e.JournalId, e.TenantId, e.Date }, "account_move_made_gaps").HasFilter("(made_sequence_gap = true)");
                //entity.HasIndex(e => new { e.JournalId, e.TenantId, e.Date }, "account_move_made_gaps").HasFilter("(made_sequence_gap = true)");
                //entity.HasIndex(e => new { e.Name, e.JournalId }, "account_move_unique_name")
                //            .IsUnique()
                //            .HasFilter("((state = 'posted'::text) AND (name <> '/'::text))");

                entity.Property(e => e.ExpenseSheetId).HasColumnName("expense_sheet_id");
                entity.Property(e => e.IsStorno).HasColumnName("is_storno");
                entity.Property(e => e.StockMoveId).HasColumnName("stock_move_id");
                // CONFLICK-V19
                //entity.HasOne(d => d.ExpenseSheet).WithMany(p => p.AccountMove)
                // entity.HasOne(d => d.ExpenseSheet).WithMany()
                //     .HasForeignKey(d => d.ExpenseSheetId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("account_move_expense_sheet_id_fkey");

                // CONFLICK-V19
                //entity.HasOne(d => d.StockMove).WithMany(p => p.AccountMove)
                // entity.HasOne(d => d.StockMove).WithMany()
                //     .HasForeignKey(d => d.StockMoveId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("account_move_stock_move_id_fkey");

                // entity.HasMany(d => d.MrpProduction).WithMany(p => p.AccountMove)
                entity.HasMany(d => d.MrpProduction).WithMany(p => p.AccountMove)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountMoveMrpProductionRel",
                        r => r.HasOne<MrpProduction>().WithMany()
                            .HasForeignKey("MrpProductionId")
                            .HasConstraintName("account_move_mrp_production_rel_mrp_production_id_fkey"),
                        l => l.HasOne<AccountMove>().WithMany()
                            .HasForeignKey("AccountMoveId")
                            .HasConstraintName("account_move_mrp_production_rel_account_move_id_fkey"),
                        j =>
                        {
                            j.HasKey("AccountMoveId", "MrpProductionId").HasName("account_move_mrp_production_rel_pkey");
                            j.ToTable("account_move_mrp_production_rel");
                            j.HasIndex(new[] { "MrpProductionId", "AccountMoveId" }, "account_move_mrp_production_r_mrp_production_id_account_mov_idx");
                            j.IndexerProperty<Guid>("AccountMoveId").HasColumnName("account_move_id");
                            j.IndexerProperty<Guid>("MrpProductionId").HasColumnName("mrp_production_id");
                        });

            });
            modelBuilder.Entity<AccountMoveLine>(entity =>
            {
                entity.HasIndex(e => new { e.AccountId, e.PartnerId }, "account_move_line__unreconciled_index").HasFilter("(((reconciled IS NULL) OR (reconciled = false) OR (reconciled IS NOT TRUE)) AND (parent_state = 'posted'::text))");
                entity.HasIndex(e => e.JournalId, "account_move_line_journal_id_neg_amnt_residual_idx").HasFilter("((amount_residual < (0)::numeric) AND (parent_state = 'posted'::text))");
                entity.Property(e => e.TaxTagInvert).HasColumnName("tax_tag_invert");

            });
            modelBuilder.Entity<AccountMoveSendWizard>(entity =>
            {
                entity.Property(e => e.MailBody).HasColumnName("mail_body");
                entity.Property(e => e.MailSubject).HasColumnName("mail_subject");
                entity.Property(e => e.MailTemplateId).HasColumnName("mail_template_id");

                // CONFLICK-V19, Replace with TemplateId
                //entity.HasOne(d => d.MailTemplate).WithMany(p => p.AccountMoveSendWizard)
                // entity.HasOne(d => d.MailTemplate).WithMany()
                //     .HasForeignKey(d => d.MailTemplateId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("account_move_send_wizard_mail_template_id_fkey");

            });
            modelBuilder.Entity<AccountPaymentRegister>(entity =>
            {
                //entity.HasOne(d => d.WriteoffAccount).WithMany(p => p.AccountPaymentRegister)
                entity.HasOne(d => d.WriteoffAccount).WithMany()
                    .HasForeignKey(d => d.WriteoffAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_payment_register_writeoff_account_id_fkey");

            });
            modelBuilder.Entity<AccountReconcileModel>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.TenantId }, "account_reconcile_model_name_unique").IsUnique();

                entity.Property(e => e.AllowPaymentTolerance).HasColumnName("allow_payment_tolerance");
                entity.Property(e => e.AutoReconcile).HasColumnName("auto_reconcile");

                entity.Property(e => e.CounterpartType).HasColumnName("counterpart_type");
                entity.Property(e => e.DecimalSeparator).HasColumnName("decimal_separator");
                entity.Property(e => e.MatchNature).HasColumnName("match_nature");
                entity.Property(e => e.MatchNote).HasColumnName("match_note");
                entity.Property(e => e.MatchNoteParam).HasColumnName("match_note_param");
                entity.Property(e => e.MatchPartner).HasColumnName("match_partner");
                entity.Property(e => e.MatchSameCurrency).HasColumnName("match_same_currency");
                entity.Property(e => e.MatchTextLocationLabel).HasColumnName("match_text_location_label");
                entity.Property(e => e.MatchTextLocationNote).HasColumnName("match_text_location_note");
                entity.Property(e => e.MatchTextLocationReference).HasColumnName("match_text_location_reference");
                entity.Property(e => e.MatchTransactionType).HasColumnName("match_transaction_type");
                entity.Property(e => e.MatchTransactionTypeParam).HasColumnName("match_transaction_type_param");
                entity.Property(e => e.MatchingOrder).HasColumnName("matching_order");
                entity.Property(e => e.PastMonthsLimit).HasColumnName("past_months_limit");
                entity.Property(e => e.PaymentToleranceParam).HasColumnName("payment_tolerance_param");
                entity.Property(e => e.PaymentToleranceType).HasColumnName("payment_tolerance_type");
                entity.Property(e => e.RuleType).HasColumnName("rule_type");
                entity.Property(e => e.ToCheck).HasColumnName("to_check");

                // entity.HasMany(d => d.ResPartnerCategory).WithMany(p => p.AccountReconcileModel)
                entity.HasMany(d => d.ResPartnerCategory).WithMany(p => p.AccountReconcileModel)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountReconcileModelResPartnerCategoryRel",
                        r => r.HasOne<ResPartnerCategory>().WithMany()
                            .HasForeignKey("ResPartnerCategoryId")
                            .HasConstraintName("account_reconcile_model_res_partne_res_partner_category_id_fkey"),
                        l => l.HasOne<AccountReconcileModel>().WithMany()
                            .HasForeignKey("AccountReconcileModelId")
                            .HasConstraintName("account_reconcile_model_res_pa_account_reconcile_model_id_fkey1"),
                        j =>
                        {
                            j.HasKey("AccountReconcileModelId", "ResPartnerCategoryId").HasName("account_reconcile_model_res_partner_category_rel_pkey");
                            j.ToTable("account_reconcile_model_res_partner_category_rel");
                            j.HasIndex(new[] { "ResPartnerCategoryId", "AccountReconcileModelId" }, "account_reconcile_model_res_p_res_partner_category_id_accou_idx");
                            j.IndexerProperty<Guid>("AccountReconcileModelId").HasColumnName("account_reconcile_model_id");
                            j.IndexerProperty<Guid>("ResPartnerCategoryId").HasColumnName("res_partner_category_id");
                        });

            });
            modelBuilder.Entity<AccountReconcileModelLine>(entity =>
            {
                entity.Property(e => e.ForceTaxIncluded).HasColumnName("force_tax_included");
                entity.Property(e => e.JournalId).HasColumnName("journal_id");

                // entity.HasOne(d => d.Journal).WithMany(p => p.AccountReconcileModelLine) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("account_reconcile_model_line_journal_id_fkey");
                entity.HasOne(d => d.Journal).WithMany()
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_reconcile_model_line_journal_id_fkey");

            });
            modelBuilder.Entity<AccountReport>(entity =>
            {
                entity.Property(e => e.FilterFiscalPosition).HasColumnName("filter_fiscal_position");

            });
            modelBuilder.Entity<AccountReportExternalValue>(entity =>
            {
                entity.Property(e => e.ForeignVatFiscalPositionId).HasColumnName("foreign_vat_fiscal_position_id");
                //entity.HasOne(d => d.ForeignVatFiscalPosition).WithMany(p => p.AccountReportExternalValue)
                entity.HasOne(d => d.ForeignVatFiscalPosition).WithMany()
                    .HasForeignKey(d => d.ForeignVatFiscalPositionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_report_external_value_foreign_vat_fiscal_position__fkey");

            });
            modelBuilder.Entity<AccountSetupBankManualConfig>(entity =>
            {
                entity.Property(e => e.NumJournalsWithoutAccount).HasColumnName("num_journals_without_account");

            });
            modelBuilder.Entity<AccountTax>(entity =>
            {
                // CONFLICK-JSON
                //entity.Property(e => e.InvoiceLegalNotes).HasColumnName("invoice_legal_notes");

            });
            modelBuilder.Entity<AuthTotpRateLimitLog>(entity =>
            {
                entity.Property(e => e.Scope).HasColumnName("scope");

            });
            modelBuilder.Entity<AuthTotpWizard>(entity =>
            {
                entity.Property(e => e.Code).HasColumnName("code");

            });
            modelBuilder.Entity<BaseModuleUninstall>(entity =>
            {
                entity.Property(e => e.ModuleId).HasColumnName("module_id");
                // CONFLICK-V19
                //entity.HasOne(d => d.Module).WithMany(p => p.BaseModuleUninstall)
                // entity.HasOne(d => d.Module).WithMany()
                //     .HasForeignKey(d => d.ModuleId)
                //     .OnDelete(DeleteBehavior.Cascade)
                //     .HasConstraintName("base_module_uninstall_module_id_fkey");

            });
            modelBuilder.Entity<CalendarAlarm>(entity =>
            {
                entity.Property(e => e.SmsNotifyResponsible).HasColumnName("sms_notify_responsible");

            });
            modelBuilder.Entity<CalendarEvent>(entity =>
            {
                entity.HasIndex(e => e.CandidateId, "calendar_event__candidate_id_index").HasFilter("(candidate_id IS NOT NULL)");

                entity.Property(e => e.CandidateId).HasColumnName("candidate_id");

                //entity.HasOne(d => d.Candidate).WithMany(p => p.CalendarEvent)
                entity.HasOne(d => d.Candidate).WithMany()
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("calendar_event_candidate_id_fkey");

            });
            modelBuilder.Entity<CalendarPopoverDeleteWizard>(entity =>
            {
                entity.Property(e => e.Record).HasColumnName("record");
                // CONFLICK-V19
                // entity.HasOne(d => d.RecordNavigation).WithMany(p => p.CalendarPopoverDeleteWizard)
                //     .HasForeignKey(d => d.Record)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("calendar_popover_delete_wizard_record_fkey");

            });
            modelBuilder.Entity<CardTemplate>(entity =>
            {
                // CONFLICK-JSON
                //entity.Property(e => e.Name).HasColumnName("name");

            });
            modelBuilder.Entity<ChatbotMessage>(entity =>
            {
                //entity.HasIndex(e => e.MailMessageId, "chatbot_message__unique_mail_message_id").IsUnique();
                // Cascade => SetNull
                // entity.HasOne(d => d.MailMessage).WithOne(p => p.ChatbotMessage)
                //             .HasForeignKey<ChatbotMessage>(d => d.MailMessageId)
                //             .OnDelete(DeleteBehavior.Cascade)
                //             .HasConstraintName("chatbot_message_mail_message_id_fkey");

                // entity.HasOne(d => d.ScriptStep).WithMany(p => p.ChatbotMessage)
                //     .HasForeignKey(d => d.ScriptStepId)
                //     .OnDelete(DeleteBehavior.Cascade)
                //     .HasConstraintName("chatbot_message_script_step_id_fkey");

            });
            modelBuilder.Entity<CrmLead>(entity =>
            {
                entity.Property(e => e.Mobile).HasColumnName("mobile");
                entity.Property(e => e.Title).HasColumnName("title");
                //entity.HasOne(d => d.TitleNavigation).WithMany(p => p.CrmLead)
                entity.HasOne(d => d.TitleNavigation).WithMany()
                            .HasForeignKey(d => d.Title)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("crm_lead_title_fkey");

            });
            modelBuilder.Entity<CrmStage>(entity =>
            {
                entity.Property(e => e.TeamId).HasColumnName("team_id");

                // CONFLICK-V19
                //entity.HasOne(d => d.Team).WithMany(p => p.CrmStage)
                entity.HasOne(d => d.Team).WithMany()
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_stage_team_id_fkey");


            });
            modelBuilder.Entity<DiscussChannel>(entity =>
            {
                entity.Property(e => e.AllowPublicUpload).HasColumnName("allow_public_upload");
                entity.Property(e => e.AnonymousName).HasColumnName("anonymous_name");
                entity.Property(e => e.LivechatActive).HasColumnName("livechat_active");

            });
            modelBuilder.Entity<DiscussChannelMember>(entity =>
            {
                entity.Property(e => e.FoldState).HasColumnName("fold_state");

            });
            modelBuilder.Entity<EventBoothRegistration>(entity =>
            {
                entity.Property(e => e.SponsorMobile).HasColumnName("sponsor_mobile");

            });
            modelBuilder.Entity<EventEvent>(entity =>
            {
                entity.Property(e => e.KanbanStateLabel).HasColumnName("kanban_state_label");
                entity.Property(e => e.LocationMenu).HasColumnName("location_menu");
                entity.Property(e => e.MeetingRoomAllowCreation).HasColumnName("meeting_room_allow_creation");

            });
            modelBuilder.Entity<EventQuestion>(entity =>
            {
                entity.Property(e => e.EventId).HasColumnName("event_id");
                entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");

                //entity.HasOne(d => d.Event).WithMany(p => p.EventQuestion)
                entity.HasOne(d => d.Event).WithMany()
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("event_question_event_id_fkey");

                // CONFLICK-V19
                //entity.HasOne(d => d.EventType).WithMany(p => p.EventQuestion)
                // entity.HasOne(d => d.EventType).WithMany()
                //     .HasForeignKey(d => d.EventTypeId)
                //     .OnDelete(DeleteBehavior.Cascade)
                //     .HasConstraintName("event_question_event_type_id_fkey");
            });
            modelBuilder.Entity<EventSponsor>(entity =>
            {
                entity.Property(e => e.ChatRoomId).HasColumnName("chat_room_id");
                entity.Property(e => e.Mobile).HasColumnName("mobile");
                //entity.HasOne(d => d.ChatRoom).WithMany(p => p.EventSponsor)
                entity.HasOne(d => d.ChatRoom).WithMany()
                    .HasForeignKey(d => d.ChatRoomId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("event_sponsor_chat_room_id_fkey");

            });
            modelBuilder.Entity<EventStage>(entity =>
            {
                entity.Property(e => e.LegendBlocked)
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_blocked");
                entity.Property(e => e.LegendDone)
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_done");
                entity.Property(e => e.LegendNormal)
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_normal");

            });
            modelBuilder.Entity<EventType>(entity =>
            {
                entity.Property(e => e.MeetingRoomAllowCreation).HasColumnName("meeting_room_allow_creation");

            });
            modelBuilder.Entity<FetchmailServer>(entity =>
            {
                entity.Property(e => e.GoogleGmailAuthorizationCode).HasColumnName("google_gmail_authorization_code");
            });
            modelBuilder.Entity<FleetVehicle>(entity =>
            {
                entity.Property(e => e.FirstContractDate).HasColumnName("first_contract_date");

            });
            modelBuilder.Entity<FleetVehicleModelCategory>(entity =>
            {
                entity.Property(e => e.VolumeCapacity).HasColumnName("volume_capacity");
                entity.Property(e => e.WeightCapacity).HasColumnName("weight_capacity");

            });
            modelBuilder.Entity<FollowupFollowup>(entity =>
            {
                entity.HasIndex(e => e.TenantId, "followup_followup_company_uniq").IsUnique();
                // entity.HasOne(d => d.Company).WithOne(p => p.FollowupFollowup) .HasForeignKey<FollowupFollowup>(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("followup_followup_company_id_fkey");
                // CONFLICK-KEY
                //entity.HasOne(d => d.Company).WithOne(p => p.FollowupFollowup)
                entity.HasOne(d => d.Company).WithOne()
                    .HasForeignKey<FollowupFollowup>(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("followup_followup_company_id_fkey");

            });
            modelBuilder.Entity<FollowupLine>(entity =>
            {
                //entity.HasIndex(e => new { e.FollowupId, e.Delay }, "followup_line_days_uniq").IsUnique();

            });
            modelBuilder.Entity<ForumForum>(entity =>
            {
                entity.Property(e => e.Teaser).HasColumnName("teaser");

            });
            modelBuilder.Entity<HrApplicant>(entity =>
            {
                entity.HasIndex(e => e.CandidateId, "hr_applicant__candidate_id_index");
                entity.Property(e => e.CandidateId).HasColumnName("candidate_id");
                //entity.HasOne(d => d.Candidate).WithMany(p => p.HrApplicant)
                entity.HasOne(d => d.Candidate).WithMany()
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_applicant_candidate_id_fkey");


            });
            modelBuilder.Entity<HrAttendance>(entity =>
            {
                entity.Property(e => e.InCity).HasColumnName("in_city");
                entity.Property(e => e.InCountryName).HasColumnName("in_country_name");
                entity.Property(e => e.OutCity).HasColumnName("out_city");
                entity.Property(e => e.OutCountryName).HasColumnName("out_country_name");

            });
            modelBuilder.Entity<HrDepartment>(entity =>
            {
                entity.Property(e => e.CompleteName).HasColumnName("complete_name");

            });
            modelBuilder.Entity<HrDepartureReason>(entity =>
            {
                entity.Property(e => e.ReasonCode).HasColumnName("reason_code");

            });
            modelBuilder.Entity<HrDepartureWizard>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                //entity.HasOne(d => d.Employee).WithMany(p => p.HrDepartureWizard)
                entity.HasOne(d => d.Employee).WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("hr_departure_wizard_employee_id_fkey");

            });
            modelBuilder.Entity<HrEmployee>(entity =>
            {
                //entity.HasIndex(e => e.ResourceCalendarId, "hr_employee__resource_calendar_id_index");

                entity.Property(e => e.AdditionalNote).HasColumnName("additional_note");
                entity.Property(e => e.AddressId).HasColumnName("address_id");
                entity.Property(e => e.BankAccountId).HasColumnName("bank_account_id");
                entity.Property(e => e.Children).HasColumnName("children");
                entity.Property(e => e.ContractId).HasColumnName("contract_id");
                entity.Property(e => e.ContractWarning).HasColumnName("contract_warning");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                entity.Property(e => e.DepartureDate).HasColumnName("departure_date");
                entity.Property(e => e.DepartureDescription).HasColumnName("departure_description");
                entity.Property(e => e.DepartureReasonId).HasColumnName("departure_reason_id");
                entity.Property(e => e.DistanceHomeWork).HasColumnName("distance_home_work");
                entity.Property(e => e.DistanceHomeWorkUnit).HasColumnName("distance_home_work_unit");
                entity.Property(e => e.EmployeeType).HasColumnName("employee_type");
                entity.Property(e => e.FirstContractDate).HasColumnName("first_contract_date");
                entity.Property(e => e.Gender).HasColumnName("gender");
                entity.Property(e => e.IdentificationId).HasColumnName("identification_id");
                entity.Property(e => e.IsFlexible).HasColumnName("is_flexible");
                entity.Property(e => e.IsFullyFlexible).HasColumnName("is_fully_flexible");
                entity.Property(e => e.JobId).HasColumnName("job_id");
                entity.Property(e => e.JobTitle).HasColumnName("job_title");
                entity.Property(e => e.KmHomeWork).HasColumnName("km_home_work");
                entity.Property(e => e.Marital).HasColumnName("marital");
                entity.Property(e => e.Notes).HasColumnName("notes");
                entity.Property(e => e.PassportId).HasColumnName("passport_id");
                entity.Property(e => e.PrivateCity).HasColumnName("private_city");
                entity.Property(e => e.PrivateCountryId).HasColumnName("private_country_id");
                entity.Property(e => e.PrivateStateId).HasColumnName("private_state_id");
                entity.Property(e => e.PrivateStreet).HasColumnName("private_street");
                entity.Property(e => e.PrivateStreet2).HasColumnName("private_street2");
                entity.Property(e => e.PrivateZip).HasColumnName("private_zip");
                entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");
                entity.Property(e => e.Sinid).HasColumnName("sinid");
                entity.Property(e => e.SpouseBirthdate).HasColumnName("spouse_birthdate");
                entity.Property(e => e.SpouseCompleteName).HasColumnName("spouse_complete_name");
                entity.Property(e => e.Ssnid).HasColumnName("ssnid");
                entity.Property(e => e.Vehicle).HasColumnName("vehicle");
                entity.Property(e => e.WorkLocationId).HasColumnName("work_location_id");

                // entity.HasOne(d => d.Address).WithMany(p => p.HrEmployeeAddress) .HasForeignKey(d => d.AddressId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_address_id_fkey");
                // entity.HasOne(d => d.Address).WithMany()
                //     .HasForeignKey(d => d.AddressId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("hr_employee_address_id_fkey");

                // CONFLICK-V19
                // entity.HasOne(d => d.BankAccount).WithMany(p => p.HrEmployee)
                // //entity.HasOne(d => d.BankAccount).WithMany()
                //     .HasForeignKey(d => d.BankAccountId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("hr_employee_bank_account_id_fkey");

                // entity.HasOne(d => d.Contract).WithMany(p => p.HrEmployee)
                //     .HasForeignKey(d => d.ContractId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("hr_employee_contract_id_fkey");

                // entity.HasOne(d => d.Country).WithMany(p => p.HrEmployeeCountry) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_country_id_fkey");
                // entity.HasOne(d => d.Country).WithMany()
                //     .HasForeignKey(d => d.CountryId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("hr_employee_country_id_fkey");

                // entity.HasOne(d => d.Department).WithMany(p => p.HrEmployee)
                //     .HasForeignKey(d => d.DepartmentId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("hr_employee_department_id_fkey");

                // entity.HasOne(d => d.DepartureReason).WithMany(p => p.HrEmployee)
                //     .HasForeignKey(d => d.DepartureReasonId)
                //     .OnDelete(DeleteBehavior.Restrict)
                //     .HasConstraintName("hr_employee_departure_reason_id_fkey");

                // entity.HasOne(d => d.Job).WithMany(p => p.HrEmployee)
                //     .HasForeignKey(d => d.JobId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("hr_employee_job_id_fkey");

                // entity.HasOne(d => d.PrivateCountry).WithMany(p => p.HrEmployeePrivateCountry) .HasForeignKey(d => d.PrivateCountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_private_country_id_fkey");
                // entity.HasOne(d => d.PrivateCountry).WithMany()
                //     .HasForeignKey(d => d.PrivateCountryId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("hr_employee_private_country_id_fkey");

                // entity.HasOne(d => d.PrivateState).WithMany(p => p.HrEmployee) .HasForeignKey(d => d.PrivateStateId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_private_state_id_fkey");
                // entity.HasOne(d => d.PrivateState).WithMany()
                //     .HasForeignKey(d => d.PrivateStateId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("hr_employee_private_state_id_fkey");

                // entity.HasOne(d => d.ResourceCalendar).WithMany(p => p.HrEmployee)
                //     .HasForeignKey(d => d.ResourceCalendarId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("hr_employee_resource_calendar_id_fkey");

                // entity.HasOne(d => d.WorkLocation).WithMany(p => p.HrEmployeeWorkLocation)
                //     .HasForeignKey(d => d.WorkLocationId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("hr_employee_work_location_id_fkey");

            });
            modelBuilder.Entity<HrEmployeeSkill>(entity =>
            {
                //entity.HasIndex(e => new { e.EmployeeId, e.SkillId }, "hr_employee_skill__unique_skill").IsUnique();

            });
            modelBuilder.Entity<HrExpenseApproveDuplicate>(entity =>
            {
                // entity.HasMany(d => d.HrExpenseSheet).WithMany(p => p.HrExpenseApproveDuplicate)
                entity.HasMany(d => d.HrExpenseSheet).WithMany(p => p.HrExpenseApproveDuplicate)
                    .UsingEntity<Dictionary<string, object>>(
                        "HrExpenseApproveDuplicateHrExpenseSheetRel",
                        r => r.HasOne<HrExpenseSheet>().WithMany()
                            .HasForeignKey("HrExpenseSheetId")
                            .HasConstraintName("hr_expense_approve_duplicate_hr_expens_hr_expense_sheet_id_fkey"),
                        l => l.HasOne<HrExpenseApproveDuplicate>().WithMany()
                            .HasForeignKey("HrExpenseApproveDuplicateId")
                            .HasConstraintName("hr_expense_approve_duplicate__hr_expense_approve_duplicate_fkey"),
                        j =>
                        {
                            j.HasKey("HrExpenseApproveDuplicateId", "HrExpenseSheetId").HasName("hr_expense_approve_duplicate_hr_expense_sheet_rel_pkey");
                            j.ToTable("hr_expense_approve_duplicate_hr_expense_sheet_rel");
                            j.HasIndex(new[] { "HrExpenseSheetId", "HrExpenseApproveDuplicateId" }, "hr_expense_approve_duplicate__hr_expense_sheet_id_hr_expens_idx");
                            j.IndexerProperty<Guid>("HrExpenseApproveDuplicateId").HasColumnName("hr_expense_approve_duplicate_id");
                            j.IndexerProperty<Guid>("HrExpenseSheetId").HasColumnName("hr_expense_sheet_id");
                        });
            });
            modelBuilder.Entity<HrExpense>(entity =>
            {
                entity.HasIndex(e => e.SheetId, "hr_expense__sheet_id_index");
                entity.Property(e => e.AccountingDate).HasColumnName("accounting_date");
                entity.Property(e => e.SheetId).HasColumnName("sheet_id");

                //entity.HasOne(d => d.Sheet).WithMany(p => p.HrExpense)
                entity.HasOne(d => d.Sheet).WithMany()
                    .HasForeignKey(d => d.SheetId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_expense_sheet_id_fkey");

            });
            modelBuilder.Entity<HrExpenseRefuseWizard>(entity =>
            {
                // entity.HasMany(d => d.HrExpenseSheet).WithMany(p => p.HrExpenseRefuseWizard)
                // entity.HasMany(d => d.HrExpenseSheet).WithMany(p => p.HrExpenseRefuseWizard)
                //     .UsingEntity<Dictionary<string, object>>(
                //         "HrExpenseRefuseWizardHrExpenseSheetRel",
                //         r => r.HasOne<HrExpenseSheet>().WithMany()
                //             .HasForeignKey("HrExpenseSheetId")
                //             .HasConstraintName("hr_expense_refuse_wizard_hr_expense_sh_hr_expense_sheet_id_fkey"),
                //         l => l.HasOne<HrExpenseRefuseWizard>().WithMany()
                //             .HasForeignKey("HrExpenseRefuseWizardId")
                //             .HasConstraintName("hr_expense_refuse_wizard_hr_ex_hr_expense_refuse_wizard_id_fkey"),
                //         j =>
                //         {
                //             j.HasKey("HrExpenseRefuseWizardId", "HrExpenseSheetId").HasName("hr_expense_refuse_wizard_hr_expense_sheet_rel_pkey");
                //             j.ToTable("hr_expense_refuse_wizard_hr_expense_sheet_rel");
                //             j.HasIndex(new[] { "HrExpenseSheetId", "HrExpenseRefuseWizardId" }, "hr_expense_refuse_wizard_hr_e_hr_expense_sheet_id_hr_expens_idx");
                //             j.IndexerProperty<Guid>("HrExpenseRefuseWizardId").HasColumnName("hr_expense_refuse_wizard_id");
                //             j.IndexerProperty<Guid>("HrExpenseSheetId").HasColumnName("hr_expense_sheet_id");
                //         });
            });
            modelBuilder.Entity<HrJob>(entity =>
            {
                entity.Property(e => e.DateFrom).HasColumnName("date_from");
                entity.Property(e => e.DateTo).HasColumnName("date_to");
                entity.Property(e => e.ExpectedEmployees).HasColumnName("expected_employees");
                entity.Property(e => e.NoOfEmployee).HasColumnName("no_of_employee");

            });
            modelBuilder.Entity<HrLeaveAccrualLevel>(entity =>
            {
                entity.Property(e => e.FrequencyHourlySource).HasColumnName("frequency_hourly_source");

            });
            modelBuilder.Entity<HrLeaveAllocation>(entity =>
            {
                entity.Property(e => e.OvertimeId).HasColumnName("overtime_id");
                // entity.HasOne(d => d.Overtime).WithMany(p => p.HrLeaveAllocation)
                //     .HasForeignKey(d => d.OvertimeId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("hr_leave_allocation_overtime_id_fkey");

            });
            modelBuilder.Entity<HrLeave>(entity =>
            {
                entity.Property(e => e.ManagerId).HasColumnName("manager_id");
                entity.Property(e => e.OvertimeId).HasColumnName("overtime_id");

                //entity.HasOne(d => d.Manager).WithMany(p => p.HrLeaveManager)
                entity.HasOne(d => d.Manager).WithMany()
                    .HasForeignKey(d => d.ManagerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_manager_id_fkey");

                //entity.HasOne(d => d.Overtime).WithMany(p => p.HrLeave)
                entity.HasOne(d => d.Overtime).WithMany()
                    .HasForeignKey(d => d.OvertimeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_overtime_id_fkey");

            });
            modelBuilder.Entity<HrLeaveType>(entity =>
            {
                entity.Property(e => e.Code).HasColumnName("code");
                entity.Property(e => e.ShowOnDashboard).HasColumnName("show_on_dashboard");
                entity.Property(e => e.TimesheetGenerate).HasColumnName("timesheet_generate");
                entity.Property(e => e.TimesheetProjectId).HasColumnName("timesheet_project_id");
                entity.Property(e => e.TimesheetTaskId).HasColumnName("timesheet_task_id");

                //entity.HasOne(d => d.TimesheetProject).WithMany(p => p.HrLeaveType)
                entity.HasOne(d => d.TimesheetProject).WithMany()
                    .HasForeignKey(d => d.TimesheetProjectId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_type_timesheet_project_id_fkey");

                //entity.HasOne(d => d.TimesheetTask).WithMany(p => p.HrLeaveType)
                entity.HasOne(d => d.TimesheetTask).WithMany()
                    .HasForeignKey(d => d.TimesheetTaskId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_leave_type_timesheet_task_id_fkey");

            });
            modelBuilder.Entity<HrResumeLine>(entity =>
            {
                entity.Property(e => e.DisplayType).HasColumnName("display_type");

            });
            modelBuilder.Entity<HrWorkEntry>(entity =>
            {
                //entity.HasIndex(e => new { e.ContractId, e.DateStart, e.DateStop }, "hr_work_entry_contract_date_start_stop_idx").HasFilter("(state = ANY (ARRAY[('draft'::character varying)::text, ('validated'::character varying)::text]))");

                entity.HasIndex(e => new { e.DateStart, e.DateStop }, "hr_work_entry_date_start_date_stop_index");
                entity.Property(e => e.ContractId).HasColumnName("contract_id");
                entity.Property(e => e.DateStart)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_start");
                entity.Property(e => e.DateStop)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_stop");

                //entity.HasOne(d => d.Contract).WithMany(p => p.HrWorkEntry)
                entity.HasOne(d => d.Contract).WithMany()
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_work_entry_contract_id_fkey");

            });
            modelBuilder.Entity<ImLivechatChannel>(entity =>
            {
                entity.HasIndex(e => e.IsPublished, "im_livechat_channel__is_published_index");

                entity.Property(e => e.InputPlaceholder)
                            .HasColumnType("jsonb")
                            .HasColumnName("input_placeholder");
                entity.Property(e => e.IsPublished).HasColumnName("is_published");
                entity.Property(e => e.WebsiteDescription)
                            .HasColumnType("jsonb")
                            .HasColumnName("website_description");
                // entity.HasMany(d => d.User).WithMany(p => p.Channel)
                entity.HasMany(d => d.User).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ImLivechatChannelImUser",
                        r => r.HasOne<ResUsers>().WithMany()
                            .HasForeignKey("UserId")
                            .HasConstraintName("im_livechat_channel_im_user_user_id_fkey"),
                        l => l.HasOne<ImLivechatChannel>().WithMany()
                            .HasForeignKey("ChannelId")
                            .HasConstraintName("im_livechat_channel_im_user_channel_id_fkey"),
                        j =>
                        {
                            j.HasKey("ChannelId", "UserId").HasName("im_livechat_channel_im_user_pkey");
                            j.ToTable("im_livechat_channel_im_user");
                            j.HasIndex(new[] { "UserId", "ChannelId" }, "im_livechat_channel_im_user_user_id_channel_id_idx");
                            j.IndexerProperty<Guid>("ChannelId").HasColumnName("channel_id");
                            j.IndexerProperty<Guid>("UserId").HasColumnName("user_id");
                        });


            });
            modelBuilder.Entity<ImLivechatChannelRule>(entity =>
            {
                entity.Property(e => e.ChatbotOnlyIfNoOperator).HasColumnName("chatbot_only_if_no_operator");

            });
            modelBuilder.Entity<IrActServer>(entity =>
            {
                entity.Property(e => e.ModelName).HasColumnName("model_name");
                // entity.HasMany(d => d.Action).WithMany(p => p.Server)
                entity.HasMany(d => d.Action).WithMany(p => p.Server)
                    .UsingEntity<Dictionary<string, object>>(
                        "RelServerActions",
                        r => r.HasOne<IrActServer>().WithMany()
                            .HasForeignKey("ActionId")
                            .HasConstraintName("rel_server_actions_action_id_fkey"),
                        l => l.HasOne<IrActServer>().WithMany()
                            .HasForeignKey("ServerId")
                            .HasConstraintName("rel_server_actions_server_id_fkey"),
                        j =>
                        {
                            j.HasKey("ServerId", "ActionId").HasName("rel_server_actions_pkey");
                            j.ToTable("rel_server_actions");
                            j.HasIndex(new[] { "ActionId", "ServerId" }, "rel_server_actions_action_id_server_id_idx");
                            j.IndexerProperty<Guid>("ServerId").HasColumnName("server_id");
                            j.IndexerProperty<Guid>("ActionId").HasColumnName("action_id");
                        });
                // entity.HasMany(d => d.Server).WithMany(p => p.Action)
                entity.HasMany(d => d.Server).WithMany(p => p.Action)
                    .UsingEntity<Dictionary<string, object>>(
                        "RelServerActions",
                        r => r.HasOne<IrActServer>().WithMany()
                            .HasForeignKey("ServerId")
                            .HasConstraintName("rel_server_actions_server_id_fkey"),
                        l => l.HasOne<IrActServer>().WithMany()
                            .HasForeignKey("ActionId")
                            .HasConstraintName("rel_server_actions_action_id_fkey"),
                        j =>
                        {
                            j.HasKey("ServerId", "ActionId").HasName("rel_server_actions_pkey");
                            j.ToTable("rel_server_actions");
                            j.HasIndex(new[] { "ActionId", "ServerId" }, "rel_server_actions_action_id_server_id_idx");
                            j.IndexerProperty<Guid>("ServerId").HasColumnName("server_id");
                            j.IndexerProperty<Guid>("ActionId").HasColumnName("action_id");
                        });

            });
            modelBuilder.Entity<IrActWindowView>(entity =>
            {
                entity.HasIndex(e => new { e.ActWindowId, e.ViewMode }, "act_window_view_unique_mode_per_action").IsUnique();

            });
            modelBuilder.Entity<IrFilters>(entity =>
            {
                entity.HasIndex(e => new { e.ModelId, e.UserId, e.ActionId, e.EmbeddedActionId, e.EmbeddedParentResId, e.Name }, "ir_filters_name_model_uid_unique").IsUnique();
                entity.Property(e => e.UserId).HasColumnName("user_id");
                // entity.HasOne(d => d.User).WithMany(p => p.IrFiltersUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("ir_filters_user_id_fkey");
                // entity.HasOne(d => d.User).WithMany()
                //     .HasForeignKey(d => d.UserId)
                //     .OnDelete(DeleteBehavior.Cascade)
                //     .HasConstraintName("ir_filters_user_id_fkey");

            });
            modelBuilder.Entity<IrMailServer>(entity =>
            {
                entity.Property(e => e.GoogleGmailAuthorizationCode).HasColumnName("google_gmail_authorization_code");

            });
            modelBuilder.Entity<IrModel>(entity =>
            {
                // CONFLICK-JSON
                //entity.Property(e => e.WebsiteFormLabel).HasColumnName("website_form_label");

            });
            modelBuilder.Entity<IrModelConstraint>(entity =>
            {
                entity.HasIndex(e => e.Type, "ir_model_constraint__type_index");

            });
            modelBuilder.Entity<IrModelFields>(entity =>
            {
                entity.HasIndex(e => e.CompleteName, "ir_model_fields__complete_name_index");
                entity.Property(e => e.CompleteName).HasColumnName("complete_name");

            });
            modelBuilder.Entity<IrRule>(entity =>
            {
                entity.HasIndex(e => e.Name, "ir_rule__name_index");
                //Restrict = > None
                // entity.HasMany(d => d.Group).WithMany(p => p.RuleGroup)
                // entity.HasMany(d => d.Group).WithMany(p => p.RuleGroup)
                //     .UsingEntity<Dictionary<string, object>>(
                //         "RuleGroupRel",
                //         r => r.HasOne<ResGroups>().WithMany()
                //             .HasForeignKey("GroupId")
                //             .OnDelete(DeleteBehavior.Restrict)
                //             .HasConstraintName("rule_group_rel_group_id_fkey"),
                //         l => l.HasOne<IrRule>().WithMany()
                //             .HasForeignKey("RuleGroupId")
                //             .HasConstraintName("rule_group_rel_rule_group_id_fkey"),
                //         j =>
                //         {
                //             j.HasKey("RuleGroupId", "GroupId").HasName("rule_group_rel_pkey");
                //             j.ToTable("rule_group_rel");
                //             j.HasIndex(new[] { "GroupId", "RuleGroupId" }, "rule_group_rel_group_id_rule_group_id_idx");
                //             j.IndexerProperty<Guid>("RuleGroupId").HasColumnName("rule_group_id");
                //             j.IndexerProperty<Guid>("GroupId").HasColumnName("group_id");
                //         });
            });
            modelBuilder.Entity<LoyaltyReward>(entity =>
            {
                // entity.HasMany(d => d.AccountTax).WithMany(p => p.LoyaltyReward)
                entity.HasMany(d => d.AccountTax).WithMany(p => p.LoyaltyReward)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountTaxLoyaltyRewardRel",
                        r => r.HasOne<AccountTax>().WithMany()
                            .HasForeignKey("AccountTaxId")
                            .HasConstraintName("account_tax_loyalty_reward_rel_account_tax_id_fkey"),
                        l => l.HasOne<LoyaltyReward>().WithMany()
                            .HasForeignKey("LoyaltyRewardId")
                            .HasConstraintName("account_tax_loyalty_reward_rel_loyalty_reward_id_fkey"),
                        j =>
                        {
                            j.HasKey("LoyaltyRewardId", "AccountTaxId").HasName("account_tax_loyalty_reward_rel_pkey");
                            j.ToTable("account_tax_loyalty_reward_rel");
                            j.HasIndex(new[] { "AccountTaxId", "LoyaltyRewardId" }, "account_tax_loyalty_reward_re_account_tax_id_loyalty_reward_idx");
                            j.IndexerProperty<Guid>("LoyaltyRewardId").HasColumnName("loyalty_reward_id");
                            j.IndexerProperty<Guid>("AccountTaxId").HasColumnName("account_tax_id");
                        });

            });
            modelBuilder.Entity<MailActivityType>(entity =>
            {
                entity.Property(e => e.KeepDone).HasColumnName("keep_done");

            });
            modelBuilder.Entity<MailCannedResponse>(entity =>
            {
                entity.Property(e => e.Description).HasColumnName("description");

            });
            modelBuilder.Entity<MailComposeMessage>(entity =>
            {
                entity.Property(e => e.RecordName).HasColumnName("record_name");

            });
            modelBuilder.Entity<MailLinkPreview>(entity =>
            {
                entity.HasIndex(e => e.MessageId, "mail_link_preview__message_id_index");
                entity.Property(e => e.IsHidden).HasColumnName("is_hidden");
                entity.Property(e => e.MessageId).HasColumnName("message_id");

                // entity.HasOne(d => d.Message).WithMany(p => p.MailLinkPreview)
                //     .HasForeignKey(d => d.MessageId)
                //     .OnDelete(DeleteBehavior.Cascade)
                //     .HasConstraintName("mail_link_preview_message_id_fkey");

            });
            modelBuilder.Entity<MailMessage>(entity =>
            {
                entity.Property(e => e.RecordName).HasColumnName("record_name");

            });
            modelBuilder.Entity<MailNotification>(entity =>
            {
                // entity.HasIndex(e => new { e.ResPartnerId, e.IsRead, e.NotificationStatus, e.MailMessageId }, "mail_notification_res_partner_id_is_read_notification_status_ma");

                // entity.HasIndex(e => new { e.MailMessageId, e.ResPartnerId }, "unique_mail_message_id_res_partner_id_if_set")
                //     .IsUnique()
                //     .HasFilter("(res_partner_id IS NOT NULL)");

            });
            modelBuilder.Entity<MailingContact>(entity =>
            {
                entity.Property(e => e.TitleId).HasColumnName("title_id");

                // entity.HasOne(d => d.Title).WithMany(p => p.MailingContact)
                //     .HasForeignKey(d => d.TitleId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("mailing_contact_title_id_fkey");

            });
            modelBuilder.Entity<MaintenanceEquipmentCategory>(entity =>
            {
                entity.Property(e => e.AliasId).HasColumnName("alias_id");

                // entity.HasOne(d => d.Alias).WithMany(p => p.MaintenanceEquipmentCategory)
                //     .HasForeignKey(d => d.AliasId)
                //     .OnDelete(DeleteBehavior.Restrict)
                //     .HasConstraintName("maintenance_equipment_category_alias_id_fkey");

            });
            modelBuilder.Entity<MaintenanceEquipment>(entity =>
            {
                //entity.Property(e => e.Location).HasColumnName("location");

            });
            modelBuilder.Entity<MrpBomLine>(entity =>
            {
                entity.Property(e => e.ManualConsumption).HasColumnName("manual_consumption");

            });
            modelBuilder.Entity<MrpProduction>(entity =>
            {
                entity.Property(e => e.LotProducingId).HasColumnName("lot_producing_id");
                entity.Property(e => e.ProcurementGroupId).HasColumnName("procurement_group_id");

                //entity.HasOne(d => d.LotProducing).WithMany(p => p.MrpProduction)
                entity.HasOne(d => d.LotProducing).WithMany()
                    .HasForeignKey(d => d.LotProducingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_lot_producing_id_fkey");

                //entity.HasOne(d => d.ProcurementGroup).WithMany(p => p.MrpProduction)
                entity.HasOne(d => d.ProcurementGroup).WithMany()
                    .HasForeignKey(d => d.ProcurementGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_production_procurement_group_id_fkey");

            });
            modelBuilder.Entity<MrpProductionSplit>(entity =>
            {
                entity.Property(e => e.Counter).HasColumnName("counter");

            });
            modelBuilder.Entity<MrpRoutingWorkcenter>(entity =>
            {
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.WorksheetGoogleSlide).HasColumnName("worksheet_google_slide");
                entity.Property(e => e.WorksheetType).HasColumnName("worksheet_type");

            });
            modelBuilder.Entity<MrpWorkcenterCapacity>(entity =>
            {
                //entity.HasIndex(e => new { e.WorkcenterId, e.ProductId }, "mrp_workcenter_capacity_unique_product").IsUnique();

                //Restrict=>SetNull
                // entity.HasOne(d => d.Product).WithMany(p => p.MrpWorkcenterCapacity) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mrp_workcenter_capacity_product_id_fkey");
                // entity.HasOne(d => d.Product).WithMany()
                //     .HasForeignKey(d => d.ProductId)
                //     .OnDelete(DeleteBehavior.Restrict)
                //     .HasConstraintName("mrp_workcenter_capacity_product_id_fkey");

            });
            modelBuilder.Entity<MrpWorkcenter>(entity =>
            {
                entity.Property(e => e.DefaultCapacity).HasColumnName("default_capacity");

            });
            modelBuilder.Entity<MrpWorkcenterProductivity>(entity =>
            {
                entity.Property(e => e.LossType).HasColumnName("loss_type");

            });
            modelBuilder.Entity<MrpWorkcenterProductivityLoss>(entity =>
            {
                entity.Property(e => e.LossType).HasColumnName("loss_type");

            });
            modelBuilder.Entity<MrpWorkorder>(entity =>
            {
                entity.Property(e => e.ProductId).HasColumnName("product_id");
                entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                // entity.HasOne(d => d.Product).WithMany(p => p.MrpWorkorder) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_workorder_product_id_fkey");
                // entity.HasOne(d => d.Product).WithMany()
                //     .HasForeignKey(d => d.ProductId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("mrp_workorder_product_id_fkey");

                // entity.HasOne(d => d.ProductUom).WithMany(p => p.MrpWorkorder) .HasForeignKey(d => d.ProductUomId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mrp_workorder_product_uom_id_fkey");
                // entity.HasOne(d => d.ProductUom).WithMany()
                //     .HasForeignKey(d => d.ProductUomId)
                //     .OnDelete(DeleteBehavior.Restrict)
                //     .HasConstraintName("mrp_workorder_product_uom_id_fkey");

            });
            modelBuilder.Entity<PaymentProvider>(entity =>
            {
                entity.Property(e => e.AuthorizeClientKey).HasColumnName("authorize_client_key");
                entity.Property(e => e.AuthorizeLogin).HasColumnName("authorize_login");
                entity.Property(e => e.AuthorizeSignatureKey).HasColumnName("authorize_signature_key");
                entity.Property(e => e.AuthorizeTransactionKey).HasColumnName("authorize_transaction_key");


            });
            modelBuilder.Entity<PaymentToken>(entity =>
            {
                entity.Property(e => e.AuthorizeProfile).HasColumnName("authorize_profile");

            });
            modelBuilder.Entity<PeppolRegistration>(entity =>
            {
                entity.Property(e => e.SmpRegistration).HasColumnName("smp_registration");

            });
            modelBuilder.Entity<PosBill>(entity =>
            {
                entity.Property(e => e.ForAllConfig).HasColumnName("for_all_config");

            });
            modelBuilder.Entity<PosConfig>(entity =>
            {
                entity.Property(e => e.CustomerDisplayType).HasColumnName("customer_display_type");
                entity.Property(e => e.ModulePosRestaurantAppointment).HasColumnName("module_pos_restaurant_appointment");
                entity.Property(e => e.OrderlinesSequenceInCartByCategory).HasColumnName("orderlines_sequence_in_cart_by_category");
                entity.Property(e => e.SelfOrderingTakeaway).HasColumnName("self_ordering_takeaway");
                entity.Property(e => e.SequenceId).HasColumnName("sequence_id");
                entity.Property(e => e.SequenceLineId).HasColumnName("sequence_line_id");
                entity.Property(e => e.Takeaway).HasColumnName("takeaway");
                entity.Property(e => e.TakeawayFpId).HasColumnName("takeaway_fp_id");

                // CONFLICK-V19
                // entity.HasOne(d => d.DefaultFiscalPosition).WithMany(p => p.PosConfigDefaultFiscalPosition)
                //     .HasForeignKey(d => d.DefaultFiscalPositionId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("pos_config_default_fiscal_position_id_fkey");

                entity.HasOne(d => d.Sequence).WithMany(p => p.PosConfigSequence)
                    .HasForeignKey(d => d.SequenceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_config_sequence_id_fkey");

                // entity.HasOne(d => d.SequenceLine).WithMany(p => p.PosConfigSequenceLine)
                //     .HasForeignKey(d => d.SequenceLineId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("pos_config_sequence_line_id_fkey");

                entity.HasOne(d => d.TakeawayFp).WithMany(p => p.PosConfigTakeawayFp)
                    .HasForeignKey(d => d.TakeawayFpId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_takeaway_fp_id_fkey");

                // entity.HasMany(d => d.Printer).WithMany(p => p.Config)
                // entity.HasMany(d => d.Printer).WithMany(p => p.Config)
                //     .UsingEntity<Dictionary<string, object>>(
                //         "PosConfigPrinterRel",
                //         r => r.HasOne<PosPrinter>().WithMany()
                //             .HasForeignKey("PrinterId")
                //             .HasConstraintName("pos_config_printer_rel_printer_id_fkey"),
                //         l => l.HasOne<PosConfig>().WithMany()
                //             .HasForeignKey("ConfigId")
                //             .HasConstraintName("pos_config_printer_rel_config_id_fkey"),
                //         j =>
                //         {
                //             j.HasKey("ConfigId", "PrinterId").HasName("pos_config_printer_rel_pkey");
                //             j.ToTable("pos_config_printer_rel");
                //             j.HasIndex(new[] { "PrinterId", "ConfigId" }, "pos_config_printer_rel_printer_id_config_id_idx");
                //             j.IndexerProperty<Guid>("ConfigId").HasColumnName("config_id");
                //             j.IndexerProperty<Guid>("PrinterId").HasColumnName("printer_id");
                //         });

            });
            modelBuilder.Entity<PosOrder>(entity =>
            {
                entity.Property(e => e.GeneralNote).HasColumnName("general_note");
                entity.Property(e => e.ProcurementGroupId).HasColumnName("procurement_group_id");
                entity.Property(e => e.Takeaway).HasColumnName("takeaway");

                // entity.HasOne(d => d.ProcurementGroup).WithMany(p => p.PosOrder)
                //     .HasForeignKey(d => d.ProcurementGroupId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("pos_order_procurement_group_id_fkey");

                // entity.HasOne(d => d.Table).WithMany(p => p.PosOrder)
                //     .HasForeignKey(d => d.TableId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("pos_order_table_id_fkey");

            });
            modelBuilder.Entity<PosOrderLine>(entity =>
            {
                entity.Property(e => e.SkipChange).HasColumnName("skip_change");


            });
            modelBuilder.Entity<PosSession>(entity =>
            {
                entity.HasIndex(e => e.Name, "pos_session_uniq_name").IsUnique();

                entity.Property(e => e.LoginNumber).HasColumnName("login_number");
                entity.Property(e => e.SequenceNumber).HasColumnName("sequence_number");

            });
            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.Property(e => e.PropertyAccountCreditorPriceDifferenceCateg)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_account_creditor_price_difference_categ");
                entity.Property(e => e.PropertyAccountDownpaymentCategId)
                    .HasColumnType("jsonb")
                    .HasColumnName("property_account_downpayment_categ_id");

                entity.Property(e => e.PropertyStockAccountInputCategId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_stock_account_input_categ_id");
                entity.Property(e => e.PropertyStockAccountOutputCategId)
                    .HasColumnType("jsonb")
                    .HasColumnName("property_stock_account_output_categ_id");

            });
            modelBuilder.Entity<ProductProduct>(entity =>
            {
                entity.Property(e => e.ImageFetchPending).HasColumnName("image_fetch_pending");

            });
            modelBuilder.Entity<ProductTag>(entity =>
            {
                entity.Property(e => e.VisibleOnEcommerce).HasColumnName("visible_on_ecommerce");

            });
            modelBuilder.Entity<ProductTemplate>(entity =>
            {
                entity.Property(e => e.CreateRepair).HasColumnName("create_repair");
                entity.Property(e => e.Membership).HasColumnName("membership");
                entity.Property(e => e.MembershipDateFrom).HasColumnName("membership_date_from");
                entity.Property(e => e.MembershipDateTo).HasColumnName("membership_date_to");
                entity.Property(e => e.PropertyAccountCreditorPriceDifference)
                    .HasColumnType("jsonb")
                    .HasColumnName("property_account_creditor_price_difference");
                entity.Property(e => e.PurchaseLineWarn).HasColumnName("purchase_line_warn");
                entity.Property(e => e.SaleLineWarn).HasColumnName("sale_line_warn");
                entity.Property(e => e.UomPoId).HasColumnName("uom_po_id");

                // // entity.HasOne(d => d.Uom).WithMany(p => p.ProductTemplateUom) .HasForeignKey(d => d.UomId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("product_template_uom_id_fkey");
                // entity.HasOne(d => d.Uom).WithMany()
                //     .HasForeignKey(d => d.UomId)
                //     .OnDelete(DeleteBehavior.Restrict)
                //     .HasConstraintName("product_template_uom_id_fkey");

                // entity.HasOne(d => d.UomPo).WithMany(p => p.ProductTemplateUomPo) .HasForeignKey(d => d.UomPoId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("product_template_uom_po_id_fkey");
                // entity.HasOne(d => d.UomPo).WithMany()
                //     .HasForeignKey(d => d.UomPoId)
                //     .OnDelete(DeleteBehavior.Restrict)
                //     .HasConstraintName("product_template_uom_po_id_fkey");

                // // entity.HasMany(d => d.Dest).WithMany(p => p.Src)
                // entity.HasMany(d => d.Dest).WithMany()
                //     .UsingEntity<Dictionary<string, object>>(
                //         "ProductAccessoryRel",
                //         r => r.HasOne<ProductProduct>().WithMany()
                //             .HasForeignKey("DestId")
                //             .HasConstraintName("product_accessory_rel_dest_id_fkey"),
                //         l => l.HasOne<ProductTemplate>().WithMany()
                //             .HasForeignKey("SrcId")
                //             .HasConstraintName("product_accessory_rel_src_id_fkey"),
                //         j =>
                //         {
                //             j.HasKey("SrcId", "DestId").HasName("product_accessory_rel_pkey");
                //             j.ToTable("product_accessory_rel");
                //             j.HasIndex(new[] { "DestId", "SrcId" }, "product_accessory_rel_dest_id_src_id_idx");
                //             j.IndexerProperty<Guid>("SrcId").HasColumnName("src_id");
                //             j.IndexerProperty<Guid>("DestId").HasColumnName("dest_id");
                //         });

                // entity.HasMany(d => d.DestNavigation).WithMany(p => p.Src)
                // entity.HasMany(d => d.DestNavigation).WithMany(p => p.Src)
                //     .UsingEntity<Dictionary<string, object>>(
                //         "ProductAlternativeRel",
                //         r => r.HasOne<ProductTemplate>().WithMany()
                //             .HasForeignKey("DestId")
                //             .HasConstraintName("product_alternative_rel_dest_id_fkey"),
                //         l => l.HasOne<ProductTemplate>().WithMany()
                //             .HasForeignKey("SrcId")
                //             .HasConstraintName("product_alternative_rel_src_id_fkey"),
                //         j =>
                //         {
                //             j.HasKey("SrcId", "DestId").HasName("product_alternative_rel_pkey");
                //             j.ToTable("product_alternative_rel");
                //             j.HasIndex(new[] { "DestId", "SrcId" }, "product_alternative_rel_dest_id_src_id_idx");
                //             j.IndexerProperty<Guid>("SrcId").HasColumnName("src_id");
                //             j.IndexerProperty<Guid>("DestId").HasColumnName("dest_id");
                //         });

                // entity.HasMany(d => d.Src).WithMany(p => p.DestNavigation)
                // entity.HasMany(d => d.Src).WithMany(p => p.DestNavigation)
                //     .UsingEntity<Dictionary<string, object>>(
                //         "ProductAlternativeRel",
                //         r => r.HasOne<ProductTemplate>().WithMany()
                //             .HasForeignKey("SrcId")
                //             .HasConstraintName("product_alternative_rel_src_id_fkey"),
                //         l => l.HasOne<ProductTemplate>().WithMany()
                //             .HasForeignKey("DestId")
                //             .HasConstraintName("product_alternative_rel_dest_id_fkey"),
                //         j =>
                //         {
                //             j.HasKey("SrcId", "DestId").HasName("product_alternative_rel_pkey");
                //             j.ToTable("product_alternative_rel");
                //             j.HasIndex(new[] { "DestId", "SrcId" }, "product_alternative_rel_dest_id_src_id_idx");
                //             j.IndexerProperty<Guid>("SrcId").HasColumnName("src_id");
                //             j.IndexerProperty<Guid>("DestId").HasColumnName("dest_id");
                //         });

                // // entity.HasMany(d => d.SrcNavigation).WithMany(p => p.Dest1)
                // entity.HasMany(d => d.SrcNavigation).WithMany(p => p.Dest1)
                //     .UsingEntity<Dictionary<string, object>>(
                //         "ProductOptionalRel",
                //         r => r.HasOne<ProductTemplate>().WithMany()
                //             .HasForeignKey("SrcId")
                //             .HasConstraintName("product_optional_rel_src_id_fkey"),
                //         l => l.HasOne<ProductTemplate>().WithMany()
                //             .HasForeignKey("DestId")
                //             .HasConstraintName("product_optional_rel_dest_id_fkey"),
                //         j =>
                //         {
                //             j.HasKey("SrcId", "DestId").HasName("product_optional_rel_pkey");
                //             j.ToTable("product_optional_rel");
                //             j.HasIndex(new[] { "DestId", "SrcId" }, "product_optional_rel_dest_id_src_id_idx");
                //             j.IndexerProperty<Guid>("SrcId").HasColumnName("src_id");
                //             j.IndexerProperty<Guid>("DestId").HasColumnName("dest_id");
                //         });


            });
            modelBuilder.Entity<ProjectProject>(entity =>
            {
                entity.Property(e => e.RatingActive).HasColumnName("rating_active");
                entity.Property(e => e.RatingRequestDeadline)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("rating_request_deadline");
                entity.Property(e => e.RatingStatus).HasColumnName("rating_status");
                entity.Property(e => e.RatingStatusPeriod).HasColumnName("rating_status_period");


            });
            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.MailReceptionConfirmed).HasColumnName("mail_reception_confirmed");
                entity.Property(e => e.MailReceptionDeclined).HasColumnName("mail_reception_declined");
                entity.Property(e => e.MailReminderConfirmed).HasColumnName("mail_reminder_confirmed");
                entity.Property(e => e.Notes).HasColumnName("notes");

                // entity.HasOne(d => d.Group).WithMany(p => p.PurchaseOrder)
                //     .HasForeignKey(d => d.GroupId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("purchase_order_group_id_fkey");

            });
            modelBuilder.Entity<PurchaseOrderLine>(entity =>
            {
                entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.ProductPackagingId).HasColumnName("product_packaging_id");
                entity.Property(e => e.ProductPackagingQty).HasColumnName("product_packaging_qty");
                //entity.Property(e => e.ProductUom).HasColumnName("product_uom");
                entity.Property(e => e.SaleOrderId).HasColumnName("sale_order_id");
                entity.Property(e => e.State).HasColumnName("state");

                // entity.HasOne(d => d.Currency).WithMany(p => p.PurchaseOrderLine) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_order_line_currency_id_fkey");
                // entity.HasOne(d => d.Currency).WithMany()
                //     .HasForeignKey(d => d.CurrencyId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("purchase_order_line_currency_id_fkey");

                // entity.HasOne(d => d.Group).WithMany(p => p.PurchaseOrderLine)
                //     .HasForeignKey(d => d.GroupId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("purchase_order_line_group_id_fkey");
                // entity.HasOne(d => d.ProductPackaging).WithMany(p => p.PurchaseOrderLine)
                //     .HasForeignKey(d => d.ProductPackagingId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("purchase_order_line_product_packaging_id_fkey");

                // CONFLICK-V19
                // entity.HasOne(d => d.ProductUomNavigation).WithMany(p => p.PurchaseOrderLine) .HasForeignKey(d => d.ProductUom) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_order_line_product_uom_fkey");
                // entity.HasOne(d => d.ProductUomNavigation).WithMany()
                //     .HasForeignKey(d => d.ProductUom)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("purchase_order_line_product_uom_fkey");

                // entity.HasOne(d => d.SaleOrder).WithMany(p => p.PurchaseOrderLine)
                //         .HasForeignKey(d => d.SaleOrderId)
                //         .OnDelete(DeleteBehavior.SetNull)
                //         .HasConstraintName("purchase_order_line_sale_order_id_fkey");

                // // entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.PurchaseOrderLine)
                // entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.PurchaseOrderLine)
                //     .UsingEntity<Dictionary<string, object>>(
                //         "ProductTemplateAttributeValuePurchaseOrderLineRel",
                //         r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                //             .HasForeignKey("ProductTemplateAttributeValueId")
                //             .OnDelete(DeleteBehavior.Restrict)
                //             .HasConstraintName("product_template_attribute_v_product_template_attribute_v_fkey1"),
                //         l => l.HasOne<PurchaseOrderLine>().WithMany()
                //             .HasForeignKey("PurchaseOrderLineId")
                //             .HasConstraintName("product_template_attribute_value_pu_purchase_order_line_id_fkey"),
                //         j =>
                //         {
                //             j.HasKey("PurchaseOrderLineId", "ProductTemplateAttributeValueId").HasName("product_template_attribute_value_purchase_order_line_rel_pkey");
                //             j.ToTable("product_template_attribute_value_purchase_order_line_rel");
                //             j.HasIndex(new[] { "ProductTemplateAttributeValueId", "PurchaseOrderLineId" }, "product_template_attribute_va_product_template_attribute_v_idx1");
                //             j.IndexerProperty<Guid>("PurchaseOrderLineId").HasColumnName("purchase_order_line_id");
                //             j.IndexerProperty<Guid>("ProductTemplateAttributeValueId").HasColumnName("product_template_attribute_value_id");
                //         });

            });
            modelBuilder.Entity<PurchaseRequisitionCreateAlternative>(entity =>
            {
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");

                // CONFLICK-V19
                // entity.HasOne(d => d.Partner).WithMany(p => p.PurchaseRequisitionCreateAlternative) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("purchase_requisition_create_alternative_partner_id_fkey");
                // entity.HasOne(d => d.Partner).WithMany()
                //     .HasForeignKey(d => d.PartnerId)
                //     .OnDelete(DeleteBehavior.Cascade)
                //     .HasConstraintName("purchase_requisition_create_alternative_partner_id_fkey");

            });
            modelBuilder.Entity<RepairOrder>(entity =>
            {
                entity.Property(e => e.ProcurementGroupId).HasColumnName("procurement_group_id");
                // entity.HasOne(d => d.ProcurementGroup).WithMany(p => p.RepairOrder)
                //     .HasForeignKey(d => d.ProcurementGroupId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("repair_order_procurement_group_id_fkey");

            });
            modelBuilder.Entity<ResCompany>(entity =>
            {
                entity.Property(e => e.AliasDomainName).HasColumnName("alias_domain_name");
                entity.Property(e => e.CandidatePropertiesDefinition)
                            .HasColumnType("jsonb")
                            .HasColumnName("candidate_properties_definition");
                entity.Property(e => e.CheckAccountAuditTrail).HasColumnName("check_account_audit_trail");
                entity.Property(e => e.ExpenseOutstandingAccountId).HasColumnName("expense_outstanding_account_id");
                entity.Property(e => e.ManufacturingLead).HasColumnName("manufacturing_lead");
                entity.Property(e => e.Mobile).HasColumnName("mobile");
                entity.Property(e => e.PartnerGid).HasColumnName("partner_gid");
                entity.Property(e => e.PaymentOnboardingPaymentMethod).HasColumnName("payment_onboarding_payment_method");
                entity.Property(e => e.PoLead).HasColumnName("po_lead");
                entity.Property(e => e.StockMoveSmsValidation).HasColumnName("stock_move_sms_validation");

                // entity.HasOne(d => d.ExpenseOutstandingAccount).WithMany(p => p.ResCompanyExpenseOutstandingAccount) .HasForeignKey(d => d.ExpenseOutstandingAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_company_expense_outstanding_account_id_fkey");
                entity.HasOne(d => d.ExpenseOutstandingAccount).WithMany()
                    .HasForeignKey(d => d.ExpenseOutstandingAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_company_expense_outstanding_account_id_fkey");

            });
            modelBuilder.Entity<ResConfigSettings>(entity =>
            {
                entity.Property(e => e.AllowOutOfStockOrder).HasColumnName("allow_out_of_stock_order");
                entity.Property(e => e.AvailableThreshold).HasColumnName("available_threshold");
                entity.Property(e => e.CloudStorageMinFileSize).HasColumnName("cloud_storage_min_file_size");
                entity.Property(e => e.CloudStorageProvider).HasColumnName("cloud_storage_provider");
                entity.Property(e => e.DefaultPurchaseMethod).HasColumnName("default_purchase_method");
                entity.Property(e => e.EnabledBuyNowButton).HasColumnName("enabled_buy_now_button");
                entity.Property(e => e.EnabledExtraCheckoutStep).HasColumnName("enabled_extra_checkout_step");
                entity.Property(e => e.GoogleCustomSearchKey).HasColumnName("google_custom_search_key");
                entity.Property(e => e.GooglePseId).HasColumnName("google_pse_id");
                entity.Property(e => e.GroupApplicantCvDisplay).HasColumnName("group_applicant_cv_display");
                entity.Property(e => e.GroupDeliveryInvoiceAddress).HasColumnName("group_delivery_invoice_address");
                entity.Property(e => e.GroupProjectMilestone).HasColumnName("group_project_milestone");
                entity.Property(e => e.GroupProjectRating).HasColumnName("group_project_rating");
                entity.Property(e => e.GroupProjectRecurringTasks).HasColumnName("group_project_recurring_tasks");
                entity.Property(e => e.GroupProjectTaskDependencies).HasColumnName("group_project_task_dependencies");
                entity.Property(e => e.GroupShowPurchaseReceipts).HasColumnName("group_show_purchase_receipts");
                entity.Property(e => e.GroupShowSaleReceipts).HasColumnName("group_show_sale_receipts");
                entity.Property(e => e.GroupStockAccountingAutomatic).HasColumnName("group_stock_accounting_automatic");
                entity.Property(e => e.GroupStockPackaging).HasColumnName("group_stock_packaging");
                entity.Property(e => e.GroupWarningAccount).HasColumnName("group_warning_account");
                entity.Property(e => e.HrEmployeeSelfEdit).HasColumnName("hr_employee_self_edit");
                entity.Property(e => e.JitsiServerDomain).HasColumnName("jitsi_server_domain");
                entity.Property(e => e.ModuleAccount).HasColumnName("module_account");
                entity.Property(e => e.ModuleAccountBankStatementImportCamt).HasColumnName("module_account_bank_statement_import_camt");
                entity.Property(e => e.ModuleAccountBankStatementImportCsv).HasColumnName("module_account_bank_statement_import_csv");
                entity.Property(e => e.ModuleAccountBankStatementImportOfx).HasColumnName("module_account_bank_statement_import_ofx");
                entity.Property(e => e.ModuleDeliveryFedex).HasColumnName("module_delivery_fedex");
                entity.Property(e => e.ModuleDeliveryMondialrelay).HasColumnName("module_delivery_mondialrelay");
                entity.Property(e => e.ModuleDeliveryUps).HasColumnName("module_delivery_ups");
                entity.Property(e => e.ModuleDeliveryUsps).HasColumnName("module_delivery_usps");
                entity.Property(e => e.ModuleHrHomeworking).HasColumnName("module_hr_homeworking");
                entity.Property(e => e.ModuleL10nEuOss).HasColumnName("module_l10n_eu_oss");
                entity.Property(e => e.ModuleMarketingAutomation).HasColumnName("module_marketing_automation");
                entity.Property(e => e.ModuleOmHrPayrollAccount).HasColumnName("module_om_hr_payroll_account");
                entity.Property(e => e.ModulePosPaytm).HasColumnName("module_pos_paytm");
                entity.Property(e => e.ModulePosPreparationDisplay).HasColumnName("module_pos_preparation_display");
                entity.Property(e => e.ModulePosSix).HasColumnName("module_pos_six");
                entity.Property(e => e.ModulePosVivaWallet).HasColumnName("module_pos_viva_wallet");
                entity.Property(e => e.ModuleProductImages).HasColumnName("module_product_images");
                entity.Property(e => e.ModuleWebsiteEventMeet).HasColumnName("module_website_event_meet");
                entity.Property(e => e.ModuleWebsiteSaleComparison).HasColumnName("module_website_sale_comparison");
                entity.Property(e => e.ModuleWebsiteSaleWishlist).HasColumnName("module_website_sale_wishlist");
                entity.Property(e => e.PosEpsonPrinterIp).HasColumnName("pos_epson_printer_ip");
                entity.Property(e => e.ShowAvailability).HasColumnName("show_availability");
                entity.Property(e => e.TenorContentFilter).HasColumnName("tenor_content_filter");
                entity.Property(e => e.TenorGifLimit).HasColumnName("tenor_gif_limit");
                entity.Property(e => e.UseManufacturingLead).HasColumnName("use_manufacturing_lead");
                entity.Property(e => e.UsePoLead).HasColumnName("use_po_lead");
                entity.Property(e => e.UserDefaultRights).HasColumnName("user_default_rights");

            });
            modelBuilder.Entity<ResDeviceLog>(entity =>
            {
                //entity.HasIndex(e => new { e.UserId, e.SessionIdentifier, e.Platform, e.Browser, e.LastActivity, e.Id }, "res_device_log__composite_idx").HasFilter("(revoked = false)");

            });
            modelBuilder.Entity<ResGroups>(entity =>
            {
                entity.HasIndex(e => e.CategoryId, "res_groups__category_id_index");

                //entity.HasIndex(e => new { e.CategoryId, e.Name }, "res_groups_name_uniq").IsUnique();
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Color).HasColumnName("color");

                // entity.HasOne(d => d.Category).WithMany(p => p.ResGroups)
                //     .HasForeignKey(d => d.CategoryId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("res_groups_category_id_fkey");

            });
            modelBuilder.Entity<ResLang>(entity =>
            {
                entity.Property(e => e.ShortTimeFormat).HasColumnName("short_time_format");

            });
            modelBuilder.Entity<ResPartnerBank>(entity =>
            {
                entity.Property(e => e.AbaRouting).HasColumnName("aba_routing");

            });
            modelBuilder.Entity<ResPartner>(entity =>
            {
                entity.Property(e => e.AdditionalInfo).HasColumnName("additional_info");
                entity.Property(e => e.AssociateMember).HasColumnName("associate_member");
                entity.Property(e => e.DebitLimit).HasColumnName("debit_limit");
                entity.Property(e => e.FreeMember).HasColumnName("free_member");
                entity.Property(e => e.InvoiceWarn).HasColumnName("invoice_warn");
                entity.Property(e => e.InvoiceWarnMsg).HasColumnName("invoice_warn_msg");
                entity.Property(e => e.MembershipAmount).HasColumnName("membership_amount");
                entity.Property(e => e.MembershipCancel).HasColumnName("membership_cancel");
                entity.Property(e => e.MembershipStart).HasColumnName("membership_start");
                entity.Property(e => e.MembershipState).HasColumnName("membership_state");
                entity.Property(e => e.MembershipStop).HasColumnName("membership_stop");
                entity.Property(e => e.Mobile).HasColumnName("mobile");
                entity.Property(e => e.PartnerGid).HasColumnName("partner_gid");
                entity.Property(e => e.PickingWarn).HasColumnName("picking_warn");
                entity.Property(e => e.PlanToChangeBike).HasColumnName("plan_to_change_bike");
                entity.Property(e => e.PlanToChangeCar).HasColumnName("plan_to_change_car");
                entity.Property(e => e.PurchaseWarn).HasColumnName("purchase_warn");
                entity.Property(e => e.SaleWarn).HasColumnName("sale_warn");
                entity.Property(e => e.Title).HasColumnName("title");

                // entity.HasOne(d => d.AssociateMemberNavigation).WithMany(p => p.InverseAssociateMemberNavigation) .HasForeignKey(d => d.AssociateMember) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_partner_associate_member_fkey");
                // entity.HasOne(d => d.AssociateMemberNavigation).WithMany()
                //     .HasForeignKey(d => d.AssociateMember)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("res_partner_associate_member_fkey");
                // entity.HasOne(d => d.TitleNavigation).WithMany(p => p.ResPartner)
                //     .HasForeignKey(d => d.Title)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("res_partner_title_fkey");

            });
            modelBuilder.Entity<ResUsers>(entity =>
            {
                entity.Property(e => e.TargetSalesDone).HasColumnName("target_sales_done");
                entity.Property(e => e.TargetSalesInvoiced).HasColumnName("target_sales_invoiced");
                entity.Property(e => e.TargetSalesWon).HasColumnName("target_sales_won");


            });
            modelBuilder.Entity<ResUsersIdentitycheck>(entity =>
            {
                entity.Property(e => e.Password).HasColumnName("password");
            });
            modelBuilder.Entity<ResUsersSettings>(entity =>
            {
                entity.HasIndex(e => e.MuteUntilDt, "res_users_settings__mute_until_dt_index");
                entity.Property(e => e.MuteUntilDt)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("mute_until_dt");

            });
            modelBuilder.Entity<ResourceCalendarAttendance>(entity =>
            {
                entity.Property(e => e.DateFrom).HasColumnName("date_from");
                entity.Property(e => e.DateTo).HasColumnName("date_to");
                entity.Property(e => e.ResourceId).HasColumnName("resource_id");

                // entity.HasOne(d => d.Resource).WithMany(p => p.ResourceCalendarAttendance)
                //     .HasForeignKey(d => d.ResourceId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("resource_calendar_attendance_resource_id_fkey");

            });
            modelBuilder.Entity<SaleOrder>(entity =>
            {
                entity.Property(e => e.ProcurementGroupId).HasColumnName("procurement_group_id");
                // entity.HasOne(d => d.ProcurementGroupNavigation).WithMany(p => p.SaleOrder)
                //             .HasForeignKey(d => d.ProcurementGroupId)
                //             .OnDelete(DeleteBehavior.SetNull)
                //             .HasConstraintName("sale_order_procurement_group_id_fkey");

            });
            modelBuilder.Entity<SaleOrderDiscount>(entity =>
            {
                // entity.HasMany(d => d.AccountTax).WithMany(p => p.SaleOrderDiscount)
                entity.HasMany(d => d.AccountTax).WithMany(p => p.SaleOrderDiscount)
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountTaxSaleOrderDiscountRel",
                        r => r.HasOne<AccountTax>().WithMany()
                            .HasForeignKey("AccountTaxId")
                            .HasConstraintName("account_tax_sale_order_discount_rel_account_tax_id_fkey"),
                        l => l.HasOne<SaleOrderDiscount>().WithMany()
                            .HasForeignKey("SaleOrderDiscountId")
                            .HasConstraintName("account_tax_sale_order_discount_rel_sale_order_discount_id_fkey"),
                        j =>
                        {
                            j.HasKey("SaleOrderDiscountId", "AccountTaxId").HasName("account_tax_sale_order_discount_rel_pkey");
                            j.ToTable("account_tax_sale_order_discount_rel");
                            j.HasIndex(new[] { "AccountTaxId", "SaleOrderDiscountId" }, "account_tax_sale_order_discou_account_tax_id_sale_order_dis_idx");
                            j.IndexerProperty<Guid>("SaleOrderDiscountId").HasColumnName("sale_order_discount_id");
                            j.IndexerProperty<Guid>("AccountTaxId").HasColumnName("account_tax_id");
                        });

            });
            modelBuilder.Entity<SaleOrderLine>(entity =>
            {
                entity.Property(e => e.ProductPackagingId).HasColumnName("product_packaging_id");
                entity.Property(e => e.ProductPackagingQty).HasColumnName("product_packaging_qty");
                //entity.Property(e => e.ProductUom).HasColumnName("product_uom");
                entity.Property(e => e.RouteId).HasColumnName("route_id");

                // entity.HasOne(d => d.Expense).WithMany(p => p.SaleOrderLine)
                //             .HasForeignKey(d => d.ExpenseId)
                //             .OnDelete(DeleteBehavior.SetNull)
                //             .HasConstraintName("sale_order_line_expense_id_fkey");

                // entity.HasOne(d => d.ProductPackaging).WithMany(p => p.SaleOrderLine)
                //     .HasForeignKey(d => d.ProductPackagingId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("sale_order_line_product_packaging_id_fkey");

                // // entity.HasOne(d => d.ProductUomNavigation).WithMany(p => p.SaleOrderLine) .HasForeignKey(d => d.ProductUom) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("sale_order_line_product_uom_fkey");
                // entity.HasOne(d => d.ProductUomNavigation).WithMany()
                //     .HasForeignKey(d => d.ProductUom)
                //     .OnDelete(DeleteBehavior.Restrict)
                //     .HasConstraintName("sale_order_line_product_uom_fkey");

                //entity.HasOne(d => d.Route).WithMany(p => p.SaleOrderLine)
                entity.HasOne(d => d.Route).WithMany()
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("sale_order_line_route_id_fkey");

                // // entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.SaleOrderLine)
                // entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.SaleOrderLine)
                //     .UsingEntity<Dictionary<string, object>>(
                //         "ProductTemplateAttributeValueSaleOrderLineRel",
                //         r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                //             .HasForeignKey("ProductTemplateAttributeValueId")
                //             .OnDelete(DeleteBehavior.Restrict)
                //             .HasConstraintName("product_template_attribute_va_product_template_attribute_v_fkey"),
                //         l => l.HasOne<SaleOrderLine>().WithMany()
                //             .HasForeignKey("SaleOrderLineId")
                //             .HasConstraintName("product_template_attribute_value_sale_o_sale_order_line_id_fkey"),
                //         j =>
                //         {
                //             j.HasKey("SaleOrderLineId", "ProductTemplateAttributeValueId").HasName("product_template_attribute_value_sale_order_line_rel_pkey");
                //             j.ToTable("product_template_attribute_value_sale_order_line_rel");
                //             j.HasIndex(new[] { "ProductTemplateAttributeValueId", "SaleOrderLineId" }, "product_template_attribute_va_product_template_attribute_va_idx");
                //             j.IndexerProperty<Guid>("SaleOrderLineId").HasColumnName("sale_order_line_id");
                //             j.IndexerProperty<Guid>("ProductTemplateAttributeValueId").HasColumnName("product_template_attribute_value_id");
                //         });


            });
            modelBuilder.Entity<SmsComposer>(entity =>
            {
                entity.Property(e => e.MassUseBlacklist).HasColumnName("mass_use_blacklist");

            });
            modelBuilder.Entity<SpreadsheetDashboard>(entity =>
            {
                // entity.HasOne(d => d.Company).WithMany(p => p.SpreadsheetDashboard) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("spreadsheet_dashboard_company_id_fkey");
                // entity.HasOne(d => d.Company).WithMany()
                //     .HasForeignKey(d => d.TenantId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("spreadsheet_dashboard_company_id_fkey");
            });
            modelBuilder.Entity<StockLocation>(entity =>
            {

                entity.Property(e => e.Comment).HasColumnName("comment");
                entity.Property(e => e.IsADock).HasColumnName("is_a_dock");
                entity.Property(e => e.IsSubcontractingLocation).HasColumnName("is_subcontracting_location");
                entity.Property(e => e.Posx).HasColumnName("posx");
                entity.Property(e => e.Posy).HasColumnName("posy");
                entity.Property(e => e.Posz).HasColumnName("posz");
                entity.Property(e => e.ScrapLocation).HasColumnName("scrap_location");
                entity.Property(e => e.ValuationInAccountId).HasColumnName("valuation_in_account_id");
                entity.Property(e => e.ValuationOutAccountId).HasColumnName("valuation_out_account_id");

                // entity.HasOne(d => d.ValuationInAccount).WithMany(p => p.StockLocationValuationInAccount) .HasForeignKey(d => d.ValuationInAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_location_valuation_in_account_id_fkey");
                // entity.HasOne(d => d.ValuationInAccount).WithMany()
                //     .HasForeignKey(d => d.ValuationInAccountId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_location_valuation_in_account_id_fkey");

                // entity.HasOne(d => d.ValuationOutAccount).WithMany(p => p.StockLocationValuationOutAccount) .HasForeignKey(d => d.ValuationOutAccountId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_location_valuation_out_account_id_fkey");
                // entity.HasOne(d => d.ValuationOutAccount).WithMany()
                //     .HasForeignKey(d => d.ValuationOutAccountId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_location_valuation_out_account_id_fkey");


            });
            modelBuilder.Entity<StockLot>(entity =>
            {
                entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                // entity.HasOne(d => d.ProductUom).WithMany(p => p.StockLot) .HasForeignKey(d => d.ProductUomId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_lot_product_uom_id_fkey");
                // entity.HasOne(d => d.ProductUom).WithMany()
                //     .HasForeignKey(d => d.ProductUomId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_lot_product_uom_id_fkey");

            });
            modelBuilder.Entity<StockMove>(entity =>
            {
                entity.HasIndex(e => e.GroupId, "stock_move__group_id_index");
                entity.HasIndex(e => e.OrderFinishedLotId, "stock_move__order_finished_lot_id_index").HasFilter("(order_finished_lot_id IS NOT NULL)");
                entity.Property(e => e.DescriptionPicking).HasColumnName("description_picking");
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.IsDone).HasColumnName("is_done");
                entity.Property(e => e.ManualConsumption).HasColumnName("manual_consumption");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.OrderFinishedLotId).HasColumnName("order_finished_lot_id");
                entity.Property(e => e.PackageLevelId).HasColumnName("package_level_id");
                entity.Property(e => e.ProductPackagingId).HasColumnName("product_packaging_id");
                entity.Property(e => e.Scrapped).HasColumnName("scrapped");
                entity.Property(e => e.UnitFactor).HasColumnName("unit_factor");

                // entity.HasOne(d => d.Group).WithMany(p => p.StockMove)
                //     .HasForeignKey(d => d.GroupId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_move_group_id_fkey");

                // entity.HasOne(d => d.OrderFinishedLot).WithMany(p => p.StockMove)
                //     .HasForeignKey(d => d.OrderFinishedLotId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_move_order_finished_lot_id_fkey");

                // entity.HasOne(d => d.PackageLevel).WithMany(p => p.StockMove)
                //     .HasForeignKey(d => d.PackageLevelId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_move_package_level_id_fkey");

                // entity.HasOne(d => d.ProductPackaging).WithMany(p => p.StockMove)
                //     .HasForeignKey(d => d.ProductPackagingId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_move_product_packaging_id_fkey");

            });
            modelBuilder.Entity<StockMoveLine>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.TenantId, e.ProductId, e.LotId, e.LocationId, e.OwnerId, e.PackageId }, "stock_move_line_free_reservation_index").HasFilter("(((state IS NULL) OR (state <> ALL (ARRAY[('cancel'::character varying)::text, ('done'::character varying)::text]))) AND (quantity_product_uom > (0)::numeric) AND (NOT picked))");
                entity.Property(e => e.BatchId).HasColumnName("batch_id");
                entity.Property(e => e.CarrierId).HasColumnName("carrier_id");
                entity.Property(e => e.DescriptionPicking).HasColumnName("description_picking");
                entity.Property(e => e.PackageLevelId).HasColumnName("package_level_id");
                entity.Property(e => e.Reference).HasColumnName("reference");

                // entity.HasOne(d => d.Batch).WithMany(p => p.StockMoveLine)
                //     .HasForeignKey(d => d.BatchId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_move_line_batch_id_fkey");

                // entity.HasOne(d => d.Carrier).WithMany(p => p.StockMoveLine)
                //     .HasForeignKey(d => d.CarrierId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_move_line_carrier_id_fkey");

                // entity.HasOne(d => d.PackageLevel).WithMany(p => p.StockMoveLine)
                //     .HasForeignKey(d => d.PackageLevelId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_move_line_package_level_id_fkey");

            });
            modelBuilder.Entity<StockPackageDestination>(entity =>
            {
                entity.Property(e => e.PickingId).HasColumnName("picking_id");
                // entity.HasOne(d => d.Picking).WithMany(p => p.StockPackageDestination)
                //     .HasForeignKey(d => d.PickingId)
                //     .OnDelete(DeleteBehavior.Cascade)
                //     .HasConstraintName("stock_package_destination_picking_id_fkey");

            });
            modelBuilder.Entity<StockPickingBatch>(entity =>
            {
                entity.Property(e => e.DockId).HasColumnName("dock_id");
                entity.Property(e => e.DriverId).HasColumnName("driver_id");
                entity.Property(e => e.EndDate)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("end_date");
                entity.Property(e => e.VehicleCategoryId).HasColumnName("vehicle_category_id");
                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");

                // entity.HasOne(d => d.Dock).WithMany(p => p.StockPickingBatch)
                //     .HasForeignKey(d => d.DockId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_picking_batch_dock_id_fkey");

                // // entity.HasOne(d => d.Driver).WithMany(p => p.StockPickingBatch) .HasForeignKey(d => d.DriverId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_picking_batch_driver_id_fkey");
                // entity.HasOne(d => d.Driver).WithMany()
                //     .HasForeignKey(d => d.DriverId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_picking_batch_driver_id_fkey");
                // entity.HasOne(d => d.VehicleCategory).WithMany(p => p.StockPickingBatch)
                //         .HasForeignKey(d => d.VehicleCategoryId)
                //         .OnDelete(DeleteBehavior.SetNull)
                //         .HasConstraintName("stock_picking_batch_vehicle_category_id_fkey");

                // entity.HasOne(d => d.Vehicle).WithMany(p => p.StockPickingBatch)
                //     .HasForeignKey(d => d.VehicleId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_picking_batch_vehicle_id_fkey");

            });
            modelBuilder.Entity<StockPicking>(entity =>
            {
                entity.Property(e => e.Date)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date");
                entity.Property(e => e.GroupId).HasColumnName("group_id");

                // entity.HasOne(d => d.Group).WithMany(p => p.StockPicking)
                //     .HasForeignKey(d => d.GroupId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_picking_group_id_fkey");

            });
            modelBuilder.Entity<StockPickingType>(entity =>
            {
                entity.Property(e => e.IsRepairable).HasColumnName("is_repairable");

            });
            modelBuilder.Entity<StockQuant>(entity =>
            {
                entity.Property(e => e.StorageCategoryId).HasColumnName("storage_category_id");
                // entity.HasOne(d => d.StorageCategory).WithMany(p => p.StockQuant)
                //     .HasForeignKey(d => d.StorageCategoryId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_quant_storage_category_id_fkey");

            });
            modelBuilder.Entity<StockRequestCount>(entity =>
            {
                entity.Property(e => e.AccountingDate).HasColumnName("accounting_date");
                entity.Property(e => e.SetCount).HasColumnName("set_count");

            });
            modelBuilder.Entity<StockRoute>(entity =>
            {
                entity.Property(e => e.PackagingSelectable).HasColumnName("packaging_selectable");

                // entity.HasMany(d => d.Packaging).WithMany(p => p.Route)
                entity.HasMany(d => d.Packaging).WithMany(p => p.Route)
                    .UsingEntity<Dictionary<string, object>>(
                        "StockRoutePackaging",
                        r => r.HasOne<ProductPackaging>().WithMany()
                            .HasForeignKey("PackagingId")
                            .HasConstraintName("stock_route_packaging_packaging_id_fkey"),
                        l => l.HasOne<StockRoute>().WithMany()
                            .HasForeignKey("RouteId")
                            .HasConstraintName("stock_route_packaging_route_id_fkey"),
                        j =>
                        {
                            j.HasKey("RouteId", "PackagingId").HasName("stock_route_packaging_pkey");
                            j.ToTable("stock_route_packaging");
                            j.HasIndex(new[] { "PackagingId", "RouteId" }, "stock_route_packaging_packaging_id_route_id_idx");
                            j.IndexerProperty<Guid>("RouteId").HasColumnName("route_id");
                            j.IndexerProperty<Guid>("PackagingId").HasColumnName("packaging_id");
                        });

            });
            modelBuilder.Entity<StockRule>(entity =>
            {
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.GroupPropagationOption).HasColumnName("group_propagation_option");
                entity.Property(e => e.PropagateWarehouseId).HasColumnName("propagate_warehouse_id");

                entity.HasOne(d => d.Group).WithMany(p => p.StockRule)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_rule_group_id_fkey");

                entity.HasOne(d => d.PropagateWarehouse).WithMany(p => p.StockRulePropagateWarehouse)
                    .HasForeignKey(d => d.PropagateWarehouseId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_rule_propagate_warehouse_id_fkey");

                // entity.HasOne(d => d.Warehouse).WithMany(p => p.StockRuleWarehouse)
                //         .HasForeignKey(d => d.WarehouseId)
                //         .OnDelete(DeleteBehavior.SetNull)
                //         .HasConstraintName("stock_rule_warehouse_id_fkey");


            });
            modelBuilder.Entity<StockWarehouse>(entity =>
            {
                entity.Property(e => e.BuyToResupply).HasColumnName("buy_to_resupply");
                entity.Property(e => e.CrossdockRouteId).HasColumnName("crossdock_route_id");
                entity.Property(e => e.ManufactureToResupply).HasColumnName("manufacture_to_resupply");
                entity.Property(e => e.SubcontractingDropshippingToResupply).HasColumnName("subcontracting_dropshipping_to_resupply");

                entity.HasOne(d => d.CrossdockRoute).WithMany(p => p.StockWarehouseCrossdockRoute)
                    .HasForeignKey(d => d.CrossdockRouteId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("stock_warehouse_crossdock_route_id_fkey");

            });
            modelBuilder.Entity<StockWarehouseOrderpoint>(entity =>
            {
                entity.Property(e => e.GroupId).HasColumnName("group_id");
                entity.Property(e => e.ManufacturingVisibilityDays).HasColumnName("manufacturing_visibility_days");
                entity.Property(e => e.ProductCategoryId).HasColumnName("product_category_id");
                entity.Property(e => e.ProductSupplierId).HasColumnName("product_supplier_id");
                entity.Property(e => e.PurchaseVisibilityDays).HasColumnName("purchase_visibility_days");
                entity.Property(e => e.QtyMultiple).HasColumnName("qty_multiple");
                entity.Property(e => e.VendorId).HasColumnName("vendor_id");

                // entity.HasOne(d => d.Group).WithMany(p => p.StockWarehouseOrderpoint)
                //     .HasForeignKey(d => d.GroupId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_warehouse_orderpoint_group_id_fkey");
                // entity.HasOne(d => d.ProductCategory).WithMany(p => p.StockWarehouseOrderpoint)
                //     .HasForeignKey(d => d.ProductCategoryId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_warehouse_orderpoint_product_category_id_fkey");

                // entity.HasOne(d => d.ProductSupplier).WithMany(p => p.StockWarehouseOrderpointProductSupplier) .HasForeignKey(d => d.ProductSupplierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_warehouse_orderpoint_product_supplier_id_fkey");
                // entity.HasOne(d => d.ProductSupplier).WithMany()
                //     .HasForeignKey(d => d.ProductSupplierId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_warehouse_orderpoint_product_supplier_id_fkey");

                // entity.HasOne(d => d.Vendor).WithMany(p => p.StockWarehouseOrderpointVendor) .HasForeignKey(d => d.VendorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("stock_warehouse_orderpoint_vendor_id_fkey");
                // entity.HasOne(d => d.Vendor).WithMany()
                //     .HasForeignKey(d => d.VendorId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("stock_warehouse_orderpoint_vendor_id_fkey");

            });
            modelBuilder.Entity<UomUom>(entity =>
            {
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Rounding).HasColumnName("rounding");
                entity.Property(e => e.UomType).HasColumnName("uom_type");

                // entity.HasOne(d => d.Category).WithMany(p => p.UomUom)
                //             .HasForeignKey(d => d.CategoryId)
                //             .OnDelete(DeleteBehavior.Restrict)
                //             .HasConstraintName("uom_uom_category_id_fkey");

            });
            modelBuilder.Entity<Website>(entity =>
            {
                entity.Property(e => e.EnabledPortalReorderButton).HasColumnName("enabled_portal_reorder_button");
                entity.Property(e => e.PreventZeroPriceSaleText)
                            .HasColumnType("jsonb")
                            .HasColumnName("prevent_zero_price_sale_text");

                // entity.HasOne(d => d.CartRecoveryMailTemplate).WithMany(p => p.Website)
                //     .HasForeignKey(d => d.CartRecoveryMailTemplateId)
                //     .OnDelete(DeleteBehavior.SetNull)
                //     .HasConstraintName("website_cart_recovery_mail_template_id_fkey");

            });

        }
    }
}