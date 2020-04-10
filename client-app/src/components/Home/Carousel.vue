<template>
  <div class="row">
    <div class="col-sm-3"></div>
    <div class="col-sm-6">
      <div class="container">
        <main role="main" class="pb-3">
          <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
            <ol class="carousel-indicators">
              <li
                v-for="(post,index) in allPosts.slice(0, 3)"
                :key="post.id"
                data-target="#carouselExampleIndicators"
                :data-slide-to="index"
                :class="{'active': index == 0}"
              ></li>
            </ol>
            <div class="carousel-inner">
              <div
                v-for="(post,index) in allPosts.slice(0, 3)"
                :key="post.id"
                :class="{'carousel-item': true, 'active': index == 0}"
              >
                <router-link
                  :to="{ name: 'postDetails', params: { id: post.id }}"
                >
                  <img class="d-block w-100" :src="'/img/' + post.image" alt="News" />
                  <div class="carousel-caption d-none d-md-block">
                    <span class="news-title">{{post.title}}</span>
                  </div>
                </router-link>
              </div>
            </div>
            <a
              class="carousel-control-prev"
              href="#carouselExampleIndicators"
              role="button"
              data-slide="prev"
            >
              <span class="carousel-control-prev-icon" aria-hidden="true"></span>
              <span class="sr-only">Previous</span>
            </a>
            <a
              class="carousel-control-next"
              href="#carouselExampleIndicators"
              role="button"
              data-slide="next"
            >
              <span class="carousel-control-next-icon" aria-hidden="true"></span>
              <span class="sr-only">Next</span>
            </a>
          </div>

          <div
            v-if="allPosts.length == 0"
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
import { ListPosts } from "../../store/Posts/helpers";

export default {
  name: "carousel",
  data: () => ({}),
  computed: {
    ...ListPosts
  },
  created() {
    this.$store
      .dispatch("allPosts")
      .then(() => {})
      .catch(err => {
        this.responseErrors = err.response.data.errors;
      });
  }
};
</script>

<style scoped>
.carousel-item {
  height: 400px;
}
</style>>