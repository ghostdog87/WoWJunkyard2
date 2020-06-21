<template>
    <footer class="footer-section">
      <div class="container">
        <ul class="footer-menu">
          <li><router-link class="site-logo" :to="{ name: 'home'}">Home</router-link></li>
          <li><router-link class="site-logo" :to="{ name: 'allPosts'}">News</router-link></li>
          <li><router-link class="site-logo" :to="{ name: 'findCharacter'}">Characters</router-link></li>
        </ul>
      </div>
    </footer>
</template>

<script>
export default {
  data: () => ({
    //
  }),
};
</script>
