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
export default {
  name: 'Search',
  data() {
      return{
        Province: "",
        Amphoe: "",
        Tambon: "",
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
    }
  }
}
</script>