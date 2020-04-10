<template>
  <div>
    <div class="text-center">
      <span class="display-4" style="color: #ffcf16">Welcome to Junkyard</span>
    </div>
    <AppCarousel/>
  </div>
</template>

<script>
import AppCarousel from '../components/Home/Carousel';

  export default {
    name: 'home',
    components: {
      AppCarousel,
    },
    data: () => ({
      
    }),
  }
</script>
