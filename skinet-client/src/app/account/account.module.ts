import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LogingComponent } from './loging/loging.component';
import { RegisterComponent } from './register/register.component';
import {AccountRoutingModule} from "./account-routing.module";



@NgModule({
  declarations: [
    LogingComponent,
    RegisterComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule
  ]
})
export class AccountModule { }
