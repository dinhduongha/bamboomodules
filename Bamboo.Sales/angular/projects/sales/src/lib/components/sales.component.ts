import { Component, OnInit } from '@angular/core';
import { SalesService } from '../services/sales.service';

@Component({
  selector: 'lib-sales',
  template: ` <p>sales works!</p> `,
  styles: [],
})
export class SalesComponent implements OnInit {
  constructor(private service: SalesService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
