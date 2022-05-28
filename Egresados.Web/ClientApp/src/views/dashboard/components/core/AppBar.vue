<template>
  <v-app-bar
    id="app-bar"
    absolute
    app
    flat
    height="75"
  >
    <v-btn
      id="btn-menu"
      class="mr-3"
      elevation="0"
      small
      @click="setDrawer(!drawer)"
    >
      <v-icon
        v-if="value"
        size="40"
        color="white"
      >
        mdi-menu
      </v-icon>

      <v-icon
        v-else
        size="40"
        color="white"
      >
        mdi-menu
      </v-icon>
    </v-btn>
    <v-toolbar-title class="hidden-sm-and-down font-weight-bold white--text">
      <span class="logo-icon">
        <img src="../../../../assets/images/logos/logo-light-icon.png">
      </span>
      <span class="logo-text ml-2">
        <img
          src="../../../../assets/images/logos/logo-light-text.png"
          class="mt-2"
        >
      </span>
    </v-toolbar-title>
    <v-spacer />
    <v-toolbar-title
      class="hidden-sm-and-down font-weight-bold white--text"
      v-text="$route.name"
    />
    <v-spacer />

    <div class="mx-3" />
    <!---Notification -->
    <!-- ---------------------------------- -->
    <v-menu
      bottom
      left
      offset-y
      origin="top right"
      transition="scale-transition"
    >
      <template v-slot:activator="{ on }">
        <v-btn
          dark
          icon
          class="mr-1"
          v-on="on"
        >
          <v-badge
            color="red"
            dot
          >
            <v-icon color="white">
              mdi-bell
            </v-icon>
          </v-badge>
        </v-btn>
      </template>

      <v-list>
        <v-list-item
          v-for="(item, i) in notifications"
          :key="i"
          @click="href"
        >
          <v-list-item-title>
            <div class="d-flex align-center py-3">
              <div class>
                <v-btn
                  class="mr-3"
                  depressed
                  fab
                  small
                  dark
                  :color="item.iconbg"
                >
                  <v-icon dark>
                    {{ item.icon }}
                  </v-icon>
                </v-btn>
              </div>
              <div>
                <h4 class="font-weight-medium">
                  {{ item.title }}
                </h4>
                <span
                  class="text--secondary text-caption descpart d-block text-truncate"
                >{{ item.desc }}</span>
                <small class="text--secondary">{{ item.time }}</small>
              </div>
            </div>
          </v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>
    <!-- ---------------------------------- -->
    <!---Notification -->
    <!-- ---------------------------------- -->
    <!---User -->
    <!-- ---------------------------------- -->
    <v-menu
      bottom
      left
      offset-y
      origin="top right"
      transition="scale-transition"
    >
      <template v-slot:activator="{ on }">
        <v-btn
          dark
          icon
          class="mr-1"
          v-on="on"
        >
          <v-avatar size="40">
            <img
              :src="`${usuario.url}`"
              :alt="usuario.url"
            >
          </v-avatar>
        </v-btn>
      </template>

      <v-list>
        <v-list-item
          v-for="(item, i) in userProfile"
          :key="i"
          :to="item.to"
          @click="href"
        >
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item>
        <v-list-item @click="logout()">
          <p class="font-weight-medium">
            <v-icon>mdi-logout</v-icon>
            Cerrar Sesión
          </p>
        </v-list-item>
      </v-list>
    </v-menu>
    <!-- ---------------------------------- -->
    <!---User -->
    <!-- ---------------------------------- -->
  </v-app-bar>
</template>

<script>
// Utilities
  import { mapState, mapMutations } from 'vuex'
  import UsuarioServices from '../../../../services/UsuarioServices'
  export default {
    name: 'DashboardCoreAppBar',
    props: {
      value: {
        type: Boolean,
        default: false,
      },
    },

    data: () => ({
      notifications: [],
      userProfile: [],
      href: '',
      usuario: {
        url: '',
      },
      bar: {
        background: '',
      },
    }),

    computed: {
      ...mapState(['drawer']),
    },
    created () {
      this.usuarioServices = new UsuarioServices()
    },
    mounted () {
      this.GetUser()
      this.PerfilNotificacionRol()
    },
    methods: {
      ...mapMutations({
        setDrawer: 'SET_DRAWER',
      }),
      logout () {
        this.usuarioServices.logout().then((data) => {
          this.$swal({
            title: '¿Estás seguro?',
            text: 'cerrando sesión',
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, cerrar sesión',
          }).then((result) => {
            if (result.isConfirmed) {
              this.$swal('Cerrando sesión', 'sesión cerrada con éxito', 'success')
              this.$router.push('/')
            }
          })
        })
      },

      GetUser () {
        const usuario = this.usuarioServices.getUser()

        this.usuario = usuario
        this.usuario.url =
          'https://ui-avatars.com/api/?background=F00095&color=fff&name=' +
          this.usuario.name +
          this.usuario.lastName +
          ''

        usuario.roles.forEach((element) => {
          if (element === 'Administrador') {
            this.visibilidadAdministrativo = true
          }
          if (element === 'Egresado') {
            this.visibilidadEgresado = true
          }
          if (element === 'RecursoHumano') {
            this.visibilidadRecursoHumano = true
          }
          if (element === 'Empresa') {
            this.visibilidadEmpresa = true
          }
        })
      },

      PerfilNotificacionRol () {
        // Perfil segun rol
        if (this.visibilidadAdministrativo) {
          this.userProfile = []
        }
        if (this.visibilidadRecursoHumano) {
          this.userProfile = []
        }
        if (this.visibilidadEmpresa) {
          this.userProfile = []
        }
        if (this.visibilidadEgresado) {
          this.userProfile.push({
            title: 'Perfil',
            to: '/egresados/perfil',
          })
        }
        if (this.visibilidadAdministrativo) {
          this.notifications.push({
            title: 'Nuevo Usuario',
            desc: 'Nuevo usuario registrado',
            icon: 'mdi-bell',
            iconbg: 'red',
            time: 'Hace 30 min',
          })
        }
        if (this.visibilidadRecursoHumano) {
          this.notifications.push(
            {
              title: 'Asistencia',
              desc: 'Alguien ha marcado su asistencia',
              icon: 'mdi-bell',
              iconbg: 'red',
              time: 'Hace 1 min',
            },
            {
              title: 'Asistencia',
              desc: 'Alguien ha removido su asistencia',
              icon: 'mdi-bell',
              iconbg: 'red',
              time: 'Hace 15 min',
            },
          )
        }
        if (this.visibilidadEmpresa) {
          this.notifications.push(
            {
              title: 'Postulaciones',
              desc: 'Alguien ha postulado a su oferta',
              icon: 'mdi-bell',
              iconbg: 'red',
              time: 'Hace 30 min',
            },
            {
              title: 'Postulaciones',
              desc: 'Alguien ha removido su postulacion',
              icon: 'mdi-bell',
              iconbg: 'red',
              time: 'Hace 1 min',
            },
          )
        }
        if (this.visibilidadEgresado) {
          this.notifications.push(
            {
              title: 'Solicitud de amistad',
              desc: 'Alguien quiere ser tu amigo',
              icon: 'mdi-account',
              iconbg: 'red',
              time: 'Hace 1 min',
            },
            {
              title: 'Evento',
              desc: 'Alguien te ha invitado a un evento',
              icon: 'mdi-bell',
              iconbg: 'red',
              time: 'Hace 15 min',
            },
          )
        }
      },
    },
  }
</script>
<style lang="scss">
#app-bar {
  background: linear-gradient(90deg, #681d60 5%, #5c79c3 80%, #e7e7e7 100%);
}
#btn-menu{
background: transparent;
}
</style>
