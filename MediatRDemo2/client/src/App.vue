<template>
  <div id="app">
    <img alt="Vue logo" src="./assets/logo.png">
    <button @click="getCars">Get the first car from db</button>
    <h1>Test</h1>
    <p v-for="car in cars" :key="car.name">
      {{ carsRequested ? car.name : '' }}
      </p>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'App',
  data () {
    return {
      cars: [],
      carsRequested: false
    }
  },
  methods: {
    async getCars () {
      const response = await axios.get("http://localhost:58829/api/cars");
      const data = response.data;
      this.cars = data;
      this.carsRequested = true;
    }
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
