import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {BehaviorSubject} from "rxjs";
import {IBasket} from "../shared/models/basket";
import {HttpClient} from "@angular/common/http";
import {map} from "rxjs/operators";

@Injectable({
  providedIn: 'root'
})

export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$ = this.basketSource.asObservable();

  constructor(private httpClient: HttpClient) { }

  getBasket(id: string) {
    return this.httpClient.get(this.baseUrl + 'basket?id=' + id)
      .pipe(
        map((basket: IBasket) =>
          this.basketSource.next(basket)
        )
      )
  }

  setBasket(basket: IBasket) {
    return this.httpClient.post(this.baseUrl + 'basket', basket)
      .subscribe((response: IBasket) => {
        this.basketSource.next(response)
      }, error => {
        console.log(error)
      })
  }

  getCurrentValue(){
    return this.basketSource.value;
  }
}
