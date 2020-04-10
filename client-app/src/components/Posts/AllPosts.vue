<template>
  <main role="main" class="pb-3">
    <div class="row mb-2" v-if="loggedIn">
      <router-link class="btn btn-info text-white" :to="{ name: 'createPost'}">Create Posts</router-link>
    </div>

    <div
      v-for="post in allPosts"
      :key="post.id"
      class="row background-gray-dark border-primary border mb-2"
    >
      <div class="col-3">
        <img :src="'/img/' + post.image" style="max-width: 350px; width: 100%" alt />
      </div>
      <div class="col-9">
        <div class="row">
          <router-link
            class="news-title"
            :to="{ name: 'postDetails', params: { id: post.id }}"
          >{{post.title}}</router-link>
          <br />
          <br />

          <div>
            <span class="posted col-6">Posted On: {{post.postedOn | formatDate}}</span>
            <span class="posted col-6">Posted by: {{post.displayName}}</span>
          </div>
        </div>
      </div>
    </div>

    <div v-if="allPosts.length == 0" class="text-warning text-center" style="font-size: 2em">No News</div>
  </main>
</template>

<script>
import moment from "moment";
import { authenticatedComputed } from "../../store/Authentication/helpers";
import { ListPosts } from "../../store/Posts/helpers";

export default {
  name: "allPosts",
  components: {},
  data: () => ({}),
  computed: {
    ...authenticatedComputed,
    ...ListPosts
  },
  filters: {
    formatDate(value) {
      if (value) {
        return moment(String(value)).format("MM/DD/YYYY hh:mm");
      }
    }
  },
  method: {},
  created() {
    this.$store
      .dispatch("allPosts")
      .then(() => {
      })
      .catch(err => {
        this.responseErrors = err.response.data.errors;
      });
  }
};
</script>

<style scoped>
.posted {
  color: #ffd100;
  font-weight: bold;
}
/* .col-3 {
  padding: 0px !important;
} */
</style>