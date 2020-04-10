<script>
//TODO: NOT WORKING FOR SOME REASON
var imageTypeValidationMixin = {
  methods: {
    image_type_validation(value) {
      if (value["type"] === "image/jpeg" || value["type"] === "image/png") {
        return true;
      }
      return false;
    }
  }
};
</script>