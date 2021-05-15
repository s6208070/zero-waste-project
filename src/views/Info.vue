<template>
  <v-app style = "overflow:auto;">
    <Navbar/>
    <v-main>
        <h1> {{this.DATA.province}}, </h1> <h2> {{this.DATA.amphoe}}, </h2><h3> {{this.DATA.tambon}} </h3> 
        <img :src="this.DATA.base64img"/>
        <div>
            Weight = {{this.DATA.weight}} <br>
            Coordinate = {{this.DATA.cox}}, {{this.DATA.coy}} <br>
            Current status = {{this.DATA.status}} <br>
            Timestamp = {{this.DATA.timestamp}} <br>
            Submitted by: {{this.DATA.userid}} <br> <br>
            Description: <br>
            {{this.DATA.description}}
        </div>
    </v-main>
  </v-app>
</template>

<script>
import Navbar from "@/components/Navbar"
export default {
  name: 'Info',
  components: {
    Navbar,
  },
  data() {
      return{
          id: "",
          DATA: []
      }
   },
   methods: {
       async loadData(id){
           console.log(`api/garbages/${id}`)
           const res = await fetch(`api/garbages/${id}`)
           this.DATA = await res.json()
           console.log(this.DATA)
       }
   },
  async created(){
      const req = this.$route.query
      this.id = req.id
      console.log(this.id)
      this.loadData(this.id)
  }
}
</script>