<template>
  <v-app style = "overflow:auto;">
    <v-card
      class = "back2"
    >
      <Navbar/>
      <v-main>
        <h1 class = "white--text" style = "font-size: 45px;"> Add garbage data</h1>
        <v-card
          max-width = "600px"
          style = "width: 80%;"
          class = "center-itself rounded-xl px-6 py-3 my-9"
        >
          <v-form @submit="addTask" class="form " name="form">
            <v-container>
              <v-row class = "mt-1 px-5" style = "height: 40px"><p class = "center-itself grey--text text--darken-2 font-weight-bold" style = "font-size: 30px;">Location</p></v-row>
              <v-row style = "height: 70px" class = "mr-2">
                <v-col>
                  <v-text-field
                    v-model="DATA.province"
                    type = "text"
                    label = "Province"
                    clearable
                    prepend-icon="mdi-map-marker"
                  >
                  </v-text-field>
                </v-col>
              </v-row>

              <v-row style = "height: 70px" class = "mr-2">
                <v-col>
                  <v-text-field
                    v-model="DATA.amphoe"
                    type = "text"
                    label = "Amphoe"
                    clearable
                    prepend-icon="mdi-map-marker"
                  >
                  </v-text-field>
                </v-col>
              </v-row>

              <v-row class = "mr-2">
                <v-col>
                  <v-text-field
                    v-model="DATA.tambon"
                    type = "text"
                    label = "Tambon"
                    clearable
                    prepend-icon="mdi-map-marker"
                  >
                  </v-text-field>
                </v-col>
              </v-row>
            </v-container>

            <v-row class = "mb-2 mt-0 px-5"><v-divider></v-divider></v-row>
            <v-row class = "mt-3 mb-2 px-5"><p class = "center-itself grey--text text--darken-2 font-weight-bold" style = "font-size: 30px;">Date & Coordinate</p></v-row>
            <v-row class = "px-2 ma-0">
              <v-col cols = "3">
                <v-card
                  class = "light blue lighten-1 rounded-xl"
                  contain
                  dark
                  flat
                >
                  Timestamp
                </v-card>
              </v-col>
              <v-col cols = "9">
                <input
                    type = "datetime-local"
                    v-model="DATA.timestamp"
                    name = "Timestamp"
                    placeholder = "Enter..."
                />
              </v-col>
            </v-row>

            <v-row class = "px-2 ma-0" align = "center">
              <v-col cols = "3">
                <v-card
                  class = "teal lighten-1 rounded-xl"
                  contain
                  dark
                  flat
                >
                  Coordinate
                </v-card>
              </v-col>
              <v-col cols = "4.5">
                <v-text-field
                  type = "number"
                  v-model="DATA.cox"
                  name = "CoX"
                  step = "0.00000001"
                  label = "Latitude"
                >
                </v-text-field>
              </v-col>
              <v-col cols = "4.5">
                <v-text-field
                  type = "number"
                  v-model="DATA.coy"
                  name = "CoY"
                  step = "0.00000001"
                  label = "Longitude"
                >
                </v-text-field>
              </v-col>
            </v-row>

            <!-- End of Coordiante -->

            <v-row class = "mb-2 mt-0 px-5"><v-divider></v-divider></v-row>
            <v-row class = "mt-3 mb-2 px-5"><p class = "center-itself grey--text text--darken-2 font-weight-bold" style = "font-size: 30px;">Severity</p></v-row>
            <v-row class = "px-2 ma-0">
              <v-col cols = "3">
                <v-card
                  class = "purple lighten-1 rounded-xl"
                  contain
                  dark
                  flat
                >
                  Size
                </v-card>
              </v-col>
              <v-col cols = "9">
                <v-slider
                  thumb-label = "always"
                  v-model ="DATA.size"
                  :thumb-size = "25"
                  step = "1"
                  min = "1"
                  max = "5"
                  track-color = "grey lighten-1"
                  :color = "this.sliderColor[this.DATA.size - 1]"
                ></v-slider>
              </v-col>
            </v-row>

            <v-row class = "px-2 ma-0">
              <v-col cols = "3">
                <v-card
                  class = "red lighten-1 rounded-xl"
                  contain
                  dark
                  flat
                >
                  Visual
                </v-card>
              </v-col>
              <v-col cols = "9">
                <v-slider
                  thumb-label = "always"
                  v-model ="DATA.visual"
                  :thumb-size = "25"
                  step = "1"
                  min = "1"
                  max = "5"
                  track-color = "grey lighten-1"
                  :color = "this.sliderColor[this.DATA.visual - 1]"
                ></v-slider>
              </v-col>
            </v-row>

            <v-row class = "px-2 ma-0">
              <v-col cols = "3">
                <v-card
                  class = "orange lighten-1 rounded-xl"
                  contain
                  dark
                  flat
                >
                  Odor
                </v-card>
              </v-col>
              <v-col cols = "9">
                <v-slider
                  thumb-label = "always"
                  v-model ="DATA.odor"
                  :thumb-size = "25"
                  step = "1"
                  min = "1"
                  max = "5"
                  track-color = "grey lighten-1"
                  :color = "this.sliderColor[this.DATA.odor - 1]"
                ></v-slider>
              </v-col>
            </v-row>

            <!-- End of Severity -->

            <v-row class = "mb-2 mt-0 px-5"><v-divider></v-divider></v-row>            
            <v-row class = "mt-3 px-5" style = "height: 40px"><p class = "center-itself grey--text text--darken-2 font-weight-bold" style = "font-size: 30px;">UserID & Other Information</p></v-row>
              <v-row style = "height: 70px" class = "pl-5 pr-8">
                <v-col>
                  <v-text-field
                    v-model="DATA.userid"
                    type = "text"
                    label = "User ID"
                    clearable
                    prepend-icon="mdi-account"
                  >
                  </v-text-field>
                </v-col>
              </v-row>

            <v-row><p class = "center-itself grey--text text--darken-2 font-weight-bold py-3" style = "font-size: 20px">Description</p></v-row>

            <v-row>
              <v-textarea
                rows="4" 
                cols="50" 
                name="comment"
                v-model="DATA.description" 
                form="form"
                placeholder = "Enter your description here..."
                outlined
                label = "Description"
                class = "rounded-xl mx-8"
                clearable
              ></v-textarea>
            </v-row>

            <v-row><p class = "center-itself grey--text text--darken-2 font-weight-bold pb-3" style = "font-size: 20px">Custom Location (No GPS data)</p></v-row>
            <v-row>
              <v-textarea
                rows="4" 
                cols="50" 
                name="location"
                v-model="DATA.location" 
                form="form"
                placeholder = "Enter your custom location here..."
                outlined
                label = "Custom Location (No GPS data)"
                class = "rounded-xl mx-8"
                clearable
              ></v-textarea>
            </v-row>

            <v-row><p class = "center-itself grey--text text--darken-2 font-weight-bold pb-3" style = "font-size: 20px">Nearby Location</p></v-row>
            <v-row>
              <v-textarea
                rows="4" 
                cols="50" 
                name="nearby"
                v-model="DATA.nearby" 
                form="form"
                placeholder = "Enter nearby location here..."
                outlined
                label = "Nearby Location"
                class = "rounded-xl mx-8"
                clearable
              ></v-textarea>
            </v-row>

            <v-row class = "px-2 ma-0" align = "center">
              <v-col cols = "3">
                <v-card
                  class = "orange lighten-1 rounded-xl"
                  contain
                  dark
                  flat
                >
                  Attach Image
                </v-card>
              </v-col>
              <v-col cols = "9">
                <input type ="file" @change="fileChange"/>
              </v-col>
            </v-row>

            <v-expand-transition>
            <v-row v-show = "this.previewurl != null" class = "pb-4">
              <v-card class = "rounded-xl transparent center-itself" style = "height: auto;" flat>
                <v-img
                  :src ="previewurl"
                  contain
                ></v-img>
              </v-card>
            </v-row>
            </v-expand-transition>

            <v-row class = "pb-6 mx-5">
              <v-btn
                class = "center-itself font-weight-bold"
                type = "submit"
                rounded
                block
                dark
              > Submit </v-btn>
            </v-row>
          </v-form>
        </v-card>
      </v-main>
    </v-card>
    <Footer/>
  </v-app>
</template>

<script>
import Navbar from '@/components/Navbar'
import {STR,RTDB} from "@/firebase"
import Footer from "@/components/Footer";

export default {
  components: {
    Navbar,
    Footer,
  },
  name: 'Search',
  data() {
      return{
        DATA: {
            timestamp: "",
            province: "",
            amphoe: "",
            tambon: "",
            cox: "",
            coy: "",
            userid: "",
            status: "Not collected",
            location: "",
            description: "",
            nearby: "",
            size: 1,
            visual: 1,
            odor: 1,
            imageURL: "",
        },
        sliderColor: ['green lighten-1', 'light-green lighten-1', 'amber lighten-1', 'orange lighten-1', 'red lighten-1'],
        selectedfile: null,
        previewurl: null,
        menu: false,
      }
    },
  methods: {
    async addTask(e){
      e.preventDefault()
      const date = new Date()
      const time = Math.round(date.getTime()/1000)
      const newName = time + "-" + this.selectedfile.name
      await STR.ref(`garbage_images/${newName}`).put(this.selectedfile)
      .then(async (snapshot) => this.DATA.imageURL = await snapshot.ref.getDownloadURL())
      // console.log(this.DATA)
      RTDB.ref('garbages').push(this.DATA)
      alert("Successfully add the gargbage information. You may go back to the Search page or GarbageData page")
      this.DATA = {
            timestamp: "",
            province: "",
            amphoe: "",
            tambon: "",
            cox: "",
            coy: "",
            userid: "",
            weight: "",
            status: "Not collected",
            location: "",
            description: "",
            nearby: "",
            size: 1,
            visual: 1,
            odor: 1,
            imageURL: "",
        }
        this.selectedfile = null
        this.previewurl = null
    },
    
    async fileChange(e){
      this.selectedfile = e.target.files[0];
      if(this.selectedfile == null) return;
      this.previewurl = URL.createObjectURL(this.selectedfile);
      
    },
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
</style>