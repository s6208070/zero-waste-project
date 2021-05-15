<template>
     <v-app-bar
      app dark color = "indigo darken-1" 

      src = "https://img.freepik.com/free-vector/abstract-background-with-dots-blurry-shapes_23-2148705493.jpg?size=626&ext=jpg&ga=GA1.2.1842958395.1604448000"
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
                  <v-col class = "px-0">
                    <v-btn text>
                        <router-link to="/" style="text-decoration: none;"> 
                            LOGOUT 
                        </router-link>
                    </v-btn>
                  </v-col>
              </v-row>
          </v-container>
      </div>
    </v-app-bar>
</template>
<script>
export default{

}
</script>
