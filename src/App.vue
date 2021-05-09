<template>
  <v-app>
    <v-app-bar 
    app dark color = "indigo darken-1" 
    elevate-on-scroll
    src = "https://img.freepik.com/free-vector/abstract-background-with-dots-blurry-shapes_23-2148705493.jpg?size=626&ext=jpg&ga=GA1.2.1842958395.1604448000"
    >
      <v-toolbar-title class = "font-weight-medium"> INTERASHTIVE DATA </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-btn outlined rounded color = "white--text">
        <span>LOGOUT</span>
        <v-icon right>mdi-exit-to-app</v-icon>
      </v-btn>
    </v-app-bar>

    <v-main>
      <Table />
    </v-main>
  </v-app>
</template>

<script>
  import Table from '@/components/Table'
  export default {
    name: 'App',
    components: { Table },
  }
</script>