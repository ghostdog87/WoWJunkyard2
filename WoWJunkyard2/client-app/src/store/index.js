import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    user: null,
    isLoading: false,
    $localAPI: 'http://localhost:5000',
  },
  mutations: {
    SET_USER_DATA(state,userData){
      state.user = userData;
      localStorage.setItem('user',JSON.stringify(userData));
      axios.defaults.headers.common['Authorization'] = `Bearer ${
        userData.token
      }`;
    },
    CLEAR_USER_DATA(){
      localStorage.removeItem('user');
      location.reload();
    },
    setLoading(state,value){
      state.isLoading = value;
    }
  },
  actions: {
    register({ commit },credentials){
      return axios.post(this.state.$localAPI + "/api/user/register", credentials)
      .then(({data}) => {
        commit('SET_USER_DATA', data);
      });              
    },
    login({ commit },credentials){
      return axios.post(this.state.$localAPI + "/api/user/login", credentials)
      .then(({data}) => {
        commit('SET_USER_DATA', data);
      });              
    },
    logout({commit}){
      commit('CLEAR_USER_DATA');
    },
  },
  getters:{
    loggedIn(state){
      return !!state.user;
    },
    loggedInUser(state){
      if(state.user !== null){
        if(typeof state.user === 'object'){
          return state.user.displayName;
        }
        return JSON.parse(state.user).displayName;
      }
      return "missing username";
    },
    isLoading(state){
      return state.isLoading;
    },
  },
  modules: {
  }
})
