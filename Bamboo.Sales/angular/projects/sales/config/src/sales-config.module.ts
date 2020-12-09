import { ModuleWithProviders, NgModule } from '@angular/core';
import { SALES_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class SalesConfigModule {
  static forRoot(): ModuleWithProviders<SalesConfigModule> {
    return {
      ngModule: SalesConfigModule,
      providers: [SALES_ROUTE_PROVIDERS],
    };
  }
}
