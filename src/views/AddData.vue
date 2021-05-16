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
      <h1> Add garbage data</h1>
      <form @submit="addTask" class="form" name="form">
        <div>
            <label>Province<br> </label>
            <input
                type = "text"
                v-model="DATA.province"
                name = "Province"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Amphoe <br> </label>
            <input
                type = "text"
                name = "Amphoe"
                v-model="DATA.amphoe"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Tambon <br>  </label>
            <input
                type = "text"
                name = "Tambon"
                v-model="DATA.tambon"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Timestamp<br> </label>
            <input
                type = "datetime-local"
                v-model="DATA.timestamp"
                name = "Timestamp"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Coordinate<br> </label>
            <input
                type = "number"
                v-model="DATA.cox"
                step = "0.00000001"
                name = "CoX"
                placeholder = "Enter Lat..."
            />
            <input
                type = "number"
                v-model="DATA.coy"
                step = "0.00000001"
                name = "CoY"
                placeholder = "Enter Lon..."
            />
        </div>
        <div>
          <label> Size: {{this.DATA.size}} <br></label>
          <input 
            type="range" 
            min="1" max ="5" 
            step="1" 
            v-model="DATA.size"
          />
        </div>
        <div>
          <label> Visual polluion: {{this.DATA.visual}} <br></label>
          <input 
            type="range" 
            min="1" max ="5" 
            step="1" 
            v-model="DATA.visual"
          />
        </div>
        <div>
          <label> Odor pollution: {{this.DATA.odor}} <br></label>
          <input 
            type="range" 
            min="1" max ="5" 
            step="1" 
            v-model="DATA.odor"
          />
        </div>
        <div>
            <label>User ID<br> </label>
            <input
                type = "text"
                v-model="DATA.userid"
                name = "UserID"
                placeholder = "Enter..."
            />
        </div>
        <div>
          <label> Description<br> </label>
          <textarea 
            rows="4" 
            cols="50" 
            name="comment"
            v-model="DATA.description" 
            form="form"
            placeholder = "Enter..."
          ></textarea>
        </div>
        <div>
          <label> Custom location<br> </label>
          <textarea 
            rows="4" 
            cols="50" 
            name="location"
            v-model="DATA.location" 
            form="form"
            placeholder = "Enter..."
          ></textarea>
        </div>
        <div>
          <label> Nearby Area<br> </label>
          <textarea 
            rows="4" 
            cols="50" 
            name="nearby"
            v-model="DATA.nearby" 
            form="form"
            placeholder = "Enter..."
          ></textarea>
        </div>
        <input type ="file" @change="fileChange"/> <br>
        <img :src="previewurl"/>
        

        <input type = "submit"/>
    </form>
    </v-main>
  </v-app>
</template>

<script>
import firebase from "firebase"
import {STR,DB} from "@/firebase"
export default {
  name: 'Search',
  data() {
      return{
        DATA: {
            timestamp: "",
            province: "",
            amphoe: "",
            tambon: "",
            cox: "",
            coy: "",
            userid: "",
            status: "Not collected",
            location: "",
            description: "",
            nearby: "",
            size: 1,
            visual: 1,
            odor: 1,
            imageURL: "",
        },
        selectedfile: null,
        previewurl: null,
      }
    },
  methods: {
    async addTask(e){
      e.preventDefault()
      await STR.ref(`garbage_images/${this.selectedfile.name}`).put(this.selectedfile)
      .then(async (snapshot) => this.DATA.imageURL = await snapshot.ref.getDownloadURL())
      console.log(this.DATA)
      await DB.add({...this.DATA})
      alert("Successfully add the gargbage information. You may go back to the Search page or GarbageData page")
      this.DATA = {
            timestamp: "",
            province: "",
            amphoe: "",
            tambon: "",
            cox: "",
            coy: "",
            userid: "",
            weight: "",
            status: "Not collected",
            location: "",
            description: "",
            nearby: "",
            size: 1,
            visual: 1,
            odor: 1,
            imageURL: "",
        }
        this.selectedfile = null
        this.previewurl = null
    },
    
    async fileChange(e){
      this.selectedfile = e.target.files[0];
      if(this.selectedfile == null) return;
      this.previewurl = URL.createObjectURL(this.selectedfile);
      
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

}
</script>