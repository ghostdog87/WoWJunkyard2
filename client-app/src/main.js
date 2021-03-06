import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify';
import './assets/css/style.css';
import './assets/css/bootstrap.min.css';
import 'bootstrap';
import axios from 'axios'

Vue.config.productionTip = false,

new Vue({
  router,
  store,
  vuetify,
  created(){
    const userString = localStorage.getItem('user');
    if(userString){
      const userData = JSON.parse(userString);
      this.$store.commit('SET_USER_DATA',userData);
    }
    // TODO: Properly intercepting errors and unauthorized access in future with axios interceptors

    axios.interceptors.response.use(
      response => response,
      error => {
        if(error.response.status === "401"){
          this.$store.dispatch("logout");
        }
        return Promise.reject(error.response);
      }
    );
  },
  render: h => h(App)
}).$mount('#app')
