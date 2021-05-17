<template>
    <v-footer dark class = "bottom-itself">
        <v-card
          class = "text-center flex"
          flat
          tile
          padless
          justify-center
        >
            <v-card-text class = "white--text text-center">
            {{ new Date().getFullYear() }} — <strong>Interashtive Team</strong> •
            <a href="https://github.com/s6208070/zero-waste-project" target = "_blank" style = "text-decoration: none;" class = "white--text font-weight-medium"><strong>Github</strong></a>
            </v-card-text>
        </v-card>
    </v-footer>
</template>

<style>
.bottom-itself{
    position: relative;
    bottom: 0px;
  }
</style>