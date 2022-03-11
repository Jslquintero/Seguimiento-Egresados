/* eslint-disable no-tabs */
import axios from 'axios'

export default class UsuarioServices {
	constructor () {
		// Axios default behavior
		axios.defaults.headers.common.Accept = 'application/json'
	}

	login (model) {
		return axios.post(process.env.VUE_APP_URL_API + 'usuarios/login', model).then(res => res.data)
	}

	registrar (model) {
		return axios.post(process.env.VUE_APP_URL_API + 'usuarios/registrar', model).then(res => res.data)
	}

	recuperarPassword (model) {
		return axios.post(process.env.VUE_APP_URL_API + 'usuarios/recuperarPassword', model).then(res => res.data)
	}

	recuperarPasswordConfirmar (model) {
		return axios.post(process.env.VUE_APP_URL_API + 'usuarios/recuperarPasswordConfirmar', model).then(res => res.data)
	}

	logout () {
		return axios.get(process.env.VUE_APP_URL_API + 'usuarios/logout').then(res => res.data)
	}

	getOne (id) {
		axios.defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token
		return axios.get(process.env.VUE_APP_URL_API + 'usuarios/getOne/' + id).then(res => res.data)
	}

	save (model) {
		axios.defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token
		return axios.post(process.env.VUE_APP_URL_API + 'usuarios/registrar', model).then(res => res.data)
	}

	edit (model) {
		axios.defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token
		return axios.post(process.env.VUE_APP_URL_API + 'usuarios/editar', model).then(res => res.data)
	}

	delete (id) {
		axios.defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token
		return axios.delete(process.env.VUE_APP_URL_API + 'usuarios/delete/' + id).then(res => res.data)
	}

	selectList () {
		axios.defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token
		return axios.get(process.env.VUE_APP_URL_API + 'usuarios/selectList/').then(res => res.data)
	}

	getList () {
		axios.defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token
		return axios.get(process.env.VUE_APP_URL_API + 'usuarios/getList/').then(res => res.data)
	}

	getListRoles () {
		axios.defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token
		return axios.get(process.env.VUE_APP_URL_API + 'usuarios/getListRoles/').then(res => res.data)
	}

	getUser () {
		return JSON.parse(localStorage.getItem('access_user'))
	}

	getToken () {
		return JSON.parse(localStorage.getItem('access_user')).token
	}
}
