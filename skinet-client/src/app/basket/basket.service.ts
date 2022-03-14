import { Injectable } from '@angular/core';
import {environment} from "../../environments/environment";
import {BehaviorSubject} from "rxjs";
import {Basket, IBasket, IBasketItem, IBasketTotals} from "../shared/models/basket";
import {HttpClient} from "@angular/common/http";
import {map} from "rxjs/operators";
import {IProduct} from "../shared/models/product";

@Injectable({
  providedIn: 'root'
})

export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  private basketTotalsSource = new BehaviorSubject<IBasketTotals>(null);
  basket$ = this.basketSource.asObservable();
  basketTotals$ = this.basketTotalsSource.asObservable();

  constructor(private httpClient: HttpClient) { }

  getBasket(id: string) {
    return this.httpClient.get(this.baseUrl + 'basket?id=' + id)
      .pipe(
        map((basket: IBasket) => {
          this.basketSource.next(basket);
          this.calculateTotals();
        })
      )
  }

  setBasket(basket: IBasket) {
    return this.httpClient.post(this.baseUrl + 'basket', basket)
      .subscribe((response: IBasket) => {
        this.basketSource.next(response)
        this.calculateTotals();
      }, error => {
        console.log(error)
      })
  }

  getCurrentValue(){
    return this.basketSource.value;
  }

  addItemToBasket(product: IProduct, quantity: number = 1) {
    const itemToAdd: IBasketItem = this.mapProductToBasketItem(product, quantity);
    const basket: IBasket = this.getCurrentValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd);
    this.setBasket(basket);
  }

  private mapProductToBasketItem(product: IProduct, quantity: number): IBasketItem {
    return {
      id: product.id,
      productName: product.name,
      brand: product.productBrand,
      type: product.productType,
      price: product.price,
      pictureUrl: product.pictureUrl,
      quantity
    };
  }

  private createBasket(): IBasket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem): IBasketItem[] {
    const index = items.findIndex(item => item.id === itemToAdd.id);
    if(index === -1) {
      items.push(itemToAdd)
    } else {
      items[index].quantity += itemToAdd.quantity;
    }

    return  items;
  }

  private calculateTotals() {
    const basket = this.getCurrentValue();
    const shipping = 0;
    const subtotal = basket.items.reduce((a,b) => (b.price * b.quantity) + a,0);
    const total = shipping + subtotal;
    this.basketTotalsSource.next({shipping, subtotal,total});
  }
}
