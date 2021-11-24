import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {IPagination} from "./shared/models/pagination";
import {IProduct} from "./shared/models/product";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'skinet-client';
  products: IProduct[];

  constructor(private http: HttpClient) {
  }

  ngOnInit(): void {
    this.http.get("https://localhost:5001/api/products?pageSize=20").subscribe((response: IPagination) => {
       this.products = response.data;
    }, error => {
      console.log(error);
    })
  }
}
