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
                Bienvenido!
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
                  v-model="form.cedula"
                  label="Cédula"
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
                  :append-icon="inputPassword ? 'mdi-eye-off' : 'mdi-eye'"
                  :type="inputPassword ? 'password' : 'text'"
                  @click:append="() => (inputPassword = !inputPassword)"
                />

                <div class="d-block d-sm-flex align-center mb-4 mb-sm-0">
                  <v-checkbox
                    v-model="checkbox"
                    label="Mantenerse conectado"
                  />
                  <div class="ml-auto">
                    <a
                      href="javascript:void(0)"
                      class="link"
                      @click="RecuperarPassword()"
                    >Olvidaste tu clave?</a>
                  </div>
                </div>

                <v-btn
                  :disabled="!valid"
                  rounded
                  color="#691a5c"
                  block
                  class="mr-4 white--text"
                  submit
                  @click="submit"
                >
                  Iniciar Sesion
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
    name: 'Login',
    data: () => ({
      valid: true,
      form: {
        cedula: '6-719-1951',
        password: 'Admin1234',
      },
      checkbox: false,
      inputPassword: String,
      passwordRules: [
        v => !!v || 'Este campo es requerido',
      ],
      emailRules: [
        v => !!v || 'Este campo es requerido',
        v => /.+@.+\..+/.test(v) || 'E-mail must be valid',
      ],
      usuarioServices: null,
    }),
    created () {
      this.usuarioServices = new UsuarioServices()
    },
    methods: {
      showSuccess (message) {
        this.$swal({
          titleText: 'Correcto!',
          text: message,
          icon: 'succes',
          confirmButtonText: 'Aceptar',
        })
      },
      showError (message) {
        this.$swal({
          titleText: 'Error!',
          text: message,
          icon: 'error',
          confirmButtonText: 'Aceptar',
        })
      },
      submit () {
        this.$refs.form.validate()
        if (this.$refs.form.validate(true)) {
          this.usuarioServices.login(this.form)
            .then(data => {
              this.$router.push({ path: '/Dashboard' })

              localStorage.setItem('access_user', JSON.stringify(data))
              this.showSuccess('Entro al sistema correctamente.')
              // this.form = {};
            })
            .catch(error => {
              if (error.response.status === 401) {
                this.showError('Contraseña o cédula incorrectas')
              } else {
                this.showError(error.response.data.title)
              }

              console.log(error.response.status)
            })
        }
      },
      RecuperarPassword: function () {
        this.$router.push('/Usuarios/RecuperarPassword')
      },
    },
  }
</script>
