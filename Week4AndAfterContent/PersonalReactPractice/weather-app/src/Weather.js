import React, { useEffect, useState, useCallback } from "react";
import axios from "axios";
import "./Weather.css"; // Import the CSS file

const Weather = () => {
  const [city, setCity] = useState("");
  const [weatherData, setWeatherData] = useState(null);

  const fetchData = useCallback(async () => {
    try {
      const response = await axios.get(
        `API key goes here`
      );
      setWeatherData(response.data);
      console.log(response.data); // You can see all the weather data in console log
    } catch (error) {
      console.error(error);
    }
  }, [city]);

  useEffect(() => {
    fetchData();
  }, [fetchData]);

  const handleInputChange = (e) => {
    setCity(e.target.value);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    fetchData();
  };

  return (
    <div className="weather-container">
      <h2>Weather Forecast</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Enter city name"
          value={city}
          onChange={handleInputChange}
          className="city-input"
        />
      </form>
      {weatherData ? (
        <div className="weather-info">
          <div className="weather-header">
            <h3>
              {new Date().toLocaleDateString("en-US", {
                weekday: "long",
                day: "numeric",
                month: "long",
              })}
            </h3>
            <h1>{weatherData.main.temp}°C</h1>
            <p>{weatherData.weather[0].description}</p>
          </div>
          <div className="weather-details">
            <div>
              <p>Feels Like: {weatherData.main.feels_like}°C</p>
              <p>Wind: {weatherData.wind.speed} m/s</p>
            </div>
            <div>
              <p>Humidity: {weatherData.main.humidity}%</p>
              <p>Pressure: {weatherData.main.pressure} hPa</p>
            </div>
          </div>
        </div>
      ) : (
        <p>Loading weather data...</p>
      )}
    </div>
  );
};

export default Weather;
