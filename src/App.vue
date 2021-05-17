<template>
  <div id="app" style="overflow:auto;">
    
  <v-app>
  <v-main><router-view :key="$route.fullPath" /></v-main>
  </v-app>
  </div>
</template>



<style lang="scss">

@import url('https://fonts.googleapis.com/css2?family=Kanit:wght@300&display=swap');

#app {
  font-family: 'Kanit', sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

#nav {
  padding: 30px;

  a {
    font-weight: bold;
    color: #d0dce7;

    &.router-link-exact-active {
      color: #42b983;
    }
  }
}
</style>
