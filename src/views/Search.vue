<template>
  <v-app style = "overflow:auto;">
    <Navbar/>
    <v-main>
      <h1> Select Area </h1>
      <form @submit="onSubmit" class="form">
        <div>
            <label>Province<br> </label>
            <input
                type = "text"
                v-model="Province"
                name = "Province"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Amphoe <br> </label>
            <input
                type = "text"
                name = "Amphoe"
                v-model="Amphoe"
                placeholder = "Enter..."
            />
        </div>
        <div>
            <label>Tambon <br>  </label>
            <input
                type = "text"
                name = "Tambon"
                v-model="Tambon"
                placeholder = "Enter..."
            />
        </div>
        <input type = "submit" value="Search"/>
    </form>

    <button v-on:click= "onEverything"> See everything </button>
    </v-main>
  </v-app>
</template>
<script>
import Navbar from "@/components/Navbar"
import firebase from "firebase"
export default {
  name: 'Search',
  components: {Navbar},
  data() {
      return{
        Province: "-",
        Amphoe: "-",
        Tambon: "-",
      }
    },
  methods: {
    onSubmit(e){
      e.preventDefault()
      this.$router.push({name: "GarbageData", query: {all: false, province: this.Province, amphoe: this.Amphoe, tambon: this.Tambon}})
      this.Province = "-"
      this.Amphoe = "-"
      this.Tambon = "-"
    },
    onEverything(){
      this.$router.push({name: "GarbageData", query: {all: true}})
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