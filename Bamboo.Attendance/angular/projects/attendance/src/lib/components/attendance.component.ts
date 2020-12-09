import { Component, OnInit } from '@angular/core';
import { AttendanceService } from '../services/attendance.service';

@Component({
  selector: 'lib-attendance',
  template: ` <p>attendance works!</p> `,
  styles: [],
})
export class AttendanceComponent implements OnInit {
  constructor(private service: AttendanceService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
