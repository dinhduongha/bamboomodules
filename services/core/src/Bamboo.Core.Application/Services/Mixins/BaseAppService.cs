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
    public partial class BaseAppService : ApplicationService, IBaseAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public BaseAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> AddGroupbyValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groupby_read_specification, List<string> groupby, List<object> current_groups) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _add_groupby_values(self, groupby_read_specification: dict[str, dict] | None, groupby: list[str], current_groups: list):
            // if not groupby_read_specification or groupby_read_specification.keys().isdisjoint(groupby):
            //     return
            // 
            // for groupby_spec in groupby:
            //     if groupby_spec in groupby_read_specification:
            //         relational_field = self._fields[groupby_spec]
            //         assert relational_field.comodel_name, "We can only read extra info from a relational field"
            //         group_ids = [
            //             id_label[0] for group in current_groups if (id_label := group[groupby_spec])
            //         ]
            //         records = self.env[relational_field.comodel_name].browse(group_ids)
            // 
            //         result_read = records.web_read(groupby_read_specification[groupby_spec])
            //         result_read_map = dict(zip(records._ids, result_read, strict=True))
            //         for group in current_groups:
            //             id_label = group[groupby_spec]
            //             group['__values'] = result_read_map[id_label[0]] if id_label else {'id': False}
            // 
            //     current_groups = [
            //         subgroup
            //         for group in current_groups
            //         for subgroup in group.get('__groups', {}).get('groups', ())
            //     ]
            */
            return default;
        }

        public async Task<TEntity> AliasGetErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object @alias) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: models.py) ---
            // def _alias_get_error(self, message, message_dict, alias):
            // if alias.alias_contact == 'employees':
            //     email_from = tools.mail.decode_message_header(message, 'From')
            //     email_address = tools.email_normalize(email_from, strict=False)
            //     employee = self.env['hr.employee'].search([('work_email', 'ilike', email_address)], limit=1)
            //     if not employee:
            //         employee = self.env['hr.employee'].search([('user_id.email', 'ilike', email_address)], limit=1)
            //     if not employee:
            //         return AliasError('error_hr_employee_restricted', _('restricted to employees'))
            //     return False
            // return super()._alias_get_error(message, message_dict, alias)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _alias_get_error(self, message, message_dict, alias):
            // """ Generic method that takes a record not necessarily inheriting from
            // mail.alias.mixin.
            // 
            // :return: error if any, False otherwise
            // :rtype: AliasError | Literal[False]
            // """
            // author = self.env['res.partner'].browse(message_dict.get('author_id', False))
            // if alias.alias_contact == 'followers':
            //     if not self.ids:
            //         return AliasError('config_follower_no_record',
            //                           _('incorrectly configured alias (unknown reference record)'),
            //                           is_config_error=True)
            //     if not hasattr(self, "message_partner_ids"):
            //         return AliasError('config_follower_no_partners', _('incorrectly configured alias'), True)
            //     if not author or author not in self.message_partner_ids:
            //         return AliasError('error_follower_not_following', _('restricted to followers'))
            // elif alias.alias_contact == 'partners' and not author:
            //     return AliasError('error_partners_no_partner', _('restricted to known authors'))
            // return False
            */
            return default;
        }

        public async Task<TEntity> CanReturnContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object access_token) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: models.py) ---
            // def _can_return_content(self, field_name=None, access_token=None):
            // if (
            //     "website_published" in self._fields
            //     and field_name in self._fields
            //     and not self._fields[field_name].groups
            //     and self.sudo().website_published
            // ):
            //     return True
            // return super()._can_return_content(field_name, access_token)
            */
            return default;
        }

        public async Task<TEntity> FindValueFromFieldPathInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_path) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _find_value_from_field_path(self, field_path):
            // """Get the value of field, returning display_name(s) if the field is a
            // model. Can be called on a void recordset, in which case it mainly serves
            // as a field path validation."""
            // if self:
            //     self.ensure_one()
            // 
            // # as we use mapped(False) returns record, better return a void string
            // if not field_path:
            //     return ''
            // 
            // try:
            //     field_value = self.mapped(field_path)
            // except KeyError:
            //     raise exceptions.UserError(
            //         _("%(model_name)s.%(field_path)s does not seem to be a valid field path", model_name=self._name, field_path=field_path)
            //     )
            // except Exception as err:  # noqa: BLE001
            //     raise exceptions.UserError(
            //         _("We were not able to fetch value of field '%(field)s'", field=field_path)
            //     ) from err
            // if isinstance(field_value, models.Model):
            //     return ' '.join((value.display_name or '') for value in field_value)
            // if any(isinstance(value, datetime) for value in field_value):
            //     tz = (self and self._mail_get_timezone()) or self.env.user.tz or 'UTC'
            //     return ' '.join([f"{tools.format_datetime(self.env, value, tz=tz)} {tz}"
            //                      for value in field_value if value and isinstance(value, datetime)])
            // # find last field / last model when having chained fields
            // # e.g. 'partner_id.country_id.state' -> ['partner_id.country_id', 'state']
            // field_path_models = field_path.rsplit('.', 1)
            // if len(field_path_models) > 1:
            //     last_model_path, last_fname = field_path_models
            //     last_model = self.mapped(last_model_path)
            // else:
            //     last_model, last_fname = self, field_path
            // last_field = last_model._fields[last_fname]
            // # if selection -> return value, not the key
            // if last_field.type == 'selection':
            //     return ' '.join(
            //         last_field.convert_to_export(value, last_model)
            //         for value in field_value
            //     )
            // return ' '.join(str(value if value is not False and value is not None else '') for value in field_value)
            */
            return default;
        }

        public async Task<TEntity> FormatWebSearchReadResultsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object records, object offset, object limit, object count_limit) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _format_web_search_read_results(self, domain, records, offset=0, limit=None, count_limit=None):
            // if not records:
            //     return {
            //         'length': 0,
            //         'records': [],
            //     }
            // current_length = len(records) + offset
            // limit_reached = len(records) == limit
            // force_search_count = self.env.context.get('force_search_count')
            // count_limit_reached = count_limit and count_limit <= current_length
            // if limit and ((limit_reached and not count_limit_reached) or force_search_count):
            //     length = self.search_count(domain, limit=count_limit)
            // else:
            //     length = current_length
            // return {
            //     'length': length,
            //     'records': records,
            // }
            */
            return default;
        }

        [ApiModel]
        public async Task<List<Dictionary<string, object>>> FormattedReadGroupAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object having, int offset, object limit, object order) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def formatted_read_group(
            //     self,
            //     domain: DomainType,
            //     groupby: Sequence[str] = (),
            //     aggregates: Sequence[str] = (),
            //     having: DomainType = (),
            //     offset: int = 0,
            //     limit: int | None = None,
            //     order: str | None = None,
            // ) -> list[dict]:
            //     """
            //     A method similar to :meth:`_read_group` but with all the
            //     formatting needed by the webclient.
            // 
            //     :param domain: :ref:`A search domain <reference/orm/domains>`.
            //         Use an empty list to match all records.
            //     :param groupby: list of groupby descriptions by which the
            //         records will be grouped.
            // 
            //         A groupby description is either a field (then it will be
            //         grouped by that field) or a string
            //         ``'<field>:<granularity>'``.
            // 
            //         Right now, the only supported granularities are:
            // 
            //         * ``day``
            //         * ``week``
            //         * ``month``
            //         * ``quarter``
            //         * ``year``
            // 
            //         and they only make sense for date/datetime fields.
            // 
            //         Additionally integer date parts are also supported:
            // 
            //         * ``year_number``
            //         * ``quarter_number``
            //         * ``month_number``
            //         * ``iso_week_number``
            //         * ``day_of_year``
            //         * ``day_of_month``
            //         * ``day_of_week``
            //         * ``hour_number``
            //         * ``minute_number``
            //         * ``second_number``
            // 
            //     :param aggregates: list of aggregates specification. Each
            //         element is ``'<field>:<agg>'`` (aggregate field with
            //         aggregation function ``agg``). The possible aggregation
            //         functions are the ones provided by
            //         `PostgreSQL <https://www.postgresql.org/docs/current/static/functions-aggregate.html>`_,
            //         except ``count_distinct`` and ``array_agg_distinct`` with
            //         the expected meaning.
            // 
            //     :param having: A domain where the valid "fields" are the
            //         aggregates.
            // 
            //     :param offset: optional number of groups to skip
            // 
            //     :param limit: optional max number of groups to return
            // 
            //     :param order: optional ``order by`` specification, for
            //         overriding the natural sort ordering of the groups, see
            //         :meth:`~.search`.
            // 
            //     :return: list of dict such as
            //         ``[{'groupy_spec': value, ...}, ...]`` containing:
            // 
            //         * the groupby values: ``{groupby[i]: <value>}``
            //         * the aggregate values: ``{aggregates[i]: <value>}``
            //         * ``'__extra_domain'``: list of tuples specifying the group
            //           search criteria
            //         * ``'__fold'``: boolean if a fold_name is set on the comodel
            //           and read_group_expand is activated
            // 
            //     :raise AccessError: if user is not allowed to access requested
            //         information
            //     """
            //     groupby = tuple(groupby)
            //     aggregates = tuple(agg.replace(':recordset', ':array_agg') for agg in aggregates)
            // 
            //     if not order:
            //         order = ', '.join(groupby)
            // 
            //     groups = self._read_group(
            //         domain, groupby, aggregates,
            //         having=having, offset=offset, limit=limit, order=order,
            //     )
            // 
            //     # Note: group_expand is only done if the limit isn't reached and when the offset == 0
            //     # to avoid inconsistency in the web client pager. Anyway, in practice, this feature should
            //     # be used only when there are few groups (or without limit for the kanban view).
            //     if (
            //         not offset and (not limit or len(groups) < limit)
            //         and self._web_read_group_field_expand(groupby)
            //     ):
            //         # It doesn't respect the order with aggregates inside
            //         expand_groups = self._web_read_group_expand(domain, groups, groupby[0], aggregates, order)
            //         if not limit or len(expand_groups) < limit:
            //             # Ditch the result of expand_groups because the limit is reached and to avoid
            //             # returning inconsistent result inside length of web_read_group
            //             groups = expand_groups
            // 
            //     fill_temporal = self.env.context.get('fill_temporal')
            //     if groupby and (fill_temporal or isinstance(fill_temporal, dict)):
            //         if limit or offset:
            //             raise ValueError('You cannot used fill_temporal with a limit or an offset')
            //         if not isinstance(fill_temporal, dict):
            //             fill_temporal = {}
            //         # This assumes that existing data is sorted by field 'groupby_name'
            //         groups = self._web_read_group_fill_temporal(groups, groupby, aggregates, **fill_temporal)
            // 
            //     return self._web_read_group_format(groupby, aggregates, groups)
            */
            return default;
        }

        public async Task<TEntity> FormattedReadGroupWithLengthInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object offset, object limit, object order) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _formatted_read_group_with_length(self, domain, groupby, aggregates, offset=0, limit=None, order=None):
            // groups = self.formatted_read_group(
            //     domain, groupby, aggregates, offset=offset, limit=limit, order=order)
            // 
            // if not groups:
            //     length = 0
            // elif limit and len(groups) == limit:
            //     length = limit + len(self._read_group(
            //         domain,
            //         groupby=groupby,
            //         offset=limit,
            //     ))
            // else:
            //     length = len(groups) + offset
            // 
            // return groups, length
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> FormattedReadGroupingSetsAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object grouping_sets, object aggregates) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def formatted_read_grouping_sets(
            //     self,
            //     domain: DomainType,
            //     grouping_sets: Sequence[Sequence[str]],
            //     aggregates: Sequence[str] = (),
            //     *,
            //     order: str | None = None,
            // ):
            //     """
            //     A method similar to :meth:`_read_grouping_set` but with all the
            //     formatting needed by the webclient.
            //     It is a multi groupby version of formatted_read_group allowing to have
            //     aggregates for different groupby specifications in a single SQL requests.
            // 
            //     :param domain: :ref:`A search domain <reference/orm/domains>`.
            //         Use an empty list to match all records.
            //     :param grouping_sets: list of list of groupby descriptions by which the
            //         records will be grouped.
            // 
            //         A groupby description is either a field (then it will be
            //         grouped by that field) or a string
            //         ``'<field>:<granularity>'``.
            // 
            //         Right now, the only supported granularities are:
            // 
            //         * ``day``
            //         * ``week``
            //         * ``month``
            //         * ``quarter``
            //         * ``year``
            // 
            //         and they only make sense for date/datetime fields.
            // 
            //         Additionally integer date parts are also supported:
            // 
            //         * ``year_number``
            //         * ``quarter_number``
            //         * ``month_number``
            //         * ``iso_week_number``
            //         * ``day_of_year``
            //         * ``day_of_month``
            //         * ``day_of_week``
            //         * ``hour_number``
            //         * ``minute_number``
            //         * ``second_number``
            // 
            //     :param aggregates: list of aggregates specification. Each
            //         element is ``'<field>:<agg>'`` (aggregate field with
            //         aggregation function ``agg``). The possible aggregation
            //         functions are the ones provided by
            //         `PostgreSQL <https://www.postgresql.org/docs/current/static/functions-aggregate.html>`_,
            //         except ``count_distinct`` and ``array_agg_distinct`` with
            //         the expected meaning.
            // 
            //     :param order: optional ``order by`` specification, for
            //         overriding the natural sort ordering of the groups, see
            //         :meth:`~.search`.
            // 
            //     :return: list of list of dict such as
            //         ``[[{'groupy_spec': value, ...}, ...], ...]`` containing:
            // 
            //         * the groupby values: ``{groupby[i]: <value>}``
            //         * the aggregate values: ``{aggregates[i]: <value>}``
            //         * ``'__extra_domain'``: list of tuples specifying the group
            //           search criteria
            //         * ``'__fold'``: boolean if a fold_name is set on the comodel
            //           and read_group_expand is activated
            // 
            //     :raise AccessError: if user is not allowed to access requested
            //         information
            //     """
            //     grouping_sets = [tuple(groupby) for groupby in grouping_sets]
            //     aggregates = tuple(agg.replace(':recordset', ':array_agg') for agg in aggregates)
            // 
            //     if not order:
            //         order = ', '.join(unique(spec for groupby in grouping_sets for spec in groupby))
            // 
            //     groups_list = self._read_grouping_sets(
            //         domain, grouping_sets, aggregates, order=order,
            //     )
            // 
            //     for groups_index, groupby in enumerate(grouping_sets):
            //         if self._web_read_group_field_expand(groupby):
            //             groups_list[groups_index] = self._web_read_group_expand(domain, groups_list[groups_index], groupby[0], aggregates, order)
            // 
            //     for groups_index, groupby in enumerate(grouping_sets):
            //         fill_temporal = self.env.context.get('fill_temporal')
            //         if groupby and (fill_temporal or isinstance(fill_temporal, dict)):
            //             if not isinstance(fill_temporal, dict):
            //                 fill_temporal = {}
            //             # This assumes that existing data is sorted by field 'groupby_name'
            //             groups_list[groups_index] = self._web_read_group_fill_temporal(groups_list[groups_index], groupby, aggregates, **fill_temporal)
            // 
            //     return [
            //         self._web_read_group_format(groupby, aggregates, groups)
            //         for groupby, groups in zip(grouping_sets, groups_list)
            //     ]
            */
            return default;
        }

        public async Task<TEntity> GetAccessActionInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid, object force_website) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_access_action(self, access_uid=None, force_website=False):
            // """ Return an action to open the document. This method is meant to be
            // overridden in addons that want to give specific access to the document.
            // By default, it opens the formview of the document.
            // 
            // :param integer access_uid: optional access_uid being the user that
            //     accesses the document. May be different from the current user as we
            //     may compute an access for someone else.
            // :param integer force_website: force frontend redirection if available
            //     on self. Used in overrides, notably with portal / website addons.
            // """
            // self.ensure_one()
            // return self.get_formview_action(access_uid=access_uid)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetBackendRootMenuIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _get_backend_root_menu_ids(self):
            // """ Method meant to be overridden to define the root menu for the model.
            // 
            // When overriding this method, call super and then add the menu id of your
            // module so that the menu id related to the most specialized will be at the
            // end of the list.
            // """
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetBaseLangInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_model.py) ---
            // def _get_base_lang(self):
            // """ Returns the default language of the website as the base language if the record is bound to it """
            // website = ir_http.get_request_website()
            // if website:
            //     return website.default_lang_id.code
            // return super()._get_base_lang()
            */
            return default;
        }

        public async Task<TEntity> GetBaseUrlAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_model.py) ---
            // def get_base_url(self):
            // """
            // Returns the base url for a given record, given the following priority:
            // 
            // 1. If the record has a `website_id` field, we use the url from this
            //    website as base url, if set.
            // 2. If the record has a `company_id` field, we use the website from that
            //    company (if set). Note that a company doesn't really have a website,
            //    it is retrieve through some heuristic in its `website_id`'s compute.
            // 3. Use the ICP `web.base.url` (super)
            // 
            // :return: the base url for this record
            // :rtype: string
            // """
            // # Ensure zero or one record
            // if not self:
            //     return super().get_base_url()
            // self.ensure_one()
            // 
            // if self._name == 'website':
            //     # Note that website_1.company_id.website_id might not be website_1
            //     return self.domain or super().get_base_url()
            // if 'website_id' in self and self.sudo().website_id.domain:
            //     return self.sudo().website_id.domain
            // if 'company_id' in self and self.company_id.website_id.domain:
            //     return self.company_id.website_id.domain
            // return super().get_base_url()
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultActivityViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _get_default_activity_view(self):
            // """ Generates an empty activity view.
            // 
            // :returns: a activity view as an lxml document
            // :rtype: etree._Element
            // """
            // field = E.field(name=self._rec_name_fallback())
            // activity_box = E.div(field, {'t-name': "activity-box"})
            // templates = E.templates(activity_box)
            // return E.activity(templates, string=self._description)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultCalendarViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_default_calendar_view(self):
            // """ Generates a default calendar view by trying to infer
            // calendar fields from a number of pre-set attribute names
            // 
            // :returns: a calendar view
            // :rtype: etree._Element
            // """
            // def set_first_of(seq, in_, to):
            //     """Sets the first value of ``seq`` also found in ``in_`` to
            //     the ``to`` attribute of the ``view`` being closed over.
            // 
            //     Returns whether it's found a suitable value (and set it on
            //     the attribute) or not
            //     """
            //     for item in seq:
            //         if item in in_ and in_[item]._description_searchable:
            //             view.set(to, item)
            //             return True
            //     return False
            // 
            // view = E.calendar(string=self._description)
            // view.append(E.field(name=self._rec_name_fallback()))
            // 
            // if not set_first_of([self._date_name, 'date', 'date_start', 'x_date', 'x_date_start'],
            //                     self._fields, 'date_start'):
            //     raise UserError(_("Insufficient fields for Calendar View!"))
            // 
            // set_first_of(["user_id", "partner_id", "x_user_id", "x_partner_id"],
            //              self._fields, 'color')
            // 
            // if not set_first_of(["date_stop", "date_end", "x_date_stop", "x_date_end"],
            //                     self._fields, 'date_stop'):
            //     if not set_first_of(["date_delay", "planned_hours", "x_date_delay", "x_planned_hours"],
            //                         self._fields, 'date_delay'):
            //         raise UserError(_(
            //             "Insufficient fields to generate a Calendar View for %s, missing a date_stop or a date_delay",
            //             self._name
            //         ))
            // 
            // return view
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultFormViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_default_form_view(self):
            // """ Generates a default single-line form view using all fields
            // of the current model.
            // 
            // :returns: a form view as an lxml document
            // :rtype: etree._Element
            // """
            // sheet = E.sheet(string=self._description)
            // main_group = E.group()
            // left_group = E.group()
            // right_group = E.group()
            // for fname, field in self._fields.items():
            //     if fname in models.MAGIC_COLUMNS or (fname == 'display_name' and field.readonly):
            //         continue
            //     elif field.type == "binary" and not isinstance(field, fields.Image) and not field.store:
            //         continue
            //     elif field.type in ('one2many', 'many2many', 'text', 'html'):
            //         # append to sheet left and right group if needed
            //         if len(left_group) > 0:
            //             main_group.append(left_group)
            //             left_group = E.group()
            //         if len(right_group) > 0:
            //             main_group.append(right_group)
            //             right_group = E.group()
            //         if len(main_group) > 0:
            //             sheet.append(main_group)
            //             main_group = E.group()
            //         # add an oneline group for field type 'one2many', 'many2many', 'text', 'html'
            //         sheet.append(E.group(E.field(name=fname)))
            //     else:
            //         if len(left_group) > len(right_group):
            //             right_group.append(E.field(name=fname))
            //         else:
            //             left_group.append(E.field(name=fname))
            // if len(left_group) > 0:
            //     main_group.append(left_group)
            // if len(right_group) > 0:
            //     main_group.append(right_group)
            // sheet.append(main_group)
            // sheet.append(E.group(E.separator()))
            // return E.form(sheet)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultGraphViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_default_graph_view(self):
            // """ Generates a single-field graph view, based on _rec_name.
            // 
            // :returns: a graph view as an lxml document
            // :rtype: etree._Element
            // """
            // element = E.field(name=self._rec_name_fallback())
            // return E.graph(element, string=self._description)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultKanbanViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_default_kanban_view(self):
            // """ Generates a single-field kanban view, based on _rec_name.
            // 
            // :returns: a kanban view as an lxml document
            // :rtype: etree._Element
            // """
            // 
            // field = E.field(name=self._rec_name_fallback())
            // kanban_card = E.t(field, {'t-name': "card"})
            // templates = E.templates(kanban_card)
            // return E.kanban(templates, string=self._description)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultListViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_default_list_view(self):
            // """ Generates a single-field list view, based on _rec_name.
            // 
            // :returns: a list view as an lxml document
            // :rtype: etree._Element
            // """
            // element = E.field(name=self._rec_name_fallback())
            // return E.list(element, string=self._description)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultPivotViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_default_pivot_view(self):
            // """ Generates an empty pivot view.
            // 
            // :returns: a pivot view as an lxml document
            // :rtype: etree._Element
            // """
            // return E.pivot(string=self._description)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetDefaultSearchViewInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_default_search_view(self):
            // """ Generates a single-field search view, based on _rec_name.
            // 
            // :returns: a search view as an lxml document
            // :rtype: etree._Element
            // """
            // element = E.field(name=self._rec_name_fallback())
            // return E.search(element, string=self._description)
            */
            return default;
        }

        [ApiModel]
        public async Task<string> GetEmptyListHelpAsync<TEntity>(IEnumerable<TEntity> entities, string help_message) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def get_empty_list_help(self, help_message: str) -> str:
            // """ Hook method to customize the help message in empty list/kanban views.
            // 
            // By default, it returns the help received as parameter.
            // 
            // :param help_message: ir.actions.act_window help content
            // :return: help message displayed when there is no result to display
            //   in a list/kanban view (by default, it returns the action help)
            // """
            // return help_message
            */
            return default;
        }

        public async Task<TEntity> GetFieldTranslationsAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object langs) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: transifex, FILE: models.py) ---
            // def get_field_translations(self, field_name, langs=None):
            // """
            // Get model/model_term translations for records with transifex url
            // 
            // :param str field_name: field name
            // :param list langs: languages
            // 
            // :return: a 2-items tuple ``(translations, context)`` where
            // 
            //     translations:
            //         list of dicts like::
            // 
            //             [{
            //                 "lang": lang,
            //                 "source": source_term,
            //                 "value": value_term,
            //                 "module": module,
            //                 "transifexURL": transifex_url
            //             }]
            // 
            //     context:
            //         dict like::
            // 
            //             {"translation_type": "text"/"char",
            //              "translation_show_source": True/False}
            // """
            // translations, context = super().get_field_translations(field_name, langs=langs)
            // external_id = self.get_external_id().get(self.id)
            // if not external_id:
            //     return translations, context
            // 
            // module = external_id.split('.')[0]
            // if module not in self.pool._init_modules:
            //     return translations, context
            // 
            // for translation in translations:
            //     translation['module'] = module
            // self.env['transifex.translation']._update_transifex_url(translations)
            // return translations, context
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetFieldsSpecInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_info) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_fields_spec(self, view_info=None):
            // """ Return the fields specification from a view description; if not
            // given, the result of ``self.get_view()`` is used.
            // """
            // def fill_spec(node, model, fields_spec):
            //     if node.tag == 'field':
            //         field_name = node.attrib['name']
            //         field_spec = fields_spec.setdefault(field_name, {})
            //         field = model._fields.get(field_name)
            //         if field is not None:
            //             sub_fields_spec = {}
            //             if field.type == 'many2one':
            //                 sub_fields_spec.setdefault('display_name', {})
            //             if field.relational:
            //                 comodel = model.env[field.comodel_name]
            //                 for child in node:
            //                     fill_spec(child, comodel, sub_fields_spec)
            //             if field.type == 'one2many':
            //                 sub_fields_spec.pop(field.inverse_name, None)
            //             if sub_fields_spec:
            //                 field_spec.setdefault('fields', {}).update(sub_fields_spec)
            //     else:
            //         for child in node:
            //             fill_spec(child, model, fields_spec)
            // 
            // if view_info is None:
            //     view_info = self.get_view()
            // 
            // result = {}
            // fill_spec(etree.fromstring(view_info['arch']), self, result)
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetFormviewActionAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def get_formview_action(self, access_uid=None):
            // """ Return an action to open the document ``self``. This method is meant
            //     to be overridden in addons that want to give specific view ids for
            //     example.
            // 
            // An optional access_uid holds the user that will access the document
            // that could be different from the current user. """
            // view_id = self.sudo().get_formview_id(access_uid=access_uid)
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': self._name,
            //     'views': [(view_id, 'form')],
            //     'target': 'current',
            //     'res_id': self.id,
            //     'context': dict(self.env.context),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetFormviewIdAsync<TEntity>(IEnumerable<TEntity> entities, object access_uid) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def get_formview_id(self, access_uid=None):
            // """ Return a view id to open the document ``self`` with. This method is
            //     meant to be overridden in addons that want to give specific view ids
            //     for example.
            // 
            //     Optional access_uid holds the user that would access the form view
            //     id different from the current environment user.
            // """
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetHtmlLinkInternalAsync<TEntity>(IEnumerable<TEntity> entities, object title) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _get_html_link(self, title=None):
            // """Generate the record html reference for chatter use.
            // 
            // :param str title: optional reference title, the record display_name
            //     is used if not provided. The title/display_name will be escaped.
            // :returns: generated html reference,
            //     in the format <a href data-oe-model="..." data-oe-id="...">title</a>
            // :rtype: str
            // """
            // self.ensure_one()
            // return Markup("<a href=# data-oe-model='%s' data-oe-id='%s'>%s</a>") % (
            //     self._name, self.id, title or self.display_name)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetImportTemplatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import, FILE: base_import.py) ---
            // def get_import_templates(self):
            // """
            // Get the import templates label and path.
            // 
            // :return: a list(dict) containing label and template path
            //          like ``[{'label': 'foo', 'template': 'path'}]``
            // """
            // return []
            */
            return default;
        }

        public async Task<string> GetReadGroupOrderInternalAsync<TEntity>(IEnumerable<TEntity> entities, object dict_order, List<string> groupby, object aggregates) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _get_read_group_order(self, dict_order: dict[str, str], groupby: list[str], aggregates: Sequence[str]) -> str:
            // if not dict_order:
            //     return ", ".join(groupby)
            // 
            // groupby = list(groupby)
            // order_spec = []
            // for fname, direction in dict_order.items():
            //     if fname == '__count':
            //         order_spec.append(f"{fname} {direction}")
            //         continue
            //     for group in list(groupby):
            //         if fname == group or group.startswith(f"{fname}:"):
            //             groupby.remove(group)
            //             order_spec.append(f"{group} {direction}")
            //             break
            //     for agg_spec in aggregates:
            //         if agg_spec.startswith(f"{fname}:"):
            //             order_spec.append(f"{agg_spec} {direction}")
            //             break
            // 
            // return ", ".join(order_spec + groupby)
            */
            return default;
        }

        public async Task<TEntity> GetRecordsActionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_records_action(self, **kwargs):
            // """ Return an action to open given records.
            //     If there's more than one record, it will be a List, otherwise it's a Form.
            //     Given keyword arguments will overwrite default ones. """
            // match self.ids:  # `self.ids` will silently filter out new records (`NewId`s)
            //     case []:
            //         length_dependent = {'views': [(False, 'form')]}
            //     case [res_id]:
            //         length_dependent = {'views': [(False, 'form')], 'res_id': res_id}
            //     case ids:
            //         length_dependent = {
            //             'views': [(False, 'list'), (False, 'form')],
            //             'domain': [('id', 'in', ids)]
            //         }
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': self._name,
            //     'target': 'current',
            //     'context': dict(self.env.context),
            //     **length_dependent,
            //     **kwargs
            // }
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def get_view(self, view_id=None, view_type='form', **options):
            // """ get_view([view_id | view_type='form'])
            // 
            // Get the detailed composition of the requested view like model, view
            // architecture.
            // 
            // The return of the method can only depend on the requested view types,
            // access rights (views or other records), view access rules, options,
            // context lang and TYPE_view_ref (other context values cannot be used).
            // 
            // :param view_id: id of the view or None
            // :type view_id: int or None
            // :param str view_type: type of the view to return if view_id is None,
            //     one of ``'form'``, ``'list'``, ...
            // :param options: options to return additional features
            // 
            //     :param bool mobile: true if the web client is currently using the
            //         responsive mobile view (to use kanban views instead of list
            //         views for x2many fields)
            // 
            // :return: composition of the requested view (including inherited views
            //     and extensions)
            // :rtype: dict
            // :raise AttributeError:
            // 
            //     * if the inherited view has unknown position to work with other
            //       than 'before', 'after', 'inside', 'replace'
            //     * if some tag other than 'position' is found in parent view
            // """
            // self.browse().check_access('read')
            // 
            // result = dict(self._get_view_cache(view_id, view_type, **options))
            // 
            // node = etree.fromstring(result['arch'])
            // node = self.env['ir.ui.view']._postprocess_access_rights(node)
            // node = self.env['ir.ui.view']._postprocess_debug(node)
            // result['arch'] = etree.tostring(node, encoding="unicode").replace('\t', '')
            // 
            // return result
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_view_cache(self, view_id=None, view_type='form', **options):
            // """ Get the view information ready to be cached
            // 
            // The cached view includes the postprocessed view, including inherited
            // views, for all groups. The blocks restricted to groups must therefore
            // be removed after calling this method for users not part of the given
            // groups.
            // 
            // :param view_id: id of the view or None
            // :type view_id: int or None
            // :param str view_type: type of the view to return if view_id is None,
            //     one of ``'form'``, ``'list'``, ...
            // :param options: options to return additional features
            // 
            //     :param bool mobile: true if the web client is currently using the
            //         responsive mobile view (to use kanban views instead of list
            //         views for x2many fields)
            // 
            // :return: a dictionnary including
            // 
            //     - string arch: the architecture of the view (including inherited views, postprocessed, for all groups)
            //     - int id: the view id
            //     - string model: the view model
            //     - dict models: the fields of the models used in the view (including sub-views)
            // 
            // :rtype: dict
            // """
            // # Get the view arch and all other attributes describing the composition of the view
            // arch, view = self._get_view(view_id, view_type, **options)
            // 
            // # Apply post processing, groups and modifiers etc...
            // arch, models = self._get_view_postprocessed(view, arch, **options)
            // models = self._get_view_fields(view_type or view.type, models)
            // result = {
            //     'arch': arch,
            //     # TODO: only `web_studio` seems to require this. I guess this is acceptable to keep it.
            //     'id': view.id,
            //     # TODO: only `web_studio` seems to require this. But this one on the other hand should be eliminated:
            //     # you just called `get_views` for that model, so obviously the web client already knows the model.
            //     'model': self._name,
            //     # Set a frozendict and tuple for the field list to make sure the value in cache cannot be updated.
            //     'models': frozendict({model: tuple(fields) for model, fields in models.items()}),
            // }
            // 
            // return frozendict(result)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewCacheKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_view_cache_key(self, view_id=None, view_type='form', **options):
            // """ Get the key to use for caching `_get_view_cache`.
            // 
            // This method is meant to be overriden by models needing additional keys.
            // 
            // :param view_id: id of the view or None
            // :type view_id: int or None
            // :param str view_type: type of the view to return if view_id is None,
            //     one of ``'form'``, ``'list'``, ...
            // :param options: options to return additional features
            // 
            //     :param bool mobile: true if the web client is currently using the
            //         responsive mobile view (to use kanban views instead of list
            //         views for x2many fields)
            // 
            // :return: a cache key
            // :rtype: tuple
            // """
            // return (view_id, view_type, options.get('mobile'), self.env.lang) + tuple(
            //     (key, value) for key, value in self.env.context.items() if key.endswith('_view_ref')
            // )
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewFieldAttributesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: models.py) ---
            // def _get_view_field_attributes(self):
            // keys = super()._get_view_field_attributes()
            // keys.append('sanitize')
            // keys.append('sanitize_tags')
            // return keys
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_view_field_attributes(self):
            // """ Returns the field attributes required by the web client to load the views.
            // 
            // The method is meant to be overridden by modules extending web client features and requiring additional
            // field attributes.
            // 
            // :return: string list of field attribute names
            // :rtype: list
            // """
            // return [
            //     'change_default', 'context', 'currency_field', 'definition_record', 'definition_record_field', 'digits', 'domain', 'aggregator', 'groups',
            //     'help', 'model_field', 'name', 'readonly', 'related', 'relation', 'relation_field', 'required', 'searchable', 'selection', 'size',
            //     'sortable', 'store', 'string', 'translate', 'trim', 'type', 'groupable', 'falsy_value_label'
            // ]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_type, object models) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_view_fields(self, view_type, models):
            // """ Returns the field names required by the web client to load the views according to the view type.
            // 
            // The method is meant to be overridden by modules extending web client features and requiring additional
            // fields.
            // 
            // :param string view_type: type of the view
            // :param dict models: dict holding the models and fields used in the view architecture.
            // :return: dict holding the models and field required by the web client given the view type.
            // :rtype: list
            // """
            // if view_type in ('kanban', 'list', 'form'):
            //     for model, model_fields in models.items():
            //         model_fields.add('id')
            //         if 'write_date' in self.env[model]._fields:
            //             model_fields.add('write_date')
            // elif view_type == 'search':
            //     models[self._name] = list(self._fields.keys())
            // elif view_type == 'graph':
            //     models[self._name].union(fname for fname, field in self._fields.items() if field.type in ('integer', 'float'))
            // elif view_type == 'pivot':
            //     models[self._name].union(fname for fname, field in self._fields.items() if field._description_groupable(self.env))
            // return models
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // """
            // Get the model view combined architecture (the view along all its
            // inheriting views).
            // 
            // :param view_id: id of the view or None
            // :type view_id: int or None
            // :param str view_type: type of the view to return if view_id is None,
            //     one of ``'form'``, ``'list'``, ...
            // :param options: options to return additional features
            // 
            //     :param bool mobile: true if the web client is currently using the
            //         responsive mobile view (to use kanban views instead of list
            //         views for x2many fields)
            // 
            // :return: architecture of the view as an etree node, and the browse
            //     record of the view used
            // :rtype: tuple
            // :raise AttributeError: if no view exists for that model, and no method
            //     ``_get_default_<view_type>_view`` exists for the view type
            // """
            // IrUiView = self.env['ir.ui.view'].sudo()
            // 
            // # try to find a view_id if none provided
            // if not view_id:
            //     # <view_type>_view_ref in context can be used to override the default view
            //     view_ref_key = view_type + '_view_ref'
            //     view_ref = self.env.context.get(view_ref_key)
            //     if view_ref:
            //         if '.' in view_ref:
            //             module, view_ref = view_ref.split('.', 1)
            // 
            //             sql = SQL(
            //                 "SELECT res_id FROM ir_model_data WHERE model='ir.ui.view' AND module=%s AND name=%s",
            //                 module, view_ref,
            //             )
            //             if view_ref_res := self.env.execute_query(sql):
            //                 [[view_id]] = view_ref_res
            //         else:
            //             _logger.warning(
            //                 '%r requires a fully-qualified external id (got: %r for model %s). '
            //                 'Please use the complete `module.view_id` form instead.', view_ref_key, view_ref,
            //                 self._name
            //             )
            // 
            //     if not view_id:
            //         # otherwise try to find the lowest priority matching ir.ui.view
            //         view_id = IrUiView.default_view(self._name, view_type)
            // 
            // if view_id:
            //     # read the view with inherited views applied
            //     view = IrUiView.browse(view_id)
            //     arch = view._get_combined_arch()
            // else:
            //     # fallback on default views methods if no ir.ui.view could be found
            //     view = IrUiView.browse()
            //     try:
            //         arch = getattr(self, '_get_default_%s_view' % view_type)()
            //     except AttributeError:
            //         raise UserError(_("No default view of type '%s' could be found!", view_type))
            // return arch, view
            */
            return default;
        }

        public async Task<TEntity> GetViewPostprocessedInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view, object arch) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _get_view_postprocessed(self, view, arch, **options):
            // """
            // Get the post-processed view architecture and the corresponding fields.
            // 
            // This method uses the view's ``postprocess_and_fields`` function to process
            // the view architecture. It applies access control rules, field modifiers,
            // and tag-specific logic. It also automatically embeds subviews for
            // ``one2many`` and ``many2many`` fields when required, and collects all
            // fields used across the view and its subviews.
            // 
            // :param view: an ``ir.ui.view`` record
            // :param arch: the view architecture as a string
            // :param options: bool options to return additional features:
            //                 ``mobile`` (bool): true if the web client is currently using
            //                 the responsive mobile view (to use kanban views instead of
            //                 list views for x2many fields)
            // :return: a tuple containing:
            //         - the post-processed view architecture as a string
            //         - a dictionary of models and the fields used in the view
            // :rtype: tuple(str, dict)
            // """
            // return view.postprocess_and_fields(arch, model=self._name, **options)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> GetViewsAsync<TEntity>(IEnumerable<TEntity> entities, object views, object options) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def get_views(self, views, options=None):
            // """ Returns the fields_views of given views, along with the fields of
            // the current model, and optionally its filters for the given action.
            // 
            // The return of the method can only depend on the requested view types,
            // access rights (views or other records), view access rules, options,
            // context lang and TYPE_view_ref (other context values cannot be used).
            // 
            // Python expressions contained in views or representing domains (on
            // python fields) will be evaluated by the client with all the context
            // values as well as the record values it has.
            // 
            // :param views: list of [view_id, view_type]
            // :param dict options: a dict optional boolean flags, set to enable:
            // 
            //     ``toolbar``
            //         includes contextual actions when loading fields_views
            //     ``load_filters``
            //         returns the model's filters
            //     ``action_id``
            //         id of the action to get the filters, otherwise loads the global
            //         filters or the model
            // 
            // :return: dictionary with fields_views, fields and optionally filters
            // """
            // options = options or {}
            // result = {}
            // 
            // result['views'] = {
            //     v_type: self.get_view(
            //         v_id, v_type,
            //         **options
            //     )
            //     for [v_id, v_type] in views
            // }
            // 
            // models = {}
            // for view in result['views'].values():
            //     for model, model_fields in view.pop('models').items():
            //         models.setdefault(model, set()).update(model_fields)
            // 
            // result['models'] = {}
            // 
            // for model, model_fields in models.items():
            //     result['models'][model] = {"fields": self.env[model].fields_get(
            //         allfields=model_fields, attributes=self._get_view_field_attributes()
            //     )}
            // 
            // # Add related action information if asked
            // if options.get('toolbar'):
            //     for view in result['views'].values():
            //         view['toolbar'] = {}
            // 
            //     bindings = self.env['ir.actions.actions'].get_bindings(self._name)
            //     for action_type, key in (('report', 'print'), ('action', 'action')):
            //         for action in bindings.get(action_type, []):
            //             view_types = (
            //                 action['binding_view_types'].split(',')
            //                 if action.get('binding_view_types')
            //                 else result['views'].keys()
            //             )
            //             for view_type in view_types:
            //                 if view_type in result['views']:
            //                     result['views'][view_type]['toolbar'].setdefault(key, []).append(action)
            // 
            // if options.get('load_filters') and 'search' in result['views']:
            //     result['views']['search']['filters'] = self.env['ir.filters'].get_filters(
            //         self._name, options.get('action_id'), options.get('embedded_action_id'), options.get('embedded_parent_res_id')
            //     )
            // 
            // return result
            */
            return default;
        }

        public async Task<TEntity> GetWebsiteMetaAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_model.py) ---
            // def get_website_meta(self):
            // # dummy version of 'get_website_meta' above; this is a graceful fallback
            // # for models that don't inherit from 'website.seo.metadata'
            // return {}
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> HierarchyReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object specification, object parent_field, object child_field, object order) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_hierarchy, FILE: models.py) ---
            // def hierarchy_read(self, domain, specification, parent_field, child_field=None, order=None):
            // if parent_field not in specification:
            //     specification[parent_field] = {"fields": {"display_name": {}}}
            // records = self.search(domain, order=order)
            // fetch_child_ids_for_all_records = False
            // if not records:
            //     return []
            // elif len(records) == 1:
            //     domain = [(parent_field, '=', records.id), ('id', '!=', records.id)]
            //     if records[parent_field]:
            //         records += records[parent_field]
            //         domain = [('id', 'not in', records.ids), (parent_field, 'in', records.ids)]
            //     records += self.search(domain, order=order)
            // else:
            //     fetch_child_ids_for_all_records = True
            // children_ids_per_record_id = {}
            // if not child_field:
            //     children_ids_per_record_id = {
            //         record.id: child_ids
            //         for record, child_ids in self._read_group(
            //             [(parent_field, 'in', records.ids if fetch_child_ids_for_all_records else (records - records[parent_field]).ids)],
            //             (parent_field,),
            //             ('id:array_agg',),
            //             order=order
            //         )
            //     }
            // result = records.web_read(specification)
            // if children_ids_per_record_id:
            //     for record_data in result:
            //         if record_data['id'] in children_ids_per_record_id:
            //             record_data['__child_ids__'] = children_ids_per_record_id[record_data['id']]
            // return result
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MailAllowedQwebExpressionsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def mail_allowed_qweb_expressions(self):
            // # QWeb expressions allowed if we are not template editor
            // return (
            //     "object.name",
            //     "object.contact_name",
            //     "object.partner_id",
            //     "object.partner_id.name",
            //     "object.user_id",
            //     "object.user_id.name",
            //     "object.user_id.signature",
            // )
            */
            return default;
        }

        public async Task<TEntity> MailGetAliasDomainsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object default_company) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_get_alias_domains(self, default_company=False):
            // """ Return alias domain linked to each record in self. It is based
            // on the company (record's company, environment company) and fallback
            // on the first found alias domain if configuration is not correct.
            // 
            // :param <res.company> default_company: default company in case records
            //   have no company (or no company field); defaults to env.company;
            // 
            // :return: for each record ID in self, found <mail.alias.domain>
            // """
            // record_companies = self._mail_get_companies(default=(default_company or self.env.company))
            // 
            // # prepare default alias domain, fetch only if necessary
            // default_domain = (default_company or self.env.company).alias_domain_id
            // all_companies = self.env['res.company'].browse({comp.id for comp in record_companies.values()})
            // # early optimization: search only if necessary
            // if not default_domain and any(not comp.alias_domain_id for comp in all_companies):
            //     default_domain = self.env['mail.alias.domain'].search([], limit=1)
            // 
            // return {
            //     record.id: (
            //         record_companies[record.id].alias_domain_id or default_domain
            //     )
            //     for record in self
            // }
            */
            return default;
        }

        public async Task<TEntity> MailGetCompaniesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_get_companies(self, default=False):
            // """ Return company linked to each record in self.
            // 
            // :param <res.company> default: default value if no company field is found
            //   or if it holds a void value. Defaults to a void recordset;
            // 
            // :return: for each record ID in self, found <res.company>
            // """
            // default_company = default or self.env['res.company']
            // company_fname = self._mail_get_company_field()
            // return {
            //     record.id: (record[company_fname] or default_company) if company_fname else default_company
            //     for record in self
            // }
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MailGetCompanyFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_get_company_field(self):
            // return 'company_id' if 'company_id' in self else False
            */
            return default;
        }

        public async Task<TEntity> MailGetCustomerInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_get_customer(self, introspect_fields=False):
            // """ Return the 'main partner' (customer business wise) of the record.
            // Mainly a helper for future changes e.g. main customer in templates. """
            // self.ensure_one()
            // customers = self._mail_get_partners(introspect_fields=introspect_fields)[self.id]
            // return customers[0] if customers else self.env['res.partner']
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_get_message_subtypes(self):
            // return self.env['mail.message.subtype'].search([
            //     '&', ('hidden', '=', False),
            //     '|', ('res_model', '=', self._name), ('res_model', '=', False)])
            */
            return default;
        }

        public async Task<TEntity> MailGetOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_get_operation_for_mail_message_operation(self, message_operation):
            // """ Give document permission based on mail.message check permission.
            // This is used when no other checks already granted permission (e.g.
            // being notified, being author, ...). """
            // valid_operations = {'read', 'write', 'unlink', 'create'}
            // if message_operation not in valid_operations:
            //     raise ValueError('Invalid message operation, should be a valid ORM operation type')
            // mail_post_access = getattr(self, '_mail_post_access', 'write')
            // if mail_post_access not in valid_operations:
            //     raise ValueError('Invalid _mail_post_access, should be a valid ORM operation type')
            // 
            // if message_operation == 'read':
            //     check_access = 'read'
            // elif message_operation == 'create':
            //     check_access = mail_post_access
            // else:
            //     check_access = 'write'
            // return dict.fromkeys(self, check_access)
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def mail_get_partner_fields(self):
            // return self._mail_get_partner_fields()
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // """ This method returns the fields to use to find the contact to link
            // when sending emails or notifications. Having partner is not always
            // necessary but gives more flexibility to notifications management.
            // 
            // :param bool introspect_fields: if no field is found by default
            //   heuristics, introspect model to find relational fields towards
            //   res.partner model. This is used notably when partners are
            //   mandatory like in voip;
            // 
            // :return: list of valid field names that can be used to retrieve
            //   a partner (customer) on the record;
            // """
            // partner_fnames = [fname for fname in ('partner_id', 'partner_ids') if fname in self]
            // if not partner_fnames and introspect_fields:
            //     partner_fnames = [
            //         fname for fname, fvalue in self._fields.items()
            //         if fvalue.type == 'many2one' and fvalue.comodel_name == 'res.partner'
            //     ]
            // return partner_fnames
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_get_partners(self, introspect_fields=False):
            // """ Give the default partners (customers) associated to customers.
            // 
            // :param bool introspect_fields: see '_mail_get_partner_fields';
            // 
            // :return: for each record ID, a res.partner recordsets being default
            //   customers to contact;
            // """
            // partner_fields = self._mail_get_partner_fields(introspect_fields=introspect_fields)
            // all_pids = {pid for record in self for fn in partner_fields for pid in record[fn].ids}
            // records_partners = {}
            // for record in self:
            //     pids = tools.unique(pid for fn in partner_fields for pid in record[fn].ids)
            //     records_partners[record.id] = self.env['res.partner'].browse(pids).with_prefetch(all_pids)
            // return records_partners
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> MailGetPrimaryEmailFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_get_primary_email_field(self):
            // """ Check if the "_primary_email" model attribute is correctly set and
            // matches an existing field, and return it. Otherwise return None. """
            // primary_email = getattr(self, '_primary_email', None)
            // if primary_email and primary_email in self._fields:
            //     return primary_email
            // return None
            */
            return default;
        }

        public async Task<TEntity> MailGetPrimaryEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_get_primary_email(self):
            // """ Based on "_primary_email", fetch primary email. Helper to override
            // when there is no easy field access. """
            // primary_email = getattr(self, '_primary_email', None)
            // fname = primary_email if primary_email and primary_email in self._fields else None
            // return {
            //     record.id: record[fname] if fname else False for record in self
            // }
            */
            return default;
        }

        public async Task<TEntity> MailGetTimezoneInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_get_timezone(self):
            // """To be overridden to get desired timezone of the model.
            // 
            // :returns: selected timezone (e.g. 'UTC' or 'Asia/Kolkata')
            // """
            // self.ensure_one()
            // return next(filter(
            //     None,
            //     (self[tz_field] for tz_field in ('date_tz', 'tz', 'timezone') if tz_field in self)
            // ), None)
            */
            return default;
        }

        public async Task<TEntity> MailGroupByOperationForMailMessageOperationInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message_operation) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_group_by_operation_for_mail_message_operation(self, message_operation):
            // """ Globally reverse result of '_mail_get_operation_for_mail_message_operation'
            // aka return documents for a given access to check on them. """
            // document_operations = self._mail_get_operation_for_mail_message_operation(message_operation)
            // operation_documents = defaultdict(lambda: self.env[self._name])
            // for record, record_operation in document_operations.items():
            //     operation_documents[record_operation] += record
            // # force prefetch in a post-loop as recordset concatenation may lose it
            // for operation, records in operation_documents.items():
            //     records = records.with_prefetch(self.ids)
            // return operation_documents
            */
            return default;
        }

        public async Task<TEntity> MailTrackGetFieldSequenceInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_track_get_field_sequence(self, fname):
            // """ Find tracking sequence of a given field, given their name. Current
            // parameter 'tracking' should be an integer, but attributes with True
            // are still supported; old naming 'track_sequence' also. """
            // if fname not in self._fields:
            //     return 100
            // 
            // def get_field_sequence(fname):
            //     return getattr(
            //         self._fields[fname], 'tracking',
            //         getattr(self._fields[fname], 'track_sequence', True)
            //     )
            // 
            // sequence = get_field_sequence(fname)
            // if self._fields[fname].type == 'properties' and sequence is True:
            //     # default properties sequence is after the definition record
            //     parent_sequence = get_field_sequence(self._fields[fname].definition_record)
            //     return 100 if parent_sequence is True else parent_sequence
            // return 100 if sequence is True else sequence
            */
            return default;
        }

        public async Task<TEntity> MailTrackInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tracked_fields, object initial_values) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_track(self, tracked_fields, initial_values):
            // """ For a given record, fields to check (tuple column name, column info)
            // and initial values, return a valid command to create tracking values.
            // 
            // :param dict tracked_fields: fields_get of updated fields on which
            //   tracking is checked and performed;
            // :param dict initial_values: dict of initial values for each updated
            //   fields;
            // 
            // :return: a tuple (changes, tracking_value_ids) where
            //   changes: set of updated column names; contains onchange tracked fields
            //   that changed;
            //   tracking_value_ids: a list of ORM (0, 0, values) commands to create
            //   ``mail.tracking.value`` records;
            // 
            // Override this method on a specific model to implement model-specific
            // behavior. Also consider inheriting from ``mail.thread``. """
            // self.ensure_one()
            // updated = set()
            // tracking_value_ids = []
            // 
            // fields_track_info = self._mail_track_order_fields(tracked_fields)
            // for col_name, _sequence in fields_track_info:
            //     if col_name not in initial_values:
            //         continue
            //     initial_value = initial_values[col_name]
            //     new_value = (
            //         # get the properties definition with the value
            //         # (not just the dict with the value)
            //         field.convert_to_read(self[col_name], self)
            //         if (field := self._fields[col_name]).type == 'properties'
            //         else self[col_name]
            //     )
            //     if new_value == initial_value or (not new_value and not initial_value):  # because browse null != False
            //         continue
            // 
            //     if self._fields[col_name].type == "properties":
            //         definition_record_field = self._fields[col_name].definition_record
            //         if self[definition_record_field] == initial_values[definition_record_field]:
            //             # track the change only if the parent changed
            //             continue
            // 
            //         updated.add(col_name)
            //         tracking_value_ids.extend(
            //             [0, 0, self.env['mail.tracking.value']._create_tracking_values_property(
            //                 property_, col_name, tracked_fields[col_name], self,
            //             )]
            //             # Show the properties in the same order as in the definition
            //             for property_ in initial_value[::-1]
            //             if property_['type'] not in ('separator', 'html') and property_.get('value')
            //         )
            //         continue
            // 
            //     updated.add(col_name)
            //     tracking_value_ids.append(
            //         [0, 0, self.env['mail.tracking.value']._create_tracking_values(
            //             initial_value, new_value,
            //             col_name, tracked_fields[col_name],
            //             self
            //         )])
            // 
            // return updated, tracking_value_ids
            */
            return default;
        }

        public async Task<TEntity> MailTrackOrderFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object tracked_fields) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _mail_track_order_fields(self, tracked_fields):
            // """ Order tracking, based on sequence found on field definition. When
            // having several identical sequences, properties are added after,
            // and then field name is used. """
            // fields_track_info = [
            //     (col_name, self._mail_track_get_field_sequence(col_name))
            //     for col_name in tracked_fields.keys()
            // ]
            // # sorting: sequence ASC, name ASC (higher sequence -> displayed last, then
            // # order by name). Model order being id DESC (aka: first insert -> last
            // # displayed) insert should be done by descending sequence then descending
            // # name.
            // fields_track_info.sort(key=lambda item: (
            //     item[1],
            //     tracked_fields[item[0]]['type'] != 'properties',
            //     item[0],
            // ), reverse=True)
            // return fields_track_info
            */
            return default;
        }

        public async Task<TEntity> MessageAddDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _message_add_default_recipients(self):
            // """ Generic implementation for finding default recipient to mail on
            // a recordset. This method is a generic implementation available for
            // all models as we could send an email through mail templates on models
            // not inheriting from mail.thread. For that purpose we use mail methods
            // to find partners (customers) and primary emails.
            // 
            // Override this method on a specific model to implement model-specific
            // behavior. """
            // res = {}
            // customers = self._mail_get_partners()
            // primary_emails = self._mail_get_primary_email()
            // for record in self:
            //     email_cc_lst, email_to_lst = [], []
            //     # consider caller is going to filter / handle so don't filter anything
            //     recipients_all = customers.get(record.id)
            //     # to computation
            //     email_to = primary_emails[record.id]
            //     if not email_to:
            //         email_to = next(
            //             (
            //                 record[fname] for fname in [
            //                     'email_from', 'x_email_from',
            //                     'email', 'x_email',
            //                     'partner_email',
            //                     'email_normalized',
            //                 ] if fname and fname in record and record[fname]
            //             ), False
            //         )
            //     if email_to:
            //         # keep value to ease debug / trace update if cannot normalize
            //         email_to_lst = tools.mail.email_split_and_format_normalize(email_to) or [email_to]
            //     # cc computation
            //     cc_fn = next(
            //         (
            //             fname for fname in ['email_cc', 'partner_email_cc', 'x_email_cc']
            //             if fname in record and record[fname]
            //         ), False
            //     )
            //     if cc_fn:
            //         email_cc_lst = tools.mail.email_split_and_format_normalize(record[cc_fn]) or [record[cc_fn]]
            // 
            //     res[record.id] = {
            //         'email_cc_lst': email_cc_lst,
            //         'email_to_lst': email_to_lst,
            //         'partners': recipients_all,
            //     }
            // return res
            */
            return default;
        }

        public async Task<TEntity> MessageAddSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_primary_email) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _message_add_suggested_recipients(self, force_primary_email=False):
            // """ Generic implementation for finding suggested recipient to mail on
            // a recordset. """
            // suggested = {
            //     record.id: {'email_to_lst': [], 'partners': self.env['res.partner']}
            //     for record in self
            // }
            // defaults = self._message_add_default_recipients()
            // 
            // # add responsible
            // user_field = self._fields.get('user_id')
            // if user_field and user_field.type == 'many2one' and user_field.comodel_name == 'res.users':
            //     # SUPERUSER because of a read on res.users that would crash otherwise
            //     for record_su in self.sudo():
            //         suggested[record_su.id]['partners'] += record_su.user_id.partner_id
            // 
            // # add customers
            // for record_id, values in defaults.items():
            //     suggested[record_id]['partners'] |= values['partners']
            // 
            // # add email
            // for record in self:
            //     if force_primary_email:
            //         suggested[record.id]['email_to_lst'] += tools.mail.email_split_and_format_normalize(force_primary_email)
            //     else:
            //         suggested[record.id]['email_to_lst'] += defaults[record.id]['email_to_lst']
            // 
            // return suggested
            */
            return default;
        }

        public async Task<TEntity> MessageGetDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_cc, object all_tos) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _message_get_default_recipients(self, with_cc=False, all_tos=False):
            // """ Compute and filter default recipients to mail on a recordset.
            // Heuristics is to find a customer (res.partner record) holding a
            // email. Then we fallback on email fields, beginning with field optionally
            // defined using `_primary_email` attribute. Email can be prioritized
            // compared to partner if `_mail_defaults_to_email` class parameter is set.
            // 
            // :param with_cc: take into account CC-like field. By default those are
            //   not considered as valid for 'default recipients' e.g. in mailings,
            //   automated actions, ...
            // :param all_tos: DEPRECATED
            // """
            // def email_key(email):
            //     return email_normalize(email, strict=False) or email.strip()
            // 
            // res = {}
            // prioritize_email = getattr(self, '_mail_defaults_to_email', False)
            // found = self._message_add_default_recipients()
            // 
            // # ban emails: never propose odoobot nor aliases
            // all_emails = []
            // for defaults in found.values():
            //     all_emails += defaults['email_to_lst']
            //     if with_cc:
            //         all_emails += defaults['email_cc_lst']
            //     all_emails += defaults['partners'].mapped('email_normalized')
            // ban_emails = [self.env.ref('base.partner_root').email_normalized]
            // ban_emails += self.env['mail.alias.domain'].sudo()._find_aliases(
            //     [email_key(e) for e in all_emails if e and e.strip()]
            // )
            // 
            // # fetch default recipients for each record
            // for record in self:
            //     defaults = found[record.id]
            //     customers = defaults['partners']
            //     email_cc_lst = defaults['email_cc_lst'] if with_cc else []
            //     email_to_lst = defaults['email_to_lst']
            // 
            //     # pure default recipients, skip public and banned emails
            //     recipients_all = customers.filtered(lambda p: not p.is_public and (not p.email_normalized or p.email_normalized not in ban_emails))
            //     recipients = customers.filtered(lambda p: not p.is_public and p.email_normalized and p.email_normalized not in ban_emails)
            //     # filter emails, skip banned mails
            //     email_cc_lst = [e for e in email_cc_lst if e not in ban_emails]
            //     email_to_lst = [e for e in email_to_lst if e not in ban_emails]
            // 
            //     # prioritize recipients: default unless asked through '_mail_defaults_to_email', or when no email_to
            //     if not prioritize_email or not email_to_lst:
            //         # if no valid recipients nor emails, fallback on recipients even
            //         # invalid to have at least some information
            //         if recipients:
            //             partner_ids = recipients.ids
            //             email_to = ''
            //         elif recipients_all and len(recipients_all) == len(email_to_lst) and all(
            //             email in recipients_all.mapped('email') for email in email_to_lst
            //         ):
            //             # here we just have partners with invalid emails, same as email fields
            //             partner_ids = recipients_all.ids
            //             email_to = ''
            //         else:
            //             partner_ids = [] if email_to_lst else recipients_all.ids
            //             email_to = ','.join(email_to_lst)
            //     # if emails match partners, use partners to have more information
            //     elif len(email_to_lst) == len(recipients) and all(
            //         tools.email_normalize(email) in recipients.mapped('email_normalized') for email in email_to_lst
            //     ):
            //         partner_ids = recipients.ids
            //         email_to = ''
            //     else:
            //         partner_ids = []
            //         email_to = ','.join(email_to_lst)
            //     res[record.id] = {
            //         'email_cc': ','.join(email_cc_lst),
            //         'email_to': email_to,
            //         'partner_ids': partner_ids,
            //     }
            // return res
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reply_discussion, object reply_message, object no_create, object primary_email, object additional_partners) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _message_get_suggested_recipients_batch(self, reply_discussion=False, reply_message=None,
            //                                         no_create=True, primary_email=False, additional_partners=None):
            // """ Get suggested recipients, contextualized depending on discussion.
            // This method automatically filters out emails and partners linked to
            // aliases or alias domains.
            // 
            // :param bool reply_discussion: consider user replies to the discussion.
            //   Last relevant message is fetched and used to search for additional
            //   'To' and 'Cc' to propose;
            // :param <mail.message> reply_message: specific message user is replying-to.
            //   Bypasses 'reply_discussion';
            // :param bool no_create: do not create partners when emails are not linked
            //   to existing partners, see '_partner_find_from_emails';
            // :param bool primary_email: new primary_email that isn't stored inside DB;
            // :param bool additional_partners: partners that needs to be added to the suggested recipients;
            // 
            // :returns: list of dictionaries (per suggested recipient) containing:
            //     * create_values:         dict: data to populate new partner, if not found
            //     * email:                 str: email of recipient
            //     * name:                  str: name of the recipient
            //     * partner_id:            int: recipient partner id
            // """
            // def email_key(email):
            //     return email_normalize(email, strict=False) or email.strip()
            // is_mail_thread = 'message_partner_ids' in self
            // suggested_record = self._message_add_suggested_recipients(force_primary_email=primary_email)
            // 
            // # copy suggested based on records, then add those from context
            // suggested = {}
            // for record in self:
            //     suggested[record.id] = {
            //         'email_to_lst': suggested_record[record.id]['email_to_lst'].copy(),
            //         'partners': suggested_record[record.id]['partners'] + (additional_partners or self.env['res.partner']),
            //     }
            // 
            // # find last relevant message
            // messages = self.env['mail.message']
            // if reply_discussion and 'message_ids' in self:
            //     messages = self._sort_suggested_messages(self.message_ids)
            // # fetch answer-based recipients as well as author
            // if reply_message or messages:
            //     for record in self:
            //         record_msg = reply_message or next(
            //             (msg for msg in messages if msg.res_id == record.id and msg.message_type in ('comment', 'email')),
            //             self.env['mail.message']
            //         )
            //         if not record_msg:
            //             continue
            //         # direct recipients, and author if not archived / root
            //         suggested[record.id]['partners'] += (record_msg.partner_ids | record_msg.author_id).filtered(lambda p: p.active)
            //         # To and Cc emails (mainly for incoming email), and email_from if not linked to hereabove author
            //         suggested[record.id]['email_to_lst'] += [record_msg.incoming_email_to or '', record_msg.incoming_email_cc or '', record_msg.email_from or '']
            //         from_normalized = email_normalize(record_msg.email_from)
            //         if from_normalized and from_normalized != record_msg.author_id.email_normalized:
            //             suggested[record.id]['email_to_lst'].append(record_msg.email_from)
            // 
            // # make a record-based list of emails to give to '_partner_find_from_emails'
            // records_emails = {}
            // all_emails = set()
            // for record in self:
            //     email_to_lst, partners = suggested[record.id]['email_to_lst'], suggested[record.id]['partners']
            //     # organize and deduplicate partners, exclude followers, keep ordering
            //     followers = record.message_partner_ids if is_mail_thread else record.env['res.partner']
            //     # sanitize email inputs, exclude followers and aliases, add some banned emails, keep ordering, then link to partners
            //     skip_emails_normalized = (followers | partners).mapped('email_normalized') + (followers | partners).mapped('email')
            //     records_emails[record] = [
            //         e for email_input in email_to_lst for e in email_split_and_format(email_input)
            //         if e and e.strip() and email_key(e) not in skip_emails_normalized
            //     ]
            //     all_emails |= set(records_emails[record]) | set(partners.mapped('email_normalized'))
            // # ban emails: never propose odoobot nor aliases
            // ban_emails = [self.env.ref('base.partner_root').email_normalized]
            // ban_emails += self.env['mail.alias.domain'].sudo()._find_aliases(
            //     [email_key(e) for e in all_emails if e and e.strip()]
            // )
            // thread_recs = self if is_mail_thread else self.env['mail.thread']
            // records_partners = thread_recs._partner_find_from_emails(
            //     records_emails,
            //     # already computed in ban_emails, no need to re-check aliases
            //     avoid_alias=False, ban_emails=ban_emails,
            //     no_create=no_create,
            // )
            // 
            // # final filtering, and fetch model-related additional information for create values
            // emails_normalized_info = self._get_customer_information() if is_mail_thread else {}
            // suggested_recipients = {}
            // for record in self:
            //     followers = record.message_partner_ids if is_mail_thread else record.env['res.partner']
            //     partners = self.env['res.partner'].browse(tools.misc.unique(
            //         p.id for p in (suggested[record.id]['partners'] + records_partners[record.id])
            //         if (
            //             # skip followers, unless being a customer suggested by record (mostly defaults)
            //             (
            //                 p not in followers or (
            //                     p in suggested_record[record.id]['partners'] and
            //                     p.partner_share
            //             )) and
            //             p.email_normalized not in ban_emails and
            //             not p.is_public
            //         )
            //     ))
            //     existing_mails = {
            //         email_key(e)
            //         for rec in (followers | partners)
            //         for e in ([rec.email_normalized] if rec.email_normalized else []) + email_split_and_format(rec.email or '')
            //     }
            //     email_to_lst = list(tools.misc.unique(
            //         e for email_input in suggested[record.id]['email_to_lst'] for e in email_split_and_format(email_input)
            //         if (
            //             e and e.strip() and
            //             email_key(e) not in ban_emails and
            //             email_key(e) not in existing_mails
            //         )
            //     ))
            // 
            //     recipients = [{
            //         **({'display_name': partner.display_name} if not partner.name else {}),
            //         'email': partner.email_normalized,
            //         'name': partner.name,
            //         'partner_id': partner.id,
            //         'create_values': {},
            //     } for partner in partners]
            //     for email_input in email_to_lst:
            //         name, email_normalized = parse_contact_from_email(email_input)
            //         recipients.append({
            //             'email': email_normalized,
            //             'name': emails_normalized_info.get(email_normalized, {}).pop('name', False) or name,
            //             'partner_id': False,
            //             'create_values': emails_normalized_info.get(email_normalized, {}),
            //         })
            //     suggested_recipients[record.id] = recipients
            // return suggested_recipients
            */
            return default;
        }

        public async Task<TEntity> MessageGetSuggestedRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object reply_discussion, object reply_message, object no_create, object primary_email, object additional_partners) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _message_get_suggested_recipients(self, reply_discussion=False, reply_message=None,
            //                                     no_create=True, primary_email=False, additional_partners=None):
            // self.ensure_one()
            // return self._message_get_suggested_recipients_batch(
            //     reply_discussion=reply_discussion, reply_message=reply_message,
            //     no_create=no_create, primary_email=primary_email, additional_partners=additional_partners,
            // )[self.id]
            */
            return default;
        }

        public async Task<TEntity> NotifyByEmailGetHeadersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object headers) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _notify_by_email_get_headers(self, headers=None):
            // """ Generate the email headers based on record. Each header not already
            // present in 'headers' will be added in it. """
            // headers = headers or {}
            // if not self:
            //     return headers
            // self.ensure_one()
            // headers['X-Odoo-Objects'] = f"{self._name}-{self.id}"
            // if 'Return-Path' not in headers:
            //     company = self._mail_get_companies(default=self.env.company)[self.id]
            //     if company.bounce_email:
            //         headers['Return-Path'] = company.bounce_email
            // return headers
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object defaults, List<Guid> author_ids) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _notify_get_reply_to_batch(self, defaults=None, author_ids=None):
            // """ Batch-enabled version of '_notify_get_reply_to' where default and
            // author_id may be different / record. This one exist mainly for batch
            // intensive computation like composer in mass mode, where email configuration
            // is different / record due to dynamic rendering.
            // 
            // :param dict defaults: default / record ID;
            // :param dict author_ids: author ID / record ID;
            // """
            // _records = self
            // model = _records._name if _records and _records._name != 'mail.thread' else False
            // res_ids = _records.ids if _records and model else []
            // _res_ids = res_ids or [False]  # always have a default value located in False
            // _records_sudo = _records.sudo()
            // if defaults is None:
            //     defaults = dict.fromkeys(_res_ids, False)
            // if author_ids is None:
            //     author_ids = dict.fromkeys(_res_ids, False)
            // 
            // # sanity check
            // if set(defaults.keys()) != set(_res_ids):
            //     raise ValueError(f'Invalid defaults, keys {defaults.keys()} does not match recordset IDs {_res_ids}')
            // if set(author_ids.keys()) != set(_res_ids):
            //     raise ValueError(f'Invalid author_ids, keys {author_ids.keys()} does not match recordset IDs {_res_ids}')
            // 
            // # group ids per company
            // if res_ids:
            //     company_to_res_ids = defaultdict(list)
            //     record_ids_to_company = _records_sudo._mail_get_companies(default=self.env.company)
            //     for record_id, company in record_ids_to_company.items():
            //         company_to_res_ids[company].append(record_id)
            // else:
            //     company_to_res_ids = {self.env.company: _res_ids}
            //     record_ids_to_company = {_res_id: self.env.company for _res_id in _res_ids}
            // 
            // # begin with aliases (independent from company, alias_domain_id on alias wins)
            // reply_to_email = {}
            // if model and res_ids:
            //     mail_aliases = self.env['mail.alias'].sudo().search([
            //         ('alias_domain_id', '!=', False),
            //         ('alias_parent_model_id.model', '=', model),
            //         ('alias_parent_thread_id', 'in', res_ids),
            //         ('alias_name', '!=', False)
            //     ])
            //     # take only first found alias for each thread_id, to match order (1 found -> limit=1 for each res_id)
            //     for alias in mail_aliases:
            //         reply_to_email.setdefault(alias.alias_parent_thread_id, alias.alias_full_name)
            // 
            // # continue with company alias
            // left_ids = set(_res_ids) - set(reply_to_email)
            // if left_ids:
            //     for company, record_ids in company_to_res_ids.items():
            //         # left ids: use catchall defined on company alias domain
            //         if company.catchall_email:
            //             left_ids = set(record_ids) - set(reply_to_email)
            //             if left_ids:
            //                 reply_to_email.update({rec_id: company.catchall_email for rec_id in left_ids})
            // 
            // # compute name of reply-to ("Company Document" <alias@domain>)
            // reply_to_formatted = dict(defaults)
            // for res_id, record_reply_to in reply_to_email.items():
            //     reply_to_formatted[res_id] = self._notify_get_reply_to_formatted_email(
            //         record_reply_to,
            //         author_id=author_ids[res_id],
            //     )
            // 
            // return reply_to_formatted
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToFormattedEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record_email, Guid author_id) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _notify_get_reply_to_formatted_email(self, record_email, author_id=False):
            // """ Compute formatted email for reply_to and try to avoid refold issue
            // with python that splits the reply-to over multiple lines. It is due to
            // a bad management of quotes (missing quotes after refold). This appears
            // therefore only when having quotes (aka not simple names, and not when
            // being unicode encoded).
            // Another edge-case produces a linebreak (CRLF) immediately after the
            // colon character separating the header name from the header value.
            // This creates an issue in certain DKIM tech stacks that will
            // incorrectly read the reply-to value as empty and fail the verification.
            // 
            // To avoid that issue when formataddr would return more than 68 chars we
            // return a simplified name/email to try to stay under 68 chars. If not
            // possible we return only the email and skip the formataddr which causes
            // the issue in python. We do not use hacks like crop the name part as
            // encoding and quoting would be error prone.
            // """
            // length_limit = 68  # 78 - len('Reply-To: '), 78 per RFC
            // # address itself is too long : return only email and log warning
            // if len(record_email) >= length_limit:
            //     _logger.warning('Notification email address for reply-to is longer than 68 characters. '
            //         'This might create non-compliant folding in the email header in certain DKIM '
            //         'verification tech stacks. It is advised to shorten it if possible. '
            //         'Reply-To: %s ', record_email)
            //     return record_email
            // 
            // if author_id:
            //     author_name = self.env['res.partner'].browse(author_id).name
            // else:
            //     author_name = self.env.user.name
            // 
            // # try user.name alone, then company.name alone
            // formatted_email = tools.formataddr((author_name, record_email))
            // if len(formatted_email) > length_limit:
            //     formatted_email = tools.formataddr((self.env.user.name, record_email))
            // if len(formatted_email) > length_limit:
            //     formatted_email = record_email
            // return formatted_email
            */
            return default;
        }

        public async Task<TEntity> NotifyGetReplyToInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @default, Guid author_id) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _notify_get_reply_to(self, default=None, author_id=False):
            // """ Returns the preferred reply-to email address when replying to a thread
            // on documents. This method is a generic implementation available for
            // all models as we could send an email through mail templates on models
            // not inheriting from mail.thread.
            // 
            // Reply-to is formatted like '"Author Name" <reply.to@domain>".
            // Heuristic it the following:
            // 
            // * search for specific aliases as they always have priority; it is limited
            //   to aliases linked to documents (like project alias for task for example);
            // * use catchall address;
            // * use default;
            // 
            // This method can be used as a generic tools if self is a void recordset.
            // 
            // :param default: default email if no alias or catchall is found;
            // :param author_id: author to use in name part of formatted email;
            // 
            // :return: dictionary. Keys are record IDs and value is formatted
            //   like an email "Company_name Document_name <reply_to@email>"
            // """
            // return self._notify_get_reply_to_batch(
            //     defaults={res_id: default for res_id in (self.ids or [False])},
            //     author_ids={res_id: author_id for res_id in (self.ids or [False])},
            // )
            */
            return default;
        }

        public async Task<TEntity> OnchangeAsync<TEntity>(IEnumerable<TEntity> entities, Dictionary<string, object> values, List<string> field_names, Dictionary<string, object> fields_spec) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def onchange(self, values: dict, field_names: list[str], fields_spec: dict):
            // """
            // Perform an onchange on the given fields, and return the result.
            // 
            // :param values: dictionary mapping field names to values on the form view,
            //     giving the current state of modification
            // :param field_names: names of the modified fields
            // :param fields_spec: dictionary specifying the fields in the view,
            //     just like the one used by :meth:`web_read`; it is used to format
            //     the resulting values
            // 
            // When creating a record from scratch, the client should call this with an
            // empty list as ``field_names``. In that case, the method first adds
            // default values to ``values``, computes the remaining fields, applies
            // onchange methods to them, and return all the fields in ``fields_spec``.
            // 
            // The result is a dictionary with two optional keys. The key ``"value"``
            // is used to return field values that should be modified on the caller.
            // The corresponding value is a dict mapping field names to their value,
            // in the format of :meth:`web_read`, except for x2many fields, where the
            // value is a list of commands to be applied on the caller's field value.
            // 
            // The key ``"warning"`` provides a warning message to the caller. The
            // corresponding value is a dictionary like::
            // 
            //     {
            //         "title": "Be careful!",         # subject of message
            //         "message": "Blah blah blah.",   # full warning message
            //         "type": "dialog",               # how to display the warning
            //     }
            // 
            // """
            // # this is for tests using `Form`
            // self.env.flush_all()
            // 
            // env = self.env
            // first_call = not field_names
            // 
            // if not (self and self._name == 'res.users'):
            //     # res.users defines SELF_WRITEABLE_FIELDS to give access to the user
            //     # to modify themselves, we skip the check in that case because the
            //     # user does not have write permission on themselves
            //     # TODO update res.users
            //     self.check_access('write' if self else 'create')
            // 
            // if any(fname not in self._fields for fname in field_names):
            //     return {}
            // 
            // if first_call:
            //     field_names = [fname for fname in values if fname != 'id']
            //     missing_names = [fname for fname in fields_spec if fname not in values]
            //     defaults = self.default_get(missing_names)
            //     for field_name in missing_names:
            //         if field_name in defaults:
            //             values[field_name] = defaults[field_name]
            //             field_names.append(field_name)
            //         else:
            //             field = self._fields[field_name]
            //             if not field.compute or self.pool.field_depends[field]:
            //                 # don't assign computed fields without dependencies,
            //                 # otherwise they don't get computed
            //                 values[field_name] = False
            // 
            // # prefetch x2many lines: this speeds up the initial snapshot by avoiding
            // # computing fields on new records as much as possible, as that can be
            // # costly and is not necessary at all
            // self.fetch(fields_spec.keys())
            // for field_name, field_spec in fields_spec.items():
            //     field = self._fields[field_name]
            //     if field.type not in ('one2many', 'many2many'):
            //         continue
            //     sub_fields_spec = field_spec.get('fields') or {}
            //     if sub_fields_spec and values.get(field_name):
            //         # retrieve all line ids in commands
            //         line_ids = OrderedSet(self[field_name].ids)
            //         for cmd in values[field_name]:
            //             if cmd[0] in (Command.UPDATE, Command.LINK):
            //                 line_ids.add(cmd[1])
            //             elif cmd[0] == Command.SET:
            //                 line_ids.update(cmd[2])
            //         # prefetch stored fields on lines
            //         lines = self[field_name].browse(line_ids)
            //         lines.fetch(sub_fields_spec.keys())
            //         # copy the cache of lines to their corresponding new records;
            //         # this avoids computing computed stored fields on new_lines
            //         new_lines = lines.browse(map(NewId, line_ids))
            //         for field_name in sub_fields_spec:
            //             field = lines._fields[field_name]
            //             for new_line, line in zip(new_lines, lines):
            //                 line_value = field.convert_to_cache(line[field_name], new_line, validate=False)
            //                 field._update_cache(new_line, line_value)
            // 
            // # Isolate changed values, to handle inconsistent data sent from the
            // # client side: when a form view contains two one2many fields that
            // # overlap, the lines that appear in both fields may be sent with
            // # different data. Consider, for instance:
            // #
            // #   foo_ids: [line with value=1, ...]
            // #   bar_ids: [line with value=1, ...]
            // #
            // # If value=2 is set on 'line' in 'bar_ids', the client sends
            // #
            // #   foo_ids: [line with value=1, ...]
            // #   bar_ids: [line with value=2, ...]
            // #
            // # The idea is to put 'foo_ids' in cache first, so that the snapshot
            // # contains value=1 for line in 'foo_ids'. The snapshot is then updated
            // # with the value of `bar_ids`, which will contain value=2 on line.
            // #
            // # The issue also occurs with other fields. For instance, an onchange on
            // # a move line has a value for the field 'move_id' that contains the
            // # values of the move, among which the one2many that contains the line
            // # itself, with old values!
            // #
            // initial_values = dict(values)
            // changed_values = {fname: initial_values.pop(fname) for fname in field_names}
            // 
            // # do not force delegate fields to False
            // for parent_name in self._inherits.values():
            //     if not initial_values.get(parent_name, True):
            //         initial_values.pop(parent_name)
            // 
            // # create a new record with initial values
            // if self:
            //     # fill in the cache of record with the values of self
            //     cache_values = {fname: self[fname] for fname in fields_spec}
            //     record = self.new(cache_values, origin=self)
            //     # apply initial values on top of the values of self
            //     record._update_cache(initial_values)
            // else:
            //     # set changed values to null in initial_values; not setting them
            //     # triggers default_get() on the new record when creating snapshot0
            //     initial_values.update(dict.fromkeys(field_names, False))
            //     record = self.new(initial_values)
            // 
            // # make parent records match with the form values; this ensures that
            // # computed fields on parent records have all their dependencies at
            // # their expected value
            // for field_name in initial_values:
            //     field = self._fields.get(field_name)
            //     if field and field.inherited:
            //         parent_name, field_name = field.related.split('.', 1)
            //         if parent := record[parent_name]:
            //             parent._update_cache({field_name: record[field_name]})
            // 
            // # make a snapshot based on the initial values of record
            // snapshot0 = RecordSnapshot(record, fields_spec, fetch=(not first_call))
            // 
            // # store changed values in cache; also trigger recomputations based on
            // # subfields (e.g., line.a has been modified, line.b is computed stored
            // # and depends on line.a, but line.b is not in the form view)
            // record._update_cache(changed_values)
            // 
            // # update snapshot0 with changed values
            // for field_name in field_names:
            //     snapshot0.fetch(field_name)
            // 
            // # Determine which field(s) should be triggered an onchange. On the first
            // # call, 'names' only contains fields with a default. If 'self' is a new
            // # line in a one2many field, 'names' also contains the one2many's inverse
            // # field, and that field may not be in nametree.
            // todo = list(unique(itertools.chain(field_names, fields_spec))) if first_call else list(field_names)
            // done = set()
            // 
            // # mark fields to do as modified to trigger recomputations
            // protected = [
            //     field
            //     for mod_field in [self._fields[fname] for fname in field_names]
            //     for field in self.pool.field_computed.get(mod_field) or [mod_field]
            // ]
            // with self.env.protecting(protected, record):
            //     record.modified(list(self._fields) if first_call else todo)
            //     for field_name in todo:
            //         field = self._fields[field_name]
            //         if field.inherited:
            //             # modifying an inherited field should modify the parent
            //             # record accordingly; because we don't actually assign the
            //             # modified field on the record, the modification on the
            //             # parent record has to be done explicitly
            //             parent = record[field.related.split('.')[0]]
            //             parent[field_name] = record[field_name]
            // 
            // result = {'warnings': OrderedSet()}
            // 
            // # process names in order
            // while todo:
            //     # apply field-specific onchange methods
            //     for field_name in todo:
            //         record._apply_onchange_methods(field_name, result)
            //         done.add(field_name)
            // 
            //     if not env.context.get('recursive_onchanges', True):
            //         break
            // 
            //     # determine which fields to process for the next pass
            //     todo = [
            //         field_name
            //         for field_name in fields_spec
            //         if field_name not in done and snapshot0.has_changed(field_name)
            //     ]
            // 
            // # make the snapshot with the final values of record
            // snapshot1 = RecordSnapshot(record, fields_spec)
            // 
            // # determine values that have changed by comparing snapshots
            // result['value'] = snapshot1.diff(snapshot0, force=first_call)
            // 
            // # format warnings
            // warnings = result.pop('warnings')
            // if len(warnings) == 1:
            //     title, message, type_ = warnings.pop()
            //     if not type_:
            //         type_ = 'dialog'
            //     result['warning'] = dict(title=title, message=message, type=type_)
            // elif len(warnings) > 1:
            //     # concatenate warning titles and messages
            //     title = self.env._("Warnings")
            //     message = '\n\n'.join([warn_title + '\n\n' + warn_message for warn_title, warn_message, warn_type in warnings])
            //     result['warning'] = dict(title=title, message=message, type='dialog')
            // 
            // return result
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> OnchangeSpecInternalAsync<TEntity>(IEnumerable<TEntity> entities, object view_info) where TEntity : IEntity<Guid>, IBaseable
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def _onchange_spec(self, view_info=None):
            // """ Return the onchange spec from a view description; if not given, the
            //     result of ``self.get_view()`` is used.
            // """
            // result = {}
            // 
            // # for traversing the XML arch and populating result
            // def process(node, info, prefix):
            //     if node.tag == 'field':
            //         name = node.attrib['name']
            //         names = "%s.%s" % (prefix, name) if prefix else name
            //         if not result.get(names):
            //             result[names] = node.attrib.get('on_change')
            //         # traverse the subviews included in relational fields
            //         for child_view in node.xpath("./*[descendant::field]"):
            //             process(child_view, None, names)
            //     else:
            //         for child in node:
            //             process(child, info, prefix)
            // 
            // if view_info is None:
            //     view_info = self.get_view()
            // process(etree.fromstring(view_info['arch']), view_info, '')
            // return result
            #endif
            return default;
        }

        public async Task<TEntity> OpenGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _open_groups(
            //     self,
            //     *,
            //     records_opening_info: list[dict[str, Any]],
            //     groups: list[dict],
            //     domain: Domain,
            //     groupby: list[str],
            //     aggregates: list[str],
            //     dict_order: dict[str, str],
            //     auto_unfold: bool,
            //     opening_info: list[dict] | None,
            //     unfold_read_default_limit: int | None,
            //     parent_opening_info: list[dict] | None,
            //     parent_group_domain: Domain,
            // ):
            //     max_number_opened_group = self.env.context.get('max_number_opened_groups') or MAX_NUMBER_OPENED_GROUPS
            // 
            //     parent_opening_info_dict = {
            //         info_opening['value']: info_opening
            //         for info_opening in parent_opening_info or ()
            //     }
            //     groupby_spec = groupby[0]
            //     field = self._fields[groupby_spec.split(':')[0].split('.')[0]]
            //     nb_opened_group = 0
            // 
            //     last_level = len(groupby) == 1
            //     if not last_level:
            //         read_group_order = self._get_read_group_order(dict_order, [groupby[1]], aggregates)
            // 
            //     for group in groups:
            //         # Remove __fold information, no need for the webclient,
            //         # the groups is unfold if __groups/__records exists
            //         fold_info = '__fold' in group
            //         fold = group.pop('__fold', False)
            // 
            //         groupby_value = group[groupby_spec]
            //         # For relational/date/datetime/property tags field
            //         raw_groupby_value = groupby_value[0] if isinstance(groupby_value, tuple) else groupby_value
            // 
            //         limit = unfold_read_default_limit
            //         offset = 0
            //         progressbar_domain = subgroup_opening_info = None
            //         if opening_info and raw_groupby_value in parent_opening_info_dict:
            //             group_info = parent_opening_info_dict[raw_groupby_value]
            //             if group_info['folded']:
            //                 continue
            //             limit = group_info['limit']
            //             offset = group_info['offset']
            //             progressbar_domain = group_info.get('progressbar_domain')
            //             subgroup_opening_info = group_info.get('groups')
            // 
            //         elif (
            //             # Auto Fold/unfold
            //             (not auto_unfold and not fold_info)
            //             or nb_opened_group >= max_number_opened_group
            //             or fold
            //             # Empty recordset is folded by default
            //             or (field.relational and not group[groupby_spec])
            //         ):
            //             continue
            // 
            //         # => Open group
            //         nb_opened_group += 1
            //         if last_level:  # Open records
            //             records_domain = parent_group_domain & Domain(group['__extra_domain'])
            // 
            //             # when we click on a part of the progress bar, we force a domain
            //             # for a specific open column/group, we want to keep this for the next reload
            //             if progressbar_domain:
            //                 records_domain &= Domain(progressbar_domain)
            // 
            //             # TODO also for groups ?
            //             # Simulate the same behavior than in relational_model.js
            //             # If the offset is bigger than the number of record (a record has been deleted)
            //             # reset the offset to 0 and add the information to the group to update the webclient too
            //             if offset and offset >= group['__count']:
            //                 group['__offset'] = offset = 0
            // 
            //             records_opening_info.append({
            //                 'domain': records_domain,
            //                 'limit': limit,
            //                 'offset': offset,
            //                 'group': group,
            //             })
            // 
            //         else:  # Open subgroups
            // 
            //             subgroup_domain = parent_group_domain
            //             if group['__extra_domain']:
            //                 subgroup_domain &= Domain(group['__extra_domain'])
            //             # That's not optimal but hard to batch because of limit/offset.
            //             # Moreover it isn't critical since it is when user opens group manually, then
            //             # the number of it should be small.
            //             subgroups, length = self._formatted_read_group_with_length(
            //                 domain=(subgroup_domain & domain),
            //                 groupby=[groupby[1]], aggregates=aggregates,
            //                 offset=offset, limit=limit, order=read_group_order)
            // 
            //             group['__groups'] = {
            //                 'groups': subgroups,
            //                 'length': length,
            //             }
            //             self._open_groups(
            //                 records_opening_info=records_opening_info,
            //                 groups=subgroups,
            //                 domain=domain,
            //                 groupby=groupby[1:],
            //                 aggregates=aggregates,
            //                 dict_order=dict_order,
            //                 auto_unfold=False,
            //                 opening_info=opening_info,
            //                 unfold_read_default_limit=unfold_read_default_limit,
            //                 parent_opening_info=subgroup_opening_info,
            //                 parent_group_domain=subgroup_domain,
            //             )
            */
            return default;
        }

        public async Task<TEntity> PhoneFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object fname, object number, object country, object force_format, object raise_exception) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: models.py) ---
            // def _phone_format(self, fname=False, number=False, country=False, force_format='E164', raise_exception=False):
            // """ Format and return number. This number can be found using a field
            // (in which case self should be a singleton recordet), or directly given
            // if the formatting itself is what matter. Field name can be found
            // automatically using :meth:`_phone_get_number_fields`.
            // 
            // :param str fname: if number is not given, fname indicates the field to
            //   use to find the number; otherwise use :meth:`_phone_get_number_fields`.;
            // :param str number: number to format (in which case fields-based computation
            //   is skipped);
            // :param <res.country> country: country used for formatting number; otherwise
            //   it is fetched based on record, using :meth:`_phone_get_number_fields`.;
            // :param str force_format: stringified version of format globals; should be
            //   one of ``'E164'``, ``'INTERNATIONAL'``, ``'NATIONAL'`` or ``'RFC3966'``;
            // :param bool raise_exception: raise if formatting is not possible (notably
            //   wrong formatting, invalid country information, ...). Otherwise ``False``
            //   is returned;
            // 
            // :return: formatted number. If formatting is not possible ``False`` is
            //   returned.
            // :rtype: str | Literal[False]
            // """
            // if not number:
            //     # if no number is given, having a singletong recordset is mandatory to
            //     # always have a number as input
            //     self.ensure_one()
            //     fnames = self._phone_get_number_fields() if not fname else [fname]
            //     number = next((self[fname] for fname in fnames if fname in self and self[fname]), False)
            // if not number:
            //     return False
            // 
            // # fetch country info only if self is a singleton recordset allowing to
            // # effectively try to find a country
            // if not country and self:
            //     self.ensure_one()
            //     country = self._phone_get_country().get(self.id)
            // if not country:
            //     country = self.env.company.country_id
            // 
            // return self._phone_format_number(
            //     number,
            //     country=country, force_format=force_format,
            //     raise_exception=raise_exception,
            // )
            */
            return default;
        }

        public async Task<TEntity> PhoneFormatNumberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object number, object country, object force_format, object raise_exception) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: models.py) ---
            // def _phone_format_number(self, number, country, force_format='E164', raise_exception=False):
            // """ Format and return number according to the asked format. This is
            // mainly a small helper around :func:`phone_validation.phone_format`."""
            // if not number:
            //     return False
            // 
            // try:
            //     number = phone_validation.phone_format(
            //         number,
            //         country.code,
            //         country.phone_code,
            //         force_format=force_format,
            //         raise_exception=True,  # do not get original number returned
            //     )
            // except exceptions.UserError:
            //     if raise_exception:
            //         raise
            //     number = False
            // return number
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PhoneGetCountryFieldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: models.py) ---
            // def _phone_get_country_field(self):
            // if 'country_id' in self:
            //     return 'country_id'
            // return False
            */
            return default;
        }

        public async Task<TEntity> PhoneGetCountryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: models.py) ---
            // def _phone_get_country(self):
            // """Get a country likely to match the phone of the record.
            // 
            // By default we get it from:
            // 
            // - The country field of the target record (self) based on
            //   :meth:`_phone_get_country_field`;
            // - The country of any mail partner (e.g. ``self.partner_ids[2].phone``),
            //   considering we are going to contact the customer(s) of the record.
            //   Done using generic :meth:`_mail_get_partner_fields` method allowing
            //   to find record customers;
            // """
            // country_by_record = {}
            // record_country_fname = self._phone_get_country_field()
            // for record in self:
            //     if record_country_fname and (record_country := record[record_country_fname]):
            //         country_by_record[record.id] = record_country
            //         continue
            //     for partner_field in self.env[self._name]._mail_get_partner_fields():
            //         partner_records = record[partner_field]
            //         if countries := partner_records.country_id:
            //             country_by_record[record.id] = countries[0]
            // return country_by_record
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> PhoneGetNumberFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: phone_validation, FILE: models.py) ---
            // def _phone_get_number_fields(self):
            // """ This method returns the fields to use to find the number to use to
            // send an SMS on a record. """
            // return [
            //     number_fname for number_fname in ('mobile', 'phone') if number_fname in self
            // ]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ReadProgressBarAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object group_by, object progress_bar) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def read_progress_bar(self, domain, group_by, progress_bar):
            // """
            // Gets the data needed for all the kanban column progressbars.
            // These are fetched alongside read_group operation.
            // 
            // :param domain: the domain used in the kanban view to filter records
            // :param group_by: the name of the field used to group records into
            //     kanban columns
            // :param progress_bar: the ``<progressbar/>`` declaration
            //     attributes (field, colors, sum)
            // :return: a dictionnary mapping group_by values to dictionnaries mapping
            //     progress bar field values to the related number of records
            // """
            // def adapt(value):
            //     if isinstance(value, BaseModel):
            //         return value.id
            //     return value
            // 
            // result = defaultdict(lambda: dict.fromkeys(progress_bar['colors'], 0))
            // 
            // for main_group, field_value, count in self._read_group(
            //     domain, [group_by, progress_bar['field']], ['__count'],
            // ):
            //     if field_value in progress_bar['colors']:
            //         group_by_value = str(adapt(main_group))
            //         result[group_by_value][field_value] += count
            // 
            // return result
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelDomainImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name, object domain, object set_count, object limit) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _search_panel_domain_image(self, field_name, domain, set_count=False, limit=False):
            // """
            // Return the values in the image of the provided domain by field_name.
            // 
            // :param domain: domain whose image is returned
            // :param field_name: the name of a field (type many2one or selection)
            // :param set_count: whether to set the key '__count' in image values. Default is False.
            // :param limit: integer, maximal number of values to fetch. Default is False.
            // :return: a dict of the form:
            //     ::
            // 
            //         {
            //             id: { 'id': id, 'display_name': display_name, ('__count': c,) },
            //             ...
            //         }
            // """
            // field = self._fields[field_name]
            // if field.type in ('many2one', 'many2many'):
            //     def group_id_name(value):
            //         return value
            // 
            // else:
            //     # field type is selection: see doc above
            //     desc = self.fields_get([field_name], ['selection'])[field_name]
            //     field_name_selection = dict(desc['selection'])
            // 
            //     def group_id_name(value):
            //         return value, field_name_selection[value]
            // 
            // domain = AND([
            //     domain,
            //     [(field_name, '!=', False)],
            // ])
            // groups = self.with_context(read_group_expand=True).formatted_read_group(
            //     domain, [field_name], ['__count'], limit=limit)
            // 
            // domain_image = {}
            // for group in groups:
            //     id_, display_name = group_id_name(group[field_name])
            //     values = {
            //         'id': id_,
            //         'display_name': display_name,
            //     }
            //     if set_count:
            //         values['__count'] = group['__count']
            //     domain_image[id_] = values
            // 
            // return domain_image
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelFieldImageInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _search_panel_field_image(self, field_name, **kwargs):
            // """
            // Return the values in the image of the provided domain by field_name.
            // 
            // :param field_name: the name of a field (type ``many2one`` or
            //     ``selection``)
            // :param kwargs: Keyword arguments:
            // 
            //     * ``model_domain``: domain whose image is returned
            //     * ``extra_domain``: extra domain to use when counting records
            //       associated with field values
            //     * ``enable_counters``: whether to set the key ``'__count'`` in
            //       image values
            //     * ``only_counters``: whether to retrieve information on the
            //       ``model_domain`` image or only counts based on
            //       ``model_domain`` and ``extra_domain``. In the later case,
            //       the counts are set whatever is enable_counters.
            //     * ``limit``: maximal number of values to fetch
            //     * ``set_limit``: whether to use the provided limit (if any)
            // :return: a dict of the form:
            //     ::
            // 
            //         {
            //             id: { 'id': id, 'display_name': display_name, ('__count': c,) },
            //             ...
            //         }
            // """
            // 
            // enable_counters = kwargs.get('enable_counters')
            // only_counters = kwargs.get('only_counters')
            // extra_domain = Domain(kwargs.get('extra_domain', []))
            // no_extra = extra_domain.is_true()
            // model_domain = Domain(kwargs.get('model_domain', []))
            // count_domain = model_domain & extra_domain
            // 
            // limit = kwargs.get('limit')
            // set_limit = kwargs.get('set_limit')
            // 
            // if only_counters:
            //     return self._search_panel_domain_image(field_name, count_domain, True)
            // 
            // model_domain_image = self._search_panel_domain_image(field_name, model_domain,
            //                     enable_counters and no_extra,
            //                     set_limit and limit,
            //                 )
            // if enable_counters and not no_extra:
            //     count_domain_image = self._search_panel_domain_image(field_name, count_domain, True)
            //     for id, values in model_domain_image.items():
            //         element = count_domain_image.get(id)
            //         values['__count'] = element['__count'] if element else 0
            // 
            // return model_domain_image
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelGlobalCountersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object values_range, object parent_name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _search_panel_global_counters(self, values_range, parent_name):
            // """
            // Modify in place values_range to transform the (local) counts
            // into global counts (local count + children local counts)
            // in case a parent field parent_name has been set on the range values.
            // Note that we save the initial (local) counts into an auxiliary dict
            // before they could be changed in the for loop below.
            // 
            // :param values_range: dict of the form:
            //     ::
            // 
            //         {
            //             id: { 'id': id, '__count': c, parent_name: parent_id, ... }
            //             ...
            //         }
            // :param parent_name: string, indicates which key determines the parent
            // """
            // local_counters = lazymapping(lambda id: values_range[id]['__count'])
            // 
            // for id in values_range:
            //     values = values_range[id]
            //     # here count is the initial value = local count set on values
            //     count = local_counters[id]
            //     if count:
            //         parent_id = values[parent_name]
            //         while parent_id:
            //             values = values_range[parent_id]
            //             local_counters[parent_id]
            //             values['__count'] += count
            //             parent_id = values[parent_name]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelSanitizedParentHierarchyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object records, object parent_name, object ids) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _search_panel_sanitized_parent_hierarchy(self, records, parent_name, ids):
            // """
            // Filter the provided list of records to ensure the following properties of
            // the resulting sublist:
            // 
            // 1) it is closed for the parent relation
            // 2) every record in it is an ancestor of a record with id in ids
            //    (if ``ids = records.ids``, that condition is automatically
            //    satisfied)
            // 3) it is maximal among other sublists with properties 1 and 2.
            // 
            // :param list[dict] records: the list of records to filter, the
            //     records must have the form::
            // 
            //         { 'id': id, parent_name: False or (id, display_name),... }
            // 
            // :param str parent_name: indicates which key determines the parent
            // :param list[int] ids: list of record ids
            // :return: the sublist of records with the above properties
            // """
            // def get_parent_id(record):
            //     value = record[parent_name]
            //     return value and value[0]
            // 
            // allowed_records = { record['id']: record for record in records }
            // records_to_keep = {}
            // for id in ids:
            //     record_id = id
            //     ancestor_chain = {}
            //     chain_is_fully_included = True
            //     while chain_is_fully_included and record_id:
            //         known_status = records_to_keep.get(record_id)
            //         if known_status is not None:
            //             # the record and its known ancestors have already been considered
            //             chain_is_fully_included = known_status
            //             break
            //         record = allowed_records.get(record_id)
            //         if record:
            //             ancestor_chain[record_id] = record
            //             record_id = get_parent_id(record)
            //         else:
            //             chain_is_fully_included = False
            // 
            //     for r_id in ancestor_chain:
            //         records_to_keep[r_id] = chain_is_fully_included
            // 
            // # we keep initial order
            // return [rec for rec in records if records_to_keep.get(rec['id'])]
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelSelectMultiRangeAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def search_panel_select_multi_range(self, field_name, **kwargs):
            // """
            // Return possible values of the field field_name (case select="multi"),
            // possibly with counters and groups.
            // 
            // :param field_name: the name of a filter field;
            //     possible types are many2one, many2many, selection.
            // 
            // :param kwargs: additional features
            // 
            //     :param category_domain: domain generated by categories.
            //         Default is ``[]``.
            //     :param comodel_domain: domain of field values (if relational)
            //             (this parameter is used in :meth:`_search_panel_range`).
            //             Default is ``[]``.
            //     :param enable_counters: whether to count records by value.
            //         Default is ``False``.
            //     :param expand: whether to return the full range of field values in
            //         ``comodel_domain`` or only the field image values.
            //         Default is ``False``.
            //     :param filter_domain: domain generated by filters.
            //         Default is ``[]``.
            //     :param group_by: extra field to read on comodel, to group comodel
            //         records.
            //     :param group_domain: dict, one domain for each activated group for
            //         the group_by (if any). Those domains are used to fech accurate
            //         counters for values in each group.
            //         Default is ``[]`` (many2one case) or ``None``.
            //     :param limit: integer, maximal number of values to fetch.
            //         Default is ``None`` (no limit).
            //     :param search_domain: base domain of search. Default is ``[]``.
            // 
            // :return: ::
            // 
            //         {
            //             'values': a list of possible values, each being a dict with keys
            //                 'id' (value),
            //                 'name' (value label),
            //                 '__count' (how many records with that value),
            //                 'group_id' (value of group), set if a group_by has been provided,
            //                 'group_name' (label of group), set if a group_by has been provided
            //         }
            // 
            //     or an object with an error message when limit is defined and reached.
            // """
            // field = self._fields[field_name]
            // supported_types = ['many2one', 'many2many', 'selection']
            // if field.type not in supported_types:
            //     raise UserError(self.env._(
            //         'Only types %(supported_types)s are supported for filter (found type %(field_type)s)',
            //         supported_types=supported_types, field_type=field.type))
            // 
            // model_domain = kwargs.get('search_domain', [])
            // extra_domain = AND([
            //     kwargs.get('category_domain', []),
            //     kwargs.get('filter_domain', []),
            // ])
            // 
            // if field.type == 'selection':
            //     return {
            //         'values': self._search_panel_selection_range(field_name, model_domain=model_domain,
            //                         extra_domain=extra_domain, **kwargs
            //                     )
            //     }
            // 
            // Comodel = self.env.get(field.comodel_name).with_context(hierarchical_naming=False)
            // field_names = ['display_name']
            // group_by = kwargs.get('group_by')
            // limit = kwargs.get('limit')
            // if group_by:
            //     group_by_field = Comodel._fields[group_by]
            // 
            //     field_names.append(group_by)
            // 
            //     if group_by_field.type == 'many2one':
            //         def group_id_name(value):
            //             return value or (False, self.env._("Not Set"))
            // 
            //     elif group_by_field.type == 'selection':
            //         desc = Comodel.fields_get([group_by])[group_by]
            //         group_by_selection = dict(desc['selection'])
            //         group_by_selection[False] = self.env._("Not Set")
            // 
            //         def group_id_name(value):
            //             return value, group_by_selection[value]
            // 
            //     else:
            //         def group_id_name(value):
            //             return (value, value) if value else (False, self.env._("Not Set"))
            // 
            // comodel_domain = kwargs.get('comodel_domain', [])
            // enable_counters = kwargs.get('enable_counters')
            // expand = kwargs.get('expand')
            // 
            // if field.type == 'many2many':
            //     if not expand:
            //         domain_image = self._search_panel_domain_image(field_name, model_domain, limit=limit)
            //         image_element_ids = list(domain_image.keys())
            //         comodel_domain = AND([
            //             comodel_domain,
            //             [('id', 'in', image_element_ids)],
            //         ])
            // 
            //     comodel_records = Comodel.search_read(comodel_domain, field_names, limit=limit)
            //     if limit and len(comodel_records) == limit:
            //         return {'error_msg': str(SEARCH_PANEL_ERROR_MESSAGE)}
            // 
            //     group_domain = kwargs.get('group_domain')
            //     field_range = []
            //     for record in comodel_records:
            //         record_id = record['id']
            //         values= {
            //             'id': record_id,
            //             'display_name': record['display_name'],
            //         }
            //         if group_by:
            //             group_id, group_name = group_id_name(record[group_by])
            //             values['group_id'] = group_id
            //             values['group_name'] = group_name
            // 
            //         if enable_counters:
            //             search_domain = AND([
            //                     model_domain,
            //                     [(field_name, 'in', record_id)],
            //                 ])
            //             local_extra_domain = extra_domain
            //             if group_by and group_domain:
            //                 local_extra_domain = AND([
            //                     local_extra_domain,
            //                     group_domain.get(json.dumps(group_id), []),
            //                 ])
            //             search_count_domain = AND([
            //                 search_domain,
            //                 local_extra_domain
            //             ])
            //             values['__count'] = self.search_count(search_count_domain)
            //         field_range.append(values)
            // 
            //     return { 'values': field_range, }
            // 
            // if field.type == 'many2one':
            //     if enable_counters or not expand:
            //         extra_domain = AND([
            //             extra_domain,
            //             kwargs.get('group_domain', []),
            //         ])
            //         domain_image = self._search_panel_field_image(field_name,
            //                             model_domain=model_domain, extra_domain=extra_domain,
            //                             only_counters=expand,
            //                             set_limit=limit and not (expand or group_by or comodel_domain), **kwargs
            //                         )
            // 
            //     if not (expand or group_by or comodel_domain):
            //         values = list(domain_image.values())
            //         if limit and len(values) == limit:
            //             return {'error_msg': str(SEARCH_PANEL_ERROR_MESSAGE)}
            //         return {'values': values, }
            // 
            //     if not expand:
            //         image_element_ids = list(domain_image.keys())
            //         comodel_domain = AND([
            //             comodel_domain,
            //             [('id', 'in', image_element_ids)],
            //         ])
            //     comodel_records = Comodel.search_read(comodel_domain, field_names, limit=limit)
            //     if limit and len(comodel_records) == limit:
            //         return {'error_msg': str(SEARCH_PANEL_ERROR_MESSAGE)}
            // 
            //     field_range = []
            //     for record in comodel_records:
            //         record_id = record['id']
            //         values= {
            //             'id': record_id,
            //             'display_name': record['display_name'],
            //         }
            // 
            //         if group_by:
            //             group_id, group_name = group_id_name(record[group_by])
            //             values['group_id'] = group_id
            //             values['group_name'] = group_name
            // 
            //         if enable_counters:
            //             image_element = domain_image.get(record_id)
            //             values['__count'] = image_element['__count'] if image_element else 0
            // 
            //         field_range.append(values)
            // 
            //     return { 'values': field_range, }
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelSelectRangeAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def search_panel_select_range(self, field_name, **kwargs):
            // """
            // Return possible values of the field field_name (case select="one"),
            // possibly with counters, and the parent field (if any and required)
            // used to hierarchize them.
            // 
            // :param field_name: the name of a field; of type many2one or selection.
            // :param kwargs: additional features
            // 
            //     * category_domain: domain generated by categories.
            //       Default is ``[]``.
            //     * comodel_domain: domain of field values (if relational).
            //       Default is ``[]``.
            //     * enable_counters: whether to count records by value.
            //       Default is ``False``.
            //     * expand: whether to return the full range of field values in
            //       comodel_domain or only the field image values (possibly
            //       filtered and/or completed with parents if hierarchize is set).
            //       Default is ``False``.
            //     * filter_domain: domain generated by filters.
            //       Default is ``[]``.
            //     * hierarchize: determines if the categories must be displayed
            //       hierarchically (if possible). If set to true and
            //       ``_parent_name`` is set on the comodel field, the information
            //       necessary for the hierarchization will be returned.
            //       Default is ``True``.
            //     * limit: integer, maximal number of values to fetch.
            //       Default is ``None`` (no limit).
            //     * search_domain: base domain of search. Default is ``[]``.
            // 
            // :return: ::
            // 
            //         {
            //             'parent_field': parent field on the comodel of field, or False
            //             'values': array of dictionaries containing some info on the records
            //                       available on the comodel of the field 'field_name'.
            //                       The display name, the __count (how many records with that value)
            //                       and possibly parent_field are fetched.
            //         }
            // 
            //     or an object with an error message when limit is defined and is reached.
            // """
            // field = self._fields[field_name]
            // supported_types = ['many2one', 'selection']
            // if field.type not in supported_types:
            //     types = dict(self.env["ir.model.fields"]._fields["ttype"]._description_selection(self.env))
            //     raise UserError(self.env._(
            //         'Only types %(supported_types)s are supported for category (found type %(field_type)s)',
            //         supported_types=", ".join(types[t] for t in supported_types),
            //         field_type=types[field.type],
            //     ))
            // 
            // model_domain = kwargs.get('search_domain', [])
            // extra_domain = AND([
            //     kwargs.get('category_domain', []),
            //     kwargs.get('filter_domain', []),
            // ])
            // 
            // if field.type == 'selection':
            //     return {
            //         'parent_field': False,
            //         'values': self._search_panel_selection_range(field_name, model_domain=model_domain,
            //                         extra_domain=extra_domain, **kwargs
            //                     ),
            //     }
            // 
            // Comodel = self.env[field.comodel_name].with_context(hierarchical_naming=False)
            // field_names = ['display_name']
            // hierarchize = kwargs.get('hierarchize', True)
            // parent_name = False
            // if hierarchize and Comodel._parent_name in Comodel._fields:
            //     parent_name = Comodel._parent_name
            //     field_names.append(parent_name)
            // 
            //     def get_parent_id(record):
            //         value = record[parent_name]
            //         return value and value[0]
            // else:
            //     hierarchize = False
            // 
            // comodel_domain = kwargs.get('comodel_domain', [])
            // enable_counters = kwargs.get('enable_counters')
            // expand = kwargs.get('expand')
            // limit = kwargs.get('limit')
            // 
            // if enable_counters or not expand:
            //     domain_image = self._search_panel_field_image(field_name,
            //         model_domain=model_domain, extra_domain=extra_domain,
            //         only_counters=expand,
            //         set_limit= limit and not (expand or hierarchize or comodel_domain), **kwargs
            //     )
            // 
            // if not (expand or hierarchize or comodel_domain):
            //     values = list(domain_image.values())
            //     if limit and len(values) == limit:
            //         return {'error_msg': str(SEARCH_PANEL_ERROR_MESSAGE)}
            //     return {
            //         'parent_field': parent_name,
            //         'values': values,
            //     }
            // 
            // if not expand:
            //     image_element_ids = list(domain_image.keys())
            //     if hierarchize:
            //         condition = [('id', 'parent_of', image_element_ids)]
            //     else:
            //         condition = [('id', 'in', image_element_ids)]
            //     comodel_domain = AND([comodel_domain, condition])
            // comodel_records = Comodel.search_read(comodel_domain, field_names, limit=limit)
            // 
            // if hierarchize:
            //     ids = [rec['id'] for rec in comodel_records] if expand else image_element_ids
            //     comodel_records = self._search_panel_sanitized_parent_hierarchy(comodel_records, parent_name, ids)
            // 
            // if limit and len(comodel_records) == limit:
            //     return {'error_msg': str(SEARCH_PANEL_ERROR_MESSAGE)}
            // 
            // field_range = {}
            // for record in comodel_records:
            //     record_id = record['id']
            //     values = {
            //         'id': record_id,
            //         'display_name': record['display_name'],
            //     }
            //     if hierarchize:
            //         values[parent_name] = get_parent_id(record)
            //     if enable_counters:
            //         image_element = domain_image.get(record_id)
            //         values['__count'] = image_element['__count'] if image_element else 0
            //     field_range[record_id] = values
            // 
            // if hierarchize and enable_counters:
            //     self._search_panel_global_counters(field_range, parent_name)
            // 
            // return {
            //     'parent_field': parent_name,
            //     'values': list(field_range.values()),
            // }
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> SearchPanelSelectionRangeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field_name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _search_panel_selection_range(self, field_name, **kwargs):
            // """
            // Return the values of a field of type selection possibly enriched
            // with counts of associated records in domain.
            // 
            // :param field_name: the name of a field of type selection
            // :param kwargs:
            // 
            //     * model_domain: domain used to determine the field image
            //       values and counts. Default is an empty list.
            //     * enable_counters: whether to set the key ``'__count'`` on
            //       values returned. Default is ``False``.
            //     * expand: whether to return the full range of values for
            //       the selection field or only the field image values. Default
            //       is ``False``.
            // :return: a list of dicts of the form
            //     ::
            // 
            //         { 'id': id, 'display_name': display_name, ('__count': c,) }
            // 
            //     with key ``'__count'`` set if ``enable_counters`` is
            //     ``True``.
            // """
            // 
            // 
            // enable_counters = kwargs.get('enable_counters')
            // expand = kwargs.get('expand')
            // 
            // if enable_counters or not expand:
            //     domain_image = self._search_panel_field_image(field_name, only_counters=expand, **kwargs)
            // 
            // if not expand:
            //     return list(domain_image.values())
            // 
            // selection = self.fields_get([field_name])[field_name]['selection']
            // 
            // selection_range = []
            // for value, label in selection:
            //     values = {
            //         'id': value,
            //         'display_name': label,
            //     }
            //     if enable_counters:
            //         image_element = domain_image.get(value)
            //         values['__count'] = image_element['__count'] if image_element else 0
            //     selection_range.append(values)
            // 
            // return selection_range
            */
            return default;
        }

        public async Task<TEntity> SmsGetRecipientsInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_field, object partner_fallback) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms, FILE: models.py) ---
            // def _sms_get_recipients_info(self, force_field=False, partner_fallback=True):
            // """ Get SMS recipient information on current record set. This method
            // checks for numbers and sanitation in order to centralize computation.
            // 
            // Example of use cases
            // 
            //   * click on a field -> number is actually forced from field, find customer
            //     linked to record, force its number to field or fallback on customer fields;
            //   * contact -> find numbers from all possible phone fields on record, find
            //     customer, force its number to found field number or fallback on customer fields;
            // 
            // :param force_field: either give a specific field to find phone number, either
            //     generic heuristic is used to find one based on :meth:`_phone_get_number_fields`;
            // :param partner_fallback: if no value found in the record, check its customer
            //     values based on :meth:`_mail_get_partners`;
            // 
            // :rtype: dict[int, dict[str, Any]]
            // :return: a dictionnary with the following structure:
            // 
            //     .. code-block:: python
            // 
            //         {
            //             record.id: {
            //                 # a res.partner recordset that is the customer (void or
            //                 # singleton) linked to the recipient.
            //                 # See _mail_get_partners;
            //                 'partner': ...,
            // 
            //                 # sanitized number to use (coming from record's field
            //                 # or partner's phone fields). Set to False if number
            //                 # impossible to parse and format;
            //                 'sanitized': ...,
            // 
            //                 # original number before sanitation;
            //                 'number': ...,
            // 
            //                 # whether the number comes from the customer phone
            //                 # fields. If False it means number comes from the
            //                 # record itself, even if linked to a customer;
            //                 'partner_store': ...,
            // 
            //                 # field in which the number has been found (generally
            //                 # mobile or phone, see _phone_get_number_fields);
            //                 'field_store': ...,
            //             }
            //             for record in self
            //         }
            // 
            // """
            // result = dict.fromkeys(self.ids, False)
            // tocheck_fields = [force_field] if force_field else self._phone_get_number_fields()
            // for record in self:
            //     all_numbers = [record[fname] for fname in tocheck_fields if fname in record]
            //     all_partners = record._mail_get_partners()[record.id]
            // 
            //     valid_number, fname = False, False
            //     for fname in [f for f in tocheck_fields if f in record]:
            //         valid_number = record._phone_format(fname=fname)
            //         if valid_number:
            //             break
            // 
            //     if valid_number:
            //         result[record.id] = {
            //             'partner': all_partners[0] if all_partners else self.env['res.partner'],
            //             'sanitized': valid_number,
            //             'number': record[fname],
            //             'partner_store': False,
            //             'field_store': fname,
            //         }
            //     elif all_partners and partner_fallback:
            //         partner = self.env['res.partner']
            //         for partner in all_partners:
            //             for fname in self.env['res.partner']._phone_get_number_fields():
            //                 valid_number = partner._phone_format(fname=fname)
            //                 if valid_number:
            //                     break
            // 
            //         if not valid_number:
            //             fname = 'phone'
            // 
            //         result[record.id] = {
            //             'partner': partner,
            //             'sanitized': valid_number if valid_number else False,
            //             'number': partner[fname],
            //             'partner_store': True,
            //             'field_store': fname,
            //         }
            //     else:
            //         # did not find any sanitized number -> take first set value as fallback;
            //         # if none, just assign False to the first available number field
            //         value, fname = next(
            //             ((value, fname) for value, fname in zip(all_numbers, tocheck_fields) if value),
            //             (False, tocheck_fields[0] if tocheck_fields else False)
            //         )
            //         result[record.id] = {
            //             'partner': self.env['res.partner'],
            //             'sanitized': False,
            //             'number': value,
            //             'partner_store': False,
            //             'field_store': fname
            //         }
            // return result
            */
            return default;
        }

        public async Task<TEntity> SortSuggestedMessagesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object messages) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _sort_suggested_messages(self, messages):
            // """ Sort messages for suggestion. Keep only discussions: incoming email
            // or user comments, with subtype being 'comment' to exclude notes,
            // logs, trackings, ... then take the most recent one. If no matching
            // message is found, no suggested message is given, as other messages
            // should not trigger a 'reply-all' behavior.
            // 
            // Dedicated method to ease override and csutom behavior for filtering
            // and sorting messages in '_message_get_suggested_recipients' """
            // subtype_ids = self._creation_subtype().ids if hasattr(self, '_creation_subtype') else []
            // subtype_ids.append(self.env['ir.model.data']._xmlid_to_res_id('mail.mt_comment'))
            // return messages.filtered(
            //     lambda msg: (
            //         msg.message_type in ('email', 'comment') and
            //         msg.subtype_id.id in subtype_ids
            //     )
            // ).sorted(lambda msg: (msg.date, msg.id), reverse=True)
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def unlink(self):
            // # Override unlink to delete records activities through (res_model, res_id)
            // record_ids = self.ids if (not self._abstract and not self._transient) else []
            // result = super().unlink()
            // if record_ids and (
            //     # during uninstallation of module mail, the search below will crash
            //     not self.env.context.get(MODULE_UNINSTALL_FLAG) or (
            //         column_exists(self.env.cr, 'mail_activity', 'res_model')
            //         and column_exists(self.env.cr, 'mail_activity', 'res_id')
            //     )
            // ):
            //     self.env['mail.activity'].with_context(active_test=False).sudo().search(
            //         [('res_model', '=', self._name), ('res_id', 'in', record_ids)]
            //     ).unlink()
            // return result
            */
            return default;
        }

        public async Task<TEntity> ValidFieldParameterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object field, object name) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_sparse_field, FILE: models.py) ---
            // def _valid_field_parameter(self, field, name):
            // return name == 'sparse' or super()._valid_field_parameter(field, name)
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def _valid_field_parameter(self, field, name):
            // # allow tracking on abstract models; see also 'mail.thread'
            // return (
            //     name == 'tracking' and self._abstract
            //     or super()._valid_field_parameter(field, name)
            // )
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> ViewHeaderGetAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_ui_view.py) ---
            // def view_header_get(self, view_id, view_type):
            // return False
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WebNameSearchAsync<TEntity>(IEnumerable<TEntity> entities, object name, object specification, object domain, object @operator, object limit) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def web_name_search(self, name, specification, domain=None, operator='ilike', limit=100):
            // id_name_pairs = self.name_search(name, domain, operator, limit)
            // if len(specification) == 1 and 'display_name' in specification:
            //     return [{'id': id, 'display_name': name, '__formatted_display_name': self.with_context(formatted_display_name=True).browse(id).display_name} for id, name in id_name_pairs]
            // records = self.browse([id for id, _ in id_name_pairs])
            // return records.web_read(specification)
            */
            return default;
        }

        public async Task<TEntity> WebOverrideTranslationsAsync<TEntity>(IEnumerable<TEntity> entities, object values) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def web_override_translations(self, values):
            // """
            // This method is used to override all the modal translations of the given fields
            // with the provided value for each field.
            // 
            // :param values: dictionary of the translations to apply for each field name
            //     ex: ``{ "field_name": "new_value" }``
            // """
            // self.ensure_one()
            // for field_name in values:
            //     field = self._fields[field_name]
            //     if field.translate is True:
            //         translations = {lang: False for lang, _ in self.env['res.lang'].get_installed()}
            //         translations['en_US'] = values[field_name]
            //         translations[self.env.lang or 'en_US'] = values[field_name]
            //         self.update_field_translations(field_name, translations)
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebReadAsync<TEntity>(IEnumerable<TEntity> entities, object specification) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def web_read(self, specification: dict[str, dict]) -> list[dict]:
            // fields_to_read = list(specification) or ['id']
            // 
            // if fields_to_read == ['id']:
            //     # if we request to read only the ids, we have them already so we can build the return dictionaries immediately
            //     # this also avoid a call to read on the co-model that might have different access rules
            //     values_list = [{'id': id_} for id_ in self._ids]
            // else:
            //     values_list: list[dict] = self.read(fields_to_read, load=None)
            // 
            // if not values_list:
            //     return values_list
            // 
            // def cleanup(vals: dict) -> dict:
            //     """ Fixup vals['id'] of a new record. """
            //     if not vals['id']:
            //         vals['id'] = vals['id'].origin or False
            //     return vals
            // 
            // for field_name, field_spec in specification.items():
            //     field = self._fields.get(field_name)
            //     if field is None:
            //         continue
            // 
            //     if field.type == 'many2one':
            //         if 'fields' not in field_spec:
            //             for values in values_list:
            //                 if isinstance(values[field_name], NewId):
            //                     values[field_name] = values[field_name].origin
            //             continue
            // 
            //         co_records = self[field_name]
            //         if 'context' in field_spec:
            //             co_records = co_records.with_context(**field_spec['context'])
            // 
            //         extra_fields = dict(field_spec['fields'])
            //         extra_fields.pop('display_name', None)
            // 
            //         many2one_data = {
            //             vals['id']: cleanup(vals)
            //             for vals in co_records.web_read(extra_fields)
            //         }
            // 
            //         if 'display_name' in field_spec['fields']:
            //             for rec in co_records.sudo():
            //                 many2one_data[rec.id]['display_name'] = rec.display_name
            // 
            //         for values in values_list:
            //             if values[field_name] is False:
            //                 continue
            //             vals = many2one_data[values[field_name]]
            //             values[field_name] = vals['id'] and vals
            // 
            //     elif field.type in ('one2many', 'many2many'):
            //         if not field_spec:
            //             continue
            // 
            //         co_records = self[field_name]
            // 
            //         if 'order' in field_spec and field_spec['order']:
            //             co_records = co_records.with_context(active_test=False).search(
            //                 [('id', 'in', co_records.ids)], order=field_spec['order'],
            //             ).with_context(co_records.env.context)  # Reapply previous context
            //             order_key = {
            //                 co_record.id: index
            //                 for index, co_record in enumerate(co_records)
            //             }
            //             for values in values_list:
            //                 # filter out inaccessible corecords in case of "cache pollution"
            //                 values[field_name] = [id_ for id_ in values[field_name] if id_ in order_key]
            //                 values[field_name] = sorted(values[field_name], key=order_key.__getitem__)
            // 
            //         if 'context' in field_spec:
            //             co_records = co_records.with_context(**field_spec['context'])
            // 
            //         if 'fields' in field_spec:
            //             if field_spec.get('limit') is not None:
            //                 limit = field_spec['limit']
            //                 ids_to_read = OrderedSet(
            //                     id_
            //                     for values in values_list
            //                     for id_ in values[field_name][:limit]
            //                 )
            //                 co_records = co_records.browse(ids_to_read)
            // 
            //             x2many_data = {
            //                 vals['id']: vals
            //                 for vals in co_records.web_read(field_spec['fields'])
            //             }
            // 
            //             for values in values_list:
            //                 values[field_name] = [x2many_data.get(id_) or {'id': id_} for id_ in values[field_name]]
            // 
            //     elif field.type in ('reference', 'many2one_reference'):
            //         if not field_spec:
            //             continue
            // 
            //         values_by_id = {
            //             vals['id']: vals
            //             for vals in values_list
            //         }
            //         for record in self:
            //             if not record[field_name]:
            //                 continue
            // 
            //             record_values = values_by_id[record.id]
            // 
            //             if field.type == 'reference':
            //                 co_record = record[field_name]
            //             else:  # field.type == 'many2one_reference'
            //                 if not record[field.model_field]:
            //                     record_values[field_name] = False
            //                     continue
            //                 co_record = self.env[record[field.model_field]].browse(record[field_name])
            // 
            //             if 'context' in field_spec:
            //                 co_record = co_record.with_context(**field_spec['context'])
            // 
            //             if 'fields' in field_spec:
            //                 try:
            //                     reference_read = co_record.web_read(field_spec['fields'])
            //                 except AccessError:
            //                     reference_read = [{'id': co_record.id, 'display_name': self.env._("You don't have access to this record")}]
            //                 if any(fname != 'id' for fname in field_spec['fields']):
            //                     # we can infer that if we can read fields for the co-record, it exists
            //                     co_record_exists = bool(reference_read)
            //                 else:
            //                     co_record_exists = co_record.exists()
            //             else:
            //                 # If there are no fields to read (field_spec.get('fields') --> None) and we web_read ids, it will
            //                 # not actually read the records so we do not know if they exist.
            //                 # This ensures the record actually exists
            //                 co_record_exists = co_record.exists()
            // 
            //             if not co_record_exists:
            //                 record_values[field_name] = False
            //                 if field.type == 'many2one_reference':
            //                     record_values[field.model_field] = False
            //                 continue
            // 
            //             if 'fields' in field_spec:
            //                 record_values[field_name] = reference_read[0]
            //                 if field.type == 'reference':
            //                     record_values[field_name]['id'] = {
            //                         'id': co_record.id,
            //                         'model': co_record._name
            //                     }
            // 
            //     elif field.type == "properties":
            //         if not field_spec or 'fields' not in field_spec:
            //             continue
            // 
            //         for values in values_list:
            //             old_values = values[field_name]
            //             next_values = []
            //             for property_name, spec in field_spec['fields'].items():
            //                 property_ = next((p for p in old_values if p.get('name') == property_name), None)
            //                 if not property_:
            //                     continue
            // 
            //                 if property_.get('type') == 'many2one' and property_.get('comodel') and property_.get('value'):
            //                     record = self.env[property_['comodel']].with_context(field_spec.get('context')).browse(property_['value'][0])
            //                     property_['value'] = record.web_read(spec['fields']) if 'fields' in spec else property_['value']
            // 
            //                 if property_.get('type') == 'many2many' and property_.get('comodel') and property_.get('value'):
            //                     records = self.env[property_['comodel']].with_context(field_spec.get('context')).browse([r[0] for r in property_['value']])
            //                     property_['value'] = records.web_read(spec['fields']) if 'fields' in spec else property_['value']
            // 
            //                 next_values.append(property_)
            // 
            //             values[field_name] = next_values
            // 
            // return values_list
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WebReadGroupAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groupby, object aggregates, object limit, int offset, object order) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def web_read_group(
            //     self,
            //     domain: DomainType,
            //     groupby: list[str] | tuple[str, ...],
            //     aggregates: Sequence[str] = (),
            //     limit: int | None = None,
            //     offset: int = 0,
            //     order: str | None = None,
            //     *,
            //     auto_unfold: bool = False,
            //     opening_info: list[dict] | None = None,
            //     unfold_read_specification: dict[str, dict] | None = None,
            //     unfold_read_default_limit: int | None = 80,  # Limit of record by unfolded group by default
            //     groupby_read_specification: dict[str, dict] | None = None,
            // ) -> dict[str, int | list]:
            //     """
            //     Serves as the primary method for loading grouped data in list and kanban views.
            // 
            //     This method wraps :meth:`~.formatted_read_group` to return both the grouped
            //     data and the total number of groups matching the search domain. It also
            //     conditionally opens (unfolds) groups based on the `auto_unfold` parameter
            //     and the `__fold` key returned by :meth:`~.formatted_read_group`.
            // 
            //     A group is considered "open" if it contains a `__records` or `__groups` key.
            //     - `__records`: The result of a :meth:`~.web_search_read` call for the group.
            //     - `__groups`: The results of subgroupings.
            // 
            //     :param domain: :ref:`A search domain <reference/orm/domains>`.
            //     :param groupby: A list of groupby specification at each level, see :meth:`~.formatted_read_group`.
            //     :param aggregates: A list of aggregate specifications. see :meth:`~.formatted_read_group`
            //     :param limit: The maximum number of top-level groups to return. see :meth:`~.formatted_read_group`
            //     :param offset: The offset for the top-level groups. see :meth:`~.formatted_read_group`
            //     :param order: A sort string, as used in :meth:`~.search`
            //     :param auto_unfold: If `True`, automatically unfolds the first 10 groups according to their
            //         `__fold` key, if present; otherwise, it is unfolded by default.
            //         This is typically `True` for kanban views and `False` for list views.
            //     :param opening_info: The state of currently opened groups, used for reloading.
            //       ::
            // 
            //         opening_info = [{
            //             "value": raw_value_groupby,
            //             "folded": True or False,
            //             ["offset": int,]  # present if unfolded
            //             ["limit": int,]  # present if unfolded
            //             ["progressbar_domain": progressbar_domain,]  # present if unfolded, e.g., when clicking on a progress bar section
            //             ["groups": <opening_info>,]  # present if unfolded
            //         }]
            // 
            //     :param unfold_read_specification: The read specification for :meth:`~.web_read` when unfolding a group.
            //     :param unfold_read_default_limit: The default record limit to apply when unfolding a group.
            //     :param groupby_read_specification: The :meth:`~.web_read` specification for reading the records
            //         that are being grouped on. This is mainly for list views with <groupby> leaves.
            //         {<groupby_spec>: <read_specification>}
            // 
            //     :return: A dictionary with the following structure:
            //       ::
            // 
            //         {
            //             'groups': <groups>,
            //             'length': <total_group_count>,
            //         }
            // 
            //         Where <groups> is the result of :meth:`~.formatted_read_group`, but with an
            //         added `__groups` key for subgroups or a `__records` key for the result of :meth:`~.web_read`
            //         for records within the group.
            // 
            //     """
            //     assert isinstance(groupby, (list, tuple)) and groupby
            // 
            //     aggregates = list(aggregates)
            //     if '__count' not in aggregates:  # Used for computing length of sublevel groups
            //         aggregates.append('__count')
            //     domain = Domain(domain).optimize(self)
            // 
            //     # dict to help creating order compatible with _read_group and for search
            //     dict_order: dict[str, str] = {}  # {fname_and_property: "<direction> <nulls>"}
            //     for order_part in (order.split(',') if order else ()):
            //         order_match = regex_order.match(order_part)
            //         if not order_match:
            //             raise ValueError(f"Invalid order {order!r} for web_read_group()")
            //         fname_and_property = order_match['field']
            //         if order_match['property']:
            //             fname_and_property = f"{fname_and_property}.{order_match['property']}"
            //         direction = (order_match['direction'] or 'ASC').upper()
            //         if order_match['nulls']:
            //             direction = f"{direction} {order_match['nulls'].upper()}"
            //         dict_order[fname_and_property] = direction
            // 
            //     # First level of grouping
            //     first_groupby = [groupby[0]]
            //     read_group_order = self._get_read_group_order(dict_order, first_groupby, aggregates)
            //     groups, length = self._formatted_read_group_with_length(
            //         domain, first_groupby, aggregates, offset=offset, limit=limit, order=read_group_order,
            //     )
            // 
            //     # Open sublevel of grouping (list) and get all subgroup to open into records.
            //     # [{limit: int, offset: int, domain: domain, group: <group>}]
            //     records_opening_info: list[dict[str, Any]] = []
            // 
            //     self._open_groups(
            //         records_opening_info=records_opening_info,
            //         groups=groups,
            //         domain=domain,
            //         groupby=groupby,
            //         aggregates=aggregates,
            //         dict_order=dict_order,
            //         auto_unfold=auto_unfold,
            //         opening_info=opening_info,
            //         unfold_read_default_limit=unfold_read_default_limit,
            //         parent_opening_info=opening_info,
            //         parent_group_domain=Domain.TRUE,
            //     )
            // 
            //     # Open last level of grouping, meaning read records of groups
            //     if records_opening_info:
            // 
            //         order_specs = [
            //             f"{fname} {direction}"
            //             for fname, direction in dict_order.items()
            //             # Remove order that are already unique for each group,
            //             # that may avoid a left join and simplify the order (not apply if granularity)
            //             if fname not in groupby
            //             if fname != '__count'
            //         ]
            //         for order_str in self._order.split(','):
            //             fname = order_str.strip().split(" ", 1)[0]
            //             if fname not in dict_order and fname not in groupby:
            //                 order_specs.append(order_str)
            // 
            //         order_searches = ', '.join(order_specs)
            //         recordset_groups = [
            //             self.search(
            //                 domain & sub_search['domain'],
            //                 order=order_searches,
            //                 limit=sub_search['limit'],
            //                 offset=sub_search['offset'],
            //             ) if sub_search['group']['__count'] else self.browse()
            //             for sub_search in records_opening_info
            //         ]
            // 
            //         all_records = self.browse().union(*recordset_groups)
            //         record_mapped = dict(zip(
            //             all_records._ids,
            //             all_records.web_read(unfold_read_specification),
            //             strict=True,
            //         ))
            // 
            //         for opening, records in zip(records_opening_info, recordset_groups, strict=True):
            //             opening['group']['__records'] = [record_mapped[record_id] for record_id in records._ids]
            // 
            //     # Read additional info of grouped field record and add it to specific groups
            //     self._add_groupby_values(groupby_read_specification, groupby, groups)
            // 
            //     return {
            //         'groups': groups,
            //         'length': length,
            //     }
            */
            return default;
        }

        public async Task<TEntity> WebReadGroupExpandInternalAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object groups, object groupby_spec, object aggregates, object order) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _web_read_group_expand(self, domain, groups, groupby_spec, aggregates, order):
            // """ Expand the result of _read_group for the webclient to show empty groups
            // for some view types (e.g. empty column for kanban view). See `Field.group_expand` attribute.
            // """
            // field_name = groupby_spec.split('.')[0].split(':')[0]
            // field = self._fields[field_name]
            // 
            // # determine all groups that should be returned
            // values = [group_value for group_value, *__ in groups if group_value]
            // 
            // # field.group_expand is a callable or the name of a method, that returns
            // # the groups that we want to display for this field, in the form of a
            // # recordset or a list of values (depending on the type of the field).
            // # This is useful to implement kanban views for instance, where some
            // # columns should be displayed even if they don't contain any record.
            // if field.relational:
            //     # groups is a recordset; determine order on groups's model
            //     values = self.env[field.comodel_name].browse(value.id for value in values)
            //     expand_values = field.determine_group_expand(self, values, domain)
            //     all_record_ids = tuple(unique(expand_values._ids + values._ids))
            // else:
            //     # groups is a list of values
            //     expand_values = field.determine_group_expand(self, values, domain)
            // 
            // if (groupby_spec + ' desc') in order.lower():
            //     expand_values = reversed(expand_values)
            // 
            // empty_aggregates = tuple(self._read_group_empty_value(spec) for spec in aggregates)
            // result = dict.fromkeys(expand_values, empty_aggregates)
            // result.update({
            //     group_value: aggregate_values
            //     for group_value, *aggregate_values in groups
            // })
            // 
            // if field.relational:
            //     return [
            //         (value.with_prefetch(all_record_ids), *aggregate_values)
            //         for value, aggregate_values in result.items()
            //     ]
            // return [(value, *aggregate_values) for value, aggregate_values in result.items()]
            */
            return default;
        }

        public async Task<TEntity> WebReadGroupFieldExpandInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groupby) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _web_read_group_field_expand(self, groupby):
            // """ Return the field that should be expand """
            // if (
            //     len(groupby) == 1
            //     and self.env.context.get('read_group_expand')
            //     and '.' not in groupby[0]
            //     and (field := self._fields[groupby[0].split(':')[0]])
            //     and field.group_expand
            // ):
            //     return field
            // return None
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WebReadGroupFillTemporalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groups, object groupby, object aggregates, object fill_from, object fill_to, object min_groups) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _web_read_group_fill_temporal(self, groups, groupby, aggregates, fill_from=False, fill_to=False, min_groups=False):
            // """Helper method for filling date/datetime 'holes' in a result for the first groupby.
            // 
            // We are in a use case where data are grouped by a date field (typically
            // months but it could be any other interval) and displayed in a chart.
            // 
            // Assume we group records by month, and we only have data for June,
            // September and December. By default, plotting the result gives something
            // like::
            // 
            //                                         ___
            //                               ___      |   |
            //                              |   | ___ |   |
            //                              |___||___||___|
            //                               Jun  Sep  Dec
            // 
            // The problem is that December data immediately follow September data,
            // which is misleading for the user. Adding explicit zeroes for missing
            // data gives something like::
            // 
            //                                                    ___
            //                      ___                          |   |
            //                     |   |           ___           |   |
            //                     |___| ___  ___ |___| ___  ___ |___|
            //                      Jun  Jul  Aug  Sep  Oct  Nov  Dec
            // 
            // To customize this output, the context key "fill_temporal" can be used
            // under its dictionary format, which has 3 attributes : fill_from,
            // fill_to, min_groups (see params of this function)
            // 
            // Fill between bounds:
            // Using either `fill_from` and/or `fill_to` attributes, we can further
            // specify that at least a certain date range should be returned as
            // contiguous groups. Any group outside those bounds will not be removed,
            // but the filling will only occur between the specified bounds. When not
            // specified, existing groups will be used as bounds, if applicable.
            // By specifying such bounds, we can get empty groups before/after any
            // group with data.
            // 
            // If we want to fill groups only between August (fill_from)
            // and October (fill_to)::
            // 
            //                                              ___
            //                          ___                |   |
            //                         |   |      ___      |   |
            //                         |___| ___ |___| ___ |___|
            //                          Jun  Aug  Sep  Oct  Dec
            // 
            // We still get June and December. To filter them out, we should match
            // `fill_from` and `fill_to` with the domain e.g. ``['&',
            // ('date_field', '>=', 'YYYY-08-01'), ('date_field', '<', 'YYYY-11-01')]``::
            // 
            //                                  ___
            //                             ___ |___| ___
            //                             Aug  Sep  Oct
            // 
            // Minimal filling amount:
            // Using `min_groups`, we can specify that we want at least that amount of
            // contiguous groups. This amount is guaranteed to be provided from
            // `fill_from` if specified, or from the lowest existing group otherwise.
            // This amount is not restricted by `fill_to`. If there is an existing
            // group before `fill_from`, `fill_from` is still used as the starting
            // group for min_groups, because the filling does not apply on that
            // existing group. If neither `fill_from` nor `fill_to` is specified, and
            // there is no existing group, no group will be returned.
            // 
            // If we set min_groups = 4::
            // 
            //                                  ___
            //                             ___ |___| ___ ___
            //                             Aug  Sep  Oct Nov
            // 
            // :param list groups: groups returned by _read_group
            // :param list groupby: list of fields being grouped on
            // :param list aggregates: list of "<key_name>:<aggregate specification>"
            // :param str fill_from: (inclusive) string representation of a
            //     date/datetime, start bound of the fill_temporal range
            //     formats: date -> %Y-%m-%d, datetime -> %Y-%m-%d %H:%M:%S
            // :param str fill_to: (inclusive) string representation of a
            //     date/datetime, end bound of the fill_temporal range
            //     formats: date -> %Y-%m-%d, datetime -> %Y-%m-%d %H:%M:%S
            // :param int min_groups: minimal amount of required groups for the
            //     fill_temporal range (should be >= 1)
            // :rtype: list
            // :return: list
            // """
            // groupby_name = groupby[0]
            // field_name = groupby_name.split(':')[0].split(".")[0]
            // field = self._fields[field_name]
            // if field.type not in ('date', 'datetime') and not (field.type == 'properties' and ':' in groupby_name):
            //     return groups
            // 
            // granularity = groupby_name.split(':')[1]
            // days_offset = 0
            // if granularity == 'week':
            //     # _read_group week groups are dependent on the
            //     # locale, so filled groups should be too to avoid overlaps.
            //     first_week_day = int(get_lang(self.env).week_start) - 1
            //     days_offset = first_week_day and 7 - first_week_day
            // tz = False
            // if field.type == 'datetime' and self.env.context.get('tz') in pytz.all_timezones_set:
            //     tz = pytz.timezone(self.env.context['tz'])
            // 
            // # existing non null date(time)
            // existing = sorted(group_value for group in groups if (group_value := group[0])) or [None]
            // # assumption: existing data is sorted by field 'groupby_name'
            // existing_from, existing_to = existing[0], existing[-1]
            // if fill_from:
            //     fill_from = Date.to_date(fill_from)
            //     fill_from = date_utils.start_of(fill_from, granularity) - datetime.timedelta(days=days_offset)
            //     if tz:
            //         fill_from = tz.localize(fill_from)
            // elif existing_from:
            //     fill_from = existing_from
            // if fill_to:
            //     fill_to = Date.to_date(fill_to)
            //     fill_to = date_utils.start_of(fill_to, granularity) - datetime.timedelta(days=days_offset)
            //     if tz:
            //         fill_to = tz.localize(fill_to)
            // elif existing_to:
            //     fill_to = existing_to
            // 
            // if not fill_to and fill_from:
            //     fill_to = fill_from
            // elif not fill_from and fill_to:
            //     fill_from = fill_to
            // if not fill_from and not fill_to:
            //     return groups
            // 
            // interval = READ_GROUP_TIME_GRANULARITY[granularity]
            // if min_groups > 0:
            //     fill_to = max(fill_to, fill_from + (min_groups - 1) * interval)
            // 
            // if fill_from > fill_to:
            //     return groups
            // 
            // empty_item = tuple(self._read_group_empty_value(spec) for spec in groupby[1:] + aggregates)
            // required_dates = list(date_utils.date_range(fill_from, fill_to, interval))
            // 
            // if existing[0] is None:
            //     existing = list(required_dates)
            // else:
            //     existing = sorted(set().union(existing, required_dates))
            // 
            // groups_mapped = defaultdict(list)
            // for group in groups:
            //     groups_mapped[group[0]].append(group)
            // 
            // result = []
            // for dt in existing:
            //     if dt in groups_mapped:
            //         result.extend(groups_mapped[dt])
            //     else:
            //         result.append((dt, *empty_item))
            // 
            // if False in groups_mapped:
            //     result.extend(groups_mapped[False])
            // 
            // return result
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebReadGroupFormatInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groupby, object aggregates, List<object> groups) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _web_read_group_format(
            //     self,
            //     groupby: tuple[str, ...],
            //     aggregates: tuple[str, ...],
            //     groups: list[tuple],
            // ) -> list[dict]:
            //     """ Format raw value of _read_group for the webclient.
            //     See formatted_read_group return value. """
            //     result = [{'__extra_domains': []} for __ in groups]
            //     if not groups:
            //         return result
            //     column_iterator = zip(*groups)
            // 
            //     for groupby_spec, values in zip(groupby, column_iterator):
            //         formatter = self._web_read_group_groupby_formatter(groupby_spec, values)
            //         for value, dict_group in zip(values, result, strict=True):
            //             dict_group[groupby_spec], additional_domain = formatter(value)
            //             dict_group['__extra_domains'].append(additional_domain)
            // 
            //         # Add fold information only if read_group_expand is activated (for kanban/list)
            //         if ((field := self._web_read_group_field_expand(groupby)) and field.relational):
            //             model = self.env[field.comodel_name]
            //             fold_name = model._fold_name
            //             if fold_name not in model._fields:
            //                 continue
            //             for value, dict_group in zip(values, result):
            //                 dict_group['__fold'] = value.sudo()[fold_name]
            // 
            //     # Reconstruct groups domain part
            //     for dict_group in result:
            //         dict_group['__extra_domain'] = AND(dict_group.pop('__extra_domains'))
            // 
            //     for aggregate_spec, values in zip(aggregates, column_iterator, strict=True):
            //         for value, dict_group in zip(values, result, strict=True):
            //             dict_group[aggregate_spec] = value
            // 
            //     return result
            */
            return default;
        }

        public async Task<TEntity> WebReadGroupGroupbyFormatterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groupby_spec, object values) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _web_read_group_groupby_formatter(self, groupby_spec, values):
            // """ Return a formatter method that returns value/label and the domain that the group
            // value represent """
            // field_path = groupby_spec.split(':')[0]
            // field_name, _dot, remaining_path = field_path.partition('.')
            // field = self._fields[field_name]
            // 
            // if remaining_path and field.type == 'many2one':
            //     model = self.env[field.comodel_name]
            //     sub_formatter = model._web_read_group_groupby_formatter(groupby_spec.split('.', 1)[1], values)
            // 
            //     def formatter_follow_many2one(value):
            //         value, domain = sub_formatter(value)
            //         if not value:
            //             return value, ['|', (field_name, 'not any', []), (field_name, 'any', domain)]
            //         return value, [(field_name, 'any', domain)]
            // 
            //     return formatter_follow_many2one
            // 
            // if field.type == 'many2many':
            // 
            //     # Special case for many2many because (<many2many>, '=', False) domain bypass ir.rule.
            //     def formatter_many2many(value):
            //         if not value:
            //             return False, [(field_name, 'not any', [])]
            //         id_ = value.id
            //         return (id_, value.sudo().display_name), [(field_name, '=', id_)]
            // 
            //     return formatter_many2many
            // 
            // if field.type == 'many2one' or field_name == 'id':
            // 
            //     def formatter_many2one(value):
            //         if not value:
            //             return False, [(field_name, '=', False)]
            //         id_ = value.id
            //         return (id_, value.sudo().display_name), [(field_name, '=', id_)]
            // 
            //     return formatter_many2one
            // 
            // if field.type in ('date', 'datetime'):
            //     assert ':' in groupby_spec, "Granularity is missing"
            //     granularity = groupby_spec.split(':')[1]
            //     if granularity in READ_GROUP_TIME_GRANULARITY:
            //         locale = get_lang(self.env).code
            //         fmt = DEFAULT_SERVER_DATETIME_FORMAT if field.type == 'datetime' else DEFAULT_SERVER_DATE_FORMAT
            //         interval = READ_GROUP_TIME_GRANULARITY[granularity]
            // 
            //         def formatter_time_granularity(value):
            //             if not value:
            //                 return value, [(field_name, '=', value)]
            //             range_start = value
            //             range_end = value + interval
            //             if field.type == 'datetime':
            //                 tzinfo = None
            //                 if self.env.context.get('tz') in pytz.all_timezones_set:
            //                     tzinfo = pytz.timezone(self.env.context['tz'])
            //                     range_start = tzinfo.localize(range_start).astimezone(pytz.utc)
            //                     # take into account possible hour change between start and end
            //                     range_end = tzinfo.localize(range_end).astimezone(pytz.utc)
            // 
            //                 label = babel.dates.format_datetime(
            //                     range_start, format=READ_GROUP_DISPLAY_FORMAT[granularity],
            //                     tzinfo=tzinfo, locale=locale,
            //                 )
            //             else:
            //                 label = babel.dates.format_date(
            //                     value, format=READ_GROUP_DISPLAY_FORMAT[granularity],
            //                     locale=locale,
            //                 )
            // 
            //             # special case weeks because babel is broken *and*
            //             # ubuntu reverted a change so it's also inconsistent
            //             if granularity == 'week':
            //                 year, week = date_utils.weeknumber(
            //                     babel.Locale.parse(locale),
            //                     value,  # provide date or datetime without UTC conversion
            //                 )
            //                 label = f"W{week} {year:04}"
            // 
            //             additional_domain = ['&',
            //                 (field_name, '>=', range_start.strftime(fmt)),
            //                 (field_name, '<', range_end.strftime(fmt)),
            //             ]
            //             # TODO: date label should be created by the webclient.
            //             return (range_start.strftime(fmt), label), additional_domain
            // 
            //         return formatter_time_granularity
            // 
            //     if granularity in READ_GROUP_NUMBER_GRANULARITY:
            // 
            //         def formatter_date_number_granularity(value):
            //             if value is None:
            //                 return [(field_name, '=', value)]
            //             return value, [(f"{field_name}.{granularity}", '=', value)]
            // 
            //         return formatter_date_number_granularity
            // 
            //     raise ValueError(f"{granularity!r} isn't a valid granularity")
            // 
            // if field.type == "properties":
            //     return self._web_read_group_groupby_properties_formatter(groupby_spec, values)
            // 
            // return lambda value: (value, [(field_name, '=', value)])
            */
            return default;
        }

        public async Task<TEntity> WebReadGroupGroupbyPropertiesFormatterInternalAsync<TEntity>(IEnumerable<TEntity> entities, object groupby_spec, object values) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _web_read_group_groupby_properties_formatter(self, groupby_spec, values):
            // if '.' not in groupby_spec:
            //     raise ValueError('You must choose the property you want to group by.')
            // 
            // fullname, __, func = groupby_spec.partition(':')
            // definition = self.get_property_definition(fullname)
            // property_type = definition.get('type')
            // if property_type == 'selection':
            //     options = definition.get('selection') or []
            //     options = tuple(option[0] for option in options)
            // 
            //     def formatter_property_selection(value):
            //         if not value:
            //             # can not do ('selection', '=', False) because we might have
            //             # option in database that does not exist anymore
            //             return value, ['|', (fullname, '=', False), (fullname, 'not in', options)]
            //         return value, [(fullname, '=', value)]
            // 
            //     return formatter_property_selection
            // 
            // if property_type == 'many2one':
            //     comodel = definition['comodel']
            //     all_groups = tuple(value for value in values if value)
            // 
            //     def formatter_property_many2one(value):
            //         if not value:
            //             # can not only do ('many2one', '=', False) because we might have
            //             # record in database that does not exist anymore
            //             return value, ['|', (fullname, '=', False), (fullname, 'not in', all_groups)]
            //         record = self.env[comodel].browse(value).with_prefetch(all_groups)
            //         return (value, record.display_name), [(fullname, '=', value)]
            // 
            //     return formatter_property_many2one
            // 
            // if property_type == 'many2many':
            //     comodel = definition['comodel']
            //     all_groups = tuple(value for value in values if value)
            // 
            //     def formatter_property_many2many(value):
            //         if not value:
            //             return value, OR([
            //                 [(fullname, '=', False)],
            //                 AND([[(fullname, 'not in', group)] for group in all_groups]),
            //             ]) if all_groups else []
            //         record = self.env[comodel].browse(value).with_prefetch(all_groups)
            //         return (value, record.display_name), [(fullname, 'in', value)]
            // 
            //     return formatter_property_many2many
            // 
            // if property_type == 'tags':
            //     tags = definition.get('tags') or []
            //     tags = {tag[0]: tuple(tag) for tag in tags}
            // 
            //     def formatter_property_tags(value):
            //         if not value:
            //             return value, OR([
            //                 [(fullname, '=', False)],
            //                 AND([[(fullname, 'not in', tag)] for tag in tags]),
            //             ]) if tags else []
            // 
            //         # replace tag raw value with tuple of raw value, label and color
            //         return tags.get(value), [(fullname, 'in', value)]
            // 
            //     return formatter_property_tags
            // 
            // if property_type in ('date', 'datetime'):
            // 
            //     def formatter_property_datetime(value):
            //         if not value:
            //             return False, [(fullname, '=', False)]
            // 
            //         # Date / Datetime are not JSONifiable, so they are stored as raw text
            //         db_format = '%Y-%m-%d' if property_type == 'date' else '%Y-%m-%d %H:%M:%S'
            //         fmt = DEFAULT_SERVER_DATE_FORMAT if property_type == 'date' else DEFAULT_SERVER_DATETIME_FORMAT
            // 
            //         if func == 'week':
            //             # the value is the first day of the week (based on local)
            //             start = value.strftime(db_format)
            //             end = (value + datetime.timedelta(days=7)).strftime(db_format)
            //         else:
            //             start = (date_utils.start_of(value, func)).strftime(db_format)
            //             end = (date_utils.end_of(value, func) + datetime.timedelta(minutes=1)).strftime(db_format)
            // 
            //         label = babel.dates.format_date(
            //             value,
            //             format=READ_GROUP_DISPLAY_FORMAT[func],
            //             locale=get_lang(self.env).code,
            //         )
            //         return (value.strftime(fmt), label), [(fullname, '>=', start), (fullname, '<', end)]
            // 
            //     return formatter_property_datetime
            // 
            // return lambda value: (value, [(fullname, '=', value)])
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebResequenceAsync<TEntity>(IEnumerable<TEntity> entities, object specification, string field_name, int offset) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def web_resequence(self, specification: dict[str, dict], field_name: str = 'sequence', offset: int = 0) -> list[dict]:
            // """ Re-sequences a number of records in the model, by their ids.
            // 
            // The re-sequencing starts at the first record of ``ids``, the
            // sequence number starts at ``offset`` and is incremented by one
            // after each record.
            // 
            // The returning value is a read of the resequenced records with
            // the specification given in the parameter.
            // 
            // :param specification: specification for the read of the
            //     resequenced records
            // :param field_name: field used for sequence specification,
            //     defaults to ``"sequence"``
            // :param offset: sequence number for first record in ``ids``,
            //     allows starting the resequencing from an arbitrary number,
            //     defaults to ``0``
            // """
            // if field_name not in self._fields:
            //     return []
            // 
            // for i, record in enumerate(self, start=offset):
            //     record.write({field_name: i})
            // return self.web_read(specification)
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebSaveAsync<TEntity>(IEnumerable<TEntity> entities, object vals, object specification, Guid next_id) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def web_save(self, vals, specification: dict[str, dict], next_id=None) -> list[dict]:
            // if self:
            //     self.write(vals)
            // else:
            //     self = self.create(vals)
            // if next_id:
            //     self = self.browse(next_id)
            // return self.with_context(bin_size=True).web_read(specification)
            */
            return default;
        }

        public async Task<List<Dictionary<string, object>>> WebSaveMultiAsync<TEntity>(IEnumerable<TEntity> entities, List<Dictionary<string, object>> vals_list, object specification) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def web_save_multi(self, vals_list: list[dict], specification: dict[str, dict]) -> list[dict]:
            // if len(self) != len(vals_list):
            //     raise ValueError("Each record must have a corresponding vals entry.")
            // 
            // for record, val in zip(self, vals_list):
            //     record.write(val)
            // 
            // return self.with_context(bin_size=True).web_read(specification)
            */
            return default;
        }

        [ApiModel]
        public async Task<TEntity> WebSearchReadAsync<TEntity>(IEnumerable<TEntity> entities, object domain, object specification, object offset, object limit, object order, object count_limit) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def web_search_read(self, domain, specification, offset=0, limit=None, order=None, count_limit=None):
            // records = self.search_fetch(domain, specification.keys(), offset=offset, limit=limit, order=order)
            // values_records = records.web_read(specification)
            // return self._format_web_search_read_results(domain, values_records, offset, limit, count_limit)
            */
            return default;
        }

        public async Task<TEntity> WithUserAsync<TEntity>(IEnumerable<TEntity> entities, object user) where TEntity : IEntity<Guid>, IBaseable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: models.py) ---
            // def with_user(self, user):
            // """Override to ensure the guest context is removed as the target user in a with_user should
            // never be considered as being the guest of the outside env."""
            // return super().with_user(user).with_context(guest=None)
            */
            return default;
        }
    }
}