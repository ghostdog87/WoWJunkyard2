<template>
  <v-card
    class="mx-auto"
    max-width="300"
    :dark="true"
    tile
  >
        <div
          v-for="(item, i) in items"
          :key="i"
          style="display:inline-block;"
        >
          <router-link :to="item.router" style="display:flex" class="btn btn-success" role="button">
          <v-list-item-icon>
            <v-icon v-text="item.icon"></v-icon>
          </v-list-item-icon>          
          <v-list-item-content>                  
              <v-list-item-title v-text="item.text">     
              </v-list-item-title>                     
          </v-list-item-content>
          </router-link>
        </div>  

  </v-card>
</template>

<script>
  export default {
    name: 'authentication',
    components: {

    },
    data: () => ({
      item: 1,
      items: [
        { text: 'Login', icon: 'mdi-account', router: '/login'},
        { text: 'Register', icon: 'mdi-account', router: '/register' },
      ]
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