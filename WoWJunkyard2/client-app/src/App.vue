<template>
  <div id="app">
    <app-header/> 
    <main><router-view/></main>
    <app-footer/>
  </div>
</template>

<script>
import AppHeader from './components/Shared/Header';
import AppFooter from './components/Shared/Footer';

export default {
  name: 'App',

  components: {
    AppHeader,
    AppFooter
  },

  data: () => ({
    //
  }),
};
</script>
