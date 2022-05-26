<template>
  <v-container id="user-profile" fluid tag="section" class="mx-3 my-5">
    <v-row justify="center">
      <v-col cols="12" md="4">
        <base-material-card
          class="v-card-profile"
          avatar="https://demos.creative-tim.com/vue-material-dashboard/img/marc.aba54d65.jpg"
        >
          <v-card-text class="text-center">
            <h6 class="text-h4 mb-1 grey--text">
              {{ Empresa }}
            </h6>

            <h4 class="text-h3 font-weight-light mb-3 black--text">Nombre</h4>
            <p class="font-weight-light grey--text">Teléfono</p>
            <p class="font-weight-light grey--text">Dirección</p>
            <p class="font-weight-light grey--text">Cumpleaños</p>

            <p class="font-weight-light grey--text">Género</p>

            <p class="font-weight-light grey--text">Biografia</p>

            <v-btn color="success" rounded class="mr-0"> Redes Sociales </v-btn>
          </v-card-text>
        </base-material-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import UsuarioServices from "../../services/UsuarioServices.js";
import PerfilServices from "../../services/PerfilServices";
export default {
  name: "Perfil",
  data() {
    return {
      form: [],
    };
  },
  created() {
    this.PerfilServices = new PerfilServices();
    this.UsuarioServices = new UsuarioServices();
    this.getUserStorage();
  },
  mounted() {},
  methods: {
    showSuccess(message) {
      this.$toastr.Add({
        name: "UniqueToastName", // this is give you ability to use removeByName method
        title: "Success Message", // Toast Title
        msg: message,
        type: "success",
      });
    },
    showError(message) {
      this.$toastr.Add({
        name: "UniqueToastName", // this is give you ability to use removeByName method
        title: "Error Message", // Toast Title
        msg: message,
        type: "error",
      });
    },

    getUserStorage() {
      this.usuario = JSON.parse(localStorage.getItem("access_user"));
    },
    getOnePerfil(id) {
      if (id !== "") {
        this.perfilServices
          .getOne(id)
          .then((data) => {
            this.form = data;
          })
          .catch((error) => {
            this.showError(error.response.data.title);
            console.log(error.response.status);
          });
      }
    },
  },
};
</script>
