<template>
  <v-app style = "overflow:auto;">
    <v-card 
      class = "back"
    >
      <Navbar/>
      <v-main>
        <h1 class = "white--text font-weight-bold search-title pb-6"> Select Area </h1>
        <v-card
          max-width = "400px"
          class = "px-5 py-3 rounded-xl center-itself"
        >

        <v-form class = "form" @submit = "onSubmit">
          <v-container>
            <v-row style = "height: 70px">
              <v-col>
                <v-text-field
                  v-model="Province"
                  type = "text"
                  label = "Province"
                  clearable
                  prepend-icon="mdi-map-marker"
                >
                </v-text-field>
              </v-col>
            </v-row>

            <v-row style = "height: 70px">
              <v-col>
                <v-text-field
                  v-model="Amphoe"
                  type = "text"
                  label = "Amphoe"
                  clearable
                  prepend-icon="mdi-map-marker"
                >
                </v-text-field>
              </v-col>
            </v-row>

            <v-row>
              <v-col>
                <v-text-field
                  v-model="Tambon"
                  type = "text"
                  label = "Tambon"
                  clearable
                  prepend-icon="mdi-map-marker"
                >
                </v-text-field>
              </v-col>
            </v-row>

            <v-row>
              <v-col>
                <v-btn
                  type = "submit"
                  flat
                  rounded
                  dark
                  block
                  class = "font-weight-bold grey darken-4"
                >SEARCH</v-btn>
              </v-col>
            </v-row>
          </v-container>
        </v-form>
      </v-card>
      
      <br><p class = "mb-6 font-weight-bold white--text">or</p>
      
      <v-btn 
        @click = "onEverything"
        class = "font-weight-bold py-5"
        width = "400px"
        rounded
        dark
        elevation = "5"
      >SEE EVERYTHING</v-btn>
      </v-main>
    </v-card>
    <Footer/>
  </v-app>
</template>
<script>
import Navbar from "@/components/Navbar"
import firebase from "firebase"
import Footer from "@/components/Footer"

export default {
  name: 'Search',
  components: {
    Navbar,
    Footer,
  },
  data() {
      return{
        Province: "",
        Amphoe: "",
        Tambon: "",
      }
    },
  methods: {
    onSubmit(e){
      if(this.Province == "") {this.Province = "-"}
      if(this.Amphoe == "") {this.Amphoe = "-"}
      if(this.Tambon == "") {this.Tambon = "-"}
      e.preventDefault()
      this.$router.push({name: "GarbageData", query: {all: false, province: this.Province, amphoe: this.Amphoe, tambon: this.Tambon}})
      this.Province = ""
      this.Amphoe = ""
      this.Tambon = ""
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

<style>
  .back {
    background-image: url(../assets/login-bg.png);
    background-size: cover;
    height: 700px;
  }

  .center-itself{
    position: relative;
    left: 50%;
    transform: translateX(-50%);
  }

  .search-title {
    font-size: 50px;
  }
</style>