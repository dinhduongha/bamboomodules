#!/bin/bash
# ls -p | grep -v ./
#BASE_PATH="${1:-data/Models-Odoo18-Uuid-Annotation-Origin-Converted/Configurations/v16}"
BASE_PATH="${1:-$(pwd)}"
DST_CONFIG_V16COMPAT_DIR=$BASE_PATH/../compat
DST_CONFIG_V18_DIR=$BASE_PATH/../v18
DST_CONFIG_V19_DIR=$BASE_PATH/../v19

mkdir -p $DST_CONFIG_V16COMPAT_DIR
mkdir -p $DST_CONFIG_V18_DIR
mkdir -p $DST_CONFIG_V19_DIR

# v19
echo "Move v19"
mv $BASE_PATH/AccountAnalyticLineCalendarEmployeeConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/AccountPaymentRegisterWithholdingLineConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/AccountPaymentWithholdingLineConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/DiscussCallHistoryConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/EventMailSlotConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/EventSlotConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HrApplicantSkillConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HrAttendanceOvertimeLineConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HrAttendanceOvertimeRuleConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HrAttendanceOvertimeRulesetConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HrBankAccountAllocationWizardConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HrBankAccountAllocationWizardLineConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HrExpensePostWizardConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HrJobSkillConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HrTalentPoolConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HrVersionConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HrVersionWizardConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HtmlEditorConverterTestConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/HtmlEditorConverterTestSubConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ImLivechatChannelMemberHistoryConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ImLivechatConversationTagConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ImLivechatExpertiseConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/IrActionsServerHistoryConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/JobAddApplicantsConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/MailActivityScheduleLineConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/MailFollowersEditConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/MailMessageLinkPreviewConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/MailPresenceConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/MrpProductionGroupConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/MrpProductionSerialsConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/OrmSignalingAssetsConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/OrmSignalingDefaultConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/OrmSignalingGroupsConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/OrmSignalingRegistryConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/OrmSignalingRoutingConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/OrmSignalingStableConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/OrmSignalingTemplatesConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/PeppolConfigWizardConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/PosConfirmationWizardConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/PosMakeInvoiceConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/PosPresetConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/PrintPrenumberedChecksConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ProductFeedConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ProductUomConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ProductValueConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ProjectRoleConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ProjectTemplateCreateWizardConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ProjectTemplateRoleToUsersMapConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/PropertiesBaseDefinitionConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ResGroupsPrivilegeConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ResRoleConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/RestaurantOrderCourseConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ResUsersSettingsEmbeddedActionConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/ServerActionHistoryWizardConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/SmsTwilioAccountManageConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/SmsTwilioNumberConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/StockPackageConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/StockPackageHistoryConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/StockPutInPackConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/StockReferenceConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/TalentPoolAddApplicantsConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/TaskShareWizardConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/TransifexCodeTranslationConfiguration.cs $DST_CONFIG_V19_DIR
mv $BASE_PATH/WebsiteCheckoutStepConfiguration.cs $DST_CONFIG_V19_DIR

# v18
echo "Move v18 - only exist with v18"
mv $BASE_PATH/AccountFiscalPositionTaxConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/BusPresenceConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/ResPartnerAutocompleteSyncConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/ResPartnerTitleConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/WebEditorConverterTestConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/WebEditorConverterTestSubConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/AccountPeppolServiceWizardConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/AccountReconcileModelPartnerMappingConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/CandidateSendMailConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/ChatRoomConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/ChooseDeliveryPackageConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/EventMeetingRoomConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrAttendanceOvertimeConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrCandidateConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrCandidateSkillConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrContractAdvantageTemplateConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrContractConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrContributionRegisterConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrEmployeeSkillLogConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrExpenseSheetConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrPayrollStructureConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrPayslipConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrPayslipEmployeesConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrPayslipInputConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrPayslipLineConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrPayslipRunConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrPayslipWorkedDaysConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrRuleInputConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrSalaryRuleCategoryConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/HrSalaryRuleConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MailGroupConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MailGroupMemberConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MailGroupMessageConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MailGroupMessageRejectConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MailGroupModerationConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MailResendMessageConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MailResendPartnerConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MailWizardInviteConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MembershipInvoiceConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MembershipMembershipLineConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MrpBatchProduceConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/MrpBatchProduceConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/PaymentProviderOnboardingWizardConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/PayslipLinesContributionRegisterConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/ProcurementGroupConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/ProductFetchImageWizardConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/ProductPackagingConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/ProjectCreateInvoiceConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/SaleOrderCancelConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/SaleOrderOptionConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/SaleOrderTemplateOptionConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/SalePaymentProviderOnboardingWizardConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/SmsResendConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/SmsResendRecipientConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/SnailmailLetterFormatErrorConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/SnailmailLetterMissingRequiredFieldsConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/StockChangeProductQtyConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/StockPackageLevelConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/StockQuantPackageConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/StockTrackConfirmationConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/StockTrackLineConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/StockValuationLayerConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/StockValuationLayerRevaluationConfiguration.cs $DST_CONFIG_V18_DIR
mv $BASE_PATH/UomCategoryConfiguration.cs $DST_CONFIG_V18_DIR

# mv $BASE_PATH/AccountAutopostBillsWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/AccountLockExceptionConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/AccountMergeWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/AccountMergeWizardLineConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/AccountMoveSendBatchWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/AccountMoveSendWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/AccountPeppolServiceConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/AccountSecureEntriesWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/AuthPasskeyKeyConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/AuthPasskeyKeyCreateConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/AuthTotpRateLimitLogConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/BaseImportModuleConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/BillToPoWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/CalendarPopoverDeleteWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/CardCampaignConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/CardCampaignTagConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/CardCardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/CardTemplateConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/CertificateCertificateConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/CertificateKeyConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/DiscussChannelConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/DiscussChannelMemberConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/DiscussChannelRtcSessionConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/DiscussGifFavoriteConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/DiscussVoiceMetadataConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/EventLeadRequestConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/FleetVehicleSendMailConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/HomeworkLocationWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/HrEmployeeCvWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/HrEmployeeDeleteWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/HrEmployeeLocationConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/HrJobPlatformConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/HrLeaveAllocationGenerateMultiWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/HrLeaveGenerateMultiWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/HrLeaveMandatoryDayConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/IapServiceConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/IrCronProgressConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/IrEmbeddedActionsConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/IrModelInheritConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/LoyaltyCardUpdateBalanceConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/LoyaltyHistoryConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailActivityPlanConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailActivityPlanTemplateConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailActivityScheduleConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailActivityTodoCreateConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailAliasDomainConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailCannedResponseConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailingSubscriptionConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailingSubscriptionOptoutConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailMessageTranslationConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailPushConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailPushDeviceConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MailScheduledMessageConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MrpAccountWipAccountingConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/MrpAccountWipAccountingLineConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/PaymentCaptureWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/PaymentMethodConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/PeppolRegistrationConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/PosNoteConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/PosPrinterConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/PosSelfOrderCustomLinkConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/ProductComboConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/ProductComboItemConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/ProductDocumentConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/ProjectProjectStageDeleteWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/ProjectShareCollaboratorWizardConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/QuotationDocumentConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/ResDeviceLogConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/SaleMassCancelOrdersConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/SaleOrderDiscountConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/SalePdfFormFieldConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/SmsAccountCodeConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/SmsAccountPhoneConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/SmsAccountSenderConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/SmsTrackerConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/SpreadsheetDashboardShareConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/StockQuantRelocateConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/StockScrapReasonTagConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/UpdateProductAttributeValueConfiguration.cs  $BASE_PATH/../v18
# mv $BASE_PATH/WebsiteControllerPageConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/WebsiteCustomBlockedThirdPartyDomainsConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/WebsitePagePropertiesBaseConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/WebsitePagePropertiesConfiguration.cs $DST_CONFIG_V18_DIR
# mv $BASE_PATH/WebTourTourStepConfiguration.cs $DST_CONFIG_V18_DIR

# v16-compat
echo "Move v16-compat - only exist with v16"
mv $BASE_PATH/AccountAccountTemplateConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountBankStatementImportConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountBankStatementImportJournalCreationConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountChartTemplateConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountFiscalPositionAccountTemplateConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountFiscalPositionTaxTemplateConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountFiscalPositionTemplateConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountGroupTemplateConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountInvoiceSendConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountReconcileModelLineTemplateConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountReconcileModelTemplateConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountTaxRepartitionLineTemplateConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountTaxTemplateConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountTourUploadBillConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountTourUploadBillEmailConfirmConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/AccountUnreconcileConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsCharConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsCharNoreadonlyConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsCharReadonlyConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsCharRequiredConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsCharStatesConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsCharStillreadonlyConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsComplexConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsFloatConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsM2oConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsM2oRelatedConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsM2oRequiredConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsM2oRequiredRelatedConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsO2mChildConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsO2mConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsPreviewConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/GoogleCalendarCredentialsConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/HrApplicantSkillConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/HrLeaveStressDayConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/HrPlanActivityTypeConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/HrPlanConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/HrPlanWizardConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/IrPropertyConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/IrServerObjectLinesConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/MailChannelConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/MailChannelMemberConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/MailChannelRtcSessionConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/MailingContactListRelConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/MailShortcodeConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/MrpDocumentConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/MrpImmediateProductionConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/MrpImmediateProductionLineConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/NoteNoteConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/NoteStageConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/NoteTagConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/PaymentIconConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/PosSessionCheckProductWizardConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/ProjectCreateSaleOrderConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/ProjectCreateSaleOrderLineConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/PurchaseRequisitionTypeConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/RepairFeeConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/RepairLineConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/RepairOrderMakeInvoiceConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/ResConfigInstallerConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/RestaurantPrinterConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/SnailmailConfirmInvoiceConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/StockAssignSerialConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/StockImmediateTransferConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/StockImmediateTransferLineConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
mv $BASE_PATH/StockSchedulerComputeConfiguration.cs $DST_CONFIG_V16COMPAT_DIR
