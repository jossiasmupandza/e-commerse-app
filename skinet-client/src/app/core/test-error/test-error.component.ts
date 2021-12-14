import { Component, OnInit } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-test-error',
  templateUrl: './test-error.component.html',
  styleUrls: ['./test-error.component.css']
})
export class TestErrorComponent implements OnInit {
  baseUrl = environment.apiUrl;
  validationErros: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
  }

  get500Error() {
    this.http.get(this.baseUrl + 'buggy/serverError').subscribe(res => {
      console.log(res)
    }, error => {
      console.log(error);
    })
  }

  get404Error() {
    this.http.get(this.baseUrl + 'buggy/notfound').subscribe(res => {
      console.log(res)
    }, error => {
      console.log(error);
    })
  }

  get400Error() {
    this.http.get(this.baseUrl + 'buggy/badRequest').subscribe(res => {
      console.log(res)
    }, error => {
      console.log(error);
    })
  }

  get400ValidationError() {
    this.http.get(this.baseUrl + 'buggy/badRequest/one').subscribe(res => {
      console.log(res)
    }, error => {
      this.validationErros = error.errors;
      console.log(error);
    })
  }

}
