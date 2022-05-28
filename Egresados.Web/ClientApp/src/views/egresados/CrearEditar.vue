<template>
  <v-card
    class="mx-3 my-5"
    width="1350"
  >
    <v-form
      ref="form"
      v-model="form.valid"
      lazy-validation
    >
      <v-container>
        <v-row>
          <v-col
            cols="3"
            sm="2"
            md="5"
          >
            <v-text-field
              v-model="form.telefono"
              label="Teléfono"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-text-field
              v-model="form.empresa"
              label="Empresa o Institución donde labora"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-text-field
              v-model="form.direccion"
              label="Dirección de la empresa o institución"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-text-field
              v-model="form.fechaNacimiento"
              label="Fecha de nacimiento"
              type="date"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-text-field
              v-model="form.linkedin"
              label="Linkedin (Introducir solamente el Id de tu perfil: https://www.linkedin.com/in/IdPerfil/)"
            />
            <v-text-field
              v-model="form.instagram"
              label="Instagram (Introducir nombre de usuario)"
            />
            <v-label>Género</v-label>
            <v-select
              v-model="form.genero"
              label="Género"
              :items="generos"
              item-text="text"
              item-value="value"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              persistent-hint
              single-line
            />
            <v-label>Provincia</v-label>
            <v-select
              v-model="form.provinciaId"
              label="Provincia"
              :items="provincias"
              item-text="nombre"
              item-value="id"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              persistent-hint
              single-line
            />
            <v-label>Facultad</v-label>
            <v-select
              v-model="form.facultadId"
              label="Facultad"
              :items="facultades"
              item-text="nombre"
              item-value="id"
              persistent-hint
              single-line
            />
            <v-textarea
              v-model="form.biografia"
              outlined
              counter
              label="Biografía"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-col />
          </v-col>
        </v-row>
      </v-container>
      <v-col
        cols="12"
        md="3"
      >
        <v-btn
          x-large
          class="mx-2 mt-2 mb-2"
          rounded
          color="#691a5c"
          dark
          @click="cancelar"
        >
          Cancelar
        </v-btn>
        <v-btn
          x-large
          class="mx-2 mt-2 mb-2"
          rounded
          color="#691a5c"
          dark
          @click="save"
        >
          Agregar
        </v-btn>
      </v-col>
    </v-form>
  </v-card>
</template>

<script>
  import moment from 'moment'
  import ProvinciaServices from '../../services/ProvinciaServices'
  import FacultadServices from '../../services/FacultadServices'
  import PerfilServices from '../../services/PerfilServices'

  export default {
    name: 'CrearEditar',
    data () {
      return {
        form: {
          fechaAlta: '',
          fechaModificacion: '',
          id: '',
          usuarioId: '',
          facultad: '',
          facultadId: '',
          provincia: '',
          provoinciaId: '',
          genero: '',
          direccion: '',
          telefono: '',
          biografia: '',
          fechaNacimiento: '',
          empresa: '',
          linkedin: '',
          instagram: '',
        },
        provincias: [],
        facultades: [],
        usuarios: [],
        generos: [
          { text: 'M', value: 'M' },
          { text: 'F', value: 'F' },
          { text: 'Otro', value: 'O' },
        ],
      }
    },
    created () {
      this.facultadServices = new FacultadServices()
      this.provinciaServices = new ProvinciaServices()
      this.perfilServices = new PerfilServices()
      this.form.usuarioId = this.$route.params.id
      this.getOneUsuario(this.$route.params.id)
    },
    mounted () {
      // this.getOnePerfil(this.$route.params.id)
      this.selectListProvincia()
      this.selectListFacultad()
      this.form.fechaNacimiento = moment().format('YYYY-MM-DD')
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

      selectListProvincia () {
        this.provinciaServices
          .selectList()
          .then((data) => {
            this.provincias = data
          })
          .catch((error) => {
            this.showError(error.response.data.title)
            console.log(error.response.status)
          })
      },

      selectListFacultad () {
        this.facultadServices
          .selectList()
          .then((data) => {
            this.facultades = data
          })
          .catch((error) => {
            this.showError(error.response.data.title)
            console.log(error.response.status)
          })
      },

      // getUserStorage () {
      //   this.usuario = JSON.parse(localStorage.getItem('access_user'))
      // },

      // getOnePerfil (id) {
      //   if (id !== '') {
      //     this.perfilServices
      //       .getOne(id)
      //       .then((data) => {
      //         console.log(data)
      //         this.form = data
      //         this.form.fechaNacimiento = moment(this.form.fechaEvento).format('YYYY-MM-DD')
      //         this.form.usuarioId = this.usuario.id
      //       })
      //       .catch((error) => {
      //         this.showError(error.response.data.title)
      //         console.log(error.response.status)
      //       })
      //   }
      // },

      getOneUsuario (id) {
        if (id !== '') {
          this.perfilServices
            .getOneUsuario(id)
            .then((data) => {
              this.form = data
              this.form.fechaNacimiento = moment(this.form.fechaNacimiento).format('YYYY-MM-DD')
            })
            .catch((error) => {
              this.showError(error.response.data.title)
              console.log(error.response.status)
            })
        }
      },

      save () {
        this.$refs.form.validate()
        if (this.$refs.form.validate(true)) {
          this.perfilServices
            .save(this.form)
            .then((data) => {
              console.log(data)
              if (data === '') {
                this.showSuccess('El perfil ha actualizado')
                this.$router.push({
                  path: '/egresados/Perfil/',
                })
              }
            })
            .catch((error) => {
              this.showError(error.response.data.title)
            })
        }
      },

      cancelar () {
        this.$router.push({
          path: '/egresados/Perfil',
        })
      },
    },
  }
</script>
