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
          title="Aplicar"
          class="mr-2"
          @click="assitencia(item)"
        >
          mdi-star
        </v-icon>
        <v-icon
          color="red darken-2"
          title="Remover aplicación"
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
  import BolsaTrabajoServices from '../../services/BolsaTrabajoServices.js'

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
        { text: 'Acciones', value: 'actions' },
      ],
      snackbar: {
        active: false,
        text: '',
        color: '',
      },
      bolsaTrabajoServices: null,
    }),
    created () {
      this.bolsaTrabajoServices = new BolsaTrabajoServices()
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
        this.bolsaTrabajoServices
          .getList()
          .then((data) => {
            this.list = data
          })
          .catch((error) => {
            this.showError(error.response.data.title)
            console.log(error.response.status)
          })
      },
    },
  }
</script>
