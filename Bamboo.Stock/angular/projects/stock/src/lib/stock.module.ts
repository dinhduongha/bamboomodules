import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { StockComponent } from './components/stock.component';
import { StockRoutingModule } from './stock-routing.module';

@NgModule({
  declarations: [StockComponent],
  imports: [CoreModule, ThemeSharedModule, StockRoutingModule],
  exports: [StockComponent],
})
export class StockModule {
  static forChild(): ModuleWithProviders<StockModule> {
    return {
      ngModule: StockModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<StockModule> {
    return new LazyModuleFactory(StockModule.forChild());
  }
}
