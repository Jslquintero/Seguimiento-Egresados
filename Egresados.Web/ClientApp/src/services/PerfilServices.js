import axios from 'axios'
import UsuarioService from './UsuarioServices'

export default class PerfilServices {
    constructor () {
        // Axios default behavior
        axios.defaults.headers.common.Accept = 'application/json'
        const usuarioService = new UsuarioService()
        axios.defaults.headers.common.Authorization = 'Bearer ' + usuarioService.getToken()
    }

    getList () {
        return axios.get(process.env.VUE_APP_URL_API + 'perfiles/getList/').then(res => res.data)
    }

    save (model) {
        return axios.post(process.env.VUE_APP_URL_API + 'perfiles/save', model).then(res => res.data)
    }

    getOne (id) {
        return axios.get(process.env.VUE_APP_URL_API + 'perfiles/getOne/' + id).then(res => res.data)
    }
}
