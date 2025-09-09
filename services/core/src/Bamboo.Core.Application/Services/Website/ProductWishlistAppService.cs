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
    [Module("WebsiteSaleWishlist", Depends = new[] { "website_sale" })]
    public class ProductWishlistAppService : GenericApplicationService<ProductWishlist>, IProductWishlistAppService
    {

        public ProductWishlistAppService(IRepository<ProductWishlist, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<ProductWishlist> AddToWishlistInternalAsync(Guid pricelist_id, Guid currency_id, Guid website_id, object price, Guid product_id, Guid partner_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py) ---
            // def _add_to_wishlist(self, pricelist_id, currency_id, website_id, price, product_id, partner_id=False):
            // wish = self.env['product.wishlist'].create({
            //     'partner_id': partner_id,
            //     'product_id': product_id,
            //     'currency_id': currency_id,
            //     'pricelist_id': pricelist_id,
            //     'price': price,
            //     'website_id': website_id,
            // })
            // return wish
            */
            return default;
        }

        protected async Task<ProductWishlist> CheckWishlistFromSessionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py) ---
            // def _check_wishlist_from_session(self):
            // """Assign all wishlist withtout partner from this the current session"""
            // session_wishes = self.sudo().search([('id', 'in', request.session.get('wishlist_ids', []))])
            // partner_wishes = self.sudo().search([("partner_id", "=", self.env.user.partner_id.id)])
            // partner_products = partner_wishes.mapped("product_id")
            // # Remove session products already present for the user
            // duplicated_wishes = session_wishes.filtered(lambda wish: wish.product_id <= partner_products)
            // session_wishes -= duplicated_wishes
            // duplicated_wishes.unlink()
            // # Assign the rest to the user
            // session_wishes.write({"partner_id": self.env.user.partner_id.id})
            // request.session.pop('wishlist_ids')
            */
            return default;
        }

        protected async Task<ProductWishlist> ComputeStockNotificationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock_wishlist, FILE: product_wishlist.py) ---
            // def _compute_stock_notification(self):
            // for record in self:
            //     record.stock_notification = record.product_id._has_stock_notification(record.partner_id)
            */
            return default;
        }

        public async Task<ProductWishlist> CurrentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py) ---
            // def current(self):
            // """Get all wishlist items that belong to current user or session,
            // filter products that are unpublished."""
            // if not request:
            //     return self
            // 
            // if request.website.is_public_user():
            //     wish = self.sudo().search([('id', 'in', request.session.get('wishlist_ids', []))])
            // else:
            //     wish = self.search([("partner_id", "=", self.env.user.partner_id.id), ('website_id', '=', request.website.id)])
            // 
            // return wish.filtered(
            //     lambda wish:
            //         wish.sudo().product_id.product_tmpl_id.website_published
            //         and wish.sudo().product_id.product_tmpl_id._can_be_added_to_cart()
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ProductWishlist> GcSessionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_wishlist, FILE: product_wishlist.py) ---
            // def _gc_sessions(self, *args, **kwargs):
            // """Remove wishlists for unexisting sessions."""
            // self.with_context(active_test=False).search([
            //     ("create_date", "<", fields.Datetime.to_string(datetime.now() - timedelta(weeks=kwargs.get('wishlist_week', 5)))),
            //     ("partner_id", "=", False),
            // ]).unlink()
            */
            return default;
        }

        protected async Task<ProductWishlist> InverseStockNotificationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale_stock_wishlist, FILE: product_wishlist.py) ---
            // def _inverse_stock_notification(self):
            // for record in self:
            //     if record.stock_notification:
            //         record.product_id.stock_notification_partner_ids += record.partner_id
            */
            return default;
        }
    }
}