<template>
  <v-card>
    <v-card-title>
      Usuarios
    </v-card-title>
    <v-card-title>
      <v-row>
        <v-col
          cols="12"
          md="3"
        >
          <v-text-field
            v-model="search"
            append-icon="mdi-magnify"
            label="Search"
            single-line
            hide-details
          />
        </v-col>
        <v-col
          cols="12"
          md="9"
        />
      </v-row>
    </v-card-title>

    <v-data-table
      :headers="headers"
      :items="list"
      :search="search"
    >
      <template v-slot:item.actions="{ item }">
        <v-icon
          title="Editar"
          class="mr-2"
          @click="editItem(item)"
        >
          mdi-pencil
        </v-icon>
        <!--<v-icon small @click="deleteItem(item)"> mdi-delete</v-icon>-->
      </template>

      <template v-slot:top>
        <v-toolbar flat>
          <v-dialog
            v-model="dialogForm"
            max-width="1200px"
            max-heigth="1200px"
          >
            <v-card>
              <v-form
                ref="form"
                v-model="valid"
                lazy-validation
              >
                <v-card-title>
                  <span class="text-h5">{{ form.title }}</span>
                </v-card-title>
                <v-card-text>
                  <v-container>
                    <v-row>
                      <v-col
                        cols="12"
                        sm="6"
                        md="3"
                      >
                        <v-text-field
                          v-model="form.name"
                          label="Nombre"
                          :rules="[v => !!v || 'Este campo es requiredo']"
                        />
                      </v-col>
                      <v-col
                        cols="12"
                        sm="6"
                        md="3"
                      >
                        <v-text-field
                          v-model="form.lastName"
                          label="Apellido"
                          :rules="[v => !!v || 'Este campo es requiredo']"
                        />
                      </v-col>
                      <v-col
                        cols="12"
                        sm="6"
                        md="4"
                      >
                        <v-text-field
                          v-model="form.email"
                          :readonly="emailShow == false"
                          label="Mail"
                          :rules="[v => !!v || 'Este campo es requiredo']"
                        />
                      </v-col>

                      <v-col
                        cols="12"
                        sm="6"
                        md="2"
                      >
                        <v-select
                          v-model="form.roles"
                          :rules="[v => !!v || 'Este campo es requiredo']"
                          item-value="name"
                          item-text="name"
                          :items="roles"
                          label="Roles"
                          multiple
                          persistent-hint
                          single-line
                          hide-details
                          @change="mostrarProveedores()"
                        />
                      </v-col>
                      <v-col
                        cols="12"
                        sm="6"
                        md="4"
                      >
                        <v-select
                          v-if="proveedorShow"
                          v-model="form.proveedorId"
                          :rules="[v => !!v || 'Este campo es requiredo']"
                          item-value="id"
                          item-text="nombre"
                          :items="proveedores"
                          label="Proveedores"
                          persistent-hint
                          single-line
                          hide-details
                        />
                      </v-col>
                      <v-col
                        cols="12"
                        sm="6"
                        md="4"
                      >
                        <v-text-field
                          v-if="passwordShow"
                          v-model="form.password"
                          label="Clave"
                          :rules="[v => !!v || 'Este campo es requiredo']"
                          :append-icon="inputPassword ? 'mdi-eye-off' : 'mdi-eye'"
                          :type="inputPassword ? 'password' : 'text'"
                          @click:append="() => (inputPassword = !inputPassword)"
                        />
                      </v-col>
                      <v-col
                        cols="12"
                        sm="6"
                        md="4"
                      >
                        <v-text-field
                          v-if="passwordShow"
                          v-model="form.confirmPassword"
                          label="Confirmar clave"
                          :rules="[v => !!v || 'Este campo es requiredo']"
                          :append-icon="repeatInputPassword ? 'mdi-eye-off' : 'mdi-eye'"
                          :type="repeatInputPassword ? 'password' : 'text'"
                          @click:append="() => (repeatInputPassword = !repeatInputPassword)"
                        />
                      </v-col>
                    </v-row>
                  </v-container>
                </v-card-text>
                <v-card-actions>
                  <v-spacer />
                  <v-btn
                    color="blue darken-1"
                    text
                    @click="dialogForm = false"
                  >
                    Cancelar
                  </v-btn>
                  <v-btn
                    color="blue darken-1"
                    text
                    @click="saveItem"
                  >
                    Guardar
                  </v-btn>
                </v-card-actions>
              </v-form>
            </v-card>
          </v-dialog>
          <!--<v-dialog v-model="dialogDelete" max-width="500px">
                        <v-card>
                            <v-card-title class="text-h5">Desea eliminar este elemento ?</v-card-title>
                            <v-card-actions>
                                <v-spacer></v-spacer>
                                <v-btn color="blue darken-1" text @click="dialogDelete = false">Cancelar</v-btn>
                                <v-btn color="blue darken-1" text @click="deleteItem">Aceptar</v-btn>
                                <v-spacer></v-spacer>
                            </v-card-actions>
                        </v-card>
                    </v-dialog>-->
          <v-snackbar
            v-model="snackbar.active"
            :timeout="3000"
            :color="snackbar.color"
          >
            {{ snackbar.text }}
            <template v-slot:action="{ attrs }">
              <v-btn
                color="pink"
                text
                v-bind="attrs"
                @click="dialogForm = false"
              >
                Close
              </v-btn>
            </template>
          </v-snackbar>
        </v-toolbar>
      </template>
    </v-data-table>

    <v-card-text>
      <v-row>
        <v-col>
          <v-btn
            x-large
            color="#008C95"
            rounded
            dark
            @click="addItem"
          >
            Agregar Usuario
          </v-btn>
        </v-col>
        <v-col />
      </v-row>
    </v-card-text>
  </v-card>
</template>

<script>
  import UsuarioServices from '../../services/UsuarioServices'
  import ProveedorServices from '../../services/ProveedorServices'

  export default {
    name: 'Listar',
    data: () => ({
      valid: true,
      search: '',
      dialogForm: false,
      dialogDelete: false,
      passwordShow: false,
      proveedorShow: false,
      emailShow: false,
      form: {},
      list: [],
      roles: [],
      proveedores: [],
      headers: [
        { text: 'Email', value: 'email' },
        { text: 'Nombre', value: 'name' },
        { text: 'Apellido', value: 'lastName' },
        { text: 'Roles', value: 'roles' },
        { text: 'Acciones', value: 'actions' },
      ],
      snackbar: {
        active: false,
        text: '',
        color: '',
      },
      usuarioServices: null,
      inputPassword: String,
      repeatInputPassword: String,
    }),
    created () {
      this.usuarioServices = new UsuarioServices()
      this.proveedorServices = new ProveedorServices()
    },
    mounted () {
      this.getList()
      this.getListRol()
      this.getListProveedor()
    },
    methods: {
      showSnackbar (text, color) {
        this.snackbar.active = true
        this.snackbar.text = text
        this.snackbar.color = color
      },
      showSuccess (message) {
        this.$toastr.Add({
          name: 'UniqueToastName', // this is give you ability to use removeByName method
          title: 'Success Message', // Toast Title
          msg: message,
          type: 'success',
        })
      },

      showError (message) {
        this.$toastr.Add({
          name: 'UniqueToastName', // this is give you ability to use removeByName method
          title: 'Error Message', // Toast Title
          msg: message,
          type: 'error',
        })
      },

      showDialogForm () {
        this.dialogForm = true
      },

      showDialogDelete () {
        this.dialogDelete = false
      },

      getList () {
        this.usuarioServices.getList()
          .then(data => {
            this.list = data
          })
          .catch(error => {
            this.showError(error.response.data.title)
            console.log(error.response.status)
          })
      },

      getListRol () {
        this.usuarioServices.getListRoles()
          .then(data => {
            this.roles = data
          })
          .catch(error => {
            this.showError(error.response.data.title)
            console.log(error.response.status)
          })
      },

      getListProveedor () {
        this.proveedorServices.selectList()
          .then(data => {
            this.proveedores = data
            console.log(this.proveedor)
          })
          .catch(error => {
            this.showError(error.response.data.title)
            console.log(error.response.status)
          })
      },

      mostrarProveedores () {
        if (this.form.roles.includes('Proveedor')) {
          this.proveedorShow = true
        } else {
          this.proveedorShow = false
        }
      },

      editItem (item) {
        this.passwordShow = false
        this.emailShow = false
        this.proveedorShow = false
        this.usuarioServices.getOne(item.id)
          .then(data => {
            this.form = data
            this.mostrarProveedores()
            this.form.title = 'Editar'
            this.dialogForm = true
          })
          .catch(error => {
            this.showError(error.response.data.title)
            console.log(error.response.status)
          })
      },

      addItem () {
        this.form = {}
        this.passwordShow = true
        this.emailShow = true
        this.proveedorShow = false
        this.form.title = 'Nuevo'
        this.showDialogForm()
        this.showSnackbar('Nuevo Usuario', 'snackColor')
      },

      deleteItem () {

      },

      saveItem () {
        this.$refs.form.validate()
        if (this.$refs.form.validate(true)) {
          if (this.passwordShow == true) {
            if (this.form.confirmPassword.trim().toLowerCase() != this.form.password.trim().toLowerCase()) {
              this.showError('Las claves no coinciden')
            } else {
              this.usuarioServices.save(this.form)
                .then(data => {
                  if (data === '') {
                    this.showSuccess('Usuario creado correctamente.')
                    this.form = ''
                    this.getList()
                  }
                })
                .catch(error => {
                  this.showError(error.response.data.title)
                })
            }
          }

          if (this.passwordShow == false) {
            this.usuarioServices.edit(this.form)
              .then(data => {
                if (data === '') {
                  this.showSuccess('Usuario editado correctamente.')

                  this.editItem(this.form)
                }
              })
              .catch(error => {
                this.showError(error.response.data.title)
              })
          }
        }
      },

    },
  }
</script>
