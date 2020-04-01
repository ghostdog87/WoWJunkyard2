<template>
    <v-dialog v-model="dialog" persistent max-width="290">
      <template v-slot:activator="{ on }">
        <v-btn color="succes" dark v-on="on">Login</v-btn>
      </template>
      <v-form @submit.prevent="login">
        <v-card
        class="mx-auto"
        max-width="300"
        :dark="true"
        tile>
        <v-text-field
          v-model="email"
          label="E-mail"
          required
        ></v-text-field>
        <v-text-field
            v-model="password"
            :append-icon="showPassword ? 'mdi-eye' : 'mdi-eye-off'"
            :type="showPassword ? 'text' : 'password'"
            label="Password"
            @click:append="showPassword = !showPassword"
          ></v-text-field>

        <v-btn class="mr-4" color="succes" type="submit">Login</v-btn>
        <v-btn color="succes" @click="dialog = false; clear();">Close</v-btn>
        </v-card>
      </v-form>
    </v-dialog>
</template>


<script>
  export default {
    data: () => ({
      dialog: false,
      showPassword: false,
      email: "",
      password: "",
    }),
    computed: {
      
    },
    methods:{
      clear() {
        this.email = ''
        this.password = ''
      },
      login(){
        this.$store.dispatch('login',{
          email: this.email,
          password: this.password,
        })
        .then(() => {
          this.dialog = false;
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