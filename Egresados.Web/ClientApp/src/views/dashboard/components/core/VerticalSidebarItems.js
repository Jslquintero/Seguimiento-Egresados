export default [
    { header: 'Administrador' },
    {
        group: '/usuarios',
        model: false,
        icon: 'mdi-account',
        title: 'Usuarios',
        class: 'two-column',
        to: '/usuarios',
        autorizeRoles: 'Administrativo',
        children: [
            {
                icon: 'mdi-account',
                title: 'Listado de Usuarios',
                to: 'listar',
                autorizeRoles: 'Administrativo',
            },
            {
                icon: 'mdi-account-box-multiple',
                title: 'Usuarios en espera',
                to: 'listaEspera',
                autorizeRoles: 'Administrativo',
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
]
