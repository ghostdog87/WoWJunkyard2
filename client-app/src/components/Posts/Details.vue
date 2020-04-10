<template>
  <main role="main" class="pb-3">
    <div class="row mb-2">
      <div v-if="loggedIn">
        <template v-if="id">
          <router-link  class="btn btn-danger" tag="button" :to="{ name: 'editPost', params: { id: id }}">Edit</router-link>
        </template>
        <button class="btn btn-danger" data-toggle="modal" data-target="#deleteModal">Delete</button>
        <div
          class="modal fade"
          id="deleteModal"
          tabindex="-1"
          role="dialog"
          aria-labelledby="exampleModalLabel"
          aria-hidden="true"
        >
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-body">Do you really want to delete this post?</div>
              <div class="modal-footer">
                <button type="button" @click="deletePost(id)" class="btn btn-primary" data-dismiss="modal">Delete post</button>
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>              
              </div>
            </div>
          </div>
        </div>
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

<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
<script>
import moment from "moment";
import {
  authenticatedComputed,
  baseURL
} from "../../store/Authentication/helpers";

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
    postedBy: ""
  }),
  computed: {
    ...authenticatedComputed,
    ...baseURL
  },
  methods: {
    deletePost(id) {
      
      this.$store
        .dispatch("deletePost", id)
        .then(() => {
          alert('Post was deleted!');
          this.$router.push({ name: "allPosts" });
        })
        .catch((err) => {
          alert('Post was not deleted! Something happen.' + err);
        });

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
    this.$store
      .dispatch("postDetails", this.$route.params.id)
      .then(response => {
        this.id = response.data.id;
        this.title = response.data.title;
        this.description = response.data.description;
        this.postedOn = response.data.postedOn;
        this.image = response.data.image;
        this.imgURL = `url(${"/img/" + this.image})`;
        this.postedBy = response.data.userId;
      })
      .catch(() => {});
  }
};
</script>

<style scoped>
</style>