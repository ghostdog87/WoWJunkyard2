import axios from "axios";

const characters = {
  state: {
  },
  mutations: {
  },
  actions: {
    searchCharacter({ commit, rootState }, characterData) {
      commit("setLoading", true, { root: true });
      return axios
        .post(rootState.$localAPI + "/api/character",characterData)
        .then((response) => {
          commit("setLoading", false, { root: true });
          return response;
        })
        .catch((err) => {
          commit("setLoading", false, { root: true });
          return err;
        });
    },
  },
  getters: {
    
  },
  modules: {}
};

export default characters;
