<template>
  <v-app style = "overflow:auto;">
    <Navbar/>
    <v-main>
        <h1> {{this.DATA.province}}, </h1> <h2> {{this.DATA.amphoe}}, </h2><h3> {{this.DATA.tambon}} </h3> 
        <img :src="this.DATA.imageURL"/>
        <div>
            Size = {{this.DATA.size}} <br>
            Visual pollution = {{this.DATA.visual}} <br>
            Odor pollution = {{this.DATA.odor}} <br>
            Coordinate = {{this.DATA.cox}}, {{this.DATA.coy}} <br>
            Current status = {{this.DATA.status}} <br>
            Timestamp = {{this.DATA.timestamp}} <br>
            Submitted by: {{this.DATA.userid}} <br> <br>
            Description: <br>
            {{this.DATA.description}}
        </div>
        <div>
            <label> Update Status <br> </label>
            <select name="status" placeholder="Select..." v-model = "temp" required>
              <option value="Not collected">Not collected</option>
              <option value="In process">In process</option>
              <option value="Successfully collected">Successfully collected</option>
              <option value="Process failed">Process failed</option>
            </select>
            <button @click="updateTask"> :Update </button>
        </div>
        <div>
          <button @click="deleteTask"> DELETE TASK </button>
        </div>
    </v-main>
  </v-app>
</template>

<script>
import Navbar from "@/components/Navbar"
import {DB} from "@/firebase"
export default {
  name: 'Info',
  data() { 
    return{
      id: "",
      DATA: [],
      temp: "",
    }
  },
  components: {Navbar},
  methods: {
    async updateTask(){
      this.DATA.status = this.temp
      await DB.doc(this.id).update({...this.DATA})
      this.$router.replace({name: "GarbageData"})
    },
    async deleteTask(){
      if(confirm("Are you sure?")){
        await DB.doc(this.id).delete()
        this.$router.replace({name: "GarbageData"})
      }
    }
  },
  async created(){
    this.id = this.$route.query.id
    const ret = await DB.doc(this.id).get()
    this.DATA = ret.data()
    console.log(this.DATA)
    console.log(this.id)
  },
}
</script>