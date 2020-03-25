import Vue from 'vue'
import Vuex from 'vuex'
import axios from 'axios'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {

  },
  mutations: {
  },
  actions: {
    async register({ commit },credentials){
      try {
        const response = await axios.post("http://localhost:5000/api/user/register", credentials)
        console.dir(response)
        commit('SET_USER_DATA', response.data)
      }
      catch (error) {
        console.dir(error.response)
      }             
    } 
  },
  modules: {
  }
})
