import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import NewsHome from '../views/News.vue'
import NewsDetails from '../components/News/Details.vue'
import Characters from '../views/Characters.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/news',
    name: 'home',
    component: NewsHome,
  },
  {
    path: '/news/:id',
      name: 'newsDetails',
     component: NewsDetails,
  },
  {
    path: '/characters',
    name: 'Characters',
    component: Characters
  },
]

const router = new VueRouter({
  routes
})

export default router
