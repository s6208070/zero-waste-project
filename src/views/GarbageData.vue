<template>
  <v-app style = "overflow:auto;">
      <v-app-bar 
      app dark color = "indigo darken-1" 

      src = "https://img.freepik.com/free-vector/abstract-background-with-dots-blurry-shapes_23-2148705493.jpg?size=626&ext=jpg&ga=GA1.2.1842958395.1604448000"
    >
      <v-toolbar-title class = "font-weight-medium"> INTERASHTIVE DATA </v-toolbar-title>
      <v-spacer></v-spacer>
      <div id="nav">
        <router-link to="/"> Login </router-link> -
        <router-link to="/Search"> Search </router-link> -
        <router-link to="/garbagedata"> Garbagedata </router-link>
      </div>
      
    </v-app-bar>
    <v-main>
      <div> hello </div>
      <h1> You are looking for: </h1>
      <h4> {{userRequest.Province}}, {{userRequest.Amphoe}}, {{userRequest.Tambon}}, right? <br> <br> </h4>
      <div> TODO: Create the Fucking table </div>
    </v-main>
  </v-app>
</template>
<script>
export default {
  name: 'GarbageData',
  data() {
      return{
          userRequest: []
      }
    },
    created() {
        this.userRequest = this.$route.params.data
        console.log(this.req)
    }
}
</script>