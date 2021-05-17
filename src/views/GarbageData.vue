<template>
  <v-app style = "overflow:auto;">
    <Navbar/>
    <v-main>
      <div> hello </div>
      <h1> You are looking for: </h1>
      <h3 v-if="this.userReq.all"> EVERYTHING, right? </h3>
      <h4 v-else> {{this.userReq.province}}, {{this.userReq.amphoe}}, {{this.userReq.tambon}}  right? <br> <br> </h4>

      <v-card flat tile class = "tbcontain">
        <Table/>
      </v-card>
    </v-main>
  </v-app>
</template>

<script>
import Table from "@/components/Table"
import Navbar from "@/components/Navbar"
export default {
  name: 'GarbageData',
  components: {
    Table,
    Navbar,
  },
  data() {
      return{
        userReq:{
          province: "-",
          amphoe: "-",
          tambon: "-",
          all: true,
        }
      }
   },
  methods:{

  },
  created(){
    let q = this.$route.query
    if(typeof q.all != 'undefined') this.userReq.all = q.all 
    if(typeof q.province != 'undefined') this.userReq.province = q.province
    if(typeof q.amphoe != 'undefined') this.userReq.amphoe = q.amphoe
    if(typeof q.tambon != 'undefined') this.userReq.tambon = q.tambon
  }
}
</script>

<style>
  .tbcontain {
    margin-left: 10%;
    margin-right: 10%;
  }
</style>