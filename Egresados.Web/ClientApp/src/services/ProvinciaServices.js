import axios from 'axios'
import UsuarioService from './UsuarioServices'

export default class ProvinciaServices {
    constructor () {
        // Axios default behavior
        axios.defaults.headers.common.Accept = 'application/json'
        const usuarioService = new UsuarioService()
        axios.defaults.headers.common.Authorization = 'Bearer ' + usuarioService.getToken()
    }

    selectList () {
        return axios.get(process.env.VUE_APP_URL_API + 'provincias/selectList/').then(res => res.data)
    }
}
