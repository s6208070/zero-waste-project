<template>
  <v-app>
    <v-app-bar 
    app dark color = "indigo darken-1" 
    elevate-on-scroll
    src = "https://img.freepik.com/free-vector/abstract-background-with-dots-blurry-shapes_23-2148705493.jpg?size=626&ext=jpg&ga=GA1.2.1842958395.1604448000"
    >
      <v-toolbar-title class = "font-weight-medium"> INTERASHTIVE DATA </v-toolbar-title>
      <v-spacer></v-spacer>
    </v-app-bar>

    <v-main>
      Welcome to our website, No registeration form yet. Contact admin to gain access.
      <Form @login-request="checkLogin" />
    </v-main>
  </v-app>
</template>

<script>
import Form from "./components/Form"
  export default {
    name: 'App',
    components: {
      Form
    },
    methods: {
      async checkLogin(request){
        const res = await fetch("api/users")
        var data = await res.json()
        console.log(data)
        console.log(request)
        var exist=false;
        for(var i=0;i < data.length;i++){
          if(data[i].Username == request.Username 
          && data[i].Password == request.Password) exist = true
        }
        if(exist){
          alert("USER EXIST, LOGIN SUCCESSFUL");
        }else{
          alert("WRONG USERNAME OR PASSWORD, PLEASE TRY AGAIN")
        }
      },
      
    }
  }
</script>