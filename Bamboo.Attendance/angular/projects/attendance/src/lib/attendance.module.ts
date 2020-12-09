import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { AttendanceComponent } from './components/attendance.component';
import { AttendanceRoutingModule } from './attendance-routing.module';

@NgModule({
  declarations: [AttendanceComponent],
  imports: [CoreModule, ThemeSharedModule, AttendanceRoutingModule],
  exports: [AttendanceComponent],
})
export class AttendanceModule {
  static forChild(): ModuleWithProviders<AttendanceModule> {
    return {
      ngModule: AttendanceModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<AttendanceModule> {
    return new LazyModuleFactory(AttendanceModule.forChild());
  }
}
