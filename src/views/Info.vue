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
        <h1> {{this.DATA.province}}, </h1> <h2> {{this.DATA.amphoe}}, </h2><h3> {{this.DATA.tambon}} </h3> 
        <img :src="this.DATA.base64img"/>
        <div>
            Weight = {{this.DATA.weight}} <br>
            Coordinate = {{this.DATA.cox}}, {{this.DATA.coy}} <br>
            Current status = {{this.DATA.status}} <br>
            Timestamp = {{this.DATA.timestamp}} <br>
            Submitted by: {{this.DATA.userid}} <br> <br>
            Description: <br>
            {{this.DATA.description}}
        </div>
    </v-main>
  </v-app>
</template>

<script>
import firebase from "firebase"
export default {
  name: 'Info',
  components: {

  },
  data() {
      return{
          id: "",
          DATA: []
      }
   },
   methods: {
    async loadData(id){
        console.log(`api/garbages/${id}`)
        const res = await fetch(`api/garbages/${id}`)
        this.DATA = await res.json()
        console.log(this.DATA)
    },
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
  async created(){
      const req = this.$route.query
      this.id = req.id
      console.log(this.id)
      this.loadData(this.id)
  }
}
</script>