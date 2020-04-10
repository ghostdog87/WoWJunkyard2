import axios from "axios";

const posts = {
  state: {
    posts: []
  },
  mutations: {
    SET_POSTS_DATA(state, postsData) {
      state.posts = postsData;
    }
  },
  actions: {
    allPosts({ commit, rootState }) {
      commit("setLoading", true, { root: true });
      return axios.get(rootState.$localAPI + "/api/post").then(({ data }) => {
        commit("SET_POSTS_DATA", data);
        commit("setLoading", false, { root: true });
      });
    },
    createPost({ commit, rootState }, formData) {
      commit("setLoading", true, { root: true });
      return axios
        .post(rootState.$localAPI + "/api/post", formData, {
          headers: {
            "Content-Type": "multipart/form-data"
          }
        })
        .then(() => {})
        .catch(error => {
          console.dir(error);
        })
        .then(() => {
          commit("setLoading", false, { root: true });
        });
    },
    editPost({ commit, rootState },{id, formData}) {
      commit("setLoading", true, { root: true });
      return axios
        .put(rootState.$localAPI + "/api/post/" + id, formData, {
          headers: {
            "Content-Type": "multipart/form-data"
          }
        })
        .then(() => {})
        .catch(error => {
          commit("setLoading", false, { root: true });
          console.dir(error);
        })
        .then(() => {
          commit("setLoading", false, { root: true });
        });
    },
    postDetails({ commit, rootState }, id) {
      commit("setLoading", true, { root: true });
      return axios
        .get(rootState.$localAPI + "/api/post/" + id)
        .then((response) => {
          commit("setLoading", false, { root: true });
          return response;
        })
        .catch((err) => {
          commit("setLoading", false, { root: true });
          return err;
        });
    },
    deletePost({ commit, rootState }, id) {
      commit("setLoading", true, { root: true });
      return axios
        .delete(rootState.$localAPI + "/api/post/" + id)
        .then((response) => {
          commit("setLoading", false, { root: true });
          return response;
        })
        .catch((err) => {
          commit("setLoading", false, { root: true });
          return err;
        });
    }
  },
  getters: {
    allPosts(state) {
      return state.posts;
    }
  },
  modules: {}
};

export default posts;
