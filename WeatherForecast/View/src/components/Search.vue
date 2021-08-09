<template>
  <div class="row mt-5 justify-content-center">
    <div class="col-lg-5 col-md-8">
      <div class="input-group">
        <input
          class="form-control me-2"
          type="search"
          placeholder="Enter city and press 'Search'"
          aria-label="Search"
          v-model="city"
          @keyup.enter="search"
        />
        <button
          class="btn btn-outline-success"
          type="submit"
          @click="search"
          :disabled="!city"
        >
          Search
        </button>
      </div>
    </div>
  </div>
  <div class="row mt-5 justify-content-center">
    <div class="col-lg-6 col-md-10 grid-margin">
      <transition name="fade">
        <weather-card
          v-if="forecasts.length"
          :forecasts="forecasts"
          :city="cityResult"
        />
      </transition>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import WeatherCard from "@/components/WeatherCard.vue";

export default {
  name: "Search",
  components: {
    WeatherCard,
  },
  data() {
    return {
      forecasts: [],
      city: "",
      cityResult: "",
    };
  },
  methods: {
    search: function () {
      if (!this.city) return;
      axios
        .get("/weatherforecast", { params: { city: this.city } })
        .then((response) => {
          this.forecasts = response.data;
          this.cityResult = this.city;
        })
        .catch((error) => {
          alert(error + "\n" + error.response.data.message);
        });
    },
  },
};
</script>

<style>
.fade-enter-from {
  opacity: 0;
  transform: translateY(-60px);
}
.fade-enter-active {
  transition: all 0.3s ease;
}
</style>
