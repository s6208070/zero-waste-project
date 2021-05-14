import Vue from 'vue'
import VueRouter from 'vue-router'
import Login from '../views/Login.vue'
import Search from '../views/Search.vue'
import GarbageData from '../views/GarbageData.vue'
import AddData from '../views/AddData.vue'
import Info from '../views/Info.vue'
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
  },
  {
    path: '/garbagedata',
    name: 'GarbageData',
    component: GarbageData,
  },
  {
    path: '/adddata',
    name: 'AddData',
    component: AddData,
  },
  {
    path: '/info',
    name: 'Info',
    component: Info,
  }
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
