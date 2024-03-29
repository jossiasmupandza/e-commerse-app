import { Component, OnInit } from '@angular/core';
import {AsyncValidatorFn, FormBuilder, FormGroup, Validators} from "@angular/forms";
import {AccountService} from "../account.service";
import {Router} from "@angular/router";
import {of, timer} from "rxjs";
import {map, switchMap} from "rxjs/operators";

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  errors: [];

  constructor(private formBuilder: FormBuilder, private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      displayName: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.pattern("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$")],
        [this.validateEmailNotToke()]],
      password: [null, [Validators.required]]
    })
  }

  onSubmit() {
    return this.accountService.register(this.registerForm.value).subscribe(response => {
      this.router.navigateByUrl('/shop');
    }, error => {
      this.errors =  error.errors;
      console.log(error);
    })
  }

  validateEmailNotToke(): AsyncValidatorFn {
    return control => {
      return timer(500).pipe(
         switchMap(() => {
           if (!control.value){
             return of(null);
           }
           return this.accountService.checkEmailExists(control.value).pipe(
             map(res => {
               return res ? {emailExists: true} : null
             })
           )
         })
      )
    }
  }

}
