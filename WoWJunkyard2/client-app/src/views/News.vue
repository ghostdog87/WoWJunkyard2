<template>
  <div class="row">
    <div class="col-sm-3"></div>
    <div class="col-sm-6">
      <div class="container">
        <AppIndex />
      </div>
    </div>
    <div class="col-sm-3"></div>
  </div>
</template>

<script>
import AppIndex from "../components/News/index.vue";

export default {
  name: "news",
  components: {
    AppIndex
  },
  data: () => ({})
};
</script>