import axios from 'axios'

const news = {
  state: {
    news: null,
  },
  mutations: {
    SET_NEWS_DATA(state,newsData){
      state.news = newsData;
    },
  },
  actions: {
    create({commit,rootState }){
      commit('setLoading',true,{ root: true });      
      return axios.get(rootState.$localAPI + "/api/news")
      .then(({data}) => {
        commit('SET_NEWS_DATA', data);
        commit('setLoading',false,{ root: true }); 
      });           
    },
  },
  getters:{
      allNews(state){
        return state.news;
      }
  },
  modules: {
  }
}

export default news;
