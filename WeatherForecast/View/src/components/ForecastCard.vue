<template>
  <div class="weakly-weather-item">
    <p class="mb-0">{{ day }}</p>
    <img :src="`http://openweathermap.org/img/wn/${icon}@2x.png`" />
    <p class="mdi">{{ description }}</p>
    <p class="mb-0">{{ temp }} °C</p>
  </div>
</template>

<script>
export default {
  props: {
    temp: Number,
    day: String,
    icon: String,
    description: String,
  },
};
</script>