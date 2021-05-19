<template>
  <v-app style = "overflow:auto;">
    <v-card
      class = "back2"
    >
      <Navbar/>
      <v-main>
        <v-container>
          <v-row align = "center" justify = "center">
            <v-icon x-large dark>mdi-map-marker</v-icon>
            <h1 class = "white--text ml-3" style = "font-size: 45px;"> Location </h1> 
          </v-row>

          <v-row justify = "center"><div class = "smol2"></div></v-row>

          <v-row align = "center">
            <h1 class = "center-itself white--text" style = "font-size: 50px;"> {{this.DATA.province}} </h1> 
          </v-row>

          <v-row>
            <h2 class = "center-itself white--text font-weight-medium" style = "font-size: 40px;"> {{this.DATA.amphoe}} </h2>
          </v-row>

          <v-row class = "mb-4">
            <h3 class = "center-itself white--text font-weight-regular" style = "font-size: 30px;"> {{this.DATA.tambon}} </h3>
          </v-row>

          <v-row justify = "center" class = "mb-5">
            <v-card class = "rounded-xl font-weight-bold grey--text text--darken-3" style = "width: 80%; font-size: 20px;" max-width = "350px">
              Submitted by: {{this.DATA.userid}}
            </v-card>
          </v-row>

          <v-row>
            <v-card class = "rounded-xl transparent center-itself" style = "height: auto;" flat>
              <v-img
                :src ="this.DATA.imageURL"
                contain
              ></v-img>
            </v-card>
          </v-row>
        </v-container>

        <v-card class = "rounded-xl center-itself my-5 pa-4" style = "width: 80%;" max-width = "600px">
          <v-container>
            <v-row>
              <v-col cols = "4">
                <v-card class = "rounded-xl" contain dark flat :color = "this.severityColor[this.DATA.size - 1]"> Size </v-card>
              </v-col>
              <v-col cols = "4">
                <v-card class = "rounded-xl" contain dark flat :color = "this.severityColor[this.DATA.visual - 1]"> Visual Pollution </v-card>
              </v-col>
              <v-col cols = "4">
                <v-card class = "rounded-xl" contain dark flat :color = "this.severityColor[this.DATA.odor - 1]"> Odor Pollution </v-card>
              </v-col>
            </v-row>

            <v-row>
              <v-col cols = "4" justify = "center" class = "pa-0">
                <p class = "grey--text text--darken-3 font-weight-bold" style = "font-size: 60px;"> {{this.DATA.size}} </p>
              </v-col>
              <v-col cols = "4" justify = "center" class = "pa-0">
                <p class = "grey--text text--darken-3 font-weight-bold" style = "font-size: 60px;"> {{this.DATA.visual}} </p>
              </v-col>
              <v-col cols = "4" justify = "center" class = "pa-0">
                <p class = "grey--text text--darken-3 font-weight-bold" style = "font-size: 60px;"> {{this.DATA.odor}} </p>
              </v-col>
            </v-row>
            
            <v-row class = "mt-5 mb-3"><v-divider></v-divider></v-row>

            <v-row align = "center">
              <v-col cols = "4">
                <v-card class = "teal lighten-1 rounded-xl" contain dark flat> Coordinate </v-card>
              </v-col>
              <v-col cols = "4">
                <v-card class = "grey lighten-4 rounded-xl" contain flat> {{this.DATA.cox}} </v-card>
              </v-col>
              <v-col cols = "4">
                <v-card class = "grey lighten-4 rounded-xl" contain flat> {{this.DATA.coy}} </v-card>
              </v-col>
            </v-row>

            <v-row align = "center">
              <v-col cols = "4">
                <v-card class = "light-blue lighten-1 rounded-xl" contain dark flat> Timestamp </v-card>
              </v-col>
              <v-col cols = "8">
                <v-card class = "grey lighten-4 rounded-xl" contain flat> {{this.DATA.timestamp}} </v-card>
              </v-col>
            </v-row>

            <v-row class = "mt-5 mb-3"><v-divider></v-divider></v-row>

            <v-row justify = "center" class = "font-weight-bold grey-text text--darken-1" style = "font-size: 27px;">Description</v-row>
            <v-row justify = "center" class = "mt-3">
              <v-card flat class = "grey lighten-4 rounded-xl my-2 pa-4" style = "width: 95%;">
                {{this.DATA.description}}
              </v-card>
            </v-row>

            <v-row>
                <v-col v-if="this.show">
                  <v-btn rounded depressed dark class = "font-weight-bold" block @click="toggleShow"><v-icon left small>mdi-eye-off</v-icon> HIDE TABLE </v-btn>
                  <v-expand-transition>
                    <div v-show ="this.show">
                      <Nearby :cox="this.DATA.cox" :coy="this.DATA.coy" :ID="id" />
                    </div>
                  </v-expand-transition>
                </v-col>
                <v-col v-else>
                  <v-btn rounded depressed dark class = "font-weight-bold" block @click="toggleShow"><v-icon left small>mdi-eye</v-icon> SHOW NEARBY GARBAGE LOCATION </v-btn>
                </v-col>
            </v-row>
          </v-container>
        </v-card>

        <v-container style = "width: 80%; max-width: 620px;">
          <v-row align = "center">
            <v-col cols = "2.5">
              <v-card dark :color = "selectColor(this.selected)" class = "rounded-xl py-1 px-3" style = "width: 100%; height: 100%;">
                Status
              </v-card>
            </v-col>
            <v-col cols = "7" style = "height: 64px;">
              <v-select
                :items="items"
                dense
                solo
                rounded
                v-model ="selected"
              ></v-select>
            </v-col>
            <v-col cols = "2.5">
              <v-btn
                dark
                block
                rounded
                @click="updateTask"
              >Update</v-btn>
            </v-col>
          </v-row>

          <v-row class = "mx-0 pt-3 pb-6">
            <v-btn
              rounded
              block
              class = "font-weight-bold red lighten-1"
              dark
              @click="deleteTask"
            ><v-icon small left>mdi-delete</v-icon> DELETE TASK</v-btn>
          </v-row>
        </v-container>
      </v-main>
    </v-card>
    <Footer/>
  </v-app>
</template>

<script>
import Navbar from "@/components/Navbar"
import {RTDB} from "@/firebase"
import Nearby from "@/components/Nearby"
import Footer from "@/components/Footer";

export default {
  name: 'Info',
  data() { 
    return{
      id: "",
      DATA: "",
      selected: '',
      show: false,
      severityColor: ['green lighten-1', 'light-green lighten-1', 'amber lighten-1', 'orange lighten-1', 'red lighten-1'],
      items: ['Not collected', 'In process', 'Successfully collected', 'Process failed'],
    }
  },
  components: {
    Nearby,
    Navbar,
    Footer,
  },
  methods: {
    async updateTask(){
      this.DATA.status = this.selected
      await RTDB.ref("garbages").child(this.id).update(this.DATA)
      this.$router.replace({name: "GarbageData"})
    },
    async deleteTask(){
      if(confirm("Are you sure?")){
        await RTDB.ref("garbages").child(this.id).remove()
        this.$router.replace({name: "GarbageData"})
      }
    },
    toggleShow(){
      this.show = !this.show
    },
    selectColor(a){
      if(a == 'Not collected') return 'red lighten-1'
      if(a == 'In process') return 'amber lighten-1'
      if(a == 'Successfully collected') return 'green lighten-1'
      if(a == 'Process failed') return 'grey lighten-1'
    }
  },
  async created(){
    this.id = this.$route.query.id
    //const ret = await DB.doc(this.id).get()
    await RTDB.ref("garbages").once('value', snapshot => {
      const data = snapshot.val();
      Object.keys(data).forEach(key => {
      if(key == this.id) this.DATA = {
        id:key ,...data[key]}
      })
    })
    //this.DATA = ret.data()
    console.log(this.DATA)
    console.log(this.id)

    if(this.DATA.status == 'Not collected') this.selected = 'Not collected'
    if(this.DATA.status == 'In process') this.selected = 'In process'
    if(this.DATA.status == 'Successfully collected') this.selected = 'Successfully collected'
    if(this.DATA.status == 'Process failed') this.selected = 'Process failed'
  },
}
</script>

<style>
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

  .smol2 {
    width: 220px;
    height: 4px;
    background: white;
    margin-top: 9px;
    margin-bottom: 4px;
  }
</style>