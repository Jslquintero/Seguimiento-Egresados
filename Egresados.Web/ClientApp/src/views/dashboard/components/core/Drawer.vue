<template>
  <v-navigation-drawer
    id="core-navigation-drawer"
    v-model="drawer"
    :dark="barColor !== 'rgba(228, 226, 226, 1), rgba(255, 255, 255, 0.7)'"
    :expand-on-hover="expandOnHover"
    :right="$vuetify.rtl"
    mobile-break-point="960"
    mini-variant-width="70"
    app
    width="260"
    v-bind="$attrs"
  >
    <template v-slot:img="props">
      <v-img
        :gradient="`to bottom, ${barColor}`"
        v-bind="props"
      />
    </template>
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
        <v-list-item-subtitle class="text-caption">
          {{ usuario.name }} {{ usuario.lastName }}
        </v-list-item-subtitle>
        <v-list-item-subtitle class="text-caption" />
      </v-list-item-content>
    </v-list-item>
    <v-divider />

    <v-list
      dense
      nav
    >
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
                {{ item.header }}
              </v-subheader>
            </v-col>
          </v-row>
          <!---If Sidebar Caption -->
          <BaseItemGroup
            v-else-if="item.children"
            :key="`group-${i}`"
            class="icon-size"
            :item="item"
            :icon="item.icon"
          />

          <BaseItem
            v-else
            :key="`item-${i}`"
            :item="item"
          />
        </template>
        <!---Sidebar Items -->
      </v-list>
    </v-list>
    <v-divider />
  </v-navigation-drawer>
</template>

<script>
// Utilities
  import { mapState } from 'vuex'
  import UsuarioServices from '../../../../services/UsuarioServices'

  export default {
    name: 'DashboardCoreDrawer',

    props: {
      expandOnHover: {
        type: Boolean,
        default: false,
      },
    },

    data: () => ({
      items: [
        { header: 'Administrador' },
        {
          group: '/usuarios',
          model: false,
          icon: 'mdi-account',
          title: 'Usuarios',
          class: 'two-column',
          to: '/usuarios',
          autorizeRoles: 'Administrador',
          children: [
            {
              icon: 'mdi-account',
              title: 'Listado de Usuarios',
              to: 'listar',
              autorizeRoles: 'Administrador',
            },
          ],
        },
        {
          title: 'Tablas',
          icon: 'mdi-clipboard-outline',
          to: '/tables/regular-tables',
        },
        {
          title: 'icons',
          icon: 'mdi-chart-bubble',
          to: '/components/icons',
        },
        {
          title: 'notifications',
          icon: 'mdi-bell',
          to: '/components/notifications',
        },
      ],
      usuario: {},
    }),
    computed: {
      ...mapState(['barColor', 'barImage']),
      drawer: {
        get () {
          return this.$store.state.drawer
        },
        set (val) {
          this.$store.commit('SET_DRAWER', val)
        },
      },
      computedItems () {
        return this.items.map(this.mapItem)
      },
      profile () {
        return {
          avatar: true,
          title: this.$t('avatar'),
        }
      },
    },
    created () {
      this.usuarioServices = new UsuarioServices()
    },
    mounted () {
      this.getUser()
    },
    methods: {
      getUser () {
        const usuario = this.usuarioServices.getUser()
        this.usuario = usuario
        this.usuario.url =
          'https://ui-avatars.com/api/?background=F00095&color=fff&name=' +
          this.usuario.name +
          this.usuario.lastName +
          ''
      },
    },
  }
</script>

<style lang="scss">
#core-navigation-drawer {
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
