using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("base")]
    public class FormatAddressMixinAppService : ApplicationService, IFormatAddressMixinAppService
    {

        public FormatAddressMixinAppService() 
        {

        }

        public async Task<TEntity> AccessibleBranchesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _accessible_branches(self):
            // return self.browse(self.__accessible_branches())
            */
            return default;
        }

        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _address_fields(self):
            // """Returns the list of address fields that are synced from the parent."""
            // return list(ADDRESS_FIELDS)
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> AllBranchesSelectedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> AllCompanyBranchesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def action_all_company_branches(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Branches'),
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

        public async Task<TEntity> AutoInitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _auto_init(self):
            // super()._auto_init()
            // tools.create_index(self._cr, 'crm_lead_user_id_team_id_type_index',
            //                    self._table, ['user_id', 'team_id', 'type'])
            // tools.create_index(self._cr, 'crm_lead_create_date_team_id_idx',
            //                    self._table, ['create_date', 'team_id'])
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _avatar_get_placeholder_path(self):
            // if self.is_company:
            //     return "base/static/img/company_image.png"
            // if self.type == 'delivery':
            //     return "base/static/img/truck.png"
            // if self.type == 'invoice':
            //     return "base/static/img/money.png"
            // return super()._avatar_get_placeholder_path()
            */
            return default;
        }

        public async Task<TEntity> CacheInvalidationFieldsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> CheckActiveInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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
            //             raise ValidationError(_(
            //                 'The company %(company_name)s cannot be archived because it is still used '
            //                 'as the default company of %(active_users)s users.',
            //                 company_name=company.name,
            //                 active_users=company_active_users,
            //             ))
            */
            return default;
        }

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('You cannot create recursive Partner hierarchies.'))
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> CheckRootDelegatedFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _check_root_delegated_fields(self):
            // for company in self:
            //     if company.parent_id:
            //         for fname in company._get_company_root_delegated_field_names():
            //             if company[fname] != company.parent_id[fname]:
            //                 description = self.env['ir.model.fields']._get("res.company", fname).field_description
            //                 raise ValidationError(_("The %s of a subsidiary must be the same as it's root company.", description))
            */
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _children_sync(self, values):
            // if not self.child_ids:
            //     return
            // # 2a. Commercial Fields: sync if commercial entity
            // if self.commercial_partner_id == self:
            //     fields_to_sync = values.keys() & self._commercial_fields()
            //     self.sudo()._commercial_sync_to_children(fields_to_sync)
            // # 2b. Address fields: sync if address changed
            // address_fields = self._address_fields()
            // if any(field in values for field in address_fields):
            //     contacts = self.child_ids.filtered(lambda c: c.type == 'contact')
            //     contacts.update_address(values)
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_fields(self):
            // """ Returns the list of fields that are managed by the commercial entity
            // to which a partner belongs. These fields are meant to be hidden on
            // partners that aren't `commercial entities` themselves, and will be
            // delegated to the parent `commercial entity`. The list is meant to be
            // extended by inheriting classes. """
            // return ['vat', 'company_registry', 'industry_id']
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_sync_from_company(self):
            // """ Handle sync of commercial fields when a new parent commercial entity is set,
            // as if they were related fields """
            // commercial_partner = self.commercial_partner_id
            // if commercial_partner != self:
            //     sync_vals = commercial_partner._update_fields_values(self._commercial_fields())
            //     self.write(sync_vals)
            //     self._company_dependent_commercial_sync()
            //     self._commercial_sync_to_children()
            */
            return default;
        }

        public async Task<TEntity> CommercialSyncToChildrenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _commercial_sync_to_children(self, fields_to_sync=None):
            // """ Handle sync of commercial fields to descendants """
            // commercial_partner = self.commercial_partner_id
            // if fields_to_sync is None:
            //     fields_to_sync = self._commercial_fields()
            // sync_vals = commercial_partner._update_fields_values(fields_to_sync)
            // sync_children = self.child_ids.filtered(lambda c: not c.is_company)
            // for child in sync_children:
            //     child._commercial_sync_to_children(fields_to_sync)
            // res = sync_children.write(sync_vals)
            // return res
            */
            return default;
        }

        public async Task<TEntity> CompanyDefaultGetInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @object, object field) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _company_default_get(self, object=False, field=False):
            // """ Returns the user's company
            //     - Deprecated
            // """
            // _logger.warning("The method '_company_default_get' on res.company is deprecated and shouldn't be used anymore")
            // return self.env.company
            */
            return default;
        }

        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _company_dependent_commercial_sync(self):
            // if not (fields_to_sync := self._company_dependent_commercial_fields()):
            //     return
            // 
            // for company_sudo in self.env['res.company'].sudo().search([]):
            //     if company_sudo == self.env.company:
            //         continue  # already handled by _commercial_sync_from_company
            //     self_in_company = self.with_company(company_sudo)
            //     self_in_company.write(
            //         self_in_company.commercial_partner_id._update_fields_values(fields_to_sync)
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // partners_with_internal_user = self.filtered(lambda partner: partner.user_ids - partner.user_ids.filtered('share'))
            // super(Partner, partners_with_internal_user)._compute_avatar(avatar_field, image_field)
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

        public async Task<TEntity> ComputeColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_color(self):
            // for company in self:
            //     company.color = company.root_id.partner_id.color or (company.root_id._origin.id % 12)
            */
            return default;
        }

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeCompanyCurrencyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_company_currency(self):
            // for lead in self:
            //     if not lead.company_id:
            //         lead.company_currency = self.env.company.currency_id
            //     else:
            //         lead.company_currency = lead.company_id.currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_company_id(self):
            // """ Compute company_id coherency. """
            // for lead in self:
            //     proposal = lead.company_id
            // 
            //     # invalidate wrong configuration
            //     if proposal:
            //         # company not in responsible companies
            //         if lead.user_id and proposal not in lead.user_id.company_ids:
            //             proposal = False
            //         # inconsistent
            //         elif lead.team_id.company_id and proposal != lead.team_id.company_id:
            //             proposal = False
            //         # void company on team and no assignee
            //         elif lead.team_id and not lead.team_id.company_id and not lead.user_id:
            //             proposal = False
            //         # no user and no team -> void company and let assignment do its job
            //         # unless customer has a company
            //         elif not lead.team_id and not lead.user_id and \
            //                 (not lead.partner_id or lead.partner_id.company_id != proposal):
            //             proposal = False
            // 
            //     # propose a new company based on team > user (respecting context) > partner
            //     if not proposal:
            //         if lead.team_id.company_id:
            //             lead.company_id = lead.team_id.company_id
            //         elif lead.user_id:
            //             if self.env.company in lead.user_id.company_ids:
            //                 lead.company_id = self.env.company
            //             else:
            //                 lead.company_id = lead.user_id.company_id & self.env.companies
            //         elif lead.partner_id:
            //             lead.company_id = lead.partner_id.company_id
            //         else:
            //             lead.company_id = False
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_type(self):
            // for partner in self:
            //     partner.company_type = 'company' if partner.is_company else 'person'
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_complete_name(self):
            // for partner in self:
            //     partner.complete_name = partner.with_context({})._get_complete_name()
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_contact_address(self):
            // for partner in self:
            //     partner.contact_address = partner._display_address()
            */
            return default;
        }

        public async Task<TEntity> ComputeContactNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_contact_name(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     lead.update(lead._prepare_contact_name_from_partner(lead.partner_id))
            */
            return default;
        }

        public async Task<TEntity> ComputeDateLastStageUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_date_last_stage_update(self):
            // for lead in self:
            //     if not lead.date_last_stage_update:
            //         lead.date_last_stage_update = self.env.cr.now()
            */
            return default;
        }

        public async Task<TEntity> ComputeDateOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_date_open(self):
            // for lead in self:
            //     if not lead.date_open and lead.user_id:
            //         lead.date_open = self.env.cr.now()
            */
            return default;
        }

        public async Task<TEntity> ComputeDayCloseInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_day_close(self):
            // """ Compute difference between current date and log date """
            // leads = self.filtered(lambda l: l.date_closed and l.create_date)
            // others = self - leads
            // others.day_close = None
            // for lead in leads:
            //     date_create = fields.Datetime.from_string(lead.create_date)
            //     date_close = fields.Datetime.from_string(lead.date_closed)
            //     lead.day_close = abs((date_close - date_create).days)
            */
            return default;
        }

        public async Task<TEntity> ComputeDayOpenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_day_open(self):
            // """ Compute difference between create date and open date """
            // leads = self.filtered(lambda l: l.date_open and l.create_date)
            // others = self - leads
            // others.day_open = None
            // for lead in leads:
            //     date_create = fields.Datetime.from_string(lead.create_date).replace(microsecond=0)
            //     date_open = fields.Datetime.from_string(lead.date_open)
            //     lead.day_open = abs((date_open - date_create).days)
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_display_name(self):
            // for partner in self:
            //     name = partner.with_context(lang=self.env.lang)._get_complete_name()
            //     if partner._context.get('show_address'):
            //         name = name + "\n" + partner._display_address(without_company=True)
            //     name = re.sub(r'\s+\n', '\n', name)
            //     if partner._context.get('partner_show_db_id'):
            //         name = f"{name} ({partner.id})"
            //     if partner._context.get('address_inline'):
            //         splitted_names = name.split("\n")
            //         name = ", ".join([n for n in splitted_names if n.strip()])
            //     if partner._context.get('show_email') and partner.email:
            //         name = f"{name} <{partner.email}>"
            //     if partner._context.get('show_vat') and partner.vat:
            //         name = f"{name} ‒ {partner.vat}"
            // 
            //     partner.display_name = name.strip()
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailDomainCriterionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_domain_criterion(self):
            // self.email_domain_criterion = False
            // for lead in self.filtered('email_normalized'):
            //     lead.email_domain_criterion = iap_tools.mail_prepare_for_domain_search(
            //         lead.email_normalized
            //     )
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_from(self):
            // for lead in self:
            //     if lead.partner_id.email and lead._get_partner_email_update():
            //         lead.email_from = lead.partner_id.email
            */
            return default;
        }

        public async Task<TEntity> ComputeEmailStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_state(self):
            // for lead in self:
            //     email_state = False
            //     if lead.email_from:
            //         email_state = 'incorrect'
            //         for email in email_split(lead.email_from):
            //             if mail_validation.mail_validate(email):
            //                 email_state = 'correct'
            //                 break
            //     lead.email_state = email_state
            */
            return default;
        }

        public async Task<TEntity> ComputeEmptyCompanyDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeFunctionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_function(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.function or lead.partner_id.function:
            //         lead.function = lead.partner_id.function
            */
            return default;
        }

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_get_ids(self):
            // for partner in self:
            //     partner.self = partner.id
            */
            return default;
        }

        public async Task<TEntity> ComputeIsAutomatedProbabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_is_automated_probability(self):
            // """ If probability and automated_probability are equal probability computation
            // is considered as automatic, aka probability is sync with automated_probability """
            // for lead in self:
            //     lead.is_automated_probability = tools.float_compare(lead.probability, lead.automated_probability, 2) == 0
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPartnerVisibleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_is_partner_visible(self):
            // """ When the crm.lead is of type 'lead', we don't want to display the "Customer" field on the form view
            // unless it's set (or debug mode).
            // 
            // Indeed, most of the times leads will not have this information set, since when we assign a Customer we
            // usually convert the lead to an opportunity as well.
            // 
            // This means that on the lead form, we don't want to display this field since it may be misleading for the
            // end user.
            // When it's set however, we want to display it, mainly because there are a few automatic synchronizations between
            // the lead and its partner (phone and email for examples), and this needs to be clear that modifying
            // one of those fields will in turn modify the linked partner."""
            // is_debug_mode = self.env.user.has_group('base.group_no_one')
            // for lead in self:
            //     lead.is_partner_visible = bool(lead.type == 'opportunity' or lead.partner_id or is_debug_mode)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeLangActiveCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_lang_active_count(self):
            // self.lang_active_count = len(self.env['res.lang'].get_installed())
            */
            return default;
        }

        public async Task<TEntity> ComputeLangIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_lang_id(self):
            // """ compute the lang based on partner, erase any value to force the partner
            // one if set. """
            // # prepare cache
            // lang_codes = [code for code in self.mapped('partner_id.lang') if code]
            // if lang_codes:
            //     lang_id_by_code = dict(
            //         (code, self.env['res.lang']._get_data(code=code).id)
            //         for code in lang_codes
            //     )
            // else:
            //     lang_id_by_code = {}
            // for lead in self.filtered('partner_id'):
            //     lead.lang_id = lang_id_by_code.get(lead.partner_id.lang, False)
            */
            return default;
        }

        public async Task<TEntity> ComputeLogoWebInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_logo_web(self):
            // for company in self:
            //     img = company.partner_id.image_1920
            //     company.logo_web = img and base64.b64encode(tools.image_process(base64.b64decode(img), size=(180, 0)))
            */
            return default;
        }

        public async Task<TEntity> ComputeMeetingDisplayInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_meeting_display(self):
            // now = fields.Datetime.now()
            // meeting_data = self.env['calendar.event'].sudo()._read_group([
            //     ('opportunity_id', 'in', self.ids),
            // ], ['opportunity_id'], ['start:array_agg', 'start:max'])
            // mapped_data = {
            //     lead: {
            //         'last_meeting_date': last_meeting_date,
            //         'next_meeting_date': min([dt for dt in meeting_start_dates if dt > now] or [False]),
            //     } for lead, meeting_start_dates, last_meeting_date in meeting_data
            // }
            // for lead in self:
            //     lead_meeting_info = mapped_data.get(lead)
            //     if not lead_meeting_info:
            //         lead.meeting_display_date = False
            //         lead.meeting_display_label = _('No Meeting')
            //     elif lead_meeting_info['next_meeting_date']:
            //         lead.meeting_display_date = lead_meeting_info['next_meeting_date']
            //         lead.meeting_display_label = _('Next Meeting')
            //     else:
            //         lead.meeting_display_date = lead_meeting_info['last_meeting_date']
            //         lead.meeting_display_label = _('Last Meeting')
            */
            return default;
        }

        public async Task<TEntity> ComputeMobileInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_mobile(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.mobile or lead.partner_id.mobile:
            //         lead.mobile = lead.partner_id.mobile
            */
            return default;
        }

        public async Task<TEntity> ComputeNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_name(self):
            // for lead in self:
            //     if not lead.name and lead.partner_id and lead.partner_id.name:
            //         lead.name = _("%s's opportunity") % lead.partner_id.name
            */
            return default;
        }

        public async Task<TEntity> ComputeParentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputePartnerAddressValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_address_values(self):
            // """ Sync all or none of address fields """
            // for lead in self:
            //     lead.update(lead._prepare_address_values_from_partner(lead.partner_id))
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_email_update(self):
            // for lead in self:
            //     lead.partner_email_update = lead._get_partner_email_update(force_void=False)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_name(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     lead.update(lead._prepare_partner_name_from_partner(lead.partner_id))
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_phone_update(self):
            // for lead in self:
            //     lead.partner_phone_update = lead._get_partner_phone_update(force_void=False)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_partner_share(self):
            // super_partner = self.env['res.users'].browse(SUPERUSER_ID).partner_id
            // if super_partner in self:
            //     super_partner.partner_share = False
            // for partner in self - super_partner:
            //     partner.partner_share = not partner.user_ids or not any(not user.share for user in partner.user_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_phone(self):
            // for lead in self:
            //     if lead.partner_id.phone and lead._get_partner_phone_update():
            //         lead.phone = lead.partner_id.phone
            */
            return default;
        }

        public async Task<TEntity> ComputePhoneStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_phone_state(self):
            // for lead in self:
            //     phone_status = False
            //     if lead.phone:
            //         country_code = lead.country_id.code if lead.country_id and lead.country_id.code else None
            //         try:
            //             if phone_validation.phone_parse(lead.phone, country_code):  # otherwise library not installed
            //                 phone_status = 'correct'
            //         except UserError:
            //             phone_status = 'incorrect'
            //     lead.phone_state = phone_status
            */
            return default;
        }

        public async Task<TEntity> ComputePotentialLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_potential_lead_duplicates(self):
            // """ Override potential lead duplicates computation to be more efficient
            // with high lead volume.
            // Criterions:
            //   * email domain exact match;
            //   * phone_sanitized exact match;
            //   * same commercial entity;
            // """
            // SEARCH_RESULT_LIMIT = 21
            // 
            // def return_if_relevant(model_name, domain):
            //     """ Returns the recordset obtained by performing a search on the provided
            //     model with the provided domain if the cardinality of that recordset is
            //     below a given threshold (i.e: `SEARCH_RESULT_LIMIT`). Otherwise, returns
            //     an empty recordset of the provided model as it indicates search term
            //     was not relevant.
            //     Note: The function will use the administrator privileges to guarantee
            //     that a maximum amount of leads will be included in the search results
            //     and transcend multi-company record rules. It also includes archived
            //     records. Idea is that counter indicates duplicates are present and
            //     the lead could be escalated to managers.
            //     """
            //     model = self.env[model_name].sudo().with_context(active_test=False)
            //     res = model.search(domain, limit=SEARCH_RESULT_LIMIT)
            //     return res if len(res) < SEARCH_RESULT_LIMIT else model
            // 
            // for lead in self:
            //     lead_id = lead._origin.id if isinstance(lead.id, models.NewId) else lead.id
            //     common_lead_domain = [
            //         ('id', '!=', lead_id)
            //     ]
            // 
            //     duplicate_lead_ids = self.env['crm.lead']
            // 
            //     # check the "company" email domain duplicates
            //     if lead.email_domain_criterion:
            //         duplicate_lead_ids |= return_if_relevant('crm.lead', common_lead_domain + [
            //             ('email_domain_criterion', '=', lead.email_domain_criterion)
            //         ])
            //     # check for "same commercial entity" duplicates
            //     if lead.partner_id and lead.partner_id.commercial_partner_id:
            //         duplicate_lead_ids |= lead.with_context(active_test=False).search(common_lead_domain + [
            //             ("partner_id", "child_of", lead.partner_id.commercial_partner_id.ids)
            //         ])
            //     # check the phone number duplicates, based on phone_sanitized. Only
            //     # exact matches are found, and the single one stored in phone_sanitized
            //     # in case phone and mobile are both set.
            //     if lead.phone_sanitized:
            //         duplicate_lead_ids |= return_if_relevant('crm.lead', common_lead_domain + [
            //             ('phone_sanitized', '=', lead.phone_sanitized)
            //         ])
            // 
            //     lead.duplicate_lead_ids = duplicate_lead_ids + lead
            //     lead.duplicate_lead_count = len(duplicate_lead_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_probabilities(self):
            // lead_probabilities = self._pls_get_naive_bayes_probabilities()
            // for lead in self:
            //     if lead.id in lead_probabilities:
            //         was_automated = lead.active and lead.is_automated_probability
            //         lead.automated_probability = lead_probabilities[lead.id]
            //         if was_automated:
            //             lead.probability = lead.automated_probability
            */
            return default;
        }

        public async Task<TEntity> ComputeProratedRevenueInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_prorated_revenue(self):
            // for lead in self:
            //     lead.prorated_revenue = round((lead.expected_revenue or 0.0) * (lead.probability or 0) / 100.0, 2)
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_monthly(self):
            // for lead in self:
            //     lead.recurring_revenue_monthly = (lead.recurring_revenue or 0.0) / (lead.recurring_plan.number_of_months or 1)
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueMonthlyProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_monthly_prorated(self):
            // for lead in self:
            //     lead.recurring_revenue_monthly_prorated = (lead.recurring_revenue_monthly or 0.0) * (lead.probability or 0) / 100.0
            */
            return default;
        }

        public async Task<TEntity> ComputeRecurringRevenueProratedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_prorated(self):
            // for lead in self:
            //     lead.recurring_revenue_prorated = (lead.recurring_revenue or 0.0) * (lead.probability or 0) / 100.0
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_same_vat_partner_id(self):
            // for partner in self:
            //     # use _origin to deal with onchange()
            //     partner_id = partner._origin.id
            //     #active_test = False because if a partner has been deactivated you still want to raise the error,
            //     #so that you can reactivate it instead of creating a new one, which would loose its history.
            //     Partner = self.with_context(active_test=False).sudo()
            //     domain = [
            //         ('vat', '=', partner.vat),
            //     ]
            //     if partner.company_id:
            //         domain += [('company_id', 'in', [False, partner.company_id.id])]
            //     if partner_id:
            //         domain += [('id', '!=', partner_id), '!', ('id', 'child_of', partner_id)]
            //     # For VAT number being only one character, we will skip the check just like the regular check_vat
            //     should_check_vat = partner.vat and len(partner.vat) != 1
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

        public async Task<TEntity> ComputeStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_stage_id(self):
            // for lead in self:
            //     if not lead.stage_id:
            //         lead.stage_id = lead._stage_find(domain=[('fold', '=', False)]).id
            */
            return default;
        }

        public async Task<TEntity> ComputeTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_team_id(self):
            // """ When changing the user, also set a team_id or restrict team id
            // to the ones user_id is member of. """
            // for lead in self:
            //     # setting user as void should not trigger a new team computation
            //     if not lead.user_id:
            //         continue
            //     user = lead.user_id
            //     if lead.team_id and user in (lead.team_id.member_ids | lead.team_id.user_id):
            //         continue
            //     team_domain = [('use_leads', '=', True)] if lead.type == 'lead' else [('use_opportunities', '=', True)]
            //     team = self.env['crm.team']._get_default_team_id(user_id=user.id, domain=team_domain)
            //     if lead.team_id != team:
            //         lead.team_id = team.id
            */
            return default;
        }

        public async Task<TEntity> ComputeTitleInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_title(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.title or lead.partner_id.title:
            //         lead.title = lead.partner_id.title
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_tz_offset(self):
            // for partner in self:
            //     partner.tz_offset = datetime.datetime.now(pytz.timezone(partner.tz or 'GMT')).strftime('%z')
            */
            return default;
        }

        public async Task<TEntity> ComputeUninstalledL10nModuleIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeUserCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_user_company_ids(self):
            // all_companies = self.env['res.company'].search([])
            // for lead in self:
            //     if not lead.company_id:
            //         lead.user_company_ids = all_companies
            //     else:
            //         lead.user_company_ids = lead.company_id
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeUsesDefaultLogoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_vat_label(self):
            // self.vat_label = self.env.company.country_id.vat_label or _("Tax ID")
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_website(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.website or lead.partner_id.website:
            //         lead.website = lead.partner_id.website
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, object partner, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def convert_opportunity(self, partner, user_ids=False, team_id=False):
            // customer = partner if partner else self.env['res.partner']
            // for lead in self:
            //     if not lead.active or lead.probability == 100:
            //         continue
            //     vals = lead._convert_opportunity_data(customer, team_id)
            //     lead.write(vals)
            // 
            // if user_ids or team_id:
            //     self._handle_salesmen_assignment(user_ids=user_ids, team_id=team_id)
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> ConvertOpportunityDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object customer, Guid team_id) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _convert_opportunity_data(self, customer, team_id=False):
            // """ Extract the data from a lead to create the opportunity
            //     :param customer : res.partner record
            //     :param team_id : identifier of the Sales Team to determine the stage
            // """
            // new_team_id = team_id if team_id else self.team_id.id
            // upd_values = {
            //     'type': 'opportunity',
            //     'date_conversion': self.env.cr.now(),
            // }
            // if customer != self.partner_id:
            //     upd_values['partner_id'] = customer.id if customer else False
            // if not self.stage_id:
            //     stage = self._stage_find(team_id=new_team_id)
            //     upd_values['stage_id'] = stage.id
            // return upd_values
            */
            return default;
        }

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def copy(self, default=None):
            // raise UserError(_('Duplicating a company is not allowed. Please create a new company instead.'))
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def copy_data(self, default=None):
            // # set default value in context, if not already set (Put stage to 'new' stage)
            // # Set date_open to today if it is an opp
            // default = dict(default or {})
            // if not self.env.user.has_group('crm.group_use_recurring_revenues'):
            //     default['recurring_revenue'] = 0
            //     default['recurring_plan'] = False
            // vals_list = super().copy_data(default=default)
            // now = self.env.cr.now()
            // for lead, vals in zip(self, vals_list):
            //     vals.setdefault('type', lead.type)
            //     vals.setdefault('team_id', lead.team_id.id)
            //     vals['date_open'] = now if lead.type == 'opportunity' else False
            //     if not lead.user_id.active:
            //         vals['user_id'] = False
            // return vals_list
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

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('website'):
            //         vals['website'] = self.env['res.partner']._clean_website(vals['website'])
            // leads = super(Lead, self).create(vals_list)
            // 
            // for lead, values in zip(leads, vals_list):
            //     if any(field in ['active', 'stage_id'] for field in values):
            //         lead._handle_won_lost(values)
            // 
            // return leads
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
            // 
            // if self.env.context.get('_partners_skip_fields_sync'):
            //     return partners
            // 
            // for partner, vals in zip(partners, vals_list):
            //     partner._fields_sync(vals)
            //     # Lang: propagate from parent if no value was given
            //     if 'lang' not in vals and partner.parent_id:
            //         partner._onchange_parent_id_for_lang()
            //     partner._handle_first_contact_creation()
            // return partners
            */
            return default;
        }

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def create_company(self):
            // self.ensure_one()
            // if self.company_name:
            //     # Create parent company
            //     values = dict(name=self.company_name, is_company=True, vat=self.vat)
            //     values.update(self._update_fields_values(self._address_fields()))
            //     new_company = self.create(values)
            //     # Set new company as my parent
            //     self.write({
            //         'parent_id': new_company.id,
            //         'child_ids': [Command.update(partner_id, dict(parent_id=new_company.id)) for partner_id in self.child_ids.ids]
            //     })
            // return True
            */
            return default;
        }

        public async Task<TEntity> CreateCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _create_customer(self):
            // """ Create a partner from lead data and link it to the lead.
            // 
            // :return: newly-created partner browse record
            // """
            // Partner = self.env['res.partner']
            // contact_name = self.contact_name
            // if not contact_name:
            //     contact_name = parse_contact_from_email(self.email_from)[0] if self.email_from else False
            // 
            // if self.partner_name:
            //     partner_company = Partner.create(self._prepare_customer_values(self.partner_name, is_company=True))
            // elif self.partner_id:
            //     partner_company = self.partner_id
            // else:
            //     partner_company = None
            // 
            // if contact_name:
            //     return Partner.create(self._prepare_customer_values(contact_name, is_company=False, parent_id=partner_company.id if partner_company else False))
            // 
            // if partner_company:
            //     return partner_company
            // return Partner.create(self._prepare_customer_values(self.name, is_company=False))
            */
            return default;
        }

        public async Task<TEntity> CreationMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _creation_message(self):
            // self.ensure_one()
            // if self.team_id:
            //     return _('A new lead has been created for the team "%(team_name)s".', team_name=self.team_id.display_name)
            // return _('A new lead has been created and is not assigned to any team.')
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('crm.mt_lead_create')
            */
            return default;
        }

        public async Task<TEntity> CronUpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _cron_update_automated_probabilities(self):
            // """ This cron will :
            //   - rebuild the lead scoring frequency table
            //   - recompute all the automated_probability and align probability if both were aligned
            // """
            // cron_start_date = datetime.now()
            // self._rebuild_pls_frequency_table()
            // self._update_automated_probabilities()
            // _logger.info("Predictive Lead Scoring : Cron duration = %d seconds" % ((datetime.now() - cron_start_date).total_seconds()))
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _default_category(self):
            // return self.env['res.partner.category'].browse(self._context.get('category_id'))
            */
            return default;
        }

        public async Task<TEntity> DefaultCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _default_currency_id(self):
            // return self.env.user.company_id.currency_id
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object default_fields) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def default_get(self, default_fields):
            // """Add the company of the parent as default if we are creating a child partner.
            // Also take the parent lang by default if any, otherwise, fallback to default DB lang."""
            // values = super().default_get(default_fields)
            // parent = self.env["res.partner"]
            // if 'parent_id' in default_fields and values.get('parent_id'):
            //     parent = self.browse(values.get('parent_id'))
            //     values['company_id'] = parent.company_id.id
            // if 'lang' in default_fields:
            //     values['lang'] = values.get('lang') or parent.lang or self.env.lang
            // # protection for `default_type` values leaking from menu action context (e.g. for crm's email)
            // if 'type' in default_fields and values.get('type'):
            //     if values['type'] not in self._fields['type'].get_values(self.env):
            //         values['type'] = None
            // return values
            */
            return default;
        }

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> ExtractFieldsFromAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object address_line) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _extract_fields_from_address(self, address_line):
            // """
            // Extract keys from the address line.
            // For example, if the address line is "zip: %(zip)s, city: %(city)s.",
            // this method will return ['zip', 'city'].
            // """
            // address_fields = ['%(' + field + ')s' for field in ADDRESS_FIELDS + ('state_code', 'state_name')]
            // return sorted([field[2:-2] for field in address_fields if field in address_line], key=address_line.index)
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _fields_sync(self, values):
            // """ Sync commercial fields and address fields from company and to children after create/update,
            // just as if those were all modeled as fields.related to the parent """
            // # 1. From UPSTREAM: sync from parent
            // if values.get('parent_id') or values.get('type') == 'contact':
            //     # 1a. Commercial fields: sync if parent changed
            //     if values.get('parent_id'):
            //         self.sudo()._commercial_sync_from_company()
            //     # 1b. Address fields: sync if parent or use_parent changed *and* both are now set
            //     if self.parent_id and self.type == 'contact':
            //         onchange_vals = self.onchange_parent_id().get('value', {})
            //         self.update_address(onchange_vals)
            // 
            // # 2. To DOWNSTREAM: sync children
            // self._children_sync(values)
            */
            return default;
        }

        public async Task<TEntity> FindMatchingPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_only) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _find_matching_partner(self, email_only=False):
            // """ Try to find a matching partner with available information on the
            // lead, using notably customer's name, email, ...
            // 
            // :param email_only: Only find a matching based on the email. To use
            //     for automatic process where ilike based on name can be too dangerous
            // :return: partner browse record
            // """
            // self.ensure_one()
            // partner = self.partner_id
            // 
            // if not partner and self.email_from:
            //     partner = self.env['res.partner'].search([('email', '=', self.email_from)], limit=1)
            // 
            // if not partner and not email_only:
            //     # search through the existing partners based on the lead's partner or contact name
            //     # to be aligned with _create_customer, search on lead's name as last possibility
            //     for customer_potential_name in [self[field_name] for field_name in ['partner_name', 'contact_name', 'name'] if self[field_name]]:
            //         partner = self.env['res.partner'].search([('name', 'ilike', customer_potential_name)], limit=1)
            //         if partner:
            //             break
            // 
            // return partner
            */
            return default;
        }

        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def find_or_create(self, email, assert_valid_email=False):
            // """ Find a partner with the given ``email`` or use :py:method:`~.name_create`
            // to create a new one.
            // 
            // :param str email: email-like string, which should contain at least one email,
            //     e.g. ``"Raoul Grosbedon <r.g@grosbedon.fr>"``
            // :param boolean assert_valid_email: raise if no valid email is found
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

        public async Task<TEntity> FormatPropertiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _format_properties(self):
            // """Format the properties to build the merge message.
            // 
            // Return a list of dict containing the label, and a value key if there's only
            // one value, or a "values" key if we have multiple values (e.g. many2many, tags).
            // 
            // E.G.
            //     [{
            //         'label': 'My Partner',
            //         'value': 'Alice',
            //     }, {
            //         'label': 'My Partners',
            //         'values': [
            //             {'name': 'Alice'},
            //             {'name': 'Bob'},
            //         ],
            //     }, {
            //         'label': 'My Tags',
            //         'values': [
            //             {'name': 'A', 'color': 1},
            //             {'name': 'C', 'color': 3},
            //         ],
            //     }]
            // """
            // self.ensure_one()
            // # read to have the display names already in the value
            // properties = self.read(['lead_properties'])[0]['lead_properties']
            // 
            // formatted = []
            // for definition in properties:
            //     label = definition.get('string')
            //     value = definition.get('value')
            //     property_type = definition['type']
            //     if not value and property_type != 'boolean':
            //         continue
            // 
            //     property_dict = {'label': label}
            //     if property_type == 'boolean':
            //         property_dict['value'] = _('Yes') if value else _('No')
            //     elif value and property_type == 'many2one':
            //         property_dict['value'] = value[1]
            //     elif value and property_type == 'many2many':
            //         # show many2many in badge
            //         property_dict['values'] = [{'name': rec[1]} for rec in value]
            //     elif value and property_type in ['selection', 'tags']:
            //         # retrieve the option label from the value
            //         options = {
            //             option[0]: option[1:]
            //             for option in (definition.get(property_type) or [])
            //         }
            //         if property_type == 'selection':
            //             value = options.get(value)
            //             property_dict['value'] = value[0] if value else None
            //         else:
            //             property_dict['values'] = [{
            //                 'name': options[tag][0],
            //                 'color': options[tag][1],
            //                 } for tag in value if tag in options
            //             ]
            //     else:
            //         property_dict['value'] = value
            // 
            //     formatted.append(property_dict)
            // 
            // return formatted
            */
            return default;
        }

        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _formatting_address_fields(self):
            // """Returns the list of address fields usable to format addresses."""
            // return self._address_fields()
            */
            return default;
        }

        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_address_format(self):
            // return self.country_id.address_format or self._get_default_address_format()
            */
            return default;
        }

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> GetCompanyAddressFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> GetCompanyAddressUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_company_address_update(self, partner):
            // return dict((fname, partner[fname])
            //             for fname in self._get_company_address_field_names())
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_company_registry_labels(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRootDelegatedFieldNamesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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
            //     if not self.is_company:
            //         name = f"{self.commercial_company_name or self.sudo().parent_id.name}, {name}"
            // return name.strip()
            */
            return default;
        }

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_country_name(self):
            // return self.country_id.name or ''
            */
            return default;
        }

        public async Task<TEntity> GetCustomerInformationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_customer_information(self):
            // email_normalized_to_values = super()._get_customer_information()
            // Partner = self.env['res.partner']
            // 
            // for record in self.filtered('email_normalized'):
            //     values = email_normalized_to_values.setdefault(record.email_normalized, {})
            //     contact_name = record.contact_name or record.partner_name or parse_contact_from_email(record.email_from)[0] or record.email_from
            //     # Note that we don't attempt to create the parent company even if partner name is set
            //     values.update(record._prepare_customer_values(contact_name, is_company=False))
            //     values['company_name'] = record.partner_name
            //     if contact_name == record.partner_name:
            //         values['company_type'] = 'company'
            // return email_normalized_to_values
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_default_address_format(self):
            // return "%(street)s\n%(street2)s\n%(city)s %(state_code)s %(zip)s\n%(country_name)s"
            */
            return default;
        }

        public async Task<TEntity> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, object help_message) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_empty_list_help(self, help_message):
            // """ This method returns the action helpers for the leads. If help is already provided
            //     on the action, the same is returned. Otherwise, we build the help message which
            //     contains the alias responsible for creating the lead (if available) and return it.
            // """
            // if not is_html_empty(help_message):
            //     return help_message
            // 
            // help_title, sub_title = "", ""
            // if self._context.get('default_type') == 'lead':
            //     help_title = _('Create a new lead')
            // else:
            //     help_title = _('Create an opportunity to start playing with your pipeline.')
            // alias_domain = [
            //     ('company_id', 'in', [self.env.company.id, False]),
            //     ('alias_id.alias_name', '!=', False),
            //     ('alias_id.alias_name', '!=', ''),
            //     ('alias_id.alias_model_id.model', '=', 'crm.lead'),
            // ]
            // # sort by use_leads, then by our membership of the team
            // alias_records = self.env['crm.team'].search(alias_domain).sorted(
            //     lambda r: (r.use_leads, self.env.user in r.member_ids), reverse=True
            // )
            // alias_record = alias_records[0] if alias_records else None
            // if alias_record and alias_record.alias_domain and alias_record.alias_name:
            //     sub_title = Markup(_('Use the <i>New</i> button, or send an email to %(email_link)s to test the email gateway.')) % {
            //         'email_link': Markup("<b><a href='mailto:%s'>%s</a></b>") % (alias_record.alias_email, alias_record.alias_email),
            //     }
            // return super().get_empty_list_help(
            //     f'<p class="o_view_nocontent_smiling_face">{help_title}</p><p class="oe_view_nocontent_alias">{sub_title}</p>'
            // )
            */
            return default;
        }

        public async Task<TEntity> GetGravatarImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_gravatar_image(self, email):
            // email_hash = hashlib.md5(email.lower().encode('utf-8')).hexdigest()
            // url = "https://www.gravatar.com/avatar/" + email_hash
            // try:
            //     res = requests.get(url, params={'d': '404', 's': '128'}, timeout=5)
            //     if res.status_code != requests.codes.ok:
            //         return False
            // except requests.exceptions.ConnectionError as e:
            //     return False
            // except requests.exceptions.Timeout as e:
            //     return False
            // return base64.b64encode(res.content)
            */
            return default;
        }

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Leads & Opportunities'),
            //     'template': '/crm/static/xls/crm_lead.xls'
            // }]
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Customers'),
            //     'template': '/base/static/xls/res_partner.xlsx'
            // }]
            */
            return default;
        }

        public async Task<TEntity> GetLeadDuplicatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner, object email, object include_lost) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_lead_duplicates(self, partner=None, email=None, include_lost=False):
            // """ Search for leads that seem duplicated based on partner / email.
            // 
            // :param partner : optional customer when searching duplicated
            // :param email: email (possibly formatted) to search
            // :param boolean include_lost: if True, search includes archived opportunities
            //   (still only active leads are considered). If False, search for active
            //   and not won leads and opportunities;
            // """
            // if not email and not partner:
            //     return self.env['crm.lead']
            // 
            // domain = []
            // for normalized_email in [tools.email_normalize(email) for email in tools.email_split(email)]:
            //     domain.append(('email_normalized', '=', normalized_email))
            // if partner:
            //     domain.append(('partner_id', '=', partner.id))
            // 
            // if not domain:
            //     return self.env['crm.lead']
            // 
            // domain = ['|'] * (len(domain) - 1) + domain
            // if include_lost:
            //     domain += ['|', ('type', '=', 'opportunity'), ('active', '=', True)]
            // else:
            //     domain += ['&', ('active', '=', True), '|', ('stage_id', '=', False), ('stage_id.is_won', '=', False)]
            // 
            // return self.with_context(active_test=False).search(domain)
            */
            return default;
        }

        public async Task<TEntity> GetLogoInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_logo(self):
            // with file_open('base/static/img/res_company_logo.png', 'rb') as file:
            //     return base64.b64encode(file.read())
            */
            return default;
        }

        public async Task<TEntity> GetMainCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> GetOpportunityMeetingViewParametersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_opportunity_meeting_view_parameters(self):
            // """ Return the most relevant parameters for calendar view when viewing meetings linked to an opportunity.
            //     If there are any meetings that are not finished yet, only consider those meetings,
            //     since the user would prefer no to see past meetings. Otherwise, consider all meetings.
            //     Allday events datetimes are used without taking tz into account.
            //     -If there is no event, return week mode and false (The calendar will target 'now' by default)
            //     -If there is only one, return week mode and date of the start of the event.
            //     -If there are several events entirely on the same week, return week mode and start of first event.
            //     -Else, return month mode and the date of the start of first event as initial date. (If they are
            //     on the same month, this will display that month and therefore show all of them, which is expected)
            // 
            //     :return tuple(mode, initial_date)
            //         - mode: selected mode of the calendar view, 'week' or 'month'
            //         - initial_date: date of the start of the first relevant meeting. The calendar will target that date.
            // """
            // self.ensure_one()
            // meeting_results = self.env["calendar.event"].search_read([('opportunity_id', '=', self.id)], ['start', 'stop', 'allday'])
            // if not meeting_results:
            //     return "week", False
            // 
            // user_tz = self.env.user.tz or self.env.context.get('tz')
            // user_pytz = pytz.timezone(user_tz) if user_tz else pytz.utc
            // 
            // # meeting_dts will contain one tuple of datetimes per meeting : (Start, Stop)
            // # meetings_dts and now_dt are as per user time zone.
            // meeting_dts = []
            // now_dt = datetime.now().astimezone(user_pytz).replace(tzinfo=None)
            // 
            // # When creating an allday meeting, whatever the TZ, it will be stored the same e.g. 00.00.00->23.59.59 in utc or
            // # 08.00.00->18.00.00. Therefore we must not put it back in the user tz but take it raw.
            // for meeting in meeting_results:
            //     if meeting.get('allday'):
            //         meeting_dts.append((meeting.get('start'), meeting.get('stop')))
            //     else:
            //         meeting_dts.append((meeting.get('start').astimezone(user_pytz).replace(tzinfo=None),
            //                            meeting.get('stop').astimezone(user_pytz).replace(tzinfo=None)))
            // 
            // # If there are meetings that are still ongoing or to come, only take those.
            // unfinished_meeting_dts = [meeting_dt for meeting_dt in meeting_dts if meeting_dt[1] >= now_dt]
            // relevant_meeting_dts = unfinished_meeting_dts if unfinished_meeting_dts else meeting_dts
            // relevant_meeting_count = len(relevant_meeting_dts)
            // 
            // if relevant_meeting_count == 1:
            //     return "week", relevant_meeting_dts[0][0].date()
            // else:
            //     # Range of meetings
            //     earliest_start_dt = min(relevant_meeting_dt[0] for relevant_meeting_dt in relevant_meeting_dts)
            //     latest_stop_dt = max(relevant_meeting_dt[1] for relevant_meeting_dt in relevant_meeting_dts)
            // 
            //     # The week start day depends on language. We fetch the week_start of user's language. 1 is monday.
            //     lang_week_start = self.env["res.lang"].search_read([('code', '=', self.env.user.lang)], ['week_start'])
            //     # We substract one to make week_start_index range 0-6 instead of 1-7
            //     week_start_index = int(lang_week_start[0].get('week_start', '1')) - 1
            // 
            //     # We compute the weekday of earliest_start_dt according to week_start_index. earliest_start_dt_index will be 0 if we are on the
            //     # first day of the week and 6 on the last. weekday() returns 0 for monday and 6 for sunday. For instance, Tuesday in UK is the
            //     # third day of the week, so earliest_start_dt_index is 2, and remaining_days_in_week includes tuesday, so it will be 5.
            //     # The first term 7 is there to avoid negative left side on the modulo, improving readability.
            //     earliest_start_dt_weekday = (7 + earliest_start_dt.weekday() - week_start_index) % 7
            //     remaining_days_in_week = 7 - earliest_start_dt_weekday
            // 
            //     # We compute the start of the week following the one containing the start of the first meeting.
            //     next_week_start_date = earliest_start_dt.date() + timedelta(days=remaining_days_in_week)
            // 
            //     # Latest_stop_dt must be before the start of following week. Limit is therefore set at midnight of first day, included.
            //     meetings_in_same_week = latest_stop_dt <= datetime(next_week_start_date.year, next_week_start_date.month, next_week_start_date.day, 0, 0, 0)
            // 
            //     if meetings_in_same_week:
            //         return "week", earliest_start_dt.date()
            //     else:
            //         return "month", earliest_start_dt.date()
            */
            return default;
        }

        public async Task<TEntity> GetPartnerEmailUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_partner_email_update(self, force_void=True):
            // """Calculate if we should write the email on the related partner. When
            // the email of the lead / partner is an empty string, we force it to False
            // to not propagate a False on an empty string.
            // 
            // Done in a separate method so it can be used in both ribbon and inverse
            // and compute of email update methods.
            // 
            // :param bool force_void: if False, skip when lead has a void email value.
            //   This is used notably to avoid propagating void lead value to a valid
            //   partner value.
            // """
            // self.ensure_one()
            // if self.partner_id and (force_void or self.email_from) and self.email_from != self.partner_id.email:
            //     lead_email_normalized = tools.email_normalize(self.email_from) or self.email_from or False
            //     partner_email_normalized = tools.email_normalize(self.partner_id.email) or self.partner_id.email or False
            //     return lead_email_normalized != partner_email_normalized
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetPartnerPhoneUpdateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_void) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_partner_phone_update(self, force_void=True):
            // """Calculate if we should write the phone on the related partner. When
            // the phone of the lead / partner is an empty string, we force it to False
            // to not propagate a False on an empty string.
            // 
            // Done in a separate method so it can be used in both ribbon and inverse
            // and compute of phone update methods.
            // 
            // :param bool force_void: if False, skip when lead has a void phone value.
            //   This is used notably to avoid propagating void lead value to a valid
            //   partner value.
            // """
            // self.ensure_one()
            // if self.partner_id and (force_void or self.phone) and self.phone != self.partner_id.phone:
            //     lead_phone_formatted = self._phone_format(fname='phone') or self.phone or False
            //     partner_phone_formatted = self.partner_id._phone_format(fname='phone') or self.partner_id.phone or False
            //     return lead_phone_formatted != partner_phone_formatted
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetPublicUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_public_user(self):
            // self.ensure_one()
            // # We need sudo to be able to see public users from others companies too
            // public_users = self.env.ref('base.group_public').sudo().with_context(active_test=False).users
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

        public async Task<TEntity> GetRainbowmanMessageAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_rainbowman_message(self):
            // self.ensure_one()
            // if self.stage_id.is_won:
            //     return self._get_rainbowman_message()
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetRainbowmanMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_rainbowman_message(self):
            // if not self.user_id or not self.team_id:
            //     return False
            // if not self.expected_revenue:
            //     # Show rainbow man for the first won lead of a salesman, even if expected revenue is not set. It is not
            //     # very often that leads without revenues are marked won, so simply get count using ORM instead of query
            //     today = fields.Datetime.today()
            //     user_won_leads_count = self.search_count([
            //         ('type', '=', 'opportunity'),
            //         ('user_id', '=', self.user_id.id),
            //         ('probability', '=', 100),
            //         ('date_closed', '>=', date_utils.start_of(today, 'year')),
            //         ('date_closed', '<', date_utils.end_of(today, 'year')),
            //     ])
            //     if user_won_leads_count == 1:
            //         return _('Go, go, go! Congrats for your first deal.')
            //     return False
            // 
            // self.flush_model()  # flush fields to make sure DB is up to date
            // query = """
            //     SELECT
            //         SUM(CASE WHEN user_id = %(user_id)s THEN 1 ELSE 0 END) as total_won,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '30 days' AND user_id = %(user_id)s THEN expected_revenue ELSE 0 END) as max_user_30,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '7 days' AND user_id = %(user_id)s THEN expected_revenue ELSE 0 END) as max_user_7,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '30 days' AND team_id = %(team_id)s THEN expected_revenue ELSE 0 END) as max_team_30,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '7 days' AND team_id = %(team_id)s THEN expected_revenue ELSE 0 END) as max_team_7
            //     FROM crm_lead
            //     WHERE
            //         type = 'opportunity'
            //     AND
            //         active = True
            //     AND
            //         probability = 100
            //     AND
            //         DATE_TRUNC('year', date_closed) = DATE_TRUNC('year', CURRENT_DATE)
            //     AND
            //         (user_id = %(user_id)s OR team_id = %(team_id)s)
            // """
            // self.env.cr.execute(query, {'user_id': self.user_id.id,
            //                             'team_id': self.team_id.id})
            // query_result = self.env.cr.dictfetchone()
            // 
            // message = False
            // if query_result['total_won'] == 1:
            //     message = _('Go, go, go! Congrats for your first deal.')
            // elif query_result['max_team_30'] == self.expected_revenue:
            //     message = _('Boom! Team record for the past 30 days.')
            // elif query_result['max_team_7'] == self.expected_revenue:
            //     message = _('Yeah! Deal of the last 7 days for the team.')
            // elif query_result['max_user_30'] == self.expected_revenue:
            //     message = _('You just beat your personal record for the past 30 days.')
            // elif query_result['max_user_7'] == self.expected_revenue:
            //     message = _('You just beat your personal record for the past 7 days.')
            // return message
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_street_split(self):
            // self.ensure_one()
            // return tools.street_split(self.street or '')
            */
            return default;
        }

        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_view_cache_key(self, view_id=None, view_type='form', **options):
            // """The override of _get_view, using _view_get_address,
            // changing the architecture according to the address view of the company,
            // makes the view cache dependent on the company.
            // Different companies could use each a different address view"""
            // key = super()._get_view_cache_key(view_id, view_type, **options)
            // return key + (self.env.company, self._context.get('no_address_format'),)
            */
            return default;
        }

        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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
            // if view.type == 'form':
            //     arch = self._view_get_address(arch)
            // return arch, view
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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
            //     addr_vals = self._update_fields_values(address_fields)
            //     parent.update_address(addr_vals)
            */
            return default;
        }

        public async Task<TEntity> HandlePartnerAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid force_partner_id, object create_missing) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_partner_assignment(self, force_partner_id=False, create_missing=True):
            // """ Update customer (partner_id) of leads. Purpose is to set the same
            // partner on most leads; either through a newly created partner either
            // through a given partner_id.
            // 
            // :param int force_partner_id: if set, update all leads to that customer;
            // :param create_missing: for leads without customer, create a new one
            //   based on lead information;
            // """
            // for lead in self:
            //     if force_partner_id:
            //         lead.partner_id = force_partner_id
            //     if not lead.partner_id and create_missing:
            //         partner = lead._create_customer()
            //         lead.partner_id = partner.id
            */
            return default;
        }

        public async Task<TEntity> HandleSalesmenAssignmentInternalAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> user_ids, Guid team_id) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_salesmen_assignment(self, user_ids=False, team_id=False):
            // """ Assign salesmen and salesteam to a batch of leads.  If there are more
            // leads than salesmen, these salesmen will be assigned in round-robin. E.g.
            // 4 salesmen (S1, S2, S3, S4) for 6 leads (L1, L2, ... L6) will assigned as
            // following: L1 - S1, L2 - S2, L3 - S3, L4 - S4, L5 - S1, L6 - S2.
            // 
            // :param list user_ids: salesmen to assign
            // :param int team_id: salesteam to assign
            // """
            // update_vals = {'team_id': team_id} if team_id else {}
            // if not user_ids and team_id:
            //     self.write(update_vals)
            // else:
            //     lead_ids = self.ids
            //     steps = len(user_ids)
            //     # pass 1 : lead_ids[0:6:3] = [L1,L4]
            //     # pass 2 : lead_ids[1:6:3] = [L2,L5]
            //     # pass 3 : lead_ids[2:6:3] = [L3,L6]
            //     # ...
            //     for idx in range(0, steps):
            //         subset_ids = lead_ids[idx:len(lead_ids):steps]
            //         update_vals['user_id'] = user_ids[idx]
            //         self.env['crm.lead'].browse(subset_ids).write(update_vals)
            */
            return default;
        }

        public async Task<TEntity> HandleWonLostInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_won_lost(self, vals):
            // """ This method handle the state changes :
            // - To lost : We need to increment corresponding lost count in scoring frequency table
            // - To won : We need to increment corresponding won count in scoring frequency table
            // - From lost to Won : We need to decrement corresponding lost count + increment corresponding won count
            // in scoring frequency table.
            // - From won to lost : We need to decrement corresponding won count + increment corresponding lost count
            // in scoring frequency table."""
            // Lead = self.env['crm.lead']
            // leads_reach_won = Lead
            // leads_leave_won = Lead
            // leads_reach_lost = Lead
            // leads_leave_lost = Lead
            // won_stage_ids = self.env['crm.stage'].search([('is_won', '=', True)]).ids
            // for lead in self:
            //     if 'stage_id' in vals:
            //         if vals['stage_id'] in won_stage_ids:
            //             if lead.probability == 0:
            //                 leads_leave_lost += lead
            //             leads_reach_won += lead
            //         elif lead.stage_id.id in won_stage_ids and lead.active:  # a lead can be lost at won_stage
            //             leads_leave_won += lead
            //     if 'active' in vals:
            //         if not vals['active'] and lead.active:  # archive lead
            //             if lead.stage_id.id in won_stage_ids and lead not in leads_leave_won:
            //                 leads_leave_won += lead
            //             leads_reach_lost += lead
            //         elif vals['active'] and not lead.active:  # restore lead
            //             leads_leave_lost += lead
            // 
            // leads_reach_won._pls_increment_frequencies(to_state='won')
            // leads_leave_won._pls_increment_frequencies(from_state='won')
            // leads_reach_lost._pls_increment_frequencies(to_state='lost')
            // leads_leave_lost._pls_increment_frequencies(from_state='lost')
            */
            return default;
        }

        public async Task<TEntity> InitAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def init(self):
            // for company in self.search([('paperformat_id', '=', False)]):
            //     paperformat_euro = self.env.ref('base.paperformat_euro', False)
            //     if paperformat_euro:
            //         company.write({'paperformat_id': paperformat_euro.id})
            // sup = super(Company, self)
            // if hasattr(sup, 'init'):
            //     sup.init()
            */
            return default;
        }

        public async Task<TEntity> InstallL10nModulesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def install_l10n_modules(self):
            // uninstalled_modules = self.uninstalled_l10n_module_ids
            // is_ready_and_not_test = (
            //     not tools.config['test_enable']
            //     and (self.env.registry.ready or not self.env.registry._init)
            //     and not getattr(threading.current_thread(), 'testing', False)
            // )
            // if uninstalled_modules and is_ready_and_not_test:
            //     return uninstalled_modules.button_immediate_install()
            // return is_ready_and_not_test
            */
            return default;
        }

        public async Task<TEntity> InverseCityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_city(self):
            // for company in self:
            //     company.partner_id.city = company.city
            */
            return default;
        }

        public async Task<TEntity> InverseColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_color(self):
            // for company in self:
            //     company.root_id.partner_id.color = company.color
            */
            return default;
        }

        public async Task<TEntity> InverseCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_country(self):
            // for company in self:
            //     company.partner_id.country_id = company.country_id
            */
            return default;
        }

        public async Task<TEntity> InverseEmailFromInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _inverse_email_from(self):
            // for lead in self:
            //     if lead._get_partner_email_update(force_void=False):
            //         lead.partner_id.email = lead.email_from
            */
            return default;
        }

        public async Task<TEntity> InversePhoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _inverse_phone(self):
            // for lead in self:
            //     if lead._get_partner_phone_update(force_void=False):
            //         lead.partner_id.phone = lead.phone
            */
            return default;
        }

        public async Task<TEntity> InverseStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_state(self):
            // for company in self:
            //     company.partner_id.state_id = company.state_id
            */
            return default;
        }

        public async Task<TEntity> InverseStreet2InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_street2(self):
            // for company in self:
            //     company.partner_id.street2 = company.street2
            */
            return default;
        }

        public async Task<TEntity> InverseStreetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_street(self):
            // for company in self:
            //     company.partner_id.street = company.street
            */
            return default;
        }

        public async Task<TEntity> InverseZipInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_zip(self):
            // for company in self:
            //     company.partner_id.zip = company.zip
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _load_records_create(self, vals_list):
            // partners = super(Partner, self.with_context(_partners_skip_fields_sync=True))._load_records_create(vals_list)
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
            //         to_write = self.browse(cp_id)._update_fields_values(self._commercial_fields())
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

        public async Task<TEntity> LogMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object meeting) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def log_meeting(self, meeting):
            // """ Log the meeting info with a link to it in the chatter
            // :param record meeting: the meeting we want to log
            // """
            // if not meeting.duration:
            //     duration = _('unknown')
            // else:
            //     duration = self.env['ir.qweb.field.duration'].value_to_html(meeting.duration, {'unit': 'hour'})
            // meeting_usertime = fields.Datetime.to_string(fields.Datetime.context_timestamp(self, meeting.start))
            // meeting_time = Markup("<time datetime='%(meeting_start)s+00:00'>%(meeting_user_time)s</time>") % {
            //     'meeting_start': meeting.start,
            //     'meeting_user_time': meeting_usertime,
            // }
            // message = Markup("<p>%(meeting)s<br/>%(subject_string)s %(subject_link)s<br/>%(duration)s<p>") % {
            //     'meeting': _("Meeting scheduled at %s", meeting_time),
            //     'subject_string': _("Subject: "),
            //     'subject_link': meeting._get_html_link(),
            //     'duration': _("Duration: %s", duration),
            // }
            // return self.message_post(body=message)
            */
            return default;
        }

        public async Task<TEntity> MergeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fnames) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_data(self, fnames=None):
            // """ Prepare lead/opp data into a dictionary for merging. Different types
            //     of fields are processed in different ways:
            //         - text: all the values are concatenated
            //         - m2m and o2m: those fields aren't processed
            //         - m2o: the first not null value prevails (the other are dropped)
            //         - any other type of field: same as m2o
            // 
            //     :param fields: list of fields to process
            //     :return dict data: contains the merged values of the new opportunity
            // """
            // if fnames is None:
            //     fnames = self._merge_get_fields()
            // fcallables = self._merge_get_fields_specific()
            // address_values = self._merge_get_fields_address()
            // 
            // # helpers
            // def _get_first_not_null(attr, opportunities):
            //     value = False
            //     for opp in opportunities:
            //         if opp[attr]:
            //             value = opp[attr].id if isinstance(opp[attr], models.BaseModel) else opp[attr]
            //             break
            //     return value
            // 
            // # process the field's values
            // data = {}
            // for field_name in fnames:
            //     field = self._fields.get(field_name)
            //     if field is None:
            //         continue
            // 
            //     fcallable = fcallables.get(field_name)
            //     if fcallable and callable(fcallable):
            //         data[field_name] = fcallable(field_name, self)
            //     elif field_name in address_values:
            //         data[field_name] = address_values[field_name]
            //     elif not fcallable and field.type in ('many2many', 'one2many'):
            //         continue
            //     else:
            //         data[field_name] = _get_first_not_null(field_name, self)  # take the first not null
            // 
            // return data
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesAttachmentsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_attachments(self, opportunities):
            // """ Move attachments of given opportunities to the current one `self`, and rename
            //     the attachments having same name than native ones.
            // 
            // :param opportunities: see ``_merge_dependences``
            // """
            // self.ensure_one()
            // 
            // all_attachments = self.env['ir.attachment'].search([
            //     ('res_model', '=', self._name),
            //     ('res_id', 'in', opportunities.ids)
            // ])
            // 
            // for opportunity in opportunities:
            //     attachments = all_attachments.filtered(lambda attach: attach.res_id == opportunity.id)
            //     for attachment in attachments:
            //         attachment.write({
            //             'res_id': self.id,
            //             'name': _("%(attach_name)s (from %(lead_name)s)",
            //                       attach_name=attachment.name,
            //                       lead_name=opportunity.name[:20]
            //                      )
            //         })
            // return True
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesCalendarEventsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_calendar_events(self, opportunities):
            // """ Move calender.event from the given opportunities to the current one. `self` is the
            //     crm.lead record destination for event of `opportunities`.
            // :param opportunities: see ``merge_dependences``
            // """
            // self.ensure_one()
            // meetings = self.env['calendar.event'].search([('opportunity_id', 'in', opportunities.ids)])
            // return meetings.write({
            //     'res_id': self.id,
            //     'opportunity_id': self.id,
            // })
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesHistoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_history(self, opportunities):
            // """ Move history from the given opportunities to the current one. `self`
            // is the crm.lead record destination for message of `opportunities`.
            // 
            // This method moves
            //   * messages
            //   * activities
            // 
            // :param opportunities: see ``_merge_dependences``
            // """
            // self.ensure_one()
            // # sudo usage: because we want to go through all messages, whatever the real ACLs
            // # current user has on them
            // for opportunity_su in opportunities.sudo():
            //     for message_su in opportunity_su.message_ids:
            //         if message_su.subject:
            //             subject = _("From %(source_name)s: %(source_subject)s", source_name=opportunity_su.name, source_subject=message_su.subject)
            //         else:
            //             subject = _("From %(source_name)s", source_name=opportunity_su.name)
            //         message_su.write({
            //             'res_id': self.id,
            //             'subject': subject,
            //         })
            // opportunities.activity_ids.write({
            //     'res_id': self.id,
            // })
            // 
            // return True
            */
            return default;
        }

        public async Task<TEntity> MergeDependencesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences(self, opportunities):
            // """ Merge dependences (messages, attachments,activities, calendar events,
            // ...). These dependences will be transfered to `self` considered as the
            // master lead.
            // 
            // :param opportunities : recordset of opportunities to transfer. Does not
            //   include `self` which is the target crm.lead being the result of the
            //   merge;
            // """
            // self.ensure_one()
            // self._merge_dependences_history(opportunities)
            // self._merge_dependences_attachments(opportunities)
            // self._merge_dependences_calendar_events(opportunities)
            */
            return default;
        }

        public async Task<TEntity> MergeFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object opportunities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_followers(self, opportunities):
            // """Add the followers into the destination lead if they post a message in the last 30 days.
            // 
            // :param opportunities : Record<crm.lead> of opportunities to transfer
            // :return: {old_lead_id: Record<mail.followers>} Followers which have been added in
            //     the destination lead grouped by source lead ID.
            // """
            // self.ensure_one()
            // 
            // self.env['mail.message'].flush_model()
            // self.env['mail.followers'].flush_model()
            // 
            // # Get the active followers (followers whose partner post a message on the
            // # leads in the last 30 days) which should be moved on the destination lead
            // self.env.cr.execute(
            //     '''
            //     SELECT MAX(mf.id) AS id
            //       FROM mail_followers AS mf
            //       JOIN mail_message AS mm
            //         ON mm.author_id = mf.partner_id
            //        AND mm.res_id = mf.res_id
            //        AND mm.model = 'crm.lead'
            //        AND mm.date > NOW() - INTERVAL '30 DAY'
            //            /* Check if the partner is already
            //               following the destination lead */
            //  LEFT JOIN mail_followers AS destf
            //         ON destf.res_model = 'crm.lead'
            //        AND destf.res_id = %(lead_id)s
            //        AND destf.partner_id = mf.partner_id
            //            /* Select only once each partner
            //               to not create duplicated followers */
            //      WHERE mf.res_model = 'crm.lead'
            //        AND mf.res_id IN %(lead_ids)s
            //        AND destf IS NULL
            //   GROUP BY mf.partner_id
            //     ''',
            //     {'lead_ids': tuple(opportunities.ids), 'lead_id': self.id},
            // )
            // followers_to_update = [r[0] for r in self.env.cr.fetchall()]
            // followers_to_update = self.env['mail.followers'].browse(followers_to_update).sudo()
            // followers_by_old_lead = dict(groupby(followers_to_update, lambda f: f.res_id))
            // followers_to_update.write({'res_id': self.id})
            // return followers_by_old_lead
            #endif
            return default;
        }

        public async Task<TEntity> MergeGetFieldsAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_address(self):
            // """The address fields are propagated as a whole.
            // 
            // The address is taken from the lead with the most non-empty address field
            // (sorted by highest rank if multiple lead have the same amount of non-empty
            // fields).
            // """
            // source_lead = max(self, key=lambda lead: len(list(
            //     lead[field] for field in PARTNER_ADDRESS_FIELDS_TO_SYNC
            //     if lead[field]
            // )))
            // return {fname: source_lead[fname] for fname in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields(self):
            // return (
            //     CRM_LEAD_FIELDS_TO_MERGE
            //     + list(self._merge_get_fields_specific().keys())
            //     + PARTNER_ADDRESS_FIELDS_TO_SYNC
            // )
            */
            return default;
        }

        public async Task<TEntity> MergeGetFieldsSpecificInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_specific(self):
            // return {
            //     'description': lambda fname, leads: '<br/><br/>'.join(desc for desc in leads.mapped('description') if not is_html_empty(desc)),
            //     'type': lambda fname, leads: 'opportunity' if any(lead.type == 'opportunity' for lead in leads) else 'lead',
            //     'priority': lambda fname, leads: max(priorities) if (priorities := leads.filtered('priority').mapped('priority')) else False,
            //     'tag_ids': lambda fname, leads: leads.mapped('tag_ids'),
            //     'lost_reason_id': lambda fname, leads:
            //         False if leads and leads[0].probability
            //         else next((lead.lost_reason_id for lead in leads if lead.lost_reason_id), False),
            // }
            */
            return default;
        }

        public async Task<TEntity> MergeLogSummaryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object merged_followers, object opportunities_tail) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_log_summary(self, merged_followers, opportunities_tail):
            // """Log the merge message on the lead."""
            // self.ensure_one()
            // self.message_post_with_source(
            //     "crm.crm_lead_merge_summary",
            //     render_values={
            //         "merged_followers": merged_followers,
            //         "opportunities": opportunities_tail,
            //         "is_html_empty": is_html_empty,
            //     },
            //     subtype_xmlid='mail.mt_note',
            // )
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def merge_opportunity(self, user_id=False, team_id=False, auto_unlink=True):
            // """ Merge opportunities in one. Different cases of merge:
            //         - merge leads together = 1 new lead
            //         - merge at least 1 opp with anything else (lead or opp) = 1 new opp
            //     The resulting lead/opportunity will be the most important one (based on its confidence level)
            //     updated with values from other opportunities to merge.
            // 
            // :param user_id : the id of the saleperson. If not given, will be determined by `_merge_data`.
            // :param team : the id of the Sales Team. If not given, will be determined by `_merge_data`.
            // 
            // :return crm.lead record resulting of th merge
            // """
            // return self._merge_opportunity(user_id=user_id, team_id=team_id, auto_unlink=auto_unlink)
            */
            return default;
        }

        public async Task<TEntity> MergeOpportunityInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, Guid team_id, object auto_unlink, object max_length) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_opportunity(self, user_id=False, team_id=False, auto_unlink=True, max_length=5):
            // """ Private merging method. This one allows to relax rules on record set
            // length allowing to merge more than 5 opportunities at once if requested.
            // This should not be called by action buttons.
            // 
            // See ``merge_opportunity`` for more details. """
            // if len(self.ids) <= 1:
            //     raise UserError(_('Select at least two Leads/Opportunities from the list to merge them.'))
            // 
            // if max_length and len(self.ids) > max_length and not self.env.is_superuser():
            //     raise UserError(_("To prevent data loss, Leads and Opportunities can only be merged by groups of %(max_length)s.", max_length=max_length))
            // 
            // opportunities = self._sort_by_confidence_level(reverse=True)
            // 
            // # get SORTED recordset of head and tail, and complete list
            // opportunities_head = opportunities[0]
            // opportunities_tail = opportunities[1:]
            // 
            // # merge all the sorted opportunity. This means the value of
            // # the first (head opp) will be a priority.
            // merged_data = opportunities._merge_data(self._merge_get_fields())
            // 
            // # force value for saleperson and Sales Team
            // if user_id:
            //     merged_data['user_id'] = user_id
            // if team_id:
            //     merged_data['team_id'] = team_id
            // 
            // merged_followers = opportunities_head._merge_followers(opportunities_tail)
            // 
            // # log merge message
            // opportunities_head._merge_log_summary(merged_followers, opportunities_tail)
            // # merge other data (mail.message, attachments, ...) from tail into head
            // opportunities_head._merge_dependences(opportunities_tail)
            // 
            // # check if the stage is in the stages of the Sales Team. If not, assign the stage with the lowest sequence
            // if merged_data.get('team_id'):
            //     team_stage_ids = self.env['crm.stage'].search(['|', ('team_id', '=', merged_data['team_id']), ('team_id', '=', False)], order='sequence, id')
            //     if merged_data.get('stage_id') not in team_stage_ids.ids:
            //         merged_data['stage_id'] = team_stage_ids[0].id if team_stage_ids else False
            // 
            // # write merged data into first opportunity; remove some keys if already
            // # set on opp to avoid useless recomputes
            // if 'user_id' in merged_data and opportunities_head.user_id.id == merged_data['user_id']:
            //     merged_data.pop('user_id')
            // if 'team_id' in merged_data and opportunities_head.team_id.id == merged_data['team_id']:
            //     merged_data.pop('team_id')
            // opportunities_head.write(merged_data)
            // 
            // # delete tail opportunities
            // # we use the SUPERUSER to avoid access rights issues because as the user had the rights to see the records it should be safe to do so
            // if auto_unlink:
            //     opportunities_tail.sudo().unlink()
            // 
            // return opportunities_head
            */
            return default;
        }

        public async Task<TEntity> MessageGetDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_get_default_recipients(self):
            // return {
            //     r.id: {
            //         'partner_ids': [],
            //         'email_to': ','.join(tools.email_normalize_all(r.email_from)) or r.email_from,
            //         'email_cc': False,
            //     } for r in self
            // }
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // try:
            //     # check if that language is correctly installed (and active) before using it
            //     lang_code = self.env['res.lang']._get_data(code=self.lang_code).code or None
            //     if self.partner_id:
            //         self._message_add_suggested_recipient(
            //             recipients, partner=self.partner_id, lang=lang_code, reason=_('Customer'))
            //     elif self.email_from:
            //         self._message_add_suggested_recipient(
            //             recipients, email=self.email_from, lang=lang_code, reason=_('Customer Email'))
            // except AccessError:  # no read access rights -> just ignore suggested recipients because this imply modifying followers
            //     pass
            // return recipients
            */
            return default;
        }

        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // """ Overrides mail_thread message_new that is called by the mailgateway
            //     through message_process.
            //     This override updates the document according to the email.
            // """
            // # remove default author when going through the mail gateway. Indeed we
            // # do not want to explicitly set an user as responsible. We prefer that
            // # assignment is done automatically (scoring) or manually. Otherwise it
            // # would always be root (gateway user). It also allows to exclude portal
            // # and public users.
            // self = self.with_context(default_user_id=False)
            // 
            // if custom_values is None:
            //     custom_values = {}
            // defaults = {
            //     'name':  msg_dict.get('subject') or _("No Subject"),
            //     'email_from': msg_dict.get('from'),
            //     'partner_id': msg_dict.get('author_id', False),
            // }
            // if msg_dict.get('priority') in dict(crm_stage.AVAILABLE_PRIORITIES):
            //     defaults['priority'] = msg_dict.get('priority')
            // defaults.update(custom_values)
            // 
            // return super(Lead, self).message_new(msg_dict, custom_values=defaults)
            */
            return default;
        }

        public async Task<TEntity> MessagePartnerInfoFromEmailsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object emails, object link_mail) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_partner_info_from_emails(self, emails, link_mail=False):
            // """ Try to propose a better recipient when having only an email by populating
            // it with the partner_name / contact_name field of the lead e.g. if lead
            // contact_name is "Raoul" and email is "raoul@raoul.fr", suggest
            // "Raoul" <raoul@raoul.fr> as recipient. """
            // result = super(Lead, self)._message_partner_info_from_emails(emails, link_mail=link_mail)
            // if not (self.partner_name or self.contact_name) or not self.email_from:
            //     return result
            // for email, partner_info in zip(emails, result):
            //     if partner_info.get('partner_id') or not email:
            //         continue
            //     # reformat email if no name information
            //     name_emails = tools.mail.email_split_tuples(email)
            //     name_from_email = name_emails[0][0] if name_emails else False
            //     if name_from_email:
            //         continue  # already containing name + email
            //     name_from_email = self.partner_name or self.contact_name
            //     emails_normalized = tools.email_normalize_all(email)
            //     email_normalized = emails_normalized[0] if emails_normalized else False
            //     if email.lower() == self.email_from.lower() or (email_normalized and self.email_normalized == email_normalized):
            //         partner_info['full_name'] = tools.formataddr((
            //             name_from_email,
            //             ','.join(emails_normalized) if emails_normalized else email))
            //         break
            // return result
            */
            return default;
        }

        public async Task<TEntity> MessagePostAfterHookInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if self.email_from and not self.partner_id:
            //     # we consider that posting a message with a specified recipient (not a follower, a specific one)
            //     # on a document without customer means that it was created through the chatter using
            //     # suggested recipients. This heuristic allows to avoid ugly hacks in JS.
            //     new_partner = message.partner_ids.filtered(
            //         lambda partner: partner.email == self.email_from or (self.email_normalized and partner.email_normalized == self.email_normalized)
            //     )
            //     if new_partner:
            //         if new_partner[0].email_normalized:
            //             email_domain = ('email_normalized', '=', new_partner[0].email_normalized)
            //         else:
            //             email_domain = ('email_from', '=', new_partner[0].email)
            //         self.search([
            //             ('partner_id', '=', False), email_domain, ('stage_id.fold', '=', False)
            //         ]).write({'partner_id': new_partner[0].id})
            // return super(Lead, self)._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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
            // default_type = self._context.get('default_type')
            // if default_type and default_type not in self._fields['type'].get_values(self.env):
            //     context = dict(self._context)
            //     context.pop('default_type')
            //     self = self.with_context(context)
            // name, email_normalized = tools.parse_contact_from_email(name)
            // if self._context.get('force_email') and not email_normalized:
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

        public async Task<TEntity> NotifyByEmailPrepareRenderingContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object msg_vals, object model_description, object force_email_company, object force_email_lang) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // if self.date_deadline:
            //     render_context['subtitles'].append(
            //         _('Deadline: %s', self.date_deadline.strftime(get_lang(self.env).date_format)))
            // return render_context
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Handle salesman recipients that can convert leads into opportunities
            // and set opportunities as won / lost. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // local_msg_vals = dict(msg_vals or {})
            // 
            // self.ensure_one()
            // if self.type == 'lead':
            //     convert_action = self._notify_get_action_link('controller', controller='/lead/convert', **local_msg_vals)
            //     salesman_actions = [{'url': convert_action, 'title': _('Convert to opportunity')}]
            // else:
            //     won_action = self._notify_get_action_link('controller', controller='/lead/case_mark_won', **local_msg_vals)
            //     lost_action = self._notify_get_action_link('controller', controller='/lead/case_mark_lost', **local_msg_vals)
            //     salesman_actions = [
            //         {'url': won_action, 'title': _('Mark Won')},
            //         {'url': lost_action, 'title': _('Mark Lost')}]
            // 
            // salesman_group_id = self.env.ref('sales_team.group_sale_salesman').id
            // new_group = (
            //     'group_sale_salesman',
            //     lambda pdata: pdata['type'] == 'user' and salesman_group_id in pdata['groups'],
            //     {
            //         'actions': salesman_actions,
            //         'active': True,
            //         'has_button_access': True,
            //     }
            // )
            // 
            // return [new_group] + groups
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_get_reply_to(self, default=None):
            // """ Override to set alias of lead and opportunities to their sales team if any. """
            // aliases = self.mapped('team_id').sudo()._notify_get_reply_to(default=default)
            // res = {lead.id: aliases.get(lead.team_id.id) for lead in self}
            // leftover = self.filtered(lambda rec: not rec.team_id)
            // if leftover:
            //     res.update(super(Lead, leftover)._notify_get_reply_to(default=default))
            // return res
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_company_id(self):
            // if self.parent_id:
            //     self.company_id = self.parent_id.company_id.id
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_company_type(self):
            // self.is_company = (self.company_type == 'company')
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> OnchangeEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_email(self):
            // if not self.image_1920 and self._context.get('gravatar_image') and self.email:
            //     self.image_1920 = self._get_gravatar_image(self.email)
            */
            return default;
        }

        public async Task<TEntity> OnchangeMobileValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _onchange_mobile_validation(self):
            // if self.mobile:
            //     self.mobile = self._phone_format(fname='mobile', force_format='INTERNATIONAL') or self.mobile
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_parent_id(self):
            // # return values in result, as this method is used by _fields_sync()
            // if not self.parent_id:
            //     return
            // result = {}
            // partner = self._origin
            // if partner.parent_id and partner.parent_id != self.parent_id:
            //     result['warning'] = {
            //         'title': _('Warning'),
            //         'message': _('Changing the company of a contact should only be done if it '
            //                      'was never correctly set. If an existing contact starts working for a new '
            //                      'company then a new contact should be created under that new '
            //                      'company. You can use the "Discard" button to abandon this change.')}
            // if partner.type == 'contact' or self.type == 'contact':
            //     # for contacts: copy the parent address, if set (aka, at least one
            //     # value is set in the address: otherwise, keep the one from the
            //     # contact)
            //     address_fields = self._address_fields()
            //     if any(self.parent_id[key] for key in address_fields):
            //         def convert(value):
            //             return value.id if isinstance(value, models.BaseModel) else value
            //         result['value'] = {key: convert(self.parent_id[key]) for key in address_fields}
            // return result
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdForLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_parent_id_for_lang(self):
            // # While creating / updating child contact, take the parent lang by default if any
            // # otherwise, fallback to default context / DB lang
            // if self.parent_id:
            //     self.lang = self.parent_id.lang or self.env.context.get('default_lang') or self.env.lang
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> OnchangePhoneValidationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _onchange_phone_validation(self):
            // if self.phone:
            //     self.phone = self._phone_format(fname='phone', force_format='INTERNATIONAL') or self.phone
            */
            return default;
        }

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> PlsGetLeadPlsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_lead_pls_values(self, domain=[]):
            // """
            // This methods builds a dict where, for each lead in self or matching the given domain,
            // we will get a list of field/value couple.
            // Due to onchange and create, we don't always have the id of the lead to recompute.
            // When we update few records (one, typically) with onchanges, we build the lead_values (= couple field/value)
            // using the ORM.
            // To speed up the computation and avoid making too much DB read inside loops,
            // we can give a domain to make sql queries to bypass the ORM.
            // This domain will be used in sql queries to get the values for every lead matching the domain.
            // :param domain: If set, we get all the leads values via unique sql queries (one for tags, one for other fields),
            //                     using the given domain on leads.
            //                If not set, get lead values lead by lead using the ORM.
            // :return: {lead_id: [(field1: value1), (field2: value2), ...], ...}
            // """
            // leads_values_dict = OrderedDict()
            // pls_fields = ["stage_id", "team_id"] + self._pls_get_safe_fields()
            // 
            // # Check if tag_ids is in the pls_fields and removed it from the list. The tags will be managed separately.
            // use_tags = 'tag_ids' in pls_fields
            // if use_tags:
            //     pls_fields.remove('tag_ids')
            // 
            // if domain:
            //     # Get leads values
            //     self.flush_model()
            //     # active_test = False as domain should take active into 'active' field it self
            //     query = self.env['crm.lead'].with_context(active_test=False)._where_calc(domain)
            //     table = query.table
            //     query.order = SQL("%(table)s.team_id asc, %(table)s.id desc", table=SQL.identifier(table))
            //     sql_fields = [SQL.identifier(field) for field in pls_fields]
            //     self._cr.execute(query.select(
            //         SQL("id"),
            //         SQL("probability"),
            //         *sql_fields,
            //     ))
            //     lead_results = self._cr.dictfetchall()
            // 
            //     if use_tags:
            //         # Get tags values
            //         tag_rel_alias = query.left_join(table, 'id', 'crm_tag_rel', 'lead_id', 'crm_tag_rel')
            //         tag_alias = query.left_join(tag_rel_alias, 'tag_id', 'crm_tag', 'id', 'crm_tag')
            //         self._cr.execute(query.select(
            //             SQL("%s AS lead_id", SQL.identifier(table, "id")),
            //             SQL("%s AS tag_id", SQL.identifier(tag_alias, "id")),
            //         ))
            //         tag_results = self._cr.dictfetchall()
            //     else:
            //         tag_results = []
            // 
            //     # get all (variable, value) couple for all in self
            //     for lead in lead_results:
            //         lead_values = []
            //         for field in pls_fields + ['probability']:  # add probability as used in _pls_prepare_frequencies (needed in rebuild mode)
            //             value = lead[field]
            //             if field == 'team_id':  # ignore team_id as stored separately in leads_values_dict[lead_id][team_id]
            //                 continue
            //             if value or field == 'probability':  # 0 is a correct value for probability
            //                 lead_values.append((field, value))
            //             elif field in ('email_state', 'phone_state'):  # As ORM reads 'None' as 'False', do the same here
            //                 lead_values.append((field, False))
            //             leads_values_dict[lead['id']] = {'values': lead_values, 'team_id': lead['team_id'] or 0}
            // 
            //     for tag in tag_results:
            //         if tag['tag_id']:
            //             leads_values_dict[tag['lead_id']]['values'].append(('tag_id', tag['tag_id']))
            //     return leads_values_dict
            // else:
            //     for lead in self:
            //         lead_values = []
            //         for field in pls_fields:
            //             if field == 'team_id':  # ignore team_id as stored separately in leads_values_dict[lead_id][team_id]
            //                 continue
            //             value = lead[field].id if isinstance(lead[field], models.BaseModel) else lead[field]
            //             if value or field in ('email_state', 'phone_state'):
            //                 lead_values.append((field, value))
            //         if use_tags:
            //             for tag in lead.tag_ids:
            //                 lead_values.append(('tag_id', tag.id))
            //         leads_values_dict[lead.id] = {'values': lead_values, 'team_id': lead['team_id'].id}
            //     return leads_values_dict
            */
            return default;
        }

        public async Task<TEntity> PlsGetNaiveBayesProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object batch_mode) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_naive_bayes_probabilities(self, batch_mode=False):
            // """
            // In machine learning, naive Bayes classifiers (NBC) are a family of simple "probabilistic classifiers" based on
            // applying Bayes theorem with strong (naive) independence assumptions between the variables taken into account.
            // E.g: will TDE eat m&m's depending on his sleep status, the amount of work he has and the fullness of his stomach?
            // As we use experience to compute the statistics, every day, we will register the variables state + the result.
            // As the days pass, we will be able to determine, with more and more precision, if TDE will eat m&m's
            // for a specific combination :
            //     - did sleep very well, a lot of work and stomach full > Will never happen !
            //     - didn't sleep at all, no work at all and empty stomach > for sure !
            // Following Bayes' Theorem: the probability that an event occurs (to win) under certain conditions is proportional
            // to the probability to win under each condition separately and the probability to win. We compute a 'Win score'
            // -> P(Won | A∩B) ∝ P(A∩B | Won)*P(Won) OR S(Won | A∩B) = P(A∩B | Won)*P(Won)
            // To compute a percentage of probability to win, we also compute the 'Lost score' that is proportional to the
            // probability to lose under each condition separately and the probability to lose.
            // -> Probability =  S(Won | A∩B) / ( S(Won | A∩B) + S(Lost | A∩B) )
            // See https://www.youtube.com/watch?v=CPqOCI0ahss can help to get a quick and simple example.
            // One issue about NBC is when a event occurence is never observed.
            // E.g: if when TDE has an empty stomach, he always eat m&m's, than the "not eating m&m's when empty stomach' event
            // will never be observed.
            // This is called 'zero frequency' and that leads to division (or at least multiplication) by zero.
            // To avoid this, we add 0.1 in each frequency. With few data, the computation is than not really realistic.
            // The more we have records to analyse, the more the estimation will be precise.
            // :return: probability in percent (and integer rounded) that the lead will be won at the current stage.
            // """
            // lead_probabilities = {}
            // if not self:
            //     return lead_probabilities
            // 
            // # Get all leads values, no matter the team_id
            // domain = []
            // if batch_mode:
            //     domain = [
            //         '&',
            //             ('active', '=', True), ('id', 'in', self.ids),
            //             '|',
            //                 ('probability', '=', None),
            //                 '&',
            //                     ('probability', '<', 100), ('probability', '>', 0)
            //     ]
            // leads_values_dict = self._pls_get_lead_pls_values(domain=domain)
            // 
            // if not leads_values_dict:
            //     return lead_probabilities
            // 
            // # Get unique couples to search in frequency table and won leads.
            // leads_fields = set()  # keep unique fields, as a lead can have multiple tag_ids
            // won_leads = set()
            // won_stage_ids = self.env['crm.stage'].search([('is_won', '=', True)]).ids
            // for lead_id, values in leads_values_dict.items():
            //     for field, value in values['values']:
            //         if field == 'stage_id' and value in won_stage_ids:
            //             won_leads.add(lead_id)
            //         leads_fields.add(field)
            // leads_fields = sorted(leads_fields)
            // # get all variable related records from frequency table, no matter the team_id
            // frequencies = self.env['crm.lead.scoring.frequency'].search([('variable', 'in', list(leads_fields))], order="team_id asc, id")
            // 
            // # get all team_ids from frequencies
            // frequency_teams = frequencies.mapped('team_id')
            // frequency_team_ids = [team.id for team in frequency_teams]
            // 
            // # 1. Compute each variable value count individually
            // # regroup each variable to be able to compute their own probabilities
            // # As all the variable does not enter into account (as we reject unset values in the process)
            // # each value probability must be computed only with their own variable related total count
            // # special case: for lead for which team_id is not in frequency table or lead with no team_id,
            // # we consider all the records, independently from team_id (this is why we add a result[-1])
            // result = dict((team_id, dict((field, dict(won_total=0, lost_total=0)) for field in leads_fields)) for team_id in frequency_team_ids)
            // result[-1] = dict((field, dict(won_total=0, lost_total=0)) for field in leads_fields)
            // for frequency in frequencies:
            //     field = frequency['variable']
            //     value = frequency['value']
            // 
            //     # To avoid that a tag take too much importance if its subset is too small,
            //     # we ignore the tag frequencies if we have less than 50 won or lost for this tag.
            //     if field == 'tag_id' and (frequency['won_count'] + frequency['lost_count']) < 50:
            //         continue
            // 
            //     if frequency.team_id:
            //         team_result = result[frequency.team_id.id]
            //         team_result[field][value] = {'won': frequency['won_count'], 'lost': frequency['lost_count']}
            //         team_result[field]['won_total'] += frequency['won_count']
            //         team_result[field]['lost_total'] += frequency['lost_count']
            // 
            //     if value not in result[-1][field]:
            //         result[-1][field][value] = {'won': 0, 'lost': 0}
            //     result[-1][field][value]['won'] += frequency['won_count']
            //     result[-1][field][value]['lost'] += frequency['lost_count']
            //     result[-1][field]['won_total'] += frequency['won_count']
            //     result[-1][field]['lost_total'] += frequency['lost_count']
            // 
            // # Get all won, lost and total count for all records in frequencies per team_id
            // for team_id in result:
            //     result[team_id]['team_won'], \
            //     result[team_id]['team_lost'], \
            //     result[team_id]['team_total'] = self._pls_get_won_lost_total_count(result[team_id])
            // 
            // save_team_id = None
            // p_won, p_lost = 1, 1
            // for lead_id, lead_values in leads_values_dict.items():
            //     # if stage_id is null, return 0 and bypass computation
            //     lead_fields = [value[0] for value in lead_values.get('values', [])]
            //     if not 'stage_id' in lead_fields:
            //         lead_probabilities[lead_id] = 0
            //         continue
            //     # if lead stage is won, return 100
            //     elif lead_id in won_leads:
            //         lead_probabilities[lead_id] = 100
            //         continue
            // 
            //     # team_id not in frequency Table -> convert to -1
            //     lead_team_id = lead_values['team_id'] if lead_values['team_id'] in result else -1
            //     if lead_team_id != save_team_id:
            //         save_team_id = lead_team_id
            //         team_won = result[save_team_id]['team_won']
            //         team_lost = result[save_team_id]['team_lost']
            //         team_total = result[save_team_id]['team_total']
            //         # if one count = 0, we cannot compute lead probability
            //         if not team_won or not team_lost:
            //             continue
            //         p_won = team_won / team_total
            //         p_lost = team_lost / team_total
            // 
            //     # 2. Compute won and lost score using each variable's individual probability
            //     s_lead_won, s_lead_lost = p_won, p_lost
            //     for field, value in lead_values['values']:
            //         field_result = result.get(save_team_id, {}).get(field)
            //         value = value.origin if hasattr(value, 'origin') else value
            //         value_result = field_result.get(str(value)) if field_result else False
            //         if value_result:
            //             total_won = team_won if field == 'stage_id' else field_result['won_total']
            //             total_lost = team_lost if field == 'stage_id' else field_result['lost_total']
            // 
            //             # if one count = 0, we cannot compute lead probability
            //             if not total_won or not total_lost:
            //                 continue
            //             s_lead_won *= value_result['won'] / total_won
            //             s_lead_lost *= value_result['lost'] / total_lost
            // 
            //     # 3. Compute Probability to win
            //     probability = s_lead_won / (s_lead_won + s_lead_lost)
            //     lead_probabilities[lead_id] = min(max(round(100 * probability, 2), 0.01), 99.99)
            // return lead_probabilities
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_safe_fields(self):
            // """ As config_parameters does not accept M2M field,
            //     we the fields from the formated string stored into the Char config field.
            //     To avoid sql injections when using that list, we return only the fields
            //     that are defined on the model. """
            // pls_fields_config = self.env['ir.config_parameter'].sudo().get_param('crm.pls_fields')
            // pls_fields = pls_fields_config.split(',') if pls_fields_config else []
            // pls_safe_fields = [field for field in pls_fields if field in self._fields.keys()]
            // return pls_safe_fields
            */
            return default;
        }

        public async Task<TEntity> PlsGetSafeStartDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_safe_start_date(self):
            // """ As config_parameters does not accept Date field,
            //     we get directly the date formated string stored into the Char config field,
            //     as we directly use this string in the sql queries.
            //     To avoid sql injections when using this config param,
            //     we ensure the date string can be effectively a date."""
            // str_date = self.env['ir.config_parameter'].sudo().get_param('crm.pls_start_date')
            // if not fields.Date.to_date(str_date):
            //     return False
            // return str_date
            */
            return default;
        }

        public async Task<TEntity> PlsGetWonLostTotalCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object team_results) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_won_lost_total_count(self, team_results):
            // """ Get all won and all lost + total :
            //        first stage can be used to know how many lost and won there is
            //        as won count are equals for all stage
            //        and first stage is always incremented in lost_count
            // :param frequencies: lead_scoring_frequencies
            // :return: won count, lost count and total count for all records in frequencies
            // """
            // # TODO : check if we need to handle specific team_id stages [for lost count] (if first stage in sequence is team_specific)
            // first_stage_id = self.env['crm.stage'].search([('team_id', '=', False)], order='sequence, id', limit=1)
            // if str(first_stage_id.id) not in team_results.get('stage_id', []):
            //     return 0, 0, 0
            // stage_result = team_results['stage_id'][str(first_stage_id.id)]
            // return stage_result['won'], stage_result['lost'], stage_result['won'] + stage_result['lost']
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object from_state, object to_state) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_increment_frequencies(self, from_state=None, to_state=None):
            // """
            // When losing or winning a lead, this method is called to increment each PLS parameter related to the lead
            // in won_count (if won) or in lost_count (if lost).
            // 
            // This method is also used when reactivating a mistakenly lost lead (using the decrement argument).
            // In this case, the lost count should be de-increment by 1 for each PLS parameter linked to the lead.
            // 
            // Live increment must be done before writing the new values because we need to know the state change (from and to).
            // This would not be an issue for the reach won or reach lost as we just need to increment the frequencies with the
            // final state of the lead.
            // This issue is when the lead leaves a closed state because once the new values have been writen, we do not know
            // what was the previous state that we need to decrement.
            // This is why 'is_won' and 'decrement' parameters are used to describe the from / to change of its state.
            // """
            // new_frequencies_by_team, existing_frequencies_by_team = self._pls_prepare_update_frequency_table(target_state=from_state or to_state)
            // 
            // # update frequency table
            // self._pls_update_frequency_table(new_frequencies_by_team, 1 if to_state else -1,
            //                                  existing_frequencies_by_team=existing_frequencies_by_team)
            */
            return default;
        }

        public async Task<TEntity> PlsIncrementFrequencyDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object frequencies, object field, object @value, object won, object lost) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_increment_frequency_dict(self, frequencies, field, value, won, lost):
            // value = str(value)  # Ensure we will always compare strings.
            // if value not in frequencies[field]:
            //     frequencies[field][value] = {'won': won, 'lost': lost}
            // else:
            //     frequencies[field][value]['won'] += won
            //     frequencies[field][value]['lost'] += lost
            // return frequencies
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareFrequenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object lead_values, object leads_pls_fields, object target_state) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_prepare_frequencies(self, lead_values, leads_pls_fields, target_state=None):
            // """new state is used when getting frequencies for leads that are changing to lost or won.
            // Stays none if we are checking frequencies for leads already won or lost."""
            // pls_fields = leads_pls_fields.copy()
            // frequencies = dict((field, {}) for field in pls_fields)
            // 
            // stage_ids = self.env['crm.stage'].search_read([], ['sequence', 'name', 'id'], order='sequence, id')
            // stage_sequences = {stage['id']: stage['sequence'] for stage in stage_ids}
            // 
            // # Increment won / lost frequencies by criteria (field / value couple)
            // for values in lead_values:
            //     if target_state:  # ignore probability values if target state (as probability is the old value)
            //         won_count = values['count'] if target_state == 'won' else 0
            //         lost_count = values['count'] if target_state == 'lost' else 0
            //     else:
            //         won_count = values['count'] if values.get('probability', 0) == 100 else 0
            //         lost_count = values['count'] if values.get('probability', 1) == 0  else 0
            // 
            //     if 'tag_id' in values:
            //         frequencies = self._pls_increment_frequency_dict(frequencies, 'tag_id', values['tag_id'], won_count, lost_count)
            //         continue
            // 
            //     # Else, treat other fields
            //     if 'tag_id' in pls_fields:  # tag_id already treated here above.
            //         pls_fields.remove('tag_id')
            //     for field in pls_fields:
            //         if field not in values:
            //             continue
            //         value = values[field]
            //         if value or field in ('email_state', 'phone_state'):
            //             if field == 'stage_id':
            //                 if won_count:  # increment all stages if won
            //                     stages_to_increment = [stage['id'] for stage in stage_ids]
            //                 else:  # increment only current + previous stages if lost
            //                     current_stage_sequence = stage_sequences[value]
            //                     stages_to_increment = [stage['id'] for stage in stage_ids if stage['sequence'] <= current_stage_sequence]
            //                 for stage_id in stages_to_increment:
            //                     frequencies = self._pls_increment_frequency_dict(frequencies, field, stage_id, won_count, lost_count)
            //             else:
            //                 frequencies = self._pls_increment_frequency_dict(frequencies, field, value, won_count, lost_count)
            // 
            // return frequencies
            */
            return default;
        }

        public async Task<TEntity> PlsPrepareUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object rebuild, object target_state) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_prepare_update_frequency_table(self, rebuild=False, target_state=False):
            // """
            // This method is common to Live Increment or Full Rebuild mode, as it shares the main steps.
            // This method will prepare the frequency dict needed to update the frequency table:
            //     - New frequencies: frequencies that we need to add in the frequency table.
            //     - Existing frequencies: frequencies that are already in the frequency table.
            // In rebuild mode, only the new frequencies are needed as existing frequencies are truncated.
            // For each team, each dict contains the frequency in won and lost for each field/value couple
            // of the target leads.
            // Target leads are :
            //     - in Live increment mode : given ongoing leads (self)
            //     - in Full rebuild mode : all the closed (won and lost) leads in the DB.
            // During the frequencies update, with both new and existing frequencies, we can split frequencies to update
            // and frequencies to add. If a field/value couple already exists in the frequency table, we just update it.
            // Otherwise, we need to insert a new one.
            // """
            // # Keep eligible leads
            // pls_start_date = self._pls_get_safe_start_date()
            // if not pls_start_date:
            //     return {}, {}
            // 
            // if rebuild:  # rebuild will treat every closed lead in DB, increment will treat current ongoing leads
            //     pls_leads = self
            // else:
            //     # Only treat leads created after the PLS start Date
            //     pls_leads = self.filtered(
            //         lambda lead: fields.Date.to_date(pls_start_date) <= fields.Date.to_date(lead.create_date))
            //     if not pls_leads:
            //         return {}, {}
            // 
            // # Extract target leads values
            // if rebuild:  # rebuild is ok
            //     domain = [
            //         '&',
            //             ('create_date', '>=', pls_start_date),
            //             '|',
            //                 ('probability', '=', 100),
            //                 '&',
            //                     ('probability', '=', 0), ('active', '=', False)
            //       ]
            //     team_ids = self.env['crm.team'].with_context(active_test=False).search([]).ids + [0]  # If team_id is unset, consider it as team 0
            // else:  # increment
            //     domain = [('id', 'in', pls_leads.ids)]
            //     team_ids = pls_leads.mapped('team_id').ids + [0]
            // 
            // leads_values_dict = pls_leads._pls_get_lead_pls_values(domain=domain)
            // 
            // # split leads values by team_id
            // # get current frequencies related to the target leads
            // leads_frequency_values_by_team = dict((team_id, []) for team_id in team_ids)
            // leads_pls_fields = set()  # ensure to keep each field unique (can have multiple tag_id leads_values_dict)
            // for lead_id, values in leads_values_dict.items():
            //     team_id = values.get('team_id', 0)  # If team_id is unset, consider it as team 0
            //     lead_frequency_values = {'count': 1}
            //     for field, value in values['values']:
            //         if field != "probability":  # was added to lead values in batch mode to know won/lost state, but is not a pls fields.
            //             leads_pls_fields.add(field)
            //         else:  # extract lead probability - needed to increment tag_id frequency. (proba always before tag_id)
            //             lead_probability = value
            //         if field == 'tag_id':  # handle tag_id separatelly (as in One Shot rebuild mode)
            //             leads_frequency_values_by_team[team_id].append({field: value, 'count': 1, 'probability': lead_probability})
            //         else:
            //             lead_frequency_values[field] = value
            //     leads_frequency_values_by_team[team_id].append(lead_frequency_values)
            // leads_pls_fields = sorted(leads_pls_fields)
            // 
            // # get new frequencies
            // new_frequencies_by_team = {}
            // for team_id in team_ids:
            //     # prepare fields and tag values for leads by team
            //     new_frequencies_by_team[team_id] = self._pls_prepare_frequencies(
            //         leads_frequency_values_by_team[team_id], leads_pls_fields, target_state=target_state)
            // 
            // # get existing frequencies
            // existing_frequencies_by_team = {}
            // if not rebuild:  # there is no existing frequency in rebuild mode as they were all deleted.
            //     # read all fields to get everything in memory in one query (instead of having query + prefetch)
            //     existing_frequencies = self.env['crm.lead.scoring.frequency'].search_read(
            //         ['&', ('variable', 'in', leads_pls_fields),
            //               '|', ('team_id', 'in', pls_leads.mapped('team_id').ids), ('team_id', '=', False)])
            //     for frequency in existing_frequencies:
            //         team_id = frequency['team_id'][0] if frequency.get('team_id') else 0
            //         if team_id not in existing_frequencies_by_team:
            //             existing_frequencies_by_team[team_id] = dict((field, {}) for field in leads_pls_fields)
            // 
            //         existing_frequencies_by_team[team_id][frequency['variable']][frequency['value']] = {
            //             'frequency_id': frequency['id'],
            //             'won': frequency['won_count'],
            //             'lost': frequency['lost_count']
            //         }
            // 
            // return new_frequencies_by_team, existing_frequencies_by_team
            */
            return default;
        }

        public async Task<TEntity> PlsUpdateFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_frequencies_by_team, object step, object existing_frequencies_by_team) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_update_frequency_table(self, new_frequencies_by_team, step, existing_frequencies_by_team=None):
            // """ Create / update the frequency table in a cross company way, per team_id"""
            // values_to_update = {}
            // values_to_create = []
            // if not existing_frequencies_by_team:
            //     existing_frequencies_by_team = {}
            // # build the create multi + frequencies to update
            // for team_id, new_frequencies in new_frequencies_by_team.items():
            //     for field, value in new_frequencies.items():
            //         # frequency already present ?
            //         current_frequencies = existing_frequencies_by_team.get(team_id, {})
            //         for param, result in value.items():
            //             current_frequency_for_couple = current_frequencies.get(field, {}).get(param, {})
            //             # If frequency already present : UPDATE IT
            //             if current_frequency_for_couple:
            //                 new_won = current_frequency_for_couple['won'] + (result['won'] * step)
            //                 new_lost = current_frequency_for_couple['lost'] + (result['lost'] * step)
            //                 # ensure to have always positive frequencies
            //                 values_to_update[current_frequency_for_couple['frequency_id']] = {
            //                     'won_count': new_won if new_won > 0 else 0.1,
            //                     'lost_count': new_lost if new_lost > 0 else 0.1
            //                 }
            //                 continue
            // 
            //             # Else, CREATE a new frequency record.
            //             # We add + 0.1 in won and lost counts to avoid zero frequency issues
            //             # should be +1 but it weights too much on small recordset.
            //             values_to_create.append({
            //                 'variable': field,
            //                 'value': param,
            //                 'won_count': result['won'] + 0.1,
            //                 'lost_count': result['lost'] + 0.1,
            //                 'team_id': team_id if team_id else None  # team_id = 0 means no team_id
            //             })
            // 
            // LeadScoringFrequency = self.env['crm.lead.scoring.frequency'].sudo()
            // for frequency_id, values in values_to_update.items():
            //     LeadScoringFrequency.browse(frequency_id).write(values)
            // 
            // if values_to_create:
            //     LeadScoringFrequency.create(values_to_create)
            */
            return default;
        }

        public async Task<TEntity> PrepareAddressValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_address_values_from_partner(self, partner):
            // # Sync all address fields from partner, or none, to avoid mixing them.
            // if any(partner[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC):
            //     values = {f: partner[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            // else:
            //     values = {f: self[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            // return values
            */
            return default;
        }

        public async Task<TEntity> PrepareContactNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_contact_name_from_partner(self, partner):
            // contact_name = False if partner.is_company else partner.name
            // return {'contact_name': contact_name or self.contact_name}
            */
            return default;
        }

        public async Task<TEntity> PrepareCustomerValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner_name, object is_company, Guid parent_id) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_customer_values(self, partner_name, is_company=False, parent_id=False):
            // """ Extract data from lead to create a partner.
            // 
            // :param name : furtur name of the partner
            // :param is_company : True if the partner is a company
            // :param parent_id : id of the parent partner (False if no parent)
            // 
            // :return: dictionary of values to give at res_partner.create()
            // """
            // email_parts = tools.email_split(self.email_from)
            // res = {
            //     'name': partner_name,
            //     'user_id': self.env.context.get('default_user_id') or self.user_id.id,
            //     'comment': self.description,
            //     'parent_id': parent_id,
            //     'phone': self.phone,
            //     'mobile': self.mobile,
            //     'email': email_parts[0] if email_parts else False,
            //     'title': self.title.id,
            //     'function': self.function,
            //     'street': self.street,
            //     'street2': self.street2,
            //     'zip': self.zip,
            //     'city': self.city,
            //     'country_id': self.country_id.id,
            //     'state_id': self.state_id.id,
            //     'website': self.website,
            //     'is_company': is_company,
            //     'type': 'contact'
            // }
            // if self.lang_id.active:
            //     res['lang'] = self.lang_id.code
            // return res
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> PreparePartnerNameFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_partner_name_from_partner(self, partner):
            // """ Company name: name of partner parent (if set) or name of partner
            // (if company) or company_name of partner (if not a company). """
            // partner_name = partner.parent_id.name
            // if not partner_name and partner.is_company:
            //     partner_name = partner.name
            // elif not partner_name and partner.company_name:
            //     partner_name = partner.company_name
            // return {'partner_name': partner_name or self.partner_name}
            */
            return default;
        }

        public async Task<TEntity> PrepareValuesFromPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partner) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_values_from_partner(self, partner):
            // """ Get a dictionary with values coming from partner information to
            // copy on a lead. Non-address fields get the current lead
            // values to avoid being reset if partner has no value for them. """
            // 
            // # Sync all address fields from partner, or none, to avoid mixing them.
            // values = self._prepare_address_values_from_partner(partner)
            // 
            // # For other fields, get the info from the partner, but only if set
            // values.update({f: partner[f] or self[f] for f in PARTNER_FIELDS_TO_SYNC if f != 'lang'})
            // if partner.lang:
            //     values['lang_id'] = self.env['res.lang']._get_data(code=partner.lang).id
            // 
            // # Fields with specific logic
            // values.update(self._prepare_contact_name_from_partner(partner))
            // values.update(self._prepare_partner_name_from_partner(partner))
            // 
            // return self._convert_to_write(values)
            */
            return default;
        }

        public async Task<TEntity> ReadGroupStageIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object stages, object domain) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // # retrieve team_id from the context and write the domain
            // # - ('id', 'in', stages.ids): add columns that should be present
            // # - OR ('fold', '=', False): add default columns that are not folded
            // # - OR ('team_ids', '=', team_id), ('fold', '=', False) if team_id: add team columns that are not folded
            // team_id = self._context.get('default_team_id')
            // if team_id:
            //     search_domain = ['|', ('id', 'in', stages.ids), '|', ('team_id', '=', False), ('team_id', '=', team_id)]
            // else:
            //     search_domain = ['|', ('id', 'in', stages.ids), ('team_id', '=', False)]
            // 
            // # perform search
            // stage_ids = stages.sudo()._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            */
            return default;
        }

        public async Task<TEntity> RebuildPlsFrequencyTableInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _rebuild_pls_frequency_table(self):
            // # Clear the frequencies table (in sql to speed up the cron)
            // try:
            //     self.browse().check_access('unlink')
            // except AccessError:
            //     raise UserError(_("You don't have the access needed to run this cron."))
            // else:
            //     self._cr.execute('TRUNCATE TABLE crm_lead_scoring_frequency')
            // 
            // new_frequencies_by_team, unused = self._pls_prepare_update_frequency_table(rebuild=True)
            // # update frequency table
            // self._pls_update_frequency_table(new_frequencies_by_team, 1)
            // 
            // _logger.info("Predictive Lead Scoring : crm.lead.scoring.frequency table rebuilt")
            */
            return default;
        }

        public async Task<TEntity> RedirectLeadOpportunityViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def redirect_lead_opportunity_view(self):
            // self.ensure_one()
            // return {
            //     'name': _('Lead or Opportunity'),
            //     'view_mode': 'form',
            //     'res_model': 'crm.lead',
            //     'domain': [('type', '=', self.type)],
            //     'res_id': self.id,
            //     'view_id': False,
            //     'type': 'ir.actions.act_window',
            //     'context': {'default_type': self.type}
            // }
            */
            return default;
        }

        public async Task<TEntity> RescheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_reschedule_meeting(self):
            // self.ensure_one()
            // action = self.action_schedule_meeting(smart_calendar=False)
            // next_activity = self.activity_ids.filtered(lambda activity: activity.user_id == self.env.user)[:1]
            // if next_activity.calendar_event_id:
            //     action['context']['initial_date'] = next_activity.calendar_event_id.start
            // return action
            */
            return default;
        }

        public async Task<TEntity> ScheduleMeetingAsync<TEntity>(IEnumerable<TEntity> entities, object smart_calendar) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_schedule_meeting(self, smart_calendar=True):
            // """ Open meeting's calendar view to schedule meeting on current opportunity.
            // 
            //     :param smart_calendar: boolean, to set to False if the view should not try to choose relevant
            //       mode and initial date for calendar view, see ``_get_opportunity_meeting_view_parameters``
            //     :return dict: dictionary value for created Meeting view
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("calendar.action_calendar_event")
            // partner_ids = self.env.user.partner_id.ids
            // if self.partner_id:
            //     partner_ids.append(self.partner_id.id)
            // current_opportunity_id = self.id if self.type == 'opportunity' else False
            // action['context'] = {
            //     'search_default_opportunity_id': current_opportunity_id,
            //     'default_opportunity_id': current_opportunity_id,
            //     'default_partner_id': self.partner_id.id,
            //     'default_partner_ids': partner_ids,
            //     'default_team_id': self.team_id.id,
            //     'default_name': self.name,
            // }
            // 
            // # 'Smart' calendar view : get the most relevant time period to display to the user.
            // if current_opportunity_id and smart_calendar:
            //     mode, initial_date = self._get_opportunity_meeting_view_parameters()
            //     action['context'].update({'default_mode': mode, 'initial_date': initial_date})
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _search_display_name(self, operator, value):
            // context = dict(self.env.context)
            // newself = self
            // constraint = []
            // if context.pop('user_preference', None):
            //     # We browse as superuser. Otherwise, the user would be able to
            //     # select only the currently visible companies (according to rules,
            //     # which are probably to allow to see the child companies) even if
            //     # she belongs to some other companies.
            //     companies = self.env.user.company_ids
            //     constraint = [('id', 'in', companies.ids)]
            //     newself = newself.sudo()
            // newself = newself.with_context(context)
            // domain = super(Company, newself)._search_display_name(operator, value)
            // return expression.AND([domain, constraint])
            */
            return default;
        }

        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def search_fetch(self, domain, field_names, offset=0, limit=None, order=None):
            // """ Override to support ordering on my_activity_date_deadline.
            // 
            // Ordering through web client calls search_read() with an order parameter
            // set. Method search_read() then calls search_fetch(). Here we override
            // search_fetch() to intercept a search with an order on field
            // my_activity_date_deadline. In that case we do the search in two steps.
            // 
            // First step: fill with deadline-based results
            // 
            //   * Perform a read_group on my activities to get a mapping lead_id / deadline
            //     Remember date_deadline is required, we always have a value for it. Only
            //     the earliest deadline per lead is kept.
            //   * Search leads linked to those activities that also match the asked domain
            //     and order from the original search request.
            //   * Results of that search will be at the top of returned results. Use limit
            //     None because we have to search all leads linked to activities as ordering
            //     on deadline is done in post processing.
            //   * Reorder them according to deadline asc or desc depending on original
            //     search ordering. Finally take only a subset of those leads to fill with
            //     results matching asked offset / limit.
            // 
            // Second step: fill with other results. If first step does not gives results
            // enough to match offset and limit parameters we fill with a search on other
            // leads. We keep the asked domain and ordering while filtering out already
            // scanned leads to keep a coherent results.
            // 
            // All other search and search_read are left untouched by this override to avoid
            // side effects. Search_count is not affected by this override.
            // """
            // if not order or 'my_activity_date_deadline' not in order:
            //     return super().search_fetch(domain, field_names, offset, limit, order)
            // order_items = [order_item.strip().lower() for order_item in (order or self._order).split(',')]
            // 
            // # Perform a read_group on my activities to get a mapping lead_id / deadline
            // # Remember date_deadline is required, we always have a value for it. Only
            // # the earliest deadline per lead is kept.
            // activity_asc = any('my_activity_date_deadline asc' in item for item in order_items)
            // my_lead_activities = self.env['mail.activity']._read_group(
            //     [('res_model', '=', self._name), ('user_id', '=', self.env.uid)],
            //     ['res_id'],
            //     ['date_deadline:min'],
            //     order='date_deadline:min ASC, res_id',
            // )
            // my_lead_mapping = dict(my_lead_activities)
            // my_lead_ids = list(my_lead_mapping.keys())
            // my_lead_domain = expression.AND([[('id', 'in', my_lead_ids)], domain])
            // my_lead_order = ', '.join(item for item in order_items if 'my_activity_date_deadline' not in item)
            // 
            // # Search leads linked to those activities and order them. See docstring
            // # of this method for more details.
            // search_res = super().search_fetch(my_lead_domain, field_names, order=my_lead_order)
            // my_lead_ids_ordered = sorted(search_res.ids, key=lambda lead_id: my_lead_mapping[lead_id], reverse=not activity_asc)
            // # keep only requested window (offset + limit, or offset+)
            // my_lead_ids_keep = my_lead_ids_ordered[offset:(offset + limit)] if limit else my_lead_ids_ordered[offset:]
            // # keep list of already skipped lead ids to exclude them from future search
            // my_lead_ids_skip = my_lead_ids_ordered[:(offset + limit)] if limit else my_lead_ids_ordered
            // 
            // # do not go further if limit is achieved
            // if limit and len(my_lead_ids_keep) >= limit:
            //     return self.browse(my_lead_ids_keep)
            // 
            // # Fill with remaining leads. If a limit is given, simply remove count of
            // # already fetched. Otherwise keep none. If an offset is set we have to
            // # reduce it by already fetch results hereabove. Order is updated to exclude
            // # my_activity_date_deadline when calling super() .
            // lead_limit = (limit - len(my_lead_ids_keep)) if limit else None
            // if offset:
            //     lead_offset = max((offset - len(search_res), 0))
            // else:
            //     lead_offset = 0
            // lead_order = ', '.join(item for item in order_items if 'my_activity_date_deadline' not in item)
            // 
            // other_lead_res = super().search_fetch(
            //     expression.AND([[('id', 'not in', my_lead_ids_skip)], domain]),
            //     field_names, lead_offset, lead_limit, lead_order,
            // )
            // return self.browse(my_lead_ids_keep) + other_lead_res
            */
            return default;
        }

        public async Task<TEntity> SetAutomatedProbabilityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_automated_probability(self):
            // self.write({'probability': self.automated_probability})
            */
            return default;
        }

        public async Task<TEntity> SetLostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_lost(self, **additional_values):
            // """ Lost semantic: probability = 0 or active = False """
            // res = self.action_archive()
            // if additional_values:
            //     self.write(dict(additional_values))
            // return res
            */
            return default;
        }

        public async Task<TEntity> SetWonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_won(self):
            // """ Won semantic: probability = 100 (active untouched) """
            // self.action_unarchive()
            // # group the leads by team_id, in order to write once by values couple (each write leads to frequency increment)
            // leads_by_won_stage = {}
            // for lead in self:
            //     won_stages = self._stage_find(domain=[('is_won', '=', True)], limit=None)
            //     # ABD : We could have a mixed pipeline, with "won" stages being separated by "standard"
            //     # stages. In the future, we may want to prevent any "standard" stage to have a higher
            //     # sequence than any "won" stage. But while this is not the case, searching
            //     # for the "won" stage while alterning the sequence order (see below) will correctly
            //     # handle such a case :
            //     #       stage sequence : [x] [x (won)] [y] [y (won)] [z] [z (won)]
            //     #       when in stage [y] and marked as "won", should go to the stage [y (won)],
            //     #       not in [x (won)] nor [z (won)]
            //     stage_id = next((stage for stage in won_stages if stage.sequence > lead.stage_id.sequence), None)
            //     if not stage_id:
            //         stage_id = next((stage for stage in reversed(won_stages) if stage.sequence <= lead.stage_id.sequence), won_stages)
            //     if stage_id in leads_by_won_stage:
            //         leads_by_won_stage[stage_id] += lead
            //     else:
            //         leads_by_won_stage[stage_id] = lead
            // for won_stage_id, leads in leads_by_won_stage.items():
            //     leads.write({'stage_id': won_stage_id.id, 'probability': 100})
            // return True
            */
            return default;
        }

        public async Task<TEntity> SetWonRainbowmanAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_won_rainbowman(self):
            // self.ensure_one()
            // self.action_set_won()
            // 
            // message = self._get_rainbowman_message()
            // if message:
            //     return {
            //         'effect': {
            //             'fadeout': 'slow',
            //             'message': message,
            //             'img_url': '/web/image/%s/%s/image_1024' % (self.team_id.user_id._name, self.team_id.user_id.id) if self.team_id.user_id.image_1024 else '/web/static/img/smile.svg',
            //             'type': 'rainbow_man',
            //         }
            //     }
            // return True
            */
            return default;
        }

        public async Task<TEntity> ShowPotentialDuplicatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_show_potential_duplicates(self):
            // """ Open kanban view to display duplicate leads or opportunity.
            //     :return dict: dictionary value for created kanban view
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("crm.crm_lead_opportunities")
            // action['domain'] = [('id', 'in', self.duplicate_lead_ids.ids)]
            // action['context'] = {
            //     'active_test': False,
            //     'create': False
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> SnoozeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_snooze(self):
            // self.ensure_one()
            // my_next_activity = self.activity_ids.filtered(lambda activity: activity.user_id == self.env.user)[:1]
            // my_next_activity.action_snooze()
            // return True
            */
            return default;
        }

        public async Task<TEntity> SortByConfidenceLevelInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reverse) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _sort_by_confidence_level(self, reverse=False):
            // """ Sorting the leads/opps according to the confidence level to it
            // being won. It is sorted following this incremental heuristics :
            // 
            //   * "not lost" first (inactive leads are lost); normally all leads
            //     should be active but in case lost one, they are always last.
            //     Inactive opportunities are considered as valid;
            //   * opportunity is more reliable than a lead which is a pre-stage
            //     used mainly for first classification;
            //   * stage sequence: the higher the better as it indicates we are moving
            //     towards won stage;
            //   * probability: the higher the better as it is more likely to be won;
            //   * ID: the higher the better when all other parameters are equal. We
            //     consider newer leads to be more reliable;
            // """
            // def opps_key(opportunity):
            //     return opportunity.type == 'opportunity' or opportunity.active,  \
            //         opportunity.type == 'opportunity', \
            //         opportunity.stage_id.sequence, \
            //         opportunity.probability, \
            //         -opportunity._origin.id
            // 
            // return self.sorted(key=opps_key, reverse=reverse)
            */
            return default;
        }

        public async Task<TEntity> StageFindInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid team_id, object domain, object order, object limit) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _stage_find(self, team_id=False, domain=None, order='sequence, id', limit=1):
            // """ Determine the stage of the current lead with its teams, the given domain and the given team_id
            //     :param team_id
            //     :param domain : base search domain for stage
            //     :param order : base search order for stage
            //     :param limit : base search limit for stage
            //     :returns crm.stage recordset
            // """
            // # collect all team_ids by adding given one, and the ones related to the current leads
            // team_ids = set()
            // if team_id:
            //     team_ids.add(team_id)
            // for lead in self:
            //     if lead.team_id:
            //         team_ids.add(lead.team_id.id)
            // # generate the domain
            // if team_ids:
            //     search_domain = ['|', ('team_id', '=', False), ('team_id', 'in', list(team_ids))]
            // else:
            //     search_domain = [('team_id', '=', False)]
            // # AND with the domain in parameter
            // if domain:
            //     search_domain += list(domain)
            // # perform search, return the first found
            // return self.env['crm.stage'].search(search_domain, order=order, limit=limit)
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def toggle_active(self):
            // """ When archiving: mark probability as 0. When re-activating
            // update probability again, for leads and opportunities. """
            // res = super(Lead, self).toggle_active()
            // activated = self.filtered(lambda lead: lead.active)
            // archived = self.filtered(lambda lead: not lead.active)
            // if activated:
            //     activated.write({'lost_reason_id': False})
            //     activated._compute_probabilities()
            // if archived:
            //     archived.write({'probability': 0, 'automated_probability': 0})
            // return res
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values and self.probability == 100 and self.stage_id:
            //     return self.env.ref('crm.mt_lead_won')
            // elif 'lost_reason_id' in init_values and self.lost_reason_id:
            //     return self.env.ref('crm.mt_lead_lost')
            // elif 'stage_id' in init_values:
            //     return self.env.ref('crm.mt_lead_stage')
            // elif 'active' in init_values and self.active:
            //     return self.env.ref('crm.mt_lead_restored')
            // elif 'active' in init_values and not self.active:
            //     return self.env.ref('crm.mt_lead_lost')
            // return super(Lead, self)._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def unlink(self):
            // """ Update meetings when removing opportunities, otherwise you have
            // a link to a record that does not lead anywhere. """
            // meetings = self.env['calendar.event'].search([
            //     ('res_id', 'in', self.ids),
            //     ('res_model', '=', self._name),
            // ])
            // if meetings:
            //     meetings.write({
            //         'res_id': False,
            //         'res_model_id': False,
            //     })
            // return super(Lead, self).unlink()
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

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> UpdateAddressAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def update_address(self, vals):
            // addr_vals = {key: vals[key] for key in self._address_fields() if key in vals}
            // if addr_vals:
            //     return super().write(addr_vals)
            */
            return default;
        }

        public async Task<TEntity> UpdateAutomatedProbabilitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _update_automated_probabilities(self):
            // """ Recompute all the automated_probability (and align probability if both were aligned) for all the leads
            // that are active (not won, nor lost).
            // 
            // For performance matter, as there can be a huge amount of leads to recompute, this cron proceed by batch.
            // Each batch is performed into its own transaction, in order to minimise the lock time on the lead table
            // (and to avoid complete lock if there was only 1 transaction that would last for too long -> several minutes).
            // If a concurrent update occurs, it will simply be put in the queue to get the lock.
            // """
            // pls_start_date = self._pls_get_safe_start_date()
            // if not pls_start_date:
            //     return
            // 
            // # 1. Get all the leads to recompute created after pls_start_date that are nor won nor lost
            // # (Won : probability = 100 | Lost : probability = 0 or inactive. Here, inactive won't be returned anyway)
            // # Get also all the lead without probability --> These are the new leads. Activate auto probability on them.
            // pending_lead_domain = [
            //     '&',
            //         '&',
            //             ('stage_id', '!=', False), ('create_date', '>=', pls_start_date),
            //         '|',
            //             ('probability', '=', False),
            //             '&',
            //                 ('probability', '<', 100), ('probability', '>', 0)
            // ]
            // leads_to_update = self.env['crm.lead'].search(pending_lead_domain)
            // leads_to_update_count = len(leads_to_update)
            // 
            // # 2. Compute by batch to avoid memory error
            // lead_probabilities = {}
            // for i in range(0, leads_to_update_count, PLS_COMPUTE_BATCH_STEP):
            //     leads_to_update_part = leads_to_update[i:i + PLS_COMPUTE_BATCH_STEP]
            //     lead_probabilities.update(leads_to_update_part._pls_get_naive_bayes_probabilities(batch_mode=True))
            // _logger.info("Predictive Lead Scoring : New automated probabilities computed")
            // 
            // # 3. Group by new probability to reduce server roundtrips when executing the update
            // probability_leads = defaultdict(list)
            // for lead_id, probability in sorted(lead_probabilities.items()):
            //     probability_leads[probability].append(lead_id)
            // 
            // # 4. Update automated_probability (+ probability if both were equal)
            // update_sql = """UPDATE crm_lead
            //                 SET automated_probability = %s,
            //                     probability = CASE WHEN (probability = automated_probability OR probability is null)
            //                                        THEN (%s)
            //                                        ELSE (probability)
            //                                   END
            //                 WHERE id in %s"""
            // 
            // # Update by a maximum number of leads at the same time, one batch by transaction :
            // # - avoid memory errors
            // # - avoid blocking the table for too long with a too big transaction
            // transactions_count, transactions_failed_count = 0, 0
            // cron_update_lead_start_date = datetime.now()
            // auto_commit = not getattr(threading.current_thread(), 'testing', False)
            // self.flush_model()
            // for probability, probability_lead_ids in probability_leads.items():
            //     for lead_ids_current in tools.split_every(PLS_UPDATE_BATCH_STEP, probability_lead_ids):
            //         transactions_count += 1
            //         try:
            //             self.env.cr.execute(update_sql, (probability, probability, tuple(lead_ids_current)))
            //             # auto-commit except in testing mode
            //             if auto_commit:
            //                 self.env.cr.commit()
            //         except Exception as e:
            //             _logger.warning("Predictive Lead Scoring : update transaction failed. Error: %s" % e)
            //             transactions_failed_count += 1
            // self.invalidate_model()
            // 
            // _logger.info(
            //     "Predictive Lead Scoring : All automated probabilities updated (%d leads / %d transactions (%d failed) / %d seconds)" % (
            //         leads_to_update_count,
            //         transactions_count,
            //         transactions_failed_count,
            //         (datetime.now() - cron_update_lead_start_date).total_seconds(),
            //     )
            // )
            */
            return default;
        }

        public async Task<TEntity> UpdateFieldsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _update_fields_values(self, fields):
            // """ Returns dict of write() values for synchronizing ``fields`` """
            // values = {}
            // for fname in fields:
            //     field = self._fields[fname]
            //     if field.type == 'many2one':
            //         values[fname] = self[fname].id
            //     elif field.type == 'one2many':
            //         raise AssertionError(_('One2Many fields cannot be synchronized as part of `commercial_fields` or `address fields`'))
            //     elif field.type == 'many2many':
            //         values[fname] = [Command.set(self[fname].ids)]
            //     else:
            //         values[fname] = self[fname]
            // return values
            */
            return default;
        }

        public async Task<TEntity> ViewGetAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object arch) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _view_get_address(self, arch):
            // # consider the country of the user, not the country of the partner we want to display
            // address_view_id = self.env.company.country_id.address_view_id.sudo()
            // address_format = self.env.company.country_id.address_format
            // if address_view_id and not self._context.get('no_address_format') and (not address_view_id.model or address_view_id.model == self._name):
            //     #render the partner address accordingly to address_view_id
            //     for address_node in arch.xpath("//div[hasclass('o_address_format')]"):
            //         Partner = self.env['res.partner'].with_context(no_address_format=True)
            //         sub_arch, _sub_view = Partner._get_view(address_view_id.id, 'form')
            //         #if the model is different than res.partner, there are chances that the view won't work
            //         #(e.g fields not present on the model). In that case we just return arch
            //         if self._name != 'res.partner':
            //             try:
            //                 self.env['ir.ui.view'].postprocess_and_fields(sub_arch, model=self._name)
            //             except ValueError:
            //                 return arch
            //         new_address_node = sub_arch.find('.//div[@class="o_address_format"]')
            //         if new_address_node is not None:
            //             sub_arch = new_address_node
            //         address_node.getparent().replace(address_node, sub_arch)
            // elif address_format and not self._context.get('no_address_format'):
            //     # For the zip, city and state fields we need to move them around in order to follow the country address format.
            //     # The purpose of this is to help the user by following a format he is used to.
            //     city_line = [self._extract_fields_from_address(line) for line in address_format.split('\n') if 'city' in line]
            //     if city_line:
            //         field_order = city_line[0]
            //         for address_node in arch.xpath("//div[hasclass('o_address_format')]"):
            //             first_field = field_order[0] if field_order[0] not in ('state_code', 'state_name') else 'state_id'
            //             concerned_fields = {'zip', 'city', 'state_id'} - {first_field}
            //             current_field = address_node.find(f".//field[@name='{first_field}']")
            //             # First loop into the fields displayed in the address_format, and order them.
            //             for field in field_order[1:]:
            //                 if field in ('state_code', 'state_name'):
            //                     field = 'state_id'
            //                 previous_field = current_field
            //                 current_field = address_node.find(f".//field[@name='{field}']")
            //                 if previous_field is not None and current_field is not None:
            //                     previous_field.addnext(current_field)
            //                 concerned_fields -= {field}
            //             # Add the remaining fields in 'concerned_fields' at the end, after the others
            //             for field in concerned_fields:
            //                 previous_field = current_field
            //                 current_field = address_node.find(f".//field[@name='{field}']")
            //                 if previous_field is not None and current_field is not None:
            //                     previous_field.addnext(current_field)
            // 
            // return arch
            */
            return default;
        }

        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def write(self, vals):
            // if vals.get('website'):
            //     vals['website'] = self.env['res.partner']._clean_website(vals['website'])
            // 
            // now = self.env.cr.now()
            // stage_updated, stage_is_won = False, False
            // # stage change (or reset): update date_last_stage_update if at least one
            // # lead does not have the same stage
            // if 'stage_id' in vals:
            //     stage_updated = any(lead.stage_id.id != vals['stage_id'] for lead in self)
            //     if stage_updated:
            //         vals['date_last_stage_update'] = now
            //     if stage_updated and vals.get('stage_id'):
            //         stage = self.env['crm.stage'].browse(vals['stage_id'])
            //         if stage.is_won:
            //             vals.update({'probability': 100, 'automated_probability': 100})
            //             stage_is_won = True
            // # user change; update date_open if at least one lead does not
            // # have the same user
            // if 'user_id' in vals and not vals.get('user_id'):
            //     vals['date_open'] = False
            // elif vals.get('user_id'):
            //     user_updated = any(lead.user_id.id != vals['user_id'] for lead in self)
            //     if user_updated:
            //         vals['date_open'] = now
            // 
            // # stage change with new stage: update probability and date_closed
            // if vals.get('probability', 0) >= 100 or not vals.get('active', True):
            //     vals['date_closed'] = fields.Datetime.now()
            // elif vals.get('probability', 0) > 0:
            //     vals['date_closed'] = False
            // elif stage_updated and not stage_is_won and not 'probability' in vals:
            //     vals['date_closed'] = False
            // 
            // if any(field in ['active', 'stage_id'] for field in vals):
            //     self._handle_won_lost(vals)
            // 
            // if not stage_is_won:
            //     return super(Lead, self).write(vals)
            // 
            // # stage change between two won stages: does not change the date_closed
            // leads_already_won = self.filtered(lambda lead: lead.stage_id.is_won)
            // remaining = self - leads_already_won
            // if remaining:
            //     result = super(Lead, remaining).write(vals)
            // if leads_already_won:
            //     vals.pop('date_closed', False)
            //     result = super(Lead, leads_already_won).write(vals)
            // return result
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def write(self, values):
            // invalidation_fields = self.cache_invalidation_fields()
            // asset_invalidation_fields = {'font', 'primary_color', 'secondary_color', 'external_report_layout_id'}
            // 
            // companies_needs_l10n = (
            //     values.get('country_id')
            //     and self.filtered(lambda company: not company.country_id)
            //     or self.browse()
            // )
            // if not invalidation_fields.isdisjoint(values):
            //     self.env.registry.clear_cache()
            // 
            // if not asset_invalidation_fields.isdisjoint(values):
            //     # this is used in the content of an asset (see asset_styles_company_report)
            //     # and thus needs to invalidate the assets cache when this is changed
            //     self.env.registry.clear_cache('assets')  # not 100% it is useful a test is missing if it is the case
            // 
            // if 'parent_id' in values:
            //     raise UserError(_("The company hierarchy cannot be changed."))
            // 
            // if values.get('currency_id'):
            //     currency = self.env['res.currency'].browse(values['currency_id'])
            //     if not currency.active:
            //         currency.write({'active': True})
            // 
            // res = super(Company, self).write(values)
            // 
            // # Archiving a company should also archive all of its branches
            // if values.get('active') is False:
            //     self.child_ids.active = False
            // 
            // for company in self:
            //     # Copy modified delegated fields from root to branches
            //     if (changed := set(values) & set(self._get_company_root_delegated_field_names())) and not company.parent_id:
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
            // company_address_fields_upd = set(company_address_fields) & set(values.keys())
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
            // # res.partner must only allow to set the company_id of a partner if it
            // # is the same as the company of all users that inherit from this partner
            // # (this is to allow the code from res_users to write to the partner!) or
            // # if setting the company_id to False (this is compatible with any user
            // # company)
            // if vals.get('website'):
            //     vals['website'] = self._clean_website(vals['website'])
            // if vals.get('parent_id'):
            //     vals['company_name'] = False
            // if 'company_id' in vals:
            //     company_id = vals['company_id']
            //     for partner in self:
            //         if company_id and partner.user_ids:
            //             company = self.env['res.company'].browse(company_id)
            //             companies = set(user.company_id for user in partner.user_ids)
            //             if len(companies) > 1 or company not in companies:
            //                 raise UserError(
            //                     ("The selected company is not compatible with the companies of the related user(s)"))
            //         if partner.child_ids:
            //             partner.child_ids.write({'company_id': company_id})
            // result = True
            // # To write in SUPERUSER on field is_company and avoid access rights problems.
            // if 'is_company' in vals and not self.env.su and self.env.user.has_group('base.group_partner_manager'):
            //     result = super(Partner, self.sudo()).write({'is_company': vals.get('is_company')})
            //     del vals['is_company']
            // result = result and super().write(vals)
            // for partner in self:
            //     if any(u._is_internal() for u in partner.user_ids if u != self.env.user):
            //         self.env['res.users'].check_access('write')
            //     partner._fields_sync(vals)
            // return result
            */
            return default;
        }

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _write_company_type(self):
            // for partner in self:
            //     partner.is_company = partner.company_type == 'company'
            */
            return default;
        }

        public async Task<TEntity> _AccessibleBranchesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IFormatAddressMixinable
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