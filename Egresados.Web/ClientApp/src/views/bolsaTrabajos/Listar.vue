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
          Crear nueva bolsa de trabajo
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
  import BolsaTrabajoServices from '../../services/BolsaTrabajos.js'

  export default {
    name: 'Listar',
    data: () => ({
      valid: true,
      search: '',
      list: [],
      headers: [
        { text: 'Nombre', value: 'empresa' },
        { text: 'Nombre de la Vacante', value: 'vacanteNombre' },
        { text: 'Perfil', value: 'perfil' },
        { text: 'Telefono', value: 'telefono' },
        { text: 'Email', value: 'email' },
        { text: 'Observacion', value: 'observacion' },
      ],
      snackbar: {
        active: false,
        text: '',
        color: '',
      },
      bolsaTrabajosServices: null,
    }),
    created () {
      this.bolsaTrabajosServices = new BolsaTrabajoServices()
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
        this.bolsaTrabajosServices
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
        this.$router.push({ name: 'CrearTrabajo', params: { id: 0 } })
      },
      editItem (item) {
        this.$router.push({ name: 'CrearTrabajo', params: { id: item.id } })
      },
      deleteItem (item) {
        this.bolsaTrabajosServices
          .delete(item.id)
          .then((data) => {
            if (data === '') {
              console.log(data)
              this.showSuccess('Elemento eliminado correctamente.')
            }
          })
          .catch((error) => {
            this.showError(error.response.data.title)
            console.log(error.response.status)
          })
      },
    },
  }
</script>
