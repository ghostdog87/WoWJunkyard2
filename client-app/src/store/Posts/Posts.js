import axios from 'axios'

const posts = {
  state: {
    posts: [],
  },
  mutations: {
    SET_POSTS_DATA(state,postsData){
      state.posts = postsData;
    },
  },
  actions: {
    allPosts({commit,rootState }){
      commit('setLoading',true,{ root: true });      
      return axios.get(rootState.$localAPI + "/api/post")
      .then(({data}) => {
        commit('SET_POSTS_DATA', data);
        commit('setLoading',false,{ root: true }); 
      });           
    },
  },
  getters:{
      allPosts(state){
        return state.posts;
      }
  },
  modules: {
  }
}

export default posts;
