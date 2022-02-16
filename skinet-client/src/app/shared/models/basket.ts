import {v4 as uuidV4} from "uuid";

export interface IBasketItem {
  id: number;
  productName: string;
  price: number;
  quantity: number;
  pictureUrl: string;
  brand: string;
  type: string;
}

export interface IBasket {
  id: string;
  items: IBasketItem[];
}

export class Basket implements IBasket {
  id = uuidV4();
  items: IBasketItem[] = [];
}
