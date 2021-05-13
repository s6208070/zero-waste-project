<template>
  <v-app style = "overflow:auto;">
     <v-app-bar
      app dark color = "indigo darken-1" 

      src = "https://img.freepik.com/free-vector/abstract-background-with-dots-blurry-shapes_23-2148705493.jpg?size=626&ext=jpg&ga=GA1.2.1842958395.1604448000"
    >
      <v-toolbar-title class = "font-weight-medium"> INTERASHTIVE DATA </v-toolbar-title>
      <v-spacer></v-spacer>
      <div id="nav">
        <router-link to="/"> Logout </router-link> -
        <router-link to="/Search"> Search </router-link> -
        <router-link to="/garbagedata"> Garbagedata </router-link> -
        <router-link to="/adddata"> Add Data </router-link>
      </div>
      
    </v-app-bar>
    <v-main>
      <div> hello </div>
      <h1> You are looking for: </h1>
      <h3 v-if="this.userReq.all"> EVERYTHING, right? </h3>
      <h4 v-else> {{this.userReq.p}}, {{this.userReq.a}}, {{this.userReq.t}}  right? <br> <br> </h4>
      <div> TODO: Create the Fucking table </div>

      <Table :userReq = "userReq"/>
    </v-main>
  </v-app>
</template>

<script>
import Table from "@/components/Table"
export default {
  name: 'GarbageData',
  components: {
    Table,
  },
  data() {
      return{
          userReq: []
      }
   },
  created(){
    const rec = this.$route.query;
    this.userReq = {
            all: true,
            p: "",
            a: "",
            t: "",
          }
    if(typeof rec.province !== 'undefined') this.userReq.p = this.$route.query.province;
    if(typeof rec.amphoe !== 'undefined') this.userReq.a = this.$route.query.amphoe;
    if(typeof rec.tambon !== 'undefined') this.userReq.t = this.$route.query.tambon;
    if(typeof rec.all !== 'undefined') this.userReq.all = this.$route.query.all;
  }
}
</script>