<template>
  <div class = "ma-4">
    <v-data-table
      :headers="headers"
      :items="Garbage"
      item-key="name"
      class="elevation-1"
    >
    </v-data-table>
    <button v-on:click="loadData"> CHECK </button>
  </div>
</template>

<script>
  export default {
    name: "Table",
    data () {
      return {
        search: '',
        Garbage: [],
      }
    },
    props: {
      userReq: {
        type: Object,
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
          { text: 'Weight', value: 'weight' },
        ]
      },
    },
    methods: {
      async loadData(){
        const res = await fetch("api/garbages")
        this.Garbage = await res.json()
        const f = this.userReq
        console.log(f.all)
        if(f.all == true || f.all == "true") return
        console.log(f.all)
        this.Garbage = this.Garbage.filter(function(item) {
          return item != null && item.province == f.p && item.amphoe == f.a && item.t == f.t
        })
      },
    },
    mounted(){
      console.log(this.userReq.p)
      this.loadData()
    }
  }
</script>