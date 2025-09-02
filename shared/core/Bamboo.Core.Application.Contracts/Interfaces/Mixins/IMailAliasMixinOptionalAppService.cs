using Volo.Abp.Application.Services;
using System.Linq;
using Volo.Abp.Domain.Entities;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using System;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IMailAliasMixinOptionalAppService : IMixinAppService
    {
        Task<TEntity> ActionConfigureBankJournalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> AliasFilterFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values, object filters) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> AliasGetAliasDomainIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> AliasPrepareAliasNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object alias_name, object name, object code, object jtype, object company) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> CheckAutoPostDraftEntriesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> CheckBankAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> CheckCompanyConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> CheckPaymentMethodLineIdsMultiplicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> CheckTypeDefaultAccountIdTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeAccountingDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeAliasEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeAvailablePaymentMethodIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeCodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeDefaultAccountTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeDisplayAliasFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeInboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeOutboundPaymentMethodLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputePaymentSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeRefundSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeSelectedPaymentMethodCodesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ComputeSuspenseAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ConstrainsAccountControlIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> CreateDefaultAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object journal_type, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> CreateDocumentFromAttachmentAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> CreateDocumentFromAttachmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> attachment_ids) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> DefaultInboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> DefaultInvoiceReferenceModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> DefaultOutboundPaymentMethodsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> EnsureUniqueAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object company) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> FillMissingValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object protected_codes) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> GetAvailablePaymentMethodLinesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_type) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> GetDefaultAccountDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> GetJournalBankAccountBalanceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> GetJournalInboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> GetJournalOutboundOutstandingPaymentAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> GetJournalsPaymentMethodInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> GetNextBankCashDefaultCodeAsync<TEntity>(IEnumerable<TEntity> entities, object journal_type, object company, object cache, object protected_codes) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> InitColumnAliasIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> IsPaymentMethodAvailableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object payment_method_code, object complete_domain) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> OnchangeTypeForAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> PrepareCreditAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> PrepareLiquidityAccountValsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object code, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> ProcessReferenceForSaleOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object order_reference) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> RequireNewAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record_vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> SearchAliasEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> SetBankAccountAsync<TEntity>(IEnumerable<TEntity> entities, object acc_number, Guid bank_id) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
        Task<TEntity> _GetBankStatementsAvailableSourcesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinOptionalable;
    }
}