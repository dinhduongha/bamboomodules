import { Component, OnInit } from '@angular/core';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'lib-product',
  template: ` <p>product works!</p> `,
  styles: [],
})
export class ProductComponent implements OnInit {
  constructor(private service: ProductService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
