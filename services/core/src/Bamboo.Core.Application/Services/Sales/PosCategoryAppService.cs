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
    [Module("PointOfSale", Category = "Sales", Depends = new[] { "resource", "stock_account", "barcodes", "html_editor", "digest", "phone_validation", "partner_autocomplete", "iot_base", "google_address_autocomplete" })]
    public partial class PosCategoryAppService : GenericApplicationService<PosCategory>, IPosCategoryAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public PosCategoryAppService(IRepository<PosCategory, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<PosCategory> CanReturnContentInternalAsync(object field_name, object access_token)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_self_order, FILE: pos_category.py) ---
            // def _can_return_content(self, field_name=None, access_token=None):
            // if field_name in ["image_128", "image_512"]:
            //     return True
            // return super()._can_return_content(field_name, access_token)
            */
            return default;
        }

        protected async Task<PosCategory> CheckCategoryRecursionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py) ---
            // def _check_category_recursion(self):
            // if self._has_cycle():
            //     raise ValidationError(_('Error! You cannot create recursive categories.'))
            */
            return default;
        }

        protected async Task<PosCategory> CheckHourInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py) ---
            // def _check_hour(self):
            // for category in self:
            //     if category.hour_until and not (0.0 <= category.hour_until <= 24.0):
            //         raise ValidationError(_('The Availability Until must be set between 00:00 and 24:00'))
            //     if category.hour_after and not (0.0 <= category.hour_after <= 24.0):
            //         raise ValidationError(_('The Availability After must be set between 00:00 and 24:00'))
            //     if category.hour_until and category.hour_after and category.hour_until < category.hour_after:
            //         raise ValidationError(_('The Availability Until must be greater than Availability After.'))
            */
            return default;
        }

        protected async Task<PosCategory> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py) ---
            // def _compute_display_name(self):
            // for cat in self:
            //     cat.display_name = " / ".join(cat._get_hierarchy())
            */
            return default;
        }

        protected async Task<PosCategory> ComputeHasImageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py) ---
            // def _compute_has_image(self):
            // for category in self:
            //     category.has_image = bool(category.image_128)
            */
            return default;
        }

        public async Task<PosCategory> GetDefaultColorAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py) ---
            // def get_default_color(self):
            // return random.randint(0, 10)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<PosCategory> GetDescendantsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py) ---
            // def _get_descendants(self):
            // available_categories = self
            // for child in self.child_ids:
            //     available_categories |= child
            //     available_categories |= child._get_descendants()
            // return available_categories
            */
            return default;
        }

        protected async Task<List<string>> GetHierarchyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py) ---
            // def _get_hierarchy(self) -> List[str]:
            // """ Returns a list representing the hierarchy of the categories. """
            // self.ensure_one()
            // return (self.parent_id._get_hierarchy() if self.parent_id else []) + [(self.name or '')]
            */
            return default;
        }

        protected async Task<PosCategory> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py) ---
            // def _load_pos_data_domain(self, data, config):
            // domain = []
            // if config.limit_categories:
            //     domain += [('id', 'in', config.iface_available_categ_ids.ids)]
            // return domain
            */
            return default;
        }

        protected async Task<PosCategory> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['id', 'name', 'parent_id', 'child_ids', 'write_date', 'has_image', 'color', 'sequence', 'hour_until', 'hour_after']
            */
            return default;
        }

        protected async Task<PosCategory> UnlinkExceptSessionOpenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: pos_category.py) ---
            // def _unlink_except_session_open(self):
            // if self.search_count([('id', 'in', self.ids)]):
            //     if self.env['pos.session'].sudo().search_count([('state', '!=', 'closed')]):
            //         raise UserError(_('You cannot delete a point of sale category while a session is still opened.'))
            */
            return default;
        }
    }
}