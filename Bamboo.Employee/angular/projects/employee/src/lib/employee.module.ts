import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { EmployeeComponent } from './components/employee.component';
import { EmployeeRoutingModule } from './employee-routing.module';

@NgModule({
  declarations: [EmployeeComponent],
  imports: [CoreModule, ThemeSharedModule, EmployeeRoutingModule],
  exports: [EmployeeComponent],
})
export class EmployeeModule {
  static forChild(): ModuleWithProviders<EmployeeModule> {
    return {
      ngModule: EmployeeModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<EmployeeModule> {
    return new LazyModuleFactory(EmployeeModule.forChild());
  }
}
