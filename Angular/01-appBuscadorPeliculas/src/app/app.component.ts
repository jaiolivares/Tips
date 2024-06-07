import { Component } from '@angular/core';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'appBuscadorPeliculas';
  variable_interpolada:string = "App de Peliculas - Interpolada"
  objetoUnico = {
    id: 1,
    nombre: "Mi Nombre"
  }

  array = [
    {
      id: 1, Nombre: "Nombre uno"
    },
    {
      id:2, Nombre: "Nombre dos"
    },
    {
      id:3, Nombre: "Nombre tre"
    }
  ]
}
