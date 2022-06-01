<template>
  <v-app-bar
    app
    clipped-left
    clipped-right
    :color="navbarColor"
    :dark="navbarColor !== 'white'"
  >
    <!---Logo part -->
    <v-toolbar-title
      v-if="navbarColor !== 'white'"
      class="align-center d-flex logo-width"
      :class="`${showLogo ? 'logo-width' : ''}`"
    >
      <span class="logo-icon">
        <img
          src="../../../assets/images/logos/egresados.png"
          height="60"
          width="80"
          class="mt-2"
        >
      </span>
    </v-toolbar-title>
    <!---Dark Logo part -->
    <v-toolbar-title
      v-else
      class="align-center d-flex logo-width"
      :class="`${showLogo ? 'logo-width' : ''}`"
    >
      <span class="logo-icon">
        <img
          src="../../../assets/images/logos/egresados.png"
          height="71"
          width="100"
          class="mt-2"
        >
      </span>
    </v-toolbar-title>
    <!---Logo part -->
    <!---/Toggle sidebar part -->
    <div @click="showhideLogo">
      <v-app-bar-nav-icon
        @click="
          $vuetify.breakpoint.smAndDown
            ? setSidebarDrawer(!Sidebar_drawer)
            : $emit('input', !value)
        "
      />
    </div>
    <!---/Toggle sidebar part -->
    <!---Search part -->
    <v-btn
      icon
      class="mr-1 d-sm-block d-none"
      @click="searchbox"
    >
      <v-icon>mdi-magnify</v-icon>
    </v-btn>

    <v-card
      v-if="showSearch"
      class="searchinput"
    >
      <template>
        <v-text-field
          placeholder="Search & hit enter"
          class="mt-3 mb-0"
          append-icon="mdi-close"
          @click:append="searchbox"
        />
      </template>
    </v-card>
    <!---/Search part -->
    <v-spacer />
    <!---right part -->
    <!---Notification -->
    <v-menu
      v-if="notificationCounter > 0"
      bottom
      left
      offset-y
      origin="top right"
      transition="scale-transition"
    >
      <template v-slot:activator="{ on }">
        <v-btn
          icon
          class="mr-1"
          v-on="on"
        >
          <v-badge
            color="red"
            :content="` ${notificationCounter}`"
          >
            <v-icon>mdi-message</v-icon>
          </v-badge>
        </v-btn>
      </template>

      <v-list>
        <h2 class="px-5 py-3 pt-2 font-weight-medium text-h6">
          Notificaciones
        </h2>
        <v-divider />
        <v-list-item
          v-for="(item, i) in notifications"
          :key="i"
          @click="abrirNotificacion(item)"
        >
          <v-list-item-title>
            <div class="d-flex align-center py-3">
              <div>
                <v-btn
                  class="mr-3"
                  depressed
                  fab
                  small
                  :color="item.iconbg"
                >
                  <v-icon dark>
                    {{ item.icon }}
                  </v-icon>
                </v-btn>
              </div>
              <div>
                <h6 class="font-weight-medium">
                  {{ item.title }}
                </h6>
                <span class="text--secondary text-caption descpart d-block text-truncate">{{ item.desc }}</span>
                <small class="text--secondary">{{ item.date }} {{ item.time }}</small>
              </div>
            </div>
          </v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>
    <!---Notification -->
    <!---User -->
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
        <!---User info -->
        <v-list-item>
          <v-list-item-avatar>
            <img
              :src="`${usuario.url}`"
              :alt="usuario.url"
            >
          </v-list-item-avatar>

          <v-list-item-content>
            <v-list-item-subtitle>{{ usuario.email }}</v-list-item-subtitle>
            <v-list-item-title>{{ usuario.name }} {{ usuario.lastName }}</v-list-item-title>
          </v-list-item-content>

          <v-list-item-action>
            <v-btn
              :class="fav ? 'red--text' : ''"
              icon
              @click="fav = !fav"
            />
          </v-list-item-action>
        </v-list-item>
        <!---End User info -->
        <v-divider />
        <v-subheader>Profile</v-subheader>

        <v-list-item
          v-for="(item, i) in userprofile"
          :key="i"
          :to="item.to"
          color="primary"
          @click="href(item)"
        >
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-menu>
    <v-dialog
      v-model="dialogLogout"
      persistent
      max-width="450"
    >
      <v-card>
        <v-card-title class="text-h3 pink dark lighten-2">
          Desea Salir del Sistema ?
        </v-card-title>
        <v-card-actions>
          <v-spacer />
          <v-btn
            color="#F00095"
            text
            @click="dialogLogout = false"
          >
            No
          </v-btn>
          <v-btn
            color="#008C95"
            text
            @click="logout"
          >
            Si
          </v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
    <!---User -->
  </v-app-bar>
</template>
<script>
// Utilities
  import { mapState, mapMutations } from 'vuex'
  import UsuarioServices from '../../../services/UsuarioServices'

  export default {
    name: 'VerticalHeader',

    components: {},

    props: {
      value: {
        type: Boolean,
        default: false,
      },
    },
    data: () => ({
      usuario: {},
      showLogo: true,
      showSearch: false,
      notificationCounter: '',
      fav: true,
      notifications: [],
      messages: [],
      userprofile: [
        { title: 'Account Setting', to: '/form-layouts/flformbasic' },
        { title: 'Logout', to: '' },
      ],
      dialogLogout: false,

    }),
    created () {
      this.usuarioServices = new UsuarioServices()
    },
    computed: {
      ...mapState(['navbarColor', 'Sidebar_drawer']),
    },
    mounted () {
      this.verticalHeaderGetUser()
    },

    methods: {
      ...mapMutations({
        setSidebarDrawer: 'SET_SIDEBAR_DRAWER',
      }),
      showhideLogo: function () {
        this.showLogo = !this.showLogo
      },

      searchbox: function () {
        this.showSearch = !this.showSearch
      },

      href (item) {
        if (item.title === 'Logout') {
          this.abrirPopUpLogout()
        }

        return undefined
      },

      verticalHeaderGetUser () {
        const usuario = this.usuarioServices.getUser()
        this.usuario = usuario
        this.usuario.url = 'https://ui-avatars.com/api/?background=008C95&color=fff&name=' + this.usuario.name + this.usuario.lastName + ''

        usuario.roles.forEach(element => {
          if (element === 'Proveedor') {
            this.visibilidadProveedor = true
          }
          if (element === 'Compras') {
            this.visibilidadCompras = true
          }
          if (element === 'Administrador') {
            this.visibilidadCompras = true
            this.visibilidadProveedor = true
          }
        })
      },

      abrirPopUpLogout: function () {
        this.dialogLogout = true
      },

      logout: function () {
        debugger
        this.usuarioServices.logout().then(data => {
          if (data === '') {
            localStorage.removeItem('access_user')
            this.$router.push({ path: '/usuarios/login' })
          }
        }).catch(error => {
          this.showError(error.response.data)
        })
      },
    },

  }
</script>

<style lang="sass">
.v-application .theme--dark.white .theme--dark.v-btn.v-btn--icon

.v-sheet.v-app-bar.v-toolbar:not(.v-sheet--outlined),
.v-sheet.v-card:not(.v-sheet--outlined)

.v-btn--icon.v-size--default .v-icon
  width: 20px
  font-size: 20px

.hidelogo
  display: none

.searchinput
  position: absolute
  width: 100%
  margin: 0
  left: 0
  z-index: 10
  padding: 0 15px

.descpart
  max-width: 220px
</style>
