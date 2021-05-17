<template>
  <div class = "my-4 mx-2">
    <v-data-table
      :headers="headers"
      :items="Garbage"
      item-key="name"
      class="elevation-1 rounded-xl"
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
      userReq:{
        all: true,
      },
      Garbage: [],
      temp:[]
    }
  },
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
        { text: 'Province', value: 'province' },
        { text: 'Amphoe', value: 'amphoe'}
      ]
    },
  },
  methods: {
    handleClick(e){
      this.$router.push({name: "Info", query: {id: e.id}})
    },
  },
  async created(){
    let q = this.$route.query
    if(typeof q.all != 'undefined') this.userReq.all = q.all 
    if(typeof q.province != 'undefined') this.userReq.province = q.province
    if(typeof q.amphoe != 'undefined') this.userReq.amphoe = q.amphoe
    if(typeof q.tambon != 'undefined') this.userReq.tambon = q.tambon
    await RTDB.ref('garbages').once('value', snapshot => {
      const data = snapshot.val();
      Object.keys(data).forEach(key => {
        this.temp.push({
          id:key ,...data[key]})
      })
      
      if(!this.userReq.all){
        for(var i=0;i < this.temp.length;i++){
          if((this.temp[i].province == this.userReq.province || this.userReq.province == "-")
          && (this.temp[i].amphoe == this.userReq.amphoe || this.userReq.amphoe == "-")
          && (this.temp[i].tambon == this.userReq.tambon || this.userReq.tambon == "-")){
            this.Garbage.push(this.temp[i])
          }
        }
      }else{
        this.Garbage = this.temp
      }
    })
  },
}
</script>