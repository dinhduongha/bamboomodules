import { ModuleWithProviders, NgModule } from '@angular/core';
import { BASE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class BaseConfigModule {
  static forRoot(): ModuleWithProviders<BaseConfigModule> {
    return {
      ngModule: BaseConfigModule,
      providers: [BASE_ROUTE_PROVIDERS],
    };
  }
}
