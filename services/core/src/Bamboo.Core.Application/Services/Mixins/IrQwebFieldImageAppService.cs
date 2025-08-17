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
    public class IrQwebFieldImageAppService : ApplicationService, IIrQwebFieldImageAppService
    {

        public IrQwebFieldImageAppService() 
        {

        }

        public async Task<TEntity> FromHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object model, object field, object element) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_qweb_fields.py) ---
            // def from_html(self, model, field, element):
            // if element.find('img') is None:
            //     return False
            // url = element.find('img').get('src')
            // 
            // url_object = urls.url_parse(url)
            // if url_object.path.startswith('/web/image'):
            //     fragments = url_object.path.split('/')
            //     query = url_object.decode_query()
            //     url_id = fragments[3].split('-')[0]
            //     # ir.attachment image urls: /web/image/<id>[-<checksum>][/...]
            //     if url_id.isdigit():
            //         model = 'ir.attachment'
            //         oid = url_id
            //         field = 'datas'
            //     # url of binary field on model: /web/image/<model>/<id>/<field>[/...]
            //     else:
            //         model = query.get('model', fragments[3])
            //         oid = query.get('id', fragments[4])
            //         field = query.get('field', fragments[5])
            //     item = self.env[model].browse(int(oid))
            //     if self.redirect_url_re.match(url_object.path):
            //         return self.load_remote_url(item.url)
            //     return item[field]
            // 
            // if self.local_url_re.match(url_object.path):
            //     return self.load_local_url(url)
            // 
            // return self.load_remote_url(url)
            --- ODOO METHOD SOURCE (MODULE: web_unsplash, FILE: ir_qweb_fields.py) ---
            // def from_html(self, model, field, element):
            // if element.find('.//img') is None:
            //     return False
            // url = element.find('.//img').get('src')
            // url_object = urls.url_parse(url)
            // 
            // if url_object.path.startswith('/unsplash/'):
            //     res_id = element.get('data-oe-id')
            //     if res_id:
            //         res_id = int(res_id)
            //         res_model = model._name
            //         attachment = self.env['ir.attachment'].search([
            //             '&', '|', '&',
            //             ('res_model', '=', res_model),
            //             ('res_id', '=', res_id),
            //             ('public', '=', True),
            //             ('url', '=', url_object.path),
            //         ], limit=1)
            //         return attachment.datas
            // 
            // return super(Image, self).from_html(model, field, element)
            */
            return default;
        }

        public async Task<TEntity> GetSrcDataB64InternalAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def _get_src_data_b64(self, value, options):
            // try:
            //     img_b64 = base64.b64decode(value)
            // except binascii.Error:
            //     raise ValueError("Invalid image content") from None
            // 
            // if img_b64 and guess_mimetype(img_b64, '') == 'image/webp':
            //     return self.env["ir.qweb"]._get_converted_image_data_uri(value)
            // 
            // try:
            //     image = Image.open(BytesIO(img_b64))
            //     image.verify()
            // except IOError:
            //     raise ValueError("Non-image binary fields can not be converted to HTML") from None
            // except: # image.verify() throws "suitable exceptions", I have no idea what they are
            //     raise ValueError("Invalid image content") from None
            // 
            // return "data:%s;base64,%s" % (Image.MIME[image.format], value.decode('ascii'))
            */
            return default;
        }

        public async Task<TEntity> GetSrcUrlsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_qweb_fields.py) ---
            // def _get_src_urls(self, record, field_name, options):
            // """Considering the rendering options, returns the src and data-zoom-image urls.
            // 
            // :return: src, src_zoom urls
            // :rtype: tuple
            // """
            // max_size = None
            // if options.get('resize'):
            //     max_size = options.get('resize')
            // else:
            //     max_width, max_height = options.get('max_width', 0), options.get('max_height', 0)
            //     if max_width or max_height:
            //         max_size = '%sx%s' % (max_width, max_height)
            // 
            // sha = hashlib.sha512(str(getattr(record, 'write_date', fields.Datetime.now())).encode('utf-8')).hexdigest()[:7]
            // max_size = '' if max_size is None else '/%s' % max_size
            // 
            // if options.get('filename-field') and options['filename-field'] in record and record[options['filename-field']]:
            //     filename = record[options['filename-field']]
            // elif options.get('filename'):
            //     filename = options['filename']
            // else:
            //     filename = record.display_name
            // filename = (filename or 'name').replace('/', '-').replace('\\', '-').replace('..', '--')
            // 
            // src = '/web/image/%s/%s/%s%s/%s?unique=%s' % (record._name, record.id, options.get('preview_image', field_name), max_size, url_quote(filename), sha)
            // 
            // src_zoom = None
            // if options.get('zoom') and getattr(record, options['zoom'], None):
            //     src_zoom = '/web/image/%s/%s/%s%s/%s?unique=%s' % (record._name, record.id, options['zoom'], max_size, url_quote(filename), sha)
            // elif options.get('zoom'):
            //     src_zoom = options['zoom']
            // 
            // return src, src_zoom
            */
            return default;
        }

        public async Task<TEntity> LoadLocalUrlAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_qweb_fields.py) ---
            // def load_local_url(self, url):
            // match = self.local_url_re.match(urls.url_parse(url).path)
            // rest = match.group('rest')
            // 
            // path = os.path.join(
            //     match.group('module'), 'static', rest)
            // 
            // try:
            //     with file_open(path, 'rb') as f:
            //         # force complete image load to ensure it's valid image data
            //         image = I.open(f)
            //         image.load()
            //         f.seek(0)
            //         return base64.b64encode(f.read())
            // except Exception:
            //     logger.exception("Failed to load local image %r", url)
            //     return None
            */
            return default;
        }

        public async Task<TEntity> LoadRemoteUrlAsync<TEntity>(IEnumerable<TEntity> entities, object url) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web_editor, FILE: ir_qweb_fields.py) ---
            // def load_remote_url(self, url):
            // try:
            //     # should probably remove remote URLs entirely:
            //     # * in fields, downloading them without blowing up the server is a
            //     #   challenge
            //     # * in views, may trigger mixed content warnings if HTTPS CMS
            //     #   linking to HTTP images
            //     # implement drag & drop image upload to mitigate?
            // 
            //     req = requests.get(url, timeout=REMOTE_CONNECTION_TIMEOUT)
            //     # PIL needs a seekable file-like image so wrap result in IO buffer
            //     image = I.open(io.BytesIO(req.content))
            //     # force a complete load of the image data to validate it
            //     image.load()
            // except Exception:
            //     logger.warning("Failed to load remote image %r", url, exc_info=True)
            //     return None
            // 
            // # don't use original data in case weird stuff was smuggled in, with
            // # luck PIL will remove some of it?
            // out = io.BytesIO()
            // image.save(out, image.format)
            // return base64.b64encode(out.getvalue())
            */
            return default;
        }

        public async Task<TEntity> RecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: ir_qweb_fields.py) ---
            // def record_to_html(self, record, field_name, options):
            // assert options['tagName'] != 'img',\
            //     "Oddly enough, the root tag of an image field can not be img. " \
            //     "That is because the image goes into the tag, or it gets the " \
            //     "hose again."
            // 
            // src = src_zoom = None
            // if options.get('qweb_img_raw_data', False):
            //     value = record[field_name]
            //     if value is False:
            //         return False
            //     src = self._get_src_data_b64(value, options)
            // else:
            //     src, src_zoom = self._get_src_urls(record, field_name, options)
            // 
            // aclasses = ['img', 'img-fluid'] if options.get('qweb_img_responsive', True) else ['img']
            // aclasses += options.get('class', '').split()
            // classes = ' '.join(map(escape, aclasses))
            // 
            // if options.get('alt-field') and options['alt-field'] in record and record[options['alt-field']]:
            //     alt = escape(record[options['alt-field']])
            // elif options.get('alt'):
            //     alt = options['alt']
            // else:
            //     alt = escape(record.display_name)
            // 
            // itemprop = None
            // if options.get('itemprop'):
            //     itemprop = options['itemprop']
            // 
            // atts = OrderedDict()
            // atts["src"] = src
            // atts["itemprop"] = itemprop
            // atts["class"] = classes
            // atts["style"] = options.get('style')
            // atts["width"] = options.get('width')
            // atts["height"] = options.get('height')
            // atts["alt"] = alt
            // atts["data-zoom"] = src_zoom and u'1' or None
            // atts["data-zoom-image"] = src_zoom
            // atts["data-no-post-process"] = options.get('data-no-post-process')
            // 
            // atts = self.env['ir.qweb']._post_processing_att('img', atts)
            // 
            // img = ['<img']
            // for name, value in atts.items():
            //     if value:
            //         img.append(' ')
            //         img.append(escape(name))
            //         img.append('="')
            //         img.append(escape(value))
            //         img.append('"')
            // img.append('/>')
            // 
            // return Markup(''.join(img))
            */
            return default;
        }

        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldImageable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // return Markup('<img src="%s">') % self._get_src_data_b64(value, options)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // return Markup('<img src="%s">' % (value))
            */
            return default;
        }
    }
}