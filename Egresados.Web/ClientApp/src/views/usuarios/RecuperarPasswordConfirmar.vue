<template>
  <v-row class="mt-n16">
    <v-col
      cols="12"
      lg="7"
      xl="6"
      class="d-none d-md-flex align-center justify-center"
    >
      <v-container>
        <div class="pa-10">
          <v-row justify="end">
            <v-col
              cols="8"
              xl="6"
            >
              <div class="mt-n16 mb-4">
                <v-img
                  lazy-src="@/assets/images/logos/logo.png"
                  max-height="auto"
                  max-width="auto"
                  src="@/assets/images/logos/logo.png"
                />
              </div>
            </v-col>
          </v-row>
        </div>
      </v-container>
    </v-col>
    <v-col class="d-flex align-center">
      <v-container>
        <div class="pa-7 pa-sm-12">
          <v-row>
            <v-col
              cols="12"
              lg="9"
              xl="8"
            >
              <!--<img src="@/assets/images/logo-icon.png" />-->
              <h2 class="font-weight-bold  blue-grey--text text--darken-2 text-center">
                Nueva Clave
              </h2>
              <!--<h6 class="subtitle-1">
                              Don't have an account?
                              <a href="#/pages/fullregister" class>Sign Up</a>
                            </h6>-->
              <v-form
                ref="form"
                v-model="valid"
                lazy-validation
              >
                <v-text-field
                  v-model="form.email"
                  :rules="emailRules"
                  label="E-mail"
                  class="mt-4"
                  required
                  outlined
                />
                <v-text-field
                  v-model="form.password"
                  :rules="passwordRules"
                  label="Clave"
                  required
                  outlined
                  :type="'password'"
                />
                <v-text-field
                  v-model="form.confirmPassword"
                  :rules="recuperarPasswordRules"
                  label="Clave"
                  required
                  outlined
                  :type="'password'"
                />
                <v-btn
                  :disabled="!valid"
                  rounded
                  color="#691a5c"
                  block
                  class="mr-4 white--text"
                  submit
                  @click="submit"
                >
                  Enviar
                </v-btn>
              </v-form>
            </v-col>
          </v-row>
        </div>
      </v-container>
    </v-col>
  </v-row>
</template>

<script>
  import UsuarioServices from '../../services/UsuarioServices'
  export default {
    name: 'RecuperarPassword',
    data: () => ({
      valid: true,
      form: {},
      checkbox: false,
      emailRules: [
        v => !!v || 'Este campo es requerido',
        v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
      ],
      recuperarPasswordRules: [
        v => !!v || 'Este campo es requerido',
      ],
      passwordRules: [
        v => !!v || 'Este campo es requerido',
      ],
      usuarioServices: null,
    }),
    created () {
      this.usuarioServices = new UsuarioServices()
    },
    methods: {
      showSuccess (message) {
        this.$toastr.Add({
          name: 'UniqueToastName', // this is give you ability to use removeByName method
          title: 'Success Message', // Toast Title
          msg: message,
          type: 'success',
        })
      },
      showError (message) {
        this.$toastr.Add({
          name: 'UniqueToastName', // this is give you ability to use removeByName method
          title: 'Error Message', // Toast Title
          msg: message,
          type: 'error',
        })
      },
      submit () {
        this.$refs.form.validate()
        if (this.$refs.form.validate(true)) {
          this.usuarioServices.recuperarPasswordConfirmar(this.form)
            .then(data => {
              this.$router.push({ path: '/Usuarios/Login' })
              console.log(data)
              // localStorage.setItem("access_user", JSON.stringify(data));
              this.showSuccess('La clave ha sido actualizada')
              this.form = {}
            })
            .catch(error => {
              if (error.response.status === 401) {
                this.showError('El mail o password es invalido.')
              } else {
                this.showError(error.response.data.title)
              }
              console.log(error.response.status)
            })
        }
      },
    },
  }
</script>
