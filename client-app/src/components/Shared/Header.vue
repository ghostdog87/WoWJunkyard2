<template>
    <header class="header-section">
      <div class="container">
            <router-link class="site-logo" to="/">
                <img :src="logo" alt="">
            </router-link>
            <AppAuthentication/>
            <nav class="navbar navbar-expand-lg navbar-dark bg-transparent">
              <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarTogglerDemo01" aria-controls="navbarTogglerDemo01" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
              </button>
              <div class="collapse navbar-collapse" id="navbarTogglerDemo01">
                <a class="navbar-brand" href="#" style="display:none;">Hidden brand</a>
                <ul class="navbar-nav mr-auto mt-2 mt-lg-0">
                    <li class="nav-item"><router-link class="nav-link" :to="{ name: 'home'}">Home</router-link></li>
                    <li class="nav-item"><router-link class="nav-link" :to="{ name: 'allPosts'}">News</router-link></li>
                    <li class="nav-item"><router-link class="nav-link" to="/characters">Characters</router-link></li>
                </ul>
              </div>  
            </nav>
            
        </div>
    </header>
</template>

<script>
import logoSrc from "@/assets/img/LogoMakr_26SJod_v2.png";
import AppAuthentication from "../Authentication/Authentication.vue";

export default {

  data() {
    return{
      logo: logoSrc,
    } 
  },
  components:{
    AppAuthentication
  },
};
</script>
