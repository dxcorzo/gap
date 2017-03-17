(function () {
    "use strict";

    angular
        .module("gap")
        .controller("crearController", crearController);

    crearController.$inject = ["$scope", "superZapatosFactory", "$rootScope"];

    function crearController($scope, $fact, $rootScope)
    {
        var onComplete = function ()
        {
            $rootScope.$emit("recargarGrid");
            $("#crear-modal").modal("hide");
        };

        var onError = function()
        {
            $scope.error = "Hubo un error";
        };

        $scope.guardar = function()
        {
            $fact.guardarTienda(
            {
                name: $scope.nombre,
                address: $scope.direccion,
            }).then(onComplete, onError);
        };
    }
})();
