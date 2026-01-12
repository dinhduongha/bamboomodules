using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("base", Category = "Base")]
    public class FormatVatLabelMixinAppService : ApplicationService, IFormatVatLabelMixinAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public FormatVatLabelMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AccessibleBranchesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _accessible_branches(self):
            // return self.browse(self.__accessible_branches())
            */
            return default;
        }

        public async Task<TEntity> ActionAllCompanyBranchesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def action_all_company_branches(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': self.env._('Branches'),
            //     'res_model': 'res.company',
            //     'domain': [('parent_id', '=', self.id)],
            //     'context': {
            //         'active_test': False,
            //         'default_parent_id': self.id,
            //     },
            //     'views': [[False, 'list'], [False, 'kanban'], [False, 'form']],
            // }
            */
            return default;
        }

        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _address_fields(self):
            // """Returns the list of address fields that are synced from the parent."""
            // return list(ADDRESS_FIELDS)
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def address_get(self, adr_pref=None):
            // """ Find contacts/addresses of the right type(s) by doing a depth-first-search
            // through descendants within company boundaries (stop at entities flagged ``is_company``)
            // then continuing the search at the ancestors that are within the same company boundaries.
            // Defaults to partners of type ``'default'`` when the exact type is not found, or to the
            // provided partner itself if no type ``'default'`` is found either. """
            // adr_pref = set(adr_pref or [])
            // if 'contact' not in adr_pref:
            //     adr_pref.add('contact')
            // result = {}
            // visited = set()
            // for partner in self:
            //     current_partner = partner
            //     while current_partner:
            //         to_scan = [current_partner]
            //         # Scan descendants, DFS
            //         while to_scan:
            //             record = to_scan.pop(0)
            //             visited.add(record)
            //             if record.type in adr_pref and not result.get(record.type):
            //                 result[record.type] = record.id
            //             if len(result) == len(adr_pref):
            //                 return result
            //             to_scan = [c for c in record.child_ids
            //                          if c not in visited
            //                          if not c.is_company] + to_scan
            // 
            //         # Continue scanning at ancestor if current_partner is not a commercial entity
            //         if current_partner.is_company or not current_partner.parent_id:
            //             break
            //         current_partner = current_partner.parent_id
            // 
            // # default to type 'contact' or the partner itself
            // default = result.get('contact', self.id or False)
            // for adr_type in adr_pref:
            //     result[adr_type] = result.get(adr_type) or default
            // return result
            */
            return default;
        }

        public async Task<TEntity> AllBranchesSelectedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _all_branches_selected(self):
            // """Return whether or all the branches of the companies in self are selected.
            // 
            // Is ``True`` if all the branches, and only those, are selected.
            // Can be used when some actions only make sense for whole companies regardless of the
            // branches.
            // """
            // return self == self.sudo().search([('id', 'child_of', self.root_id.ids)])
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _avatar_get_placeholder_path(self):
            // if self.is_company:
            //     return "base/static/img/company_image.png"
            // if self.type == 'delivery':
            //     return "base/static/img/truck.png"
            // if self.type == 'invoice':
            //     return "base/static/img/bill.png"
            // if self.type == 'other':
            //     return "base/static/img/puzzle.png"
            // return super()._avatar_get_placeholder_path()
            */
            return default;
        }

        public async Task<TEntity> CacheInvalidationFieldsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def cache_invalidation_fields(self):
            // # This list is not well defined and tests should be improved
            // return {
            //     'active', # user._get_company_ids and other potential cached search
            //     'sequence', # user._get_company_ids and other potential cached search
            // }
            */
            return default;
        }

        public async Task<TEntity> CheckActiveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _check_active(self):
            // for company in self:
            //     if not company.active:
            //         company_active_users = self.env['res.users'].search_count([
            //             ('company_id', '=', company.id),
            //             ('active', '=', True),
            //         ])
            //         if company_active_users:
            //             # You cannot disable companies with active users
            //             raise ValidationError(self.env._(
            //                 'The company %(company_name)s cannot be archived because it is still used '
            //                 'as the default company of %(active_users)s users.',
            //                 company_name=company.name,
            //                 active_users=company_active_users,
            //             ))
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_barcode_unicity(self):
            // for partner in self:
            //     if partner.barcode and self.env['res.partner'].search_count([('barcode', '=', partner.barcode)]) > 1:
            //         raise ValidationError(_('Another partner already has this barcode'))
            */
            return default;
        }

        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_import_consistency(self, vals_list):
            // """
            // The values created by an import are generated by a name search, field by field.
            // As a result there is no check that the field values are consistent with each others.
            // We check that if the state is given a value, it does belong to the given country, or we remove it.
            // """
            // States = self.env['res.country.state']
            // states_ids = {vals['state_id'] for vals in vals_list if vals.get('state_id')}
            // state_to_country = States.search_read([('id', 'in', list(states_ids))], ['country_id'])
            // for vals in vals_list:
            //     if vals.get('state_id'):
            //         country_id = next(c['country_id'][0] for c in state_to_country if c['id'] == vals.get('state_id'))
            //         state = States.browse(vals['state_id'])
            //         if state.country_id.id != country_id:
            //             state_domain = [('code', '=', state.code),
            //                             ('country_id', '=', country_id)]
            //             state = States.search(state_domain, limit=1)
            //             vals['state_id'] = state.id
            */
            return default;
        }

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('You cannot create recursive Partner hierarchies.'))
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_partner_company(self):
            // """
            // Check that for every partner which has a company,
            // if there exists a company linked to that partner,
            // the company_id set on the partner is that company
            // """
            // partners = self.filtered(lambda p: p.is_company and p.company_id)
            // companies = self.env['res.company'].search_fetch([('partner_id', 'in', partners.ids)], ['partner_id'])
            // for company in companies:
            //     if company != company.partner_id.company_id:
            //         raise ValidationError(_('The company assigned to this partner does not match the company this partner represents.'))
            */
            return default;
        }

        public async Task<TEntity> CheckRootDelegatedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _check_root_delegated_fields(self):
            // for company in self:
            //     if company.parent_id:
            //         for fname in company._get_company_root_delegated_field_names():
            //             if company[fname] != company.parent_id[fname]:
            //                 description = self.env['ir.model.fields']._get("res.company", fname).field_description
            //                 raise ValidationError(self.env._("The %s of a subsidiary must be the same as it's root company.", description))
            */
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _children_sync(self, values):
            // if not self.child_ids:
            //     return
            // # 2a. Commercial Fields: sync if commercial entity
            // if self.commercial_partner_id == self:
            //     fields_to_sync = values.keys() & self._commercial_fields()
            //     self.sudo()._commercial_sync_to_descendants(fields_to_sync)
            // # 2b. Address fields: sync if address changed
            // address_fields = self._address_fields()
            // if any(field in values for field in address_fields):
            //     contacts = self.child_ids.filtered(lambda c: c.type == 'contact')
            //     contacts._update_address(values)
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _clean_website(self, website):
            // url = urls.url_parse(website)
            // if not url.scheme:
            //     if not url.netloc:
            //         url = url.replace(netloc=url.path, path='')
            //     website = url.replace(scheme='http').to_url()
            // return website
            */
            return default;
        }

        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // """ Returns the list of fields that are managed by the commercial entity
            // to which a partner belongs. These fields are meant to be hidden on
            // partners that aren't `commercial entities` themselves, or synchronized
            // at update (if present in _synced_commercial_fields), and will be
            // delegated to the parent `commercial entity`. The list is meant to be
            // extended by inheriting classes. """
            // return self._synced_commercial_fields() + ['company_registry', 'industry_id']
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_sync_from_company(self):
            // """ Handle sync of commercial fields when a new parent commercial entity is set,
            // as if they were related fields """
            // commercial_partner = self.commercial_partner_id
            // if commercial_partner != self:
            //     sync_vals = commercial_partner._get_commercial_values()
            //     if sync_vals:
            //         self.write(sync_vals)
            //         self._commercial_sync_to_descendants()
            //     self._company_dependent_commercial_sync()
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncToDescendantsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_sync_to_descendants(self, fields_to_sync=None):
            // """ Handle sync of commercial fields to descendants """
            // commercial_partner = self.commercial_partner_id
            // if fields_to_sync is None:
            //     fields_to_sync = self._commercial_fields()
            // sync_vals = commercial_partner._convert_fields_to_values(fields_to_sync)
            // sync_children = self.child_ids.filtered(lambda c: not c.is_company)
            // for child in sync_children:
            //     child._commercial_sync_to_descendants(fields_to_sync)
            // sync_children.write(sync_vals)
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _company_dependent_commercial_fields(self):
            // return [
            //     fname for fname in self._commercial_fields()
            //     if self._fields[fname].company_dependent
            // ]
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _company_dependent_commercial_sync(self):
            // """ Propagate sync of company dependant commercial fields to other
            // commpanies. """
            // if not (fields_to_sync := self._company_dependent_commercial_fields()):
            //     return
            // 
            // for company_sudo in self.env['res.company'].sudo().search([]):
            //     if company_sudo == self.env.company:
            //         continue  # already handled by _commercial_sync_from_company
            //     self_in_company = self.with_company(company_sudo)
            //     self_in_company.write(
            //         self_in_company.commercial_partner_id._convert_fields_to_values(fields_to_sync)
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_active_lang_count(self):
            // lang_count = len(self.env['res.lang'].get_installed())
            // for partner in self:
            //     partner.active_lang_count = lang_count
            */
            return default;
        }

        public async Task<TEntity> ComputeAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_address(self):
            // for company in self.filtered(lambda company: company.partner_id):
            //     address_data = company.partner_id.sudo().address_get(adr_pref=['contact'])
            //     if address_data['contact']:
            //         partner = company.partner_id.browse(address_data['contact']).sudo()
            //         company.update(company._get_company_address_update(partner))
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsHookInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_application_statistics_hook(self):
            // """ Hook for override, as overriding compute method does not update
            // cache accordingly. All overrides receive False instead of previously
            // assigned value. """
            // return defaultdict(list)
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationStatisticsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_application_statistics(self):
            // result = self._compute_application_statistics_hook()
            // for p in self:
            //     p.application_statistics = result.get(p.id, [])
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // partners_with_internal_user = self.filtered(
            //     lambda partner: partner.user_ids - partner.user_ids.filtered('share') or partner.type == 'contact')
            // super(ResPartner, partners_with_internal_user)._compute_avatar(avatar_field, image_field)
            // partners_without_image = (self - partners_with_internal_user).filtered(lambda p: not p[image_field])
            // for _, group in tools.groupby(partners_without_image, key=lambda p: p._avatar_get_placeholder_path()):
            //     group_partners = self.env['res.partner'].concat(*group)
            //     group_partners[avatar_field] = base64.b64encode(group_partners[0]._avatar_get_placeholder())
            // 
            // for partner in self - partners_with_internal_user - partners_without_image:
            //     partner[avatar_field] = partner[image_field]
            */
            return default;
        }

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_color(self):
            // for company in self:
            //     company.color = company.root_id.partner_id.color or (company.root_id._origin.id % 12)
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_commercial_company_name(self):
            // for partner in self:
            //     p = partner.commercial_partner_id
            //     partner.commercial_company_name = p.is_company and p.name or partner.company_name
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_commercial_partner(self):
            // for partner in self:
            //     if partner.is_company or not partner.parent_id:
            //         partner.commercial_partner_id = partner
            //     else:
            //         partner.commercial_partner_id = partner.parent_id.commercial_partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_registry(self):
            // # exists to allow overrides
            // for company in self:
            //     company.company_registry = company.company_registry
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_registry_label(self):
            // label_by_country = self._get_company_registry_labels()
            // for company in self:
            //     country_code = company.country_id.code
            //     company.company_registry_label = label_by_country.get(country_code, _("Company ID"))
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_registry_placeholder(self):
            // self.company_registry_placeholder = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_type(self):
            // for partner in self:
            //     partner.company_type = 'company' if partner.is_company else 'person'
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_complete_name(self):
            // for partner in self:
            //     partner.complete_name = partner.with_context({})._get_complete_name()
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_contact_address(self):
            // for partner in self:
            //     partner.contact_address = partner._display_address()
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_display_name(self):
            // type_description = dict(self._fields['type']._description_selection(self.env))
            // for partner in self:
            //     if partner.env.context.get("formatted_display_name"):
            //         name = partner.name or ''
            //         if partner.parent_id or partner.company_name:
            //             name = (f"{partner.company_name or partner.parent_id.name} \t "
            //                     f"--{partner.name or type_description.get(partner.type, '')}--")
            // 
            //         if partner.env.context.get('show_email') and partner.email:
            //             name = f"{name} \t --{partner.email}--"
            //         elif partner.env.context.get('partner_show_db_id'):
            //             name = f"{name} \t --{partner.id}--"
            // 
            //     else:
            //         name = partner.with_context(lang=self.env.lang)._get_complete_name()
            //         if partner.env.context.get('partner_show_db_id'):
            //             name = f"{name} ({partner.id})"
            //         if partner.env.context.get('show_email') and partner.email:
            //             name = f"{name} <{partner.email}>"
            //         if partner.env.context.get('show_address'):
            //             name = name + "\n" + partner._display_address(without_company=True)
            // 
            //         if partner.env.context.get('show_vat') and partner.vat:
            //             if partner.env.context.get('show_address'):
            //                 name = f"{name} \n {partner.vat}"
            //             else:
            //                 name = f"{name} - {partner.vat}"
            // 
            //     # Remove extra empty lines
            //     name = re.sub(r'\s+\n', '\n', name)
            //     partner.display_name = name.strip()
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_email_formatted(self):
            // """ Compute formatted email for partner, using formataddr. Be defensive
            // in computation, notably
            // 
            //   * double format: if email already holds a formatted email like
            //     'Name' <email@domain.com> we should not use it as it to compute
            //     email formatted like "Name <'Name' <email@domain.com>>";
            //   * multi emails: sometimes this field is used to hold several addresses
            //     like email1@domain.com, email2@domain.com. We currently let this value
            //     untouched, but remove any formatting from multi emails;
            //   * invalid email: if something is wrong, keep it in email_formatted as
            //     this eases management and understanding of failures at mail.mail,
            //     mail.notification and mailing.trace level;
            //   * void email: email_formatted is False, as we cannot do anything with
            //     it;
            // """
            // self.email_formatted = False
            // for partner in self:
            //     emails_normalized = tools.email_normalize_all(partner.email)
            //     if emails_normalized:
            //         # note: multi-email input leads to invalid email like "Name" <email1, email2>
            //         # but this is current behavior in Odoo 14+ and some servers allow it
            //         partner.email_formatted = tools.formataddr((
            //             partner.name or u"False",
            //             ','.join(emails_normalized)
            //         ))
            //     elif partner.email:
            //         partner.email_formatted = tools.formataddr((
            //             partner.name or u"False",
            //             partner.email
            //         ))
            */
            return default;
        }

        public async Task<TEntity> ComputeEmptyCompanyDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_empty_company_details(self):
            // # In recent change when an html field is empty a <p> balise remains with a <br> in it,
            // # but when company details is empty we want to put the info of the company
            // for record in self:
            //     record.is_company_details_empty = not html2plaintext(record.company_details or '')
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_get_ids(self):
            // for partner in self:
            //     partner.self = partner.id
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_is_public(self):
            // for partner in self.with_context(active_test=False):
            //     users = partner.user_ids
            //     partner.is_public = users and any(user._is_public() for user in users)
            */
            return default;
        }

        public async Task<TEntity> ComputeLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_lang(self):
            // """ While creating / updating child contact, take the parent lang by
            // default if any. 0therwise, fallback to default context / DB lang """
            // for partner in self.filtered('parent_id'):
            //     partner.lang = partner.parent_id.lang or self.default_get(['lang']).get('lang') or self.env.lang
            */
            return default;
        }

        public async Task<TEntity> ComputeLogoWebInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_logo_web(self):
            // for company in self:
            //     img = company.partner_id.image_1920
            //     company.logo_web = img and base64.b64encode(image_process(base64.b64decode(img), size=(180, 0)))
            */
            return default;
        }

        public async Task<TEntity> ComputeMainUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_main_user_id(self):
            // for partner in self:
            //     if self.env.user.partner_id == partner:
            //         partner.main_user_id = self.env.user
            //         continue
            //     users = partner.user_ids.filtered(lambda u: u.active).with_prefetch(self.user_ids.ids)
            //     # Special case for OdooBot as its user might be archived.
            //     if not users and partner.id == self.env["ir.model.data"]._xmlid_to_res_id("base.partner_root"):
            //         partner.main_user_id = self.env["ir.model.data"]._xmlid_to_res_id("base.user_root")
            //         continue
            //     partner.main_user_id = users.sorted(
            //         lambda u: (not u.share, -u.id), reverse=True,
            //     )[:1]
            */
            return default;
        }

        public async Task<TEntity> ComputeParentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_parent_ids(self):
            // for company in self.with_context(active_test=False):
            //     company.parent_ids = self.browse(int(id) for id in company.parent_path.split('/') if id) if company.parent_path else company
            //     company.root_id = company.parent_ids[0]
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_partner_share(self):
            // super_partner = self.env['res.users'].browse(api.SUPERUSER_ID).partner_id
            // if super_partner in self:
            //     super_partner.partner_share = False
            // for partner in self - super_partner:
            //     partner.partner_share = not partner.user_ids or not any(not user.share for user in partner.user_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_same_vat_partner_id(self):
            // for partner in self:
            //     # use _origin to deal with onchange()
            //     partner_id = partner._origin.id
            //     # active_test = False because if a partner has been deactivated you still want to raise the error,
            //     # so that you can reactivate it instead of creating a new one, which would lose its history.
            //     Partner = self.with_context(active_test=False).sudo()
            //     vats = [partner.vat]
            //     should_check_vat = partner.vat and len(partner.vat) != 1
            // 
            //     if should_check_vat and partner.country_id and 'EU_PREFIX' in partner.country_id.country_group_codes:
            //         if partner.vat[:2].isalpha():
            //             vats.append(partner.vat[2:])
            //         else:
            //             vats.append(partner.country_id.code + partner.vat)
            //             if new_code := EU_EXTRA_VAT_CODES.get(partner.country_id.code):
            //                 vats.append(new_code + partner.vat)
            //     domain = [
            //         ('vat', 'in', vats),
            //     ]
            //     if partner.country_id:
            //         domain += [('country_id', 'in', [partner.country_id.id, False])]
            //     if partner.company_id:
            //         domain += [('company_id', 'in', [False, partner.company_id.id])]
            //     if partner_id:
            //         domain += [('id', '!=', partner_id), '!', ('id', 'child_of', partner_id)]
            //     # For VAT number being only one character, we will skip the check just like the regular check_vat
            // 
            //     partner.same_vat_partner_id = should_check_vat and not partner.parent_id and Partner.search(domain, limit=1)
            //     # check company_registry
            //     domain = [
            //         ('company_registry', '=', partner.company_registry),
            //         ('company_id', 'in', [False, partner.company_id.id]),
            //     ]
            //     if partner_id:
            //         domain += [('id', '!=', partner_id), '!', ('id', 'child_of', partner_id)]
            //     partner.same_company_registry_partner_id = bool(partner.company_registry) and not partner.parent_id and Partner.search(domain, limit=1)
            */
            return default;
        }

        public async Task<TEntity> ComputeTypeAddressLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_type_address_label(self):
            // for partner in self:
            //     if partner.type == 'invoice':
            //         partner.type_address_label = _('Invoice Address')
            //     elif partner.type == 'delivery':
            //         partner.type_address_label = _('Delivery Address')
            //     elif partner.type == 'contact' and partner.parent_id:
            //         partner.type_address_label = _('Company Address')
            //     else:
            //         partner.type_address_label = _('Address')
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_tz_offset(self):
            // for partner in self:
            //     partner.tz_offset = datetime.datetime.now(pytz.timezone(partner.tz or 'GMT')).strftime('%z')
            */
            return default;
        }

        public async Task<TEntity> ComputeUninstalledL10nModuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_uninstalled_l10n_module_ids(self):
            // # This will only compute uninstalled modules with auto-install without recursion,
            // # the rest will eventually be handled by `button_install`
            // self.env['ir.module.module'].flush_model(['auto_install', 'country_ids', 'dependencies_id'])
            // self.env['ir.module.module.dependency'].flush_model()
            // self.env.cr.execute("""
            //     SELECT country.id,
            //            ARRAY_AGG(module.id)
            //       FROM ir_module_module module,
            //            res_country country
            //      WHERE module.auto_install
            //        AND state NOT IN %(install_states)s
            //        AND NOT EXISTS (
            //                SELECT 1
            //                  FROM ir_module_module_dependency d
            //                  JOIN ir_module_module mdep ON (d.name = mdep.name)
            //                 WHERE d.module_id = module.id
            //                   AND d.auto_install_required
            //                   AND mdep.state NOT IN %(install_states)s
            //            )
            //        AND EXISTS (
            //                SELECT 1
            //                  FROM module_country mc
            //                 WHERE mc.module_id = module.id
            //                   AND mc.country_id = country.id
            //            )
            //        AND country.id = ANY(%(country_ids)s)
            //   GROUP BY country.id
            // """, {
            //     'country_ids': self.country_id.ids,
            //     'install_states': ('installed', 'to install', 'to upgrade'),
            // })
            // mapping = dict(self.env.cr.fetchall())
            // for company in self:
            //     company.uninstalled_l10n_module_ids = self.env['ir.module.module'].browse(mapping.get(company.country_id.id))
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_user_id(self):
            // """ Synchronize sales rep with parent if partner is a person """
            // for partner in self.filtered(lambda partner: not partner.user_id and partner.company_type == 'person' and partner.parent_id.user_id):
            //     partner.user_id = partner.parent_id.user_id
            */
            return default;
        }

        public async Task<TEntity> ComputeUsesDefaultLogoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_uses_default_logo(self):
            // default_logo = self._get_logo()
            // for company in self:
            //     company.uses_default_logo = not company.logo or company.logo == default_logo
            */
            return default;
        }

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_vat_label(self):
            // self.vat_label = self.env.company.country_id.vat_label or _("Tax ID")
            */
            return default;
        }

        public async Task<TEntity> ConvertFieldsToValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _convert_fields_to_values(self, field_names):
            // """ Returns dict of write() values for synchronizing ``field_names`` """
            // if any(self._fields[fname].type == 'one2many' for fname in field_names):
            //     raise AssertionError(_('One2Many fields cannot be synchronized as part of `commercial_fields` or `address fields`'))
            // return self._convert_to_write({fname: self[fname] for fname in field_names})
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def copy(self, default=None):
            // raise UserError(self.env._('Duplicating a company is not allowed. Please create a new company instead.'))
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // if default.get('name'):
            //     return vals_list
            // return [dict(vals, name=self.env._("%s (copy)", partner.name)) for partner, vals in zip(self, vals_list)]
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def create(self, vals_list):
            // 
            // # create missing partners
            // no_partner_vals_list = [
            //     vals
            //     for vals in vals_list
            //     if vals.get('name') and not vals.get('partner_id')
            // ]
            // if no_partner_vals_list:
            //     partners = self.env['res.partner'].with_context(default_parent_id=False).create([
            //         {
            //             'name': vals['name'],
            //             'is_company': True,
            //             'image_1920': vals.get('logo'),
            //             'email': vals.get('email'),
            //             'phone': vals.get('phone'),
            //             'website': vals.get('website'),
            //             'vat': vals.get('vat'),
            //             'country_id': vals.get('country_id'),
            //         }
            //         for vals in no_partner_vals_list
            //     ])
            //     # compute stored fields, for example address dependent fields
            //     partners.flush_model()
            //     for vals, partner in zip(no_partner_vals_list, partners):
            //         vals['partner_id'] = partner.id
            // 
            // for vals in vals_list:
            //     # Copy delegated fields from root to branches
            //     if parent := self.browse(vals.get('parent_id')):
            //         for fname in self._get_company_root_delegated_field_names():
            //             vals.setdefault(fname, self._fields[fname].convert_to_write(parent[fname], parent))
            // 
            // self.env.registry.clear_cache()
            // companies = super().create(vals_list)
            // 
            // # The write is made on the user to set it automatically in the multi company group.
            // if companies:
            //     (self.env.user | self.env['res.users'].browse(SUPERUSER_ID)).write({
            //         'company_ids': [Command.link(company.id) for company in companies],
            //     })
            // 
            // # Make sure that the selected currencies are enabled
            // companies.currency_id.sudo().filtered(lambda c: not c.active).active = True
            // 
            // companies_needs_l10n = companies.filtered('country_id')
            // if companies_needs_l10n:
            //     companies_needs_l10n.install_l10n_modules()
            // 
            // return companies
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def create(self, vals_list):
            // if self.env.context.get('import_file'):
            //     self._check_import_consistency(vals_list)
            // for vals in vals_list:
            //     if vals.get('website'):
            //         vals['website'] = self._clean_website(vals['website'])
            //     if vals.get('parent_id'):
            //         vals['company_name'] = False
            // partners = super().create(vals_list)
            // # due to ir.default, compute is not called as there is a default value
            // # hence calling the compute manually
            // for partner, values in zip(partners, vals_list):
            //     if 'lang' not in values and partner.parent_id:
            //         partner._compute_lang()
            // 
            // if self.env.context.get('_partners_skip_fields_sync'):
            //     return partners
            // 
            // for partner, vals in zip(partners, vals_list):
            //     partner._fields_sync(vals)
            // return partners
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def create_company(self):
            // self.ensure_one()
            // if (new_company := self._create_contact_parent_company()):
            //     # Set new company as my parent
            //     self.write({
            //         'parent_id': new_company.id,
            //         'child_ids': [Command.update(partner_id, dict(parent_id=new_company.id)) for partner_id in self.child_ids.ids]
            //     })
            // return True
            */
            return default;
        }

        public async Task<TEntity> CreateContactParentCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _create_contact_parent_company(self):
            // self.ensure_one()
            // if self.company_name:
            //     # Create parent company
            //     values = dict(name=self.company_name, is_company=True, vat=self.vat)
            //     values.update(self._convert_fields_to_values(self._address_fields()))
            //     return self.create(values)
            // return self.browse()
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _default_category(self):
            // return self.env['res.partner.category'].browse(self.env.context.get('category_id'))
            */
            return default;
        }

        public async Task<TEntity> DefaultCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _default_currency_id(self):
            // return self.env.user.company_id.currency_id
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def default_get(self, fields):
            // """Add the company of the parent as default if we are creating a child partner. """
            // values = super().default_get(fields)
            // if 'parent_id' in fields and values.get('parent_id'):
            //     parent = self.browse(values.get('parent_id'))
            //     values['company_id'] = parent.company_id.id
            // # protection for `default_type` values leaking from menu action context (e.g. for crm's email)
            // if 'type' in fields and values.get('type'):
            //     if values['type'] not in self._fields['type'].get_values(self.env):
            //         values['type'] = None
            // return values
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _display_address_depends(self):
            // # field dependencies of method _display_address()
            // return self._formatting_address_fields() + [
            //     'country_id', 'company_name', 'state_id',
            // ]
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _display_address(self, without_company=False):
            // '''
            // The purpose of this function is to build and return an address formatted accordingly to the
            // standards of the country where it belongs.
            // 
            // :param without_company: if address contains company
            // :returns: the address formatted in a display that fit its country habits (or the default ones
            //     if not country is specified)
            // :rtype: string
            // '''
            // address_format, args = self._prepare_display_address(without_company)
            // return address_format % args
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _fields_sync(self, values):
            // """ Sync commercial fields and address fields from company and to children.
            // Also synchronize address to parent. This somehow mimics related fields
            // to the parent, with more control. This method should be called after
            // updating values in cache e.g. self should contain new values.
            // 
            // :param dict values: updated values, triggering sync
            // """
            // # 1. From UPSTREAM: sync from parent
            // if values.get('parent_id') or values.get('type') == 'contact':
            //     # 1a. Commercial fields: sync if parent changed
            //     if values.get('parent_id'):
            //         self.sudo()._commercial_sync_from_company()
            //     # 1b. Address fields: sync if parent or use_parent changed *and* both are now set
            //     if self.parent_id and self.type == 'contact':
            //         if address_values := self.parent_id._get_address_values():
            //             self._update_address(address_values)
            // 
            // # 2. To UPSTREAM: sync parent address, as well as editable synchronized commercial fields
            // address_to_upstream = (
            //     # parent is set, potential address update as contact address = parent address
            //     bool(self.parent_id) and bool(self.type == 'contact') and
            //     # address updated, or parent updated
            //     (any(field in values for field in self._address_fields()) or 'parent_id' in values) and
            //     # something is actually updated
            //     any(self[fname] != self.parent_id[fname] for fname in self._address_fields())
            // )
            // if address_to_upstream:
            //     new_address = self._get_address_values()
            //     self.parent_id.write(new_address)  # is going to trigger _fields_sync again
            // commercial_to_upstream = (
            //     # has a parent and is not a commercial entity itself
            //     bool(self.parent_id) and (self.commercial_partner_id != self) and
            //     # actually updated, or parent updated
            //     (any(field in values for field in self._synced_commercial_fields()) or 'parent_id' in values) and
            //     # something is actually updated
            //     any(self[fname] != self.parent_id[fname] for fname in self._synced_commercial_fields())
            // )
            // if commercial_to_upstream:
            //     new_synced_commercials = self._get_synced_commercial_values()
            //     self.parent_id.write(new_synced_commercials)
            // 
            // # 3. To DOWNSTREAM: sync children
            // self._children_sync(values)
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def find_or_create(self, email, assert_valid_email=False):
            // """ Find a partner with the given ``email`` or use :meth:`name_create`
            // to create a new one.
            // 
            // :param str email: email-like string, which should contain at least one email,
            //     e.g. ``"Raoul Grosbedon <r.g@grosbedon.fr>"``
            // :param bool assert_valid_email: raise if no valid email is found
            // :return: newly created record
            // """
            // if not email:
            //     raise ValueError(_('An email is required for find_or_create to work'))
            // 
            // parsed_name, parsed_email_normalized = tools.parse_contact_from_email(email)
            // if not parsed_email_normalized and assert_valid_email:
            //     raise ValueError(_('A valid email is required for find_or_create to work properly.'))
            // 
            // if parsed_email_normalized:
            //     partners = self.search([('email', '=ilike', parsed_email_normalized)], limit=1)
            //     if partners:
            //         return partners
            // 
            // create_values = {self._rec_name: parsed_name or parsed_email_normalized}
            // if parsed_email_normalized:  # keep default_email in context
            //     create_values['email'] = parsed_email_normalized
            // return self.create(create_values)
            */
            return default;
        }

        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _formatting_address_fields(self):
            // """Returns the list of address fields usable to format addresses."""
            // return self._address_fields()
            */
            return default;
        }

        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_address_format(self):
            // return self.country_id.address_format or self._get_default_address_format()
            */
            return default;
        }

        public async Task<TEntity> GetAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_address_values(self):
            // """ Get address values from record if at least one value is set. Otherwise
            // it is considered empty and nothing is returned. """
            // address_fields = self._address_fields()
            // if any(self[key] for key in address_fields):
            //     return self._convert_fields_to_values(address_fields)
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_all_addr(self):
            // self.ensure_one()
            // return [{
            //     'contact_type': self.street,
            //     'street': self.street,
            //     'zip': self.zip,
            //     'city': self.city,
            //     'country': self.country_id.code,
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_commercial_values(self):
            // """ Get commercial values from record. Return only set values, as they
            // are considered individually, and only set values should be taken into
            // account. """
            // set_commercial_fields = [fname for fname in self._commercial_fields() if self[fname]]
            // if set_commercial_fields:
            //     return self._convert_fields_to_values(set_commercial_fields)
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetCompanyAddressFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_company_address_field_names(self):
            // """ Return a list of fields coming from the address partner to match
            // on company address fields. Fields are labeled same on both models. """
            // return ['street', 'street2', 'city', 'zip', 'state_id', 'country_id']
            */
            return default;
        }

        public async Task<TEntity> GetCompanyAddressUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_company_address_update(self, partner):
            // return dict((fname, partner[fname])
            //             for fname in self._get_company_address_field_names())
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_company_registry_labels(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRootDelegatedFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_company_root_delegated_field_names(self):
            // """Get the set of fields delegated to the root company.
            // 
            // Some fields need to be identical on all branches of the company. All
            // fields listed by this function will be copied from the root company and
            // appear as readonly in the form view.
            // :rtype: set
            // """
            // return ['currency_id']
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_complete_name(self):
            // self.ensure_one()
            // 
            // displayed_types = self._complete_name_displayed_types
            // type_description = dict(self._fields['type']._description_selection(self.env))
            // 
            // name = self.name or ''
            // if self.company_name or self.parent_id:
            //     if not name and self.type in displayed_types:
            //         name = type_description[self.type]
            //     if not self.is_company and not self.env.context.get('partner_display_name_hide_company'):
            //         name = f"{self.commercial_company_name or self.sudo().parent_id.name}, {name}"
            // return name.strip()
            */
            return default;
        }

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_country_name(self):
            // return self.country_id.name or ''
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_default_address_format(self):
            // return "%(street)s\n%(street2)s\n%(city)s %(state_code)s %(zip)s\n%(country_name)s"
            */
            return default;
        }

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Contacts'),
            //     'template': '/base/static/xls/contacts_import_template.xlsx',
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetLogoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_logo(self):
            // with file_open('base/static/img/res_company_logo.png', 'rb') as file:
            //     return base64.b64encode(file.read())
            */
            return default;
        }

        public async Task<TEntity> GetMainCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_main_company(self):
            // try:
            //     main_company = self.sudo().env.ref('base.main_company')
            // except ValueError:
            //     main_company = self.env['res.company'].sudo().search([], limit=1, order="id")
            // 
            // return main_company
            */
            return default;
        }

        public async Task<TEntity> GetPublicUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_public_user(self):
            // self.ensure_one()
            // # We need sudo to be able to see public users from others companies too
            // public_users = self.env.ref('base.group_public').sudo().with_context(active_test=False).all_user_ids
            // public_users_for_company = public_users.filtered(lambda user: user.company_id == self)
            // 
            // if public_users_for_company:
            //     return public_users_for_company[0]
            // else:
            //     return self.env.ref('base.public_user').sudo().copy({
            //         'name': 'Public user for %s' % self.name,
            //         'login': 'public-user@company-%s.com' % self.id,
            //         'company_id': self.id,
            //         'company_ids': [(6, 0, [self.id])],
            //     })
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_street_split(self):
            // self.ensure_one()
            // return tools.street_split(self.street or '')
            */
            return default;
        }

        public async Task<TEntity> GetSyncedCommercialValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_synced_commercial_values(self):
            // """ Get synchronized commercial values from ercord. Return only set values
            // as for other commercial values. """
            // set_synced_fields = [fname for fname in self._synced_commercial_fields() if self[fname]]
            // if set_synced_fields:
            //     return self._convert_fields_to_values(set_synced_fields)
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // delegated_fnames = set(self._get_company_root_delegated_field_names())
            // arch, view = super()._get_view(view_id, view_type, **options)
            // for f in arch.iter("field"):
            //     if f.get('name') in delegated_fnames:
            //         f.set('readonly', "parent_id != False")
            // return arch, view
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // arch, view = super()._get_view(view_id, view_type, **options)
            // if vat_label := self.env.company.country_id.vat_label:
            //     for node in arch.iterfind(".//field[@name='vat']"):
            //         node.set("string", vat_label)
            //     # In some module vat field is replaced and so above string change is not working
            //     for node in arch.iterfind(".//label[@for='vat']"):
            //         node.set("string", vat_label)
            // return arch, view
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _handle_first_contact_creation(self):
            // """ On creation of first contact for a company (or root) that has no address, assume contact address
            // was meant to be company address """
            // parent = self.parent_id
            // address_fields = self._address_fields()
            // if (
            //     (parent.is_company or not parent.parent_id)
            //     and any(self[f] for f in address_fields)
            //     and not any(parent[f] for f in address_fields)
            //     and len(parent.child_ids) == 1
            // ):
            //     addr_vals = self._convert_fields_to_values(address_fields)
            //     parent._update_address(addr_vals)
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def init(self):
            // for company in self.search([('paperformat_id', '=', False)]):
            //     paperformat_euro = self.env.ref('base.paperformat_euro', False)
            //     if paperformat_euro:
            //         company.write({'paperformat_id': paperformat_euro.id})
            // sup = super()
            // if hasattr(sup, 'init'):
            //     sup.init()
            */
            return default;
        }

        public async Task<TEntity> InstallL10nModulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def install_l10n_modules(self):
            // uninstalled_modules = self.uninstalled_l10n_module_ids
            // is_ready_and_not_test = (
            //     not tools.config['test_enable']
            //     and (self.env.registry.ready or not self.env.registry._init)
            //     and not modules.module.current_test
            //     and not self.env.context.get('install_mode')  # due to savepoint when importing the file
            // )
            // if uninstalled_modules and is_ready_and_not_test:
            //     return uninstalled_modules.button_immediate_install()
            // return is_ready_and_not_test
            */
            return default;
        }

        public async Task<TEntity> InverseCityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_city(self):
            // for company in self:
            //     company.partner_id.city = company.city
            */
            return default;
        }

        public async Task<TEntity> InverseColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_color(self):
            // for company in self:
            //     company.root_id.partner_id.color = company.color
            */
            return default;
        }

        public async Task<TEntity> InverseCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_country(self):
            // for company in self:
            //     company.partner_id.country_id = company.country_id
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_state(self):
            // for company in self:
            //     company.partner_id.state_id = company.state_id
            */
            return default;
        }

        public async Task<TEntity> InverseStreet2InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_street2(self):
            // for company in self:
            //     company.partner_id.street2 = company.street2
            */
            return default;
        }

        public async Task<TEntity> InverseStreetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_street(self):
            // for company in self:
            //     company.partner_id.street = company.street
            */
            return default;
        }

        public async Task<TEntity> InverseZipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_zip(self):
            // for company in self:
            //     company.partner_id.zip = company.zip
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _load_records_create(self, vals_list):
            // partners = super(ResPartner, self.with_context(_partners_skip_fields_sync=True))._load_records_create(vals_list)
            // 
            // # batch up first part of _fields_sync
            // # group partners by commercial_partner_id (if not self) and parent_id (if type == contact)
            // groups = collections.defaultdict(list)
            // for partner, vals in zip(partners, vals_list):
            //     cp_id = None
            //     if vals.get('parent_id') and partner.commercial_partner_id != partner:
            //         cp_id = partner.commercial_partner_id.id
            // 
            //     add_id = None
            //     if partner.parent_id and partner.type == 'contact':
            //         add_id = partner.parent_id.id
            //     groups[(cp_id, add_id)].append(partner.id)
            // 
            // for (cp_id, add_id), children in groups.items():
            //     # values from parents (commercial, regular) written to their common children
            //     to_write = {}
            //     # commercial fields from commercial partner
            //     if cp_id:
            //         to_write = self.browse(cp_id)._convert_fields_to_values(self._commercial_fields())
            //     # address fields from parent
            //     if add_id:
            //         parent = self.browse(add_id)
            //         for f in self._address_fields():
            //             v = parent[f]
            //             if v:
            //                 to_write[f] = v.id if isinstance(v, models.BaseModel) else v
            //     if to_write:
            //         self.sudo().browse(children).write(to_write)
            // 
            // # do the second half of _fields_sync the "normal" way
            // for partner, vals in zip(partners, vals_list):
            //     partner._children_sync(vals)
            //     partner._handle_first_contact_creation()
            // return partners
            */
            return default;
        }

        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def name_create(self, name):
            // """ Override of orm's name_create method for partners. The purpose is
            //     to handle some basic formats to create partners using the
            //     name_create.
            //     If only an email address is received and that the regex cannot find
            //     a name, the name will have the email value.
            //     If 'force_email' key in context: must find the email address. """
            // default_type = self.env.context.get('default_type')
            // if default_type and default_type not in self._fields['type'].get_values(self.env):
            //     context = dict(self.env.context)
            //     context.pop('default_type')
            //     self = self.with_context(context)
            // name, email_normalized = tools.parse_contact_from_email(name)
            // if self.env.context.get('force_email') and not email_normalized:
            //     raise ValidationError(_("Couldn't create contact without email address!"))
            // 
            // create_values = {self._rec_name: name or email_normalized}
            // if email_normalized:  # keep default_email in context
            //     create_values['email'] = email_normalized
            // partner = self.create(create_values)
            // return partner.id, partner.display_name
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_company_id(self):
            // if self.parent_id:
            //     self.company_id = self.parent_id.company_id.id
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_company_type(self):
            // self.is_company = (self.company_type == 'company')
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _onchange_country_id(self):
            // if self.country_id:
            //     self.currency_id = self.country_id.currency_id
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_country_id(self):
            // if self.country_id and self.country_id != self.state_id.country_id:
            //     self.state_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_parent_id(self):
            // # return values in result, as this method is used by _fields_sync()
            // if not self.parent_id:
            //     return
            // result = {}
            // partner = self._origin
            // if (partner.type or self.type) == 'contact':
            //     # for contacts: copy the parent address, if set (aka, at least one
            //     # value is set in the address: otherwise, keep the one from the
            //     # contact)
            //     if address_values := self.parent_id._get_address_values():
            //         result['value'] = address_values
            // return result
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _onchange_parent_id(self):
            // if self.parent_id:
            //     for fname in self._get_company_root_delegated_field_names():
            //         if self[fname] != self.parent_id[fname]:
            //             self[fname] = self.parent_id[fname]
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _onchange_state(self):
            // if self.state_id.country_id:
            //     self.country_id = self.state_id.country_id
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_state(self):
            // if self.state_id.country_id and self.country_id != self.state_id.country_id:
            //     self.country_id = self.state_id.country_id
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def open_commercial_entity(self):
            // """ Utility method used to add an "Open Company" button in partner views """
            // self.ensure_one()
            // return {'type': 'ir.actions.act_window',
            //         'res_model': 'res.partner',
            //         'view_mode': 'form',
            //         'res_id': self.commercial_partner_id.id,
            //         'target': 'current',
            //         }
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _prepare_display_address(self, without_company=False):
            // # get the information that will be injected into the display format
            // # get the address format
            // address_format = self._get_address_format()
            // args = defaultdict(str, {
            //     'state_code': self.state_id.code or '',
            //     'state_name': self.state_id.name or '',
            //     'country_code': self.country_id.code or '',
            //     'country_name': self._get_country_name(),
            //     'company_name': self.commercial_company_name or '',
            // })
            // for field in self._formatting_address_fields():
            //     args[field] = self[field] or ''
            // if without_company:
            //     args['company_name'] = ''
            // elif self.commercial_company_name:
            //     address_format = '%(company_name)s\n' + address_format
            // return address_format, args
            */
            return default;
        }

        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _search_display_name(self, operator, value):
            // context = dict(self.env.context)
            // newself = self
            // constraint = Domain.TRUE
            // if context.pop('user_preference', None):
            //     # We browse as superuser. Otherwise, the user would be able to
            //     # select only the currently visible companies (according to rules,
            //     # which are probably to allow to see the child companies) even if
            //     # she belongs to some other companies.
            //     companies = self.env.user.company_ids
            //     constraint = Domain('id', 'in', companies.ids)
            //     newself = newself.sudo()
            // newself = newself.with_context(context)
            // domain = super(ResCompany, newself)._search_display_name(operator, value)
            // return domain & constraint
            */
            return default;
        }

        public async Task<TEntity> SyncedCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _synced_commercial_fields(self):
            // """ Returns the list of fields that are managed by the commercial entity
            // to which a partner belongs. When modified on a children, update is
            // propagated until the commercial entity. """
            // return ['vat']
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def unlink(self):
            // """
            // Unlink the companies and clear the cache to make sure that
            // _get_company_ids of res.users gets only existing company ids.
            // """
            // res = super().unlink()
            // self.env.registry.clear_cache()
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _unlink_except_user(self):
            // users = self.env['res.users'].sudo().search([('partner_id', 'in', self.ids)])
            // if not users:
            //     return  # no linked user, operation is allowed
            // if self.env['res.users'].sudo(False).has_access('write'):
            //     error_msg = _('You cannot delete contacts linked to an active user.\n'
            //                   'You should rather archive them after archiving their associated user.\n\n'
            //                   'Linked active users : %(names)s', names=", ".join([u.display_name for u in users]))
            //     action_error = users._action_show()
            //     raise RedirectWarning(error_msg, action_error, _('Go to users'))
            // else:
            //     raise ValidationError(_('You cannot delete contacts linked to an active user.\n'
            //                             'Ask an administrator to archive their associated user first.\n\n'
            //                             'Linked active users :\n%(names)s', names=", ".join([u.display_name for u in users])))
            */
            return default;
        }

        public async Task<TEntity> UpdateAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _update_address(self, vals):
            // """ Filter values from vals that are liked to address definition, and
            // update recordset using super().write to avoid loops and side effects
            // due to synchronization of address fields through partner hierarchy. """
            // addr_vals = {key: vals[key] for key in self._address_fields() if key in vals}
            // if addr_vals:
            //     super().write(addr_vals)
            */
            return default;
        }

        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def view_header_get(self, view_id, view_type):
            // if self.env.context.get('category_id'):
            //     return  _(
            //         'Partners: %(category)s',
            //         category=self.env['res.partner.category'].browse(self.env.context['category_id']).name,
            //     )
            // return super().view_header_get(view_id, view_type)
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def write(self, vals):
            // if 'parent_id' in vals:
            //     raise UserError(self.env._("The company hierarchy cannot be changed."))
            // 
            // if vals.get('currency_id'):
            //     currency = self.env['res.currency'].browse(vals['currency_id'])
            //     if not currency.active:
            //         currency.write({'active': True})
            // 
            // res = super().write(vals)
            // invalidation_fields = self.cache_invalidation_fields()
            // asset_invalidation_fields = {'font', 'primary_color', 'secondary_color', 'external_report_layout_id'}
            // 
            // companies_needs_l10n = (
            //     vals.get('country_id')
            //     and self.filtered(lambda company: not company.country_id)
            // ) or self.browse()
            // if not invalidation_fields.isdisjoint(vals):
            //     self.env.registry.clear_cache()
            // 
            // if not asset_invalidation_fields.isdisjoint(vals):
            //     # this is used in the content of an asset (see asset_styles_company_report)
            //     # and thus needs to invalidate the assets cache when this is changed
            //     self.env.registry.clear_cache('assets')  # not 100% it is useful a test is missing if it is the case
            // 
            // # Archiving a company should also archive all of its branches
            // if vals.get('active') is False:
            //     self.child_ids.active = False
            // 
            // for company in self:
            //     # Copy modified delegated fields from root to branches
            //     if (changed := set(vals) & set(self._get_company_root_delegated_field_names())) and not company.parent_id:
            //         branches = self.sudo().search([
            //             ('id', 'child_of', company.id),
            //             ('id', '!=', company.id),
            //         ])
            //         for fname in sorted(changed):
            //             branches[fname] = company[fname]
            // 
            // if companies_needs_l10n:
            //     companies_needs_l10n.install_l10n_modules()
            // 
            // # invalidate company cache to recompute address based on updated partner
            // company_address_fields = self._get_company_address_field_names()
            // company_address_fields_upd = set(company_address_fields) & set(vals.keys())
            // if company_address_fields_upd:
            //     self.invalidate_model(company_address_fields)
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def write(self, vals):
            // if vals.get('active') is False:
            //     # DLE: It should not be necessary to modify this to make work the ORM. The problem was just the recompute
            //     # of partner.user_ids when you create a new user for this partner, see test test_70_archive_internal_partners
            //     # You modified it in a previous commit, see original commit of this:
            //     # https://github.com/odoo/odoo/commit/9d7226371730e73c296bcc68eb1f856f82b0b4ed
            //     #
            //     # RCO: when creating a user for partner, the user is automatically added in partner.user_ids.
            //     # This is wrong if the user is not active, as partner.user_ids only returns active users.
            //     # Hence this temporary hack until the ORM updates inverse fields correctly.
            //     self.invalidate_recordset(['user_ids'])
            //     users = self.env['res.users'].sudo().search([('partner_id', 'in', self.ids)])
            //     if users:
            //         if self.env['res.users'].sudo(False).has_access('write'):
            //             error_msg = _('You cannot archive contacts linked to an active user.\n'
            //                           'You first need to archive their associated user.\n\n'
            //                           'Linked active users : %(names)s', names=", ".join([u.display_name for u in users]))
            //             action_error = users._action_show()
            //             raise RedirectWarning(error_msg, action_error, _('Go to users'))
            //         else:
            //             raise ValidationError(_('You cannot archive contacts linked to an active user.\n'
            //                                     'Ask an administrator to archive their associated user first.\n\n'
            //                                     'Linked active users :\n%(names)s', names=", ".join([u.display_name for u in users])))
            // if vals.get('website'):
            //     vals['website'] = self._clean_website(vals['website'])
            // if vals.get('parent_id'):
            //     vals['company_name'] = False
            // if vals.get('name'):
            //     for partner in self:
            //         for bank in partner.bank_ids:
            //             if bank.acc_holder_name == partner.name:
            //                 bank.acc_holder_name = vals['name']
            // 
            // # filter to keep only really updated values -> field synchronize goes through
            // # partner tree and we should avoid infinite loops in case same value is
            // # updated due to cycles. Use case: updating a property field, which updated
            // # a computed field, which has an inverse writing the same value on property
            // # field. Yay.
            // pre_values_list = [{fname: partner[fname] for fname in vals} for partner in self]
            // 
            // # res.partner must only allow to set the company_id of a partner if it
            // # is the same as the company of all users that inherit from this partner
            // # (this is to allow the code from res_users to write to the partner!) or
            // # if setting the company_id to False (this is compatible with any user
            // # company)
            // if 'company_id' in vals:
            //     company_id = vals['company_id']
            //     for partner in self:
            //         if company_id and partner.user_ids:
            //             company = self.env['res.company'].browse(company_id)
            //             companies = set(user.company_id for user in partner.user_ids)
            //             if len(companies) > 1 or company not in companies:
            //                 raise UserError(
            //                     self.env._("The selected company is not compatible with the companies of the related user(s)"))
            //         if partner.child_ids:
            //             partner.child_ids.write({'company_id': company_id})
            // result = True
            // # To write in SUPERUSER on field is_company and avoid access rights problems.
            // if 'is_company' in vals and not self.env.su and self.env.user.has_group('base.group_partner_manager'):
            //     result = super(ResPartner, self.sudo()).write({'is_company': vals.get('is_company')})
            //     del vals['is_company']
            // result = result and super().write(vals)
            // for partner, pre_values in zip(self, pre_values_list, strict=True):
            //     if internal_users := partner.user_ids.filtered(lambda u: u._is_internal() and u != self.env.user):
            //         internal_users.check_access('write')
            //     updated = {fname: fvalue for fname, fvalue in vals.items() if partner[fname] != pre_values[fname]}
            //     if updated:
            //         partner._fields_sync(updated)
            // return result
            */
            return default;
        }

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _write_company_type(self):
            // for partner in self:
            //     partner.is_company = partner.company_type == 'company'
            */
            return default;
        }

        public async Task<TEntity> _AccessibleBranchesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatVatLabelMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def __accessible_branches(self):
            // # Get branches of this company that the current user can use
            // self.ensure_one()
            // 
            // accessible_branch_ids = []
            // accessible = self.env.companies
            // current = self.sudo()
            // while current:
            //     accessible_branch_ids.extend((current & accessible).ids)
            //     current = current.child_ids
            // 
            // if not accessible_branch_ids and self.env.uid == SUPERUSER_ID:
            //     # Accessible companies will always be the same for super user when called in a cron.
            //     # Because of that, the intersection between them and self might be empty. The super user anyway always has
            //     # access to all companies (as it bypasses the record rules), so we return the current company in this case.
            //     return self.ids
            // 
            // return accessible_branch_ids
            */
            return default;
        }
    }
}