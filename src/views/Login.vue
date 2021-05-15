<template>
  <v-app style = "overflow:auto;">
    <v-card 
      class = "back"
      height = "720px"
    >
    <v-app-bar 
      app dark color = "grey-darken-4" 
    >
      <v-toolbar-title class = "font-weight-medium"> INTERASHTIVE DATA </v-toolbar-title>
      <v-spacer></v-spacer>
      <div id="nav">
        Please contact admin to gain access
      </div>
      
    </v-app-bar>
      <v-main>
        <v-img
          src = "../assets/interashtive-logo.png"
          max-height = "105"
          contain
        ></v-img>
        <v-card
          flat
          align = "center"
          class = "pt-7 white--text"
          color = "transparent"
        >Welcome to our website, currently there is no registration form yet... Please contact admin to gain access.</v-card>
        <Form @login-request="checkLogin" />
      </v-main>
    </v-card>

    <v-footer dark>
      <v-card
        class = "text-center flex"
        flat
        tile
        justify-center
      >
        <v-card-text class = "white--text text-center">
          {{ new Date().getFullYear() }} — <strong>Interashtive Team</strong>
        </v-card-text>
      </v-card>
    </v-footer>
  </v-app>
</template>

<script>
import Form from "@/components/Form"

  export default {
    name: 'Login',
    components: {
      Form
    },
    methods: {
      async checkLogin(request){
        const res = await fetch("api/users")
        var data = await res.json()
        var exist=false;
        for(var i=0;i < data.length;i++){
          if(data[i].Username == request.Username 
          && data[i].Password == request.Password) exist = true
        }
        if(exist){
          alert("USER EXIST, LOGIN SUCCESSFUL");
          this.$router.push({name: "Search"});
        }else{
          alert("WRONG USERNAME OR PASSWORD, PLEASE TRY AGAIN")
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