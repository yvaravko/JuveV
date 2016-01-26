(
    function() {
        angular.module('admin-main').controller('teamsController', teamsController);

        function teamsController($resource) {
            var vm = this;
            vm.teams = [];
            vm.editMode = false;
            vm.editedEntity = {};
            vm.isLoading = true;

            vm.countries = [{ id: 1, name: "Italy" }, { id: 2, name: "Spain" }, { id: 3, name: "France" }];

            $resource('/api/team').query(function(response) {
                angular.copy(response, vm.teams);
                vm.isLoading = false;
            });

            vm.edit = function (type) {
                angular.copy(type, vm.editedEntity);
                type.editMode = true;
                vm.editMode = true;
            };

            //TODO: fix this method
            vm.save = function (type) {
                alert(type.selectedCountry);
                vm.editMode = false;
            };
        }
    }
)();