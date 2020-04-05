<template>
  <div class="row">
    <div class="col-sm-3"></div>
    <div class="col-sm-6">
      <div class="container">
        <main role="main" class="pb-3">
          <div class="row mb-2">
            <div v-if="loggedIn">
              <router-link class="btn btn-danger" :to="{ name: 'newsEdit', params: { id: id }}">Edit</router-link>
              <button class="btn btn-danger" @click="deleteNews(id)">Delete</button>
            </div>
          </div>

          <div class="row news-details">
            <div class="col-sm-12 guide-header" :style="{ backgroundImage: imgURL }">
              <div class="col-sm-6 text-white font-weight-bold news-text-title">{{title}}</div>
              <div class="col-sm-6">
                <span
                  class="align-middle text-justify text-light"
                  style="display: table-cell;"
                >Posted on : {{postedOn | formatDate}}</span>
              </div>
            </div>

            <div class="col-sm-12 news-text" v-html="description"></div>
          </div>
        </main>
      </div>
    </div>
    <div class="col-sm-3"></div>
  </div>
</template>

<script>
import axios from "axios";
import moment from "moment";
import { authenticatedComputed } from "../../store/helpers.js";

export default {
  name: "newsDetails",
  components: {},
  data: () => ({
    id: "",
    title: "",
    description: "",
    postedOn: "",
    image: "",
    imgURL: ""
  }),
  computed: {
    ...authenticatedComputed
  },
  methods: {
    deleteNews(id) {
      if (confirm("Do you really want to delete these news?")) {
        axios
          .delete(this.$localAPI+"/api/artist/" + id)
          .then(resp => {
            console.dir(resp);
          })
          .catch(error => {
            console.dir(error);
          });
      }
    }
  },
  filters: {
    formatDate(value) {
      if (value) {
        return moment(String(value)).format("MM/DD/YYYY hh:mm");
      }
    }
  },
  created() {
    axios
      .get(this.$localAPI+ "/api/news/" + this.$route.params.id)
      .then(response => {
        //console.dir(response.data);
        this.id = response.data.id;
        this.title = response.data.title;
        this.description = response.data.description;
        this.postedOn = response.data.postedOn;
        this.image = response.data.image;
        this.imgURL = `url(${require("@/assets/img/" + this.image)})`;
      });
  }
};
</script>

<style scoped>
/* .col-3 {
  padding: 0px !important;
} */
</style>