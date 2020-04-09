import Vue from 'vue'
import Vuex from 'vuex'
import auth from './Authentication/auth'
import news from './News/news'


Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    isLoading: false,
    $localAPI: 'http://localhost:5000',
  },
  mutations: {
    setLoading(state,value){
      state.isLoading = value;
    }
  },
  actions: {
  },
  getters:{
    isLoading(state){
      return state.isLoading;
    },
  },
    modules: {
      auth,
      news,
    }
})