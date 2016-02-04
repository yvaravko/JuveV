(function() {
    var app = angular.module('admin-main');
    app.controller('playersCtrl', function ($resource, $window) {
        var vm = this;
        vm.players = [];
        vm.isLoading = true;
        
        $resource('/api/player').query(function (response) {
            angular.copy(response, vm.players);
            vm.isLoading = false;
        });

        vm.search = function(keyEvent) {
            if (keyEvent.which === 13) {
                $resource('/api/player/search/:value', { value: vm.searchValue }).query(function(response) {
                    angular.copy(response, vm.players);
                });
            }
        };
    });
})();