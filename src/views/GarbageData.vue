<template>
  <v-app style = "overflow:auto;">
    <Navbar/>
    <v-main>
      <div> hello </div>
      <h1> You are looking for: </h1>
      <h3 v-if="this.userReq.all"> EVERYTHING, right? </h3>
      <h4 v-else> {{this.userReq.p}}, {{this.userReq.a}}, {{this.userReq.t}}  right? <br> <br> </h4>
      <div> TODO: Create the Fucking table </div>
      <v-card
        flat
        class = "tbcontain"
        justify = "center"
      >
        <Table :userReq = "userReq"/>
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
          userReq: []
      }
   },
  created(){
    const rec = this.$route.query;
    this.userReq = {
            all: true,
            p: "",
            a: "",
            t: "",
          }
    if(typeof rec.province !== 'undefined') this.userReq.p = this.$route.query.province;
    if(typeof rec.amphoe !== 'undefined') this.userReq.a = this.$route.query.amphoe;
    if(typeof rec.tambon !== 'undefined') this.userReq.t = this.$route.query.tambon;
    if(typeof rec.all !== 'undefined') this.userReq.all = this.$route.query.all;
  }
}
</script>

<style>
  .tbcontain {
    margin-left: 10%;
    margin-right: 10%;
  }
</style>