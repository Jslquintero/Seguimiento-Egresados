"use strict";

Object.defineProperty(exports, "__esModule", {
  value: true
});
exports["default"] = void 0;

var _axios = _interopRequireDefault(require("axios"));

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { "default": obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } }

function _createClass(Constructor, protoProps, staticProps) { if (protoProps) _defineProperties(Constructor.prototype, protoProps); if (staticProps) _defineProperties(Constructor, staticProps); return Constructor; }

var UsuarioServices =
/*#__PURE__*/
function () {
  function UsuarioServices() {
    _classCallCheck(this, UsuarioServices);

    // Axios default behavior
    _axios["default"].defaults.headers.common.Accept = 'application/json';
  }

  _createClass(UsuarioServices, [{
    key: "login",
    value: function login(model) {
      debugger;
      return _axios["default"].post(process.env.VUE_APP_URL_API + 'usuarios/login', model).then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "registrar",
    value: function registrar(model) {
      return _axios["default"].post(process.env.VUE_APP_URL_API + 'usuarios/registrar', model).then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "recuperarPassword",
    value: function recuperarPassword(model) {
      return _axios["default"].post(process.env.VUE_APP_URL_API + 'usuarios/recuperarPassword', model).then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "recuperarPasswordConfirmar",
    value: function recuperarPasswordConfirmar(model) {
      return _axios["default"].post(process.env.VUE_APP_URL_API + 'usuarios/recuperarPasswordConfirmar', model).then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "logout",
    value: function logout() {
      return _axios["default"].get(process.env.VUE_APP_URL_API + 'usuarios/logout').then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "getOne",
    value: function getOne(id) {
      _axios["default"].defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token;
      return _axios["default"].get(process.env.VUE_APP_URL_API + 'usuarios/getOne/' + id).then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "save",
    value: function save(model) {
      _axios["default"].defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token;
      return _axios["default"].post(process.env.VUE_APP_URL_API + 'usuarios/registrar', model).then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "edit",
    value: function edit(model) {
      _axios["default"].defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token;
      return _axios["default"].post(process.env.VUE_APP_URL_API + 'usuarios/editar', model).then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "delete",
    value: function _delete(id) {
      _axios["default"].defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token;
      return _axios["default"]["delete"](process.env.VUE_APP_URL_API + 'usuarios/delete/' + id).then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "selectList",
    value: function selectList() {
      _axios["default"].defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token;
      return _axios["default"].get(process.env.VUE_APP_URL_API + 'usuarios/selectList/').then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "getList",
    value: function getList() {
      _axios["default"].defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token;
      return _axios["default"].get(process.env.VUE_APP_URL_API + 'usuarios/getList/').then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "getListRoles",
    value: function getListRoles() {
      _axios["default"].defaults.headers.common.Authorization = 'Bearer ' + JSON.parse(localStorage.getItem('access_user')).token;
      return _axios["default"].get(process.env.VUE_APP_URL_API + 'usuarios/getListRoles/').then(function (res) {
        return res.data;
      });
    }
  }, {
    key: "getUser",
    value: function getUser() {
      return JSON.parse(localStorage.getItem('access_user'));
    }
  }, {
    key: "getToken",
    value: function getToken() {
      return JSON.parse(localStorage.getItem('access_user')).token;
    }
  }]);

  return UsuarioServices;
}();

exports["default"] = UsuarioServices;