(function () {
    "use strict";

    angular
        .module("gap")
        .factory("superZapatosFactory", superZapatosFactory);

    superZapatosFactory.$inject = ["$http"];

    function superZapatosFactory($http)
    {
        var authdata = "my_user" + ":" + "my_password";
        $http.defaults.headers.common["Authorization"] = "Basic " + authdata;

        var generarErrorIntencionado = function ()
        {
            return $http.get("/services/raise-error/").then(function (r) { return r.data; });
        };

        var consultarArticulos = function()
        {
            return $http.get("/services/articles/").then(function(r) { return r.data; });
        };

        var consultarTiendas = function ()
        {
            return $http.get("/services/stores/").then(function (r) { return r.data; });
        };

        var consultarArticulo = function (id)
        {
            return $http.get("/services/articles/" + id).then(function (r) { return r.data; });
        };

        var guardarArticulo = function(data)
        {
            return $http.post("/services/articles/create", data).then(function (r) { return r.data; });
        };

        var guardarTienda = function (data)
        {
            return $http.post("/services/stores/create", data).then(function (r) { return r.data; });
        };

        var editarTienda = function (data)
        {
            return $http.post("/services/stores/update", data).then(function (r) { return r.data; });
        };

        var recargarGrid = function(tabla, data)
        {
            tabla.clear().draw();
            tabla.rows.add(data).draw();
        };

        var service =
        {
            consultarArticulos: consultarArticulos,
            consultarTiendas: consultarTiendas,
            guardarArticulo: guardarArticulo,
            consultarArticulo: consultarArticulo,
            guardarTienda: guardarTienda,
            recargarGrid: recargarGrid,
            editarTienda: editarTienda,
            generarErrorIntencionado: generarErrorIntencionado
        };

        return service;
    }
})();