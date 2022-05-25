<template>
  <v-app-bar
    class="horizontal-header"
    app
    clipped-left
    clipped-right
    :color="navbarColor"
    :dark="navbarColor !== 'white'"
  >
    <v-container class="py-0 d-flex">
      <!-- ---------------------------------- -->
      <!--- light Logo part -->
      <!-- ---------------------------------- -->
      <v-toolbar-title
        v-if="navbarColor !== 'white'"
        class="align-center d-flex"
        :class="`${showLogo ? 'logo-width' : ''}`"
      >
        <span class="logo-icon">
          <img  src="../../../assets/images/logos/fasani.png">
        </span>
        <span
          class="logo-text ml-2"
          :class="`${showLogo ? '' : 'hidelogo'}`"
        >
          <img
             src="../../../assets/images/logos/fasani.png"
            class="mt-2"
          >
        </span>
      </v-toolbar-title>
      <!-- ---------------------------------- -->
      <!---  dark Logo part -->
      <!-- ---------------------------------- -->
      <v-toolbar-title
        v-else
        class="align-center d-flex"
        :class="`${showLogo ? 'logo-width' : ''}`"
      >
        <span class="logo-icon">
          <img  src="../../../assets/images/logos/fasani.png">
        </span>
        <span
          class="logo-text ml-2"
          :class="`${showLogo ? '' : 'hidelogo'}`"
        >
          <img
             src="../../../assets/images/logos/fasani.png"
            class="mt-2"
          >
        </span>
      </v-toolbar-title>
      <!-- ---------------------------------- -->
      <!--- end Logo part -->
      <!-- ---------------------------------- -->
      <!-- ---------------------------------- -->
      <!---/Toggle sidebar part -->
      <!-- ---------------------------------- -->
      <div
        class="d-block d-lg-none md-none"
        @click="showhideLogo"
      >
        <v-app-bar-nav-icon
          @click="
            $vuetify.breakpoint.smAndDown
              ? setSidebarDrawer(!Sidebar_drawer)
              : $emit('input', !value)
          "
        />
      </div>
      <!-- ---------------------------------- -->
      <!---/Toggle sidebar part -->
      <!-- ---------------------------------- -->
      <!---Search part -->
      <!-- ---------------------------------- -->
      <v-btn
        dark
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
      <!-- ---------------------------------- -->
      <!---/Search part -->
      <!-- ---------------------------------- -->
      <v-spacer />

      <!-- ---------------------------------- -->
      <!---right part -->
      <!-- ---------------------------------- -->
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
            v-for="(item, i) in userprofile"
            :key="i"
            :to="item.to"
            @click="href"
          >
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item>
        </v-list>
      </v-menu>
      <!-- ---------------------------------- -->
      <!---User -->
      <!-- ---------------------------------- -->
    </v-container>
  </v-app-bar>
</template>
<script>
// Utilities
  import { mapState, mapMutations } from 'vuex'
  export default {
    name: 'HorizontalHeader',

    components: {},

    props: {
      value: {
        type: Boolean,
        default: false,
      },
    },
    data: () => ({
      showLogo: true,
      showSearch: false,
      notifications: [
        {
          title: 'Settings',
          iconbg: 'info',
          icon: 'mdi-cog',
          desc: 'You can customize this template as you want',
          time: '11:30AM',
        },
      ],
      userprofile: [
        { title: 'My Contacts', to: '/apps/contact' },
        { title: 'My Balance', to: '/apps/contact-grid' },
        { title: 'Inbox', to: '/apps/email/inbox' },
        { title: 'Account Setting', to: '/form-layouts/flformbasic' },
        { title: 'Logout', to: '/authentication/boxedlogin' },
      ],
      href () {
        return undefined
      },
    }),

    computed: {
      ...mapState(['navbarColor', 'Sidebar_drawer']),
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
    },
  }
</script>

<style lang="scss">
.hidelogo {
  display: none;
}
.searchinput {
  position: absolute;
  width: 100%;
  margin: 0;
  left: 0;
  z-index: 10;
  padding: 0 15px;
}
.descpart {
  max-width: 220px;
}

@media (min-width: 1024px) {
  .horizontalstyle {
    .logo-width {
      position: absolute;
      left: 0;
      right: 0;
      margin: 0 auto;
      width: 235px;
    }
  }
}
</style>
