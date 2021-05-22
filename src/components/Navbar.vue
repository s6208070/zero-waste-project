<template>
     <v-app-bar
      app dark color = "grey-darken-4" 
    >
      <v-toolbar-title class = "font-weight-medium"> INTERASHTIVE DATA </v-toolbar-title>
      <v-spacer></v-spacer>
      <div id = "nav" class = "ma-0 pa-0">
          <v-container>
              <v-row>
                  <v-col class="px-0">
                    <v-btn text>
                        <router-link to="/Search" style="text-decoration: none;"> 
                            Search 
                        </router-link>
                    </v-btn>
                  </v-col>
                  <v-col class="px-0">
                    <v-btn text>
                        <router-link to="/garbagedata" style="text-decoration: none;"> 
                            Garbage data 
                        </router-link>
                    </v-btn>
                  </v-col>
                  <v-col class = "px-0">
                    <v-btn text>
                        <router-link to="/adddata" style="text-decoration: none;"> 
                            Add Data 
                        </router-link>
                    </v-btn>
                  </v-col>
                  <v-col class = "pr-1 pl-2">
                    <v-btn @click= "logOut" outlined class = "font-weight-bold" color = "blue-grey lighten-5">
                        LOGOUT
                        <v-icon right small>mdi-logout</v-icon>
                    </v-btn>
                  </v-col>
              </v-row>
          </v-container>
      </div>
    </v-app-bar>
</template>
<script>
import firebase from "firebase"
export default {
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
    },
}
</script>
