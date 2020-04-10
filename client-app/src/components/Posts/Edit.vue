<template>
  <main role="main" class="pb-3">
    <div class="row">
      <div class="col-md-12">
        <v-form @submit.prevent="submit" enctype="multipart/form-data">
          <div class="form-group" :class="{ 'form-group--error': $v.title.$error }">
            <label class="col-form-label text-light" for="Title">Title</label>
            <input
              v-model="title"
              name="Title"
              class="form-control"
              @input="$v.title.$touch()"
              @blur="$v.title.$touch()"
            />
            <p class="error" v-if="!$v.title.required">Title is required field.</p>
            <p class="error" v-if="!$v.title.minLength">Title must be at least 6 characters long.</p>
            <p class="error" v-if="!$v.title.maxLength">Title must be at most 80 characters long.</p>
          </div>
          <div class="form-group" :class="{ 'form-group--error': $v.description.$error }">
            <label for="Description" class="col-form-label text-light">Description</label>
            <editor
              v-model="description"
              api-key="no-api-key"
              name="Description"
              @input="$v.description.$touch()"
              @blur="$v.description.$touch()"
              :init="{
                        height: 500,
                        menubar: 'file edit format tools',
                        plugins: [
                        'advlist autolink lists link image charmap print preview anchor',
                        'searchreplace visualblocks code fullscreen',
                        'insertdatetime media table paste code help wordcount'
                        ],
                        toolbar:
                        'undo redo | formatselect | bold italic backcolor | \
                        alignleft aligncenter alignright alignjustify | \
                        bullist numlist outdent indent | removeformat | help',
                        selector: 'textarea',
                        
                    }"
            />
            <p class="error" v-if="!$v.description.required">Description is required field.</p>
            <p
              class="error"
              v-if="!$v.description.minLength"
            >Description must be at least 50 characters long.</p>
            <p
              class="error"
              v-if="!$v.description.maxLength"
            >Description must be at most 200000 characters long.</p>
          </div>
          <div class="form-group" :class="{ 'form-group--error': $v.image.$error }">
            <label for="Image" class="col-form-label text-light">Image upload</label>
            <input
              type="file"
              name="Image"
              id="file"
              ref="file"
              @change="handleFileUpload"
              accept="image/png, image/jpeg"
              class="form-control"
              @input="$v.image.$touch()"
              @blur="$v.image.$touch()"
            />
            <p class="error" v-if="!$v.image.required">Image is required.</p>
            <p
              class="error"
              v-if="!$v.image.image_type_validation"
            >Image must be of types jpeg or png!</p>
          </div>
          <div class="form-group">
            <input
              type="submit"
              id="submit-button"
              :disabled="$v.$invalid"
              value="Update"
              class="btn btn-primary"
            />
          </div>
        </v-form>
      </div>
    </div>
  </main>
</template>

<script>
import Editor from "@tinymce/tinymce-vue";
import { validationMixin } from "vuelidate";
import { required, maxLength, minLength } from "vuelidate/lib/validators";
import { baseURL } from "../../store/Authentication/helpers";
import { usernameComputed } from "../../store/Authentication/helpers";

const image_type_validation = value => {
  if (value["type"] === "image/jpeg" || value["type"] === "image/png") {
    return true;
  }
  return false;
};

export default {
  name: "editPost",
  mixins: [validationMixin],
  validations: {
    title: { required, minLength: minLength(6), maxLength: maxLength(80) },
    description: {
      required,
      minLength: minLength(50),
      maxLength: maxLength(200000)
    },
    image: { required,image_type_validation}
  },
  components: {
    editor: Editor
  },
  data: () => ({
    title: "",
    description: "",
    image: ""
  }),
  computed: {
    ...baseURL,
    ...usernameComputed
  },
  methods: {
    handleFileUpload() {
      this.image = this.$refs.file.files[0];
    },
    submit(event) {
      const file = this.$refs.file.files[0];

      if (!file) {
        event.preventDefault();
        return;
      }

      let formData = new FormData();
      formData.append("Title", this.title);
      formData.append("Description", this.description);
      formData.append("Image", this.image);

      this.$store
        .dispatch("editPost", {id: this.$route.params.id,formData: formData})
        .then(() => {
          this.$router.push({ name: "allPosts" });
        })
        .catch(err => {
          this.responseErrors = err.response.data.errors;
        });
    }
  },
  filters: {},
  created() {
    this.$store
      .dispatch("postDetails", this.$route.params.id)
      .then(response => {
        this.title = response.data.title;
        this.description = response.data.description;
      })
      .catch(() => {});
  }
};
</script>

<style scoped>
p.error {
  color: red !important;
  background-color: transparent !important;
  font-weight: bold !important;
}
</style>