<template>
  <v-app>
  <div id="app">
    
      <app-header/> 
        <main><router-view/></main>
      <app-footer/>
    
  </div>
  </v-app>
</template>

<script>
import AppHeader from './components/Shared/Header';
import AppFooter from './components/Shared/Footer';

export default {
  name: 'App',

  components: {
    AppHeader,
    AppFooter
  },

  data: () => ({
    //
  }),
};
</script>

<style>
.v-application{
    background: none !important;
    background-image: url(`../img/zandalari-craft.jpg`) !important;
    background-repeat: no-repeat !important;
    background-attachment: fixed !important;
    background-size: cover !important;
}    
</style>
