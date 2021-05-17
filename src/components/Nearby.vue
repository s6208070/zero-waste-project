<template>
  <div class = "ma-4">
    <v-data-table
      :headers="headers"
      :items="Garbage"
      item-key="name"
      class="elevation-1"
      @click:row="handleClick"
    >
    </v-data-table>
  </div>
</template>

<script>
import {RTDB} from "@/firebase"

export default {
  name: "Table",
  data(){
    return{
      Garbage: [],
      temp:[]
    }
  },
  props:["cox","coy","ID"],
  computed: {
    headers () {
      return [
        {
          text: 'Timestamp',
          align: 'start',
          value: 'timestamp',
        },
        { text: 'Coordinate X', value: 'cox' },
        { text: 'Coordinate Y', value: 'coy' },
        { text: 'UserID', value: 'userid' },
        { text: 'status', value: 'status' },
      ]
    },
  },
  methods: {
    handleClick(e){
      console.log(e)
      this.$router.push({name: "Info", query: {id: e.id}})
    },
  },
  async created(){
    await RTDB.ref('garbages').once('value', snapshot => {
      const data = snapshot.val();
      Object.keys(data).forEach(key => {
        this.temp.push({
          id:key ,...data[key]})
      })
      
      const x1 = parseFloat(this.cox)
      const y1 = parseFloat(this.coy)
      const R = 6357
      for(var i = 0;i < this.temp.length;i++){
          var x2 = parseFloat(this.temp[i].cox)
          var y2 = parseFloat(this.temp[i].coy)
          var degX = (x1-x2) * (Math.PI/180)
          var degY = (y1-y2) * (Math.PI/180)
          var a = 
            Math.sin(degX/2) * Math.sin(degX/2) +
            Math.cos(x1 * (Math.PI/180)) * Math.cos(x2 * (Math.PI/180)) * 
            Math.sin(degY/2) * Math.sin(degY/2)
          var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a)); 
          var dist = R * c; // Distance in km
          console.log(dist)
          if(dist <= 10 && this.temp[i].id != this.ID){
              this.Garbage.push(this.temp[i])
          }
      }
    })
  },
}
</script>