import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { CRMComponent } from './components/c-rM.component';
import { CRMRoutingModule } from './c-rM-routing.module';

@NgModule({
  declarations: [CRMComponent],
  imports: [CoreModule, ThemeSharedModule, CRMRoutingModule],
  exports: [CRMComponent],
})
export class CRMModule {
  static forChild(): ModuleWithProviders<CRMModule> {
    return {
      ngModule: CRMModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<CRMModule> {
    return new LazyModuleFactory(CRMModule.forChild());
  }
}
