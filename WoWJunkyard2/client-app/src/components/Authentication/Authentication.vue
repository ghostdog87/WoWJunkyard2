<template>
  <v-card
    class="mx-auto"
    max-width="300"
    :dark="true"
    tile>
    <AppLogin/> 
    <AppRegister/>      
  </v-card>
</template>

<script>
import AppRegister from './Register.vue'
import AppLogin from './Login.vue'

export default {
  name: 'authentication',
  components: {
    AppRegister,
    AppLogin
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