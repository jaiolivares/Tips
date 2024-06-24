import { Component, OnInit, inject } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { ApiService } from "../../services/api.service";
import { IProduct } from "../../models/product.model";
import { CommonModule } from "@angular/common";

@Component({
  selector: "app-product-datail",
  standalone: true,
  imports: [CommonModule],
  templateUrl: "./product-datail.component.html",
  styleUrl: "./product-datail.component.css",
})
export class ProductDatailComponent implements OnInit {
  loading: boolean = true;
  public product?: IProduct;

  private _router = inject(Router);
  private _route = inject(ActivatedRoute);
  private _apiService = inject(ApiService);

  ngOnInit(): void {
    this._route.params.subscribe((params) => {
      this._apiService.getProduct(params["id"]).subscribe((data: IProduct) => {
        this.product = data;
        this.loading = false;
      });
    });
  }

  volver(): void {
    this._router.navigate(["/products"]);
  }
}
