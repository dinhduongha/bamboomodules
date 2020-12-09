import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class AttendanceService {
  apiName = 'Attendance';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/Attendance/sample' },
      { apiName: this.apiName }
    );
  }
}
