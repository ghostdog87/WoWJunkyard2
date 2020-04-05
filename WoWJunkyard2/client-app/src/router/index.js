import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
//import NewsHome from '../views/News.vue'
import NewsHome from '../components/News/index.vue'
import NewsDetails from '../components/News/Details.vue'
import NewsCreate from '../components/News/Create.vue'
import Characters from '../views/Characters.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/news',
    name: 'news',
    component: NewsHome,
  },
  {
    path: '/news/create',
    name: 'newsCreate',
    component: NewsCreate,
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
