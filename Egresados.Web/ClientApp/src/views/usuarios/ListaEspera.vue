<template>
  <v-card
    class="mx-3 my-auto"
  >
    <v-card-title>
      <v-row>
        <v-col
          cols="12"
          md="3"
        >
          <v-text-field
            v-model="search"
            append-icon="mdi-magnify"
            label="Buscar"
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
            width="1000px"
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
                        md="2"
                      >
                        <v-text-field
                          v-model="form.cedula"
                          label="Cedula"
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
        { text: 'Nombre', value: 'name' },
        { text: 'Apellido', value: 'lastName' },
        { text: 'Cedula', value: 'userName' },
        { text: 'Correo', value: 'email' },
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
    },
    mounted () {
      this.getList()
      this.getListRol()
    },
    methods: {
      showSnackbar (text, color) {
        this.snackbar.active = true
        this.snackbar.text = text
        this.snackbar.color = color
      },
      showSuccess (message) {
        this.$swal({
          titleText: 'Correcto!',
          text: message,
          icon: 'succes',
          confirmButtonText: 'Aceptar',
        })
      },
      showError (message) {
        this.$swal({
          titleText: 'Error!',
          text: message,
          icon: 'error',
          confirmButtonText: 'Aceptar',
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

      editItem (item) {
        this.passwordShow = false
        this.emailShow = false
        this.usuarioServices.getOne(item.id)
          .then(data => {
            this.form = data
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
        this.form.title = 'Nuevo Usuario'
        this.showDialogForm()
      },

      deleteItem () {

      },

      saveItem () {
        this.$refs.form.validate()
        if (this.$refs.form.validate(true)) {
          if (this.passwordShow === true) {
            if (this.form.confirmPassword.trim().toLowerCase() !== this.form.password.trim().toLowerCase()) {
              this.showError('Las claves no coinciden')
            } else {
              this.usuarioServices.save(this.form)
                .then(data => {
                  console.log(data)
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

          if (this.passwordShow === false) {
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
