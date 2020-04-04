<template>
  <main role="main" class="pb-3">
    <div class="row mb-2" v-if="loggedIn">
      <a asp-action="Create" class="btn btn-info text-white">Create New</a>
    </div>

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
          <span style="color: #ffd100">Posted On: {{item.postedOn | formatDate}}</span>
        </div>
      </div>
    </div>

    <div v-if="news.length == 0" class="text-warning text-center" style="font-size: 2em">No News</div>
  </main>
</template>

<script>
import axios from "axios";
import moment from 'moment'
import {authenticatedComputed} from '../../store/helpers.js'


export default {
  name: "index",
  components: {},
  data: () => ({
    news: []
  }),
  computed:{
    ...authenticatedComputed,
    
  },
  filters:{
    formatDate(value) {
      if (value) {
        return moment(String(value)).format('MM/DD/YYYY hh:mm')
      }
    }
  },
  created() {
    axios.get("http://localhost:5000/api/news").then(response => {
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