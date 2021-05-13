<template>
  <v-app style = "overflow:auto;">
     <v-app-bar
      app dark color = "indigo darken-1" 

      src = "https://img.freepik.com/free-vector/abstract-background-with-dots-blurry-shapes_23-2148705493.jpg?size=626&ext=jpg&ga=GA1.2.1842958395.1604448000"
    >
      <v-toolbar-title class = "font-weight-medium"> INTERASHTIVE DATA </v-toolbar-title>
      <v-spacer></v-spacer>
      <div id="nav">
        <router-link to="/"> Logout </router-link> -
        <router-link to="/Search"> Search </router-link> -
        <router-link to="/garbagedata"> Garbagedata </router-link> -
        <router-link to="/adddata"> Add Data </router-link>
      </div>
      
    </v-app-bar>
    <v-main>
      <h1> Add garbage data</h1>
      <form @submit="addTask" class="form">
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
                step = "0.000001"
                name = "CoX"
                placeholder = "Enter X..."
            />
            <input
                type = "number"
                v-model="DATA.coy"
                step = "0.000001"
                name = "CoY"
                placeholder = "Enter Y..."
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
            <label>Weight<br> </label>
            <input
                type = "number"
                v-model="DATA.weight"
                step = "0.01"
                name = "Weight"
                placeholder = "Enter..."
            />
        </div>
        <input type = "submit"/>
    </form>
    </v-main>
  </v-app>
</template>
<script>
export default {
  name: 'Search',
  data() {
      return{
        DATA: {
            id: "",
            timestamp: "",
            province: "",
            amphoe: "",
            tambon: "",
            cox: "",
            coy: "",
            userid: "",
            weight: "",
            status: "Not collected",
        },
      }
    },
  methods: {
    async addTask(e){
      e.preventDefault()
      console.log(JSON.stringify(this.DATA));
      const res = await fetch("api/garbages", {
          method: 'POST',
          headers: {
              'Content-type': 'application/json', 
          },
          body: JSON.stringify(this.DATA),
      })
      res.json()
    },
  }
}
</script>