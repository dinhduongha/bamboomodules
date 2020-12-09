import { Component, OnInit } from '@angular/core';
import { CRMService } from '../services/c-rM.service';

@Component({
  selector: 'lib-c-rM',
  template: ` <p>c-rM works!</p> `,
  styles: [],
})
export class CRMComponent implements OnInit {
  constructor(private service: CRMService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
