import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {RouterModule, Routes} from "@angular/router";
import {LogingComponent} from "./loging/loging.component";
import {RegisterComponent} from "./register/register.component";

const routes: Routes = [
  {path: "login", component: LogingComponent},
  {path: "register", component: RegisterComponent}
]

@NgModule({
  declarations: [

  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class AccountRoutingModule { }
