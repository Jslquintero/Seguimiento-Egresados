<template>
  <v-card>
    <v-card-title> Eventos </v-card-title>
    <v-card-text />
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
              v-model="form.nombre"
              label="Nombre"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-text-field
              v-model="form.descripcion"
              label="Descripción"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-text-field
              v-model="form.fechaEvento"
              label="Fecha del evento"
              type="date"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-col />
            <v-col />
            <v-text-field
              v-model="form.horaEvento"
              label="Hora del evento"
              type="time"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-col />
            <v-text-field
              v-model="form.costo"
              label="Costo"
              type="number"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              required
            />
            <v-col />
            <v-select
              v-model="form.lugarEventoId"
              label="Lugar"
              :items="lugarEventos"
              item-text="nombre"
              item-value="id"
              :rules="[(v) => !!v || 'Este campo es requiredo']"
              persistent-hint
              single-line
            />
            <v-col />
            <v-col />
            <v-select
              v-model="form.facultadId"
              label="Facultad"
              :items="facultades"
              item-text="nombre"
              item-value="id"
              persistent-hint
              single-line
            />
            <v-col />
          </v-col>
          <v-col
            cols="6"
            sm="2"
            md="2"
          />
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
          color="#F00095"
          dark
          @click="cancelar"
        >
          Cancelar
        </v-btn>
        <v-btn
          x-large
          class="mx-2 mt-2 mb-2"
          rounded
          color="#F00095"
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
  import EventoServices from '../../services/EventoServices'
  import LugarEventoServices from '../../services/LugarEventoServices'
  import FacultadServices from '../../services/FacultadServices'

  export default {
    name: 'CrearEditar',
    data () {
      return {
        form: {
          fechaAlta: '',
          fechaModificacion: '',
          id: 0,
          lugarEvento: '',
          lugarEventoId: '',
          facultad: '',
          facultadId: '',
          nombre: '',
          descripcion: '',
          fechaEvento: '',
          horaEvento: '',
          sala: '',
          costo: '',
        },
        lugarEventos: [],
        facultades: [],
      }
    },
    created () {
      this.eventoServices = new EventoServices()
      this.lugarEventoServices = new LugarEventoServices()
      this.facultadServices = new FacultadServices()
    },
    mounted () {
      this.getOneEvento(this.$route.params.id)
      this.selectListLugarEvento()
      this.selectListFacultad()
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

      selectListLugarEvento () {
        this.lugarEventoServices
          .selectList()
          .then((data) => {
            this.lugarEventos = data
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

      getOneEvento (id) {
        if (id > 0) {
          this.eventoServices
            .getOne(id)
            .then((data) => {
              this.form = data
              this.form.fechaEvento = moment(this.form.fechaEvento).format('YYYY-MM-DD')
              this.form.horaEvento = moment(this.form.horaEvento).format('hh:mm')
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
          this.eventoServices
            .save(this.form)
            .then((data) => {
              if (data === '') {
                this.showSuccess('El evento se creó correctamente.')
                this.$router.push({
                  path: '/eventos/Listar/',
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
          path: '/eventos/Listar',
        })
      },
    },
  }
</script>
