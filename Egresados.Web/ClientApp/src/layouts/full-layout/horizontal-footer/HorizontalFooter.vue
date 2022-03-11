<template>
  <v-footer
    app
    class="footerpart"
    inset
  >
    <v-container class="py-0">
      <v-col cols="12">
        <span
          class="d-block text-center"
        >© {{ new Date().getFullYear() }} — Farmacias San Nicolas
        </span>
      </v-col>
    </v-container>
  </v-footer>
</template>
<script>
  export default {
    name: 'HorizontalFooter',
    data: () => ({}),
  }
</script>
<style lang="scss">
.v-application .footerpart {
  border-top: 1px solid rgba(0, 0, 0, 0.1) !important;
}
.theme--light.v-footer {
  background: white;
}
</style>
