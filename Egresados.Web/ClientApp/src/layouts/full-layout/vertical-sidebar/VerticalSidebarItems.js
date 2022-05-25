export default [
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
            {
                icon: 'mdi-account-box-multiple',
                title: 'Usuarios en espera',
                to: 'listaEspera',
                autorizeRoles: 'Administrador',
            },
        ],
    },

    {
        group: '/eventos',
        model: false,
        icon: 'mdi-account',
        title: 'Eventos',
        class: 'two-column',
        to: '/eventos',
        autorizeRoles: 'RecursoHumano',
        children: [
            {
                icon: 'mdi-account',
                title: 'Crear',
                to: 'crearEditar',
                autorizeRoles: 'RecursoHumano',
            },
            {
                icon: 'mdi-account-box-multiple',
                title: 'Lista de Eventos',
                to: 'listar',
                autorizeRoles: 'RecursoHumano',
            },
        ],
    },

    // { header: 'Egresado' },
    // {
    //    group: '/usuarios',
    //    model: false,
    //    icon: 'mdi-account',
    //    title: 'Usuarios',
    //    class: 'two-column',
    //    to: '/usuarios',
    //    autorizeRoles: 'Egresado',
    //    children: [
    //        {
    //            icon: 'mdi-account',
    //            title: 'Listado de Usuarios',
    //            to: 'listar',
    //            autorizeRoles: 'Egresado',
    //        },
    //        {
    //            icon: 'mdi-account-box-multiple',
    //            title: 'Usuarios en espera',
    //            to: 'listaEspera',
    //            autorizeRoles: 'Egresado',
    //        },
    //    ],
    // },
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
]
