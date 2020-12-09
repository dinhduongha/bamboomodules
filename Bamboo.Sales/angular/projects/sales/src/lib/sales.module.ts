import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { SalesComponent } from './components/sales.component';
import { SalesRoutingModule } from './sales-routing.module';

@NgModule({
  declarations: [SalesComponent],
  imports: [CoreModule, ThemeSharedModule, SalesRoutingModule],
  exports: [SalesComponent],
})
export class SalesModule {
  static forChild(): ModuleWithProviders<SalesModule> {
    return {
      ngModule: SalesModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<SalesModule> {
    return new LazyModuleFactory(SalesModule.forChild());
  }
}
