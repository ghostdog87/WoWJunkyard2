import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    user: null
  },
  mutations: {
    SET_USER_DATA(state,userData){
      state.user = userData;
      localStorage.setItem('user',JSON.stringify(userData));
      axios.defaults.headers.common['Authorization'] = `Bearer ${
        userData.token
      }`;
    }
  },
  actions: {
    register({ commit },credentials){
      return axios.post("http://localhost:5000/api/user/register", credentials)
      .then(({data}) => {
        commit('SET_USER_DATA', data);
      });              
    },
    login({ commit },credentials){
      return axios.post("http://localhost:5000/api/user/login", credentials)
      .then(({data}) => {
        commit('SET_USER_DATA', data);
      });              
    }
  },
  getters:{
    loggedIn(state){
      return !!state.user;
    }
  },
  modules: {
  }
})
