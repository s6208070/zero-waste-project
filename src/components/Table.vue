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
        if(f.all == true || f.all == "true") return
        this.Garbage = this.Garbage.filter(function(item) {
          return item != null && item.province == f.p && item.amphoe == f.a && item.t == f.t
        })
      },
      handleClick(e){
        this.$router.push({name: "Info", query: {id: e.id}})
      }
    },
    mounted(){
      this.loadData()
    }
  }
</script>