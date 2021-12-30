import {Component, ElementRef, OnInit, ViewChild} from '@angular/core';
import {ShopService} from "./shop.service";
import {IProduct} from "../shared/models/product";
import {IProductBrand} from "../shared/models/productBrand";
import {IProductType} from "../shared/models/productType";
import {ShopParams} from "../shared/models/ShopParams";

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {
  // we use static = true when how referenced element does not have a condition to show on screen
  // viewChild to access elements on our template
  @ViewChild('search', {static: false}) searchTerm: ElementRef;
  products: IProduct[];
  productBrands: IProductBrand[];
  productTypes: IProductType[];
  shopParams = new ShopParams();
  totalCount: number;
  sortOptions = [
    {name: 'Alphabetic asc', value: 'nameAsc'},
    {name: 'Alphabetic desc', value: 'nameDesc'},
    {name: 'Price: Low to High', value: 'priceAsc'},
    {name: 'Price: High to Low', value: 'priceDesc'}
  ]

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getProductBrands();
    this.getProductTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams)
      .subscribe((response) => {
        this.products = response.data;
        this.shopParams.pageSize = response.pageSize;
        this.shopParams.pageNumber = response.pageIndex;
        this.totalCount = response.count;
    }, error => {
      console.log(error)
    })
  }

  getProductBrands() {
    this.shopService.getProductBrands().subscribe((response) => {
      this.productBrands = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error)
    })
  }

  getProductTypes() {
    this.shopService.getProductTypes().subscribe((response) => {
      this.productTypes = [{id: 0, name: 'All'}, ...response];
    }, error => {
      console.log(error)
    })
  }

  onBrandIdSelected(brandId: number) {
    this.shopParams.brandId = brandId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeIdSelected(typeId: number) {
    this.shopParams.typeId = typeId;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(sort: string) {
    this.shopParams.sort = sort;
    this.getProducts();
  }

  onPageChanged(page: number) {
    if(this.shopParams.pageNumber !== page) {
      this.shopParams.pageNumber = page;
      this.getProducts();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchTerm.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.getProducts();
  }
}
