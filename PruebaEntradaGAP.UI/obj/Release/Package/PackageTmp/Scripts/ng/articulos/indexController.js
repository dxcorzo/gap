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
                { data: "description", title: "Descripción" },
                { data: "price", title: "Precio" },
                { data: "total_in_shelf", title: "En Vitrina" },
                { data: "total_in_vault", title: "En Bodega" },
                { data: "store.name", title: "Tienda" }
            ],
            data: []
        });

        var onConsultarProductosComplete = function (data)
        {
            $fact.recargarGrid(tabla, data.articles);
        };

        var onError = function()
        {
            $scope.error = "Hubo un error";
        };

        $rootScope.$on("recargarGrid", function () { $scope.inicializar(); });
        $scope.inicializar = function()
        {
            $fact.consultarArticulos().then(onConsultarProductosComplete, onError);
        };

        $scope.inicializar();
    }
})();
