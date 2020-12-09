import { Component, OnInit } from '@angular/core';
import { BaseService } from '../services/base.service';

@Component({
  selector: 'lib-base',
  template: ` <p>base works!</p> `,
  styles: [],
})
export class BaseComponent implements OnInit {
  constructor(private service: BaseService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
