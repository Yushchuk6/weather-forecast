<template>
  <div class="card shadow-sm bg-body rounded">
    <div class="card-body">
      <div class="weather-date">
        <h3>{{ getDay(forecasts[0].dt * 1000) }}</h3>
        <p class="text-secondary">
          <span>{{ new Date(forecasts[0].dt * 1000).getDate() }}</span>
          <span>{{ " " + getMonth(forecasts[0].dt * 1000) }}</span>
          <span>{{ ", " + city }}</span>
        </p>
      </div>
      <div class="weather-data mr-auto">
        <div class="d-inline-flex align-items-center">
          <img
            :src="`http://openweathermap.org/img/wn/${forecasts[0].weather[0].icon}@2x.png`"
          />
          <span class="display-3"
            >{{ Math.trunc(forecasts[0].main.temp) }} °C</span
          >
        </div>
        <h4>{{ forecasts[0].weather[0].description }}</h4>
      </div>
    </div>
    <div class="card-body my-4 p-0">
      <div class="d-flex justify-content-around">
        <forecast-card
          v-for="forecast of skipFirstForecast"
          :key="forecast"
          :temp="Math.trunc(forecast.main.temp)"
          :icon="forecast.weather[0].icon"
          :day="getDay(forecast.dt * 1000)"
          :description="forecast.weather[0].description"
        />
      </div>
    </div>
  </div>
</template>

<script>
import ForecastCard from "@/components/ForecastCard.vue";
import { getDay, getMonth } from "./consts";

export default {
  name: "WeatherCard",
  props: {
    forecasts: Array,
    city: String,
  },
  components: {
    ForecastCard,
  },
  methods: {
    getDay,
    getMonth,
  },
  computed: {
    // skiping first element - current weather
    skipFirstForecast: function () {
      return this.forecasts.slice(1);
    },
  },
};
</script>
