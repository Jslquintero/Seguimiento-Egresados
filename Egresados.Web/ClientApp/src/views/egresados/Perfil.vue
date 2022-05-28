<template>
  <v-container
    id="user-profile"
    fluid
    tag="section"
    class="mx-3 my-5"
  >
    <v-row justify="center">
      <v-col
        cols="12"
        md="4"
      >
        <base-material-card
          class="v-card-profile"
          :avatar="`${avatarUrl}`"
        >
          <v-card-text class="text-left">
            <h4 class="text-h3 font-weight-light mb-3 black--text text-center">
              {{ this.user.name }} {{ this.user.lastName }}
            </h4>
            <h6 class="text-h3 mb-1 grey--text text-center">
              Datos Empresariales
            </h6>
            <v-divider />
            <v-divider />
            <p />
            <p class="text-h4 mb-1 grey--text text-left">
              <v-icon
                title="Empresa"
                class="mr-2"
              >
                mdi-domain
              </v-icon>
              Empresa: {{ this.form.empresa }}
            </p>
            <p class="text-h4 mb-1 grey--text text-left">
              <v-icon
                title="Dirección"
                class="mr-2"
              >
                mdi-map-marker
              </v-icon>
              Dirección: {{ this.form.direccion }}
            </p>
            <p />
            <h6 class="text-h3 mb-1 grey--text text-center">
              Contacto
            </h6>
            <v-divider />
            <v-divider />
            <p />
            <p class="text-h4 mb-1 grey--text text-left">
              <v-icon
                title="Teléfono"
                class="mr-2"
              >
                mdi-phone
              </v-icon>
              Teléfono: {{ this.form.telefono }}
            </p>

            <p class="text-h4 mb-1 grey--text text-left">
              <v-icon
                title="Linkedin"
                class="mr-2"
              >
                mdi-linkedin
              </v-icon>
              Linkedin:
              <a
                style="text-decoration: none"
                :href="`https://www.linkedin.com/in/${this.form.linkedin}/`"
                target="_blank"
              >
                Visitar
              </a>
            </p>

            <p class="text-h4 mb-1 grey--text text-left">
              <v-icon
                title="Instagram"
                class="mr-2"
              >
                mdi-instagram
              </v-icon>
              Instagram:
              <a
                style="text-decoration: none"
                :href="`https://www.instagram.com/${this.form.instagram}`"
                target="_blank"
              >
                Visitar
              </a>
            </p>
            <p class="text-h3 mb-1 grey--text text-center">
              Acerca de mi
            </p>
            <v-divider />
            <v-divider />
            <p />
            <p class="text-h4 mb-1 grey--text text-left">
              <v-icon
                title="Linkedin"
                class="mr-2"
              >
                mdi-cake-variant
              </v-icon>
              Cumpleaños: {{ this.form.fechaString }}
            </p>

            <p class="text-h4 mb-1 grey--text text-left">
              <v-icon
                title="Linkedin"
                class="mr-2"
              >
                mdi-town-hall
              </v-icon>
              Facultad: {{ this.facultades.nombre }}
            </p>
            <p class="text-h4 mb-1 grey--text text-left">
              <v-icon
                title="Linkedin"
                class="mr-2"
              >
                mdi-earth
              </v-icon>
              Provincia de residencia: {{ this.provincias.nombre }}
            </p>
            <p />
            <p class="text-h3 mb-1 grey--text text-center">
              Bio
            </p>
            <v-divider />
            <v-divider />
            <p />
            <v-textarea
              name="input-7-1"
              readonly
              outlined
              no-resize
              :value="this.form.biografia"
            />

            <v-btn
              color="success"
              rounded
              class="mr-0"
            >
              Seguir
            </v-btn>
            <v-btn
              color="success"
              rounded
              class="mr-0"
              @click="editar()"
            >
              Editar
            </v-btn>
          </v-card-text>
        </base-material-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
  import UsuarioServices from '../../services/UsuarioServices.js'
  import PerfilServices from '../../services/PerfilServices'
  import FacultadServices from '../../services/FacultadServices'
  import ProvinciaServices from '../../services/ProvinciaServices'
  export default {
    name: 'Perfil',
    data () {
      return {
        form: {
          id: '',
          empresa: '',
          telefono: '',
          linkedin: '',
          instagram: '',
          biografia: '',
          fechaString: '',
          genero: '',
          provincia: '',
          provinciaId: '',
          facultad: '',
          facultadId: '',
          fechaAlta: '',
          usuarioId: '',
        },
        facultades: [],
        provincias: [],
        user: '',
        userId: '',
        avatarUrl: '',
      }
    },
    created () {
      this.perfilServices = new PerfilServices()
      this.usuarioServices = new UsuarioServices()
      this.facultadServices = new FacultadServices()
      this.provinciaServices = new ProvinciaServices()
      this.getUserStorage()
      this.getOneUsuario(this.userId)
    },
    mounted () {},
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

      getUserStorage () {
        this.user = JSON.parse(localStorage.getItem('access_user'))
        this.userId = this.user.id
        this.avatarUrl =
          'https://ui-avatars.com/api/?background=691a5c&color=fff&name=' +
          this.user.name +
          this.user.lastName +
          ''
      },
      getOneUsuario (id) {
        if (id !== '') {
          this.perfilServices
            .getOneUsuario(id)
            .then((data) => {
              this.form = data
              this.getOneFacultad(this.form.facultadId)
              this.getOneProvincia(this.form.provinciaId)

              if (data === '') {
                this.showError('No se encontró el usuario')
              }
            })
            .catch((error) => {
              this.showError(error.response.data.title)
              console.log(error.response.status)
            })
        }
      },
      getOneFacultad (id) {
        if (id > 0) {
          this.facultadServices
            .getOne(id)
            .then((data) => {
              this.facultades = data
            })
            .catch((error) => {
              this.showError(error.response.data.title)
              console.log(error.response.status)
            })
        }
      },
      getOneProvincia (id) {
        if (id > 0) {
          console.log(id)
          this.provinciaServices
            .getOne(id)
            .then((data) => {
              this.provincias = data
            })
            .catch((error) => {
              this.showError(error.response.data.title)
              console.log(error.response.status)
            })
        }
      },
      editar () {
        this.$router.push({ name: 'EditarPerfil', params: { id: this.userId } })
      },
    },
  }
</script>
