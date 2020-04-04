<template>
  <main role="main" class="pb-3">
    <div
      v-for="item in news"
      :key="item.id"
      class="row background-gray-dark border-primary border mb-2"
    >
      <div class="col-3">
        <img :src="require(`@/assets/img/${item.image}`)" style="max-width: 350px; width: 100%" alt />
      </div>
      <div class="col-9">
        <div class="row">
          <router-link
            class="news-title"
            :to="{ name: 'newsDetails', params: { id: item.id }}"
          >{{item.title}}</router-link>
          <br />
          <br />
          <span style="color: #ffd100">Posted On: {{item.PostedOn}}</span>
        </div>
      </div>
    </div>

    <div v-if="news.length == 0" class="text-warning text-center" style="font-size: 2em">No News</div>
  </main>
</template>

<script>
import axios from "axios";

export default {
  name: "newsDetails",
  components: {},
  data: () => ({
    news: []
  }),
  created() {
    axios.get("http://localhost:5000/api/news").then(response => {
      //console.dir(this.$store.user);
      this.news = response.data;
    });
  }
};
</script>

<style scoped>
/* .col-3 {
  padding: 0px !important;
} */
</style>