import { Routes } from "@angular/router";
import { HomeComponent } from "./pages/home/home.component";
import { ProductsComponent } from "./pages/products/products.component";
import { ProductDatailComponent } from "./pages/product-datail/product-datail.component";
import { ContactComponent } from "./pages/contact/contact.component";

export const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "products", component: ProductsComponent },
  { path: "product/:id", component: ProductDatailComponent },
  { path: "contact", component: ContactComponent },
  { path: "**", redirectTo: "", pathMatch: "full" },
];
