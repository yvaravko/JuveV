(function() {
    function playerTypesController($resource) {
        var vm = this;
        vm.playerTypes = [];

        $resource('api/playertype').query(function (response) {
            angular.copy(response, vm.playerTypes);
        });
    }

    angular.module('admin-main').controller('playerTypes', playerTypesController);
})();