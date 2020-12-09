import { ModuleWithProviders, NgModule } from '@angular/core';
import { CRM_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class CRMConfigModule {
  static forRoot(): ModuleWithProviders<CRMConfigModule> {
    return {
      ngModule: CRMConfigModule,
      providers: [CRM_ROUTE_PROVIDERS],
    };
  }
}
