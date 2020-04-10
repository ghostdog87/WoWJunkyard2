import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

const auth = {
  state: {
    user: null,
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
  },
  actions: {
    register({ commit },credentials){
      commit('setLoading',true,{ root: true }); 
      return axios.post(this.state.$localAPI + "/api/user/register", credentials)
      .then(({data}) => {
        commit('SET_USER_DATA', data);        
      })
      .then(() => {
        commit('setLoading',false,{ root: true });
      });              
    },
    login({ commit },credentials){
      commit('setLoading',true,{ root: true }); 
      return axios.post(this.state.$localAPI + "/api/user/login", credentials)
      .then(({data}) => {
        commit('SET_USER_DATA', data);
        
        commit('setLoading',false,{ root: true });
      })
      .catch((err) => {
        commit('setLoading',false,{ root: true });
        return err;
      })          
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
    loggedInUserName(state){
      if(state.user !== null){
        if(typeof state.user === 'object'){
          return state.user.username;
        }
        return JSON.parse(state.user).username;
      }
      return "missing username";
    },
  },
  modules: {
  },
}

export default auth;
