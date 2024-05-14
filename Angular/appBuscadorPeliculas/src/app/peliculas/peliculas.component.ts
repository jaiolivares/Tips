import { Component } from '@angular/core';
import { MovieAppService } from '../services/movie-app.service';

@Component({
  selector: 'app-peliculas',
  templateUrl: './peliculas.component.html',
  styleUrl: './peliculas.component.css'
})
export class PeliculasComponent {
  movies: any[] = [];
  searchTerm: string = '';

  constructor(private movieService: MovieAppService) { }

  searchMovies() {
    this.movieService.buscarPelicula(this.searchTerm).subscribe((data: any) => {
      this.movies = data.results;
    });
  }
}