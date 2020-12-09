import { Component, OnInit } from '@angular/core';
import { StockService } from '../services/stock.service';

@Component({
  selector: 'lib-stock',
  template: ` <p>stock works!</p> `,
  styles: [],
})
export class StockComponent implements OnInit {
  constructor(private service: StockService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
