(function ()
{
    "use strict";

    angular
        .module("gap")
        .controller("indexController", indexController);

    indexController.$inject = ["$scope", "superZapatosFactory", "$rootScope"];

    function indexController($scope, $fact, $rootScope)
    {
        var tabla = $("#tablaInfo").DataTable(
        {
            language: { "url": "/json/language.json" },
            columns:
            [
                { data: "name", title: "Nombre" },
                { data: "address", title: "Dirección" }
            ],
            data: []
        });

        var onConsultarComplete = function (data)
        {
            $fact.recargarGrid(tabla, data.stores);
        };

        var onError = function ()
        {
            $scope.error = "Hubo un error";
        };

        $rootScope.$on("recargarGrid", function () { $scope.inicializar(); });
        $scope.inicializar = function ()
        {
            $fact.consultarTiendas().then(onConsultarComplete, onError);
        };

        $scope.inicializar();
    }
})();
