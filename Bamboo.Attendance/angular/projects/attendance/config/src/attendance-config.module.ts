import { ModuleWithProviders, NgModule } from '@angular/core';
import { ATTENDANCE_ROUTE_PROVIDERS } from './providers/route.provider';

@NgModule()
export class AttendanceConfigModule {
  static forRoot(): ModuleWithProviders<AttendanceConfigModule> {
    return {
      ngModule: AttendanceConfigModule,
      providers: [ATTENDANCE_ROUTE_PROVIDERS],
    };
  }
}
