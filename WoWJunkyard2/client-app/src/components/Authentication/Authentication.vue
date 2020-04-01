<template>
  <v-card
    class="mx-auto"
    max-width="300"
    :dark="true"
    tile>
    <AppLogin v-if="!loggedIn"/> 
    <AppRegister v-if="!loggedIn"/>   
    <p v-if="loggedIn">Welcome back!</p>   
  </v-card>
</template>

<script>
import AppRegister from './Register.vue'
import AppLogin from './Login.vue'
import {authenticatedComputed} from '../../store/helpers.js'

export default {
  name: 'authentication',
  components: {
    AppRegister,
    AppLogin
  },
  computed:{
    ...authenticatedComputed
  },
  data: () => ({

  }) 
}
</script>

<style scoped>
.v-list-item__title{
  line-height: 1.3 !important;
}
.v-list-item__icon{
  margin: 10px 0 !important;
}
.v-item-group{
  display:flex;
}
.v-card{
  float:right;
}
</style>