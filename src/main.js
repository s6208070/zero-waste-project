import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify';
import router from './router'
import firebase from 'firebase/app'

Vue.config.productionTip = false;


const firebaseConfig = {
  apiKey: "AIzaSyADr89Q1Bqb-X3Fi_9cDq-W-QHAqKtAHP4",
  authDomain: "zero-waste-d97bf.firebaseapp.com",
  projectId: "zero-waste-d97bf",
  storageBucket: "zero-waste-d97bf.appspot.com",
  messagingSenderId: "174775595809",
  appId: "1:174775595809:web:7613b285e7563dd6e88460"
};
firebase.initializeApp(firebaseConfig);


new Vue({
  vuetify,
  router,
  render: h => h(App)
}).$mount('#app')
