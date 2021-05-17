<template>
  <v-app style = "overflow:auto;">
    <v-card 
      class = "back2"
    >
      <Navbar/>
      <v-main>
        <h2 class = "white--text"> Currently, </h2>
        <h1 class = "white--text"> You are looking for: </h1>
        <v-container class = "mt-3">
          <v-row justify="center">
            <v-col cols="1" class = "ma-0 pa-0">
              <v-icon x-large right dark>mdi-map-marker</v-icon>
            </v-col>
            <v-col cols="4" class = "ma-0 pa-0">
              <v-card
                rounded = "xl"
                class = "center-itself text-center py-2 grey--text text--darken-2"
              >
                <h3 v-if="this.userReq.all" class = "font-weight-black"> EVERYTHING </h3>
                <h4 v-else class = "font-weight-black"> {{this.userReq.province}}, &nbsp;{{this.userReq.amphoe}}, &nbsp;{{this.userReq.tambon}}</h4>
              </v-card>
            </v-col>
            <v-col cols="1" class = "ma-0 pa-0">
            </v-col>
          </v-row>
        </v-container>
        <v-card flat class = "tbcontain mb-10 mt-8 rounded-xl transparent">
          <Table/>
        </v-card>
      </v-main>
    </v-card>
    <Footer/>
  </v-app>
</template>

<script>
import Table from "@/components/Table"
import Navbar from "@/components/Navbar"
import Footer from "@/components/Footer";

export default {
  name: 'GarbageData',
  components: {
    Table,
    Navbar,
    Footer,
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

  .back2 {
    background-image: url(../assets/login-bg.png);
    background-size: cover;
    height: 100%;
  }

  .center-itself{
    position: relative;
    left: 50%;
    transform: translateX(-50%);
  }
</style>