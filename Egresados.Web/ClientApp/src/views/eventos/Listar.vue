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
      <v-col>
        <v-btn
          x-large
          color="#691a5c"
          rounded
          dark
          @click="addItem"
        >
          Crear nuevo evento
        </v-btn>
      </v-col>
      <v-col />
    </v-card-title>

    <v-data-table
      :headers="headers"
      :items="list"
      :search="search"
    >
      <template v-slot:item.actions="{ item }">
        <v-icon
          title="Editar"
          class="mr-2"
          @click="editItem(item)"
        >
          mdi-pencil
        </v-icon>
        <v-icon
          small
          @click="deleteItem(item)"
        >
          mdi-delete
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
      addItem () {
        this.$router.push({ name: 'CrearEvento', params: { id: 0 } })
      },
      editItem (item) {
        this.$router.push({ name: 'CrearEvento', params: { id: item.id } })
      },
      deleteItem (item) {
        this.$swal({
          title: '¿Estás seguro?',
          text: '¿Estás seguro de eliminar el evento?',
          icon: 'warning',
          showCancelButton: true,
          confirmButtonColor: '#691a5c',
          cancelButtonColor: '#d33',
          confirmButtonText: 'Si, eliminar',
          cancelButtonText: 'No, cancelar',
        }).then((result) => {
          if (result.value) {
            this.eventoServices
              .deleteItem(item.id)
              .then((data) => {
                this.showSuccess(data.title)
                this.getList()
              })
              .catch((error) => {
                this.showError(error.response.data.title)
                console.log(error.response.status)
              })
          }
        })
      },
    },
  }
</script>
