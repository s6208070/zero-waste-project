import Vue from 'vue'
import VueRouter from 'vue-router'
import Login from '../views/Login.vue'
import Search from '../views/Search.vue'
import GarbageData from '../views/GarbageData.vue'
import AddData from '../views/AddData.vue'
import Info from '../views/Info.vue'
import Register from '../views/Register.vue'
import firebase from "firebase"
Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Login',
    component: Login
  },
  {
    path: '/search',
    name: 'Search',
    component: Search,
    meta: {requiresAuth: true}
  },
  {
    path: '/garbagedata',
    name: 'GarbageData',
    component: GarbageData,
    meta: {requiresAuth: true}
  },
  {
    path: '/adddata',
    name: 'AddData',
    component: AddData,
    meta: {requiresAuth: true}
  },
  {
    path: '/info',
    name: 'Info',
    component: Info,
    meta: {requiresAuth: true}
  },
  {
    path: '/register',
    name: 'Register',
    component: Register,
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

router.beforeEach((to,from,next) => {
  const requiresAuth = to.matched.some(record => record.meta.requiresAuth);
  const isAuth = firebase.auth().currentUser;
  if(requiresAuth && !isAuth){
    next("/");
  }else{
    next();
  }
})

export default router
