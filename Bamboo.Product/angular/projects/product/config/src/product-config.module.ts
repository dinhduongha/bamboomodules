import { ModuleWithProviders, NgModule } from '@angular/core';
import { PRODUCT_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class ProductConfigModule {
  static forRoot(): ModuleWithProviders<ProductConfigModule> {
    return {
      ngModule: ProductConfigModule,
      providers: [PRODUCT_ROUTE_PROVIDERS],
    };
  }
}
