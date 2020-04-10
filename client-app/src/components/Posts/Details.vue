<template>
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
</template>

<script>
import axios from "axios";
import moment from "moment";
import { authenticatedComputed,baseURL } from "../../store/Authentication/helpers";

export default {
  name: "postDetails",
  components: {},
  data: () => ({
    id: "",
    title: "",
    description: "",
    postedOn: "",
    image: "",
    imgURL: "",
    postedBy: "",
  }),
  computed: {
    ...authenticatedComputed,
    ...baseURL
  },
  methods: {
    delete(id) {
      if (confirm("Do you really want to delete these news?")) {
        axios
          .delete(this.$localAPI+"/api/posts/" + id)
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
      .get(this.$localAPI+ "/api/post/" + this.$route.params.id)
      .then(response => {
        //console.dir(response.data);
        this.id = response.data.id;
        this.title = response.data.title;
        this.description = response.data.description;
        this.postedOn = response.data.postedOn;
        this.image = response.data.image;
        this.imgURL = `url(${'/img/' + this.image})`;
        this.postedBy = response.data.userId
      });
  }
};
</script>

<style scoped>
/* .col-3 {
  padding: 0px !important;
} */
</style>