<template>
    <v-dialog v-model="dialog" persistent max-width="290">
      <template v-slot:activator="{ on }">
        <v-btn color="succes" dark v-on="on">Register</v-btn>
      </template>
      <v-form @submit.prevent="register">
        <v-card
        class="mx-auto"
        max-width="300"
        :dark="true"
        tile>
        <v-text-field
          v-model="email"
          :error-messages="emailErrors"
          label="E-mail"
          required
          @input="$v.email.$touch()"
          @blur="$v.email.$touch()"
        ></v-text-field>
        <v-text-field
          v-model="username"
          :error-messages="usernameErrors"
          label="Username"
          required
          @input="$v.username.$touch()"
          @blur="$v.username.$touch()"
        ></v-text-field>
        <v-text-field
          v-model="displayName"
          :error-messages="displayNameErrors"
          label="Display name"
          required
          @input="$v.displayName.$touch()"
          @blur="$v.displayName.$touch()"
        ></v-text-field>
        <v-text-field
            v-model="password"
            :error-messages="passwordErrors"
            :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
            :type="showPassword ? 'text' : 'password'"
            label="Password"
            @click:append="showPassword = !showPassword"
            @input="$v.password.$touch()"
            @blur="$v.password.$touch()"
          ></v-text-field>

        <v-btn class="mr-4" color="succes" type="submit" @click="submit" :disabled="$v.$invalid">Create</v-btn>
        <v-btn color="succes" @click="dialog = false; clear();">Close</v-btn>
        </v-card>
      </v-form>
    </v-dialog>
</template>


<script>
  import { validationMixin } from 'vuelidate'
  import { required, maxLength,minLength, email } from 'vuelidate/lib/validators'

  export default {
    mixins: [validationMixin],
    validations: {
      email: { required, email },
      username: { required, maxLength: maxLength(10) },
      displayName: { required, maxLength: maxLength(10) },
      password: { 
        required,
        minLength: minLength(6),
        strongPassword(password) {
          return (
            /[a-z]/.test(password) && // checks for upper character
            /[0-9]/.test(password) && // checks for 0-9
            /\W|_/.test(password) // checks for special character
          );
        }
      },
    },
    data: () => ({
      dialog: false,
      showPassword: false,
      email: "",
      username: "",
      displayName: "",
      password: "",
    }),
    computed: {
      emailErrors() {
        const errors = []
        if (!this.$v.email.$dirty) return errors
        !this.$v.email.email && errors.push('Must be valid e-mail')
        !this.$v.email.required && errors.push('E-mail is required')
        return errors
      },
      usernameErrors() {
        const errors = []
        if (!this.$v.username.$dirty) return errors
        !this.$v.username.maxLength && errors.push('Name must be at most 10 characters long')
        !this.$v.username.required && errors.push('Name is required.')
        return errors
      },
      displayNameErrors() {
        const errors = []
        if (!this.$v.displayName.$dirty) return errors
        !this.$v.displayName.maxLength && errors.push('Display name must be at most 10 characters long')
        !this.$v.displayName.required && errors.push('Display name is required.')
        return errors
      },
      passwordErrors() {
        const errors = []
        if (!this.$v.password.$dirty) return errors
        !this.$v.password.minLength && errors.push('Password must be at least 6 characters long');
        !this.$v.password.required && errors.push('Password is required.');
        !this.$v.password.strongPassword && errors.push('Strong passwords must have an upper letter, a number and a special character');
        return errors
      },
      // submitErrors() {
      //   const errors = []
      //   if (!this.isSubmitValid) return errors
      //   !this.isSubmitValid && errors.push('Enter valid data!');
      //   return errors
      // },
    },
    methods:{
      submit () {
        this.$v.$touch()
      },
      clear() {
        this.$v.$reset()
        this.email = ''
        this.username = ''
        this.displayName = ''
        this.password = ''
      },
      register(){
        this.$store.dispatch('register',{
          email: this.email,
          username: this.username,
          displayName: this.displayName,
          password: this.password,
        })
      }
    },
  }
</script>

<style scoped>
.v-application{
  padding:5% !important;
}
.v-card{
  float:none !important;
  padding:5% !important;
}
.container{
  padding:5%;
}
</style>