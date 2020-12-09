import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { AccountComponent } from './components/account.component';
import { AccountRoutingModule } from './account-routing.module';

@NgModule({
  declarations: [AccountComponent],
  imports: [CoreModule, ThemeSharedModule, AccountRoutingModule],
  exports: [AccountComponent],
})
export class AccountModule {
  static forChild(): ModuleWithProviders<AccountModule> {
    return {
      ngModule: AccountModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<AccountModule> {
    return new LazyModuleFactory(AccountModule.forChild());
  }
}
