import { ModuleWithProviders, NgModule } from '@angular/core';
import { EMPLOYEE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class EmployeeConfigModule {
  static forRoot(): ModuleWithProviders<EmployeeConfigModule> {
    return {
      ngModule: EmployeeConfigModule,
      providers: [EMPLOYEE_ROUTE_PROVIDERS],
    };
  }
}
