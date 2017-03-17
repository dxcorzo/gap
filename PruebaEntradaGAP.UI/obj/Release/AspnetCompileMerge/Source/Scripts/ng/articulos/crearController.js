(function () {
    "use strict";

    angular
        .module("gap")
        .controller("crearController", crearController);

    crearController.$inject = ["$scope", "superZapatosFactory", "$rootScope"];

    function crearController($scope, $fact, $rootScope)
    {
        var onConsultarTiendasComplete = function (data)
        {
            $scope.tiendas = data.stores;
        };

        var onGuardarArticuloComplete = function()
        {
            $rootScope.$emit("recargarGrid");
            $("#crear-modal").modal("hide");
        };

        var onError = function()
        {
            $scope.error = "Hubo un error";
        };

        $scope.inicializar = function()
        {
            $fact.consultarTiendas().then(onConsultarTiendasComplete, onError);
        };

        $scope.guardarArticulo = function()
        {
            $fact.guardarArticulo(
            {
                store_id: $scope.tienda.id,
                name: $scope.nombre,
                description: $scope.descripcion,
                price: $scope.precio,
                total_in_shelf: $scope.totalVitrina,
                total_in_vault: $scope.totalBodega
            }).then(onGuardarArticuloComplete, onError);
        };

        $scope.inicializar();
    }
})();
