<template>
  <v-card
    class="mx-auto"
    max-width="800"
    :dark="true"
    tile
  >
  <v-form v-model="valid">
    <v-container>
        <v-row
          cols="6"
          md="4"
        >
          <v-text-field
            v-model="firstname"
            :rules="nameRules"
            :counter="10"
            label="First name"
            required
          ></v-text-field>
        </v-row>

        <v-row
          cols="6"
          md="4"
        >
          <v-text-field
            v-model="lastname"
            :rules="nameRules"
            :counter="10"
            label="Last name"
            required
          ></v-text-field>
        </v-row>

        <v-row
          cols="6"
          md="4"
        >
          <v-text-field
            v-model="email"
            :rules="emailRules"
            label="E-mail"
            required
          ></v-text-field>
        </v-row>
        <v-row
          cols="6"
          md="4"
        >
          <v-btn @click="submit" class="btn btn-success mr-4">submit</v-btn>
        </v-row>
    </v-container>
  </v-form>
  </v-card>
</template>

<script>
  export default {
    data: () => ({
      valid: false,
      firstname: '',
      lastname: '',
      nameRules: [
        v => !!v || 'Name is required',
        v => v.length <= 10 || 'Name must be less than 10 characters',
      ],
      email: '',
      emailRules: [
        v => !!v || 'E-mail is required',
        v => /.+@.+/.test(v) || 'E-mail must be valid',
      ],
    }),
    methods:{
      submit () {
        //TODO
      },
    }
  }
</script>

<style scoped>
.v-card{
  float:none !important;
}
</style>