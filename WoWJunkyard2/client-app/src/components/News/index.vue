<template>
  <div class="row">
    <div class="col-sm-3"></div>
    <div class="col-sm-6">
      <div class="container">
        <main role="main" class="pb-3">
          <div class="row mb-2" v-if="loggedIn">
            <router-link class="btn btn-info text-white" :to="{ name: 'newsCreate'}">Create New</router-link>
          </div>

          <div
            v-for="item in allNews"
            :key="item.id"
            class="row background-gray-dark border-primary border mb-2"
          >
            <div class="col-3">
              <img
                :src="'/img/' + item.image"
                style="max-width: 350px; width: 100%"
                alt
              />
            </div>
            <div class="col-9">
              <div class="row">
                <router-link
                  class="news-title"
                  :to="{ name: 'newsDetails', params: { id: item.id }}"
                >{{item.title}}</router-link>
                <br />
                <br />
                <span style="color: #ffd100">Posted On: {{item.postedOn | formatDate}}</span>
              </div>
            </div>
          </div>

          <div
            v-if="allNews == null"
            class="text-warning text-center"
            style="font-size: 2em"
          >No News</div>
        </main>
      </div>
    </div>
    <div class="col-sm-3"></div>
  </div>
</template>

<script>
import moment from "moment";
import { authenticatedComputed } from "../../store/Authentication/helpers";
import { getAllNews } from "../../store/News/helpers";

export default {
  name: "index",
  components: {},
  data: () => ({
  }),
  computed: {
    ...authenticatedComputed,
    ...getAllNews,
  },
  filters: {
    formatDate(value) {
      if (value) {
        return moment(String(value)).format("MM/DD/YYYY hh:mm");
      }
    }
  },
  method: {
  },
  created() {
    this.$store.dispatch('create')
        .then(() => {
        })
        .catch((err) => {
          this.responseErrors = err.response.data.errors;
        })
  }
};
</script>

<style scoped>
/* .col-3 {
  padding: 0px !important;
} */
</style>