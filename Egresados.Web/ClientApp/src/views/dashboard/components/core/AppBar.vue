<template>
  <v-app-bar
    id="app-bar"
    absolute
    app
    color="transparent"
    flat
    height="75"
  >
    <v-btn
      class="mr-3"
      elevation="1"
      fab
      small
      @click="setDrawer(!drawer)"
    >
      <v-icon v-if="value">
        mdi-view-quilt
      </v-icon>

      <v-icon v-else>
        mdi-dots-horizontal
      </v-icon>
    </v-btn>

    <v-toolbar-title
      class="hidden-sm-and-down font-weight-light"
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
            <v-icon>mdi-message</v-icon>
          </v-badge>
        </v-btn>
      </template>

      <v-list>
        <h4 class="px-5 py-3 pt-2 font-weight-medium text-h6">
          Notificaciones
        </h4>
        <v-divider />
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
              src="https://randomuser.me/api/portraits/men/81.jpg"
              alt="John"
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
      notifications: [{ title: 'My Contacts', to: '/' }],
      userProfile: [{ title: 'Mi perfil', to: '/pages/user' }],
      href () {
        return undefined
      },
    }),

    computed: {
      ...mapState(['drawer']),
    },
    created () {
      this.usuarioServices = new UsuarioServices()
    },
    methods: {
      ...mapMutations({
        setDrawer: 'SET_DRAWER',
      }),
      logout () {
        this.usuarioServices.logout()
          .then(data => {
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
                this.$swal(
                  'Cerrando sesión',
                  'sesión cerrada con éxito',
                  'success',
                )
                this.$router.push('/')
              }
            })
          })
      },
    },
  }
</script>
