import axios from 'axios'
import UsuarioService from '../services/UsuarioServices'

export default class BolsaTrabajoServices {
     constructor () {
        // Axios default behavior
        axios.defaults.headers.common.Accept = 'application/json'
        const usuarioService = new UsuarioService()
        axios.defaults.headers.common.Authorization = 'Bearer ' + usuarioService.getToken()
    }

    getList () {
        return axios.get(process.env.VUE_APP_URL_API + 'bolsatrabajos/getList/').then(res => res.data)
    }

    save (model) {
        return axios.post(process.env.VUE_APP_URL_API + 'bolsatrabajos/save', model).then(res => res.data)
    }

    delete (id) {
        return axios.delete(process.env.VUE_APP_URL_API + 'bolsatrabajos/delete/' + id).then(res => res.data)
    }

    getOne (id) {
        return axios.get(process.env.VUE_APP_URL_API + 'bolsatrabajos/getOne/' + id).then(res => res.data)
    }
}
