<template>
  <div class="row">
    <div class="col-sm-3"></div>
    <div class="col-sm-6">
      <div class="container">
        <main role="main" class="pb-3">
          <div class="row">
            <div class="col-md-12">
              <v-form @submit.prevent="create" enctype="multipart/form-data">
                <div
                  asp-validation-summary="ModelOnly"
                  class="font-weight-bold"
                  style="color:#1dff39"
                ></div>
                <div class="form-group">
                  <label asp-for="Title" class="col-form-label"></label>
                  <input v-model="title" asp-for="Title" class="form-control" />
                  <span asp-validation-for="Title" class="font-weight-bold" style="color:#1dff39"></span>
                </div>
                <div class="form-group">
                  <label asp-for="Description" class="col-form-label"></label>
                  <editor
                    v-model="description"
                    api-key="no-api-key"
                    :init="{
                        height: 500,
                        menubar: false,
                        plugins: [
                        'advlist autolink lists link image charmap print preview anchor',
                        'searchreplace visualblocks code fullscreen',
                        'insertdatetime media table paste code help wordcount'
                        ],
                        toolbar:
                        'undo redo | formatselect | bold italic backcolor | \
                        alignleft aligncenter alignright alignjustify | \
                        bullist numlist outdent indent | removeformat | help'
                    }"
                  />
                  <span
                    asp-validation-for="Description"
                    class="font-weight-bold"
                    style="color:#1dff39"
                  ></span>
                </div>
                <div class="form-group">
                  <label asp-for="Image" class="col-form-label"></label>
                  <input
                    type="file"
                    id="file"
                    ref="file"
                    @change="handleFileUpload"
                    class="form-control"
                  />
                  <span asp-validation-for="Image" class="font-weight-bold" style="color:#1dff39"></span>
                </div>
                <div class="form-group">
                  <input type="submit" id="submit-button" value="Create" class="btn btn-primary" />
                </div>
              </v-form>
            </div>
          </div>
        </main>
      </div>
    </div>
    <div class="col-sm-3"></div>
  </div>
</template>

<script>
import axios from "axios";
import Editor from "@tinymce/tinymce-vue";

export default {
  name: "newsCreate",
  components: {
    editor: Editor
  },
  data: () => ({
    title: "",
    description: "",
    image: ""
  }),
  computed: {},
  methods: {
    handleFileUpload() {
      this.image = this.$refs.file.files[0];
      console.dir(this.image);
    },
    create() {
      let formData = new FormData();
      formData.append("Title", this.title);
      formData.append("Description", this.description);
      formData.append("Image", this.image);
        
      axios
        .post(this.$localAPI + "/api/news/", 
        formData, {
          headers: {
            "Content-Type": "multipart/form-data"
          }
        })
        .then(response => {
          console.dir(response);
        })
        .catch(error => {
          console.dir(error);
        });
    }
  },
  filters: {},
  created() {}
};
</script>

<style scoped>
</style>