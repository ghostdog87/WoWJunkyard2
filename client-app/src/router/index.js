import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'
import Posts from '../views/Posts.vue'
import AllPosts from '../components/Posts/AllPosts.vue'
import PostDetails from '../components/Posts/Details.vue'
import CreatePost from '../components/Posts/Create.vue'
import UpdatePost from '../components/Posts/Update.vue'
import Characters from '../views/Characters.vue'

Vue.use(VueRouter)

const routes = [
  
  {
    path: '/',
    name: 'home',
    component: Home
  },
  {
    path: '/post',
    name: 'post',
    component: Posts,
    children:[
      {
        path: 'all',
        name: 'allPosts',
        component: AllPosts,
      },
      {
        path: 'create',
        name: 'createPost',
        component: CreatePost,
      },
      {
        path: 'update',
        name: 'UpdatePost',
        component: UpdatePost,
      },
      {
        path: ':id',
        name: 'postDetails',
        component: PostDetails,
      },    
    ]
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
