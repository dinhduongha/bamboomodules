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
    [Module("BaseModule", Category = "Base")]
    public class IrAssetAppService : GenericApplicationService<IrAsset>, IIrAssetAppService
    {

        public IrAssetAppService(IRepository<IrAsset, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<IrAsset> FillAssetPathsInternalAsync(object bundle, object asset_paths, object seen, object addons, object installed)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _fill_asset_paths(self, bundle, asset_paths, seen, addons, installed, **assets_params):
            // """
            // Fills the given AssetPaths instance by applying the operations found in
            // the matching bundle of the given addons manifests.
            // See `_get_asset_paths` for more information.
            // 
            // :param bundle: name of the bundle from which to fetch the file paths
            // :param addons: list of addon names as strings
            // :param asset_paths: the AssetPath object to fill
            // :param seen: a list of bundles already checked to avoid circularity
            // :param assets_params: Keyword arguments:
            // 
            //     * css: bool: whether or not to include style files
            //     * js: bool: whether or not to include script files
            //     * xml: bool: whether or not to include template files
            // """
            // if bundle in seen:
            //     raise Exception("Circular assets bundle declaration: %s" % " > ".join(seen + [bundle]))
            // 
            // # this index is used for prepending: files are inserted at the beginning
            // # of the CURRENT bundle.
            // bundle_start_index = len(asset_paths.list)
            // 
            // assets = self._get_related_assets([('bundle', '=', bundle)], **assets_params).filtered('active')
            // # 1. Process the first sequence of 'ir.asset' records
            // for asset in assets.filtered(lambda a: a.sequence < DEFAULT_SEQUENCE):
            //     self._process_path(bundle, asset.directive, asset.target, asset.path, asset_paths, seen, addons, installed, bundle_start_index, **assets_params)
            // 
            // # 2. Process all addons' manifests.
            // for addon in addons:
            //     for command in Manifest.for_addon(addon)['assets'].get(bundle, ()):
            //         directive, target, path_def = self._process_command(command)
            //         self._process_path(bundle, directive, target, path_def, asset_paths, seen, addons, installed, bundle_start_index, **assets_params)
            // 
            // # 3. Process the rest of 'ir.asset' records
            // for asset in assets.filtered(lambda a: a.sequence >= DEFAULT_SEQUENCE):
            //     self._process_path(bundle, asset.directive, asset.target, asset.path, asset_paths, seen, addons, installed, bundle_start_index, **assets_params)
            */
            return default;
        }

        public async Task<IrAsset> FilterDuplicateAsync(Guid id, IrAssetFilterDuplicateRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_asset.py) ---
            // def filter_duplicate(self, website_id=None):
            // """ Filter current recordset only keeping the most suitable asset per distinct name.
            //     Every non-accessible asset will be removed from the set:
            // 
            //       * In non website context, every asset with a website will be removed
            //       * In a website context, every asset from another website
            // """
            // if website_id is None:
            //     website_id = self.env['website'].get_current_website(fallback=False).id
            // if not website_id:
            //     return self.filtered(lambda asset: not asset.website_id)
            // 
            // specific_asset_keys = {asset.key for asset in self if asset.website_id.id == website_id and asset.key}
            // most_specific_assets = []
            // for asset in self:
            //     if asset.website_id:
            //         # specific asset: add it if it's for the current website and ignore
            //         # it if it's for another website
            //         if asset.website_id.id == website_id:
            //             most_specific_assets.append(asset)
            //         continue
            //     elif not asset.key:
            //         # no key: added either way
            //         most_specific_assets.append(asset)
            //     elif asset.key not in specific_asset_keys:
            //         # generic asset: add it iff for the current website, there is no
            //         # specific asset for this asset (based on the same `key` attribute)
            //         most_specific_assets.append(asset)
            // 
            // return self.browse().union(*most_specific_assets)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrAsset> GetActiveAddonsListInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_asset.py) ---
            // def _get_active_addons_list(self, *, website_id=None, **params):
            // """Overridden to discard inactive themes."""
            // addons_list = super()._get_active_addons_list(**params)
            // 
            // if not website_id:
            //     return addons_list
            // 
            // IrModule = self.env['ir.module.module'].sudo()
            // # discard all theme modules except website.theme_id
            // themes = IrModule.search(IrModule.get_themes_domain()) - self.env["website"].browse(website_id).theme_id
            // to_remove = set(themes.mapped('name'))
            // 
            // return [name for name in addons_list if name not in to_remove]
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _get_active_addons_list(self, **kwargs):
            // """Can be overridden to filter the returned list of active modules."""
            // return self._get_installed_addons_list()
            */
            return default;
        }

        protected async Task<IrAsset> GetAssetBundleUrlInternalAsync(object filename, object unique, object assets_params, object ignore_params)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_asset.py) ---
            // def _get_asset_bundle_url(self, filename, unique, assets_params, ignore_params=False):
            // route_prefix = '/web/assets'
            // if ignore_params: # we dont care about website id, match both
            //     route_prefix = '/web/assets%'
            // elif website_id := assets_params.get('website_id', None):
            //     route_prefix = f'/web/assets/{website_id}'
            // return f'{route_prefix}/{unique}/{filename}'
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _get_asset_bundle_url(self, filename, unique, assets_params, ignore_params=False):
            // return f'/web/assets/{unique}/{filename}'
            */
            return default;
        }

        protected async Task<IrAsset> GetAssetParamsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_asset.py) ---
            // def _get_asset_params(self):
            // params = super()._get_asset_params()
            // params['website_id'] = self.env['website'].get_current_website(fallback=False).id
            // return params
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _get_asset_params(self):
            // """
            // This method can be overriden to add param _get_asset_paths call.
            // Those params will be part of the orm cache key
            // """
            // return {}
            */
            return default;
        }

        protected async Task<IrAsset> GetAssetPathsInternalAsync(object bundle, object assets_params)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _get_asset_paths(self, bundle, assets_params):
            // """
            // Fetches all asset file paths from a given list of addons matching a
            // certain bundle. The returned list is composed of tuples containing the
            // file path [1], the first addon calling it [0] and the bundle name.
            // Asset loading is performed as follows:
            // 
            // 1. All 'ir.asset' records matching the given bundle and with a sequence
            // strictly less than 16 are applied.
            // 
            // 3. The manifests of the given addons are checked for assets declaration
            // for the given bundle. If any, they are read sequentially and their
            // operations are applied to the current list.
            // 
            // 4. After all manifests have been parsed, the remaining 'ir.asset'
            // records matching the bundle are also applied to the current list.
            // 
            // :param bundle: name of the bundle from which to fetch the file paths
            // :param assets_params: parameters needed by overrides, mainly website_id
            //     see _get_asset_params
            // :returns: the list of tuples (path, addon, bundle)
            // """
            // installed = self._get_installed_addons_list()
            // addons = self._get_active_addons_list(**assets_params)
            // 
            // asset_paths = AssetPaths()
            // 
            // addons = self._topological_sort(tuple(addons))
            // 
            // self._fill_asset_paths(bundle, asset_paths, [], addons, installed, **assets_params)
            // return asset_paths.list
            */
            return default;
        }

        protected async Task<IrAsset> GetInstalledAddonsListInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _get_installed_addons_list(self):
            // """
            // Returns the list of all installed addons.
            // :returns: string[]: list of module names
            // """
            // return self.env.registry._init_modules.union(tools.config['server_wide_modules'])
            */
            return default;
        }

        protected async Task<IrAsset> GetPathsInternalAsync(object path_def, object installed)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _get_paths(self, path_def, installed):
            // """
            // Returns a list of tuple (path, full_path, modified) matching a given glob (path_def).
            // The glob can only occur in the static direcory of an installed addon.
            // 
            // If the path_def matches a (list of) file, the result will contain the full_path
            // and the modified time.
            // Ex: ('/base/static/file.js', '/home/user/source/odoo/odoo/addons/base/static/file.js', 643636800)
            // 
            // If the path_def looks like a non aggregable path (http://, /web/assets), only return the path
            // Ex: ('http://example.com/lib.js', None, -1)
            // The timestamp -1 is given to be thruthy while carrying no information.
            // 
            // If the path_def is not a wildward, but may still be a valid addons path, return a False path
            // with No timetamp
            // Ex: ('/_custom/web.asset_frontend', False, None)
            // 
            // :param path_def: the definition (glob) of file paths to match
            // :param installed: the list of installed addons
            // :returns: a list of tuple: (path, full_path, modified)
            // """
            // paths = None
            // path_def = fs2web(path_def)  # we expect to have all path definition unix style or url style, this is a safety
            // path_parts = [part for part in path_def.split('/') if part]
            // addon = path_parts[0]
            // addon_manifest = Manifest.for_addon(addon, display_warning=False)
            // 
            // safe_path = False
            // if addon_manifest:
            //     if addon not in installed:
            //         # Assert that the path is in the installed addons
            //         raise Exception(f"""Unallowed to fetch files from addon {addon} for file {path_def}. """
            //                         f"""Addon {addon} is not installed""")
            //     addons_path = addon_manifest.addons_path
            //     full_path = os.path.normpath(os.path.join(addons_path, *path_parts))
            //     # forbid escape from the current addon
            //     # "/mymodule/../myothermodule" is forbidden
            //     static_prefix = os.path.join(addon_manifest.path, 'static', '')
            //     if full_path.startswith(static_prefix):
            //         paths_with_timestamps = _glob_static_file(full_path)
            //         paths = [
            //             (fs2web(absolute_path[len(addons_path):]), absolute_path, timestamp)
            //             for absolute_path, timestamp in paths_with_timestamps
            //         ]
            //         safe_path = True
            // 
            // if not paths and not can_aggregate(path_def):  # http:// or /web/content
            //     paths = [(path_def, EXTERNAL_ASSET, -1)]
            // 
            // if not paths and not is_wildcard_glob(path_def):  # an attachment url most likely
            //     paths = [(path_def, None, None)]
            // 
            // if not paths:
            //     msg = f'IrAsset: the path "{path_def}" did not resolve to anything.'
            //     if not safe_path:
            //         msg += " It may be due to security reasons."
            //     _logger.warning(msg)
            // # Paths are filtered on the extensions (if any).
            // return paths
            */
            return default;
        }

        protected async Task<IrAsset> GetRelatedAssetsInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_asset.py) ---
            // def _get_related_assets(self, domain, *, website_id=None, **params):
            // if website_id:
            //     domain = Domain(domain) & self.env['website'].browse(website_id).website_domain()
            // assets = super()._get_related_assets(domain, **params)
            // return assets.filter_duplicate(website_id)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _get_related_assets(self, domain, **kwargs):
            // """
            // Returns a set of assets matching the domain, regardless of their
            // active state. This method can be overridden to filter the results.
            // :param domain: search domain
            // :returns: ir.asset recordset
            // """
            // # active_test is needed to disable some assets through filter_duplicate for website
            // # they will be filtered on active afterward
            // return self.with_context(active_test=False).sudo().search(domain, order='sequence, id')
            */
            return default;
        }

        protected async Task<IrAsset> GetRelatedBundleInternalAsync(object target_path_def, object root_bundle)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _get_related_bundle(self, target_path_def, root_bundle):
            // """
            // Returns the first bundle directly defining a glob matching the target
            // path. This is useful when generating an 'ir.asset' record to override
            // a specific asset and target the right bundle, i.e. the first one
            // defining the target path.
            // 
            // :param str target_path_def: path to match.
            // :param str root_bundle: bundle from which to initiate the search.
            // :returns: the first matching bundle or None
            // """
            // installed = self._get_installed_addons_list()
            // target_path, _full_path, _modified = self._get_paths(target_path_def, installed)[0]
            // assets_params = self._get_asset_params()
            // asset_paths = self._get_asset_paths(root_bundle, assets_params)
            // 
            // for path, _full_path, bundle, _modified in asset_paths:
            //     if path == target_path:
            //         return bundle
            // 
            // return root_bundle
            */
            return default;
        }

        protected async Task<IrAsset> ParseBundleNameInternalAsync(object bundle_name, object debug_assets)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _parse_bundle_name(self, bundle_name, debug_assets):
            // bundle_name, asset_type = bundle_name.rsplit('.', 1)
            // rtl = False
            // autoprefix = False
            // if not debug_assets:
            //     bundle_name, min_ = bundle_name.rsplit('.', 1)
            //     if min_ != 'min':
            //         raise ValueError("'min' expected in extension in non debug mode")
            // if asset_type == 'css':
            //     if bundle_name.endswith('.autoprefixed'):
            //         bundle_name = bundle_name[:-13]
            //         autoprefix = True
            //     if bundle_name.endswith('.rtl'):
            //         bundle_name = bundle_name[:-4]
            //         rtl = True
            // elif asset_type != 'js':
            //     raise ValueError('Only js and css assets bundle are supported for now')
            // if len(bundle_name.split('.')) != 2:
            //     raise ValueError(f'{bundle_name} is not a valid bundle name, should have two parts')
            // return bundle_name, rtl, asset_type, autoprefix
            */
            return default;
        }

        protected async Task<IrAsset> ProcessCommandInternalAsync(object command)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _process_command(self, command):
            // """Parses a given command to return its directive, target and path definition."""
            // if isinstance(command, str):
            //     # Default directive: append
            //     directive, target, path_def = APPEND_DIRECTIVE, None, command
            // elif command[0] in DIRECTIVES_WITH_TARGET:
            //     directive, target, path_def = command
            // else:
            //     directive, path_def = command
            //     target = None
            // return directive, target, path_def
            */
            return default;
        }

        protected async Task<IrAsset> ProcessPathInternalAsync(object bundle, object directive, object target, object path_def, object asset_paths, object seen, object addons, object installed, object bundle_start_index)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _process_path(self, bundle, directive, target, path_def, asset_paths, seen, addons, installed, bundle_start_index, **assets_params):
            // """
            // This sub function is meant to take a directive and a set of
            // arguments and apply them to the current asset_paths list
            // accordingly.
            // 
            // It is nested inside `_get_asset_paths` since we need the current
            // list of addons, extensions and asset_paths.
            // 
            // :param directive: string
            // :param target: string or None or False
            // :param path_def: string
            // """
            // if directive == INCLUDE_DIRECTIVE:
            //     # recursively call this function for each INCLUDE_DIRECTIVE directive.
            //     self._fill_asset_paths(path_def, asset_paths, seen + [bundle], addons, installed, **assets_params)
            //     return
            // if can_aggregate(path_def):
            //     paths = self._get_paths(path_def, installed)
            // else:
            //     paths = [(path_def, EXTERNAL_ASSET, -1)]  # external urls
            // 
            // # retrieve target index when it applies
            // if directive in DIRECTIVES_WITH_TARGET:
            //     target_paths = self._get_paths(target, installed)
            //     if not target_paths and target.rpartition('.')[2] not in ASSET_EXTENSIONS:
            //         # nothing to do: the extension of the target is wrong
            //         return
            //     if target_paths:
            //         target = target_paths[0][0]
            //     target_index = asset_paths.index(target, bundle)
            // 
            // if directive == APPEND_DIRECTIVE:
            //     asset_paths.append(paths, bundle)
            // elif directive == PREPEND_DIRECTIVE:
            //     asset_paths.insert(paths, bundle, bundle_start_index)
            // elif directive == AFTER_DIRECTIVE:
            //     asset_paths.insert(paths, bundle, target_index + 1)
            // elif directive == BEFORE_DIRECTIVE:
            //     asset_paths.insert(paths, bundle, target_index)
            // elif directive == REMOVE_DIRECTIVE:
            //     asset_paths.remove(paths, bundle)
            // elif directive == REPLACE_DIRECTIVE:
            //     asset_paths.insert(paths, bundle, target_index)
            //     asset_paths.remove(target_paths, bundle)
            // else:
            //     # this should never happen
            //     raise ValueError("Unexpected directive")
            */
            return default;
        }

        protected async Task<IrAsset> TopologicalSortInternalAsync(object addons_tuple)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def _topological_sort(self, addons_tuple):
            // """Returns a list of sorted modules name accord to the spec in ir.module.module
            // that is, application desc, sequence, name then topologically sorted"""
            // IrModule = self.env['ir.module.module']
            // 
            // def mapper(addon):
            //     manif = Manifest.for_addon(addon) or {}
            //     from_terp = IrModule.get_values_from_terp(manif)
            //     from_terp['name'] = addon
            //     from_terp['depends'] = manif.get('depends') or ['base']
            //     return from_terp
            // 
            // manifs = map(mapper, addons_tuple)
            // 
            // def sort_key(manif):
            //     return (not manif['application'], int(manif['sequence']), manif['name'])
            // 
            // manifs = sorted(manifs, key=sort_key)
            // 
            // return misc.topological_sort({manif['name']: tuple(manif['depends']) for manif in manifs})
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, IrAsset entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_asset.py) ---
            // def write(self, vals):
            // """COW for ir.asset. This way editing websites does not impact other
            // websites. Also this way newly created websites will only
            // contain the default assets.
            // """
            // current_website_id = self.env.context.get('website_id')
            // if not current_website_id or self.env.context.get('no_cow'):
            //     return super().write(vals)
            // 
            // for asset in self.with_context(active_test=False):
            //     # No need of COW if the asset is already specific
            //     if asset.website_id:
            //         super(IrAsset, asset).write(vals)
            //         continue
            // 
            //     # If already a specific asset for this generic asset, write on it
            //     website_specific_asset = asset.search([
            //         ('key', '=', asset.key),
            //         ('website_id', '=', current_website_id)
            //     ], limit=1)
            //     if website_specific_asset:
            //         super(IrAsset, website_specific_asset).write(vals)
            //         continue
            // 
            //     copy_vals = {'website_id': current_website_id, 'key': asset.key}
            //     website_specific_asset = asset.copy(copy_vals)
            // 
            //     super(IrAsset, website_specific_asset).write(vals)
            // 
            // return True
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_asset.py) ---
            // def write(self, vals):
            // if self:
            //     self.env.registry.clear_cache('assets')
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}