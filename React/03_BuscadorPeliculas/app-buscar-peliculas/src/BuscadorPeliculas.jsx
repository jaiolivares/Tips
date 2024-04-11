import { useState } from "react";

export const BuscadorPeliculas = () => {
  const urlBase = "https://api.themoviedb.org/3/search/movie";
  const API_KEY = "e99d615df8a92dc31427eb6004865bff";

  const [busqueda, setBusqueda] = useState("");
  const [peliculas, setPeliculas] = useState([]);

  const handleInputChange = (e) => {
    setBusqueda(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetchPeliculas();
  };

  const fetchPeliculas = async () => {
    try {
      const response = await fetch(`${urlBase}?query=${busqueda}&api_key=${API_KEY}`);
      const data = await response.json();
      setPeliculas(data.results);
    } catch (error) {
      console.error("Error en catch: " + error);
    }
  };

  return (
    <div className="container">
      <h1 className="title">Buscador de Películas</h1>
      <form onSubmit={handleSubmit}>
        <input type="text" placeholder="Escribe la búsqueda" value={busqueda} onChange={handleInputChange}></input>
        <button type="submit" className="search-buttom">
          Buscar
        </button>
      </form>

      <div className="movie-list">
        {peliculas.map((peli) => (
          <div key={peli.id} className="movie-card">
            <img src={`https://image.tmdb.org/t/p/w500/${peli.poster_path}`} alt={peli.title} />
            <h2>{peli.overview}</h2>
          </div>
        ))}
      </div>
    </div>
  );
};
