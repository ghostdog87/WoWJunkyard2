<template>
  <v-app>
  <div id="app">
    
      <app-header/> 
        
        <main>
          <loading :active.sync="isLoading" 
        :can-cancel="false" 
        :is-full-page="false"
        :color="loadingColor"
        :opacity="0"
        class="vld-parent"
        ></loading>
          <router-view/>
          </main>
        
      <app-footer/>
    
  </div>
  </v-app>
</template>

<script>
import AppHeader from './components/Shared/Header';
import AppFooter from './components/Shared/Footer';
import Loading from 'vue-loading-overlay';
import 'vue-loading-overlay/dist/vue-loading.css';
import { loadingComputed } from "../src/store/Authentication/helpers";


export default {
  name: 'App',

  components: {
    AppHeader,
    AppFooter,
    Loading
  },

  computed:{
    ...loadingComputed,
  },
  data: () => ({
    size: '200px',   
    loadingColor: "#0f0",
  }),
};
</script>

<style>
.vld-parent{
  position: fixed;
}
main{
  margin-bottom:20px !important;
}
.footer-section{
  padding: 0px !important;
}
.v-application{
    background: none !important;
    background-image: url(`../img/zandalari-craft.jpg`) !important;
    background-repeat: no-repeat !important;
    background-attachment: fixed !important;
    background-size: cover !important;
}    
</style>
