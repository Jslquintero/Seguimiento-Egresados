import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  mode: 'hash',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      redirect: 'usuarios/Login',
      component: () => import('@/views/dashboard/Dashboard'),
    },
    {
      path: '/usuarios',
      component: () => import('@/layouts/blank-layout/Blanklayout'),
      children: [
        {
          name: 'Login',
          path: 'Login',
          component: () => import('@/views/usuarios/Login'),
        },
        {
          name: 'RecuperarPassword',
          path: 'RecuperarPassword',
          component: () => import('@/views/usuarios/RecuperarPassword'),
        },
        {
          name: 'RecuperarPasswordConfirmar',
          path: 'RecuperarPasswordConfirmar',
          component: () => import('@/views/usuarios/RecuperarPasswordConfirmar'),
        },
      ],
    },
    {
      path: '/usuarios',
      component: () => import('@/views/dashboard/Index'),
      children: [
        {
          name: 'Listar',
          path: 'Listar',
          component: () => import('@/views/usuarios/Listar'),
        },
      ],
    },
    {
      path: '/eventos',
      component: () => import('@/views/dashboard/Index'),
      children: [
        {
          name: 'Listar',
          path: 'Listar',
          component: () => import('@/views/eventos/Listar'),
        },
        {
          name: 'CrearEvento',
          path: 'CrearEditar',
          component: () => import('@/views/eventos/CrearEditar'),
        },
      ],
    },
    {
      path: '/bolsaTrabajos',
      component: () => import('@/views/dashboard/Index'),
      children: [
        {
          name: 'Listar',
          path: 'Listar',
          component: () => import('@/views/bolsaTrabajos/Listar'),
        },
        {
          name: 'CrearTrabajo',
          path: 'CrearEditar',
          component: () => import('@/views/bolsaTrabajos/CrearEditar'),
        },
      ],
    },
    {
      path: '/egresados',
      component: () => import('@/views/dashboard/Index'),
      children: [
        {
          name: 'ListarEvento',
          path: 'ListarEvento',
          component: () => import('@/views/egresados/ListarEvento'),
        },
        {
          name: 'ListarTrabajo',
          path: 'ListarTrabajo',
          component: () => import('@/views/egresados/ListarTrabajo'),
        },
        {
          name: 'Perfil',
          path: 'Perfil',
          component: () => import('@/views/egresados/Perfil'),
        },
        {
          name: 'EditarPerfil',
          path: 'CrearEditar',
          component: () => import('@/views/egresados/CrearEditar'),
        },
      ],
    },
    //  dashboard routes start
    {
      path: '/dashboard',
      component: () => import('@/views/dashboard/Index'),
      children: [
        // Dashboard
        {
          name: 'Inicio',
          path: '',
          component: () => import('@/views/dashboard/Dashboard'),
        },
        // Pages
        {
          name: 'Usuarios',
          path: '/pages/user',
          component: () => import('@/views/dashboard/pages/UserProfile'),
        },
        {
          name: 'Notifications',
          path: '/components/notifications',
          component: () => import('@/views/dashboard/component/Notifications'),
        },
        {
          name: 'Icons',
          path: '/components/icons',
          component: () => import('@/views/dashboard/component/Icons'),
        },
        {
          name: 'Typography',
          path: '/components/typography',
          component: () => import('@/views/dashboard/component/Typography'),
        },
        // Tables
        {
          name: 'Regular Tables',
          path: '/tables/regular-tables',
          component: () => import('@/views/dashboard/tables/RegularTables'),
        },
        // Maps
        {
          name: 'Google Maps',
          path: '/maps/google-maps',
          component: () => import('@/views/dashboard/maps/GoogleMaps'),
        },
      ],
    },
  ],
})
