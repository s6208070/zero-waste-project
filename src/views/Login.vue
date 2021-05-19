<template>
  <v-app style = "overflow:auto;">
    <v-card 
      class = "back"
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
          max-height = "105"
          contain
        ></v-img>
        <!-- <v-card
          flat
          align = "center"
          class = "pt-7 white--text"
          color = "transparent"
        >Welcome to our website.</v-card> -->
        <Form @login-request="checkLogin" :name ="name" :name2="name2" />
        <v-card
          flat
          align = "center"
          class = "pt-8 pb-6 white--text"
          color = "transparent"
        >No account? <router-link to="/register" class = "white--text font-weight-bold"> Register here </router-link> </v-card>
      </v-main>
      </v-card>
      <Footer/>
  </v-app>
</template>

<script>
import Form from "@/components/Form";
import firebase  from "firebase";
import Footer from "@/components/Footer";

  export default {
    name: 'Login',
    data () {
      return{
        name: "Login",
        name2: "LOGIN"
      }
    },
    components: {
      Form,
      Footer,
    },
    methods: {
      async checkLogin(request){
        try{
          const login = await firebase.auth()
          .signInWithEmailAndPassword(request.Username, request.Password)
          // console.log(login)
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
    height: 700px;
  }
</style>