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
        <img :src="this.DATA.imageURL"/>
        <div>
            Size = {{this.DATA.size}} <br>
            Visual pollution = {{this.DATA.visual}} <br>
            Odor pollution = {{this.DATA.odor}} <br>
            Coordinate = {{this.DATA.cox}}, {{this.DATA.coy}} <br>
            Current status = {{this.DATA.status}} <br>
            Timestamp = {{this.DATA.timestamp}} <br>
            Submitted by: {{this.DATA.userid}} <br> <br>
            Description: <br>
            {{this.DATA.description}}
        </div>
        <div>
            <label> Update Status <br> </label>
            <select name="status" placeholder="Select..." v-model = "temp" required>
              <option value="Not collected">Not collected</option>
              <option value="In process">In process</option>
              <option value="Successfully collected">Successfully collected</option>
              <option value="Process failed">Process failed</option>
            </select>
            <button @click="updateTask"> :Update </button>
        </div>
        <div>
          <button @click="deleteTask"> DELETE TASK </button>
        </div>
    </v-main>
  </v-app>
</template>

<script>
import firebase from "firebase"
import {DB} from "@/firebase"
export default {
  name: 'Info',
  data() { 
    return{
      id: "",
      DATA: [],
      temp: "",
    }
  },
  methods: {
    async logOut(){
      try{
        const data = await firebase.auth().signOut();
        console.log(data)
        this.$router.replace({name: "Login"})
      }catch(err){
        alert(err)
      }
    },
    async updateTask(){
      this.DATA.status = this.temp
      await DB.doc(this.id).update({...this.DATA})
      this.$router.replace({name: "GarbageData"})
    },
    async deleteTask(){
      if(confirm("Are your sure?")){
        await DB.doc(this.id).delete()
        this.$router.replace({name: "GarbageData"})
      }
    }
  },
  async created(){
    this.id = this.$route.query.id
    const ret = await DB.doc(this.id).get()
    this.DATA = ret.data()
    console.log(this.DATA)
    console.log(this.id)
  },
}
</script>