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
              v-model="form.empresa"
              label="Nombre de la empresa"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-text-field
              v-model="form.vacanteNombre"
              label="Nombre de la vacante"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-text-field
              v-model="form.perfil"
              label="Perfil"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-text-field
              v-model="form.telefono"
              label="Telefono"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-text-field
              v-model="form.email"
              label="Emai"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-text-field
              v-model="form.observacion"
              label="Observaciones"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-col />
            <v-col />
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
  import BolsaTrabajoServices from '../../services/BolsaTrabajos'

  export default {
    name: 'CrearEditar',
    data () {
      return {
        form: {
          fechaAlta: '',
          fechaModificacion: '',
          id: 0,
          empresa: '',
          vacanteNombre: '',
          perfil: '',
          telefono: '',
          email: '',
          observacion: '',
        },
      }
    },
    created () {
      this.bolsaTrabajosServices = new BolsaTrabajoServices()
    },
    mounted () {
      this.getOneEvento(this.$route.params.id)
      this.form.fechaEvento = moment().format('YYYY-MM-DD')
      this.form.horaEvento = moment().format('hh:mm')
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

      save () {
        this.$refs.form.validate()
        if (this.$refs.form.validate(true)) {
          this.bolsaTrabajosServices
            .save(this.form)
            .then((data) => {
              if (data === '') {
                this.showSuccess('La vacante se creo correctamente.')
                this.$router.push({
                  path: '/bolsaTrabajos/Listar/',
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
          path: '/bolsatrabajos/Listar',
        })
      },
    },
  }
</script>
