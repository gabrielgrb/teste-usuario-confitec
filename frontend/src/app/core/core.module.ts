import { ErrorHandler, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { MainLayoutComponent } from './main-layout/main-layout.component';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [MainLayoutComponent],
    imports: [
      RouterModule,
      BrowserModule,
      FormsModule,
      CommonModule,
      HttpClientModule,
    ],
    exports: [MainLayoutComponent],

  })
  export class CoreModule {}
