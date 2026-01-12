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
    public class IrModuleModuleAppService : GenericApplicationService<IrModuleModule>, IIrModuleModuleAppService
    {
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public IrModuleModuleAppService(IRepository<IrModuleModule, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public async Task<IrModuleModule> ButtonChooseThemeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def button_choose_theme(self):
            // """
            //     Remove any existing theme on the current website and install the theme ``self`` instead.
            // 
            //     The actual loading of the theme on the current website will be done
            //     automatically on ``write`` thanks to the upgrade and/or install.
            // 
            //     When installating a new theme, upgrade the upstream chain first to make sure
            //     we have the latest version of the dependencies to prevent inconsistencies.
            // 
            //     :return: dict with the next action to execute
            // """
            // self.ensure_one()
            // website = self.env['website'].get_current_website()
            // 
            // self._theme_remove(website)
            // 
            // # website.theme_id must be set before upgrade/install to trigger the load in ``write``
            // website.theme_id = self
            // 
            // # this will install 'self' if it is not installed yet
            // if request:
            //     request.update_context(apply_new_theme=True)
            // self._theme_upgrade_upstream()
            // 
            // result = website.button_go_website()
            // return result
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModule> ButtonImmediateFunctionInternalAsync(object function)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _button_immediate_function(self, function):
            // if not self.env.registry.ready or self.env.registry._init:
            //     raise UserError(_('The method _button_immediate_install cannot be called on init or non loaded registries. Please use button_install instead.'))
            // 
            // if modules.module.current_test:
            //     raise RuntimeError(
            //         "Module operations inside tests are not transactional and thus forbidden.\n"
            //         "If you really need to perform module operations to test a specific behavior, it "
            //         "is best to write it as a standalone script, and ask the runbot/metastorm team "
            //         "for help."
            //     )
            // 
            // # raise error if database is updating for module operations
            // if self.search_count([('state', 'in', ('to install', 'to upgrade', 'to remove'))], limit=1):
            //     raise UserError(_("Odoo is currently processing another module operation.\n"
            //                        "Please try again later or contact your system administrator."))
            // try:
            //     # raise error if another transaction is trying to schedule module operations concurrently
            //     self.env.cr.execute("LOCK ir_module_module IN EXCLUSIVE MODE NOWAIT")
            // except psycopg2.OperationalError:
            //     raise UserError(_("Odoo is currently processing another module operation.\n"
            //                        "Please try again later or contact your system administrator."))
            // 
            // try:
            //     # This is done because the installation/uninstallation/upgrade can modify a currently
            //     # running cron job and prevent it from finishing, and since the ir_cron table is locked
            //     # during execution, the lock won't be released until timeout.
            //     self.env.cr.execute("SELECT FROM ir_cron FOR UPDATE NOWAIT")
            // except psycopg2.OperationalError:
            //     raise UserError(_("Odoo is currently processing a scheduled action.\n"
            //                       "Module operations are not possible at this time, "
            //                       "please try again later or contact your system administrator."))
            // function(self)
            // 
            // self.env.cr.commit()
            // registry = modules.registry.Registry.new(self.env.cr.dbname, update_module=True)
            // self.env.cr.commit()
            // if request and request.registry is self.env.registry:
            //     request.env.cr.reset()
            //     request.registry = request.env.registry
            //     assert request.env.registry is registry
            // self.env.cr.reset()
            // assert self.env.registry is registry
            // 
            // # pylint: disable=next-method-called
            // config = self.env['ir.module.module'].next() or {}
            // if config.get('type') not in ('ir.actions.act_window_close',):
            //     return config
            // 
            // # reload the client; open the first available root menu
            // menu = self.env['ir.ui.menu'].search([('parent_id', '=', False)])[:1]
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'reload',
            //     'params': {'menu_id': menu.id},
            // }
            */
            return default;
        }

        public async Task<IrModuleModule> ButtonImmediateInstallAppAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def button_immediate_install_app(self):
            // if not self.env.is_admin():
            //     raise AccessDenied()
            // module_name = self.env.context.get('module_name')
            // import requests  # noqa: PLC0415
            // try:
            //     resp = requests.get(
            //         f"{APPS_URL}/loempia/download/data_app/{module_name}/{major_version}",
            //         timeout=5.0,
            //     )
            //     resp.raise_for_status()
            //     missing_dependencies_description, unavailable_modules = self._get_missing_dependencies(resp.content)
            //     if unavailable_modules:
            //         raise UserError(missing_dependencies_description)
            //     import_module = self.env['base.import.module'].create({
            //         'module_file': base64.b64encode(resp.content),
            //         'state': 'init',
            //         'modules_dependencies': missing_dependencies_description,
            //     })
            //     return {
            //         'name': _("Install an Industry"),
            //         'view_mode': 'form',
            //         'target': 'new',
            //         'res_id': import_module.id,
            //         'res_model': 'base.import.module',
            //         'type': 'ir.actions.act_window',
            //         'context': {'data_module': True}
            //     }
            // except requests.exceptions.HTTPError:
            //     raise UserError(_('The module %s cannot be downloaded') % module_name)
            // except requests.exceptions.ConnectionError:
            //     raise UserError(_('Connection to %(url)s failed, the module %(module)s cannot be downloaded.', url=APPS_URL, module=module_name))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> ButtonImmediateInstallAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def button_immediate_install(self):
            // """ Installs the selected module(s) immediately and fully,
            // returns the next res.config action to execute
            // 
            // :returns: next res.config item to execute
            // :rtype: dict[str, object]
            // """
            // _logger.info('User #%d triggered module installation', self.env.uid)
            // # We use here the request object (which is thread-local) as a kind of
            // # "global" env because the env is not usable in the following use case.
            // # When installing a Chart of Account, I would like to send the
            // # allowed companies to configure it on the correct company.
            // # Otherwise, the SUPERUSER won't be aware of that and will try to
            // # configure the CoA on his own company, which makes no sense.
            // if request:
            //     request.allowed_company_ids = self.env.companies.ids
            // return self._button_immediate_function(self.env.registry[self._name].button_install)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> ButtonImmediateUninstallAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def button_immediate_uninstall(self):
            // """
            // Uninstall the selected module(s) immediately and fully,
            // returns the next res.config action to execute
            // """
            // _logger.info('User #%d triggered module uninstallation', self.env.uid)
            // return self._button_immediate_function(self.env.registry[self._name].button_uninstall)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> ButtonImmediateUpgradeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def button_immediate_upgrade(self):
            // """
            // Upgrade the selected module(s) immediately and fully,
            // return the next res.config action to execute
            // """
            // return self._button_immediate_function(self.env.registry[self._name].button_upgrade)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> ButtonInstallAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def button_install(self):
            // company_countries = self.env['res.company'].search([]).country_id
            // # domain to select auto-installable (but not yet installed) modules
            // auto_domain = [('state', '=', 'uninstalled'), ('auto_install', '=', True)]
            // 
            // # determine whether an auto-install module must be installed:
            // #  - all its dependencies are installed or to be installed,
            // #  - at least one dependency is 'to install'
            // #  - if the module is country specific, at least one company is in one of the countries
            // install_states = frozenset(('installed', 'to install', 'to upgrade'))
            // def must_install(module):
            //     states = {dep.state for dep in module.dependencies_id if dep.auto_install_required}
            //     return states <= install_states and 'to install' in states and (
            //         not module.country_ids or module.country_ids & company_countries
            //     )
            // 
            // modules = self
            // while modules:
            //     # Mark the given modules and their dependencies to be installed.
            //     modules._state_update('to install', ['uninstalled'])
            // 
            //     # Determine which auto-installable modules must be installed.
            // 
            //     if config.get('skip_auto_install'):
            //         modules = None
            //     else:
            //         modules = self.search(auto_domain).filtered(must_install)
            // 
            // # the modules that are installed/to install/to upgrade
            // install_mods = self.search([('state', 'in', list(install_states))])
            // 
            // # check individual exclusions
            // install_names = {module.name for module in install_mods}
            // for module in install_mods:
            //     for exclusion in module.exclusion_ids:
            //         if exclusion.name in install_names:
            //             raise UserError(_(
            //                 'Modules "%(module)s" and "%(incompatible_module)s" are incompatible.',
            //                 module=module.shortdesc,
            //                 incompatible_module=exclusion.exclusion_id.shortdesc,
            //             ))
            // 
            // # check category exclusions
            // def closure(module):
            //     todo = result = module
            //     while todo:
            //         result |= todo
            //         todo = todo.dependencies_id.depend_id
            //     return result
            // 
            // exclusives = self.env['ir.module.category'].search([('exclusive', '=', True)])
            // for category in exclusives:
            //     # retrieve installed modules in category and sub-categories
            //     categories = category.search([('id', 'child_of', category.ids)])
            //     modules = install_mods.filtered(lambda mod: mod.category_id in categories)
            //     # the installation is valid if all installed modules in categories
            //     # belong to the transitive dependencies of one of them
            //     if modules and not any(modules <= closure(module) for module in modules):
            //         labels = dict(self.fields_get(['state'])['state']['selection'])
            //         raise UserError(
            //             _('You are trying to install incompatible modules in category "%(category)s":%(module_list)s', category=category.name, module_list=''.join(
            //                 f"\n- {module.shortdesc} ({labels[module.state]})"
            //                 for module in modules
            //             ))
            //         )
            // 
            // return dict(ACTION_DICT, name=_('Install'))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> ButtonRefreshThemeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def button_refresh_theme(self):
            // """
            //     Refresh the current theme of the current website.
            // 
            //     To refresh it, we only need to upgrade the modules.
            //     Indeed the (re)loading of the theme will be done automatically on ``write``.
            // """
            // website = self.env['website'].get_current_website()
            // website.theme_id._theme_upgrade_upstream()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> ButtonRemoveThemeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def button_remove_theme(self):
            // """Remove the current theme of the current website."""
            // website = self.env['website'].get_current_website()
            // self._theme_remove(website)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> ButtonResetStateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def button_reset_state(self):
            // # reset the transient state for all modules in case the module operation is stopped in an unexpected way.
            // self.search([('state', '=', 'to install')]).state = 'uninstalled'
            // self.search([('state', 'in', ('to upgrade', 'to remove'))]).state = 'installed'
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> ButtonUninstallAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def button_uninstall(self):
            // un_installable_modules = set(odoo.tools.config['server_wide_modules']) & set(self.mapped('name'))
            // if un_installable_modules:
            //     raise UserError(_("Those modules cannot be uninstalled: %s", ', '.join(un_installable_modules)))
            // if any(state not in ('installed', 'to upgrade') for state in self.mapped('state')):
            //     raise UserError(_(
            //         "One or more of the selected modules have already been uninstalled, if you "
            //         "believe this to be an error, you may try again later or contact support."
            //     ))
            // deps = self.downstream_dependencies()
            // (self + deps).write({'state': 'to remove'})
            // return dict(ACTION_DICT, name=_('Uninstall'))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> ButtonUninstallWizardAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def button_uninstall_wizard(self):
            // """ Launch the wizard to uninstall the given module. """
            // return {
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'name': _('Uninstall module'),
            //     'view_mode': 'form',
            //     'res_model': 'base.module.uninstall',
            //     'context': {'default_module_ids': self.ids},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> ButtonUpgradeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def button_upgrade(self):
            // res = super().button_upgrade()
            // # revert states for imported modules since they cannot be upgraded
            // self.search([('imported', '=', True), ('state', '=', 'to upgrade')]).state = 'installed'
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def button_upgrade(self):
            // if not self:
            //     return
            // Dependency = self.env['ir.module.module.dependency']
            // self.update_list()
            // 
            // todo = list(self)
            // if 'base' in self.mapped('name'):
            //     # If an installed module is only present in the dependency graph through
            //     # a new, uninstalled dependency, it will not have been selected yet.
            //     # An update of 'base' should also update these modules, and as a consequence,
            //     # install the new dependency.
            //     todo.extend(self.search([
            //         ('state', '=', 'installed'),
            //         ('name', '!=', 'studio_customization'),
            //         ('id', 'not in', self.ids),
            //     ]))
            // i = 0
            // while i < len(todo):
            //     module = todo[i]
            //     i += 1
            //     if module.state not in ('installed', 'to upgrade'):
            //         raise UserError(_("Cannot upgrade module “%s”. It is not installed.", module.name))
            //     if self.get_module_info(module.name).get("installable", True):
            //         self.check_external_dependencies(module.name, 'to upgrade')
            //     for dep in Dependency.search([('name', '=', module.name)]):
            //         if (
            //             dep.module_id.state == 'installed'
            //             and dep.module_id not in todo
            //             and dep.module_id.name != 'studio_customization'
            //         ):
            //             todo.append(dep.module_id)
            // 
            // self.browse(module.id for module in todo).write({'state': 'to upgrade'})
            // 
            // to_install = []
            // for module in todo:
            //     if not self.get_module_info(module.name).get("installable", True):
            //         continue
            //     for dep in module.dependencies_id:
            //         if dep.state == 'unknown':
            //             raise UserError(_('You try to upgrade the module %(module)s that depends on the module: %(dependency)s.\nBut this module is not available in your system.', module=module.name, dependency=dep.name))
            //         if dep.state == 'uninstalled':
            //             to_install += self.search([('name', '=', dep.name)]).ids
            // 
            // self.browse(to_install).button_install()
            // return dict(ACTION_DICT, name=_('Apply Schedule Upgrade'))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModule> CallAppsInternalAsync(object payload)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _call_apps(self, payload):
            // headers = {'Content-type': 'application/json', 'Accept': 'text/plain'}
            // import requests  # noqa: PLC0415
            // return requests.post(
            //         f"{APPS_URL}/loempia/listdatamodules",
            //         data=payload,
            //         headers=headers,
            //         timeout=5.0,
            //     )
            */
            return default;
        }

        public async Task<IrModuleModule> CheckExternalDependenciesAsync(Guid id, IrModuleModuleCheckExternalDependenciesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def check_external_dependencies(self, module_name, newstate='to install'):
            // manifest = modules.Manifest.for_addon(module_name)
            // if not manifest:
            //     return  # unavailable module, there is no point in checking dependencies
            // try:
            //     manifest.check_manifest_dependencies()
            // except MissingDependency as e:
            //     if newstate == 'to install':
            //         msg = _('Unable to install module "%(module)s" because an external dependency is not met: %(dependency)s', module=module_name, dependency=e.dependency)
            //     elif newstate == 'to upgrade':
            //         msg = _('Unable to upgrade module "%(module)s" because an external dependency is not met: %(dependency)s', module=module_name, dependency=e.dependency)
            //     else:
            //         msg = _('Unable to process module "%(module)s" because an external dependency is not met: %(dependency)s', module=module_name, dependency=e.dependency)
            // 
            //     install_package = None
            //     if platform.system() == 'Linux':
            //         distro = platform.freedesktop_os_release()
            //         id_likes = {distro['ID'], *distro.get('ID_LIKE', '').split()}
            //         if 'debian' in id_likes or 'ubuntu' in id_likes:
            //             if package := manifest['external_dependencies'].get('apt', {}).get(e.dependency):
            //                 install_package = f'apt install {package}'
            // 
            //     if install_package:
            //         msg += _("\nIt can be installed running: %s", install_package)
            // 
            //     raise UserError(msg) from e
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModule> CheckInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _check(self):
            // super()._check()
            // View = self.env['ir.ui.view']
            // website_views_to_adapt = getattr(self.pool, 'website_views_to_adapt', [])
            // if website_views_to_adapt:
            //     for view_replay in website_views_to_adapt:
            //         cow_view = View.browse(view_replay[0])
            //         View._load_records_write_on_cow(cow_view, view_replay[1], view_replay[2])
            //     self.pool.website_views_to_adapt.clear()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _check(self):
            // for module in self:
            //     if not module.description_html:
            //         _logger.warning('module %s: description is empty!', module.name)
            */
            return default;
        }

        public async Task<IrModuleModule> CheckModuleUpdateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def check_module_update(self):
            // return bool(self.sudo().search_count([('state', 'in', ('to install', 'to upgrade', 'to remove'))], limit=1))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModule> ComputeAccountTemplatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_module.py) ---
            // def _compute_account_templates(self):
            // chart_category = self.env.ref('base.module_category_accounting_localizations_account_charts')
            // ChartTemplate = self.env['account.chart.template']
            // for module in self:
            //     templates = {}
            //     if module.category_id == chart_category or module.name == 'account':
            //         try:
            //             python_module = import_module(f"odoo.addons.{module.name}.models")
            //         except ModuleNotFoundError:
            //             templates = {}
            //         else:
            //             templates = {
            //                 fct._l10n_template[0]: {
            //                     'name': template_values.get('name'),
            //                     'parent': template_values.get('parent'),
            //                     'sequence': template_values.get('sequence', 1),
            //                     'country': template_values.get('country', ''),
            //                     'visible': template_values.get('visible', True),
            //                     'installed': module.state == "installed",
            //                     'module': module.name,
            //                 }
            //                 for _name, mdl in getmembers(python_module, template_module)
            //                 for _name, cls in getmembers(mdl, template_class)
            //                 for _name, fct in getmembers(cls, template_function)
            //                 if (template_values := fct(ChartTemplate))
            //             }
            // 
            //     module.account_templates = {
            //         code: templ(self.env, code, **vals)
            //         for code, vals in sorted(templates.items(), key=lambda kv: kv[1]['sequence'])
            //     }
            */
            return default;
        }

        protected async Task<IrModuleModule> ComputeHasIapInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _compute_has_iap(self):
            // for module in self:
            //     module.has_iap = bool(module.id) and 'iap' in module.upstream_dependencies(exclude_states=('',)).mapped('name')
            */
            return default;
        }

        protected async Task<IrModuleModule> ComputeIsInstalledOnCurrentWebsiteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _compute_is_installed_on_current_website(self):
            // """
            //     Compute for every theme in ``self`` if the current website is using it or not.
            // 
            //     This method does not take dependencies into account, because if it did, it would show
            //     the current website as having multiple different themes installed at the same time,
            //     which would be confusing for the user.
            // """
            // for module in self:
            //     module.is_installed_on_current_website = module == self.env['website'].get_current_website().theme_id
            */
            return default;
        }

        protected async Task<IrModuleModule> CreateModelDataInternalAsync(object views)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _create_model_data(self, views):
            // """ Creates model data records for newly created view records.
            // 
            //     :param views: views for which model data must be created
            // """
            // # The generated templates are set as noupdate in order to avoid that
            // # _process_end deletes them.
            // # In case some of them require an XML definition in the future,
            // # an upgrade script will be needed to temporarily make those
            // # records updatable.
            // self.env['ir.model.data'].create([{
            //     'name': view.key.split('.')[1],
            //     'module': view.key.split('.')[0],
            //     'model': 'ir.ui.view',
            //     'res_id': view.id,
            //     'noupdate': True,
            // } for view in views])
            */
            return default;
        }

        public async Task<IrModuleModule> DownstreamDependenciesAsync(Guid id, IrModuleModuleDownstreamDependenciesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def downstream_dependencies(self, known_deps=None,
            //                         exclude_states=('uninstalled', 'uninstallable', 'to remove')):
            // """ Return the modules that directly or indirectly depend on the modules
            // in `self`, and that satisfy the `exclude_states` filter.
            // """
            // if not self:
            //     return self
            // self.flush_model(['name', 'state'])
            // self.env['ir.module.module.dependency'].flush_model(['module_id', 'name'])
            // known_deps = known_deps or self.browse()
            // query = """ SELECT DISTINCT m.id
            //             FROM ir_module_module_dependency d
            //             JOIN ir_module_module m ON (d.module_id=m.id)
            //             WHERE
            //                 d.name IN (SELECT name from ir_module_module where id in %s) AND
            //                 m.state NOT IN %s AND
            //                 m.id NOT IN %s """
            // self.env.cr.execute(query, (tuple(self.ids), tuple(exclude_states), tuple(known_deps.ids or self.ids)))
            // new_deps = self.browse([row[0] for row in self.env.cr.fetchall()])
            // missing_mods = new_deps - known_deps
            // known_deps |= new_deps
            // if missing_mods:
            //     known_deps |= missing_mods.downstream_dependencies(known_deps, exclude_states)
            // return known_deps
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModule> ExtractResourceAttachmentTranslationsInternalAsync(object module, object lang)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _extract_resource_attachment_translations(self, module, lang):
            // yield from super()._extract_resource_attachment_translations(module, lang)
            // if not self._get(module).imported:
            //     return
            // self.env['ir.model.data'].flush_model()
            // IrAttachment = self.env['ir.attachment']
            // IrAttachment.flush_model()
            // module_ = module.replace('_', r'\_')
            // ids = [r[0] for r in self.env.execute_query(SQL(
            //     """
            //         SELECT ia.id
            //         FROM ir_attachment ia
            //         JOIN ir_model_data imd
            //         ON ia.id = imd.res_id
            //         AND imd.model = 'ir.attachment'
            //         AND imd.module = %(module)s
            //         AND ia.res_model = 'ir.ui.view'
            //         AND ia.res_field IS NULL
            //         AND ia.res_id IS NULL
            //         AND (ia.url ilike %(js_pattern)s or ia.url ilike %(xml_pattern)s)
            //         AND ia.type = 'binary'
            //         ORDER BY ia.url
            //     """,
            //     module=module,
            //     js_pattern=f'/{module_}/static/src/%.js',
            //     xml_pattern=f'/{module_}/static/src/%.xml',
            // ))]
            // attachments = IrAttachment.browse(OrderedSet(ids))
            // if not attachments:
            //     return
            // translations = self._get_imported_module_translations_for_webclient(module, lang)
            // translations = {tran['id']: tran['string'] for tran in translations['messages']}
            // for attachment in attachments.filtered('raw'):
            //     display_path = f'addons{attachment.url}'
            //     if attachment.url.endswith('js'):
            //         extract_method = 'odoo.tools.babel:extract_javascript'
            //         extract_keywords = {'_t': None}
            //     else:
            //         extract_method = 'odoo.tools.translate:babel_extract_qweb'
            //         extract_keywords = {}
            //     try:
            //         with io.BytesIO(attachment.raw) as fileobj:
            //             for extracted in extract.extract(extract_method, fileobj, keywords=extract_keywords):
            //                 lineno, message, comments = extracted[:3]
            //                 value = translations.get(message, '')
            //                 # (module, ttype, name, res_id, source, comments, record_id, value)
            //                 yield (module, 'code', display_path, lineno, message, comments + [JAVASCRIPT_TRANSLATION_COMMENT], None, value)
            //     except Exception:  # noqa: BLE001
            //         _logger.exception("Failed to extract terms from attachment with url %s", attachment.url)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _extract_resource_attachment_translations(self, module, lang):
            // yield from ()
            */
            return default;
        }

        protected async Task<IrModuleModule> GeneratePrimaryPageTemplatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _generate_primary_page_templates(self):
            // """ Generates page templates based on manifest entries. """
            // View = self.env['ir.ui.view']
            // manifest = Manifest.for_addon(self.name)
            // templates = manifest['new_page_templates']
            // 
            // # TODO Find a way to create theme and other module's template patches
            // # Create or update template views per group x key
            // create_values = []
            // for group in templates:
            //     for template_name in templates[group]:
            //         xmlid = f'{self.name}.new_page_template_sections_{group}_{template_name}'
            //         wrapper = f'%s.new_page_template_{group}_{template_name}_%s'
            //         calls = '\n    '.join([
            //             f'''<t t-snippet-call="{wrapper % (snippet_key.split('.') if '.' in snippet_key else ('website', snippet_key))}"/>'''
            //             for snippet_key in templates[group][template_name]
            //         ])
            //         create_values.append({
            //             'name': f"New page template: {template_name!r} in {group!r}",
            //             'type': 'qweb',
            //             'key': xmlid,
            //             'arch': f'<div id="wrap">\n    {calls}\n</div>',
            //         })
            // keys = [values['key'] for values in create_values]
            // existing_primary_templates = View.search_read([('mode', '=', 'primary'), ('key', 'in', keys)], ['key'])
            // existing_primary_template_keys = {data['key']: data['id'] for data in existing_primary_templates}
            // missing_create_values = []
            // update_count = 0
            // for create_value in create_values:
            //     if create_value['key'] in existing_primary_template_keys:
            //         View.browse(existing_primary_template_keys[create_value['key']]).with_context(no_cow=True).write({
            //             'arch': create_value['arch'],
            //         })
            //         update_count += 1
            //     else:
            //         missing_create_values.append(create_value)
            // if missing_create_values:
            //     missing_records = View.create(missing_create_values)
            //     self._create_model_data(missing_records)
            //     _logger.info('Generated %s primary page templates for %r', len(missing_create_values), self.name)
            // if update_count:
            //     _logger.info('Updated %s primary page templates for %r', update_count, self.name)
            */
            return default;
        }

        protected async Task<IrModuleModule> GeneratePrimarySnippetTemplatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _generate_primary_snippet_templates(self):
            // """ Generates snippet templates hierarchy based on manifest entries for
            //     use in the configurator and when creating new pages from templates.
            // """
            // def split_key(snippet_key):
            //     """ Snippets xmlid can be written without the module part, meaning
            //         it is a shortcut for a website module snippet.
            // 
            //         :param snippet_key: xmlid with or without the module part
            //             'website' is assumed to be the default module
            //         :return: module and key extracted from the snippet_key
            //     """
            //     return snippet_key.split('.') if '.' in snippet_key else ('website', snippet_key)
            // 
            // def create_missing_views(create_values):
            //     """ Creates the snippet primary view records that do not exist yet.
            // 
            //         :param create_values: values of records to create
            //         :return: number of created records
            //     """
            //     # Defensive code (low effort): `if values` should always be set
            //     create_values = [values for values in create_values if values]
            // 
            //     keys = [values['key'] for values in create_values]
            //     existing_primary_template_keys = self.env['ir.ui.view'].with_context(active_test=False).search_fetch([
            //         ('mode', '=', 'primary'), ('key', 'in', keys),
            //     ], ['key']).mapped('key')
            //     missing_create_values = [values for values in create_values if values['key'] not in existing_primary_template_keys]
            //     missing_records = self.env['ir.ui.view'].with_context(no_cow=True).create(missing_create_values)
            //     self._create_model_data(missing_records)
            //     return len(missing_records)
            // 
            // def get_create_vals(name, snippet_key, parent_wrap, new_wrap):
            //     """ Returns the create values for the new primary template of the
            //         snippet having snippet_key as its base key, having a new key
            //         formatted with new_wrap, and extending a parent with the key
            //         formatted with parent_wrap.
            // 
            //         :param name: name
            //         :param snippet_key: xmlid of the base block
            //         :param parent_wrap: string pattern used to format the
            //             snippet_key's second part to reach the parent key
            //         :param new_wrap: string pattern used to format the
            //             snippet_key's second part to reach the new key
            //         :return: create values for the new record
            //     """
            //     module, xmlid = split_key(snippet_key)
            //     parent_key = f'{module}.{parent_wrap % xmlid}'
            //     # Equivalent to using an already cached ref, without failing on
            //     # missing key - because the parent records have just been created.
            //     parent_id = self.env['ir.model.data']._xmlid_to_res_model_res_id(parent_key, False)
            //     if not parent_id:
            //         _logger.warning("No such snippet template: %r", parent_key)
            //         return None
            //     return {
            //         'name': name,
            //         'key': f'{module}.{new_wrap % xmlid}',
            //         'inherit_id': parent_id[1],
            //         'mode': 'primary',
            //         'type': 'qweb',
            //         'arch': '<t/>',
            //     }
            // 
            // def get_distinct_snippet_names(structure):
            //     """ Returns the distinct leaves of the structure (tree leaf's list
            //         elements).
            // 
            //         :param structure: dict or list or snippet names
            //         :return: distinct snippet names
            //     """
            //     items = []
            //     for value in structure.values():
            //         if isinstance(value, list):
            //             items.extend(value)
            //         else:
            //             items.extend(get_distinct_snippet_names(value))
            //     return set(items)
            // 
            // create_count = 0
            // manifest = Manifest.for_addon(self.name)
            // 
            // # ------------------------------------------------------------
            // # Configurator
            // # ------------------------------------------------------------
            // 
            // configurator_snippets = dict(manifest.get('configurator_snippets', {}))
            // addons = manifest.get('configurator_snippets_addons', {})
            // installed_modules = self.env['ir.module.module']._installed()
            // 
            // # Add addon snippets to the main snippet list for batch generation
            // for module_name, pages in addons.items():
            //     # generate snippet only if the module is installed
            //     if module_name not in installed_modules and module_name != self.name:
            //         continue
            //     for page, snippets_to_insert in pages.items():
            //         snippets = configurator_snippets.setdefault(page, [])
            //         dynamic_snippets = [snippet for snippet, *_ in snippets_to_insert]
            //         configurator_snippets[page] = list(dict.fromkeys(snippets + dynamic_snippets))
            // 
            // # Generate general configurator snippet templates
            // create_values = []
            // # Every distinct snippet name across all configurator pages.
            // for snippet_name in get_distinct_snippet_names(configurator_snippets):
            //     create_values.append(get_create_vals(
            //         f"Snippet {snippet_name!r} for pages generated by the configurator",
            //         snippet_name, '%s', 'configurator_%s'
            //     ))
            // create_count += create_missing_views(create_values)
            // 
            // # Generate configurator snippet templates for specific pages
            // create_values = []
            // for page_name in configurator_snippets:
            //     for snippet_name in set(configurator_snippets[page_name]):
            //         create_values.append(get_create_vals(
            //             f"Snippet {snippet_name!r} for {page_name!r} pages generated by the configurator",
            //             snippet_name, 'configurator_%s', f'configurator_{page_name}_%s'
            //         ))
            // create_count += create_missing_views(create_values)
            // 
            // # ------------------------------------------------------------
            // # New page templates
            // # ------------------------------------------------------------
            // 
            // templates = manifest.get('new_page_templates', {})
            // 
            // # Generate general new page snippet templates
            // create_values = []
            // # Every distinct snippet name across all new page templates.
            // for snippet_name in get_distinct_snippet_names(templates):
            //     create_values.append(get_create_vals(
            //         f"Snippet {snippet_name!r} for new page templates",
            //         snippet_name, '%s', 'new_page_template_%s'
            //     ))
            // create_count += create_missing_views(create_values)
            // 
            // # Generate new page snippet templates for new page template groups
            // create_values = []
            // for group in templates:
            //     # Every distinct snippet name across all new page templates of group.
            //     for snippet_name in get_distinct_snippet_names(templates[group]):
            //         create_values.append(get_create_vals(
            //             f"Snippet {snippet_name!r} for new page {group!r} templates",
            //             snippet_name, 'new_page_template_%s', f'new_page_template_{group}_%s'
            //         ))
            // create_count += create_missing_views(create_values)
            // 
            // # Generate new page snippet templates for specific new page templates within groups
            // create_values = []
            // for group in templates:
            //     for template_name in templates[group]:
            //         for snippet_name in templates[group][template_name]:
            //             create_values.append(get_create_vals(
            //                 f"Snippet {snippet_name!r} for new page {group!r} template {template_name!r}",
            //                 snippet_name, f'new_page_template_{group}_%s', f'new_page_template_{group}_{template_name}_%s'
            //             ))
            // create_count += create_missing_views(create_values)
            // 
            // if create_count:
            //     _logger.info("Generated %s primary snippet templates for %r", create_count, self.name)
            */
            return default;
        }

        protected async Task<IrModuleModule> GetDescInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _get_desc(self):
            // def _apply_description_images(doc):
            //     html = lxml.html.document_fromstring(doc)
            //     for element, _attribute, _link, _pos in html.iterlinks():
            //         if element.get('src') and not '//' in element.get('src') and not 'static/' in element.get('src'):
            //             element.set('src', "/%s/static/description/%s" % (module.name, element.get('src')))
            //     return tools.html_sanitize(lxml.html.tostring(html, encoding='unicode'))
            // 
            // for module in self:
            //     if not module.name:
            //         module.description_html = False
            //         continue
            //     path = os.path.join(module.name, 'static/description/index.html')
            //     try:
            //         with tools.file_open(path, 'rb') as desc_file:
            //             doc = desc_file.read().decode()
            //             module.description_html = _apply_description_images(doc)
            //     except FileNotFoundError:
            //         overrides = {
            //             'embed_stylesheet': False,
            //             'doctitle_xform': False,
            //             'output_encoding': 'unicode',
            //             'xml_declaration': False,
            //             'file_insertion_enabled': False,
            //         }
            //         output = publish_string(source=module.description if not module.application and module.description else '', settings_overrides=overrides, writer=MyWriter())
            //         module.description_html = _apply_description_images(output)
            */
            return default;
        }

        protected async Task<IrModuleModule> GetIconImageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _get_icon_image(self):
            // super()._get_icon_image()
            // IrAttachment = self.env["ir.attachment"]
            // for module in self.filtered('imported'):
            //     attachment = IrAttachment.sudo().search([
            //         ('url', '=', module.icon),
            //         ('type', '=', 'binary'),
            //         ('res_model', '=', 'ir.ui.view')
            //     ], limit=1)
            //     if attachment:
            //         module.icon_image = attachment.datas
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _get_icon_image(self):
            // self.icon_image = ''
            // for module in self:
            //     if not module.id:
            //         continue
            //     manifest = self.get_module_info(module.name)
            //     if module.icon:
            //         path = module.icon or ''
            //     elif manifest:
            //         path = manifest.get('icon', '')
            //     else:
            //         path = Manifest.for_addon('base').icon
            //     path = path.removeprefix("/")
            //     if path:
            //         try:
            //             with tools.file_open(path, 'rb', filter_ext=('.png', '.svg', '.gif', '.jpeg', '.jpg')) as image_file:
            //                 module.icon_image = base64.b64encode(image_file.read())
            //         except OSError:
            //             module.icon_image = ''
            //     countries = manifest.get('countries', [])
            //     country_code = len(countries) == 1 and countries[0]
            //     module.icon_flag = get_flag(country_code.upper()) if country_code else ''
            */
            return default;
        }

        protected async Task<IrModuleModule> GetIdInternalAsync(object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _get_id(self, name):
            // self.flush_model(['name'])
            // self.env.cr.execute("SELECT id FROM ir_module_module WHERE name=%s", (name,))
            // return self.env.cr.fetchone()
            */
            return default;
        }

        protected async Task<IrModuleModule> GetImportedModuleNamesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _get_imported_module_names(self):
            // return OrderedSet(self.sudo().search_fetch([('imported', '=', True), ('state', '=', 'installed')], ['name']).mapped('name'))
            */
            return default;
        }

        protected async Task<IrModuleModule> GetImportedModuleTranslationsForWebclientInternalAsync(object module, object lang)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _get_imported_module_translations_for_webclient(self, module, lang):
            // if not lang:
            //     lang = self.env.context.get("lang") or 'en_US'
            // IrAttachment = self.env['ir.attachment']
            // 
            // def filter_func(row):
            //     return row.get('value') and JAVASCRIPT_TRANSLATION_COMMENT in row['comments']
            // 
            // translations = {}
            // for lang_ in get_base_langs(lang):
            //     attachment = IrAttachment.sudo().search([
            //         ('name', '=', f"{module}_{lang_}.po"),
            //         ('url', '=', f"/{module}/i18n/{lang_}.po"),
            //         ('res_model', '=', 'ir.module.module'),
            //         ('res_id', '=', self._get_id(module)),
            //         ('type', '=', 'binary'),
            //     ], limit=1)
            //     if attachment.raw:
            //         try:
            //             with io.BytesIO(attachment.raw) as fileobj:
            //                 fileobj.name = attachment.name
            //                 webclient_translations = CodeTranslations._read_code_translations_file(fileobj, filter_func)
            //                 translations.update(webclient_translations)
            //         except Exception:  # noqa: BLE001
            //             _logger.warning('module %s: failed to load translation attachment %s for language %s', module, attachment.name, lang)
            // 
            // return {
            //     'messages': tuple({
            //         'id': src,
            //         'string': value,
            //     } for src, value in translations.items())
            // }
            */
            return default;
        }

        protected async Task<IrModuleModule> GetIndustryCategoriesFromAppsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _get_industry_categories_from_apps(self):
            // import requests  # noqa: PLC0415
            // try:
            //     resp = requests.post(
            //         f"{APPS_URL}/loempia/listindustrycategory",
            //         json={'params': {}},
            //         timeout=5.0,
            //     )
            //     resp.raise_for_status()
            //     return resp.json().get('result', [])
            // except requests.exceptions.HTTPError:
            //     return []
            // except requests.exceptions.ConnectionError:
            //     return []
            */
            return default;
        }

        protected async Task<IrModuleModule> GetInternalAsync(object name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _get(self, name):
            // """ Return the (sudoed) `ir.module.module` record with the given name.
            // The result may be an empty recordset if the module is not found.
            // """
            // model_id = self._get_id(name) if name else False
            // return self.browse(model_id).sudo()
            */
            return default;
        }

        protected async Task<IrModuleModule> GetLatestVersionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _get_latest_version(self):
            // imported_modules = self.filtered(lambda m: m.imported and m.latest_version)
            // for module in imported_modules:
            //     module.installed_version = module.latest_version
            // super(IrModuleModule, self - imported_modules)._get_latest_version()
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _get_latest_version(self):
            // default_version = modules.adapt_version('1.0')
            // for module in self:
            //     module.installed_version = self.get_module_info(module.name).get('version', default_version)
            */
            return default;
        }

        protected async Task<IrModuleModule> GetMissingDependenciesInternalAsync(object zip_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _get_missing_dependencies(self, zip_data):
            // _modules, unavailable_modules = self._get_missing_dependencies_modules(zip_data)
            // description = ''
            // if unavailable_modules:
            //     description = _(
            //         "The installation of the data module would fail as the following dependencies can't"
            //         " be found in the addons-path:\n"
            //     )
            //     for module in unavailable_modules:
            //         description += "- " + module + "\n"
            //     description += _(
            //         "\nYou may need the Enterprise version to install the data module. Please visit "
            //         "https://www.odoo.com/pricing-plan for more information.\n"
            //         "If you need Website themes, it can be downloaded from https://github.com/odoo/design-themes.\n"
            //     )
            // else:
            //     description = _(
            //         "Load demo data to test the industry's features with sample records. "
            //         "Do not load them if this is your production database.",
            //     )
            // return description, unavailable_modules
            */
            return default;
        }

        protected async Task<IrModuleModule> GetMissingDependenciesModulesInternalAsync(object zip_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _get_missing_dependencies_modules(self, zip_data):
            // dependencies_to_install = self.env['ir.module.module']
            // known_mods = self.search([('to_buy', '=', False)])
            // installed_mods = [m.name for m in known_mods if m.state == 'installed']
            // not_found_modules = set()
            // with zipfile.ZipFile(BytesIO(zip_data), "r") as z:
            //     manifest_files = [
            //         file
            //         for file in z.infolist()
            //         if file.filename.count('/') == 1
            //         and file.filename.split('/')[1] in MANIFEST_NAMES
            //     ]
            //     modules_in_zip = {manifest.filename.split('/')[0] for manifest in manifest_files}
            //     for manifest_file in manifest_files:
            //         if manifest_file.file_size > MAX_FILE_SIZE:
            //             raise UserError(_("File '%s' exceed maximum allowed file size", manifest_file.filename))
            //         try:
            //             with z.open(manifest_file) as manifest:
            //                 terp = ast.literal_eval(manifest.read().decode())
            //         except Exception:
            //             continue
            //         unmet_dependencies = set(terp.get('depends', [])).difference(installed_mods, modules_in_zip)
            //         dependencies_to_install |= known_mods.filtered(lambda m: m.name in unmet_dependencies)
            //         not_found_modules |= set(
            //             mod for mod in unmet_dependencies if mod not in dependencies_to_install.mapped('name')
            //         )
            // return dependencies_to_install, not_found_modules
            */
            return default;
        }

        protected async Task<IrModuleModule> GetModuleDataInternalAsync(object model_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _get_module_data(self, model_name):
            // """
            //     Return every theme template model of type ``model_name`` for every theme in ``self``.
            // 
            //     :param model_name: string with the technical name of the model for which to get data.
            //         (the name must be one of the keys present in ``_theme_model_names``)
            //     :return: recordset of theme template models (of type defined by ``model_name``)
            // """
            // if not self.env.user.has_group('website.group_website_restricted_editor'):
            //     raise werkzeug.exceptions.Forbidden()
            // 
            // self_sudo = self.sudo()
            // 
            // theme_model_name = self_sudo._theme_model_names[model_name]
            // IrModelData = self_sudo.env['ir.model.data']
            // records = self_sudo.env[theme_model_name]
            // 
            // for module in self_sudo:
            //     imd_ids = IrModelData.search([('module', '=', module.name), ('model', '=', theme_model_name)]).mapped('res_id')
            //     records |= self_sudo.env[theme_model_name].with_context(active_test=False).browse(imd_ids)
            // return records
            */
            return default;
        }

        public async Task<IrModuleModule> GetModuleInfoAsync(Guid id, IrModuleModuleGetModuleInfoRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def get_module_info(cls, name):
            // if isinstance(name, str):
            //     # we have no info for studio_customization
            //     # imported modules are not found using this method
            //     return modules.Manifest.for_addon(name, display_warning=False) or {}
            // if isinstance(name, modules.Manifest):
            //     return name
            // return {}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModule> GetModulesFromAppsInternalAsync(object fields, object module_type, object module_name, object domain, object limit, object offset)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _get_modules_from_apps(self, fields, module_type, module_name, domain=None, limit=None, offset=None):
            // if 'name' not in fields:
            //     fields = fields + ['name']
            // payload = {
            //     'params': {
            //         'series': major_version,
            //         'module_fields': fields,
            //         'module_type': module_type,
            //         'module_name': module_name,
            //         'domain': domain,
            //         'limit': limit,
            //         'offset': offset,
            //     }
            // }
            // import requests  # noqa: PLC0415
            // try:
            //     resp = self._call_apps(json.dumps(payload))
            //     resp.raise_for_status()
            //     modules_list = resp.json().get('result', [])
            //     for mod in modules_list:
            //         module_name = mod['name']
            //         existing_mod = self.search([('name', '=', module_name), ('state', '=', 'installed')])
            //         mod['id'] = existing_mod.id if existing_mod else -1
            //         if 'icon' in fields:
            //             mod['icon'] = f"{APPS_URL}{mod['icon']}"
            //         if 'state' in fields:
            //             if existing_mod:
            //                 mod['state'] = 'installed'
            //             else:
            //                 mod['state'] = 'uninstalled'
            //         if 'module_type' in fields:
            //             mod['module_type'] = module_type
            //         if 'website' in fields:
            //             mod['website'] = f"{APPS_URL}/apps/modules/{major_version}/{module_name}/"
            //     return modules_list
            // except requests.exceptions.HTTPError:
            //     raise UserError(_('The list of industry applications cannot be fetched. Please try again later'))
            // except requests.exceptions.ConnectionError:
            //     raise UserError(_('Connection to %s failed The list of industry modules cannot be fetched') % APPS_URL)
            */
            return default;
        }

        protected async Task<IrModuleModule> GetModulesToLoadDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _get_modules_to_load_domain(self):
            // # imported modules are not expected to be loaded as regular modules
            // return super()._get_modules_to_load_domain() + [('imported', '=', False)]
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _get_modules_to_load_domain(self):
            // """ Domain to retrieve the modules that should be loaded by the registry. """
            // return [('state', '=', 'installed')]
            */
            return default;
        }

        public async Task<IrModuleModule> GetThemesDomainAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def get_themes_domain(self):
            // """Returns the 'ir.module.module' search domain matching all available themes."""
            // def get_id(model_id):
            //     return self.env['ir.model.data']._xmlid_to_res_id(model_id)
            // return [
            //     ('state', '!=', 'uninstallable'),
            //     ('category_id', 'not in', [
            //         get_id('base.module_category_hidden'),
            //         get_id('base.module_category_theme_hidden'),
            //     ]),
            //     '|',
            //     ('category_id', '=', get_id('base.module_category_theme')),
            //     ('category_id.parent_id', '=', get_id('base.module_category_theme'))
            // ]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> GetValuesFromTerpAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def get_values_from_terp(terp):
            // return {
            //     'description': dedent(terp.get('description', '')),
            //     'shortdesc': terp.get('name', ''),
            //     'author': terp.get('author', 'Unknown'),
            //     'maintainer': terp.get('maintainer', False),
            //     'contributors': ', '.join(terp.get('contributors', [])) or False,
            //     'website': terp.get('website', ''),
            //     'license': terp.get('license', 'LGPL-3'),
            //     'sequence': terp.get('sequence', 100),
            //     'application': terp.get('application', False),
            //     'auto_install': terp.get('auto_install', False) is not False,
            //     'icon': terp.get('icon', False),
            //     'summary': terp.get('summary', ''),
            //     'url': terp.get('url') or terp.get('live_test_url', ''),
            //     'to_buy': False
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModule> GetViewsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _get_views(self):
            // IrModelData = self.env['ir.model.data'].with_context(active_test=True)
            // dmodels = ['ir.ui.view', 'ir.actions.report', 'ir.ui.menu']
            // 
            // for module in self:
            //     # Skip uninstalled modules below, no data to find anyway.
            //     if module.state not in ('installed', 'to upgrade', 'to remove'):
            //         module.views_by_module = ""
            //         module.reports_by_module = ""
            //         module.menus_by_module = ""
            //         continue
            // 
            //     # then, search and group ir.model.data records
            //     imd_models = defaultdict(list)
            //     imd_domain = [('module', '=', module.name), ('model', 'in', tuple(dmodels))]
            //     for data in IrModelData.sudo().search(imd_domain):
            //         imd_models[data.model].append(data.res_id)
            // 
            //     def browse(model):
            //         # as this method is called before the module update, some xmlid
            //         # may be invalid at this stage; explictly filter records before
            //         # reading them
            //         return self.env[model].browse(imd_models[model]).exists()
            // 
            //     def format_view(v):
            //         return '%s%s (%s)' % (v.inherit_id and '* INHERIT ' or '', v.name, v.type)
            // 
            //     module.views_by_module = "\n".join(sorted(format_view(v) for v in browse('ir.ui.view')))
            //     module.reports_by_module = "\n".join(sorted(r.name for r in browse('ir.actions.report')))
            //     module.menus_by_module = "\n".join(sorted(m.complete_name for m in browse('ir.ui.menu')))
            */
            return default;
        }

        protected async Task<IrModuleModule> ImportModuleInternalAsync(object module, object path, object force, object with_demo)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _import_module(self, module, path, force=False, with_demo=False):
            // # Do not create a bridge module for these neutralizations.
            // # Do not involve specific website during import by resetting
            // # information used by website's get_current_website.
            // self = self.with_context(website_id=None)  # noqa: PLW0642
            // force_website_id = None
            // if request and request.session.get('force_website_id'):
            //     force_website_id = request.session.pop('force_website_id')
            // 
            // known_mods = self.search([])
            // known_mods_names = {m.name: m for m in known_mods}
            // installed_mods = [m.name for m in known_mods if m.state == 'installed']
            // 
            // terp = Manifest._from_path(path, env=self.env)
            // if not terp:
            //     return False
            // values = self.get_values_from_terp(terp)
            // try:
            //     icon_path = terp.raw_value('icon') or opj(terp.name, 'static/description/icon.png')
            //     file_path(icon_path, env=self.env, check_exists=True)
            //     values['icon'] = '/' + icon_path
            // except OSError:
            //     pass  # keep the default icon
            // values['latest_version'] = terp.version
            // if self.env.context.get('data_module'):
            //     values['module_type'] = 'industries'
            // 
            // unmet_dependencies = set(terp.get('depends', [])).difference(installed_mods)
            // 
            // if unmet_dependencies:
            //     wrong_dependencies = unmet_dependencies.difference(known_mods.mapped("name"))
            //     if wrong_dependencies:
            //         err = _("Unknown module dependencies:") + "\n - " + "\n - ".join(wrong_dependencies)
            //         raise UserError(err)
            //     to_install = known_mods.filtered(lambda mod: mod.name in unmet_dependencies)
            //     to_install.button_immediate_install()
            // elif 'web_studio' not in installed_mods and _is_studio_custom(path):
            //     raise UserError(_("Studio customizations require the Odoo Studio app."))
            // 
            // mod = known_mods_names.get(module)
            // if mod:
            //     mod.write(dict(state='installed', **values))
            //     mode = 'update' if not force else 'init'
            // else:
            //     assert terp.get('installable', True), "Module not installable"
            //     mod = self.create(dict(name=module, state='installed', imported=True, **values))
            //     mode = 'init'
            // 
            // exclude_list = set()
            // base_dir = pathlib.Path(path)
            // for pattern in terp.get('cloc_exclude', []):
            //     exclude_list.update(str(p.relative_to(base_dir)) for p in base_dir.glob(pattern) if p.is_file())
            // 
            // kind_of_files = ['data', 'init_xml']
            // if with_demo:
            //     kind_of_files.append('demo')
            // for kind in kind_of_files:
            //     for filename in terp.get(kind, []):
            //         ext = os.path.splitext(filename)[1].lower()
            //         if ext not in ('.xml', '.csv', '.sql'):
            //             _logger.info("module %s: skip unsupported file %s", module, filename)
            //             continue
            //         _logger.info("module %s: loading %s", module, filename)
            //         noupdate = ext == '.csv' and kind == 'init_xml'
            //         pathname = opj(path, filename)
            //         idref = {}
            //         convert_file(self.env, module, filename, idref, mode, noupdate, pathname=pathname)
            //         if filename in exclude_list:
            //             for xml_id, rec_id in idref.items():
            //                 name = xml_id.replace('.', '_')
            //                 if self.env.ref(f"__cloc_exclude__.{name}", raise_if_not_found=False):
            //                     continue
            //                 self.env['ir.model.data'].create([{
            //                     'name': name,
            //                     'model': self.env['ir.model.data']._xmlid_lookup(xml_id)[0],
            //                     'module': "__cloc_exclude__",
            //                     'res_id': rec_id,
            //                 }])
            // 
            // path_static = opj(path, 'static')
            // IrAttachment = self.env['ir.attachment']
            // if os.path.isdir(path_static):
            //     for root, _dirs, files in os.walk(path_static):
            //         for static_file in files:
            //             full_path = opj(root, static_file)
            //             with file_open(full_path, 'rb', env=self.env) as fp:
            //                 data = base64.b64encode(fp.read())
            //             url_path = '/{}{}'.format(module, full_path.split(path)[1].replace(os.path.sep, '/'))
            //             if not isinstance(url_path, str):
            //                 url_path = url_path.decode(sys.getfilesystemencoding())
            //             filename = os.path.split(url_path)[1]
            //             values = dict(
            //                 name=filename,
            //                 url=url_path,
            //                 res_model='ir.ui.view',
            //                 type='binary',
            //                 datas=data,
            //             )
            //             # Do not create a bridge module for this check.
            //             if 'public' in IrAttachment._fields:
            //                 # Static data is public and not website-specific.
            //                 values['public'] = True
            //             attachment = IrAttachment.sudo().search([('url', '=', url_path), ('type', '=', 'binary'), ('res_model', '=', 'ir.ui.view')])
            //             if attachment:
            //                 attachment.write(values)
            //             else:
            //                 attachment = IrAttachment.create(values)
            //                 self.env['ir.model.data'].create({
            //                     'name': f"attachment_{url_path}".replace('.', '_').replace(' ', '_'),
            //                     'model': 'ir.attachment',
            //                     'module': module,
            //                     'res_id': attachment.id,
            //                 })
            //                 if str(pathlib.Path(full_path).relative_to(base_dir)) in exclude_list:
            //                     self.env['ir.model.data'].create({
            //                         'name': f"cloc_exclude_attachment_{url_path}".replace('.', '_').replace(' ', '_'),
            //                         'model': 'ir.attachment',
            //                         'module': "__cloc_exclude__",
            //                         'res_id': attachment.id,
            //                     })
            // 
            // # store translation files as attachments to allow loading translations for webclient
            // path_lang = opj(path, 'i18n')
            // if os.path.isdir(path_lang):
            //     for entry in os.scandir(path_lang):
            //         if not entry.is_file() or not entry.name.endswith('.po'):
            //             # we don't support sub-directories in i18n
            //             continue
            //         with file_open(entry.path, 'rb', env=self.env) as fp:
            //             raw = fp.read()
            //         lang = entry.name.split('.')[0]
            //         # store as binary ir.attachment
            //         values = {
            //             'name': f'{module}_{lang}.po',
            //             'url': f'/{module}/i18n/{lang}.po',
            //             'res_model': 'ir.module.module',
            //             'res_id': mod.id,
            //             'type': 'binary',
            //             'raw': raw,
            //         }
            //         attachment = IrAttachment.sudo().search([('url', '=', values['url']), ('type', '=', 'binary'), ('name', '=', values['name'])])
            //         if attachment:
            //             attachment.write(values)
            //         else:
            //             attachment = IrAttachment.create(values)
            //             self.env['ir.model.data'].create({
            //                 'name': f'attachment_{module}_{lang}'.replace('.', '_').replace(' ', '_'),
            //                 'model': 'ir.attachment',
            //                 'module': module,
            //                 'res_id': attachment.id,
            //             })
            // 
            // IrAsset = self.env['ir.asset']
            // assets_vals = []
            // 
            // # Generate 'ir.asset' record values for each asset delared in the manifest
            // for bundle, commands in terp.get('assets', {}).items():
            //     for command in commands:
            //         directive, target, path = IrAsset._process_command(command)
            //         if is_wildcard_glob(path):
            //             raise UserError(_(
            //                 "The assets path in the manifest of imported module '%(module_name)s' "
            //                 "cannot contain glob wildcards (e.g., *, **).", module_name=module))
            //         path = path if path.startswith('/') else '/' + path # Ensures a '/' at the start
            //         assets_vals.append({
            //             'name': f'{module}.{bundle}.{path}',
            //             'directive': directive,
            //             'target': target,
            //             'path': path,
            //             'bundle': bundle,
            //         })
            // 
            // # Look for existing assets
            // existing_assets = {
            //     asset.name: asset
            //     for asset in IrAsset.search([('name', 'in', [vals['name'] for vals in assets_vals])])
            // }
            // assets_to_create = []
            // 
            // # Update existing assets and generate the list of new assets values
            // for values in assets_vals:
            //     if values['name'] in existing_assets:
            //         existing_assets[values['name']].write(values)
            //     else:
            //         assets_to_create.append(values)
            // 
            // # Create new assets and attach 'ir.model.data' records to them
            // created_assets = IrAsset.create(assets_to_create)
            // self.env['ir.model.data'].create([{
            //     'name': f"{asset['bundle']}_{asset['path']}".replace(".", "_"),
            //     'model': 'ir.asset',
            //     'module': module,
            //     'res_id': asset.id,
            // } for asset in created_assets])
            // 
            // self.env['ir.module.module']._load_module_terms(
            //     [module],
            //     [lang for lang, _name in self.env['res.lang'].get_installed()],
            //     overwrite=True,
            // )
            // 
            // if ('knowledge.article' in self.env
            //     and (article_record := self.env.ref(f"{module}.welcome_article", raise_if_not_found=False))
            //     and article_record._name == 'knowledge.article'
            //     and self.env.ref(f"{module}.welcome_article_body", raise_if_not_found=False)
            // ):
            //     body = self.env['ir.qweb']._render(f"{module}.welcome_article_body", lang=self.env.user.lang)
            //     article_record.write({'body': body})
            // 
            // mod._update_from_terp(terp)
            // _logger.info("Successfully imported module '%s'", module)
            // 
            // if force_website_id:
            //     # Restore neutralized website_id.
            //     request.session['force_website_id'] = force_website_id
            // 
            // return True
            */
            return default;
        }

        protected async Task<IrModuleModule> ImportZipfileInternalAsync(object module_file, object force, object with_demo)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _import_zipfile(self, module_file, force=False, with_demo=False):
            // if not self.env.is_admin():
            //     raise AccessError(_("Only administrators can install data modules."))
            // if not module_file:
            //     raise Exception(_("No file sent."))
            // if not zipfile.is_zipfile(module_file):
            //     raise UserError(_('Only zip files are supported.'))
            // 
            // module_names = []
            // with zipfile.ZipFile(module_file, "r") as z:
            //     for zf in z.infolist():
            //         if zf.file_size > MAX_FILE_SIZE:
            //             raise UserError(_("File '%s' exceed maximum allowed file size", zf.filename))
            // 
            //     with file_open_temporary_directory(self.env) as module_dir:
            //         manifest_files = sorted(
            //             (file.filename.split('/')[0], file)
            //             for file in z.infolist()
            //             if file.filename.count('/') == 1
            //             and file.filename.split('/')[1] in MANIFEST_NAMES
            //         )
            //         module_data_files = defaultdict(list)
            //         dependencies = defaultdict(list)
            //         for mod_name, manifest in manifest_files:
            //             _manifest_path = z.extract(manifest, module_dir)
            //             terp = Manifest._from_path(opj(module_dir, mod_name), env=self.env)
            //             if not terp:
            //                 continue
            //             files_to_import = terp.get('data', []) + terp.get('init_xml', []) + terp.get('update_xml', [])
            //             if with_demo:
            //                 files_to_import += terp.get('demo', [])
            //             for filename in files_to_import:
            //                 if os.path.splitext(filename)[1].lower() not in ('.xml', '.csv', '.sql'):
            //                     continue
            //                 module_data_files[mod_name].append('%s/%s' % (mod_name, filename))
            //             dependencies[mod_name] = terp.get('depends', [])
            // 
            //         dirs = {d for d in os.listdir(module_dir) if os.path.isdir(opj(module_dir, d))}
            //         sorted_dirs = topological_sort(dependencies)
            //         if wrong_modules := dirs.difference(sorted_dirs):
            //             raise UserError(_(
            //                 "No manifest found in '%(modules)s'. Can't import the zip file.",
            //                 modules=", ".join(wrong_modules)
            //             ))
            // 
            //         for file in z.infolist():
            //             filename = file.filename
            //             mod_name = filename.split('/')[0]
            //             is_data_file = filename in module_data_files[mod_name]
            //             is_static = filename.startswith('%s/static' % mod_name)
            //             is_translation = filename.startswith('%s/i18n' % mod_name) and filename.endswith('.po')
            //             if is_data_file or is_static or is_translation:
            //                 z.extract(file, module_dir)
            // 
            //         for mod_name in sorted_dirs:
            //             module_names.append(mod_name)
            //             try:
            //                 # assert mod_name.startswith('theme_')
            //                 path = opj(module_dir, mod_name)
            //                 self.sudo()._import_module(mod_name, path, force=force, with_demo=with_demo)
            //             except Exception as e:
            //                 raise UserError(_(
            //                     "Error while importing module '%(module)s'.\n\n %(error_message)s \n\n",
            //                     module=mod_name, error_message=traceback.format_exc(),
            //                 )) from e
            // return "", module_names
            */
            return default;
        }

        protected async Task<IrModuleModule> InstalledInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _installed(self):
            // """ Return the set of installed modules as a dictionary {name: id} """
            // return {
            //     module.name: module.id
            //     for module in self.sudo().search([('state', '=', 'installed')])
            // }
            */
            return default;
        }

        protected async Task<IrModuleModule> LoadModuleTermsInternalAsync(object modules, object langs, object overwrite)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_module.py) ---
            // def _load_module_terms(self, modules, langs, overwrite=False):
            // super()._load_module_terms(modules, langs, overwrite=overwrite)
            // if 'account' in modules:
            //     def load_account_translations(env):
            //         env['account.chart.template']._load_translations(langs=langs)
            //         env['account.account.tag']._translate_tax_tags(langs=langs)
            //     if self.env.registry.loaded:
            //         load_account_translations(self.env)
            //     else:
            //         self.env.registry._delayed_account_translator = load_account_translations
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def _load_module_terms(self, modules, langs, overwrite=False):
            // super()._load_module_terms(modules, langs, overwrite=overwrite)
            // 
            // translation_importer = TranslationImporter(self.env.cr, verbose=False)
            // IrAttachment = self.env['ir.attachment']
            // 
            // for module in modules:
            //     if Manifest.for_addon(module, display_warning=False):
            //         continue
            //     for lang in langs:
            //         for lang_ in get_base_langs(lang):
            //             # Translations for imported data modules only works with imported po files
            //             attachment = IrAttachment.sudo().search([
            //                 ('name', '=', f"{module}_{lang_}.po"),
            //                 ('url', '=', f"/{module}/i18n/{lang_}.po"),
            //                 ('type', '=', 'binary'),
            //             ], limit=1)
            //             if attachment.raw:
            //                 try:
            //                     with io.BytesIO(attachment.raw) as fileobj:
            //                         fileobj.name = attachment.name
            //                         translation_importer.load(fileobj, 'po', lang, module=module)
            //                 except Exception:   # noqa: BLE001
            //                     _logger.warning('module %s: failed to load translation attachment %s for language %s', module, attachment.name, lang)
            //         if lang != 'en_US' and lang not in translation_importer.imported_langs:
            //             _logger.info('module %s: no translation for language %s', module, lang)
            // 
            // translation_importer.save(overwrite=overwrite)
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _load_module_terms(self, modules, langs, overwrite=False):
            // """ Add missing website specific translation """
            // res = super()._load_module_terms(modules, langs, overwrite=overwrite)
            // 
            // if not langs or langs == ['en_US'] or not modules:
            //     return res
            // 
            // # Add specific view translations
            // 
            // # use the translation dic of the generic to translate the specific
            // self.env.cr.flush()
            // View = self.env['ir.ui.view']
            // field = self.env['ir.ui.view']._fields['arch_db']
            // batch_size = PREFETCH_MAX // 10
            // self.env.cr.execute(""" SELECT generic.arch_db, specific.arch_db, specific.id
            //                                   FROM ir_ui_view generic
            //                                  INNER JOIN ir_ui_view specific
            //                                     ON generic.key = specific.key
            //                                  WHERE generic.website_id IS NULL AND generic.type = 'qweb'
            //                                  AND specific.website_id IS NOT NULL
            //                                  AND generic.arch_db IS NOT NULL
            //                                  AND specific.arch_db IS NOT NULL
            //                     """)
            // while batch := self.env.cr.fetchmany(batch_size):
            //     for generic_arch_db, specific_arch_db, specific_id in batch:
            //         langs_update = (langs & generic_arch_db.keys()) - {'en_US'}
            //         if not langs_update:
            //             continue
            //         # get dictionaries limited to the requested languages
            //         generic_arch_db_en = generic_arch_db.get('en_US')
            //         specific_arch_db_en = specific_arch_db.get('en_US')
            //         generic_arch_db_update = {k: generic_arch_db[k] for k in langs_update}
            //         specific_arch_db_update = {k: specific_arch_db.get(k, specific_arch_db_en) for k in langs_update}
            //         generic_translation_dictionary = field.get_translation_dictionary(generic_arch_db_en, generic_arch_db_update)
            //         specific_translation_dictionary = field.get_translation_dictionary(specific_arch_db_en, specific_arch_db_update)
            //         # update specific_translation_dictionary
            //         for term_en, specific_term_langs in specific_translation_dictionary.items():
            //             if term_en not in generic_translation_dictionary:
            //                 continue
            //             for lang, generic_term_lang in generic_translation_dictionary[term_en].items():
            //                 if overwrite or term_en == specific_term_langs[lang]:
            //                     specific_term_langs[lang] = generic_term_lang
            //         for lang in langs_update:
            //             specific_arch_db[lang] = field.translate(
            //                 lambda term: specific_translation_dictionary.get(term, {lang: None})[lang], specific_arch_db_en)
            //         field._update_cache(View.with_context(prefetch_langs=True).browse(specific_id), specific_arch_db, dirty=True)
            // default_menu = self.env.ref('website.main_menu', raise_if_not_found=False)
            // if not default_menu:
            //     return res
            // 
            // lang_value_list = [SQL("%(lang)s, o_menu.name->>%(lang)s", lang=lang) for lang in langs if lang != 'en_US']
            // update_jsonb_list = [SQL('jsonb_build_object(%s)', SQL(', ').join(items)) for items in split_every(50, lang_value_list)]
            // update_jsonb = SQL(' || ').join(update_jsonb_list)
            // o_menu_name = SQL('menu.name || %s' if overwrite else '%s || menu.name', update_jsonb)
            // self.env.cr.execute(SQL(
            //     """
            //     UPDATE website_menu menu
            //        SET name = %(o_menu_name)s
            //       FROM website_menu o_menu
            //      INNER JOIN website_menu s_menu
            //         ON o_menu.name->>'en_US' = s_menu.name->>'en_US' AND o_menu.url = s_menu.url
            //      INNER JOIN website_menu root_menu
            //         ON s_menu.parent_id = root_menu.id AND root_menu.parent_id IS NULL
            //      WHERE o_menu.website_id IS NULL AND o_menu.parent_id = %(default_menu_id)s
            //        AND s_menu.website_id IS NOT NULL
            //        AND menu.id = s_menu.id
            //     """,
            //     o_menu_name=o_menu_name,
            //     default_menu_id=default_menu.id
            // ))
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: ir_module_module.py) ---
            // def _load_module_terms(self, modules, langs, overwrite=False):
            // # Add missing website_sale-specific translations
            // 
            // super()._load_module_terms(modules, langs, overwrite=overwrite)
            // 
            // to_langs = [lang for lang in langs if lang != 'en_US']
            // if not (to_langs and modules):
            //     return  # nothing to translate
            // 
            // def set_field(fname):
            //     lang_items = (
            //         SQL('%(lang)s, o_step.%(fname)s->>%(lang)s', lang=lang, fname=fname)
            //         for lang in to_langs
            //     )
            //     # PSQL functions take 100 args max, and we're generating 2 per lang
            //     batched_lang_items = split_every(50, lang_items)
            //     update_jsonb = SQL(' || ').join(
            //         SQL('jsonb_build_object(%s)', SQL(', ').join(batch))
            //         for batch in batched_lang_items
            //     )
            //     ordered = reversed if overwrite else iter
            //     src = SQL(' || ').join(ordered([
            //         SQL('jsonb_strip_nulls(%s)', update_jsonb),  # gets updated translation
            //         SQL('jsonb_strip_nulls(step.%s)', fname),  # keeps current translation
            //     ]))
            //     return SQL('%(fname)s = %(src)s', fname=fname, src=src)
            // 
            // WebsiteCheckoutStep = self.env['website.checkout.step']
            // to_translate = [
            //     SQL.identifier(field.name)
            //     for field in WebsiteCheckoutStep._fields.values()
            //     if field.translate is True  # more correct in case of `callable(field.translate)`
            // ]
            // set_fields = SQL(', ').join(set_field(fname) for fname in to_translate)
            // 
            // WebsiteCheckoutStep.invalidate_model()
            // self.env.cr.execute(SQL(
            //     '''
            //     UPDATE website_checkout_step step
            //        SET %(set_fields)s
            //       FROM website_checkout_step o_step
            //       JOIN website_checkout_step s_step
            //         ON o_step.step_href = s_step.step_href
            //      WHERE o_step.website_id IS NULL
            //        AND s_step.website_id IS NOT NULL
            //        AND step.id = s_step.id
            //     ''',
            //     set_fields=set_fields,
            // ))
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _load_module_terms(self, modules, langs, overwrite=False):
            // """ Load PO files of the given modules for the given languages. """
            // # load i18n files
            // translation_importer = TranslationImporter(self.env.cr, verbose=False)
            // 
            // for module_name in modules:
            //     if not Manifest.for_addon(module_name, display_warning=False):
            //         continue
            //     for lang in langs:
            //         for po_path in get_po_paths(module_name, lang):
            //             _logger.info('module %s: loading translation file %s for language %s', module_name, po_path, lang)
            //             translation_importer.load_file(po_path, lang)
            //         for data_path in get_datafile_translation_path(module_name):
            //             translation_importer.load_file(data_path, lang, module=module_name)
            //         if lang != 'en_US' and lang not in translation_importer.imported_langs:
            //             _logger.info('module %s: no translation for language %s', module_name, lang)
            // 
            // translation_importer.save(overwrite=overwrite)
            */
            return default;
        }

        protected async Task<IrModuleModule> LoadPosDataDomainInternalAsync(object data, object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: ir_module_module.py) ---
            // def _load_pos_data_domain(self, data, config):
            // return [('name', '=', 'pos_settle_due')]
            */
            return default;
        }

        protected async Task<IrModuleModule> LoadPosDataFieldsInternalAsync(object config)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: ir_module_module.py) ---
            // def _load_pos_data_fields(self, config):
            // return ['id', 'name', 'state']
            */
            return default;
        }

        public async Task<IrModuleModule> ModuleUninstallAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_module.py) ---
            // def module_uninstall(self):
            // unlinked_templates = [code for template in self.mapped('account_templates') for code in template]
            // if unlinked_templates:
            //     companies = self.env['res.company'].search([
            //         ('chart_template', 'in', unlinked_templates),
            //     ])
            //     companies.chart_template = False
            //     companies.flush_recordset()
            // 
            // return super().module_uninstall()
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def module_uninstall(self):
            // # Delete an ir_module_module record completely if it was an imported
            // # one. The rationale behind this is that an imported module *cannot* be
            // # reinstalled anyway, as it requires the data files. Any attempt to
            // # install it again will simply fail without trace.
            // # /!\ modules_to_delete must be calculated before calling super().module_uninstall(),
            // # because when uninstalling `base_import_module` the `imported` column will no longer be
            // # in the database but we'll still have an old registry that runs this code.
            // modules_to_delete = self.filtered('imported')
            // res = super().module_uninstall()
            // if modules_to_delete:
            //     deleted_modules_names = modules_to_delete.mapped('name')
            //     _logger.info("deleting imported modules upon uninstallation: %s",
            //                  ", ".join(deleted_modules_names))
            //     modules_to_delete.unlink()
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def module_uninstall(self):
            // """ Perform the various steps required to uninstall a module completely
            // including the deletion of all database structures created by the module:
            // tables, columns, constraints, etc.
            // """
            // modules_to_remove = self.mapped('name')
            // self.env['ir.model.data']._module_data_uninstall(modules_to_remove)
            // # we deactivate prefetching to not try to read a column that has been deleted
            // self.with_context(prefetch_fields=False).write({'state': 'uninstalled', 'latest_version': False})
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> MoreInfoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def more_info(self):
            // return {
            //     'name': _('Apps'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.module.module',
            //     'view_mode': 'form',
            //     'res_id': self.id,
            //     'context': self.env.context,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> NextAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def next(self):
            // """
            // Return the action linked to an ir.actions.todo is there exists one that
            // should be executed. Otherwise, redirect to /web
            // """
            // Todos = self.env['ir.actions.todo']
            // _logger.info('getting next %s', Todos)
            // active_todo = Todos.search([('state', '=', 'open')], limit=1)
            // if active_todo:
            //     _logger.info('next action is "%s"', active_todo.name)
            //     return active_todo.action_launch()
            // return {
            //     'type': 'ir.actions.act_url',
            //     'target': 'self',
            //     'url': '/odoo',
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> OpenInstallRequestAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_install_request, FILE: ir_module_module.py) ---
            // def action_open_install_request(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'name': _('Activation Request of "%s"', self.shortdesc),
            //     'view_mode': 'form',
            //     'res_model': 'base.module.install.request',
            //     'context': {'default_module_id': self.id},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModule> PostCopyInternalAsync(object old_rec, object new_rec)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _post_copy(self, old_rec, new_rec):
            // self.ensure_one()
            // translated_fields = self._theme_translated_fields.get(old_rec._name, [])
            // cur_lang = self.env.lang or 'en_US'
            // valid_langs = set(code for code, _ in self.env['res.lang'].get_installed()) | {'en_US'}
            // old_rec.flush_recordset()
            // for (src_field, dst_field) in translated_fields:
            //     __, src_fname = src_field.split(',')
            //     dst_mname, dst_fname = dst_field.split(',')
            //     if dst_mname != new_rec._name:
            //         continue
            //     old_field = old_rec._fields[src_fname]
            //     old_stored_translations = old_field._get_stored_translations(old_rec)
            //     if not old_stored_translations:
            //         continue
            //     if old_field.translate is True:
            //         if old_rec[src_fname] != new_rec[dst_fname]:
            //             continue
            //         new_rec.update_field_translations(dst_fname, {
            //             k: v for k, v in old_stored_translations.items() if k in valid_langs and k != cur_lang
            //         })
            //     else:
            //         old_translations = {
            //             k: old_stored_translations.get(f'_{k}', v)
            //             for k, v in old_stored_translations.items()
            //             if k in valid_langs
            //         }
            //         # {from_lang_term: {lang: to_lang_term}
            //         translation_dictionary = old_field.get_translation_dictionary(
            //             old_translations.pop(cur_lang, old_translations['en_US']),
            //             old_translations
            //         )
            //         # {lang: {old_term: new_term}
            //         translations = defaultdict(dict)
            //         for from_lang_term, to_lang_terms in translation_dictionary.items():
            //             for lang, to_lang_term in to_lang_terms.items():
            //                 translations[lang][from_lang_term] = to_lang_term
            //         new_rec.with_context(install_filename='dummy').update_field_translations(dst_fname, translations)
            */
            return default;
        }

        protected async Task<IrModuleModule> RegisterHookInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_module.py) ---
            // def _register_hook(self):
            // super()._register_hook()
            // if hasattr(self.env.registry, '_delayed_account_translator'):
            //     self.env.registry._delayed_account_translator(self.env)
            //     del self.env.registry._delayed_account_translator
            // if hasattr(self.env.registry, '_auto_install_template'):
            //     self.env.registry._auto_install_template(self.env)
            //     del self.env.registry._auto_install_template
            */
            return default;
        }

        protected async Task<IrModuleModule> RemoveCopiedViewsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _remove_copied_views(self):
            // """ Remove the copies of the views installed by the modules in `self`.
            // 
            // Those copies do not have an external id so they will not be cleaned by
            // `_module_data_uninstall`. This is why we rely on `key` instead.
            // 
            // It is important to remove these copies because using them will crash if
            // they rely on data that don't exist anymore if the module is removed.
            // """
            // domain = Domain.OR(Domain('key', '=like', m.name + '.%') for m in self)
            // orphans = self.env['ir.ui.view'].with_context(**{'active_test': False, MODULE_UNINSTALL_FLAG: True}).search(domain)
            // orphans.unlink()
            */
            return default;
        }

        public async Task<IrModuleModule> SearchPanelSelectRangeAsync(Guid id, IrModuleModuleSearchPanelSelectRangeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def search_panel_select_range(self, field_name, **kwargs):
            // if field_name == 'category_id' and _domain_asks_for_industries(kwargs.get('category_domain', [])):
            //     categories = self._get_industry_categories_from_apps()
            //     return {
            //         'parent_field': 'parent_id',
            //         'values': categories,
            //     }
            // return super().search_panel_select_range(field_name, **kwargs)
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def search_panel_select_range(self, field_name, **kwargs):
            // if field_name == 'category_id':
            //     enable_counters = kwargs.get('enable_counters', False)
            //     domain = Domain([
            //         ('parent_id', '=', False),
            //         '|',
            //         ('module_ids.application', '!=', False),
            //         ('child_ids.module_ids', '!=', False),
            //     ])
            // 
            //     excluded_xmlids = [
            //         'base.module_category_website_theme',
            //         'base.module_category_theme',
            //     ]
            //     if not self.env.user.has_group('base.group_no_one'):
            //         excluded_xmlids.append('base.module_category_hidden')
            // 
            //     excluded_category_ids = []
            //     for excluded_xmlid in excluded_xmlids:
            //         categ = self.env.ref(excluded_xmlid, False)
            //         if not categ:
            //             continue
            //         excluded_category_ids.append(categ.id)
            // 
            //     if excluded_category_ids:
            //         domain &= Domain('id', 'not in', excluded_category_ids)
            // 
            //     records = self.env['ir.module.category'].search_read(domain, ['display_name'], order="sequence")
            // 
            //     values_range = OrderedDict()
            //     for record in records:
            //         record_id = record['id']
            //         if enable_counters:
            //             model_domain = Domain.AND([
            //                 kwargs.get('search_domain', []),
            //                 kwargs.get('category_domain', []),
            //                 kwargs.get('filter_domain', []),
            //                 [('category_id', 'child_of', record_id), ('category_id', 'not in', excluded_category_ids)]
            //             ])
            //             record['__count'] = self.env['ir.module.module'].search_count(model_domain)
            //         values_range[record_id] = record
            // 
            //     return {
            //         'parent_field': 'parent_id',
            //         'values': list(values_range.values()),
            //     }
            // 
            // return super().search_panel_select_range(field_name, **kwargs)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModule> StateUpdateInternalAsync(object newstate, object states_to_update, object level)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _state_update(self, newstate, states_to_update, level=100):
            // if level < 1:
            //     raise UserError(_('Recursion error in modules dependencies!'))
            // 
            // for module in self:
            //     if module.state not in states_to_update:
            //         continue
            // 
            //     # determine dependency modules to update/others
            //     update_mods, ready_mods = self.browse(), self.browse()
            //     for dep in module.dependencies_id:
            //         if dep.state == 'unknown':
            //             raise UserError(_(
            //                 'You try to install module "%(module)s" that depends on module "%(dependency)s".\nBut the latter module is not available in your system.',
            //                 module=module.name, dependency=dep.name,
            //             ))
            //         if dep.depend_id.state == newstate:
            //             ready_mods += dep.depend_id
            //         else:
            //             update_mods += dep.depend_id
            // 
            //     # update dependency modules that require it
            //     update_mods._state_update(newstate, states_to_update, level=level-1)
            // 
            //     if module.state in states_to_update:
            //         # check dependencies and update module itself
            //         self.check_external_dependencies(module.name, newstate)
            //         module.write({'state': newstate})
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeCleanupInternalAsync(object model_name, object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _theme_cleanup(self, model_name, website):
            // """
            //     Remove orphan models of type ``model_name`` from the current theme and
            //     for the website ``website``.
            // 
            //     We need to compute it this way because if the upgrade (or deletion) of a theme module
            //     removes a model template, then in the model itself the variable
            //     ``theme_template_id`` will be set to NULL and the reference to the theme being removed
            //     will be lost. However we do want the ophan to be deleted from the website when
            //     we upgrade or delete the theme from the website.
            // 
            //     ``website.page`` and ``website.menu`` don't have ``key`` field so we don't clean them.
            //     TODO in master: add a field ``theme_id`` on the models to more cleanly compute orphans.
            // 
            //     :param model_name: string with the technical name of the model to cleanup
            //         (the name must be one of the keys present in ``_theme_model_names``)
            //     :param website: ``website`` model for which the models have to be cleaned
            // 
            // """
            // if not self.env.user.has_group('website.group_website_restricted_editor'):
            //     raise werkzeug.exceptions.Forbidden()
            // 
            // self.ensure_one()
            // model_sudo = self.env[model_name].sudo()
            // 
            // if model_name in ('website.page', 'website.menu'):
            //     return model_sudo
            // # use active_test to also unlink archived models
            // # and use MODULE_UNINSTALL_FLAG to also unlink inherited models
            // orphans = model_sudo.with_context(**{'active_test': False, MODULE_UNINSTALL_FLAG: True}).search([
            //     ('key', '=like', self.name + '.%'),
            //     ('website_id', '=', website.id),
            //     ('theme_template_id', '=', False),
            // ])
            // orphans.unlink()
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeGetDownstreamInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _theme_get_downstream(self):
            // """
            //     Return installed downstream themes that starts with the same name.
            // 
            //     eg. For theme_A, this will return theme_A_sale, but not theme_B even if theme B
            //         depends on theme_A.
            // 
            //     :return: recordset of themes ``ir.module.module``
            // """
            // self.ensure_one()
            // return self.downstream_dependencies().filtered(lambda x: x.name.startswith(self.name))
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeGetStreamThemesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _theme_get_stream_themes(self):
            // """
            //     Returns all the themes in the stream of the current theme.
            // 
            //     First find all its downstream themes, and all of the upstream themes of both
            //     sorted by their level in hierarchy, up first.
            // 
            //     :return: recordset of themes ``ir.module.module``
            // """
            // self.ensure_one()
            // all_mods = self + self._theme_get_downstream()
            // for down_mod in self._theme_get_downstream() + self:
            //     for up_mod in down_mod._theme_get_upstream():
            //         all_mods = up_mod | all_mods
            // return all_mods
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeGetStreamWebsiteIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _theme_get_stream_website_ids(self):
            // """
            //     Websites for which this theme (self) is in the stream (up or down) of their theme.
            // 
            //     :return: recordset of websites ``website``
            // """
            // self.ensure_one()
            // websites = self.env['website']
            // for website in websites.search([('theme_id', '!=', False)]):
            //     if self in website.theme_id._theme_get_stream_themes():
            //         websites |= website
            // return websites
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeGetUpstreamInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _theme_get_upstream(self):
            // """
            //     Return installed upstream themes.
            // 
            //     :return: recordset of themes ``ir.module.module``
            // """
            // self.ensure_one()
            // return self.upstream_dependencies(exclude_states=('',)).filtered(lambda x: x.name.startswith('theme_'))
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeLoadInternalAsync(object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _theme_load(self, website):
            // """
            //     For every type of model in ``self._theme_model_names``, and for every theme in ``self``:
            //     create/update real models for the website ``website`` based on the theme template models.
            // 
            //     :param website: ``website`` model on which to load the themes
            // """
            // for module in self:
            //     _logger.info('Load theme %s for website %s from template.' % (module.mapped('name'), website.id))
            // 
            //     for model_name in self._theme_model_names:
            //         module._update_records(model_name, website)
            // 
            //     if self.env.context.get('apply_new_theme'):
            //         # Both the theme install and upgrade flow ends up here.
            //         # The _post_copy() is supposed to be called only when the theme
            //         # is installed for the first time on a website.
            //         # It will basically select some header and footer template.
            //         # We don't want the system to select again the theme footer or
            //         # header template when that theme is updated later. It could
            //         # erase the change the user made after the theme install.
            //         self.env['theme.utils'].with_context(website_id=website.id)._post_copy(module)
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeRemoveInternalAsync(object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _theme_remove(self, website):
            // """
            //     Remove from ``website`` its current theme, including all the themes in the stream.
            // 
            //     The order of removal will be reverse of installation to handle dependencies correctly.
            // 
            //     :param website: ``website`` model for which the themes have to be removed
            // """
            // # _theme_remove is the entry point of any change of theme for a website
            // # (either removal or installation of a theme and its dependencies). In
            // # either case, we need to reset some default configuration before.
            // self.env['theme.utils'].with_context(website_id=website.id)._reset_default_config()
            // 
            // if not website.theme_id:
            //     return
            // 
            // for theme in reversed(website.theme_id._theme_get_stream_themes()):
            //     theme._theme_unload(website)
            // website.theme_id = False
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeUnloadInternalAsync(object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _theme_unload(self, website):
            // """
            //     For every type of model in ``self._theme_model_names``, and for every theme in ``self``:
            //     remove real models that were generated based on the theme template models
            //     for the website ``website``.
            // 
            //     :param website: ``website`` model on which to unload the themes
            // """
            // for module in self:
            //     _logger.info('Unload theme %s for website %s from template.' % (self.mapped('name'), website.id))
            // 
            //     for model_name in module._theme_model_names:
            //         template = module._get_module_data(model_name)
            //         models = template.with_context(**{'active_test': False, MODULE_UNINSTALL_FLAG: True}).mapped('copy_ids').filtered(lambda m: m.website_id == website)
            //         models.unlink()
            //         module._theme_cleanup(model_name, website)
            */
            return default;
        }

        protected async Task<IrModuleModule> ThemeUpgradeUpstreamInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _theme_upgrade_upstream(self):
            // """ Upgrade the upstream dependencies of a theme, and install it if necessary. """
            // if not self.env.user.has_group('website.group_website_restricted_editor'):
            //     raise werkzeug.exceptions.Forbidden()
            // 
            // def install_or_upgrade(theme):
            //     if theme.state != 'installed':
            //         theme.button_install()
            //     themes = theme + theme._theme_get_upstream()
            //     themes.filtered(lambda m: m.state == 'installed').button_upgrade()
            // 
            // self.sudo()._button_immediate_function(install_or_upgrade)
            */
            return default;
        }

        protected async Task<IrModuleModule> UnlinkExceptInstalledInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _unlink_except_installed(self):
            // for module in self:
            //     if module.state in ('installed', 'to upgrade', 'to remove', 'to install'):
            //         raise UserError(_('You are trying to remove a module that is installed or will be installed.'))
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateCategoryInternalAsync(object category)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _update_category(self, category='Uncategorized'):
            // current_category = self.category_id
            // seen = set()
            // current_category_path = []
            // while current_category:
            //     current_category_path.insert(0, current_category.name)
            //     seen.add(current_category.id)
            //     if current_category.parent_id.id in seen:
            //         current_category.parent_id = False
            //         _logger.warning('category %r ancestry loop has been detected and fixed', current_category)
            //     current_category = current_category.parent_id
            // 
            // categs = category.split('/')
            // if categs != current_category_path:
            //     cat_id = modules.db.create_categories(self.env.cr, categs)
            //     self.write({'category_id': cat_id})
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateCountriesInternalAsync(object countries)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _update_countries(self, countries=()):
            // existing = set(self.country_ids.ids)
            // needed = set(self.env['res.country'].search([('code', 'in', [c.upper() for c in countries])]).ids)
            // for dep in (needed - existing):
            //     self.env.cr.execute('INSERT INTO module_country (module_id, country_id) values (%s, %s)', (self.id, dep))
            // for dep in (existing - needed):
            //     self.env.cr.execute('DELETE FROM module_country WHERE module_id = %s and country_id = %s', (self.id, dep))
            // self.invalidate_recordset(['country_ids'])
            // self.env['res.company'].invalidate_model(['uninstalled_l10n_module_ids'])
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateDependenciesInternalAsync(object depends, object auto_install_requirements)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _update_dependencies(self, depends=None, auto_install_requirements=()):
            // self.env['ir.module.module.dependency'].flush_model()
            // existing = {dep.name for dep in self.dependencies_id}
            // needed = set(depends or [])
            // for dep in (needed - existing):
            //     self.env.cr.execute('INSERT INTO ir_module_module_dependency (module_id, name) values (%s, %s)', (self.id, dep))
            // for dep in (existing - needed):
            //     self.env.cr.execute('DELETE FROM ir_module_module_dependency WHERE module_id = %s and name = %s', (self.id, dep))
            // self.env.cr.execute('UPDATE ir_module_module_dependency SET auto_install_required = (name = any(%s)) WHERE module_id = %s',
            //                  (list(auto_install_requirements or ()), self.id))
            // self.env['ir.module.module.dependency'].invalidate_model(['auto_install_required'])
            // self.invalidate_recordset(['dependencies_id'])
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateExclusionsInternalAsync(object excludes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _update_exclusions(self, excludes=None):
            // self.env['ir.module.module.exclusion'].flush_model()
            // existing = {excl.name for excl in self.exclusion_ids}
            // needed = set(excludes or [])
            // for name in (needed - existing):
            //     self.env.cr.execute('INSERT INTO ir_module_module_exclusion (module_id, name) VALUES (%s, %s)', (self.id, name))
            // for name in (existing - needed):
            //     self.env.cr.execute('DELETE FROM ir_module_module_exclusion WHERE module_id=%s AND name=%s', (self.id, name))
            // self.invalidate_recordset(['exclusion_ids'])
            */
            return default;
        }

        protected async Task<IrModuleModule> UpdateFromTerpInternalAsync(object terp)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _update_from_terp(self, terp):
            // self._update_dependencies(terp.get('depends', []), terp.get('auto_install'))
            // self._update_countries(terp.get('countries', []))
            // self._update_exclusions(terp.get('excludes', []))
            // self._update_category(terp.get('category', 'Uncategorized'))
            */
            return default;
        }

        public async Task<IrModuleModule> UpdateListAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def update_list(self):
            // res = super(IrModuleModule, self).update_list()
            // self.update_theme_images()
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def update_list(self):
            // res = [0, 0]    # [update, add]
            // 
            // default_version = modules.adapt_version('1.0')
            // known_mods = self.with_context(lang=None).search([])
            // known_mods_names = {mod.name: mod for mod in known_mods}
            // 
            // # iterate through detected modules and update/create them in db
            // for manifest in modules.Manifest.all_addon_manifests():
            //     mod = known_mods_names.get(manifest.name)
            //     terp = self.get_module_info(manifest)
            //     values = self.get_values_from_terp(terp)
            // 
            //     if mod:
            //         updated_values = {}
            //         for key in values:
            //             old = getattr(mod, key)
            //             if (old or values[key]) and values[key] != old:
            //                 updated_values[key] = values[key]
            //         if terp.get('installable', True) and mod.state == 'uninstallable':
            //             updated_values['state'] = 'uninstalled'
            //         if parse_version(terp.get('version', default_version)) > parse_version(mod.latest_version or default_version):
            //             res[0] += 1
            //         if updated_values:
            //             mod.write(updated_values)
            //     elif not manifest or not terp:
            //         continue
            //     else:
            //         state = "uninstalled" if terp.get('installable', True) else "uninstallable"
            //         mod = self.create(dict(name=manifest.name, state=state, **values))
            //         res[1] += 1
            // 
            //     mod._update_from_terp(terp)
            // 
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModule> UpdateRecordsInternalAsync(object model_name, object website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def _update_records(self, model_name, website):
            // """
            //     This method:
            // 
            //     - Find and update existing records.
            // 
            //         For each model, overwrite the fields that are defined in the template (except few
            //         cases such as active) but keep inherited models to not lose customizations.
            // 
            //     - Create new records from templates for those that didn't exist.
            // 
            //     - Remove the models that existed before but are not in the template anymore.
            // 
            //         See _theme_cleanup for more information.
            // 
            // 
            //     There is a special 'while' loop around the 'for' to be able queue back models at the end
            //     of the iteration when they have unmet dependencies. Hopefully the dependency will be
            //     found after all models have been processed, but if it's not the case an error message will be shown.
            // 
            // 
            //     :param model_name: string with the technical name of the model to handle
            //         (the name must be one of the keys present in ``_theme_model_names``)
            //     :param website: ``website`` model for which the records have to be updated
            // 
            //     :raise MissingError: if there is a missing dependency.
            // """
            // self.ensure_one()
            // 
            // remaining = self._get_module_data(model_name)
            // last_len = -1
            // while (len(remaining) != last_len):
            //     last_len = len(remaining)
            //     for rec in remaining:
            //         rec_data = rec._convert_to_base_model(website)
            //         if not rec_data:
            //             _logger.info('Record queued: %s' % rec.display_name)
            //             continue
            // 
            //         find = rec.with_context(active_test=False).mapped('copy_ids').filtered(lambda m: m.website_id == website)
            // 
            //         # special case for attachment
            //         # if module B override attachment from dependence A, we update it
            //         if not find and model_name == 'ir.attachment':
            //             # In master, a unique constraint over (theme_template_id, website_id)
            //             # will be introduced, thus ensuring unicity of 'find'
            //             find = rec.copy_ids.search([('key', '=', rec.key), ('website_id', '=', website.id), ("original_id", "=", False)])
            // 
            //         if find:
            //             imd = self.env['ir.model.data'].search([('model', '=', find._name), ('res_id', '=', find.id)])
            //             if imd and imd.noupdate:
            //                 _logger.info('Noupdate set for %s (%s)' % (find, imd))
            //             else:
            //                 # at update, ignore active field
            //                 if 'active' in rec_data:
            //                     rec_data.pop('active')
            //                 if model_name == 'ir.ui.view' and (find.arch_updated or find.arch == rec_data['arch']):
            //                     rec_data.pop('arch')
            //                 find.update(rec_data)
            //                 self._post_copy(rec, find)
            //         else:
            //             new_rec = self.env[model_name].create(rec_data)
            //             self._post_copy(rec, new_rec)
            // 
            //         remaining -= rec
            // 
            // if len(remaining):
            //     error = 'Error - Remaining: %s' % remaining.mapped('display_name')
            //     _logger.error(error)
            //     raise MissingError(error)
            // 
            // self._theme_cleanup(model_name, website)
            */
            return default;
        }

        public async Task<IrModuleModule> UpdateThemeImagesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def update_theme_images(self):
            // IrAttachment = self.env['ir.attachment']
            // existing_urls = IrAttachment.search_read([['res_model', '=', self._name], ['type', '=', 'url']], ['url'])
            // existing_urls = {url_wrapped['url'] for url_wrapped in existing_urls}
            // 
            // themes = self.env['ir.module.module'].with_context(active_test=False).search([
            //     ('category_id', 'child_of', self.env.ref('base.module_category_theme').id),
            // ], order='name')
            // 
            // for theme in themes:
            //     terp = self.get_module_info(theme.name)
            //     images = terp.get('images', [])
            //     image_paths = ['/%s/%s' % (theme.name, image) for image in images]
            //     if all(image_path in existing_urls for image_path in image_paths):
            //         continue
            //     # Images creation order must be the order specified in the manifest
            //     for image_path in image_paths:
            //         image_name = image_path.split('/')[-1]
            //         IrAttachment.create({
            //             'type': 'url',
            //             'name': image_name,
            //             'url': image_path,
            //             'res_model': self._name,
            //             'res_id': theme.id,
            //         })
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<IrModuleModule> UpdateTranslationsInternalAsync(object filter_lang, object overwrite)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def _update_translations(self, filter_lang=None, overwrite=False):
            // if not filter_lang:
            //     langs = self.env['res.lang'].get_installed()
            //     filter_lang = [code for code, _ in langs]
            // elif not isinstance(filter_lang, (list, tuple)):
            //     filter_lang = [filter_lang]
            // 
            // update_mods = self.filtered(lambda r: r.state in ('installed', 'to install', 'to upgrade'))
            // mod_dict = {
            //     mod.name: mod.dependencies_id.mapped('name')
            //     for mod in update_mods
            // }
            // mod_names = topological_sort(mod_dict)
            // self.env['ir.module.module']._load_module_terms(mod_names, filter_lang, overwrite)
            */
            return default;
        }

        public async Task<IrModuleModule> UpstreamDependenciesAsync(Guid id, IrModuleModuleUpstreamDependenciesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_module.py) ---
            // def upstream_dependencies(self, known_deps=None,
            //                       exclude_states=('installed', 'uninstallable', 'to remove')):
            // """ Return the dependency tree of modules of the modules in `self`, and
            // that satisfy the `exclude_states` filter.
            // """
            // if not self:
            //     return self
            // self.flush_model(['name', 'state'])
            // self.env['ir.module.module.dependency'].flush_model(['module_id', 'name'])
            // known_deps = known_deps or self.browse()
            // query = """ SELECT DISTINCT m.id
            //             FROM ir_module_module_dependency d
            //             JOIN ir_module_module m ON (d.module_id=m.id)
            //             WHERE
            //                 m.name IN (SELECT name from ir_module_module_dependency where module_id in %s) AND
            //                 m.state NOT IN %s AND
            //                 m.id NOT IN %s """
            // self.env.cr.execute(query, (tuple(self.ids), tuple(exclude_states), tuple(known_deps.ids or self.ids)))
            // new_deps = self.browse([row[0] for row in self.env.cr.fetchall()])
            // missing_mods = new_deps - known_deps
            // known_deps |= new_deps
            // if missing_mods:
            //     known_deps |= missing_mods.upstream_dependencies(known_deps, exclude_states)
            // return known_deps
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> ViewDeliveryMethodsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: delivery, FILE: ir_module_module.py) ---
            // def action_view_delivery_methods(self):
            // self.ensure_one()
            // 
            // module_name = self.name  # e.g., delivery_dhl
            // if not module_name.startswith('delivery_'):
            //     return False
            // 
            // delivery_type = module_name.removeprefix('delivery_')  # dhl, fedex, etc.
            // action = self.env.ref('delivery.action_delivery_carrier_form').read()[0]
            // if delivery_type == 'mondialrelay':
            //     action['context'] = {'search_default_is_mondialrelay': True}
            // else:
            //     action['context'] = {'search_default_delivery_type': delivery_type}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> WebReadAsync(Guid id, IrModuleModuleWebReadRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def web_read(self, specification):
            // fields = list(specification.keys())
            // module_type = self.env.context.get('module_type', 'official')
            // if module_type == 'industries':
            //     modules_list = self._get_modules_from_apps(fields, module_type, self.env.context.get('module_name'))
            //     return modules_list
            // else:
            //     return super().web_read(specification)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<IrModuleModule> WebSearchReadAsync(Guid id, IrModuleModuleWebSearchReadRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base_import_module, FILE: ir_module.py) ---
            // def web_search_read(self, domain, specification, offset=0, limit=None, order=None, count_limit=None):
            // if _domain_asks_for_industries(domain):
            //     fields_name = list(specification.keys())
            //     modules_list = self._get_modules_from_apps(fields_name, 'industries', False, domain, offset=offset)
            //     return {
            //         'length': len(modules_list) + offset,
            //         'records': modules_list[:(limit or 80)],
            //     }
            // else:
            //     return super().web_search_read(domain, specification, offset=offset, limit=limit, order=order, count_limit=count_limit)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, IrModuleModule entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: ir_module.py) ---
            // def write(self, vals):
            // # Instanciate the first template of the module on the current company upon installing the module
            // was_installed = len(self) == 1 and self.state in ('installed', 'to upgrade', 'to remove')
            // res = super().write(vals)
            // is_installed = len(self) == 1 and self.state == 'installed'
            // if (
            //     not was_installed and is_installed
            //     and not self.env.company.chart_template
            //     and self.account_templates
            //     and (guessed := next((
            //         tname
            //         for tname, tvals in self.account_templates.items()
            //         if (self.env.company.country_id.id and tvals['country_id'] == self.env.company.country_id.id)
            //         or tname == 'generic_coa'
            //     ), None))
            // ):
            //     def try_loading(env):
            //         env['account.chart.template'].try_loading(
            //             guessed,
            //             env.company,
            //         )
            //     self.env.registry._auto_install_template = try_loading
            // return res
            --- ODOO METHOD SOURCE (MODULE: website, FILE: ir_module_module.py) ---
            // def write(self, vals):
            // """
            //     Override to correctly upgrade themes after upgrade/installation of modules.
            // 
            //     # Install
            // 
            //         If this theme wasn't installed before, then load it for every website
            //         for which it is in the stream.
            // 
            //         eg. The very first installation of a theme on a website will trigger this.
            // 
            //         eg. If a website uses theme_A and we install sale, then theme_A_sale will be
            //             autoinstalled, and in this case we need to load theme_A_sale for the website.
            // 
            //     # Upgrade
            // 
            //         There are 2 cases to handle when upgrading a theme:
            // 
            //         * When clicking on the theme upgrade button on the interface,
            //             in which case there will be an http request made.
            // 
            //             -> We want to upgrade the current website only, not any other.
            // 
            //         * When upgrading with -u, in which case no request should be set.
            // 
            //             -> We want to upgrade every website using this theme.
            // """
            // if request and request.db and request.env and request.env.context.get('apply_new_theme'):
            //     self = self.with_context(apply_new_theme=True)
            // 
            // for module in self:
            //     if module.name.startswith('theme_') and vals.get('state') == 'installed':
            //         _logger.info('Module %s has been loaded as theme template (%s)' % (module.name, module.state))
            // 
            //         if module.state in ['to install', 'to upgrade']:
            //             websites_to_update = module._theme_get_stream_website_ids()
            // 
            //             if module.state == 'to upgrade' and request:
            //                 Website = self.env['website']
            //                 current_website = Website.get_current_website()
            //                 websites_to_update = current_website if current_website in websites_to_update else Website
            // 
            //             for website in websites_to_update:
            //                 module._theme_load(website)
            // 
            // return super(IrModuleModule, self).write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}