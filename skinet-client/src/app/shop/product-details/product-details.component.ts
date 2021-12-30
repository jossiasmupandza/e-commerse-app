import { Component, OnInit } from '@angular/core';
import {IProduct} from "../../shared/models/product";
import {ShopService} from "../shop.service";
import {ActivatedRoute} from "@angular/router";
import {BreadcrumbService} from "xng-breadcrumb";

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;

  constructor(private shopService: ShopService, private activeRoute: ActivatedRoute, private breadcrumbService: BreadcrumbService) {
    this.breadcrumbService.set('@productDetails', ' ');
  }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    this.shopService.getProduct(+this.activeRoute.snapshot.paramMap.get('id')).subscribe(product => {
      this.product = product;
      this.breadcrumbService.set('@productDetails', product.name);
    }, error => {
      console.log(error);
    })
  }

}
