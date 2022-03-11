<template>
  <v-navigation-drawer
    id="main-sidebar"
    v-model="Sidebar_drawer"
    v-bar
    :dark="SidebarColor !== 'white'"
    :color="SidebarColor"
    mobile-breakpoint="960"
    clipped
    :right="$vuetify.rtl"
    mini-variant-width="70"
    :expand-on-hover="expandOnHover"
    app
  >
    <!---USer Area -->
    <v-list-item
      two-line
      class="profile-bg"
    >
      <v-list-item-avatar>
        <img
          :src="`${usuario.url}`"
          :alt="usuario.url"
        >
      </v-list-item-avatar>

      <v-list-item-content>
        <v-list-item-title>{{ usuario.email }}</v-list-item-title>
        <v-list-item-subtitle class="text-caption">
          {{ usuario.name }} {{ usuario.lastName }}
        </v-list-item-subtitle>
        <v-list-item-subtitle class="text-caption">
          {{ usuario.proveedorNombre }}
        </v-list-item-subtitle>
      </v-list-item-content>
    </v-list-item>
    <v-divider />
    <!---USer Area -->

    <v-list
      expand
      nav
      class="mt-1"
    >
      <template v-for="(item, i) in items">
        <!---If Sidebar Caption -->
        <v-row
          v-if="item.header"
          :key="item.header"
          align="center"
        >
          <v-col cols="12">
            <v-subheader
              v-if="item.header"
              class="d-block text-truncate"
            >
              {{
                item.header
              }}
            </v-subheader>
          </v-col>
        </v-row>
        <!---If Sidebar Caption -->
        <BaseItemGroup
          v-else-if="item.children"
          :key="`group-${i}`"
          class="icon-size"
          :item="item"
        />

        <BaseItem
          v-else
          :key="`item-${i}`"
          :item="item"
        />
      </template>
      <!---Sidebar Items -->
    </v-list>
    <v-divider />
    <!--- Progress -->

    <!--- Progress -->
  </v-navigation-drawer>
</template>

<script>
  import { mapState } from 'vuex'
  import VerticalSidebarItems from './VerticalSidebarItems'
  import UsuarioServices from '../../../services/UsuarioServices'
  import ProveedorServices from '../../../services/ProveedorServices'

  export default {
    name: 'VerticalSidebar',
    props: {
      expandOnHover: {
        type: Boolean,
        default: false,
      },
    },
    data: () => ({
      items: [],
      usuario: {},
    }),
    created () {
      this.usuarioServices = new UsuarioServices()
      this.proveedorServices = new ProveedorServices()
    },
    computed: {
      ...mapState(['SidebarColor', 'SidebarBg']),
      Sidebar_drawer: {
        get () {
          return this.$store.state.Sidebar_drawer
        },
        set (val) {
          this.$store.commit('SET_SIDEBAR_DRAWER', val)
        },
      },
    },
    watch: {
      '$vuetify.breakpoint.smAndDown' (val) {
        this.$emit('update:expandOnHover', !val)
      },
    },
    mounted () {
      this.verticalSidebarGetUser()
      this.verticalSidebarItemsPorRoles()
    },

    methods: {

      verticalSidebarGetUser () {
        const usuario = this.usuarioServices.getUser()

        this.usuario = usuario
        this.usuario.url = 'https://ui-avatars.com/api/?background=F00095&color=fff&name=' + this.usuario.name + this.usuario.lastName + ''

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

      verticalSidebarItemsPorRoles () {
        const list = []
        // verificamos menu
        VerticalSidebarItems.forEach(element => {
          if (this.visibilidadProveedor === true && (element.autorizeRoles === 'Proveedor' || element.autorizeRoles === '')) {
            // verificamos submenu
            let i = 0
            element.children.forEach(subElement => {
              if (this.visibilidadProveedor === true && (subElement.autorizeRoles === 'Compras')) {
                element.children.splice(i, 1)
              }
              i++
            })
            list.push(element)
          }

          if (this.visibilidadCompras === true && (element.autorizeRoles === 'Compras' || element.autorizeRoles === '')) {
            // verificamos submenu
            let i = 0
            element.children.forEach(subElement => {
              if (this.visibilidadCompras === true && (subElement.autorizeRoles === 'Proveedor')) {
                element.children.splice(i, 1)
              }
              i++
            })
            list.push(element)
          }
        })

        this.items = list
      },

    },
  }
</script>
<style lang="scss">
    #main-sidebar {
        box-shadow: 1px 0 20px rgba(0, 0, 0, 0.08);
        -webkit-box-shadow: 1px 0 20px rgba(0, 0, 0, 0.08);

        .v-navigation-drawer__border {
            display: none;
        }

        .v-list {
            padding: 8px 15px;
        }

        .v-list-item {
            min-height: 35px;

            &__icon--text,
            &__icon:first-child {
                justify-content: center;
                text-align: center;
                width: 20px;
            }
        }

        .v-list-item__icon i {
            width: 20px;
        }

        .icon-size .v-list-group__items i {
            width: 16px;
            font-size: 16px;
        }

        .profile-bg {
            &.theme--dark.v-list-item:not(.v-list-item--active):not(.v-list-item--disabled) {
                opacity: 1;
            }

            .v-avatar {
                padding: 15px 0;
            }
        }

        .theme--dark.v-list-item:not(.v-list-item--active):not(.v-list-item--disabled) {
            opacity: 0.5;

            &:hover {
                opacity: 1;
            }
        }

        .v-list .v-list-item--active {
            color: white;
        }
    }
</style>
