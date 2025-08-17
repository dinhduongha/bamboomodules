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
    public class AvatarMixinAppService : ApplicationService, IAvatarMixinAppService
    {

        public AvatarMixinAppService() 
        {

        }

        public async Task<TEntity> AcceptDriverChangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def action_accept_driver_change(self):
            // # Find all the vehicles of the same type for which the driver is the future_driver_id
            // # remove their driver_id and close their history using current date
            // vehicles = self.search([('driver_id', 'in', self.mapped('future_driver_id').ids), ('vehicle_type', '=', self.vehicle_type)])
            // vehicles.write({'driver_id': False})
            // 
            // for vehicle in self:
            //     if vehicle.vehicle_type == 'bike':
            //         vehicle.future_driver_id.sudo().write({'plan_to_change_bike': False})
            //     if vehicle.vehicle_type == 'car':
            //         vehicle.future_driver_id.sudo().write({'plan_to_change_car': False})
            //     vehicle.driver_id = vehicle.future_driver_id
            //     vehicle.future_driver_id = False
            */
            return default;
        }

        public async Task<TEntity> ActShowLogCostAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def act_show_log_cost(self):
            // """ This opens log view to view and add new log for this vehicle, groupby default to only show effective costs
            //     @return: the costs log view
            // """
            // self.ensure_one()
            // copy_context = dict(self.env.context)
            // copy_context.pop('group_by', None)
            // res = self.env['ir.actions.act_window']._for_xml_id('fleet.fleet_vehicle_costs_action')
            // res.update(
            //     context=dict(copy_context, default_vehicle_id=self.id, search_default_parent_false=True),
            //     domain=[('vehicle_id', '=', self.id)]
            // )
            // return res
            */
            return default;
        }

        public async Task<TEntity> AddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _address_fields(self):
            // """Returns the list of address fields that are synced from the parent."""
            // return list(ADDRESS_FIELDS)
            */
            return default;
        }

        public async Task<TEntity> AddressGetAsync<TEntity>(IEnumerable<TEntity> entities, object adr_pref) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> AvatarGenerateSvgInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _avatar_generate_svg(self):
            // initial = html_escape(self[self._avatar_name_field][0].upper())
            // bgcolor = get_hsl_from_seed(self[self._avatar_name_field] + str(self.create_date.timestamp() if self.create_date else ""))
            // return b64encode((
            //     "<?xml version='1.0' encoding='UTF-8' ?>"
            //     "<svg height='180' width='180' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'>"
            //     f"<rect fill='{bgcolor}' height='180' width='180'/>"
            //     f"<text fill='#ffffff' font-size='96' text-anchor='middle' x='90' y='125' font-family='sans-serif'>{initial}</text>"
            //     "</svg>"
            // ).encode())
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _avatar_get_placeholder(self):
            // return file_open(self._avatar_get_placeholder_path(), 'rb').read()
            */
            return default;
        }

        public async Task<TEntity> AvatarGetPlaceholderPathInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _avatar_get_placeholder_path(self):
            // return "base/static/img/avatar_grey.png"
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

        public async Task<TEntity> CheckBarcodeUnicityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CheckFieldAccessRightsAsync<TEntity>(IEnumerable<TEntity> entities, object operation, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def check_field_access_rights(self, operation, field_names):
            // # DISCLAIMER: Dirty hack to avoid having to create a bridge module to override only a
            // # groups on a field which is not prefetched (because not stored) but would crash anyway
            // # if we try to read them directly (very uncommon use case). Don't add your field on this
            // # list if you can specify the group on the field directly (as all the other fields).
            // result = super().check_field_access_rights(operation, field_names)
            // if not self.env.user.has_group("hr.group_hr_user"):
            //     result = [field for field in result if field not in ['activity_calendar_event_id', 'rating_ids', 'website_message_ids', 'message_has_sms_error']]
            // return result
            */
            return default;
        }

        public async Task<TEntity> CheckImportConsistencyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CheckParentIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _check_parent_id(self):
            // if self._has_cycle():
            //     raise ValidationError(_('You cannot create recursive Partner hierarchies.'))
            */
            return default;
        }

        public async Task<TEntity> CheckPartnerCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CheckPrivateFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_private_fields(self, field_names):
            // """ Check whether ``field_names`` contain private fields. """
            // public_fields = self.env['hr.employee.public']._fields
            // private_fields = [fname for fname in field_names if fname not in public_fields]
            // if private_fields:
            //     raise AccessError(_('The fields “%s”, which you are trying to read, are not available for employee public profiles.', ','.join(private_fields)))
            */
            return default;
        }

        public async Task<TEntity> CheckSsnidInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _check_ssnid(self):
            // # By default, an Social Security Number is always valid, but each localization
            // # may want to add its own constraints
            // pass
            */
            return default;
        }

        public async Task<TEntity> ChildrenSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CleanValsInternalUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _clean_vals_internal_user(self, vals):
            // # Fleet administrator may not have rights to write on partner
            // # related fields when the driver_id is a res.user.
            // # This trick is used to prevent access right error.
            // su_vals = {}
            // if self.env.su:
            //     return su_vals
            // if 'plan_to_change_car' in vals:
            //     su_vals['plan_to_change_car'] = vals.pop('plan_to_change_car')
            // if 'plan_to_change_bike' in vals:
            //     su_vals['plan_to_change_bike'] = vals.pop('plan_to_change_bike')
            // return su_vals
            */
            return default;
        }

        public async Task<TEntity> CleanWebsiteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CommercialSyncFromCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CommercialSyncToChildrenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields_to_sync) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CompanyDependentCommercialFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CompanyDependentCommercialSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ComputeActiveLangCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ComputeAvatar1024InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_1024(self):
            // self._compute_avatar('avatar_1024', 'image_1024')
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1024(self):
            // super()._compute_avatar_1024()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar128InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_128(self):
            // self._compute_avatar('avatar_128', 'image_128')
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_128(self):
            // super()._compute_avatar_128()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar1920InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_1920(self):
            // self._compute_avatar('avatar_1920', 'image_1920')
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_1920(self):
            // super()._compute_avatar_1920()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar256InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_256(self):
            // self._compute_avatar('avatar_256', 'image_256')
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_256(self):
            // super()._compute_avatar_256()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatar512InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar_512(self):
            // self._compute_avatar('avatar_512', 'image_512')
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_avatar_512(self):
            // super()._compute_avatar_512()
            */
            return default;
        }

        public async Task<TEntity> ComputeAvatarInternalAsync<TEntity>(IEnumerable<TEntity> entities, object avatar_field, object image_field) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // employee_wo_user_and_image = self.env['hr.employee']
            // for employee in self:
            //     if not employee.user_id and not employee._origin[image_field]:
            //         employee_wo_user_and_image += employee
            //         continue
            //     avatar = employee._origin[image_field]
            //     if not avatar and employee.user_id:
            //         avatar = employee.user_id.sudo()[avatar_field]
            //     employee[avatar_field] = avatar
            // super(HrEmployeePrivate, employee_wo_user_and_image)._compute_avatar(avatar_field, image_field)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: avatar_mixin.py) ---
            // def _compute_avatar(self, avatar_field, image_field):
            // for record in self:
            //     avatar = record[image_field]
            //     if not avatar:
            //         if record.id and record[record._avatar_name_field]:
            //             avatar = record._avatar_generate_svg()
            //         else:
            //             avatar = b64encode(record._avatar_get_placeholder())
            //     record[avatar_field] = avatar
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

        public async Task<TEntity> ComputeCommercialCompanyNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ComputeCommercialPartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ComputeCompanyRegistryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ComputeCompanyRegistryLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ComputeCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_company_type(self):
            // for partner in self:
            //     partner.company_type = 'company' if partner.is_company else 'person'
            */
            return default;
        }

        public async Task<TEntity> ComputeCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_complete_name(self):
            // for partner in self:
            //     partner.complete_name = partner.with_context({})._get_complete_name()
            */
            return default;
        }

        public async Task<TEntity> ComputeContactAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_contact_address(self):
            // for partner in self:
            //     partner.contact_address = partner._display_address()
            */
            return default;
        }

        public async Task<TEntity> ComputeContractReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_contract_reminder(self):
            // params = self.env['ir.config_parameter'].sudo()
            // delay_alert_contract = int(params.get_param('hr_fleet.delay_alert_contract', default=30))
            // current_date = fields.Date.context_today(self)
            // data = self.env['fleet.vehicle.log.contract']._read_group(
            //     domain=[('expiration_date', '!=', False), ('vehicle_id', 'in', self.ids), ('state', '!=', 'closed')],
            //     groupby=['vehicle_id', 'state'],
            //     aggregates=['expiration_date:max'])
            // 
            // prepared_data = {}
            // for vehicle_id, state, expiration_date in data:
            //     if prepared_data.get(vehicle_id.id):
            //         if prepared_data[vehicle_id.id]['expiration_date'] < expiration_date:
            //             prepared_data[vehicle_id.id]['expiration_date'] = expiration_date
            //             prepared_data[vehicle_id.id]['state'] = state
            //     else:
            //         prepared_data[vehicle_id.id] = {
            //             'state': state,
            //             'expiration_date': expiration_date,
            //         }
            // 
            // for record in self:
            //     vehicle_data = prepared_data.get(record.id)
            //     if vehicle_data:
            //         diff_time = (vehicle_data['expiration_date'] - current_date).days
            //         record.contract_renewal_overdue = diff_time < 0
            //         record.contract_renewal_due_soon = not record.contract_renewal_overdue and (diff_time < delay_alert_contract)
            //         record.contract_state = vehicle_data['state']
            //     else:
            //         record.contract_renewal_overdue = False
            //         record.contract_renewal_due_soon = False
            //         record.contract_state = ""
            */
            return default;
        }

        public async Task<TEntity> ComputeCountAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_count_all(self):
            // Odometer = self.env['fleet.vehicle.odometer']
            // LogService = self.env['fleet.vehicle.log.services'].with_context(active_test=False)
            // LogContract = self.env['fleet.vehicle.log.contract'].with_context(active_test=False)
            // History = self.env['fleet.vehicle.assignation.log']
            // odometers_data = Odometer._read_group([('vehicle_id', 'in', self.ids)], ['vehicle_id'], ['__count'])
            // services_data = LogService._read_group([('vehicle_id', 'in', self.ids)], ['vehicle_id', 'active'], ['__count'])
            // logs_data = LogContract._read_group([('vehicle_id', 'in', self.ids), ('state', '!=', 'closed')], ['vehicle_id', 'active'], ['__count'])
            // histories_data = History._read_group([('vehicle_id', 'in', self.ids)], ['vehicle_id'], ['__count'])
            // 
            // mapped_odometer_data = defaultdict(lambda: 0)
            // mapped_service_data = defaultdict(lambda: defaultdict(lambda: 0))
            // mapped_log_data = defaultdict(lambda: defaultdict(lambda: 0))
            // mapped_history_data = defaultdict(lambda: 0)
            // 
            // for vehicle, count in odometers_data:
            //     mapped_odometer_data[vehicle.id] = count
            // for vehicle, active, count in services_data:
            //     mapped_service_data[vehicle.id][active] = count
            // for vehicle, active, count in logs_data:
            //     mapped_log_data[vehicle.id][active] = count
            // for vehicle, count in histories_data:
            //     mapped_history_data[vehicle.id] = count
            // 
            // for vehicle in self:
            //     vehicle.odometer_count = mapped_odometer_data[vehicle.id]
            //     vehicle.service_count = mapped_service_data[vehicle.id][vehicle.active]
            //     vehicle.contract_count = mapped_log_data[vehicle.id][vehicle.active]
            //     vehicle.history_count = mapped_history_data[vehicle.id]
            */
            return default;
        }

        public async Task<TEntity> ComputeDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def _compute_display_name(self):
            // for record in self:
            //     name = record.name
            //     if record.brand_id.name:
            //         name = f"{record.brand_id.name}/{name}"
            //     record.display_name = name
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_display_name(self):
            // if self.browse().has_access('read'):
            //     return super()._compute_display_name()
            // for employee_private, employee_public in zip(self, self.env['hr.employee.public'].browse(self.ids)):
            //     employee_private.display_name = employee_public.display_name
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

        public async Task<TEntity> ComputeEmailFormattedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ComputeGetIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_get_ids(self):
            // for partner in self:
            //     partner.self = partner.id
            */
            return default;
        }

        public async Task<TEntity> ComputeImStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _compute_im_status(self):
            // # sudo - bus.presence: guests can access other guest's presences
            // presences = self.env["bus.presence"].sudo().search([("guest_id", "in", self.ids)])
            // im_status_by_guest = {presence.guest_id: presence.status for presence in presences}
            // for guest in self:
            //     guest.im_status = im_status_by_guest.get(guest, "offline")
            */
            return default;
        }

        public async Task<TEntity> ComputeIsPublicInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ComputeKmHomeWorkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_km_home_work(self):
            // for employee in self:
            //     employee.km_home_work = employee.distance_home_work * 1.609 if employee.distance_home_work_unit == "miles" else employee.distance_home_work
            */
            return default;
        }

        public async Task<TEntity> ComputeModelFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_model_fields(self):
            // '''
            // Copies all the related fields from the model to the vehicle
            // '''
            // model_values = dict()
            // for vehicle in self.filtered('model_id'):
            //     if vehicle.model_id.id in model_values:
            //         write_vals = model_values[vehicle.model_id.id]
            //     else:
            //         # copy if value is truthy
            //         write_vals = {MODEL_FIELDS_TO_VEHICLE[key]: vehicle.model_id[key] for key in MODEL_FIELDS_TO_VEHICLE\
            //             if vehicle.model_id[key]}
            //         model_values[vehicle.model_id.id] = write_vals
            //     vehicle.update(write_vals)
            */
            return default;
        }

        public async Task<TEntity> ComputePartnerShareInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ComputeRelatedPartnersCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_related_partners_count(self):
            // self.related_partners_count = len(self._get_related_partners())
            */
            return default;
        }

        public async Task<TEntity> ComputeSameVatPartnerIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ComputeServiceActivityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_service_activity(self):
            // for vehicle in self:
            //     activities_state = set(state for state in vehicle.log_services.mapped('activity_state') if state and state != 'planned')
            //     vehicle.service_activity = sorted(activities_state)[0] if activities_state else 'none'
            */
            return default;
        }

        public async Task<TEntity> ComputeTzOffsetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_tz_offset(self):
            // for partner in self:
            //     partner.tz_offset = datetime.datetime.now(pytz.timezone(partner.tz or 'GMT')).strftime('%z')
            */
            return default;
        }

        public async Task<TEntity> ComputeUserIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> ComputeVatLabelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _compute_vat_label(self):
            // self.vat_label = self.env.company.country_id.vat_label or _("Tax ID")
            */
            return default;
        }

        public async Task<TEntity> ComputeVehicleCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def _compute_vehicle_count(self):
            // group = self.env['fleet.vehicle']._read_group(
            //     [('model_id', 'in', self.ids)], ['model_id'], aggregates=['__count'],
            // )
            // count_by_model = {model.id: count for model, count in group}
            // for model in self:
            //     model.vehicle_count = count_by_model.get(model.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeVehicleNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _compute_vehicle_name(self):
            // for record in self:
            //     record.name = (record.model_id.brand_id.name or '') + '/' + (record.model_id.name or '') + '/' + (record.license_plate or _('No Plate'))
            */
            return default;
        }

        public async Task<TEntity> ComputeWorkPermitNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _compute_work_permit_name(self):
            // for employee in self:
            //     name = employee.name.replace(' ', '_') + '_' if employee.name else ''
            //     permit_no = '_' + employee.permit_no if employee.permit_no else ''
            //     employee.work_permit_name = "%swork_permit%s" % (name, permit_no)
            */
            return default;
        }

        public async Task<TEntity> CopyCacheFromInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @public, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _copy_cache_from(self, public, field_names):
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // for fname in field_names:
            //     values = self.env.cache.get_values(public, public._fields[fname])
            //     if self._fields[fname].translate:
            //         values = [(value.copy() if value else None) for value in values]
            //     self.env.cache.update_raw(self, self._fields[fname], values)
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def create(self, vals_list):
            // ptc_values = [self._clean_vals_internal_user(vals) for vals in vals_list]
            // vehicles = super().create(vals_list)
            // for vehicle, vals, ptc_value in zip(vehicles, vals_list, ptc_values):
            //     if ptc_value:
            //         vehicle.sudo().write(ptc_value)
            //     if 'driver_id' in vals and vals['driver_id']:
            //         vehicle.create_driver_history(vals)
            //     if 'future_driver_id' in vals and vals['future_driver_id']:
            //         state_waiting_list = self.env.ref('fleet.fleet_vehicle_state_waiting_list', raise_if_not_found=False)
            //         states = vehicle.mapped('state_id').ids
            //         if not state_waiting_list or state_waiting_list.id not in states:
            //             future_driver = self.env['res.partner'].browse(vals['future_driver_id'])
            //             if self.vehicle_type == 'bike':
            //                 future_driver.sudo().write({'plan_to_change_bike': True})
            //             if self.vehicle_type == 'car':
            //                 future_driver.sudo().write({'plan_to_change_car': True})
            // return vehicles
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('user_id'):
            //         user = self.env['res.users'].browse(vals['user_id'])
            //         vals.update(self._sync_user(user, bool(vals.get('image_1920'))))
            //         vals['name'] = vals.get('name', user.name)
            //         self._remove_work_contact_id(user, vals.get('company_id'))
            // employees = super().create(vals_list)
            // # Sudo in case HR officer doesn't have the Contact Creation group
            // employees.filtered(lambda e: not e.work_contact_id).sudo()._create_work_contacts()
            // for employee_sudo in employees.sudo():
            //     # creating 'svg/xml' attachments requires specific rights
            //     if not employee_sudo.image_1920 and self.env['ir.ui.view'].sudo(False).has_access('write'):
            //         employee_sudo.image_1920 = employee_sudo._avatar_generate_svg()
            //         employee_sudo.work_contact_id.image_1920 = employee_sudo.image_1920
            // if self.env.context.get('salary_simulation'):
            //     return employees
            // employee_departments = employees.department_id
            // if employee_departments:
            //     self.env['discuss.channel'].sudo().search([
            //         ('subscription_department_ids', 'in', employee_departments.ids)
            //     ])._subscribe_users_automatically()
            // onboarding_notes_bodies = {}
            // hr_root_menu = self.env.ref('hr.menu_hr_root')
            // for employee in employees:
            //     # Launch onboarding plans
            //     url = '/odoo/%s/action-hr.plan_wizard_action?active_model=hr.employee&menu_id=%s' % (employee.id, hr_root_menu.id)
            //     onboarding_notes_bodies[employee.id] = Markup(_(
            //         '<b>Congratulations!</b> May I recommend you to setup an <a href="%s">onboarding plan?</a>',
            //     )) % url
            // employees._message_log_batch(onboarding_notes_bodies)
            // return employees
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

        public async Task<TEntity> CreateCompanyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> CreateDriverHistoryAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def create_driver_history(self, vals):
            // for vehicle in self:
            //     self.env['fleet.vehicle.assignation.log'].create(
            //         vehicle._get_driver_history_data(vals),
            //     )
            */
            return default;
        }

        public async Task<TEntity> CreateUserAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_create_user(self):
            // self.ensure_one()
            // if self.user_id:
            //     raise ValidationError(_("This employee already has an user."))
            // return {
            //     'name': _('Create User'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.users',
            //     'view_mode': 'form',
            //     'view_id': self.env.ref('hr.view_users_simple_form').id,
            //     'target': 'new',
            //     'context': dict(self._context, **{
            //         'default_create_employee_id': self.id,
            //         'default_name': self.name,
            //         'default_phone': self.work_phone,
            //         'default_mobile': self.mobile_phone,
            //         'default_login': self.work_email,
            //         'default_partner_id': self.work_contact_id.id,
            //     })
            // }
            */
            return default;
        }

        public async Task<TEntity> CronCheckWorkPermitValidityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _cron_check_work_permit_validity(self):
            // # Called by a cron
            // # Schedule an activity 1 month before the work permit expires
            // outdated_days = fields.Date.today() + relativedelta(months=+1)
            // nearly_expired_work_permits = self.search([('work_permit_scheduled_activity', '=', False), ('work_permit_expiration_date', '<', outdated_days)])
            // employees_scheduled = self.env['hr.employee']
            // for employee in nearly_expired_work_permits.filtered(lambda employee: employee.parent_id):
            //     responsible_user_id = employee.parent_id.user_id.id
            //     if responsible_user_id:
            //         employees_scheduled |= employee
            //         lang = self.env['res.users'].browse(responsible_user_id).lang
            //         formated_date = format_date(employee.env, employee.work_permit_expiration_date, date_format="dd MMMM y", lang_code=lang)
            //         employee.activity_schedule(
            //             'mail.mail_activity_data_todo',
            //             note=_('The work permit of %(employee)s expires at %(date)s.',
            //                 employee=employee.name,
            //                 date=formated_date),
            //             user_id=responsible_user_id)
            // employees_scheduled.write({'work_permit_scheduled_activity': True})
            */
            return default;
        }

        public async Task<TEntity> DefaultCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _default_category(self):
            // return self.env['res.partner.category'].browse(self._context.get('category_id'))
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object default_fields) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> DisplayAddressDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> DisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> EmployeeAttendanceIntervalsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start, object stop, object lunch) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _employee_attendance_intervals(self, start, stop, lunch=False):
            // self.ensure_one()
            // calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            // if not lunch:
            //     return self._get_expected_attendances(start, stop)
            // else:
            //     return calendar._attendance_intervals_batch(start, stop, self.resource_id, lunch=True)[self.resource_id.id]
            */
            return default;
        }

        public async Task<TEntity> FetchAsync<TEntity>(IEnumerable<TEntity> entities, object field_names) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def fetch(self, field_names):
            // if self.browse().has_access('read'):
            //     return super().fetch(field_names)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // self._check_private_fields(field_names)
            // self.flush_recordset(field_names)
            // public = self.env['hr.employee.public'].browse(self._ids)
            // public.fetch(field_names)
            // self._copy_cache_from(public, field_names)
            */
            return default;
        }

        public async Task<TEntity> FieldsSyncInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> FindOrCreateAsync<TEntity>(IEnumerable<TEntity> entities, object email, object assert_valid_email) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> FormatAuthCookieInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _format_auth_cookie(self):
            // """Format the cookie value for the given guest.
            // 
            // :param guest: guest to format the cookie value for
            // :return str: formatted cookie value
            // """
            // self.ensure_one()
            // return f"{self.id}{self._cookie_separator}{self.access_token}"
            */
            return default;
        }

        public async Task<TEntity> FormattingAddressFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _formatting_address_fields(self):
            // """Returns the list of address fields usable to format addresses."""
            // return self._address_fields()
            */
            return default;
        }

        public async Task<TEntity> GenerateRandomBarcodeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def generate_random_barcode(self):
            // for employee in self:
            //     employee.barcode = '041'+"".join(choice(digits) for i in range(9))
            */
            return default;
        }

        public async Task<TEntity> GetAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_address_format(self):
            // return self.country_id.address_format or self._get_default_address_format()
            */
            return default;
        }

        public async Task<TEntity> GetAgeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object target_date) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_age(self, target_date=None):
            // self.ensure_one()
            // if target_date is None:
            //     target_date = fields.Date.context_today(self.env.user)
            // return relativedelta(target_date, self.birthday).years if self.birthday else 0
            */
            return default;
        }

        public async Task<TEntity> GetAllAddrInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> GetAnalyticNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_analytic_name(self):
            // # This function is used in fleet_account and is overrided in l10n_be_hr_payroll_fleet
            // return self.license_plate or _('No plate')
            */
            return default;
        }

        public async Task<TEntity> GetCalendarAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_calendar_attendances(self, date_from, date_to):
            // self.ensure_one()
            // employee_timezone = timezone(self.tz) if self.tz else None
            // calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            // return calendar\
            //     .with_context(employee_timezone=employee_timezone)\
            //     .get_work_duration_data(
            //         date_from,
            //         date_to,
            //         domain=[('company_id', 'in', [False, self.company_id.id])])
            */
            return default;
        }

        public async Task<TEntity> GetCompanyRegistryLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_company_registry_labels(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetCompleteNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> GetCountryNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_country_name(self):
            // return self.country_id.name or ''
            */
            return default;
        }

        public async Task<TEntity> GetDefaultAddressFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_default_address_format(self):
            // return "%(street)s\n%(street2)s\n%(city)s %(state_code)s %(zip)s\n%(country_name)s"
            */
            return default;
        }

        public async Task<TEntity> GetDefaultStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_default_state(self):
            // state = self.env.ref('fleet.fleet_vehicle_state_new_request', raise_if_not_found=False)
            // return state if state and state.id else False
            */
            return default;
        }

        public async Task<TEntity> GetDriverHistoryDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_driver_history_data(self, vals):
            // self.ensure_one()
            // return {
            //     'vehicle_id': self.id,
            //     'driver_id': vals['driver_id'],
            //     'date_start': fields.Date.today(),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetEmployeeM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_employee_m2o_to_empty_on_archived_employees(self):
            // return ['parent_id', 'coach_id']
            */
            return default;
        }

        public async Task<TEntity> GetExpectedAttendancesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_expected_attendances(self, date_from, date_to):
            // self.ensure_one()
            // employee_timezone = timezone(self.tz) if self.tz else None
            // calendar = self.resource_calendar_id or self.company_id.resource_calendar_id
            // calendar_intervals = calendar._work_intervals_batch(
            //                         date_from,
            //                         date_to,
            //                         tz=employee_timezone,
            //                         resources=self.resource_id,
            //                         compute_leaves=True,
            //                         domain=[('company_id', 'in', [False, self.company_id.id])])[self.resource_id.id]
            // return calendar_intervals
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_formview_action(self, access_uid=None):
            // """ Override this method in order to redirect many2one towards the right model depending on access_uid """
            // res = super(HrEmployeePrivate, self).get_formview_action(access_uid=access_uid)
            // user = self.env.user
            // if access_uid:
            //     user = self.env['res.users'].browse(access_uid).sudo()
            // 
            // if not user.has_group('hr.group_hr_user'):
            //     res['res_model'] = 'hr.employee.public'
            // 
            // return res
            */
            return default;
        }

        public async Task<TEntity> GetFormviewIdAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_formview_id(self, access_uid=None):
            // """ Override this method in order to redirect many2one towards the right model depending on access_uid """
            // user = self.env.user
            // if access_uid:
            //     user = self.env['res.users'].browse(access_uid).sudo()
            // 
            // if user.has_group('hr.group_hr_user'):
            //     return super(HrEmployeePrivate, self).get_formview_id(access_uid=access_uid)
            // # Hardcode the form view for public employee
            // return self.env.ref('hr.hr_employee_public_view_form').id
            */
            return default;
        }

        public async Task<TEntity> GetGravatarImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> GetGuestFromContextInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _get_guest_from_context(self):
            // """Returns the current guest record from the context, if applicable."""
            // guest = self.env.context.get('guest')
            // if isinstance(guest, self.pool['mail.guest']):
            //     return guest.sudo(False).with_context(guest=guest)
            // return self.env['mail.guest']
            */
            return default;
        }

        public async Task<TEntity> GetGuestFromTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object token) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _get_guest_from_token(self, token=""):
            // """Returns the guest record for the given token, if applicable."""
            // guest = self.env["mail.guest"]
            // parts = token.split(self._cookie_separator)
            // if len(parts) == 2:
            //     guest_id, guest_access_token = parts
            //     # sudo: mail.guest: guests need sudo to read their access_token
            //     guest = self.browse(int(guest_id)).sudo().exists()
            //     if not guest or not guest.access_token or not consteq(guest.access_token, guest_access_token):
            //         guest = self.env["mail.guest"]
            // return guest.sudo(False)
            */
            return default;
        }

        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Employees'),
            //     'template': '/hr/static/xls/hr_employee.xls'
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

        public async Task<TEntity> GetMaritalStatusSelectionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_marital_status_selection(self):
            // return [
            //     ('single', _('Single')),
            //     ('married', _('Married')),
            //     ('cohabitant', _('Legal Cohabitant')),
            //     ('widower', _('Widower')),
            //     ('divorced', _('Divorced')),
            // ]
            */
            return default;
        }

        public async Task<TEntity> GetOdometerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _get_odometer(self):
            // FleetVehicalOdometer = self.env['fleet.vehicle.odometer']
            // for record in self:
            //     vehicle_odometer = FleetVehicalOdometer.search([('vehicle_id', '=', record.id)], limit=1, order='value desc')
            //     if vehicle_odometer:
            //         record.odometer = vehicle_odometer.value
            //     else:
            //         record.odometer = 0
            */
            return default;
        }

        public async Task<TEntity> GetPartnerCountDependsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_partner_count_depends(self):
            // return ['user_id']
            */
            return default;
        }

        public async Task<TEntity> GetRelatedPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_related_partners(self):
            // return self.work_contact_id | self.user_id.partner_id
            */
            return default;
        }

        public async Task<TEntity> GetStreetSplitInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _get_street_split(self):
            // self.ensure_one()
            // return tools.street_split(self.street or '')
            */
            return default;
        }

        public async Task<TEntity> GetTimezoneFromRequestInternalAsync<TEntity>(IEnumerable<TEntity> entities, object request) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _get_timezone_from_request(self, request):
            // timezone = request.cookies.get('tz')
            // return timezone if timezone in pytz.all_timezones else False
            */
            return default;
        }

        public async Task<TEntity> GetTzBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_tz_batch(self):
            // # Finds the first valid timezone in his tz, his work hours tz,
            // #  the company calendar tz or UTC
            // # Returns a dict {employee_id: tz}
            // return {emp.id: emp._get_tz() for emp in self}
            */
            return default;
        }

        public async Task<TEntity> GetTzInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_tz(self):
            // # Finds the first valid timezone in his tz, his work hours tz,
            // #  the company calendar tz or UTC and returns it as a string
            // self.ensure_one()
            // return self.tz or\
            //        self.resource_calendar_id.tz or\
            //        self.company_id.resource_calendar_id.tz or\
            //        'UTC'
            */
            return default;
        }

        public async Task<TEntity> GetUnusualDaysInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_from, object date_to) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_unusual_days(self, date_from, date_to=None):
            // # Checking the calendar directly allows to not grey out the leaves taken
            // # by the employee or fallback to the company calendar
            // return (self.resource_calendar_id or self.env.company.resource_calendar_id)._get_unusual_days(
            //     datetime.combine(fields.Date.from_string(date_from), time.min).replace(tzinfo=UTC),
            //     datetime.combine(fields.Date.from_string(date_to), time.max).replace(tzinfo=UTC),
            //     self.company_id,
            // )
            */
            return default;
        }

        public async Task<TEntity> GetUserM2oToEmptyOnArchivedEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _get_user_m2o_to_empty_on_archived_employees(self):
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_view(self, view_id=None, view_type='form', **options):
            // if self.browse().has_access('read'):
            //     return super().get_view(view_id, view_type, **options)
            // return self.env['hr.employee.public'].get_view(view_id, view_type, **options)
            */
            return default;
        }

        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def get_views(self, views, options=None):
            // if self.browse().has_access('read'):
            //     return super().get_views(views, options)
            // res = self.env['hr.employee.public'].get_views(views, options)
            // res['models'].update({'hr.employee': res['models']['hr.employee.public']})
            // return res
            */
            return default;
        }

        public async Task<TEntity> HandleFirstContactCreationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> InverseKmHomeWorkInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _inverse_km_home_work(self):
            // for employee in self:
            //     employee.distance_home_work = employee.km_home_work / 1.609 if employee.distance_home_work_unit == "miles" else employee.km_home_work
            */
            return default;
        }

        public async Task<TEntity> LangGetInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        public async Task<TEntity> LoadRecordsCreateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> LoadScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _load_scenario(self):
            // demo_tag = self.env.ref('hr.employee_category_demo', raise_if_not_found=False)
            // if demo_tag:
            //     return
            // convert.convert_file(self.env, 'hr', 'data/scenarios/hr_scenario.xml', None, mode='init', kind='data')
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['user_partner_id']
            */
            return default;
        }

        public async Task<TEntity> ModelVehicleAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def action_model_vehicle(self):
            // self.ensure_one()
            // context = {'default_model_id': self.id}
            // if self.vehicle_count:
            //     view_mode = 'kanban,list,form'
            //     name = _('Vehicles')
            //     context['search_default_model_id'] = self.id
            // else:
            //     view_mode = 'form'
            //     name = _('Vehicle')
            // view = {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': view_mode,
            //     'res_model': 'fleet.vehicle',
            //     'name': name,
            //     'context': context,
            // }
            // 
            // return view
            */
            return default;
        }

        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_company_id(self):
            // if self._origin:
            //     return {'warning': {
            //         'title': _("Warning"),
            //         'message': _("To avoid multi company issues (losing the access to your previous contracts, leaves, ...), you should create another employee in the new company instead.")
            //     }}
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_company_id(self):
            // if self.parent_id:
            //     self.company_id = self.parent_id.company_id.id
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyTypeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_company_type(self):
            // self.is_company = (self.company_type == 'company')
            */
            return default;
        }

        public async Task<TEntity> OnchangeCountryIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_country_id(self):
            // if self.country_id and self.country_id != self.state_id.country_id:
            //     self.state_id = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def onchange_email(self):
            // if not self.image_1920 and self._context.get('gravatar_image') and self.email:
            //     self.image_1920 = self._get_gravatar_image(self.email)
            */
            return default;
        }

        public async Task<TEntity> OnchangeParentIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> OnchangeParentIdForLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> OnchangeStateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _onchange_state(self):
            // if self.state_id.country_id and self.country_id != self.state_id.country_id:
            //     self.country_id = self.state_id.country_id
            */
            return default;
        }

        public async Task<TEntity> OnchangeTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_timezone(self):
            // if self.resource_calendar_id and not self.tz:
            //     self.tz = self.resource_calendar_id.tz
            */
            return default;
        }

        public async Task<TEntity> OnchangeUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _onchange_user(self):
            // self.update(self._sync_user(self.user_id, (bool(self.image_1920))))
            // if not self.name:
            //     self.name = self.user_id.name
            */
            return default;
        }

        public async Task<TEntity> OpenAssignationLogsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def open_assignation_logs(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': 'Assignment Logs',
            //     'view_mode': 'list',
            //     'res_model': 'fleet.vehicle.assignation.log',
            //     'domain': [('vehicle_id', '=', self.id)],
            //     'context': {'default_driver_id': self.driver_id.id, 'default_vehicle_id': self.id}
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenCommercialEntityAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _phone_get_number_fields(self):
            // return ['mobile_phone']
            */
            return default;
        }

        public async Task<TEntity> PrepareDisplayAddressInternalAsync<TEntity>(IEnumerable<TEntity> entities, object without_company) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> PrepareResourceValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object tz) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _prepare_resource_values(self, vals, tz):
            // resource_vals = super()._prepare_resource_values(vals, tz)
            // vals.pop('name')  # Already considered by super call but no popped
            // # We need to pop it to avoid useless resource update (& write) call
            // # on every newly created resource (with the correct name already)
            // user_id = vals.pop('user_id', None)
            // if user_id:
            //     resource_vals['user_id'] = user_id
            // active_status = vals.get('active')
            // if active_status is not None:
            //     resource_vals['active'] = active_status
            // return resource_vals
            */
            return default;
        }

        public async Task<TEntity> RelatedContactsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def action_related_contacts(self):
            // related_partners = self._get_related_partners()
            // action = {
            //     'name': _("Related Contacts"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'res.partner',
            //     'view_mode': 'form',
            // }
            // if len(related_partners) > 1:
            //     action['view_mode'] = 'kanban,list,form'
            //     action['domain'] = [('id', 'in', related_partners.ids)]
            //     return action
            // else:
            //     action['res_id'] = related_partners.id
            // return action
            */
            return default;
        }

        public async Task<TEntity> RemoveWorkContactIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_company) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _remove_work_contact_id(self, user, employee_company):
            // """ Remove work_contact_id for previous employee if the user is assigned to a new employee """
            // employee_company = employee_company or self.company_id.id
            // # For employees with a user_id, the constraint (user can't be linked to multiple employees) is triggered
            // old_partner_employee_ids = user.partner_id.employee_ids.filtered(lambda e:
            //     not e.user_id
            //     and e.company_id.id == employee_company
            //     and e != self
            // )
            // old_partner_employee_ids.work_contact_id = None
            */
            return default;
        }

        public async Task<TEntity> ReturnToOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def return_action_to_open(self):
            // """ This opens the xml view specified in xml_id for the current vehicle """
            // self.ensure_one()
            // xml_id = self.env.context.get('xml_id')
            // if xml_id:
            // 
            //     res = self.env['ir.actions.act_window']._for_xml_id('fleet.%s' % xml_id)
            //     res.update(
            //         context=dict(self.env.context, default_vehicle_id=self.id, group_by=False),
            //         domain=[('vehicle_id', '=', self.id)]
            //     )
            //     return res
            // return False
            */
            return default;
        }

        public async Task<TEntity> SearchContractRenewalDueSoonInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _search_contract_renewal_due_soon(self, operator, value):
            // params = self.env['ir.config_parameter'].sudo()
            // delay_alert_contract = int(params.get_param('hr_fleet.delay_alert_contract', default=30))
            // res = []
            // assert operator in ('=', '!=', '<>') and value in (True, False), 'Operation not supported'
            // if (operator == '=' and value is True) or (operator in ('<>', '!=') and value is False):
            //     search_operator = 'in'
            // else:
            //     search_operator = 'not in'
            // today = fields.Date.context_today(self)
            // datetime_today = fields.Datetime.from_string(today)
            // limit_date = fields.Datetime.to_string(datetime_today + relativedelta(days=+delay_alert_contract))
            // res_ids = self.env['fleet.vehicle.log.contract'].search([
            //     ('expiration_date', '>', today),
            //     ('expiration_date', '<', limit_date),
            //     ('state', 'in', ['open', 'expired'])
            // ]).mapped('vehicle_id').ids
            // res.append(('id', search_operator, res_ids))
            // return res
            */
            return default;
        }

        public async Task<TEntity> SearchDisplayNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def _search_display_name(self, operator, value):
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     positive_operator = expression.TERM_OPERATORS_NEGATION[operator]
            // else:
            //     positive_operator = operator
            // domain = expression.OR([[('name', positive_operator, value)], [('brand_id.name', positive_operator, value)]])
            // if positive_operator != operator:
            //     domain = ['!', *domain]
            // return domain
            */
            return default;
        }

        public async Task<TEntity> SearchFetchAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object field_names, object offset, object limit, object order) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def search_fetch(self, domain, field_names, offset=0, limit=None, order=None):
            // if self.browse().has_access('read'):
            //     return super().search_fetch(domain, field_names, offset, limit, order)
            // 
            // # HACK: retrieve publicly available values from hr.employee.public and
            // # copy them to the cache of self; non-public data will be missing from
            // # cache, and interpreted as an access error
            // self._check_private_fields(field_names)
            // self.flush_model(field_names)
            // public = self.env['hr.employee.public'].search_fetch(domain, field_names, offset, limit, order)
            // employees = self.browse(public._ids)
            // employees._copy_cache_from(public, field_names)
            // return employees
            */
            return default;
        }

        public async Task<TEntity> SearchGetOverdueContractReminderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _search_get_overdue_contract_reminder(self, operator, value):
            // res = []
            // assert operator in ('=', '!=', '<>') and value in (True, False), 'Operation not supported'
            // if (operator == '=' and value is True) or (operator in ('<>', '!=') and value is False):
            //     search_operator = 'in'
            // else:
            //     search_operator = 'not in'
            // today = fields.Date.context_today(self)
            // # get the id of vehicles that have overdue contracts
            // # but exclude those for which a new contract has already been created for them
            // vehicle_ids = self.env['fleet.vehicle']._search([
            //     ("log_contracts", "any", [
            //         ('expiration_date', '!=', False),
            //         ('expiration_date', '<', today),
            //         ('state', 'in', ['open', 'expired'])
            //     ]),
            //     "!",
            //         ("log_contracts", "any", [
            //             ('expiration_date', '!=', False),
            //             ('expiration_date', '>=', today),
            //             ('state', 'in', ['open', 'futur'])
            //         ]),
            // ])
            // res.append(('id', search_operator, vehicle_ids))
            // return res
            */
            return default;
        }

        public async Task<TEntity> SearchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object offset, object limit, object order) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None):
            // """
            //     We override the _search because it is the method that checks the access rights
            //     This is correct to override the _search. That way we enforce the fact that calling
            //     search on an hr.employee returns a hr.employee recordset, even if you don't have access
            //     to this model, as the result of _search (the ids of the public employees) is to be
            //     browsed on the hr.employee model. This can be trusted as the ids of the public
            //     employees exactly match the ids of the related hr.employee.
            // """
            // if self.browse().has_access('read'):
            //     return super()._search(domain, offset, limit, order)
            // try:
            //     ids = self.env['hr.employee.public']._search(domain, offset, limit, order)
            // except ValueError:
            //     raise AccessError(_('You do not have access to this document.'))
            // # the result is expected from this table, so we should link tables
            // return super(HrEmployeePrivate, self.sudo())._search([('id', 'in', ids)], order=order)
            */
            return default;
        }

        public async Task<TEntity> SearchVehicleCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle_model.py) ---
            // def _search_vehicle_count(self, operator, value):
            // if operator not in ['=', '!=', '<', '>'] or not isinstance(value, int):
            //     raise NotImplementedError(_('Operation not supported.'))
            // fleet_models = self.env['fleet.vehicle.model'].search([])
            // if operator == '=':
            //     fleet_models = fleet_models.filtered(lambda m: m.vehicle_count == value)
            // elif operator == '!=':
            //     fleet_models = fleet_models.filtered(lambda m: m.vehicle_count != value)
            // elif operator == '<':
            //     fleet_models = fleet_models.filtered(lambda m: m.vehicle_count < value)
            // elif operator == '>':
            //     fleet_models = fleet_models.filtered(lambda m: m.vehicle_count > value)
            // return [('id', 'in', fleet_models.ids)]
            */
            return default;
        }

        public async Task<TEntity> SendEmailAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def action_send_email(self):
            // return {
            //     'name': _('Send Email'),
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'view_mode': 'form',
            //     'res_model': 'fleet.vehicle.send.mail',
            //     'context': {
            //         'default_vehicle_ids': self.ids,
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> SetAuthCookieInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _set_auth_cookie(self):
            // """Add a cookie to the response to identify the guest. Every route
            // that expects a guest will make use of it to authenticate the guest
            // through `add_guest_to_context`.
            // """
            // self.ensure_one()
            // expiration_date = datetime.now() + timedelta(days=365)
            // request.future_response.set_cookie(
            //     self._cookie_name,
            //     self._format_auth_cookie(),
            //     httponly=True,
            //     expires=expiration_date,
            // )
            // request.update_context(guest=self.sudo(False))
            */
            return default;
        }

        public async Task<TEntity> SetOdometerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _set_odometer(self):
            // for record in self:
            //     if record.odometer:
            //         date = fields.Date.context_today(record)
            //         data = {'value': record.odometer, 'date': date, 'vehicle_id': record.id}
            //         self.env['fleet.vehicle.odometer'].create(data)
            */
            return default;
        }

        public async Task<TEntity> SyncUserInternalAsync<TEntity>(IEnumerable<TEntity> entities, object user, object employee_has_image) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _sync_user(self, user, employee_has_image=False):
            // vals = dict(
            //     work_contact_id=user.partner_id.id if user else self.work_contact_id.id,
            //     user_id=user.id,
            // )
            // if not employee_has_image:
            //     vals['image_1920'] = user.image_1920
            // if user.tz:
            //     vals['tz'] = user.tz
            // return vals
            */
            return default;
        }

        protected async Task<object> ToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _to_store(self, store: Store, /, *, fields=None):
            // if fields is None:
            //     fields = ["avatar_128", "im_status", "name"]
            // for guest in self:
            //     data = guest._read_format(
            //         [field for field in fields if field not in ["avatar_128"]],
            //         load=False,
            //     )[0]
            //     if "avatar_128" in fields:
            //         data["avatar_128_access_token"] = limited_field_access_token(guest, "avatar_128")
            //         data["write_date"] = guest.write_date
            //     store.add(guest, data)
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def toggle_active(self):
            // res = super(HrEmployeePrivate, self).toggle_active()
            // unarchived_employees = self.filtered(lambda employee: employee.active)
            // unarchived_employees.write({
            //     'departure_reason_id': False,
            //     'departure_description': False,
            //     'departure_date': False
            // })
            // 
            // archived_employees = self.filtered(lambda e: not e.active)
            // if archived_employees:
            //     # Empty links to this employees (example: manager, coach, time off responsible, ...)
            //     employee_fields_to_empty = self._get_employee_m2o_to_empty_on_archived_employees()
            //     user_fields_to_empty = self._get_user_m2o_to_empty_on_archived_employees()
            //     employee_domain = [[(field, 'in', archived_employees.ids)] for field in employee_fields_to_empty]
            //     user_domain = [[(field, 'in', archived_employees.user_id.ids)] for field in user_fields_to_empty]
            //     employees = self.env['hr.employee'].search(expression.OR(employee_domain + user_domain))
            //     for employee in employees:
            //         for field in employee_fields_to_empty:
            //             if employee[field] in archived_employees:
            //                 employee[field] = False
            //         for field in user_fields_to_empty:
            //             if employee[field] in archived_employees.user_id:
            //                 employee[field] = False
            // 
            // if len(self) == 1 and not self.active and not self.env.context.get('no_wizard', False):
            //     return {
            //         'type': 'ir.actions.act_window',
            //         'name': _('Register Departure'),
            //         'res_model': 'hr.departure.wizard',
            //         'view_mode': 'form',
            //         'target': 'new',
            //         'context': {'active_id': self.id},
            //         'views': [[False, 'form']]
            //     }
            // return res
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'driver_id' in init_values or 'future_driver_id' in init_values:
            //     return self.env.ref('fleet.mt_fleet_driver_updated')
            // return super(FleetVehicle, self)._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def unlink(self):
            // resources = self.mapped('resource_id')
            // super(HrEmployeePrivate, self).unlink()
            // return resources.unlink()
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptUserInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> UpdateAddressAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> UpdateFieldsValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> UpdateNameInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _update_name(self, name):
            // self.ensure_one()
            // name = name.strip()
            // if len(name) < 1:
            //     raise UserError(_("Guest's name cannot be empty."))
            // if len(name) > 512:
            //     raise UserError(_("Guest's name is too long."))
            // self.name = name
            // store = Store(self, fields=["avatar_128", "name"])
            // self.channel_ids._bus_send_store(store)
            // self._bus_send_store(store)
            */
            return default;
        }

        public async Task<TEntity> UpdateTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities, object timezone) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_guest.py) ---
            // def _update_timezone(self, timezone):
            // query = """
            //     UPDATE mail_guest
            //     SET timezone = %s
            //     WHERE id IN (
            //         SELECT id FROM mail_guest WHERE id = %s
            //         FOR NO KEY UPDATE SKIP LOCKED
            //     )
            // """
            // self.env.cr.execute(query, (timezone, self.id))
            */
            return default;
        }

        public async Task<TEntity> VerifyBarcodeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _verify_barcode(self):
            // for employee in self:
            //     if employee.barcode:
            //         if not (re.match(r'^[A-Za-z0-9]+$', employee.barcode) and len(employee.barcode) <= 18):
            //             raise ValidationError(_("The Badge ID must be alphanumeric without any accents and no longer than 18 characters."))
            */
            return default;
        }

        public async Task<TEntity> VerifyPinInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def _verify_pin(self):
            // for employee in self:
            //     if employee.pin and not employee.pin.isdigit():
            //         raise ValidationError(_("The PIN must be a sequence of digits."))
            */
            return default;
        }

        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IAvatarMixinable
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

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: fleet, FILE: fleet_vehicle.py) ---
            // def write(self, vals):
            // if 'odometer' in vals and any(vehicle.odometer > vals['odometer'] for vehicle in self):
            //     raise UserError(_('The odometer value cannot be lower than the previous one.'))
            // 
            // if 'driver_id' in vals and vals['driver_id']:
            //     driver_id = vals['driver_id']
            //     for vehicle in self.filtered(lambda v: v.driver_id.id != driver_id):
            //         vehicle.create_driver_history(vals)
            //         if vehicle.driver_id:
            //             vehicle.activity_schedule(
            //                 'mail.mail_activity_data_todo',
            //                 user_id=vehicle.manager_id.id or self.env.user.id,
            //                 note=_('Specify the End date of %s', vehicle.driver_id.name))
            // 
            // if 'future_driver_id' in vals and vals['future_driver_id']:
            //     state_waiting_list = self.env.ref('fleet.fleet_vehicle_state_waiting_list', raise_if_not_found=False)
            //     states = self.mapped('state_id').ids if 'state_id' not in vals else [vals['state_id']]
            //     if not state_waiting_list or state_waiting_list.id not in states:
            //         future_driver = self.env['res.partner'].browse(vals['future_driver_id'])
            //         if self.vehicle_type == 'bike':
            //             future_driver.sudo().write({'plan_to_change_bike': True})
            //         if self.vehicle_type == 'car':
            //             future_driver.sudo().write({'plan_to_change_car': True})
            // 
            // if 'active' in vals and not vals['active']:
            //     self.env['fleet.vehicle.log.contract'].search([('vehicle_id', 'in', self.ids)]).active = False
            //     self.env['fleet.vehicle.log.services'].search([('vehicle_id', 'in', self.ids)]).active = False
            // 
            // su_vals = self._clean_vals_internal_user(vals)
            // if su_vals:
            //     self.sudo().write(su_vals)
            // res = super(FleetVehicle, self).write(vals)
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_employee.py) ---
            // def write(self, vals):
            // if 'work_contact_id' in vals:
            //     account_ids = vals.get('bank_account_id') or self.bank_account_id.ids
            //     if account_ids:
            //         bank_accounts = self.env['res.partner.bank'].sudo().browse(account_ids)
            //         for bank_account in bank_accounts:
            //             if vals['work_contact_id'] != bank_account.partner_id.id:
            //                 if bank_account.allow_out_payment:
            //                     bank_account.allow_out_payment = False
            //                 if vals['work_contact_id']:
            //                     bank_account.partner_id = vals['work_contact_id']
            //     self.message_unsubscribe(self.work_contact_id.ids)
            //     if vals['work_contact_id']:
            //         self._message_subscribe([vals['work_contact_id']])
            // if vals.get('user_id'):
            //     # Update the profile pictures with user, except if provided
            //     user = self.env['res.users'].browse(vals['user_id'])
            //     vals.update(self._sync_user(user, (bool(all(emp.image_1920 for emp in self)))))
            //     self._remove_work_contact_id(user, vals.get('company_id'))
            // if 'work_permit_expiration_date' in vals:
            //     vals['work_permit_scheduled_activity'] = False
            // res = super(HrEmployeePrivate, self).write(vals)
            // if vals.get('department_id') or vals.get('user_id'):
            //     department_id = vals['department_id'] if vals.get('department_id') else self[:1].department_id.id
            //     # When added to a department or changing user, subscribe to the channels auto-subscribed by department
            //     self.env['discuss.channel'].sudo().search([
            //         ('subscription_department_ids', 'in', department_id)
            //     ])._subscribe_users_automatically()
            // if vals.get('departure_description'):
            //     for employee in self:
            //         employee.message_post(body=_(
            //             'Additional Information: \n %(description)s',
            //             description=vals.get('departure_description')))
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

        public async Task<TEntity> WriteCompanyTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IAvatarMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_partner.py) ---
            // def _write_company_type(self):
            // for partner in self:
            //     partner.is_company = partner.company_type == 'company'
            */
            return default;
        }
    }
}