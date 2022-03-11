export default [
    { header: 'Administracion' },
    {
        group: '/usuarios',
        model: false,
        icon: 'users',
        title: 'Usuarios',
        class: 'two-column',
        to: '/usuarios',
        autorizeRoles: 'Compras',
        children: [
            {
                icon: 'disc',
                title: 'Listado de Usuarios',
                to: 'listar',
                autorizeRoles: 'Compras',
            },
        ],
    },
    {
        group: '/ordenCompras',
        model: false,
        icon: 'shopping-cart',
        title: 'Ordenes de Compra',
        class: 'two-column',
        to: '/ordenCompras',
        autorizeRoles: '',
        children: [
            {
                icon: 'disc',
                title: 'Importar Orden',
                to: 'Importar',
                autorizeRoles: 'Compras',
            },
            {
                icon: 'disc',
                title: 'Listado de Ordenes',
                to: 'Listar',
                autorizeRoles: '',
            },
            {
                icon: 'disc',
                title: 'Fill Rate',
                to: 'FillRate',
                autorizeRoles: '',
            },
        ],
    },
    {
        group: '/productos',
        model: false,
        icon: 'file-text',
        title: 'Productos',
        class: 'two-column',
        to: '/productos',
        autorizeRoles: '',
        children: [
            {
                icon: 'disc',
                title: 'Listar',
                to: 'Listar',
                autorizeRoles: '',
            },
            {
                icon: 'disc',
                title: 'Fill Rate',
                to: 'FillRate',
                autorizeRoles: 'Compras',
            },
        ],
    },
  ]
