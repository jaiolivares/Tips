import { useState } from "react";

export const WhetherApp = () => {
  const urlBase = "https://api.openweathermap.org/data/2.5/weather";
  const API_KEY = "17341567f5da01c38a6f83b75a241eca";

  const [ciudad, setCiudad] = useState("Santiago");
  const [dataClima, setDateClima] = useState(null);
  const difKelvin = 273.15;

  const handleCambioCiudad = (e) => {
    setCiudad(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (ciudad.length > 0) fetchClima();
  };

  const fetchClima = async () => {
    try {
      const response = await fetch(`${urlBase}?q=${ciudad}&appid=${API_KEY}`);
      const data = await response.json();
      setDateClima(data);
    } catch (error) {
      console.error("Ocurrió un problema en el Catch: " + error);
    }
  };

  return (
    <div className="container">
      <h1>WheatherAppComponent</h1>

      <form onSubmit={handleSubmit}>
        <input type="text" value={ciudad} onChange={handleCambioCiudad} />
        <button type="submit">Buscar</button>
      </form>

      {dataClima && (
        <div>
          <h2>{dataClima.name}</h2>
          <p>Temperatura: {parseInt(dataClima?.main?.temp - difKelvin)}°C</p>
          <p>Condición meteorológica: {dataClima.weather[0].description}</p>
          <img
            src={`https://openweathermap.org/img/wn/${dataClima.weather[0].icon}@2x.png`}
          />
        </div>
      )}
    </div>
  );
};
