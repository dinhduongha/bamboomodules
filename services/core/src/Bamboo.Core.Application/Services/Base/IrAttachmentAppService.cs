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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule", Category = "Base")]
    public partial class IrAttachmentAppService : GenericApplicationService<IrAttachment>, IIrAttachmentAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public IrAttachmentAppService(IRepository<IrAttachment, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        protected async Task<IrAttachment> BuildZipFromAttachmentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_attachment.py) ---
            // def _build_zip_from_attachments(self):
            // """ Return the zip bytes content resulting from compressing the attachments in `self`"""
            // buffer = io.BytesIO()
            // with zipfile.ZipFile(buffer, 'w', compression=zipfile.ZIP_DEFLATED) as zipfile_obj:
            //     for attachment in self:
            //         zipfile_obj.writestr(attachment.display_name, attachment.raw)
            // return buffer.getvalue()
            */
            return default;
        }

        protected async Task<IrAttachment> BusChannelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: bus, FILE: ir_attachment.py) ---
            // def _bus_channel(self):
            // return self.env.user
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _bus_channel(self):
            // self.ensure_one()
            // if self.res_model == "discuss.channel" and self.res_id:
            //     return self.env["discuss.channel"].browse(self.res_id)
            // guest = self.env["mail.guest"]._get_guest_from_context()
            // if self.env.user._is_public() and guest:
            //     return guest
            // return super()._bus_channel()
            */
            return default;
        }

        protected async Task<IrAttachment> CanBypassRightsOnMediaDialogInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py) ---
            // def _can_bypass_rights_on_media_dialog(self, **attachment_data):
            // """ This method is meant to be overridden, for instance to allow to
            // create image attachment despite the user not allowed to create
            // attachment, eg:
            // - Portal user uploading an image on the forum (bypass acl)
            // - Non admin user uploading an unsplash image (bypass binary/url check)
            // """
            // return False
            --- ODOO METHOD SOURCE (MODULE: web_unsplash, FILE: ir_attachment.py) ---
            // def _can_bypass_rights_on_media_dialog(self, **attachment_data):
            // # We need to allow and sudo the case of an "url + file" attachment,
            // # which is by default forbidden for non admin.
            // # See `_check_serving_attachments`
            // forbidden = 'url' in attachment_data and attachment_data.get('type', 'binary') == 'binary'
            // if forbidden and attachment_data['url'].startswith('/unsplash/'):
            //     return True
            // return super()._can_bypass_rights_on_media_dialog(**attachment_data)
            --- ODOO METHOD SOURCE (MODULE: website_forum, FILE: ir_attachment.py) ---
            // def _can_bypass_rights_on_media_dialog(self, **attachment_data):
            // # Bypass the attachment create ACL and let the user create the image
            // # attachment if they have write access to the model (the image attachment
            // # will be bound to this model's record).
            // res_model = attachment_data['res_model']
            // res_id = attachment_data.get('res_id')
            // if (
            //     res_model == 'forum.post' and res_id
            //     and self.env['forum.post'].browse(res_id).can_use_full_editor
            // ):
            //     return True
            // 
            // return super()._can_bypass_rights_on_media_dialog(**attachment_data)
            */
            return default;
        }

        protected async Task<IrAttachment> CanReturnContentInternalAsync(object field_name, object access_token)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _can_return_content(self, field_name=None, access_token=None):
            // attachment_sudo = self.sudo().with_context(prefetch_fields=False)
            // if access_token:
            //     if not consteq(attachment_sudo.access_token or "", access_token):
            //         raise AccessError("Invalid access token")  # pylint: disable=missing-gettext
            //     return True
            // if attachment_sudo.public:
            //     return True
            // if self.env.user._is_portal():
            //     # Check the read access on the record linked to the attachment
            //     # eg: Allow to download an attachment on a task from /my/tasks/task_id
            //     self.check_access('read')
            //     return True
            // return super()._can_return_content(field_name, access_token)
            */
            return default;
        }

        protected async Task<IrAttachment> CheckAccessInternalAsync(object operation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _check_access(self, operation):
            // """Check access for attachments.
            // 
            // Rules:
            // - `public` is always accessible for reading.
            // - If we have `res_model and res_id`, the attachment is accessible if the
            //   referenced model is accessible. Also, when `res_field != False` and
            //   the user is not an administrator, we check the access on the field.
            // - If we don't have a referenced record, the attachment is accessible to
            //   the administrator and the creator of the attachment.
            // """
            // res = super()._check_access(operation)
            // remaining = self
            // error_func = None
            // forbidden_ids = OrderedSet()
            // if res:
            //     forbidden, error_func = res
            //     if forbidden == self:
            //         return res
            //     remaining -= forbidden
            //     forbidden_ids.update(forbidden._ids)
            // elif not self:
            //     return None
            // 
            // if operation in ('create', 'unlink'):
            //     # check write operation instead of unlinking and creating for
            //     # related models and field access
            //     operation = 'write'
            // 
            // # collect the records to check (by model)
            // model_ids = defaultdict(set)            # {model_name: set(ids)}
            // att_model_ids = []                      # [(att_id, (res_model, res_id))]
            // # DLE P173: `test_01_portal_attachment`
            // remaining = remaining.sudo()
            // remaining.fetch(SECURITY_FIELDS)  # fetch only these fields
            // for attachment in remaining:
            //     if attachment.public and operation == 'read':
            //         continue
            //     att_id = attachment.id
            //     res_model, res_id = attachment.res_model, attachment.res_id
            //     if not self.env.is_system():
            //         if not res_id and attachment.create_uid.id != self.env.uid:
            //             forbidden_ids.add(att_id)
            //             continue
            //         if res_field := attachment.res_field:
            //             try:
            //                 field = self.env[res_model]._fields[res_field]
            //             except KeyError:
            //                 # field does not exist
            //                 field = None
            //             if field is None or not self._has_field_access(field, operation):
            //                 forbidden_ids.add(att_id)
            //                 continue
            //     if res_model and res_id:
            //         model_ids[res_model].add(res_id)
            //         att_model_ids.append((att_id, (res_model, res_id)))
            // forbidden_res_model_id = set(self._inaccessible_comodel_records(model_ids, operation))
            // forbidden_ids.update(att_id for att_id, res in att_model_ids if res in forbidden_res_model_id)
            // 
            // if forbidden_ids:
            //     forbidden = self.browse(forbidden_ids)
            //     forbidden.invalidate_recordset(SECURITY_FIELDS)  # avoid cache pollution
            //     if error_func is None:
            //         def error_func():
            //             return AccessError(self.env._(
            //                 "Sorry, you are not allowed to access this document. "
            //                 "Please contact your system administrator.\n\n"
            //                 "(Operation: %(operation)s)\n\n"
            //                 "Records: %(records)s, User: %(user)s",
            //                 operation=operation,
            //                 records=forbidden[:6],
            //                 user=self.env.uid,
            //             ))
            //     return forbidden, error_func
            // return None
            */
            return default;
        }

        public async Task<IrAttachment> CheckAsync(Guid id, IrAttachmentCheckRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def check(self, mode, values=None):
            // """ Restricts the access to an ir.attachment, according to referred mode """
            // warnings.warn("Since 19.0, use check_access", DeprecationWarning, stacklevel=2)
            // # Always require an internal user (aka, employee) to access to a attachment
            // if not (self.env.is_admin() or self.env.user._is_internal()):
            //     raise AccessError(_("Sorry, you are not allowed to access this document."))
            // self.check_access(mode)
            // if values and any(self._inaccessible_comodel_records({values.get('res_model'): [values.get('res_id')]}, mode)):
            //     raise AccessError(_("Sorry, you are not allowed to access this document."))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrAttachment> CheckContentsInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _check_contents(self, values):
            // mimetype = values['mimetype'] = self._compute_mimetype(values)
            // xml_like = 'ht' in mimetype or ( # hta, html, xhtml, etc.
            //         'xml' in mimetype and    # other xml (svg, text/xml, etc)
            //         not mimetype.startswith('application/vnd.openxmlformats'))  # exception for Office formats
            // force_text = xml_like and (
            //     self.env.context.get('attachments_mime_plainxml')
            //     or not self.env['ir.ui.view'].sudo(False).has_access('write')
            // )
            // if force_text:
            //     values['mimetype'] = 'text/plain'
            // if not self.env.context.get('image_no_postprocess'):
            //     values = self._postprocess_contents(values)
            // return values
            */
            return default;
        }

        protected async Task<IrAttachment> CheckServingAttachmentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _check_serving_attachments(self):
            // if self.env.is_admin():
            //     return
            // for attachment in self:
            //     # restrict writing on attachments that could be served by the
            //     # ir.http's dispatch exception handling
            //     # XDO note: if read on sudo, read twice, one for constraints, one for _inverse_datas as user
            //     if attachment.type == 'binary' and attachment.url:
            //         has_group = self.env.user.has_group
            //         if not any(has_group(g) for g in attachment.get_serving_groups()):
            //             raise ValidationError(_("Sorry, you are not allowed to write on this document"))
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeChecksumInternalAsync(object bin_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _compute_checksum(self, bin_data):
            // """ compute the checksum for the given datas
            //     :param bin_data : datas in its binary form
            // """
            // # an empty file has a checksum too (for caching)
            // return hashlib.sha1(bin_data or b'').hexdigest()
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeDatasInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _compute_datas(self):
            // if self.env.context.get('bin_size'):
            //     for attach in self:
            //         attach.datas = human_size(attach.file_size)
            //     return
            // 
            // for attach in self:
            //     attach.datas = base64.b64encode(attach.raw or b'')
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeHasThumbnailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _compute_has_thumbnail(self):
            // for attachment in self.with_context(bin_size=True):
            //     attachment.has_thumbnail = bool(attachment.thumbnail)
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeImageSizeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py) ---
            // def _compute_image_size(self):
            // for attachment in self:
            //     try:
            //         image = base64_to_image(attachment.datas)
            //         attachment.image_width = image.width
            //         attachment.image_height = image.height
            //     except UserError:
            //         attachment.image_width = 0
            //         attachment.image_height = 0
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeImageSrcInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py) ---
            // def _compute_image_src(self):
            // for attachment in self:
            //     # Only add a src for supported images
            //     if not attachment.mimetype or attachment.mimetype.split(';')[0] not in SUPPORTED_IMAGE_MIMETYPES:
            //         attachment.image_src = False
            //         continue
            // 
            //     if attachment.type == 'url':
            //         if attachment.url.startswith('/'):
            //             # Local URL
            //             attachment.image_src = attachment.url
            //         else:
            //             name = quote(attachment.name)
            //             attachment.image_src = '/web/image/%s-redirect/%s' % (attachment.id, name)
            //     else:
            //         # Adding unique in URLs for cache-control
            //         unique = attachment.checksum[:8]
            //         if attachment.url:
            //             # For attachments-by-url, unique is used as a cachebuster. They
            //             # currently do not leverage max-age headers.
            //             separator = '&' if '?' in attachment.url else '?'
            //             attachment.image_src = '%s%sunique=%s' % (attachment.url, separator, unique)
            //         else:
            //             name = quote(attachment.name)
            //             attachment.image_src = '/web/image/%s-%s/%s' % (attachment.id, unique, name)
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeLocalUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py) ---
            // def _compute_local_url(self):
            // for attachment in self:
            //     if attachment.url:
            //         attachment.local_url = attachment.url
            //     else:
            //         attachment.local_url = '/web/image/%s?unique=%s' % (attachment.id, attachment.checksum)
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeMimetypeInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _compute_mimetype(self, values):
            // """ compute the mimetype of the given values
            //     :param values : dict of values to create or write an ir_attachment
            //     :return mime : string indicating the mimetype, or application/octet-stream by default
            // """
            // mimetype = None
            // if values.get('mimetype'):
            //     mimetype = values['mimetype']
            // if not mimetype and values.get('name'):
            //     mimetype = mimetypes.guess_type(values['name'])[0]
            // if not mimetype and values.get('url'):
            //     mimetype = mimetypes.guess_type(values['url'].split('?')[0])[0]
            // if not mimetype or mimetype == 'application/octet-stream':
            //     raw = None
            //     if values.get('raw'):
            //         raw = values['raw']
            //     elif values.get('datas'):
            //         raw = base64.b64decode(values['datas'])
            //     if raw:
            //         mimetype = guess_mimetype(raw)
            // return mimetype and mimetype.lower() or 'application/octet-stream'
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeRawInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _compute_raw(self):
            // for attach in self:
            //     if attach.store_fname:
            //         attach.raw = attach._file_read(attach.store_fname)
            //     else:
            //         attach.raw = attach.db_datas
            */
            return default;
        }

        protected async Task<IrAttachment> ComputeResNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _compute_res_name(self):
            // for attachment in self:
            //     if attachment.res_model and attachment.res_id:
            //         record = self.env[attachment.res_model].browse(attachment.res_id)
            //         attachment.res_name = record.display_name
            //     else:
            //         attachment.res_name = False
            */
            return default;
        }

        public override async Task<IrAttachment> CopyAsync(Guid id, List<string> fields, IrAttachment defaultValues = null)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py) ---
            // def copy(self, default=None):
            // for attachment in self:
            //     index_content_cache[attachment.checksum] = attachment.index_content
            // return super().copy(default=default)
            */
            return await base.CopyAsync(id, fields, defaultValues);
        }

        public async Task<IrAttachment> CopyDataAsync(Guid id, IrAttachmentCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def copy_data(self, default=None):
            // default = dict(default or {})
            // vals_list = super().copy_data(default=default)
            // for attachment, vals in zip(self, vals_list):
            //     if not default.keys() & {'datas', 'db_datas', 'raw'}:
            //         # ensure the content is kept and recomputes checksum/store_fname
            //         vals['raw'] = attachment.raw
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<IrAttachment> CreateAsync(IrAttachment entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: ir_attachment.py) ---
            // def create(self, vals_list):
            // """Create product.document for attachments added in products chatters"""
            // attachments = super().create(vals_list)
            // if not self.env.context.get('disable_product_documents_creation'):
            //     product_attachments = attachments.filtered(
            //         lambda attachment:
            //             attachment.res_model in ('product.product', 'product.template')
            //             and not attachment.res_field
            //     )
            //     if product_attachments:
            //         self.env['product.document'].sudo().create([
            //             {
            //                 'ir_attachment_id': attachment.id
            //             }
            //             for attachment in product_attachments
            //         ])
            // return attachments
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_attachment.py) ---
            // def create(self, vals_list):
            // website = self.env['website'].get_current_website(fallback=False)
            // for vals in vals_list:
            //     if website and 'website_id' not in vals and 'not_force_website_id' not in self.env.context:
            //         vals['website_id'] = website.id
            // return super().create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def create(self, vals_list):
            // record_tuple_set = set()
            // 
            // # remove computed field depending of datas
            // vals_list = [{
            //     key: value
            //     for key, value
            //     in vals.items()
            //     if key not in ('file_size', 'checksum', 'store_fname')
            // } for vals in vals_list]
            // checksum_raw_map = {}
            // 
            // for values in vals_list:
            //     # needs to be popped in all cases to bypass `_inverse_datas`
            //     datas = values.pop('datas', None)
            //     if raw := values.get('raw'):
            //         if isinstance(raw, str):
            //             values['raw'] = raw.encode()
            //     elif datas:
            //         values['raw'] = base64.b64decode(datas)
            //     else:
            //         values['raw'] = b''
            // 
            //     values = self._check_contents(values)
            //     if raw := values.pop('raw'):
            //         values.update(self._get_datas_related_values(raw, values['mimetype']))
            //         checksum_raw_map[values['checksum']] = raw
            // 
            //     # 'check()' only uses res_model and res_id from values, and make an exists.
            //     # We can group the values by model, res_id to make only one query when
            //     # creating multiple attachments on a single record.
            //     record_tuple = (values.get('res_model'), values.get('res_id'))
            //     record_tuple_set.add(record_tuple)
            // 
            // # don't use possible contextual recordset for check, see commit for details
            // model_and_ids = defaultdict(set)
            // for res_model, res_id in record_tuple_set:
            //     model_and_ids[res_model].add(res_id)
            // if any(self._inaccessible_comodel_records(model_and_ids, 'write')):
            //     raise AccessError(_("Sorry, you are not allowed to access this document."))
            // records = super().create(vals_list)
            // if self._storage() != 'db':
            //     for checksum, raw in checksum_raw_map.items():
            //         self._file_write(raw, checksum)
            // records._check_serving_attachments()
            // return records
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<IrAttachment> CreateUniqueAsync(Guid id, IrAttachmentCreateUniqueRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def create_unique(self, values_list):
            // ids = []
            // for values in values_list:
            //     # Create only if record does not already exist for checksum and size.
            //     try:
            //         bin_data = base64.b64decode(values.get('datas', '')) or False
            //     except binascii.Error:
            //         raise UserError(_("Attachment is not encoded in base64."))
            //     checksum = self._compute_checksum(bin_data)
            //     existing_domain = [
            //         ['id', '!=', False],  # No implicit condition on res_field.
            //         ['checksum', '=', checksum],
            //         ['file_size', '=', len(bin_data)],
            //         ['mimetype', '=', values['mimetype']],
            //     ]
            //     existing = self.sudo().search(existing_domain)
            //     if existing:
            //         for attachment in existing:
            //             ids.append(attachment.id)
            //     else:
            //         attachment = self.create(values)
            //         ids.append(attachment.id)
            // return ids
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrAttachment> CronMigrateLocalToCloudStorageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_migration, FILE: ir_attachment.py) ---
            // def _cron_migrate_local_to_cloud_storage(self):
            // """
            // The Http server only reschedules the cron job asap without migrating any attachment.
            // The cron server will continue the migrating process stopped at the last time by using
            // ``cloud_storage_migration_min_attachment_id``
            // """
            // ICP = self.env['ir.config_parameter']
            // if not ICP.get_param('cloud_storage_provider'):
            //     raise UserError(_("Cloud storage provider is not configured"))
            // 
            // # check ir.config_parameter values' formats are correct
            // cron = self.env.ref('cloud_storage_migration.ir_cron_manual_migrate_local_to_cloud_storage')
            // min_file_size = int(ICP.get_param('cloud_storage_min_file_size', DEFAULT_CLOUD_STORAGE_MIN_FILE_SIZE))
            // max_file_size = int(ICP.get_param('cloud_storage_migration_max_file_size', 10**9))  # default 1GB
            // max_batch_file_size = int(ICP.get_param('cloud_storage_migration_max_batch_file_size', 10**10))  # default 10GB
            // message_model_names = ICP.get_param('cloud_storage_migration_message_models', '').split(',')
            // message_model_names = tuple(m_ for m in message_model_names if (m_ := m.strip()) and m_ in self.env)
            // all_model_names = ICP.get_param('cloud_storage_migration_all_models', '').split(',')
            // all_model_names = tuple(m_ for m in all_model_names if (m_ := m.strip()) and m_ in self.env)
            // if not message_model_names and not all_model_names:
            //     raise UserError(_("No model for cloud storage migration"))
            // 
            // max_attachment_id = int(ICP.get_param('cloud_storage_migration_max_attachment_id', 0))
            // if not max_attachment_id:
            //     max_attachment_id = self.env['ir.attachment'].sudo().search_fetch([], ['id'], limit=1, order='id desc').id or 1
            //     ICP.set_param('cloud_storage_migration_max_attachment_id', max_attachment_id)
            // 
            // if request:
            //     # Don't upload in HTTP server, if the method is called by ``Manually Run`` button from web client
            //     # The cron job should be rescheduled asap in cron server
            //     cron._trigger()
            //     return
            // 
            // def commit_min_attachment_id(attachment_id):
            //     # directly write data of ir_config_parameter to avoid invalidating ormcache
            //     self.env.cr.execute("UPDATE ir_config_parameter SET value = %s WHERE key = 'cloud_storage_migration_min_attachment_id'", (str(attachment_id),))
            //     self.env['ir.cron']._commit_progress(1)  # record this attachment as attempted to avoid reprocessing
            // 
            // limit_time_real = config['limit_time_real']
            // # ``config['limit_time_real_cron'] == 0`` means unlimited time for cron worker,
            // # but will fallback to ``config['limit_time_real']`` for cron thread
            // # here we use ``config['limit_time_real']`` for simplicity
            // if config['limit_time_real_cron'] and config['limit_time_real_cron'] > 0:
            //     limit_time_real = config['limit_time_real_cron']
            // # use half of the time limit to mitigate the timeout problem
            // end_time = limit_time_real // 2 + time.monotonic()
            // 
            // check_model = []
            // if message_model_names:
            //     check_model.append(SQL('(ia.res_model IN %s AND mar.attachment_id IS NOT NULL)', message_model_names))
            // if all_model_names:
            //     check_model.append(SQL('(ia.res_model IN %s)', all_model_names))
            // check_model = SQL(' OR ').join(check_model)
            // 
            // check_documents = SQL("""
            //     AND NOT EXISTS (
            //         SELECT 1
            //         FROM documents_document dd
            //         WHERE dd.attachment_id = ia.id
            //     )""") if 'documents.document' in self.env else SQL("")
            // 
            // # check ir_attachment records which are used by any mail_message.attachment_ids
            // query = SQL("""
            //     WITH last_attachment AS (
            //         SELECT value::integer AS id
            //         FROM ir_config_parameter
            //         WHERE key = 'cloud_storage_migration_min_attachment_id'
            //         LIMIT 1
            //     )
            //     SELECT ia.id
            //     FROM ir_attachment ia
            //     LEFT JOIN message_attachment_rel mar
            //     ON mar.attachment_id = ia.id
            //     WHERE ia.id <= %(max_attachment_id)s
            //     AND ia.id > COALESCE((SELECT id FROM last_attachment), 0)
            //     AND ia.type = 'binary'
            //     AND ia.url IS NULL
            //     AND ia.res_id IS NOT NULL
            //     AND ia.res_field IS NULL
            //     AND ia.store_fname IS NOT NULL
            //     AND (%(check_model)s)
            //     AND ia.file_size BETWEEN %(min_file_size)s AND %(max_file_size)s
            //     AND ia.create_date < %(create_date)s
            //     %(check_documents)s
            //     ORDER BY ia.id ASC
            //     LIMIT 1;
            // """,
            //     max_attachment_id=max_attachment_id,
            //     check_model=check_model,
            //     # ignore if attachment is too small or too large
            //     min_file_size=min_file_size,
            //     max_file_size=max_file_size,
            //     # ignore attachments uploaded recently in case their binaries are unfortunately used by business
            //     # codes which may block important business operations
            //     create_date=fields.Datetime.now() - timedelta(days=7),
            //     # ignore if attachment is used by documents.document
            //     check_documents=check_documents,
            // )
            // 
            // session = requests.Session()
            // 
            // total_file_size = 0
            // first_attachment = True
            // while True:
            //     self.env.cr.execute(query)
            //     res = self.env.cr.fetchone()
            //     attachment = self.env['ir.attachment'].browse(res[0] if res else False)
            // 
            //     if not attachment:
            //         commit_min_attachment_id(max_attachment_id)
            //         return
            // 
            //     total_file_size += attachment.file_size
            //     if max_batch_file_size and total_file_size >= max_batch_file_size:
            //         if first_attachment:
            //             # skip in case attachment.file_size > max_batch_file_size
            //             commit_min_attachment_id(attachment.id)
            //         break
            //     first_attachment = False
            // 
            //     # commit before migration to upload the file only once even if it causes timeout
            //     commit_min_attachment_id(attachment.id)
            // 
            //     try:
            //         attachment._migrate_local_to_cloud_storage(session)
            //         self.env['ir.cron']._commit_progress(0)  # progress already recorded via ``commit_min_attachment_id``
            //         _logger.info('uploaded attachment %s to cloud storage', attachment.id)
            //     except Exception as e:  # noqa: BLE001
            //         _logger.warning('Failed to upload attachment %s to cloud storage: %s', attachment.id, e)
            //         self.env.cr.rollback()
            // 
            //     if end_time < time.monotonic():
            //         break
            // 
            // cron._trigger()
            */
            return default;
        }

        protected async Task<IrAttachment> DeleteAndNotifyInternalAsync(object message)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _delete_and_notify(self, message=None):
            // if message:
            //     # sudo: mail.message - safe write just updating the date, because guests don't have the rights
            //     message.sudo().write({})  # to make sure write_date on the message is updated
            // for attachment in self:
            //     attachment._bus_send(
            //         "ir.attachment/delete",
            //         {
            //             "id": attachment.id,
            //             "message": (
            //                 {"id": message.id, "write_date": message.write_date} if message else None
            //             ),
            //         },
            //     )
            // self.unlink()
            */
            return default;
        }

        protected async Task<IrAttachment> ExceptAuditTrailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_attachment.py) ---
            // def _except_audit_trail(self):
            // audit_trail_attachments = self.filtered(lambda attachment:
            //     attachment.res_model == 'account.move'
            //     and attachment.res_id
            //     and attachment.raw
            //     and attachment.company_id.restrictive_audit_trail
            //     and guess_mimetype(attachment.raw) in (
            //         'application/pdf',
            //         'application/xml',
            //     )
            // )
            // id2move = self.env['account.move'].browse(set(audit_trail_attachments.mapped('res_id'))).exists().grouped('id')
            // for attachment in audit_trail_attachments:
            //     move = id2move.get(attachment.res_id)
            //     if move and move.posted_before and move.company_id.restrictive_audit_trail:
            //         ue = UserError(_("You cannot remove parts of a restricted audit trail."))
            //         ue._audit_trail = True
            //         raise ue
            */
            return default;
        }

        protected async Task<IrAttachment> FileDeleteInternalAsync(object fname)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _file_delete(self, fname):
            // # simply add fname to checklist, it will be garbage-collected later
            // self._mark_for_gc(fname)
            */
            return default;
        }

        protected async Task<IrAttachment> FileReadInternalAsync(object fname, object size)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _file_read(self, fname, size=None):
            // assert isinstance(self, IrAttachment)
            // full_path = self._full_path(fname)
            // try:
            //     with open(full_path, 'rb') as f:
            //         return f.read(size)
            // except OSError:
            //     _logger.info("_read_file reading %s", full_path, exc_info=True)
            // return b''
            */
            return default;
        }

        protected async Task<IrAttachment> FileWriteInternalAsync(object bin_value, object checksum)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _file_write(self, bin_value, checksum):
            // assert isinstance(self, IrAttachment)
            // fname, full_path = self._get_path(bin_value, checksum)
            // if not os.path.exists(full_path):
            //     try:
            //         with open(full_path, 'wb') as fp:
            //             fp.write(bin_value)
            //         # add fname to checklist, in case the transaction aborts
            //         self._mark_for_gc(fname)
            //     except OSError:
            //         _logger.info("_file_write writing %s", full_path)
            //         raise
            // return fname
            */
            return default;
        }

        protected async Task<IrAttachment> FilestoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _filestore(self):
            // return config.filestore(self.env.cr.dbname)
            */
            return default;
        }

        public async Task<IrAttachment> ForceStorageAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def force_storage(self):
            // """Force all attachments to be stored in the currently configured storage"""
            // if not self.env.is_admin():
            //     raise AccessError(_('Only administrators can execute this action.'))
            // 
            // # Migrate only binary attachments and bypass the res_field automatic
            // # filter added in _search override
            // self.search(Domain.AND([
            //     self._get_storage_domain(),
            //     ['&', ('type', '=', 'binary'), '|', ('res_field', '=', False), ('res_field', '!=', False)]
            // ]))._migrate()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrAttachment> FromRequestFileInternalAsync(object file)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _from_request_file(self, file, *, mimetype, **vals):
            // """
            // Create an attachment out of a request file
            // 
            // :param file: the request file
            // :param str mimetype:
            //     * "TRUST" to use the mimetype and file extension from the
            //       request file with no verification.
            //     * "GUESS" to determine the mimetype and file extension on
            //       the file's content. The determined extension is added at
            //       the end of the filename unless the filename already had a
            //       valid extension.
            //     * a mimetype in format "{type}/{subtype}" to force the
            //       mimetype to the given value, it adds the corresponding
            //       file extension at the end of the filename unless the
            //       filename already had a valid extension.
            // """
            // if mimetype == 'TRUST':
            //     mimetype = file.content_type
            //     filename = file.filename
            // elif mimetype == 'GUESS':
            //     head = file.read(MIMETYPE_HEAD_SIZE)
            //     file.seek(-len(head), 1)  # rewind
            //     mimetype = guess_mimetype(head)
            //     filename = fix_filename_extension(file.filename, mimetype)
            //     if mimetype in ('application/zip', *_olecf_mimetypes):
            //         mimetype = mimetypes.guess_type(filename)[0]
            // elif all(mimetype.partition('/')):
            //     filename = fix_filename_extension(file.filename, mimetype)
            // else:
            //     raise ValueError(f'{mimetype=}')
            // 
            // return self.create({
            //     'name': filename,
            //     'type': 'binary',
            //     'raw': file.read(),  # load the entire file in memory :(
            //     'mimetype': mimetype,
            //     **vals,
            // })
            */
            return default;
        }

        protected async Task<IrAttachment> FullPathInternalAsync(object path)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _full_path(self, path):
            // # sanitize path
            // path = re.sub('[.:]', '', path)
            // path = path.strip('/\\')
            // return os.path.join(self._filestore(), path)
            */
            return default;
        }

        protected async Task<IrAttachment> GcDocIndexInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: api_doc, FILE: ir_attachment.py) ---
            // def _gc_doc_index(self):
            // """ Garbage collect the outdated /doc/index.json attachments. """
            // sequence = str(self.env.registry.get_sequences(self.env.cr)[0])
            // attachments = self.search_fetch(
            //     [('name', 'like', R'odoo-doc-index-%-%.json')],
            //     ['name'],
            // ).filtered(
            //     lambda doc: doc.name.split('-')[3] != sequence,
            // )
            // if attachments:
            //     attachments.unlink()
            // _logger.info("GC'd %s /doc cached index", len(attachments))
            */
            return default;
        }

        protected async Task<IrAttachment> GcFileStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _gc_file_store(self):
            // """ Perform the garbage collection of the filestore. """
            // assert isinstance(self, IrAttachment)
            // if self._storage() != 'file':
            //     return
            // 
            // # Continue in a new transaction. The LOCK statement below must be the
            // # first one in the current transaction, otherwise the database snapshot
            // # used by it may not contain the most recent changes made to the table
            // # ir_attachment! Indeed, if concurrent transactions create attachments,
            // # the LOCK statement will wait until those concurrent transactions end.
            // # But this transaction will not see the new attachements if it has done
            // # other requests before the LOCK (like the method _storage() above).
            // cr = self.env.cr
            // cr.commit()
            // 
            // # prevent all concurrent updates on ir_attachment while collecting,
            // # but only attempt to grab the lock for a little bit, otherwise it'd
            // # start blocking other transactions. (will be retried later anyway)
            // cr.execute("SET LOCAL lock_timeout TO '10s'")
            // try:
            //     cr.execute("LOCK ir_attachment IN SHARE MODE")
            // except psycopg2.errors.LockNotAvailable:
            //     cr.rollback()
            //     return False
            // 
            // self._gc_file_store_unsafe()
            // 
            // # commit to release the lock
            // cr.commit()
            */
            return default;
        }

        protected async Task<IrAttachment> GcFileStoreUnsafeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _gc_file_store_unsafe(self):
            // # retrieve the file names from the checklist
            // checklist = {}
            // for dirpath, _, filenames in os.walk(self._full_path('checklist')):
            //     dirname = os.path.basename(dirpath)
            //     for filename in filenames:
            //         fname = "%s/%s" % (dirname, filename)
            //         checklist[fname] = os.path.join(dirpath, filename)
            // 
            // # Clean up the checklist. The checklist is split in chunks and files are garbage-collected
            // # for each chunk.
            // removed = 0
            // for names in split_every(self.env.cr.IN_MAX, checklist):
            //     # determine which files to keep among the checklist
            //     self.env.cr.execute("SELECT store_fname FROM ir_attachment WHERE store_fname IN %s", [names])
            //     whitelist = set(row[0] for row in self.env.cr.fetchall())
            // 
            //     # remove garbage files, and clean up checklist
            //     for fname in names:
            //         filepath = checklist[fname]
            //         if fname not in whitelist:
            //             try:
            //                 os.unlink(self._full_path(fname))
            //                 _logger.debug("_file_gc unlinked %s", self._full_path(fname))
            //                 removed += 1
            //             except OSError:
            //                 _logger.info("_file_gc could not unlink %s", self._full_path(fname), exc_info=True)
            //         with contextlib.suppress(OSError):
            //             os.unlink(filepath)
            // 
            // _logger.info("filestore gc %d checked, %d removed", len(checklist), removed)
            */
            return default;
        }

        public async Task<IrAttachment> GenerateAccessTokenAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def generate_access_token(self):
            // tokens = []
            // for attachment in self:
            //     if attachment.access_token:
            //         tokens.append(attachment.access_token)
            //         continue
            //     access_token = self._generate_access_token()
            //     attachment.write({'access_token': access_token})
            //     tokens.append(access_token)
            // return tokens
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrAttachment> GenerateAccessTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _generate_access_token(self):
            // return str(uuid.uuid4())
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageAzureSasUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_azure_sas_url(self, **kwargs):
            // token = generate_blob_sas(user_delegation_key=get_cloud_storage_azure_user_delegation_key(self.env), **kwargs)
            // return f"{self._generate_cloud_storage_azure_url(kwargs['blob_name'])}?{token}"
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageAzureUrlInternalAsync(object blob_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_azure_url(self, blob_name):
            // ICP = self.env['ir.config_parameter'].sudo()
            // account_name = ICP.get_param('cloud_storage_azure_account_name')
            // container_name = ICP.get_param('cloud_storage_azure_container_name')
            // return f"https://{account_name}.blob.core.windows.net/{container_name}/{quote(blob_name)}"
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageBlobNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_blob_name(self):
            // """
            // Generate a unique blob name for the attachment
            // 
            // :return: A unique blob name str
            // """
            // return f'{self.id}/{uuid.uuid4()}/{self.name}'
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageDownloadInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_download_info(self):
            // """
            // Generate the download info for the public client to directly download
            // the attachment's blob from the cloud storage.
            // 
            // :return: An download_info dictionary containing:
            // 
            //     download_url
            //         cloud storage url with permission to download the file
            //     time_to_expiry
            //         the time in seconds before the download url expires
            // """
            // raise NotImplementedError()
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_download_info(self):
            // if self.env['ir.config_parameter'].sudo().get_param('cloud_storage_provider') != 'azure':
            //     return super()._generate_cloud_storage_download_info()
            // info = self._get_cloud_storage_azure_info()
            // expiry = datetime.now(timezone.utc) + timedelta(seconds=self._cloud_storage_download_url_time_to_expiry)
            // return {
            //     'url': self._generate_cloud_storage_azure_sas_url(**info, permission='r', expiry=expiry, cache_control=f'private, max-age={self._cloud_storage_download_url_time_to_expiry}'),
            //     'time_to_expiry': self._cloud_storage_download_url_time_to_expiry,
            // }
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_download_info(self):
            // if self.env['ir.config_parameter'].sudo().get_param('cloud_storage_provider') != 'google':
            //     return super()._generate_cloud_storage_download_info()
            // info = self._get_cloud_storage_google_info()
            // return {
            //     'url': self._generate_cloud_storage_google_signed_url(info['bucket_name'], info['blob_name'], method='GET', expiration=self._cloud_storage_download_url_time_to_expiry),
            //     'time_to_expiry': self._cloud_storage_download_url_time_to_expiry,
            // }
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageGoogleSignedUrlInternalAsync(object bucket_name, object blob_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_google_signed_url(self, bucket_name, blob_name, **kwargs):
            // quote_blob_name = quote(blob_name)
            // return generate_signed_url_v4(
            //     credentials=get_cloud_storage_google_credential(self.env),
            //     resource=f'/{bucket_name}/{quote_blob_name}',
            //     **kwargs,
            // )
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageGoogleUrlInternalAsync(object blob_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_google_url(self, blob_name):
            // bucket_name = self.env['ir.config_parameter'].get_param('cloud_storage_google_bucket_name')
            // return f"https://storage.googleapis.com/{bucket_name}/{quote(blob_name)}"
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageUploadInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_upload_info(self):
            // """
            // Generate the upload info for the public client to directly upload a
            // file to the cloud storage.
            // 
            // :return: An upload_info dictionary containing:
            // 
            //     upload_url
            //         cloud storage url with permission to upload the file
            //     method
            //         the request method used to upload the file
            //     response_status
            //         the status of the response for a successful upload request
            //     [Optionally] headers
            //         a dictionary of headers to be added to the upload request
            // """
            // raise NotImplementedError()
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_upload_info(self):
            // if self.env['ir.config_parameter'].sudo().get_param('cloud_storage_provider') != 'azure':
            //     return super()._generate_cloud_storage_upload_info()
            // info = self._get_cloud_storage_azure_info()
            // expiry = datetime.now(timezone.utc) + timedelta(seconds=self._cloud_storage_upload_url_time_to_expiry)
            // url = self._generate_cloud_storage_azure_sas_url(**info, permission='c', expiry=expiry)
            // return {
            //     'url': url,
            //     'method': 'PUT',
            //     'headers': {
            //         'x-ms-blob-type': 'BlockBlob',
            //     },
            //     'response_status': 201,
            // }
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_upload_info(self):
            // if self.env['ir.config_parameter'].sudo().get_param('cloud_storage_provider') != 'google':
            //     return super()._generate_cloud_storage_upload_info()
            // info = self._get_cloud_storage_google_info()
            // return {
            //     'url': self._generate_cloud_storage_google_signed_url(info['bucket_name'], info['blob_name'], method='PUT', expiration=self._cloud_storage_upload_url_time_to_expiry),
            //     'method': 'PUT',
            //     'response_status': 200,
            // }
            */
            return default;
        }

        protected async Task<IrAttachment> GenerateCloudStorageUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_url(self):
            // """
            // Generate a cloud blob url without signature or token for the attachment.
            // This url is only used to identify the cloud blob.
            // 
            // :return: A cloud blob url str
            // """
            // raise NotImplementedError()
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_url(self):
            // if self.env['ir.config_parameter'].sudo().get_param('cloud_storage_provider') != 'azure':
            //     return super()._generate_cloud_storage_url()
            // blob_name = self._generate_cloud_storage_blob_name()
            // return self._generate_cloud_storage_azure_url(blob_name)
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py) ---
            // def _generate_cloud_storage_url(self):
            // if self.env['ir.config_parameter'].sudo().get_param('cloud_storage_provider') != 'google':
            //     return super()._generate_cloud_storage_url()
            // blob_name = self._generate_cloud_storage_blob_name()
            // return self._generate_cloud_storage_google_url(blob_name)
            */
            return default;
        }

        public async Task<IrAttachment> GetAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def action_get(self):
            // return self.env['ir.actions.act_window']._for_xml_id('base.action_attachment')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrAttachment> GetCloudStorageAzureInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_azure, FILE: ir_attachment.py) ---
            // def _get_cloud_storage_azure_info(self):
            // match = self._cloud_storage_azure_url_pattern.fullmatch(self.url or '')
            // if not match:
            //     raise ValidationError(self.env._('%s is not a valid Azure Blob Storage URL.', self.url))
            // return {
            //     'account_name': match['account_name'],
            //     'container_name': match['container_name'],
            //     'blob_name': unquote(match['blob_name']),
            // }
            */
            return default;
        }

        protected async Task<IrAttachment> GetCloudStorageGoogleInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_google, FILE: ir_attachment.py) ---
            // def _get_cloud_storage_google_info(self):
            // match = self._cloud_storage_google_url_pattern.fullmatch(self.url or '')
            // if not match:
            //     raise ValidationError(self.env._('%s is not a valid Google Cloud Storage URL.', self.url))
            // return {
            //     'bucket_name': match['bucket_name'],
            //     'blob_name': unquote(match['blob_name']),
            // }
            */
            return default;
        }

        protected async Task<IrAttachment> GetCloudStorageUnsupportedModelsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py) ---
            // def _get_cloud_storage_unsupported_models(self):
            // # Some models may use their attachments' data in the business code
            // # We should avoid those attachments to be uploaded to the cloud storage
            // models = self.env.registry.descendants(['mail.thread.main.attachment'], '_inherit', '_inherits')
            // if 'documents.mixin' in self.env:
            //     models.update(self.env.registry.descendants(['documents.mixin'], '_inherit'))
            //     models.add('documents.document')
            // return list(models)
            */
            return default;
        }

        protected async Task<IrAttachment> GetDatasRelatedValuesInternalAsync(object data, object mimetype)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _get_datas_related_values(self, data, mimetype):
            // checksum = self._compute_checksum(data)
            // try:
            //     index_content = self._index(data, mimetype, checksum=checksum)
            // except TypeError:
            //     index_content = self._index(data, mimetype)
            // values = {
            //     'file_size': len(data),
            //     'checksum': checksum,
            //     'index_content': index_content,
            //     'store_fname': False,
            //     'db_datas': data,
            // }
            // if data and self._storage() != 'db':
            //     values['store_fname'], _full_path = self._get_path(data, checksum)
            //     values['db_datas'] = False
            // return values
            */
            return default;
        }

        protected async Task<IrAttachment> GetMediaInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: html_editor, FILE: ir_attachment.py) ---
            // def _get_media_info(self):
            // """Return a dict with the values that we need on the media dialog."""
            // self.ensure_one()
            // return self._read_format(['id', 'name', 'description', 'mimetype', 'checksum', 'url', 'type', 'res_id', 'res_model', 'public', 'access_token', 'image_src', 'image_width', 'image_height', 'original_id'])[0]
            */
            return default;
        }

        protected async Task<IrAttachment> GetOwnershipTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _get_ownership_token(self):
            // """ Returns a scoped limited access token that indicates ownership of the attachment when
            //     using _has_attachments_ownership. If verified by verify_limited_field_access_token,
            //     accessing the attachment bypasses the ACLs.
            // 
            //     :rtype: str
            // """
            // self.ensure_one()
            // return limited_field_access_token(self, field_name="id", scope="attachment_ownership")
            */
            return default;
        }

        protected async Task<IrAttachment> GetPathInternalAsync(object bin_data, object sha)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _get_path(self, bin_data, sha):
            // # scatter files across 256 dirs
            // # we use '/' in the db (even on windows)
            // fname = sha[:2] + '/' + sha
            // full_path = self._full_path(fname)
            // dirname = os.path.dirname(full_path)
            // if not os.path.isdir(dirname):
            //     os.makedirs(dirname, exist_ok=True)
            // 
            // # prevent sha-1 collision
            // if os.path.isfile(full_path) and not self._same_content(bin_data, full_path):
            //     raise UserError(_("The attachment collides with an existing file."))
            // return fname, full_path
            */
            return default;
        }

        protected async Task<IrAttachment> GetRawAccessTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _get_raw_access_token(self):
            // """Return a scoped access token for the `raw` field. The token can be
            // used with `ir_binary._find_record` to bypass access rights.
            // 
            // :rtype: str
            // """
            // self.ensure_one()
            // return limited_field_access_token(self, "raw", scope="binary")
            */
            return default;
        }

        protected async Task<IrAttachment> GetServeAttachmentInternalAsync(object url, object extra_domain, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_attachment.py) ---
            // def _get_serve_attachment(self, url, extra_domain=None, order=None):
            // website = self.env['website'].get_current_website()
            // extra_domain = (extra_domain or []) + website.website_domain()
            // order = ('website_id, %s' % order) if order else 'website_id'
            // return super()._get_serve_attachment(url, extra_domain, order)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _get_serve_attachment(self, url, extra_domain=None, order=None):
            // domain = [('type', '=', 'binary'), ('url', '=', url)] + (extra_domain or [])
            // return self.search(domain, order=order, limit=1)
            */
            return default;
        }

        public async Task<IrAttachment> GetServingGroupsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_attachment.py) ---
            // def get_serving_groups(self):
            // return super().get_serving_groups() + ['website.group_website_designer']
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def get_serving_groups(self):
            // """ An ir.attachment record may be used as a fallback in the
            // http dispatch if its type field is set to "binary" and its url
            // field is set as the request's url. Only the groups returned by
            // this method are allowed to create and write on such records.
            // """
            // return ['base.group_system']
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrAttachment> GetStorageDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _get_storage_domain(self):
            // # domain to retrieve the attachments to migrate
            // return {
            //     'db': [('store_fname', '!=', False)],
            //     'file': [('db_datas', '!=', False)],
            // }[self._storage()]
            */
            return default;
        }

        protected async Task<IrAttachment> GetStoreOwnershipFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _get_store_ownership_fields(self):
            // return [Store.Attr("ownership_token", lambda a: a._get_ownership_token())]
            */
            return default;
        }

        protected async Task<IrAttachment> GetThumbnailTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _get_thumbnail_token(self):
            // self.ensure_one()
            // return limited_field_access_token(self, "thumbnail", scope="binary")
            */
            return default;
        }

        protected async Task<IrAttachment> HasAttachmentsOwnershipInternalAsync(object attachment_tokens)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _has_attachments_ownership(self, attachment_tokens):
            // """ Checks if the current user has ownership of all attachments in the recordset.
            //     Ownership is defined as either:
            //     - Having 'write' access to the attachment.
            //     - Providing a valid, scoped 'attachment_ownership' access token.
            // 
            //     :param list attachment_tokens: A list of access tokens
            // """
            // attachment_tokens = attachment_tokens or ([None] * len(self))
            // if len(attachment_tokens) != len(self):
            //     raise UserError(_("An access token must be provided for each attachment."))
            // 
            // def is_owned(attachment, token):
            //     if not attachment.exists():
            //         return False
            //     if attachment.sudo(False).has_access("write"):
            //         return True
            //     return token and verify_limited_field_access_token(
            //         attachment, "id", token, scope="attachment_ownership"
            //     )
            // 
            // return all(is_owned(att, tok) for att, tok in zip(self, attachment_tokens, strict=True))
            */
            return default;
        }

        protected async Task<IrAttachment> InaccessibleComodelRecordsInternalAsync(List<Guid> model_and_ids, string operation)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _inaccessible_comodel_records(self, model_and_ids: dict[str, Collection[int]], operation: str):
            // # check access rights on the records
            // if self.env.su:
            //     return
            // for res_model, res_ids in model_and_ids.items():
            //     res_ids = OrderedSet(filter(None, res_ids))
            //     if not res_model or not res_ids:
            //         # nothing to check
            //         continue
            //     # forbid access to attachments linked to removed models as we do not
            //     # know what persmissions should be checked
            //     if res_model not in self.env:
            //         for res_id in res_ids:
            //             yield res_model, res_id
            //         continue
            //     records = self.env[res_model].browse(res_ids)
            //     if res_model == 'res.users' and len(records) == 1 and self.env.uid == records.id:
            //         # by default a user cannot write on itself, despite the list of writeable fields
            //         # e.g. in the case of a user inserting an image into his image signature
            //         # we need to bypass this check which would needlessly throw us away
            //         continue
            //     try:
            //         records = records._filtered_access(operation)
            //     except MissingError:
            //         records = records.exists()._filtered_access(operation)
            //     res_ids.difference_update(records._ids)
            //     for res_id in res_ids:
            //         yield res_model, res_id
            */
            return default;
        }

        protected async Task<IrAttachment> IndexDocxInternalAsync(object bin_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py) ---
            // def _index_docx(self, bin_data):
            // '''Index Microsoft .docx documents'''
            // buf = u""
            // f = io.BytesIO(bin_data)
            // if zipfile.is_zipfile(f):
            //     try:
            //         zf = zipfile.ZipFile(f)
            //         content = xml.dom.minidom.parseString(zf.read("word/document.xml"))
            //         for val in ["w:p", "w:h", "text:list"]:
            //             for element in content.getElementsByTagName(val):
            //                 buf += textToString(element) + "\n"
            //     except Exception:
            //         pass
            // return buf
            */
            return default;
        }

        protected async Task<IrAttachment> IndexInternalAsync(object bin_data, string file_type, object checksum)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py) ---
            // def _index(self, bin_data, mimetype, checksum=None):
            // if checksum:
            //     cached_content = index_content_cache.get(checksum)
            //     if cached_content:
            //         return cached_content
            // res = False
            // for ftype in FTYPES:
            //     buf = getattr(self, '_index_%s' % ftype)(bin_data)
            //     if buf:
            //         res = buf.replace('\x00', '')
            //         break
            // 
            // res = res or super(IrAttachment, self)._index(bin_data, mimetype, checksum=checksum)
            // if checksum:
            //     index_content_cache[checksum] = res
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _index(self, bin_data: bytes, file_type: str, checksum=None) -> str | None:
            // """ compute the index content of the given binary data.
            // This is a python implementation of the unix command 'strings'.
            // """
            // # compute index_content only for text type
            // if file_type and file_type.startswith('text/'):
            //     words = re.findall(rb"[\x20-\x7E]{4,}", bin_data)
            //     return b"\n".join(words).decode('ascii')
            // return None
            */
            return default;
        }

        protected async Task<IrAttachment> IndexOpendocInternalAsync(object bin_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py) ---
            // def _index_opendoc(self, bin_data):
            // '''Index OpenDocument documents (.odt, .ods...)'''
            // 
            // f = io.BytesIO(bin_data)
            // buf = []
            // MAX_COLUMN_REPEAT = 100
            // MAX_ROW_REPEAT = 50
            // main_namespaces = {
            //     'office': 'urn:oasis:names:tc:opendocument:xmlns:office:1.0',
            //     'text': 'urn:oasis:names:tc:opendocument:xmlns:text:1.0',
            //     'table': 'urn:oasis:names:tc:opendocument:xmlns:table:1.0',
            //     'manifest': 'urn:oasis:names:tc:opendocument:xmlns:manifest:1.0'
            // }
            // 
            // def extract_row(row):
            //     cells = []
            //     for cell in row.xpath('.//table:table-cell | .//table:covered-table-cell', namespaces=main_namespaces):
            //         repeat = cell.get(f'{{{main_namespaces["table"]}}}number-columns-repeated')
            //         repeat_count = min(int(repeat), MAX_COLUMN_REPEAT) if repeat and repeat.isdigit() else 1
            //         text_parts = cell.xpath('.//text:p//text()', namespaces=main_namespaces)
            //         cell_text = ' '.join(t.strip() for t in text_parts if t.strip())
            //         cells.extend([cell_text] * repeat_count)
            //     return cells
            // 
            // def extract_spreadsheet(content):
            //     sheets_csv = []
            //     tables = content.xpath('.//table:table', namespaces=main_namespaces)
            //     for table in tables:
            //         table_rows = []
            //         table_name = table.get(f'{{{main_namespaces["table"]}}}name')
            //         if not table_name:
            //             table_name = f"Sheet{len(sheets_csv) + 1}"
            //         table_name_escaped = _csv_escape(table_name)
            //         for row in table.xpath('.//table:table-row', namespaces=main_namespaces):
            //             row_repeat = row.get(f'{{{main_namespaces["table"]}}}number-rows-repeated')
            //             row_repeat_count = min(int(row_repeat), MAX_ROW_REPEAT) if row_repeat and row_repeat.isdigit() else 1
            // 
            //             cells = extract_row(row)
            //             if not any(cells):
            //                 continue
            // 
            //             while cells and not cells[-1]:
            //                 cells.pop()
            // 
            //             row_str = ','.join([table_name_escaped] + list(map(_csv_escape, cells)))
            //             if row_str.replace(',', '').strip():
            //                 table_rows.extend([row_str] * row_repeat_count)
            // 
            //         if table_rows:
            //             sheets_csv.append('\n'.join(table_rows))
            // 
            //     return sheets_csv
            // 
            // def extract_text(content):
            //     lines = []
            //     for element in content.xpath('.//text:p | .//text:h | .//text:list-item', namespaces=main_namespaces):
            //         text = ''.join(element.xpath('.//text()', namespaces=main_namespaces)).strip()
            //         if text:
            //             lines.append(text)
            //     return lines
            // 
            // if zipfile.is_zipfile(f):
            //     try:
            //         zf = zipfile.ZipFile(f)
            //         content = etree.fromstring(zf.read('content.xml'))
            //         mime_type = zf.read('mimetype').decode('utf-8').strip()
            //         if mime_type and 'spreadsheet' in mime_type:
            //             buf.extend(extract_spreadsheet(content))
            //         else:
            //             buf.extend(extract_text(content))
            //     except Exception:
            //         pass
            // 
            // buf_str = '\n\n'.join(buf)
            // return _clean_text_content(buf_str)
            */
            return default;
        }

        protected async Task<IrAttachment> IndexPdfInternalAsync(object bin_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py) ---
            // def _index_pdf(self, bin_data):
            // '''Index PDF documents'''
            // if not bin_data.startswith(b'%PDF-'):
            //     return ""
            // try:
            //     if not importlib.util.find_spec('pdfminer.high_level'):
            //         return ""
            //     from pdfminer.pdfinterp import PDFResourceManager, PDFPageInterpreter  # noqa: PLC0415
            //     from pdfminer.converter import TextConverter  # noqa: PLC0415
            //     from pdfminer.layout import LAParams  # noqa: PLC0415
            //     from pdfminer.pdfpage import PDFPage  # noqa: PLC0415
            //     logging.getLogger("pdfminer").setLevel(logging.CRITICAL)
            // except ImportError:
            //     # warned already during init of module
            //     return ""
            // f = io.BytesIO(bin_data)
            // try:
            //     resource_manager = PDFResourceManager()
            //     laparams = LAParams(detect_vertical=True)
            // 
            //     with io.StringIO() as content, TextConverter(
            //         resource_manager,
            //         content,
            //         laparams=laparams
            //     ) as device:
            //         interpreter = PDFPageInterpreter(resource_manager, device)
            //         for page in PDFPage.get_pages(f):
            //             interpreter.process_page(page)
            // 
            //         buf = content.getvalue()
            //     return _clean_text_content(buf)
            // except Exception:  # noqa: BLE001
            //     return ""
            */
            return default;
        }

        protected async Task<IrAttachment> IndexPptxInternalAsync(object bin_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py) ---
            // def _index_pptx(self, bin_data):
            // '''Index Microsoft .pptx documents'''
            // 
            // buf = u""
            // f = io.BytesIO(bin_data)
            // if zipfile.is_zipfile(f):
            //     try:
            //         zf = zipfile.ZipFile(f)
            //         zf_filelist = [x for x in zf.namelist() if x.startswith('ppt/slides/slide')]
            //         for i in range(1, len(zf_filelist) + 1):
            //             content = xml.dom.minidom.parseString(zf.read('ppt/slides/slide%s.xml' % i))
            //             for val in ["a:t"]:
            //                 for element in content.getElementsByTagName(val):
            //                     buf += textToString(element) + "\n"
            //     except Exception:
            //         pass
            // return buf
            */
            return default;
        }

        protected async Task<IrAttachment> IndexXlsxInternalAsync(object bin_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py) ---
            // def _index_xlsx(self, bin_data):
            // '''Index Microsoft .xlsx documents'''
            // 
            // try:
            //     from openpyxl import load_workbook  # noqa: PLC0415
            //     logging.getLogger("openpyxl").setLevel(logging.CRITICAL)
            // except ImportError:
            //     _logger.info('openpyxl is not installed.')
            //     return ""
            // 
            // f = io.BytesIO(bin_data)
            // all_sheets = []
            // try:
            //     with warnings.catch_warnings():
            //         warnings.simplefilter("ignore")
            //         workbook = load_workbook(f, data_only=True, read_only=True)
            //         for sheet in workbook.worksheets:
            //             sheet_name = sheet.title
            //             sheet_name_escaped = _csv_escape(sheet_name)
            //             sheet_rows = []
            //             for row in sheet.iter_rows(values_only=True):
            //                 if not any(row):
            //                     continue
            //                 row_cells = [sheet_name_escaped] + [
            //                     _csv_escape(str(cell) if cell is not None else '') for cell in row
            //                 ]
            //                 sheet_rows.append(','.join(row_cells))
            //             sheet_data = '\n'.join(sheet_rows)
            //             if sheet_data:
            //                 all_sheets.append(sheet_data)
            // except Exception:  # noqa: BLE001
            //     pass
            // 
            // all_sheets_str = '\n\n'.join(all_sheets)
            // return _clean_text_content(all_sheets_str)
            */
            return default;
        }

        public async Task<IrAttachment> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: ir_attachment.py) ---
            // def init(self):
            // if self.env.registry.has_trigram:
            //     indexed_field = SQL('UNACCENT(index_content)') if self.env.registry.has_unaccent else SQL('index_content')
            // 
            //     self.env.cr.execute(SQL('''
            //         CREATE INDEX IF NOT EXISTS ir_attachment_index_content_applicant_trgm_idx
            //             ON ir_attachment USING gin (%(indexed_field)s gin_trgm_ops)
            //          WHERE res_model = 'hr.applicant'
            //     ''', indexed_field=indexed_field))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrAttachment> InverseDatasInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _inverse_datas(self):
            // self._set_attachment_data(lambda attach: base64.b64decode(attach.datas or b''))
            */
            return default;
        }

        protected async Task<IrAttachment> InverseRawInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _inverse_raw(self):
            // self._set_attachment_data(lambda a: a.raw or b'')
            */
            return default;
        }

        protected async Task<IrAttachment> IsRemoteSourceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _is_remote_source(self):
            // self.ensure_one()
            // return self.url and not self.file_size and self.url.startswith(('http://', 'https://', 'ftp://'))
            */
            return default;
        }

        protected async Task<IrAttachment> MarkForGcInternalAsync(object fname)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _mark_for_gc(self, fname):
            // """ Add ``fname`` in a checklist for the filestore garbage collection. """
            // assert isinstance(self, IrAttachment)
            // fname = re.sub('[.:]', '', fname).strip('/\\')
            // # we use a spooldir: add an empty file in the subdirectory 'checklist'
            // full_path = os.path.join(self._full_path('checklist'), fname)
            // if not os.path.exists(full_path):
            //     dirname = os.path.dirname(full_path)
            //     if not os.path.isdir(dirname):
            //         with contextlib.suppress(OSError):
            //             os.makedirs(dirname)
            //     open(full_path, 'ab').close()
            */
            return default;
        }

        protected async Task<IrAttachment> MigrateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _migrate(self):
            // record_count = len(self)
            // storage = self._storage().upper()
            // for index, attach in enumerate(self):
            //     _logger.debug("Migrate attachment %s/%s to %s", index + 1, record_count, storage)
            //     # pass mimetype, to avoid recomputation
            //     attach.write({'raw': attach.raw, 'mimetype': attach.mimetype})
            */
            return default;
        }

        protected async Task<IrAttachment> MigrateLocalToCloudStorageInternalAsync(object session)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage_migration, FILE: ir_attachment.py) ---
            // def _migrate_local_to_cloud_storage(self, session):
            // """Migrate attachment from local binary storage to cloud storage"""
            // if self.type != 'binary':
            //     raise ValidationError(_("Attachment (%s) is not a binary attachment and cannot be migrated to cloud storage.", self.id))
            // if not self.store_fname:
            //     raise ValidationError(_("Attachment (%s) does not have a stored filename and cannot be migrated to cloud storage.", self.id))
            // filepath = self._full_path(self.store_fname)
            // self.url = self._generate_cloud_storage_url()
            // upload_info = self._generate_cloud_storage_upload_info()
            // headers = upload_info.get('headers')
            // with open(filepath, 'rb') as f:
            //     # upload rate limit can be set by nginx proxy for
            //     # google cloud storage or azure blob storage by url matching
            //     response = session.request(upload_info['method'], upload_info['url'], data=f, headers=headers, timeout=(10, 30))
            //     if response.status_code != upload_info['response_status']:
            //         raise ValidationError(_('Failed to upload attachment %(id)s to cloud storage: %(code)s', id=self.id, code=response.status_code))
            // self.write({
            //     'type': 'cloud_storage',
            //     'mimetype': self.mimetype,  # force kept the mimetype
            //     'raw': False,
            // })
            */
            return default;
        }

        protected async Task<IrAttachment> MigrateRemoteToLocalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py) ---
            // def _migrate_remote_to_local(self):
            // if self.type != 'cloud_storage':
            //     return super()._migrate_remote_to_local()
            // url = self._generate_cloud_storage_download_info()['url']
            // response = requests.get(url, timeout=10)
            // response.raise_for_status()
            // if response.status_code != 200:
            //     raise ValidationError(_(
            //         "Failed to download attachment (%(id)s) from cloud: %(code)s - %(reason)s",
            //         id=self.id, code=response.status_code, reason=response.reason,
            //     ))
            // attachment_data = response.content
            // _logger.info("Migrating attachment (%s) with url (%s) from cloud_storage to binary.", self.id, self.url)
            // self.write({
            //     'type': 'binary',
            //     'url': False,
            //     'raw': attachment_data,
            // })
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _migrate_remote_to_local(self):
            // if self.type == 'binary':
            //     return
            // if self.type == 'url':
            //     raise ValidationError(_("URL attachment (%s) shouldn't be migrated to local.", self.id))
            */
            return default;
        }

        protected async Task<IrAttachment> PostAddCreateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_attachment.py) ---
            // def _post_add_create(self, **kwargs):
            // for move_id, attachments in self.filtered(lambda attachment: attachment.res_model == 'account.move').grouped('res_id').items():
            //     move = self.env['account.move'].browse(move_id)
            //     files_data = move._to_files_data(attachments)
            //     files_data.extend(move._unwrap_attachments(files_data))
            //     move._extend_with_attachments(files_data)
            // super()._post_add_create(**kwargs)
            --- ODOO METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py) ---
            // def _post_add_create(self, **kwargs):
            // super()._post_add_create(**kwargs)
            // if kwargs.get('cloud_storage'):
            //     if not self.env['ir.config_parameter'].sudo().get_param('cloud_storage_provider'):
            //         raise UserError(_('Cloud Storage is not enabled'))
            //     for record in self:
            //         record.write({
            //             'raw': False,
            //             'type': 'cloud_storage',
            //             'url': record._generate_cloud_storage_url(),
            //         })
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _post_add_create(self, **kwargs):
            // super()._post_add_create(**kwargs)
            // if kwargs.get('voice'):
            //     self._set_voice_metadata()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _post_add_create(self, **kwargs):
            // """ Overrides behaviour when the attachment is created through the controller
            // """
            // super()._post_add_create(**kwargs)
            // self.register_as_main_attachment(force=False)
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: ir_attachment.py) ---
            // def _post_add_create(self, **kwargs):
            // super()._post_add_create(**kwargs)
            // if self.res_model == "mrp.bom":
            //     bom = self.env['mrp.bom'].browse(self.res_id)
            //     self.res_model = bom.product_id._name if bom.product_id else bom.product_tmpl_id._name
            //     self.res_id = bom.product_id.id if bom.product_id else bom.product_tmpl_id.id
            //     self.env['product.document'].create({
            //         'ir_attachment_id': self.id,
            //         'attached_on_mrp': 'bom'
            //     })
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _post_add_create(self, **kwargs):
            // # TODO master: rename to _post_upload, better indicating its usage
            // pass
            */
            return default;
        }

        protected async Task<IrAttachment> PostprocessContentsInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _postprocess_contents(self, values):
            // ICP = self.env['ir.config_parameter'].sudo().get_param
            // supported_subtype = ICP('base.image_autoresize_extensions', 'png,jpeg,bmp,tiff').split(',')
            // 
            // mimetype = values['mimetype'] = self._compute_mimetype(values)
            // _type, _match, _subtype = mimetype.partition('/')
            // is_image_resizable = _type == 'image' and _subtype in supported_subtype
            // if is_image_resizable and (values.get('datas') or values.get('raw')):
            //     is_raw = values.get('raw')
            // 
            //     # Can be set to 0 to skip the resize
            //     max_resolution = ICP('base.image_autoresize_max_px', '1920x1920')
            //     if str2bool(max_resolution, True):
            //         try:
            //             if is_raw:
            //                 img = image.ImageProcess(values['raw'], verify_resolution=False)
            //             else:  # datas
            //                 img = image.ImageProcess(base64.b64decode(values['datas']), verify_resolution=False)
            // 
            //             if not img.image:
            //                 _logger.info('Post processing ignored : Empty source, SVG, or WEBP')
            //                 return values
            // 
            //             w, h = img.image.size
            //             nw, nh = map(int, max_resolution.split('x'))
            //             if w > nw or h > nh:
            //                 img = img.resize(nw, nh)
            //                 if _subtype == 'jpeg':  # Do not affect PNGs color palette
            //                     quality = int(ICP('base.image_autoresize_quality', 80))
            //                 else:
            //                     quality = 0
            //                 image_data = img.image_quality(quality=quality)
            //                 if is_raw:
            //                     values['raw'] = image_data
            //                 else:
            //                     values['datas'] = base64.b64encode(image_data)
            //         except UserError as e:
            //             # Catch error during test where we provide fake image
            //             # raise UserError(_("This file could not be decoded as an image file. Please try with a different file."))
            //             msg = str(e)  # the exception can be lazy-translated, resolve it here
            //             _logger.info('Post processing ignored : %s', msg)
            // return values
            */
            return default;
        }

        public async Task<IrAttachment> PreviewAttachmentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_fleet, FILE: ir_attachment.py) ---
            // def action_preview_attachment(self):
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': '/web/content/%s/%s' % (self.id, self.name),
            //     'target': 'new',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrAttachment> RegenerateAssetsBundlesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def regenerate_assets_bundles(self):
            // self.search([
            //     ('public', '=', True),
            //     ("url", "=like", "/web/assets/%"),
            //     ('res_model', '=', 'ir.ui.view'),
            //     ('res_id', '=', 0),
            //     ('create_uid', '=', api.SUPERUSER_ID),
            // ]).unlink()
            // self.env.registry.clear_cache('assets')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrAttachment> RegisterAsMainAttachmentAsync(Guid id, IrAttachmentRegisterAsMainAttachmentRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def register_as_main_attachment(self, force=True):
            // """ Registers this attachment as the main one of the model it is
            // attached to.
            // 
            // :param bool force: if set, the method always updates the existing main attachment
            //     otherwise it only sets the main attachment if there is none.
            // """
            // todo = self.filtered(lambda a: a.res_model and a.res_id)
            // if not todo:
            //     return
            // 
            // for model, attachments in todo.grouped("res_model").items():
            //     related_records = self.env[model].browse(attachments.mapped("res_id"))
            //     if not hasattr(related_records, '_message_set_main_attachment_id'):
            //         return
            // 
            //     # this action is generic; if user cannot update record do not crash
            //     # just skip update
            //     for related_record, attachment in zip(related_records, attachments):
            //         with contextlib.suppress(AccessError):
            //             related_record._message_set_main_attachment_id(attachment, force=force)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrAttachment> SameContentInternalAsync(object bin_data, object filepath)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _same_content(self, bin_data, filepath):
            // BLOCK_SIZE = 1024
            // with open(filepath, 'rb') as fd:
            //     i = 0
            //     while True:
            //         data = fd.read(BLOCK_SIZE)
            //         if data != bin_data[i * BLOCK_SIZE:(i + 1) * BLOCK_SIZE]:
            //             return False
            //         if not data:
            //             break
            //         i += 1
            // return True
            */
            return default;
        }

        protected async Task<IrAttachment> SearchInternalAsync(object domain, object offset, object limit, object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _search(self, domain, offset=0, limit=None, order=None, *, active_test=True, bypass_access=False):
            // assert not self._active_name, "active name not supported on ir.attachment"
            // disable_binary_fields_attachments = False
            // domain = Domain(domain)
            // if (
            //     not self.env.context.get('skip_res_field_check')
            //     and not any(d.field_expr in ('id', 'res_field') for d in domain.iter_conditions())
            //     and not bypass_access
            // ):
            //     disable_binary_fields_attachments = True
            //     domain &= Domain('res_field', '=', False)
            // 
            // domain = domain.optimize(self)
            // if self.env.su or bypass_access or domain.is_false():
            //     return super()._search(domain, offset, limit, order, active_test=active_test, bypass_access=bypass_access)
            // 
            // # General access rules
            // # - public == True are always accessible
            // sec_domain = Domain('public', '=', True)
            // # - res_id == False needs to be system user or creator
            // res_ids = condition_values(self, 'res_id', domain)
            // if not res_ids or False in res_ids:
            //     if self.env.is_system():
            //         sec_domain |= Domain('res_id', '=', False)
            //     else:
            //         sec_domain |= Domain('res_id', '=', False) & Domain('create_uid', '=', self.env.uid)
            // 
            // # Search by res_model and res_id, filter using permissions from res_model
            // # - res_id != False needs then check access on the linked res_model record
            // # - res_field != False needs to check field access on the res_model
            // res_model_names = condition_values(self, 'res_model', domain)
            // if 0 < len(res_model_names or ()) <= 5:
            //     env = self.with_context(active_test=False).env
            //     for res_model_name in res_model_names:
            //         comodel = env.get(res_model_name)
            //         if comodel is None:
            //             continue
            //         codomain = Domain('res_model', '=', comodel._name)
            //         comodel_res_ids = condition_values(self, 'res_id', domain.map_conditions(
            //             lambda cond: codomain & cond if cond.field_expr == 'res_model' else cond
            //         ))
            //         query = comodel._search(Domain('id', 'in', comodel_res_ids) if comodel_res_ids else Domain.TRUE)
            //         if query.is_empty():
            //             continue
            //         if query.where_clause:
            //             codomain &= Domain('res_id', 'in', query)
            //         if not disable_binary_fields_attachments and not self.env.is_system():
            //             accessible_fields = [
            //                 field.name
            //                 for field in comodel._fields.values()
            //                 if field.type == 'binary' or (field.relational and field.comodel_name == self._name)
            //                 if comodel._has_field_access(field, 'read')
            //             ]
            //             accessible_fields.append(False)
            //             codomain &= Domain('res_field', 'in', accessible_fields)
            //         sec_domain |= codomain
            // 
            //     return super()._search(domain & sec_domain, offset, limit, order, active_test=active_test)
            // 
            // # We do not have a small restriction on res_model. We still need to
            // # support other queries such as: `('id', 'in' ...)`.
            // # Restrict with domain and add all attachments linked to a model.
            // domain &= sec_domain | Domain('res_model', '!=', False)
            // domain = domain.optimize_full(self)
            // ordered = bool(order)
            // if limit is None:
            //     records = self.sudo().with_context(active_test=False).search_fetch(
            //         domain, SECURITY_FIELDS, order=order).sudo(False)
            //     return records._filtered_access('read')[offset:]._as_query(ordered)
            // # Fetch by small batches
            // sub_offset = 0
            // limit += offset
            // result = []
            // if not ordered:
            //     # By default, order by model to batch access checks.
            //     order = 'res_model nulls first, id'
            // while len(result) < limit:
            //     records = self.sudo().with_context(active_test=False).search_fetch(
            //         domain,
            //         SECURITY_FIELDS,
            //         offset=sub_offset,
            //         limit=PREFETCH_MAX,
            //         order=order,
            //     ).sudo(False)
            //     result.extend(records._filtered_access('read')._ids)
            //     if len(records) < PREFETCH_MAX:
            //         # There are no more records
            //         break
            //     sub_offset += PREFETCH_MAX
            // return self.browse(result[offset:limit])._as_query(ordered)
            */
            return default;
        }

        protected async Task<IrAttachment> SetAttachmentDataInternalAsync(object asbytes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _set_attachment_data(self, asbytes):
            // old_fnames = []
            // checksum_raw_map = {}
            // 
            // for attach in self:
            //     # compute the fields that depend on datas
            //     bin_data = asbytes(attach)
            //     vals = self._get_datas_related_values(bin_data, attach.mimetype)
            //     if bin_data:
            //         checksum_raw_map[vals['checksum']] = bin_data
            // 
            //     # take current location in filestore to possibly garbage-collect it
            //     if attach.store_fname:
            //         old_fnames.append(attach.store_fname)
            // 
            //     # write as superuser, as user probably does not have write access
            //     super(IrAttachment, attach.sudo()).write(vals)
            // 
            // if self._storage() != 'db':
            //     # before touching the filestore, flush to prevent the GC from
            //     # running until the end of the transaction
            //     self.flush_recordset(['checksum', 'store_fname'])
            //     for fname in old_fnames:
            //         self._file_delete(fname)
            //     for checksum, raw in checksum_raw_map.items():
            //         self._file_write(raw, checksum)
            */
            return default;
        }

        protected async Task<IrAttachment> SetVoiceMetadataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _set_voice_metadata(self):
            // self.env["discuss.voice.metadata"].create([{"attachment_id": att.id} for att in self])
            */
            return default;
        }

        protected async Task<IrAttachment> StorageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _storage(self):
            // return self.env['ir.config_parameter'].sudo().get_param('ir_attachment.location', 'file')
            */
            return default;
        }

        protected async Task<IrAttachment> ToHttpStreamInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: cloud_storage, FILE: ir_attachment.py) ---
            // def _to_http_stream(self):
            // if (self.type == 'cloud_storage' and
            //       self.env['res.config.settings']._get_cloud_storage_configuration()):
            //     self.ensure_one()
            //     info = self._generate_cloud_storage_download_info()
            //     stream = Stream(type='url', url=info['url'])
            //     if 'time_to_expiry' in info:
            //         # cache the redirection until 10 seconds before the expiry
            //         stream.max_age = max(info['time_to_expiry'] - 10, 0)
            //     return stream
            // return super()._to_http_stream()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _to_http_stream(self):
            // """ Create a :class:`~Stream`: from an ir.attachment record. """
            // self.ensure_one()
            // 
            // stream = Stream(
            //     mimetype=self.mimetype,
            //     download_name=self.name,
            //     etag=self.checksum,
            //     public=self.public,
            // )
            // 
            // if self.store_fname:
            //     stream.type = 'path'
            //     stream.path = werkzeug.security.safe_join(
            //         os.path.abspath(config.filestore(request.db)),
            //         self.store_fname
            //     )
            //     stat = os.stat(stream.path)
            //     stream.last_modified = stat.st_mtime
            //     stream.size = stat.st_size
            // 
            // elif self.db_datas:
            //     stream.type = 'data'
            //     stream.data = self.raw
            //     stream.last_modified = self.write_date
            //     stream.size = len(stream.data)
            // 
            // elif self.url:
            //     # When the URL targets a file located in an addon, assume it
            //     # is a path to the resource. It saves an indirection and
            //     # stream the file right away.
            //     static_path = root.get_static_file(
            //         self.url,
            //         host=request.httprequest.environ.get('HTTP_HOST', '')
            //     )
            //     if static_path:
            //         stream = Stream.from_path(static_path, public=True)
            //     else:
            //         stream.type = 'url'
            //         stream.url = self.url
            // 
            // else:
            //     stream.type = 'data'
            //     stream.data = b''
            //     stream.size = 0
            // 
            // return stream
            */
            return default;
        }

        protected async Task<IrAttachment> ToStoreDefaultsInternalAsync(object target)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _to_store_defaults(self, target):
            // # sudo: discuss.voice.metadata - checking the existence of voice metadata for accessible
            // # attachments is fine
            // return super()._to_store_defaults(target) + [Store.Many("voice_ids", [], sudo=True)]
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _to_store_defaults(self, target):
            // return [
            //     "checksum",
            //     "create_date",
            //     "file_size",
            //     "has_thumbnail",
            //     "mimetype",
            //     "name",
            //     Store.Attr("raw_access_token", lambda a: a._get_raw_access_token()),
            //     "res_name",
            //     Store.One("thread", [], as_thread=True),
            //     Store.Attr("thumbnail_access_token", lambda a: a._get_thumbnail_token()),
            //     "type",
            //     "url",
            // ]
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_attachment.py) ---
            // def unlink(self):
            // invoice_pdf_attachments = self.filtered(lambda attachment:
            //     attachment.res_model == 'account.move'
            //     and attachment.res_id
            //     and attachment.res_field in ('invoice_pdf_report_file', 'ubl_cii_xml_file')
            //     and attachment.company_id.restrictive_audit_trail
            // )
            // if invoice_pdf_attachments:
            //     # only detach the document from the field, but keep it in the database for the audit trail
            //     # it shouldn't be an issue as there aren't any security group on the fields as it is the public report
            //     invoice_pdf_attachments.res_field = False
            //     today = format_date(self.env, fields.Date.context_today(self))
            //     for attachment in invoice_pdf_attachments:
            //         attachment_name = attachment.name
            //         attachment_extension = ''
            //         dot_index = attachment_name.rfind('.')
            //         if dot_index > 0:
            //             attachment_name = attachment.name[:dot_index]
            //             attachment_extension = attachment.name[dot_index:]
            //         attachment.name = _(
            //             '%(attachment_name)s (detached by %(user)s on %(date)s)%(attachment_extension)s',
            //             attachment_name=attachment_name,
            //             attachment_extension=attachment_extension,
            //             user=self.env.user.name,
            //             date=today,
            //         )
            // return super(IrAttachment, self - invoice_pdf_attachments).unlink()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def unlink(self):
            // # First delete in the database, *then* in the filesystem if the
            // # database allowed it. Helps avoid errors when concurrent transactions
            // # are deleting the same file, and some of the transactions are
            // # rolled back by PostgreSQL (due to concurrent updates detection).
            // to_delete = OrderedSet(attach.store_fname for attach in self if attach.store_fname)
            // res = super().unlink()
            // for file_path in to_delete:
            //     self._file_delete(file_path)
            // 
            // return res
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<IrAttachment> UnlinkExceptGovernmentDocumentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_edi, FILE: ir_attachment.py) ---
            // def _unlink_except_government_document(self):
            // # sudo: account.edi.document - constraint that must be applied regardless of ACL
            // linked_edi_documents = self.env['account.edi.document'].sudo().search([('attachment_id', 'in', self.ids)])
            // linked_edi_formats_ws = linked_edi_documents.edi_format_id.filtered(lambda edi_format: edi_format._needs_web_services())
            // if linked_edi_formats_ws:
            //     raise UserError(_("You can't unlink an attachment being an EDI document sent to the government."))
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, IrAttachment entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_attachment.py) ---
            // def write(self, vals):
            // if vals.keys() & {'res_id', 'res_model', 'raw', 'datas', 'store_fname', 'db_datas', 'company_id'}:
            //     try:
            //         self._except_audit_trail()
            //     except UserError as e:
            //         if (
            //             not hasattr(e, '_audit_trail')
            //             or vals.get('res_model') != 'documents.document'
            //             or vals.keys() & {'raw', 'datas', 'store_fname', 'db_datas'}
            //         ):
            //             raise  # do not raise if trying to version the attachment through a document
            //         vals.pop('res_model', None)
            //         vals.pop('res_id', None)
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def write(self, vals):
            // self.check_access('write')
            // if vals.get('res_model') or vals.get('res_id'):
            //     model_and_ids = defaultdict(OrderedSet)
            //     if 'res_model' in vals and 'res_id' in vals:
            //         model_and_ids[vals['res_model']].add(vals['res_id'])
            //     else:
            //         for record in self:
            //             model_and_ids[vals.get('res_model', record.res_model)].add(vals.get('res_id', record.res_id))
            //     if any(self._inaccessible_comodel_records(model_and_ids, 'write')):
            //         raise AccessError(_("Sorry, you are not allowed to access this document."))
            // # remove computed field depending of datas
            // for field in ('file_size', 'checksum', 'store_fname'):
            //     vals.pop(field, False)
            // if 'mimetype' in vals or 'datas' in vals or 'raw' in vals:
            //     vals = self._check_contents(vals)
            // res = super().write(vals)
            // if 'url' in vals or 'type' in vals:
            //     self._check_serving_attachments()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}