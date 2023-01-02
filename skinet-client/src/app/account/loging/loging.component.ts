import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-loging',
  templateUrl: './loging.component.html',
  styleUrls: ['./loging.component.css']
})
export class LogingComponent implements OnInit {
  loginGroup: FormGroup;

  constructor() { }

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginGroup = new FormGroup({
      email: new FormControl('', Validators.required),
      password: new FormControl('', Validators.required)
    })
  }

  onSubmit() {
    console.log(this.loginGroup.value)
  }
}
