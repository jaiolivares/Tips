import { Component, OnInit, inject } from "@angular/core";
import { ApiService } from "../../services/api.service";
import { CommonModule } from "@angular/common";
import { IProduct } from "../../models/product.model";
import { Router } from "@angular/router";

@Component({
  selector: "app-products",
  standalone: true,
  imports: [CommonModule],
  templateUrl: "./products.component.html",
  styleUrl: "./products.component.css",
})
export class ProductsComponent implements OnInit {
  loading: boolean = true;
  productList: IProduct[] = [];

  private _apliService = inject(ApiService);
  private _router = inject(Router);

  ngOnInit(): void {
    this._apliService.getProducts().subscribe((data: IProduct[]) => {
      this.productList = data;
      this.loading = false;
    });
  }

  verDetalle(id: number): void {
    this._router.navigate(["/product", id]);
  }
}
