import { Component } from '@angular/core';
import { MovieAppService } from '../services/movie-app.service';

import { Persona } from '../interfaces/persona';

@Component({
  selector: 'app-peliculas',
  templateUrl: './peliculas.component.html',
  styleUrl: './peliculas.component.css'
})
export class PeliculasComponent {
  movies: any[] = [];
  searchTerm: string = '';

  persona:Persona={
    nombre: "Javier Olivares",
    id: 99,
    estado: false
 }

 objPersonas: Persona[] = [{nombre: "Alan Brito", id: 11, estado: true}];

 constructor(private movieService: MovieAppService) { 
  this.objPersonas.push({nombre: "Desde constructor", id: 13, estado: true});
 }

 ngOnInit(){
  this.objPersonas.push({nombre: "Desde init", id: 13, estado: true});
  this.loadObjPersonas();
 }
 
 searchMovies() {
   this.movieService.buscarPelicula(this.searchTerm).subscribe((data: any) => {
     this.movies = data.results;
   });
 }
  
 loadObjPersonas() {
   this.objPersonas.push({nombre: "Alan", id: 13, estado: true})
   this.objPersonas.push({nombre: "Brito", id: 14, estado: true})
  }



}