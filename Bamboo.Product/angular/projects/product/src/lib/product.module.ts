import { NgModule, NgModuleFactory, ModuleWithProviders } from '@angular/core';
import { CoreModule, LazyModuleFactory } from '@abp/ng.core';
import { ThemeSharedModule } from '@abp/ng.theme.shared';
import { ProductComponent } from './components/product.component';
import { ProductRoutingModule } from './product-routing.module';

@NgModule({
  declarations: [ProductComponent],
  imports: [CoreModule, ThemeSharedModule, ProductRoutingModule],
  exports: [ProductComponent],
})
export class ProductModule {
  static forChild(): ModuleWithProviders<ProductModule> {
    return {
      ngModule: ProductModule,
      providers: [],
    };
  }

  static forLazy(): NgModuleFactory<ProductModule> {
    return new LazyModuleFactory(ProductModule.forChild());
  }
}
