<template>
  <v-card class="mx-auto" :dark="true" tile>
    <AppLogin v-if="!loggedIn" />
    <AppRegister v-if="!loggedIn" />
    <div v-if="loggedIn" class="row welcomeContainer">
      <div class="welcomeMsg align-middle">Welcome back, {{loggedInUser}}!</div>
      <v-btn class="align-middle" color="succes" @click="logout">Logout</v-btn>
    </div>
  </v-card>
</template>

<script>
import AppRegister from "./Register.vue";
import AppLogin from "./Login.vue";
import { authenticatedComputed,usernameComputed } from "../../store/Authentication/helpers";

export default {
  name: "authentication",
  components: {
    AppRegister,
    AppLogin
  },
  computed: {
    ...authenticatedComputed,
    ...usernameComputed
  },
  methods: {
    logout() {
      this.$store.dispatch("logout");
    },
  },
  data: () => ({
    
  }),

};
</script>

<style scoped>
.welcomeContainer{
  display:contents;
}
.welcomeMsg{
  display:inline-block;
  padding:10px;
}
.v-list-item__title {
  line-height: 1.3 !important;
}
.v-list-item__icon {
  margin: 10px 0 !important;
}
.v-item-group {
  display: flex;
}
.v-card {
  float: right;
}
</style>