import axios from 'axios'
import UsuarioService from '../services/UsuarioServices'

export default class EventoServices {
    constructor () {
        // Axios default behavior
        axios.defaults.headers.common.Accept = 'application/json'
        const usuarioService = new UsuarioService()
        axios.defaults.headers.common.Authorization = 'Bearer ' + usuarioService.getToken()
    }

    selectList () {
        return axios.get(process.env.VUE_APP_URL_API + 'lugarEventos/selectList/').then(res => res.data)
    }
}
