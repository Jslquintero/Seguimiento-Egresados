export default [
    {
    group: '/dashboards',
    model: false,
    icon: 'home',
    title: 'Dashboards',
    class: 'two-column',
    to: '/dashboards',
    children: [
      {
        icon: 'mdi mdi-adjust',
        title: 'Minimal',
        to: 'minimal',
      },
      {
        icon: 'mdi mdi-adjust',
        title: 'Analytical',
        to: 'analytical',
      },
      {
        icon: 'mdi mdi-adjust',
        title: 'Demographical',
        to: 'demographical',
      },
      {
        icon: 'mdi mdi-adjust',
        title: 'Modern',
        to: 'modern',
      },
    ],
  },

  {
    group: '/apps',
    model: false,
    icon: 'box',
    title: 'Apps',
    to: '/apps',
    children: [
      {
        icon: 'mdi mdi-comment-outline',
        title: 'Chat',
        to: '/apps/chat',
      },

      {
        icon: 'mdi mdi-calendar',
        title: 'Calendar',
        to: '/apps/fullcalendar',
      },
      {
        icon: 'mdi mdi-shopping',
        title: 'Ecommerce-Shop',
        to: '/apps/shop',
      },
      {
        icon: 'mdi mdi-phone-classic',
        title: 'Contact',
        to: '/apps/contact',
      },
      {
        icon: 'mdi mdi-phone',
        title: 'Contact List',
        to: '/apps/contact-list',
      },
      {
        icon: 'mdi mdi-phone-voip',
        title: 'Contact Grid',
        to: '/apps/contact-grid',
      },
      {
        icon: 'mdi mdi-email',
        title: 'Email',
        to: '/apps/email/inbox',
      },
      {
        icon: 'mdi mdi-playlist-plus',
        title: 'Todo',
        to: '/apps/email/todo',
      },
    ],
  },

  {
    group: '/uicomponents',
    model: false,
    icon: 'cpu',
    title: 'Ui',
    extraclass: 'mega-dropdown',
    to: '/components',
    children: [
      {
        title: 'Alerts',
        icon: 'mdi mdi-alert',
        to: '/components/alerts',
      },
      {
        title: 'Avatar',
        icon: 'mdi mdi-account-circle',
        to: '/components/avatar',
      },
      {
        title: 'Badge',
        icon: 'mdi mdi-relative-scale',
        to: '/components/badge',
      },
      {
        title: 'Banner',
        icon: 'mdi mdi-box-shadow',
        to: '/components/banner',
      },
      {
        title: 'Appbar',
        icon: 'mdi mdi-arrange-bring-to-front',
        to: '/components/appbar',
      },
      {
        title: 'Toolbar',
        icon: 'mdi mdi-table-column-plus-after',
        to: '/components/toolbar',
      },
      {
        title: 'Systembar',
        icon: 'mdi mdi-format-float-left',
        to: '/components/systembar',
      },
      {
        title: 'Bottom Navigation',
        icon: 'mdi mdi-border-bottom',
        to: '/components/bottomnavigation',
      },
      {
        title: 'Bottomsheet',
        icon: 'mdi mdi-format-wrap-top-bottom',
        to: '/components/bottomsheet',
      },
      {
        title: 'Breadcrumb',
        icon: 'mdi mdi-equal',
        to: '/components/breadcrumb',
      },
      {
        title: 'Buttons',
        icon: 'mdi mdi-toggle-switch',
        to: '/components/buttons',
      },
      {
        title: 'Fab',
        icon: 'mdi mdi-react',
        to: '/components/fab',
      },
      {
        title: 'Cards',
        icon: 'mdi mdi-cards-outline',
        to: '/components/cards',
      },
      {
        title: 'Carousel',
        icon: 'mdi mdi-view-carousel',
        to: '/components/carousel',
      },
      {
        title: 'Chips',
        icon: 'mdi mdi-checkbox-multiple-blank-outline',
        to: '/components/chips',
      },
      {
        title: 'Dialogs',
        icon: 'mdi mdi-tablet',
        to: '/components/dialogs',
      },
      {
        title: 'Dividers',
        icon: 'mdi mdi-bandcamp',
        to: '/components/dividers',
      },
      {
        title: 'Expansion Panel',
        icon: 'mdi mdi-credit-card-multiple',
        to: '/components/expansionpanel',
      },
      {
        title: 'Footer',
        icon: 'mdi mdi-view-agenda',
        to: '/components/footer',
      },
      {
        title: 'Overflow Buttons',
        icon: 'mdi mdi-window-open',
        to: '/components/overflow-buttons',
      },
      {
        title: 'Grids',
        icon: 'mdi mdi-grid',
        to: '/components/grids',
      },
      {
        title: 'Button Group',
        icon: 'mdi mdi-hexagon-multiple',
        to: '/components/button-group',
      },
      {
        title: 'Chip Group',
        icon: 'mdi mdi-image-filter-vintage',
        to: '/components/chip-group',
      },
      {
        title: 'Item Group',
        icon: 'mdi mdi-layers',
        to: '/components/item-group',
      },
      {
        title: 'List Item Group',
        icon: 'mdi mdi-playlist-plus',
        to: '/components/listitem-group',
      },
      {
        title: 'Slide Group',
        icon: 'mdi mdi-recycle',
        to: '/components/slide-group',
      },
      {
        title: 'Windows',
        icon: 'mdi mdi-window-maximize',
        to: '/components/windows',
      },
      {
        title: 'Hover',
        icon: 'mdi mdi-white-balance-sunny',
        to: '/components/hover',
      },
      {
        title: 'Icons',
        icon: 'mdi mdi-unity',
        to: '/components/icons',
      },
      {
        title: 'Images',
        icon: 'mdi mdi-image-area',
        to: '/components/images',
      },

      {
        title: 'Menus',
        icon: 'mdi mdi-launch',
        to: '/components/menus',
      },
      {
        title: 'Navigation Drawers',
        icon: 'mdi mdi-image-broken-variant',
        to: '/components/navigation-drawers',
      },
      {
        title: 'Overlay',
        icon: 'mdi mdi-arrange-bring-forward',
        to: '/components/overlay',
      },
      {
        title: 'Pagination',
        icon: 'mdi mdi-book-open-variant',
        to: '/components/pagination',
      },
      {
        title: 'Parallex',
        icon: 'mdi mdi-book-plus',
        to: '/components/parallex',
      },
      {
        title: 'Color Pickers',
        icon: 'mdi mdi-grease-pencil',
        to: '/components/color-pickers',
      },
      {
        title: 'Date Pickers',
        icon: 'mdi mdi-calendar-multiple',
        to: '/components/date-pickers',
      },
      {
        title: 'Time Pickers',
        icon: 'mdi mdi-clock-fast',
        to: '/components/time-pickers',
      },
      {
        title: 'Progress Circular',
        icon: 'mdi mdi-compass',
        to: '/components/progress-circular',
      },
      {
        title: 'Progress Linear',
        icon: 'mdi mdi-crosshairs',
        to: '/components/progress-linear',
      },
      {
        title: 'Rating',
        icon: 'mdi mdi-star-circle',
        to: '/components/rating',
      },
      {
        title: 'Sheet',
        icon: 'mdi mdi-table-large',
        to: '/components/sheet',
      },
      {
        title: 'SkeletonLoaders',
        icon: 'mdi mdi-television-guide',
        to: '/components/skeleton-loaders',
      },
      {
        title: 'Snackbar',
        icon: 'mdi mdi-trello',
        to: '/components/snackbar',
      },
      {
        title: 'Sparkline',
        icon: 'mdi mdi-chart-areaspline',
        to: '/components/sparkline',
      },
      {
        title: 'Steppers',
        icon: 'mdi mdi-chart-gantt',
        to: '/components/steppers',
      },
      {
        title: 'Subheaders',
        icon: 'mdi mdi-clipboard-outline',
        to: '/components/subheaders',
      },
      {
        title: 'Tabs',
        icon: 'mdi mdi-sort-variant',
        to: '/components/tabs',
      },
      {
        title: 'Timeline',
        icon: 'mdi mdi-clock-end',
        to: '/components/timeline',
      },
      {
        title: 'Tooltips',
        icon: 'mdi mdi-image-filter-vintage',
        to: '/components/tooltips',
      },
      {
        title: 'Treeview',
        icon: 'mdi mdi-webhook',
        to: '/components/treeview',
      },
      {
        title: 'Colors',
        icon: 'mdi mdi-format-color-fill',
        to: '/style-animation/colors',
      },
      {
        title: 'Content',
        icon: 'mdi mdi-blur-linear',
        to: '/style-animation/content',
      },
      {
        title: 'Display',
        icon: 'mdi mdi-application',
        to: '/style-animation/display',
      },
      {
        title: 'Elevation',
        icon: 'mdi mdi-assistant',
        to: '/style-animation/levation',
      },
      {
        title: 'Flex',
        icon: 'mdi mdi-box-cutter',
        to: '/style-animation/flex',
      },
      {
        title: 'Float',
        icon: 'mdi mdi-alpha',
        to: '/style-animation/float',
      },
      {
        title: 'Spacing',
        icon: 'mdi mdi-bridge',
        to: '/style-animation/spacing',
      },
      {
        title: 'Text',
        icon: 'mdi mdi-bowling',
        to: '/style-animation/text',
      },
      {
        title: 'Typography',
        icon: 'mdi mdi-sort',
        to: '/style-animation/typography',
      },
      {
        title: 'Transitions',
        icon: 'mdi mdi-text-shadow',
        to: '/style-animation/transitions',
      },
    ],
  },

  {
    group: '/charts',
    model: false,
    icon: 'pie-chart',
    title: 'Charts',
    to: '/charts/apexcharts',
  },

  {
    group: '/form-elements',
    model: false,
    icon: 'file-text',
    title: 'Forms',
    extraclass: 'two-column',
    to: '/form-elements',
    children: [
      {
        title: 'Autocompletes',
        icon: 'mdi mdi-priority-low',
        to: '/form-elements/feautocompletes',
      },
      {
        title: 'Combobox',
        icon: 'mdi mdi-rounded-corner',
        to: '/form-elements/fecombobox',
      },
      {
        title: 'File Inputs',
        icon: 'mdi mdi-select-all',
        to: '/form-elements/fefileinputs',
      },
      {
        title: 'Inputs',
        icon: 'mdi mdi-shape-plus',
        to: '/form-elements/feinputs',
      },
      {
        title: 'Overflow Buttons',
        icon: 'mdi mdi-toggle-switch-off',
        to: '/form-elements/feoverflowbuttons',
      },
      {
        title: 'Selection Controls',
        icon: 'mdi mdi-relative-scale',
        to: '/form-elements/feselectioncontrols',
      },
      {
        title: 'Selects',
        icon: 'mdi mdi-tab-unselected',
        to: '/form-elements/feselects',
      },
      {
        title: 'Sliders',
        icon: 'mdi mdi-vector-difference-ba',
        to: '/form-elements/fesliders',
      },
      {
        title: 'Textareas',
        icon: 'mdi mdi-code-greater-than',
        to: '/form-elements/fetextareas',
      },
      {
        title: 'Textfields',
        icon: 'mdi mdi-border-vertical',
        to: '/form-elements/fetextfields',
      },

      {
        title: 'Form Action',
        icon: 'mdi mdi-code-equal',
        to: '/form-layouts/flformaction',
      },
      {
        title: 'Form Basic',
        icon: 'mdi mdi-content-duplicate',
        to: '/form-layouts/flformbasic',
      },
      {
        title: 'Form Wizard',
        icon: 'mdi mdi-cube-send',
        to: '/form-layouts/formwizard',
      },
      {
        title: 'Form Horizontal',
        icon: 'mdi mdi-cards-variant',
        to: '/form-layouts/flformhorizontal',
      },
      {
        title: 'Form Validation',
        icon: 'mdi mdi-credit-card-scan',
        to: '/form-layouts/formvalidation',
      },
      {
        title: 'Drag n Drop',
        icon: 'mdi mdi-package-variant-closed',
        to: '/extra-components/dragndrop',
      },
      {
        title: 'Lists',
        icon: 'mdi mdi-format-list-bulleted-type',
        to: '/components/lists',
      },
    ],
  },

  {
    group: '/tables',
    model: false,
    icon: 'codepen',
    title: 'Tables',
    to: '/tables',
    children: [
      {
        title: 'Simple Table',
        icon: 'mdi mdi-table',
        to: '/tables/tablesimple',
      },
      {
        title: 'Datatable',
        icon: 'mdi mdi-table-column-width',
        to: '/tables/tabledatatable',
      },
      {
        title: 'Data Iterators',
        icon: 'mdi mdi-table-edit',
        to: '/tables/tabledataiterators',
      },
    ],
  },

  {
    group: '/extra',
    model: false,
    icon: 'archive',
    title: 'Extra',
    to: '/icons',
    children: [
      {
        title: 'Boxed Login',
        icon: 'mdi mdi-account-key',
        to: '/authentication/boxedlogin',
      },
      {
        title: 'Login',
        icon: 'mdi mdi-account-key',
        to: '/authentication/fulllogin',
      },
      {
        title: 'Boxed Register',
        icon: 'mdi mdi-account-plus',
        to: '/authentication/boxedregister',
      },
      {
        title: 'Register',
        icon: 'mdi mdi-account-plus',
        to: '/authentication/fullregister',
      },
      {
        title: 'Error',
        icon: 'mdi mdi-alert-outline',
        to: '/authentication/error',
      },
      {
        title: 'Material',
        icon: 'mdi mdi-emoticon',
        to: '/icons/materialicons',
      },
      {
        title: 'Font Awesome',
        icon: 'mdi mdi-emoticon-cool',
        to: '/icons/fontawesomeicons',
      },
      {
        title: 'Themify',
        icon: 'mdi mdi-chart-bubble',
        to: '/icons/themifyicons',
      },
      {
        title: 'Simple line',
        icon: 'mdi mdi-image-broken-variant',
        to: '/icons/simplelineicons',
      },
    ],
  },
]
