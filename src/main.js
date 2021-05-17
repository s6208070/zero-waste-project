import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify';
import router from './router'
import './firebase'
import firebase from 'firebase/app'
import VueParticles from 'vue-particles'

Vue.use(VueParticles)
Vue.config.productionTip = false;

let app;

firebase.auth().onAuthStateChanged(user => {
  console.log(user)
  if(!app){
    app = new Vue({
      vuetify,
      router,
      render: h => h(App)
    }).$mount('#app')
  }
})


