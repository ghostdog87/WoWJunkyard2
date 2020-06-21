<template>
  <div class="row">
    <div class="col-sm-3"></div>
    <div class="col-sm-6">
      <div class="container">     
          <router-view/>
      </div>
    </div>
    <div class="col-sm-3"></div>
  </div>
</template>

<script>
  export default {
    name: 'characters',
    components: {

    },
    data: () => ({
      
    }),
  }
</script>