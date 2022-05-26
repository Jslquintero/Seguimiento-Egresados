<template>
  <v-card class="mx-3 my-5">
    <v-card-title>
      <v-row>
        <v-col
          cols="12"
          md="10"
        >
          <v-text-field
            v-model="search"
            append-icon="mdi-magnify"
            label="Buscar"
            single-line
            hide-details
          />
        </v-col>
        <v-col
          cols="12"
          md="9"
        />
      </v-row>
      <v-col />
    </v-card-title>

    <v-data-table
      :headers="headers"
      :items="list"
      :search="search"
    >
      <template v-slot:item.actions="{ item }">
        <v-icon
          color="yellow darken-2"
          title="Interesado"
          class="mr-2"
          @click="assitencia(item)"
        >
          mdi-star
        </v-icon>
        <v-icon
          color="green darken-2"
          title="Asistiré"
          class="mr-2"
          @click="assitencia(item)"
        >
          mdi-check
        </v-icon>
        <v-icon
          color="red darken-2"
          title="No Interesado"
          class="mr-2"
          @click="assitencia(item)"
        >
          mdi-star-off
        </v-icon>
        <v-icon
          color="blue darken-2"
          title="Compartir"
          class="mr-2"
          @click="assitencia(item)"
        >
          mdi-share
        </v-icon>
      </template>
    </v-data-table>
  </v-card>
</template>

<script>
  import EventoServices from '../../services/EventoServices.js'

  export default {
    name: 'Listar',
    data: () => ({
      valid: true,
      search: '',
      list: [],
      headers: [
        { text: 'Nombre', value: 'nombre' },
        { text: 'Descripcion', value: 'descripcion' },
        { text: 'Fecha del evento', value: 'fechaString' },
        { text: 'Hora del evento', value: 'horaString' },
        { text: 'Lugar', value: 'lugarEvento.nombre' },
        { text: 'Sala', value: 'sala' },
        { text: 'Costo entrada', value: 'costo' },
        { text: 'Acciones', value: 'actions' },
      ],
      snackbar: {
        active: false,
        text: '',
        color: '',
      },
      eventoServices: null,
    }),
    created () {
      this.eventoServices = new EventoServices()
    },
    mounted () {
      this.getList()
    },
    methods: {
      showSnackbar (text, color) {
        this.snackbar.active = true
        this.snackbar.text = text
        this.snackbar.color = color
      },
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

      getList () {
        this.eventoServices
          .getList()
          .then((data) => {
            this.list = data
          })
          .catch((error) => {
            this.showError(error.response.data.title)
            console.log(error.response.status)
          })
      },

      assitencia () {
        this.$swal({
          titleText: 'Correcto!',
          text: 'Asistencia registrada',
          icon: 'succes',
          confirmButtonText: 'Aceptar',
        })
      },
    },
  }
</script>
