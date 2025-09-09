using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule")]
    public class IrAttachmentAppService : GenericApplicationService<IrAttachment>, IIrAttachmentAppService
    {
        private readonly IBusListenerMixinAppService _busListenerMixinAppService;
        public IrAttachmentAppService(IRepository<IrAttachment, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IBusListenerMixinAppService busListenerMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _busListenerMixinAppService = busListenerMixinAppService;
        }

        protected async Task<IrAttachment> AutoInitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _auto_init(self):
            // res = super(IrAttachment, self)._auto_init()
            // tools.create_index(self._cr, 'ir_attachment_res_idx',
            //                    self._table, ['res_model', 'res_id'])
            // return res
            */
            return default;
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
            // return self.env.user._bus_channel()
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _bus_channel(self):
            // self.ensure_one()
            // if self.res_model == "discuss.channel" and self.res_id:
            //     return self.env["discuss.channel"].browse(self.res_id)._bus_channel()
            // guest = self.env["mail.guest"]._get_guest_from_context()
            // if self.env.user._is_public() and guest:
            //     return guest._bus_channel()
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

        public async Task<IrAttachment> CheckAsync(Guid id, IrAttachmentCheckRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def check(self, mode, values=None):
            // """ Restricts the access to an ir.attachment, according to referred mode """
            // if self.env.is_superuser():
            //     return True
            // # Always require an internal user (aka, employee) to access to a attachment
            // if not (self.env.is_admin() or self.env.user._is_internal()):
            //     raise AccessError(_("Sorry, you are not allowed to access this document."))
            // # collect the records to check (by model)
            // model_ids = defaultdict(set)            # {model_name: set(ids)}
            // if self:
            //     # DLE P173: `test_01_portal_attachment`
            //     self.env['ir.attachment'].flush_model(['res_model', 'res_id', 'create_uid', 'public', 'res_field'])
            //     self._cr.execute('SELECT res_model, res_id, create_uid, public, res_field FROM ir_attachment WHERE id IN %s', [tuple(self.ids)])
            //     for res_model, res_id, create_uid, public, res_field in self._cr.fetchall():
            //         if public and mode == 'read':
            //             continue
            //         if not self.env.is_system():
            //             if not res_id and create_uid != self.env.uid:
            //                 raise AccessError(_("Sorry, you are not allowed to access this document."))
            //             if res_field:
            //                 field = self.env[res_model]._fields[res_field]
            //                 if not field.is_accessible(self.env):
            //                     raise AccessError(_("Sorry, you are not allowed to access this document."))
            //         if not (res_model and res_id):
            //             continue
            //         model_ids[res_model].add(res_id)
            // if values and values.get('res_model') and values.get('res_id'):
            //     model_ids[values['res_model']].add(values['res_id'])
            // 
            // # check access rights on the records
            // for res_model, res_ids in model_ids.items():
            //     # ignore attachments that are not attached to a resource anymore
            //     # when checking access rights (resource was deleted but attachment
            //     # was not)
            //     if res_model not in self.env:
            //         continue
            //     if res_model == 'res.users' and len(res_ids) == 1 and self.env.uid == list(res_ids)[0]:
            //         # by default a user cannot write on itself, despite the list of writeable fields
            //         # e.g. in the case of a user inserting an image into his image signature
            //         # we need to bypass this check which would needlessly throw us away
            //         continue
            //     records = self.env[res_model].browse(res_ids).exists()
            //     # For related models, check if we can write to the model, as unlinking
            //     # and creating attachments can be seen as an update to the model
            //     access_mode = 'write' if mode in ('create', 'unlink') else mode
            //     records.check_access(access_mode)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrAttachment> CheckAttachmentsAccessInternalAsync(object attachment_tokens)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _check_attachments_access(self, attachment_tokens):
            // """This method relies on access rules/rights and therefore it should not be called from a sudo env."""
            // self = self.sudo(False)
            // attachment_tokens = attachment_tokens or ([None] * len(self))
            // if len(attachment_tokens) != len(self):
            //     raise UserError(_("An access token must be provided for each attachment."))
            // for attachment, access_token in zip(self, attachment_tokens):
            //     try:
            //         attachment_sudo = attachment.with_user(SUPERUSER_ID).exists()
            //         if not attachment_sudo:
            //             raise MissingError(_("The attachment %s does not exist.", attachment.id))
            //         try:
            //             attachment.check('write')
            //         except AccessError:
            //             if not access_token or not attachment_sudo.access_token or not consteq(attachment_sudo.access_token, access_token):
            //                 message_sudo = self.env['mail.message'].sudo().search([('attachment_ids', 'in', attachment_sudo.ids)], limit=1)
            //                 if not message_sudo or not message_sudo.is_current_user_or_guest_author:
            //                     raise
            //     except (AccessError, MissingError):
            //         raise UserError(_("The attachment %s does not exist or you do not have the rights to access it.", attachment.id))
            */
            return default;
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
            //     # XDO note: this should be done in check(write), constraints for access rights?
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
            // if self._context.get('bin_size'):
            //     for attach in self:
            //         attach.datas = human_size(attach.file_size)
            //     return
            // 
            // for attach in self:
            //     attach.datas = base64.b64encode(attach.raw or b'')
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
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: ir_attachment.py) ---
            // def create(self, vals_list):
            // attachments = super().create(vals_list)
            // if self.env.context.get('sync_attachment', True):
            //     expenses_attachments = attachments.filtered(lambda att: att.res_model == 'hr.expense')
            //     if expenses_attachments:
            //         expenses = self.env['hr.expense'].browse(expenses_attachments.mapped('res_id'))
            //         for expense in expenses.filtered('sheet_id'):
            //             checksums = set(expense.sheet_id.attachment_ids.mapped('checksum'))
            //             for attachment in expense.attachment_ids.filtered(lambda att: att.checksum not in checksums):
            //                 attachment.copy({
            //                     'res_model': 'hr.expense.sheet',
            //                     'res_id': expense.sheet_id.id,
            //                 })
            // return attachments
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
            //         self.env['product.document'].sudo().create(
            //             {
            //                 'ir_attachment_id': attachment.id
            //             } for attachment in product_attachments
            //         )
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
            // 
            // for values in vals_list:
            //     values = self._check_contents(values)
            //     raw, datas = values.pop('raw', None), values.pop('datas', None)
            //     if raw or datas:
            //         if isinstance(raw, str):
            //             # b64decode handles str input but raw needs explicit encoding
            //             raw = raw.encode()
            //         values.update(self._get_datas_related_values(
            //             raw or base64.b64decode(datas or b''),
            //             values['mimetype']
            //         ))
            // 
            //     # 'check()' only uses res_model and res_id from values, and make an exists.
            //     # We can group the values by model, res_id to make only one query when
            //     # creating multiple attachments on a single record.
            //     record_tuple = (values.get('res_model'), values.get('res_id'))
            //     record_tuple_set.add(record_tuple)
            // 
            // # don't use possible contextual recordset for check, see commit for details
            // Attachments = self.browse()
            // for res_model, res_id in record_tuple_set:
            //     Attachments.check('create', values={'res_model':res_model, 'res_id':res_id})
            // return super().create(vals_list)
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

        protected async Task<IrAttachment> DecodeEdiBinaryInternalAsync(object filename, object content)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_attachment.py) ---
            // def _decode_edi_binary(self, filename, content):
            // """Decodes any file into a list of one dictionary representing an attachment.
            // This is a fallback for all files that are not decoded by other methods.
            // :returns:           A list with a dictionary.
            // """
            // return [{
            //     'filename': filename,
            //     'content': content,
            //     'attachment': self,
            //     'sort_weight': 100,
            //     'type': 'binary',
            // }]
            */
            return default;
        }

        protected async Task<IrAttachment> DecodeEdiPdfInternalAsync(object filename, object content)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_attachment.py) ---
            // def _decode_edi_pdf(self, filename, content):
            // """Decodes a pdf and unwrap sub-attachment into a list of dictionary each representing an attachment.
            // :returns:           A list of dictionary for each attachment.
            // """
            // try:
            //     buffer = io.BytesIO(content)
            //     pdf_reader = OdooPdfFileReader(buffer, strict=False)
            // except Exception as e:
            //     # Malformed pdf
            //     _logger.info('Error when reading the pdf file "%s": %s', filename, e)
            //     return []
            // 
            // # Process embedded files.
            // to_process = []
            // try:
            //     for xml_name, xml_content in pdf_reader.getAttachments():
            //         embedded_files = self.env['ir.attachment']._decode_edi_xml(xml_name, xml_content)
            //         for file_data in embedded_files:
            //             file_data['sort_weight'] += 1
            //             file_data['originator_pdf'] = self
            //         to_process.extend(embedded_files)
            // except (NotImplementedError, StructError, PdfReadError) as e:
            //     _logger.warning("Unable to access the attachments of %s. Tried to decrypt it, but %s.", filename, e)
            // 
            // # Process the pdf itself.
            // to_process.append({
            //     'filename': filename,
            //     'content': content,
            //     'pdf_reader': pdf_reader,
            //     'attachment': self,
            //     'on_close': buffer.close,
            //     'sort_weight': 20,
            //     'type': 'pdf',
            // })
            // 
            // return to_process
            */
            return default;
        }

        protected async Task<IrAttachment> DecodeEdiXmlInternalAsync(object filename, object content)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_attachment.py) ---
            // def _decode_edi_xml(self, filename, content):
            // """Decodes an xml into a list of one dictionary representing an attachment.
            // :returns:           A list with a dictionary.
            // """
            // try:
            //     xml_tree = etree.fromstring(content)
            // except Exception as e:
            //     _logger.info('Error when reading the xml file "%s": %s', filename, e)
            //     return []
            // 
            // to_process = []
            // if xml_tree is not None:
            //     to_process.append({
            //         'attachment': self,
            //         'filename': filename,
            //         'content': content,
            //         'xml_tree': xml_tree,
            //         'sort_weight': 10,
            //         'type': 'xml',
            //     })
            // return to_process
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

        protected async Task<IrAttachment> FileReadInternalAsync(object fname)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _file_read(self, fname):
            // assert isinstance(self, IrAttachment)
            // full_path = self._full_path(fname)
            // try:
            //     with open(full_path, 'rb') as f:
            //         return f.read()
            // except (IOError, OSError):
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
            //     except IOError:
            //         _logger.info("_file_write writing %s", full_path, exc_info=True)
            // return fname
            */
            return default;
        }

        protected async Task<IrAttachment> FilestoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _filestore(self):
            // return config.filestore(self._cr.dbname)
            */
            return default;
        }

        protected async Task<IrAttachment> FilterAttachmentAccessInternalAsync(List<Guid> attachment_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _filter_attachment_access(self, attachment_ids):
            // """Filter the given attachment to return only the records the current user have access to.
            // 
            // :param attachment_ids: List of attachment ids we want to filter
            // :return: <ir.attachment> the current user have access to
            // """
            // ret_attachments = self.env['ir.attachment']
            // attachments = self.browse(attachment_ids)
            // if not attachments.has_access('read'):
            //     return ret_attachments
            // 
            // for attachment in attachments.sudo():
            //     # Use SUDO here to not raise an error during the prefetch
            //     # And then drop SUDO right to check if we can access it
            //     try:
            //         attachment.sudo(False).check('read')
            //         ret_attachments |= attachment
            //     except AccessError:
            //         continue
            // return ret_attachments
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
            // self.search(expression.AND([
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
            //     head = file.read(1024)
            //     file.seek(-len(head), 1)  # rewind
            //     mimetype = guess_mimetype(head)
            //     filename = fix_filename_extension(file.filename, mimetype)
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
            // path = re.sub('[.]', '', path)
            // path = path.strip('/\\')
            // return os.path.join(self._filestore(), path)
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
            // cr = self._cr
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
            // for names in self.env.cr.split_for_in_conditions(checklist):
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
            //             except (OSError, IOError):
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
            // :param attachment: an ir.attachment record
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
            // :param attachment: an ir.attachment record
            // :return: An download_info dictionary containing:
            //     * download_url: cloud storage url with permission to download the file
            //     * time_to_expiry: the time in seconds before the download url expires
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
            // :param attachment: an ir.attachment record
            // :return: An upload_info dictionary containing:
            //     * upload_url: cloud storage url with permission to upload the file
            //     * method: the request method used to upload the file
            //     * response_status: the status of the response for a successful
            //         upload request
            //     * [Optionally] headers: a dictionary of headers to be added to the
            //         upload request
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
            // :param attachment: an ir.attachment record
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
            // match = self._cloud_storage_azure_url_pattern.match(self.url or '')
            // if not match:
            //     raise ValidationError(f'"{self.url}" is not a valid Azure Blob Storage URL.')
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
            // match = self._cloud_storage_google_url_pattern.match(self.url)
            // if not match:
            //     raise ValidationError('%s is not a valid Google Cloud Storage URL.', self.url)
            // return {
            //     'bucket_name': match['bucket_name'],
            //     'blob_name': unquote(match['blob_name']),
            // }
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
            //     values['store_fname'] = self._file_write(data, values['checksum'])
            //     values['db_datas'] = False
            // return values
            */
            return default;
        }

        protected async Task<IrAttachment> GetEdiSupportedFormatsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_attachment.py) ---
            // def _get_edi_supported_formats(self):
            // """Get the list of supported formats.
            // This function is meant to be overriden to add formats.
            // 
            // :returns:           A list of dictionary.
            // 
            // * format:           Optional but helps debugging.
            //                     There are other methods that require the attachment
            //                     to be an XML other than the standard one.
            // * check:            Function to be called on the attachment to pre-check if decoding will work.
            // * decoder:          Function to be called on the attachment to unwrap it.
            // """
            // 
            // def is_xml(attachment):
            //     # XML attachments received by mail have a 'text/plain' mimetype (cfr. context key:
            //     # 'attachments_mime_plainxml'). Therefore, if content start with '<?xml', or if the filename ends with
            //     # '.xml', it is considered as XML.
            //     is_text_plain_xml = 'text/plain' in attachment.mimetype and (guess_mimetype(attachment.raw).endswith('/xml') or attachment.name.endswith('.xml'))
            //     return attachment.mimetype.endswith('/xml') or is_text_plain_xml
            // 
            // return [
            //     {
            //         'format': 'pdf',
            //         'check': lambda attachment: 'pdf' in attachment.mimetype,
            //         'decoder': self._decode_edi_pdf,
            //     },
            //     {
            //         'format': 'xml',
            //         'check': is_xml,
            //         'decoder': self._decode_edi_xml,
            //     },
            //     {
            //         'format': 'binary',
            //         'check': lambda attachment: True,
            //         'decoder': self._decode_edi_binary,
            //     },
            // ]
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
            // return super(Attachment, self).get_serving_groups() + ['website.group_website_designer']
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

        protected async Task<IrAttachment> IndexInternalAsync(object bin_data, object file_type, object checksum)
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
            // def _index(self, bin_data, file_type, checksum=None):
            // """ compute the index content of the given binary data.
            //     This is a python implementation of the unix command 'strings'.
            //     :param bin_data : datas in binary form
            //     :return index_content : string containing all the printable character of the binary data
            // """
            // index_content = False
            // if file_type:
            //     index_content = file_type.split('/')[0]
            //     if index_content == 'text': # compute index_content only for text type
            //         words = re.findall(b"[\x20-\x7E]{4,}", bin_data)
            //         index_content = b"\n".join(words).decode('ascii')
            // return index_content
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
            // buf = u""
            // f = io.BytesIO(bin_data)
            // if zipfile.is_zipfile(f):
            //     try:
            //         zf = zipfile.ZipFile(f)
            //         content = xml.dom.minidom.parseString(zf.read("content.xml"))
            //         for val in ["text:p", "text:h", "text:list"]:
            //             for element in content.getElementsByTagName(val):
            //                 buf += textToString(element) + "\n"
            //     except Exception:
            //         pass
            // return buf
            */
            return default;
        }

        protected async Task<IrAttachment> IndexPdfInternalAsync(object bin_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: attachment_indexation, FILE: ir_attachment.py) ---
            // def _index_pdf(self, bin_data):
            // '''Index PDF documents'''
            // if PDFResourceManager is None:
            //     return
            // buf = u""
            // if bin_data.startswith(b'%PDF-'):
            //     f = io.BytesIO(bin_data)
            //     try:
            //         resource_manager = PDFResourceManager()
            //         with io.StringIO() as content, TextConverter(resource_manager, content) as device:
            //             logging.getLogger("pdfminer").setLevel(logging.CRITICAL)
            //             interpreter = PDFPageInterpreter(resource_manager, device)
            // 
            //             for page in PDFPage.get_pages(f):
            //                 interpreter.process_page(page)
            // 
            //             buf = content.getvalue()
            //     except Exception:
            //         pass
            // return buf
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
            // buf = u""
            // f = io.BytesIO(bin_data)
            // if zipfile.is_zipfile(f):
            //     try:
            //         zf = zipfile.ZipFile(f)
            //         content = xml.dom.minidom.parseString(zf.read("xl/sharedStrings.xml"))
            //         for val in ["t"]:
            //             for element in content.getElementsByTagName(val):
            //                 buf += textToString(element) + "\n"
            //     except Exception:
            //         pass
            // return buf
            */
            return default;
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

        protected async Task<IrAttachment> MarkForGcInternalAsync(object fname)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _mark_for_gc(self, fname):
            // """ Add ``fname`` in a checklist for the filestore garbage collection. """
            // assert isinstance(self, IrAttachment)
            // fname = re.sub('[.]', '', fname).strip('/\\')
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
            // # When migrating to filestore verifying if the directory has write permission
            // if storage == 'FILE':
            //     filestore = self._filestore()
            //     if not os.access(filestore, os.W_OK):
            //         raise PermissionError("Write permission denied for filestore directory.")
            // for index, attach in enumerate(self):
            //     _logger.debug("Migrate attachment %s/%s to %s", index + 1, record_count, storage)
            //     # pass mimetype, to avoid recomputation
            //     attach.write({'raw': attach.raw, 'mimetype': attach.mimetype})
            */
            return default;
        }

        protected async Task<IrAttachment> PostAddCreateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_attachment.py) ---
            // def _post_add_create(self, **kwargs):
            // move_attachments = self.filtered(lambda attachment: attachment.res_model == 'account.move')
            // moves_per_id = self.env['account.move'].browse([attachment.res_id for attachment in move_attachments]).grouped('id')
            // for attachment in move_attachments:
            //     moves_per_id[attachment.res_id]._check_and_decode_attachment(attachment)
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
            //                 quality = int(ICP('base.image_autoresize_quality', 80))
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
            //     ('create_uid', '=', SUPERUSER_ID),
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
            // def _search(self, domain, offset=0, limit=None, order=None):
            // # add res_field=False in domain if not present; the arg[0] trick below
            // # works for domain items and '&'/'|'/'!' operators too
            // disable_binary_fields_attachments = False
            // if not self.env.context.get('skip_res_field_check') and not any(arg[0] in ('id', 'res_field') for arg in domain):
            //     disable_binary_fields_attachments = True
            //     domain = [('res_field', '=', False)] + domain
            // 
            // if self.env.is_superuser():
            //     # rules do not apply for the superuser
            //     return super()._search(domain, offset, limit, order)
            // 
            // # For attachments, the permissions of the document they are attached to
            // # apply, so we must remove attachments for which the user cannot access
            // # the linked document. For the sake of performance, fetch the fields to
            // # determine those permissions within the same SQL query.
            // fnames_to_read = ['id', 'res_model', 'res_id', 'res_field', 'public', 'create_uid']
            // query = super()._search(domain, offset, limit, order)
            // rows = self.env.execute_query(query.select(
            //     *[self._field_to_sql(self._table, fname) for fname in fnames_to_read],
            // ))
            // 
            // # determine permissions based on linked records
            // all_ids = []
            // allowed_ids = set()
            // model_attachments = defaultdict(lambda: defaultdict(set))   # {res_model: {res_id: set(ids)}}
            // for id_, res_model, res_id, res_field, public, create_uid in rows:
            //     all_ids.append(id_)
            //     if public:
            //         allowed_ids.add(id_)
            //         continue
            // 
            //     if res_field and not self.env.is_system():
            //         field = self.env[res_model]._fields[res_field]
            //         if field.groups and not self.env.user.has_groups(field.groups):
            //             continue
            // 
            //     if not res_id and (self.env.is_system() or create_uid == self.env.uid):
            //         allowed_ids.add(id_)
            //         continue
            //     if not (res_field and disable_binary_fields_attachments) and res_model and res_id:
            //         model_attachments[res_model][res_id].add(id_)
            // 
            // # check permissions on records model by model
            // for res_model, targets in model_attachments.items():
            //     if res_model not in self.env:
            //         allowed_ids.update(id_ for ids in targets.values() for id_ in ids)
            //         continue
            //     if not self.env[res_model].has_access('read'):
            //         continue
            //     # filter ids according to what access rules permit
            //     ResModel = self.env[res_model].with_context(active_test=False)
            //     for res_id in ResModel.search([('id', 'in', list(targets))])._ids:
            //         allowed_ids.update(targets[res_id])
            // 
            // # filter out all_ids by keeping allowed_ids only
            // result = [id_ for id_ in all_ids if id_ in allowed_ids]
            // 
            // # If the original search reached the limit, it is important the
            // # filtered record set does so too. When a JS view receive a
            // # record set whose length is below the limit, it thinks it
            // # reached the last page. To avoid an infinite recursion due to the
            // # permission checks the sub-call need to be aware of the number of
            // # expected records to retrieve
            // if len(all_ids) == limit and len(result) < self._context.get('need', limit):
            //     need = self._context.get('need', limit) - len(result)
            //     more_ids = self.with_context(need=need)._search(
            //         domain, offset + len(all_ids), limit, order,
            //     )
            //     result.extend(list(more_ids)[:limit - len(result)])
            // 
            // return self.browse(result)._as_query(order)
            */
            return default;
        }

        protected async Task<IrAttachment> SetAttachmentDataInternalAsync(object asbytes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def _set_attachment_data(self, asbytes):
            // for attach in self:
            //     # compute the fields that depend on datas
            //     bin_data = asbytes(attach)
            //     vals = self._get_datas_related_values(bin_data, attach.mimetype)
            // 
            //     # take current location in filestore to possibly garbage-collect it
            //     fname = attach.store_fname
            //     # write as superuser, as user probably does not have write access
            //     super(IrAttachment, attach.sudo()).write(vals)
            //     if fname:
            //         self._file_delete(fname)
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

        protected async Task<IrAttachment> ToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _to_store(self, store: Store, **kwargs):
            // super()._to_store(store, **kwargs)
            // for attachment in self:
            //     # TODO master: make a real computed / inverse field and stop propagating
            //     # kwargs through hook methods
            //     # sudo: discuss.voice.metadata - checking the existence of voice metadata for accessible attachments is fine
            //     store.add(attachment, {"voice": bool(attachment.sudo().voice_ids)})
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: ir_attachment.py) ---
            // def _to_store(self, store: Store, /, *, fields=None, extra_fields=None):
            // if fields is None:
            //     fields = [
            //         "checksum",
            //         "create_date",
            //         "filename",
            //         "mimetype",
            //         "name",
            //         "res_name",
            //         "size",
            //         "thread",
            //         "type",
            //         "url",
            //     ]
            // if extra_fields:
            //     fields.extend(extra_fields)
            // for attachment in self:
            //     data = attachment._read_format(
            //         [field for field in fields if field not in ["filename", "size", "thread"]],
            //         load=False,
            //     )[0]
            //     if "filename" in fields:
            //         data["filename"] = attachment.name
            //     if "size" in fields:
            //         data["size"] = attachment.file_size
            //     if "thread" in fields:
            //         data["thread"] = (
            //             Store.one(
            //                 self.env[attachment.res_model].browse(attachment.res_id),
            //                 as_thread=True,
            //                 only_id=True,
            //             )
            //             if attachment.res_model != "mail.compose.message" and attachment.res_id
            //             else False
            //         )
            //     store.add(attachment, data)
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_expense, FILE: ir_attachment.py) ---
            // def unlink(self):
            // if self.env.context.get('sync_attachment', True):
            //     attachments_to_unlink = self.env['ir.attachment']
            //     expenses_attachments = self.filtered(lambda att: att.res_model == 'hr.expense')
            //     if expenses_attachments:
            //         expenses = self.env['hr.expense'].browse(expenses_attachments.mapped('res_id'))
            //         for expense in expenses.exists().filtered('sheet_id'):
            //             checksums = set(expense.attachment_ids.mapped('checksum'))
            //             attachments_to_unlink += expense.sheet_id.attachment_ids.filtered(lambda att: att.checksum in checksums)
            //     sheets_attachments = self.filtered(lambda att: att.res_model == 'hr.expense.sheet')
            //     if sheets_attachments:
            //         sheets = self.env['hr.expense.sheet'].browse(sheets_attachments.mapped('res_id'))
            //         for sheet in sheets.exists():
            //             checksums = set((sheet.attachment_ids & sheets_attachments).mapped('checksum'))
            //             attachments_to_unlink += sheet.expense_line_ids.attachment_ids.filtered(lambda att: att.checksum in checksums)
            //     super(IrAttachment, attachments_to_unlink).unlink()
            // return super().unlink()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def unlink(self):
            // if not self:
            //     return True
            // self.check('unlink')
            // 
            // # First delete in the database, *then* in the filesystem if the
            // # database allowed it. Helps avoid errors when concurrent transactions
            // # are deleting the same file, and some of the transactions are
            // # rolled back by PostgreSQL (due to concurrent updates detection).
            // to_delete = set(attach.store_fname for attach in self if attach.store_fname)
            // res = super(IrAttachment, self).unlink()
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

        protected async Task<IrAttachment> UnwrapEdiAttachmentsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_attachment.py) ---
            // def _unwrap_edi_attachments(self):
            // """Decodes ir.attachment and unwrap sub-attachment into a sorted list of
            // dictionary each representing an attachment.
            // 
            // :returns:           A list of dictionary for each attachment.
            // * filename:         The name of the attachment.
            // * content:          The content of the attachment.
            // * type:             The type of the attachment.
            // * xml_tree:         The tree of the xml if type is xml.
            // * pdf_reader:       The pdf_reader if type is pdf.
            // * attachment:       The associated ir.attachment if any
            // * sort_weight:      The associated weigth used for sorting the arrays
            // """
            // to_process = []
            // 
            // for attachment in self:
            //     supported_formats = attachment._get_edi_supported_formats()
            //     for supported_format in supported_formats:
            //         if supported_format['check'](attachment):
            //             to_process += supported_format['decoder'](attachment.name, attachment.raw)
            //             break
            // 
            // to_process.sort(key=lambda x: x['sort_weight'])
            // 
            // return to_process
            */
            return default;
        }

        public async Task<IrAttachment> ValidateAccessAsync(Guid id, IrAttachmentValidateAccessRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_attachment.py) ---
            // def validate_access(self, access_token):
            // self.ensure_one()
            // record_sudo = self.sudo()
            // 
            // if access_token:
            //     tok = record_sudo.with_context(prefetch_fields=False).access_token
            //     valid_token = consteq(tok or '', access_token)
            //     if not valid_token:
            //         raise AccessError("Invalid access token")
            //     return record_sudo
            // 
            // if record_sudo.with_context(prefetch_fields=False).public:
            //     return record_sudo
            // 
            // if self.env.user._is_portal():
            //     # Check the read access on the record linked to the attachment
            //     # eg: Allow to download an attachment on a task from /my/tasks/task_id
            //     self.check('read')
            //     return record_sudo
            // 
            // return self
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}