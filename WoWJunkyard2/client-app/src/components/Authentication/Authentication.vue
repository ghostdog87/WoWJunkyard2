<template>
  <v-card
    class="mx-auto"
    max-width="300"
    :dark="true"
    tile
  >
    <v-list dense >
      <v-list-item-group v-model="item" color="primary">
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
        >
          <v-list-item-icon>
            <v-icon v-text="item.icon"></v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title v-text="item.text" @click="showModal(item.text)"></v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list-item-group>
    </v-list>
    <AppRegister v-if="isRegisterModalOpen"></AppRegister>
  </v-card>
  
</template>

<script>
import AppRegister from './Register.vue';

  export default {
    name: 'authentication',
    components: {
      AppRegister,
    },
    data: () => ({
      item: 1,
      items: [
        { text: 'Login', icon: 'mdi-account' },
        { text: 'Register', icon: 'mdi-account' },
      ]
    })
  }
</script>

<style scope>
.v-item-group{
  display:flex;
}
.v-card{
  float:right;
}
</style>