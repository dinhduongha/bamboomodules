using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IAccountChartTemplateAppService : IMixinAppService
    {
        Task<TEntity> DerefAccountTagsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object tax_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetAccountAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetAccountFiscalPositionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetAccountGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetAccountReconcileModelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetAccountTaxGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetAccountTaxInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetAccountsDataValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object template_data, object bank_prefix, object code_digits) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetChartTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetChartTemplateMappingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object get_all) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetFieldTranslationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object fname, object lang) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetGenericCoaResCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetGenericCoaTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetParentTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object code) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetPropertyAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object additional_properties) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetStockAccountJournalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetStockTemplateDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetTagMapperInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid country_id) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetTranslatableTemplateModelFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetUntranslatableFieldsTargetLanguageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetUntranslatableFieldsToTranslateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GetUntranslatedTranslatableTemplateModelRecordsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object langs, object companies) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> GuessChartTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> InstallDemoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object companies) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> InstantiateForeignTaxesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country, object company) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> LoadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data, object ignore_duplicates) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> LoadInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object install_demo, object force_create) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> LoadTranslationsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object langs, object companies, object template_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> LoadWipAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object template_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> ParseCsvInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object model, object module) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> PostLoadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object template_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> PreLoadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object template_data, object data) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> PreReloadDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object company, object template_data, object data, object force_create) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> RefAsync<TEntity>(IEnumerable<TEntity> entities, object xmlid, object raise_if_not_found) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> SelectChartTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object country) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> SetupCompleteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> SetupUtilityBankAccountsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object template_data) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> TemplateRegisterInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
        Task<TEntity> TryLoadingAsync<TEntity>(IEnumerable<TEntity> entities, object template_code, object company, object install_demo, object force_create) where TEntity : IEntity<Guid>, IAccountChartTemplateable;
    }
}