import { Component, OnInit } from '@angular/core';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'lib-account',
  template: ` <p>account works!</p> `,
  styles: [],
})
export class AccountComponent implements OnInit {
  constructor(private service: AccountService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
