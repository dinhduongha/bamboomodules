import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../services/employee.service';

@Component({
  selector: 'lib-employee',
  template: ` <p>employee works!</p> `,
  styles: [],
})
export class EmployeeComponent implements OnInit {
  constructor(private service: EmployeeService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
