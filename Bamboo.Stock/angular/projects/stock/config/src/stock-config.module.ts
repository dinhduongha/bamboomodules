import { ModuleWithProviders, NgModule } from '@angular/core';
import { STOCK_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class StockConfigModule {
  static forRoot(): ModuleWithProviders<StockConfigModule> {
    return {
      ngModule: StockConfigModule,
      providers: [STOCK_ROUTE_PROVIDERS],
    };
  }
}
