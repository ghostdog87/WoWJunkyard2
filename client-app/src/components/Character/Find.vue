<template>
  <main role="main" class="pb-3">
    <v-form @submit.prevent="searchCharacter">
      <div class="form-row">
        <div class="form-group col-auto">
          <select v-model="realmName" class="form-control form-control-sm">
            <option disabled value>Please select realm</option>
            <option v-for="(realm,index) in realmList" :key="index" :value="realm">{{realm}}</option>
          </select>
        </div>
        <div class="form-group col-auto">
          <input
            type="text"
            v-model="characterName"
            class="form-control form-control-sm"
            value="characterName"
            id="name"
            placeholder="Character"
          />
        </div>
        <div class="form-group col-auto">
          <input type="submit" value="Search" class="btn btn-warning mx-auto btn-sm" />
        </div>
      </div>
    </v-form>
    <CharactersList />
  </main>
</template>

<script>
import CharactersList from "./List.vue";
import RealmList from "../../utilities/RealmList.json";

export default {
  name: "findCharacter",
  components: {
    CharactersList
  },
  data: () => ({
    realmName: "",
    characterName: "",
    realmList: RealmList
  }),
  computed: {},
  filters: {},
  methods: {
    searchCharacter() {
      let formData = new FormData();
      formData.append("characterName", this.characterName);
      formData.append("realmName", this.realmName);

      this.$store
        .dispatch("searchCharacter", formData)
        .then(response => {
          console.dir(response);
        })
        .catch(err => {
          console.dir(err);
        });
    }
  },
  created() {}
};
</script>

<style scoped>
</style>