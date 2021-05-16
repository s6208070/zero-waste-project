<template>
  <v-app style = "overflow:auto;">
     <v-app-bar
      app dark color = "indigo darken-1" 

      src = "https://img.freepik.com/free-vector/abstract-background-with-dots-blurry-shapes_23-2148705493.jpg?size=626&ext=jpg&ga=GA1.2.1842958395.1604448000"
    >
      <v-toolbar-title class = "font-weight-medium"> INTERASHTIVE DATA </v-toolbar-title>
      <v-spacer></v-spacer>
      <div id="nav">
        <button @click= "logOut"> Log out </button> - 
        <router-link to="/Search"> Search </router-link> -
        <router-link to="/garbagedata"> Garbagedata </router-link> -
        <router-link to="/adddata"> Add Data </router-link>
      </div>
      
    </v-app-bar>
    <v-main>
      <div> hello </div>
      <h1> You are looking for: </h1>
      <h3 v-if="this.userReq.all"> EVERYTHING, right? </h3>
      <h4 v-else> {{this.userReq.province}}, {{this.userReq.amphoe}}, {{this.userReq.tambon}}  right? <br> <br> </h4>

      <Table/>
    </v-main>
  </v-app>
</template>

<script>
import Table from "@/components/Table"
import firebase from "firebase"
export default {
  name: 'GarbageData',
  components: {
    Table,
  },
  data() {
      return{
        userReq:{
          province: "-",
          amphoe: "-",
          tambon: "-",
          all: true,
        }
      }
   },
  methods:{
    async logOut(){
      try{
        const data = await firebase.auth().signOut();
        console.log(data)
        this.$router.replace({name: "Login"})
      }catch(err){
        alert(err)
      }
    },
  },
  created(){
    let q = this.$route.query
    if(typeof q.all != 'undefined') this.userReq.all = q.all 
    if(typeof q.province != 'undefined') this.userReq.province = q.province
    if(typeof q.amphoe != 'undefined') this.userReq.amphoe = q.amphoe
    if(typeof q.tambon != 'undefined') this.userReq.tambon = q.tambon
  }
}
</script>