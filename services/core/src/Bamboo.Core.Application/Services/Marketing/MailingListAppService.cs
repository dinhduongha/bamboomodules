using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("MassMailing", Category = "Marketing", Depends = new[] { "contacts", "mail", "html_builder", "utm", "link_tracker", "social_media", "web_tour", "digest" })]
    public partial class MailingListAppService : GenericApplicationService<MailingList>, IMailingListAppService
    {

        public MailingListAppService(IRepository<MailingList, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<MailingList> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def _compute_display_name(self):
            // for mailing_list in self:
            //     mailing_list.display_name = f"{mailing_list.name} ({mailing_list.contact_count})"
            */
            return default;
        }

        protected async Task<MailingList> ComputeMailingCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def _compute_mailing_count(self):
            // data = {}
            // if self.ids:
            //     self.env.cr.execute('''
            //         SELECT mailing_list_id, count(*)
            //         FROM mail_mass_mailing_list_rel
            //         WHERE mailing_list_id IN %s
            //         GROUP BY mailing_list_id''', (tuple(self.ids),))
            //     data = dict(self.env.cr.fetchall())
            // for mailing_list in self:
            //     mailing_list.mailing_count = data.get(mailing_list._origin.id, 0)
            */
            return default;
        }

        protected async Task<MailingList> ComputeMailingListStatisticsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def _compute_mailing_list_statistics(self):
            // """ Computes various statistics for this mailing.list that allow users
            // to have a global idea of its quality (based on blacklist, opt-outs, ...).
            // 
            // As some fields depend on the value of each other (mainly percentages),
            // we compute everything in a single method. """
            // # flush, notably to have email_normalized computed on contact model
            // self.env.flush_all()
            // 
            // # 1. Fetch contact data and associated counts (total / blacklist / opt-out)
            // contact_statistics_per_mailing = self._fetch_contact_statistics()
            // 
            // # 2. Fetch bounce data
            // # Optimized SQL way of fetching the count of contacts that have
            // # at least 1 message bouncing for passed mailing.lists """
            // bounce_per_mailing = {}
            // if self.ids:
            //     sql = '''
            //         SELECT list_sub.list_id, COUNT(DISTINCT mc.id)
            //         FROM mailing_contact mc
            //         LEFT OUTER JOIN mailing_subscription list_sub
            //         ON mc.id = list_sub.contact_id
            //         WHERE mc.message_bounce > 0
            //         AND list_sub.list_id in %s
            //         GROUP BY list_sub.list_id
            //     '''
            //     self.env.cr.execute(sql, (tuple(self.ids),))
            //     bounce_per_mailing = dict(self.env.cr.fetchall())
            // 
            // # 3. Compute and assign all counts / pct fields
            // for mailing_list in self:
            //     contact_counts = contact_statistics_per_mailing.get(mailing_list.id, {})
            //     for field, value in contact_counts.items():
            //         if field in self._fields:
            //             mailing_list[field] = value
            // 
            //     if mailing_list.contact_count != 0:
            //         mailing_list.contact_pct_opt_out = 100 * (mailing_list.contact_count_opt_out / mailing_list.contact_count)
            //         mailing_list.contact_pct_blacklisted = 100 * (mailing_list.contact_count_blacklisted / mailing_list.contact_count)
            //         mailing_list.contact_pct_bounce = 100 * (bounce_per_mailing.get(mailing_list.id, 0) / mailing_list.contact_count)
            //     else:
            //         mailing_list.contact_pct_opt_out = 0
            //         mailing_list.contact_pct_blacklisted = 0
            //         mailing_list.contact_pct_bounce = 0
            */
            return default;
        }

        public async Task<MailingList> CopyDataAsync(Guid id, MailingListCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", mailing_list.name)) for mailing_list, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailingList> FetchContactStatisticsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def _fetch_contact_statistics(self):
            // """ Compute number of contacts matching various conditions.
            // (see '_get_contact_count_select_fields' for details)
            // 
            // Will return a dict under the form:
            // {
            //     42: { # 42 being the mailing list ID
            //         'contact_count': 52,
            //         'contact_count_email': 35,
            //         'contact_count_opt_out': 5,
            //         'contact_count_blacklisted': 2
            //     },
            //     ...
            // } """
            // 
            // res = []
            // if self.ids:
            //     self.env.cr.execute(f'''
            //         SELECT
            //             {','.join(self._get_contact_statistics_fields().values())}
            //         FROM
            //             mailing_subscription r
            //             {self._get_contact_statistics_joins()}
            //         WHERE list_id IN %s
            //         GROUP BY
            //             list_id;
            //     ''', (tuple(self.ids), ))
            //     res = self.env.cr.dictfetchall()
            // 
            // contact_counts = {}
            // for res_item in res:
            //     mailing_list_id = res_item.pop('mailing_list_id')
            //     contact_counts[mailing_list_id] = res_item
            // 
            // for mass_mailing in self:
            //     # adds default 0 values for ids that don't have statistics
            //     if mass_mailing.id not in contact_counts:
            //         contact_counts[mass_mailing.id] = {
            //             field: 0
            //             for field in mass_mailing._get_contact_statistics_fields()
            //         }
            // 
            // return contact_counts
            */
            return default;
        }

        protected async Task<MailingList> GetContactStatisticsFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def _get_contact_statistics_fields(self):
            // """ Returns fields and SQL query select path in a dictionnary.
            // This is done to be easily overridable in subsequent modules.
            // 
            // - mailing_list_id             id of the associated mailing.list
            // - contact_count:              all contacts
            // - contact_count_email:        all valid emails
            // - contact_count_opt_out:      all opted-out contacts
            // - contact_count_blacklisted:  all blacklisted contacts """
            // 
            // return {
            //     'mailing_list_id': 'list_id AS mailing_list_id',
            //     'contact_count': 'COUNT(*) AS contact_count',
            //     'contact_count_email': '''
            //         SUM(CASE WHEN
            //                 (c.email_normalized IS NOT NULL
            //                 AND COALESCE(r.opt_out,FALSE) = FALSE
            //                 AND bl.id IS NULL)
            //                 THEN 1 ELSE 0 END) AS contact_count_email''',
            //     'contact_count_opt_out': '''
            //         SUM(CASE WHEN COALESCE(r.opt_out,FALSE) = TRUE
            //             THEN 1 ELSE 0 END) AS contact_count_opt_out''',
            //     'contact_count_blacklisted': '''
            //         SUM(CASE WHEN bl.id IS NOT NULL
            //         THEN 1 ELSE 0 END) AS contact_count_blacklisted'''
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py) ---
            // def _get_contact_statistics_fields(self):
            // """ See super method docstring for more info.
            // Adds:
            // - contact_count_sms:           all valid sms
            // - contact_count_blacklisted:   override the dict entry to add SMS blacklist condition """
            // 
            // values = super(MailingList, self)._get_contact_statistics_fields()
            // values.update({
            //     'contact_count_sms': '''
            //         SUM(CASE WHEN
            //             (c.phone_sanitized IS NOT NULL
            //             AND COALESCE(r.opt_out,FALSE) = FALSE
            //             AND bl_sms.id IS NULL)
            //         THEN 1 ELSE 0 END) AS contact_count_sms''',
            //     'contact_count_blacklisted': '''
            //         SUM(CASE WHEN (bl.id IS NOT NULL OR bl_sms.id IS NOT NULL)
            //         THEN 1 ELSE 0 END) AS contact_count_blacklisted'''
            // })
            // return values
            */
            return default;
        }

        protected async Task<MailingList> GetContactStatisticsJoinsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def _get_contact_statistics_joins(self):
            // """ Extracted to be easily overridable by sub-modules (such as mass_mailing_sms). """
            // return """
            //     LEFT JOIN mailing_contact c ON (r.contact_id=c.id)
            //     LEFT JOIN mail_blacklist bl on c.email_normalized = bl.email and bl.active"""
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py) ---
            // def _get_contact_statistics_joins(self):
            // return super(MailingList, self)._get_contact_statistics_joins() + '''
            //     LEFT JOIN phone_blacklist bl_sms ON c.phone_sanitized = bl_sms.number and bl_sms.active
            // '''
            */
            return default;
        }

        protected async Task<MailingList> MailingGetDefaultDomainInternalAsync(object mailing)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def _mailing_get_default_domain(self, mailing):
            // return [('list_ids', 'in', mailing.contact_list_ids.ids)]
            */
            return default;
        }

        protected async Task<MailingList> MailingGetOptOutListInternalAsync(object mailing)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def _mailing_get_opt_out_list(self, mailing):
            // """ Check subscription on all involved mailing lists. If user is opt_out
            // on one list but not on another if two users with same email address, one
            // opted in and the other one opted out, send the mail anyway. """
            // # TODO DBE Fixme : Optimize the following to get real opt_out and opt_in
            // subscriptions = self.subscription_ids if self else mailing.contact_list_ids.subscription_ids
            // opt_out_contacts = subscriptions.filtered(lambda rel: rel.opt_out).mapped('contact_id.email_normalized')
            // opt_in_contacts = subscriptions.filtered(lambda rel: not rel.opt_out).mapped('contact_id.email_normalized')
            // opt_out = set(c for c in opt_out_contacts if c not in opt_in_contacts)
            // return opt_out
            */
            return default;
        }

        protected async Task<MailingList> MailingGetOptOutListSmsInternalAsync(object mailing)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py) ---
            // def _mailing_get_opt_out_list_sms(self, mailing):
            // """ Check subscription on all involved mailing lists. If user is opt_out
            // on one list but not on another, one opted in and the other one opted out,
            // send mailing anyway.
            // 
            // :return: opt-outed record IDs
            // :rtype: list
            // """
            // subscriptions = self.subscription_ids if self else mailing.contact_list_ids.subscription_ids
            // opt_out_contacts = subscriptions.filtered(lambda sub: sub.opt_out).mapped('contact_id')
            // opt_in_contacts = subscriptions.filtered(lambda sub: not sub.opt_out).mapped('contact_id')
            // return list(set(c.id for c in opt_out_contacts if c not in opt_in_contacts))
            */
            return default;
        }

        public async Task<MailingList> MergeAsync(Guid id, MailingListMergeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def action_merge(self, src_lists, archive):
            // """
            //     Insert all the contact from the mailing lists 'src_lists' to the
            //     mailing list in 'self'. Possibility to archive the mailing lists
            //     'src_lists' after the merge except the destination mailing list 'self'.
            // """
            // # Explanation of the SQL query with an example. There are the following lists
            // # A (id=4): yti@odoo.com; yti@example.com
            // # B (id=5): yti@odoo.com; yti@openerp.com
            // # C (id=6): nothing
            // # To merge the mailing lists A and B into C, we build the view st that looks
            // # like this with our example:
            // #
            // #  contact_id |           email           | row_number |  list_id |
            // # ------------+---------------------------+------------------------
            // #           4 | yti@odoo.com              |          1 |        4 |
            // #           6 | yti@odoo.com              |          2 |        5 |
            // #           5 | yti@example.com           |          1 |        4 |
            // #           7 | yti@openerp.com           |          1 |        5 |
            // #
            // # The row_column is kind of an occurrence counter for the email address.
            // # Then we create the Many2many relation between the destination list and the contacts
            // # while avoiding to insert an existing email address (if the destination is in the source
            // # for example)
            // self.ensure_one()
            // # Put destination is sources lists if not already the case
            // src_lists |= self
            // self.env.flush_all()
            // self.env.cr.execute("""
            //     INSERT INTO mailing_subscription (contact_id, list_id)
            //     SELECT st.contact_id AS contact_id, %s AS list_id
            //     FROM
            //         (
            //         SELECT
            //             contact.id AS contact_id,
            //             contact.email AS email,
            //             list.id AS list_id,
            //             row_number() OVER (PARTITION BY email ORDER BY email) AS rn
            //         FROM
            //             mailing_contact contact,
            //             mailing_subscription contact_list_rel,
            //             mailing_list list
            //         WHERE contact.id=contact_list_rel.contact_id
            //         AND COALESCE(contact_list_rel.opt_out,FALSE) = FALSE
            //         AND contact.email_normalized NOT IN (select email from mail_blacklist where active = TRUE)
            //         AND list.id=contact_list_rel.list_id
            //         AND list.id IN %s
            //         AND NOT EXISTS
            //             (
            //             SELECT 1
            //             FROM
            //                 mailing_contact contact2,
            //                 mailing_subscription contact_list_rel2
            //             WHERE contact2.email = contact.email
            //             AND contact_list_rel2.contact_id = contact2.id
            //             AND contact_list_rel2.list_id = %s
            //             )
            //         ) st
            //     WHERE st.rn = 1;""", (self.id, tuple(src_lists.ids), self.id))
            // self.env.invalidate_all()
            // if archive:
            //     (src_lists - self).action_archive()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingList> OpenImportAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def action_open_import(self):
            // """Open the mailing list contact import wizard."""
            // action = self.env['ir.actions.actions']._for_xml_id('mass_mailing.mailing_contact_import_action')
            // action['context'] = {
            //     **self.env.context,
            //     'default_mailing_list_ids': self.ids,
            //     'default_subscription_ids': [
            //         Command.create({'list_id': mailing_list.id})
            //         for mailing_list in self
            //     ],
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingList> SendMailingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def action_send_mailing(self):
            // """Open the mailing form view, with the current lists set as recipients."""
            // action = self.env["ir.actions.actions"]._for_xml_id('mass_mailing.mailing_mailing_action_mail')
            // 
            // action.update({
            //     'context': {
            //         **self.env.context,
            //         'default_contact_list_ids': self.ids,
            //         'default_mailing_type': 'mail',
            //         'default_model_id': self.env['ir.model']._get_id('mailing.list'),
            //     },
            //     'target': 'current',
            //     'view_type': 'form',
            // })
            // 
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingList> SendMailingSmsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py) ---
            // def action_send_mailing_sms(self):
            // view = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_sms')
            // action = self.env["ir.actions.actions"]._for_xml_id('mass_mailing_sms.mailing_mailing_action_sms')
            // action.update({
            //     'context': {
            //         'default_contact_list_ids': self.ids,
            //         'default_model_id': self.env['ir.model']._get_id('mailing.list'),
            //         'default_mailing_type': 'sms',
            //     },
            //     'target': 'current',
            //     'view_type': 'form',
            //     'views': [(view.id, 'form')],
            // })
            // 
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<MailingList> UpdateSubscriptionFromEmailInternalAsync(object email, object opt_out, object force_message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def _update_subscription_from_email(self, email, opt_out=True, force_message=None):
            // """ When opting-out: we have to switch opted-in subscriptions. We don't
            // need to create subscription for other lists as opt-out = not being a
            // member.
            // 
            // When opting-in: we have to switch opted-out subscriptions and create
            // subscription for other mailing lists id they are public. Indeed a
            // contact is opted-in when being subscribed in a mailing list.
            // 
            // :param str email: email address that should opt-in or opt-out from
            //   mailing lists;
            // :param boolean opt_out: if True, opt-out from lists given by self if
            //   'email' is member of it. If False, opt-in in lists givben by self
            //   and create membership if not already member;
            // :param str force_message: if given, post a note using that body on
            //   contact instead of generated update message. Give False to entirely
            //   skip the note step;
            // """
            // email_normalized = tools.email_normalize(email)
            // if not self or not email_normalized:
            //     return
            // 
            // contacts = self.env['mailing.contact'].with_context(active_test=False).search(
            //     [('email_normalized', '=', email_normalized)]
            // )
            // if not contacts:
            //     return
            // 
            // # switch opted-in subscriptions
            // if opt_out:
            //     current_opt_in = contacts.subscription_ids.filtered(
            //         lambda sub: not sub.opt_out and sub.list_id in self
            //     )
            //     if current_opt_in:
            //         current_opt_in.write({'opt_out': True})
            // # switch opted-out subscription and create missing subscriptions
            // else:
            //     subscriptions = contacts.subscription_ids.filtered(lambda sub: sub.list_id in self)
            //     current_opt_out = subscriptions.filtered('opt_out')
            //     if current_opt_out:
            //         current_opt_out.write({'opt_out': False})
            // 
            //     # create a subscription (for a single contact) for missing lists
            //     missing_lists = self - subscriptions.list_id
            //     if missing_lists:
            //         self.env['mailing.subscription'].create([
            //             {'contact_id': contacts[0].id,
            //              'list_id': mailing_list.id}
            //             for mailing_list in missing_lists
            //         ])
            // 
            // for contact in contacts:
            //     # do not log if no opt-out / opt-in was actually done
            //     if opt_out:
            //         updated = current_opt_in.filtered(lambda sub: sub.contact_id == contact).list_id
            //     else:
            //         updated = current_opt_out.filtered(lambda sub: sub.contact_id == contact).list_id + missing_lists
            //     if not updated:
            //         continue
            // 
            //     if force_message is False:
            //         continue
            //     if force_message:
            //         body = force_message
            //     elif opt_out:
            //         body = Markup('<p>%s</p><ul>%s</ul>') % (
            //             _('%(contact_name)s unsubscribed from the following mailing list(s)', contact_name=contact.display_name),
            //             Markup().join(Markup('<li>%s</li>') % name for name in updated.mapped('name')),
            //         )
            //     else:
            //         body = Markup('<p>%s</p><ul>%s</ul>') % (
            //             _('%(contact_name)s subscribed to the following mailing list(s)', contact_name=contact.display_name),
            //             Markup().join(Markup('<li>%s</li>') % name for name in updated.mapped('name')),
            //         )
            //     contact.with_context(mail_post_autofollow_author_skip=True).message_post(
            //         body=body,
            //         subtype_id=self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //     )
            */
            return default;
        }

        public async Task<MailingList> ViewContactsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def action_view_contacts(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("mass_mailing.action_view_mass_mailing_contacts")
            // action['domain'] = [('list_ids', 'in', self.ids)]
            // action['context'] = {'default_list_ids': self.ids}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingList> ViewContactsBlacklistedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def action_view_contacts_blacklisted(self):
            // action = self.env["ir.actions.actions"]._for_xml_id('mass_mailing.action_view_mass_mailing_contacts')
            // action['domain'] = [('list_ids', 'in', self.id)]
            // action['context'] = {'default_list_ids': self.ids, 'create': False, 'search_default_filter_blacklisted': 1}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingList> ViewContactsBouncingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def action_view_contacts_bouncing(self):
            // action = self.env["ir.actions.actions"]._for_xml_id('mass_mailing.action_view_mass_mailing_contacts')
            // action['domain'] = [('list_ids', 'in', self.id)]
            // action['context'] = {'default_list_ids': self.ids, 'create': False, 'search_default_filter_bounce': 1}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingList> ViewContactsEmailAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def action_view_contacts_email(self):
            // action = self.action_view_contacts()
            // action['context'] = dict(action.get('context', {}), search_default_filter_valid_email_recipient=1)
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingList> ViewContactsOptOutAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def action_view_contacts_opt_out(self):
            // action = self.env["ir.actions.actions"]._for_xml_id('mass_mailing.action_view_mass_mailing_contacts')
            // action['domain'] = [('list_ids', 'in', self.id)]
            // action['context'] = {'default_list_ids': self.ids, 'create': False, 'search_default_filter_opt_out': 1}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingList> ViewContactsSmsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py) ---
            // def action_view_contacts_sms(self):
            // action = self.action_view_contacts()
            // action['context'] = dict(action.get('context', {}), search_default_filter_valid_sms_recipient=1)
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<MailingList> ViewMailingsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py) ---
            // def action_view_mailings(self):
            // action = self.env["ir.actions.actions"]._for_xml_id('mass_mailing.mailing_mailing_action_mail')
            // action['domain'] = [('contact_list_ids', 'in', self.ids)]
            // action['context'] = {'default_mailing_type': 'mail', 'default_contact_list_ids': self.ids}
            // return action
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py) ---
            // def action_view_mailings(self):
            // if self.env.context.get('mailing_sms'):
            //     action = self.env["ir.actions.actions"]._for_xml_id('mass_mailing_sms.mailing_mailing_action_sms')
            //     action['domain'] = [('id', 'in', self.mailing_ids.ids)]
            //     action['context'] = {
            //         'default_mailing_type': 'sms',
            //         'default_contact_list_ids': self.ids,
            //         'mailing_sms': True
            //     }
            //     return action
            // else:
            //     return super(MailingList, self).action_view_mailings()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}