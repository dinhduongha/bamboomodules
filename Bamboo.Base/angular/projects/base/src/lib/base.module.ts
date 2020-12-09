import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { BaseComponent } from './components/base.component';
import { BaseRoutingModule } from './base-routing.module';

@NgModule({
  declarations: [BaseComponent],
  imports: [CoreModule, ThemeSharedModule, BaseRoutingModule],
  exports: [BaseComponent],
})
export class BaseModule {
  static forChild(): ModuleWithProviders<BaseModule> {
    return {
      ngModule: BaseModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<BaseModule> {
    return new LazyModuleFactory(BaseModule.forChild());
  }
}
