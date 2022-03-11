<template>
  <v-navigation-drawer
    id="main-sidebar"
    v-model="Sidebar_drawer"
    :dark="SidebarColor !== 'white'"
    :color="SidebarColor"
    mobile-breakpoint="961"
    clipped
    :right="$vuetify.rtl"
    mini-variant-width="70"
    :expand-on-hover="expandOnHover"
    app
    class="horizontal-side"
  >
    <v-container class="py-0">
      <!-- ------------------------------------- -->
      <!-- start navigation -->
      <!-- ------------------------------------- -->
      <ul class="horizontal-navbar">
        <li
          v-for="(item, i) in items"
          :key="i"
        >
          <!-- ------------------------------------- -->
          <!-- single item -->
          <!-- ------------------------------------- -->
          <ul v-if="!item.children">
            <li class="single-item">
              <router-link :to="item.to">
                <feather :type="item.icon" />
                <span>{{ item.title }}</span>
              </router-link>
            </li>
          </ul>
          <!-- ------------------------------------- -->
          <!-- start Item with Dropdown -->
          <!-- ------------------------------------- -->
          <div v-else>
            <ul
              class="first-level"
              :class="item.extraclass"
            >
              <li>
                <a
                  class="d-flex align-center"
                  :class="{ 'is-link-active': subIsActive(item.to) }"
                >
                  <div class="d-flex align-center">
                    <feather :type="item.icon" />
                    <span>{{ item.title }}</span>
                    <i class="mdi mdi-chevron-down ml-1 mr-0 sidebar-icon" />
                  </div>
                  <!-- ------------------------------------- -->
                  <!-- Start Dropdown Item -->
                  <!-- ------------------------------------- -->
                  <ul
                    class="second-level"
                    :class="item.class"
                  >
                    <li
                      v-for="(child, i) in item.children"
                      :key="i"
                    >
                      <router-link :to="child.to">
                        <div class="d-flex align-center">
                          <i :class="child.icon" />
                          <span>{{ child.title }}</span>
                        </div>
                      </router-link>
                    </li>
                  </ul>
                  <!-- ------------------------------------- -->
                  <!-- End Dropdown Item -->
                  <!-- ------------------------------------- -->
                </a>
              </li>
            </ul>
          </div>
          <!-- ------------------------------------- -->
          <!-- end Item with Dropdown -->
          <!-- ------------------------------------- -->
        </li>
      </ul>
      <!-- ------------------------------------- -->
      <!-- end navigation -->
      <!-- ------------------------------------- -->
    </v-container>
  </v-navigation-drawer>
</template>

<script>
  import { mapState } from 'vuex'
  import HorizontalSidebarItems from './HorizontalSidebarItems'
  export default {
    name: 'HorizontalSidebar',
    props: {
      expandOnHover: {
        type: Boolean,
        default: false,
      },
    },
    data: () => ({
      items: HorizontalSidebarItems,
    }),
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

    methods: {
      // This is for the parent active if child has router link exact active
      subIsActive (input) {
        const paths = Array.isArray(input) ? input : [input]
        return paths.some((path) => {
          return this.$route.path.indexOf(path) === 0 // current path starts with this path string
        })
      },
    },
  }
</script>
<style lang="scss">
.horizontal-navbar {
  padding: 0px;
  margin: 0px;
  align-items: center;
  display: flex;
  ul {
    padding: 0px;
    margin: 0px;
  }
  li {
    list-style: none;
    a {
      line-height: 35px;
      color: rgba(255, 255, 255, 0.87);
      &.is-link-active {
        color: rgba(255, 255, 255, 1);
        i {
          color: rgba(255, 255, 255, 1);
        }
      }
      &:hover {
        color: rgba(255, 255, 255, 1);
        i {
          color: rgba(255, 255, 255, 1);
        }
      }
      i {
        margin-right: 10px;
        font-size: 24px;
        width: 20px;
        color: rgba(255, 255, 255, 0.54);
      }
    }
  }
  > li {
    padding: 5px 10px;
  }
  .first-level {
    position: relative;
    a {
      padding: 15px 0;

      .second-level {
        li {
          a {
            i {
              font-size: 20px;
            }
            &.router-link-active {
              color: $primary !important;
              i {
                color: $primary !important;
              }
            }
          }
        }
      }
    }
    a:hover {
      .second-level {
        display: block;
        li {
          a {
            color: rgba(0, 0, 0, 0.65);
            i {
              color: rgba(0, 0, 0, 0.54);
            }
            &:hover {
              color: rgba(0, 0, 0, 1);
              i {
                color: rgba(0, 0, 0, 1);
              }
            }
          }
        }
      }
    }
  }
  .second-level {
    position: absolute;
    display: none;
    background: white;
    top: 64px;
    padding: 8px;
    color: inherit;
    min-width: 230px;
    box-shadow: 7px 15px 20px 0px rgba(0, 0, 0, 0.1);
    -webkit-box-shaodw: 7px 15px 20px 0px rgba(0, 0, 0, 0.1);
    li {
      padding: 8px 10px;
    }
  }
}

.v-navigation-drawer.theme--light {
  .horizontal-navbar {
    li {
      a {
        color: rgba(0, 0, 0, 0.65);
        &.is-link-active {
          color: rgba(0, 0, 0, 1);
          i {
            color: rgba(0, 0, 0, 1);
          }
        }
        i {
          width: 20px;
          color: rgba(0, 0, 0, 0.54);
        }
        &:hover {
          color: rgba(0, 0, 0, 1);
          i {
            color: rgba(0, 0, 0, 1);
          }
        }
      }
    }
  }
}
</style>
