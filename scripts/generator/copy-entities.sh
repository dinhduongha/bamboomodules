#!/bin/bash
# ls -p | grep -v ./
BASE_PATH="${1:-data/Models-Odoo16-Uuid-Annotation-Origin-Converted/Models/main}"
#BASE_PATH="${1:-$(pwd)}"
DST_ENTITIES_V16COMPAT_DIR=$BASE_PATH/../compat
DST_ENTITIES_INTERNALS_DIR=$BASE_PATH/../Internals
DST_ENTITIES_V18_DIR=$BASE_PATH/../v18
DST_ENTITIES_V19_DIR=$BASE_PATH/../v19

mkdir -p $DST_ENTITIES_V16COMPAT_DIR
mkdir -p $DST_ENTITIES_INTERNALS_DIR
mkdir -p $DST_ENTITIES_V18_DIR
mkdir -p $DST_ENTITIES_V19_DIR

echo "PROCESS entities in $BASE_PATH"

echo "Move internal entities"
# Internal entities
# IrActions.cs  IrEmbeddedActions.cs  IrExports.cs  IrModelData.cs  IrModelFields.cs
mv $BASE_PATH/AuthTotpDevice.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/AuthTotpWizard.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseAutomation.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseDocumentLayout.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseGeoProvider.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseEnableProfilingWizard.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseImportImport.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseImportMapping.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseImportModule.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseLanguageExport.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseLanguageImport.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseLanguageInstall.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseModuleInstallRequest.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseModuleInstallReview.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseModuleUninstall.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseModuleUpdate.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BaseModuleUpgrade.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BasePartnerMergeAutomaticWizard.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BasePartnerMergeLine.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BusBus.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/BusPresence.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ChangePasswordOwn.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/ChangePasswordUser.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/ChangePasswordWizard.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/DecimalPrecision.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IapAccount.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IapService.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrActClient.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrAction.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrActionsTodo.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrActReportXml.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrActServer.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrActUrl.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrActWindow.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrActWindowView.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrActions.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/IrActionsServerHistory.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/IrEmbeddedActions.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/IrExports.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/IrModelData.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/IrModelFields.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/IrAsset.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrAttachment.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrConfigParameter.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrCron.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrCronProgress.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrCronTrigger.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrDefault.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrDemo.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrDemoFailure.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrDemoFailureWizard.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrEmbeddedAction.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrExport.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrExportsLine.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrFilters.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrLogging.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrMailServer.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrModelAccess.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrModelConstraint.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrModel.cs $DST_ENTITIES_INTERNALS_DIR 
#mv $BASE_PATH/IrModelDatum.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrModelFieldAccess.cs $DST_ENTITIES_INTERNALS_DIR 
#mv $BASE_PATH/IrModelField.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrModelFieldsSelection.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrModelInherit.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrModelRelation.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrModuleCategory.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrModuleModule.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrModuleModuleDependency.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrModuleModuleExclusion.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrProfile.cs $DST_ENTITIES_INTERNALS_DIR 
#mv $BASE_PATH/IrProperty.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrRule.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrSequence.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrSequenceDateRange.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrServerObjectLine.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrUiMenu.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrUiView.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/IrUiViewCustom.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ReportLayout.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ReportPaperformat.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/ResBank.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResCity.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResCompany.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResConfig.cs $DST_ENTITIES_INTERNALS_DIR 
#mv $BASE_PATH/ResConfigInstaller.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/ResConfigSetting.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResConfigSettings.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResCountry.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResCountryGroup.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResCountryState.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResCurrency.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResCurrencyRate.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResetViewArchWizard.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResGroup.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResGroups.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/ResGroupsUsersRel.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/ResGroupsPrivilege.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ResLang.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResPartner.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResPartnerActivation.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResPartnerAutocompleteSync.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResPartnerBank.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResPartnerCategory.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResPartnerGrade.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResPartnerIap.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResPartnerIndustry.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResPartnerTag.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResPartnerTitle.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResUser.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResUsers.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResUsersApikey.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResUsersApikeys.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResUsersApikeysDescription.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResUsersDeletion.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResUsersIdentitycheck.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResUsersLog.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResUsersSetting.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/ResUsersSettings.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/ResUsersSettingsVolume.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/ResUsersSettingsVolumes.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/ResUsersSettingsEmbeddedAction.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ResRole.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ResDeviceLog.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/ServerActionHistoryWizard.cs $DST_ENTITIES_V19_DIR 
#mv $BASE_PATH/IrServerObjectLines.cs $DST_ENTITIES_INTERNALS_DIR
mv $BASE_PATH/WebEditorConverterTest.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/WebEditorConverterTestSub.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/WebTourTour.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/WebTourTourStep.cs $DST_ENTITIES_INTERNALS_DIR 
mv $BASE_PATH/WizardIrModelMenuCreate.cs $DST_ENTITIES_INTERNALS_DIR 

echo "Move v19 entities"
# v19 entities
mv $BASE_PATH/AccountAnalyticLineCalendarEmployee.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/AccountPaymentRegisterWithholdingLine.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/AccountPaymentWithholdingLine.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/DiscussCallHistory.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/EventMailSlot.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/EventSlot.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HrApplicantSkill.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HrAttendanceOvertimeLine.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HrAttendanceOvertimeRule.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HrAttendanceOvertimeRuleset.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HrBankAccountAllocationWizard.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HrBankAccountAllocationWizardLine.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HrExpensePostWizard.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HrJobSkill.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HrTalentPool.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HrVersion.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HrVersionWizard.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HtmlEditorConverterTest.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/HtmlEditorConverterTestSub.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ImLivechatChannelMemberHistory.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ImLivechatConversationTag.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ImLivechatExpertise.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/JobAddApplicants.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/MailActivityScheduleLine.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/MailFollowersEdit.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/MailMessageLinkPreview.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/MailPresence.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/MrpProductionGroup.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/MrpProductionSerials.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/OrmSignalingAssets.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/OrmSignalingDefault.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/OrmSignalingGroups.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/OrmSignalingRegistry.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/OrmSignalingRouting.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/OrmSignalingStable.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/OrmSignalingTemplates.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/PeppolConfigWizard.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/PosConfirmationWizard.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/PosMakeInvoice.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/PosPreset.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/PrintPrenumberedChecks.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ProductFeed.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ProductUom.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ProductValue.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ProjectRole.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ProjectTemplateCreateWizard.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/ProjectTemplateRoleToUsersMap.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/PropertiesBaseDefinition.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/RestaurantOrderCourse.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/SmsTwilioAccountManage.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/SmsTwilioNumber.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/StockPackage.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/StockPackageHistory.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/StockPutInPack.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/StockReference.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/TalentPoolAddApplicants.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/TaskShareWizard.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/TransifexCodeTranslation.cs $DST_ENTITIES_V19_DIR
mv $BASE_PATH/WebsiteCheckoutStep.cs $DST_ENTITIES_V19_DIR

echo "Move v18 entities"
# v18-vs-v19
mv $BASE_PATH/AccountFiscalPositionTax.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/AccountReconcileModelPartnerMapping.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/ChatRoom.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/ChooseDeliveryPackage.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/EventMeetingRoom.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/HrAttendanceOvertime.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/HrContract.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/HrEmployeeSkillLog.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/HrExpenseSheet.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/MailGroup.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/MailGroupMember.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/MailGroupMessage.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/MailGroupMessageReject.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/MailGroupModeration.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/MailResendMessage.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/MailResendPartner.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/MailWizardInvite.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/MembershipInvoice.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/MembershipMembershipLine.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/PaymentProviderOnboardingWizard.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/ProcurementGroup.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/ProductFetchImageWizard.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/ProductPackaging.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/ProjectCreateInvoice.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/SaleOrderCancel.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/SaleOrderOption.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/SaleOrderTemplateOption.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/SalePaymentProviderOnboardingWizard.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/SmsResend.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/SmsResendRecipient.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/SnailmailLetterFormatError.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/SnailmailLetterMissingRequiredFields.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/StockChangeProductQty.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/StockPackageLevel.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/StockQuantPackage.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/StockTrackConfirmation.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/StockTrackLine.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/StockValuationLayer.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/StockValuationLayerRevaluation.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/UomCategory.cs $DST_ENTITIES_V18_DIR

mv $BASE_PATH/AccountPeppolServiceWizard.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/CandidateSendMail.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrCandidate.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrCandidateSkill.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrContractAdvantageTemplate.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrContributionRegister.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrPayrollStructure.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrPayslip.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrPayslipEmployees.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrPayslipInput.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrPayslipLine.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrPayslipRun.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrPayslipWorkedDays.cs $DST_ENTITIES_V18_DIR
mv $BASE_PATH/HrRuleInput.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrSalaryRuleCategory.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/HrSalaryRule.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/MrpBatchProduce.cs $DST_ENTITIES_V18_DIR 
mv $BASE_PATH/PayslipLinesContributionRegister.cs $DST_ENTITIES_V18_DIR

#mv $BASE_PATH/AccountMoveSendWizard.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/AccountPeppolService.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/AuthPasskeyKey.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/AuthTotpRateLimitLog.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/BaseImportModule.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/CalendarPopoverDeleteWizard.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/CardCard.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/CardTemplate.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/DiscussChannel.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/DiscussChannelMember.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/DiscussChannelRtcSession.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/EventLeadRequest.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/HrLeaveMandatoryDay.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/IapService.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/IrCronProgress.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/IrEmbeddedActions.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/IrModelInherit.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/LoyaltyHistory.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/MailActivityPlanTemplate.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/MailActivitySchedule.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/MailAliasDomain.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/MailCannedResponse.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/MailingSubscription.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/MailScheduledMessage.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/PaymentMethod.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/PeppolRegistration.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/PosNote.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/PosPrinter.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/ProductCombo.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/ProductComboItem.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/ProductDocument.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/QuotationDocument.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/ResDeviceLog.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/SaleOrderDiscount.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/SmsTracker.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/StockQuantRelocate.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/WebsiteControllerPage.cs $DST_ENTITIES_V18_DIR 
#mv $BASE_PATH/WebTourTourStep.cs $DST_ENTITIES_V18_DIR 


# v18-vs-v16
# mv $BASE_PATH/AccountAutopostBillsWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/AccountLockException.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/AccountMergeWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/AccountMergeWizardLine.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/AccountMoveSendBatchWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/AccountPeppolServiceWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/AccountSecureEntriesWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/AuthPasskeyKeyCreate.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/BillToPoWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/CandidateSendMail.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/CardCampaign.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/CardCampaignTag.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/CertificateCertificate.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/CertificateKey.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/DiscussGifFavorite.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/DiscussVoiceMetadata.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/FleetVehicleSendMail.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HomeworkLocationWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrCandidate.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrCandidateSkill.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrContractAdvantageTemplate.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrContributionRegister.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrEmployeeCvWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrEmployeeDeleteWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrEmployeeLocation.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrJobPlatform.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrLeaveAllocationGenerateMultiWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrLeaveGenerateMultiWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrPayrollStructure.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrPayslip.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrPayslipEmployees.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrPayslipInput.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrPayslipLine.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrPayslipRun.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrPayslipWorkedDays.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrRuleInput.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrSalaryRuleCategory.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/HrSalaryRule.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/LoyaltyCardUpdateBalance.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/MailActivityPlan.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/MailActivityTodoCreate.cs $DST_ENTITIES_V18_DIR 

# mv $BASE_PATH/MailingSubscriptionOptout.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/MailMessageTranslation.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/MailPush.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/MailPushDevice.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/MrpAccountWipAccounting.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/MrpAccountWipAccountingLine.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/MrpBatchProduce.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/PaymentCaptureWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/PayslipLinesContributionRegister.cs $DST_ENTITIES_V18_DIR

# mv $BASE_PATH/PosSelfOrderCustomLink.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/ProjectProjectStageDeleteWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/ProjectShareCollaboratorWizard.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/SaleMassCancelOrders.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/SalePdfFormField.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/SmsAccountCode.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/SmsAccountPhone.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/SmsAccountSender.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/SpreadsheetDashboardShare.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/StockScrapReasonTag.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/UpdateProductAttributeValue.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/WebsiteCustomBlockedThirdPartyDomains.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/WebsitePagePropertiesBase.cs $DST_ENTITIES_V18_DIR 
# mv $BASE_PATH/WebsitePageProperties.cs $DST_ENTITIES_V18_DIR 

echo "Move v16-compat"
# v16-compat
mv $BASE_PATH/BaseImportTestsModelsChar.cs $DST_ENTITIES_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsCharNoreadonly.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsCharReadonly.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsCharRequired.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsCharState.cs $DST_ENTITIES_V16COMPAT_DIR
mv $BASE_PATH/BaseImportTestsModelsCharStates.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsCharStillreadonly.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsComplex.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsFloat.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsM2o.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsM2oRelated.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsM2oRequired.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsM2oRequiredRelated.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsO2mChild.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsO2m.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/BaseImportTestsModelsPreview.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/IrProperty.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/IrServerObjectLines.cs $DST_ENTITIES_V16COMPAT_DIR
mv $BASE_PATH/ResConfigInstaller.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountAccountTemplate.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountBankStatementImport.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountBankStatementImportJournalCreation.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountChartTemplate.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountFiscalPositionAccountTemplate.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountFiscalPositionTaxTemplate.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountFiscalPositionTemplate.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountGroupTemplate.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountInvoiceSend.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountReconcileModelLineTemplate.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountReconcileModelTemplate.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountTaxRepartitionLineTemplate.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountTaxTemplate.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountTourUploadBill.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountTourUploadBillEmailConfirm.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/AccountUnreconcile.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/GoogleCalendarCredentials.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/HrApplicantSkill.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/HrLeaveStressDay.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/HrPlan.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/HrPlanActivityType.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/HrPlanWizard.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/MailChannel.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/MailChannelMember.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/MailChannelRtcSession.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/MailShortcode.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/MailingContactListRel.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/MrpDocument.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/MrpImmediateProduction.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/MrpImmediateProductionLine.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/NoteNote.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/NoteStage.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/NoteTag.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/PaymentIcon.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/PosSessionCheckProductWizard.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/ProjectCreateSaleOrder.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/ProjectCreateSaleOrderLine.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/PurchaseRequisitionType.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/RepairFee.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/RepairLine.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/RepairOrderMakeInvoice.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/RestaurantPrinter.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/SnailmailConfirmInvoice.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/StockAssignSerial.cs $DST_ENTITIES_V16COMPAT_DIR
mv $BASE_PATH/StockImmediateTransfer.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/StockImmediateTransferLine.cs $DST_ENTITIES_V16COMPAT_DIR 
mv $BASE_PATH/StockSchedulerCompute.cs $DST_ENTITIES_V16COMPAT_DIR 

