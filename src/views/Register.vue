<template>
  <v-app style = "overflow:auto;">
    <v-card 
      class = "back"
      height = "780px"
    >
    <v-app-bar 
      app dark color = "grey-darken-4" 
    >
      <v-toolbar-title class = "font-weight-medium"> INTERASHTIVE DATA </v-toolbar-title>
      <v-spacer></v-spacer>
      <div id="nav">
        Please login before accessing the website
      </div>
      
    </v-app-bar>
      <v-main>
        <v-img
          src = "../assets/interashtive-logo.png"
          max-height = "110"
          contain
        ></v-img>
        <v-card
          flat
          align = "center"
          class = "pt-7 white--text"
          color = "transparent"
        >Create new account with email and password WITH 6 OR MORE LETTERS</v-card>
        <Form @login-request="createAccount" :name ="name" :name2="name2" />
        <v-card
          flat
          align = "center"
          class = "pt-7 white--text"
          color = "transparent"
        >Already has an account? <router-link to="/" class = "white--text font-weight-bold"> Login here </router-link></v-card>
      </v-main>
    </v-card>
    <Footer/>
  </v-app>
</template>

<script>
import Form from "@/components/Form"
import firebase from "firebase"
import Footer from "@/components/Footer";

  export default {
    name: 'Register',
    data () {
      return{
        name: "Register",
        name2: "CREATE NEW ACCOUNT"
      }
    },
    components: {
      Form,
      Footer,
    },
    methods: {
      async createAccount(request){
        try{
            const regis = await firebase.auth()
            .createUserWithEmailAndPassword(request.Username, request.Password)
            console.log(regis)
            this.$router.push({name: "Search"})
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
  }
</style>