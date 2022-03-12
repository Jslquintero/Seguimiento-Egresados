<template>
  <v-app
    id="inspire"
    :class="{ horizontalstyle: setHorizontalLayout }"
  >
    <vertical-header
      v-if="!setHorizontalLayout"
      v-model="expandOnHover"
    />
    <horizontal-header v-else />
    <v-main>
      <v-container
        fluid
        class="page-wrapper"
      >
        <transition
          name="router-anim"
          enter-active-class="fade-enter-active fade-enter"
          leave-active-class="fade-leave-active fade-enter"
        >
          <router-view />
        </transition>
      </v-container>
    </v-main>
    <vertical-sidebar
      v-if="!setHorizontalLayout"
      :expand-on-hover.sync="expandOnHover"
    />
    <horizontal-sidebar v-else />

    <customizer v-model="expandOnHover" />
  </v-app>
</template>

<script>
  import HorizontalHeader from './horizontal-header/HorizontalHeader'
  import VerticalHeader from './vertical-header/VerticalHeader'
  import HorizontalSidebar from './horizontal-sidebar/HorizontalSidebar'
  import VerticalSidebar from './vertical-sidebar/VerticalSidebar'
  import Footer from '../../views/dashboard/components/core/Footer.vue'
  import Customizer from './customizer/Customizer'
  import { mapState, mapMutations } from 'vuex'
  export default {
    name: 'Layout',

    components: {
      HorizontalHeader,
      VerticalHeader,
      HorizontalSidebar,
      VerticalSidebar,
      Footer,
      HorizontalFooter,
      Customizer,
    },

    props: {
      source: String,
    },
    data: () => ({
      expandOnHover: false,
    }),
    computed: {
      ...mapState(['Customizer_drawer', 'setHorizontalLayout']),
    },

    methods: {
      ...mapMutations({
        setCustomizerDrawer: 'SET_CUSTOMIZER_DRAWER',
      }),
    },
  }
</script>

<style>
</style>
