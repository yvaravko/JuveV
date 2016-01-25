(function() {
    function playerTypesController($resource, $http) {
        var vm = this;
        vm.playerTypes = [];
        vm.editMode = false;
        vm.editedEntity = {};

        vm.isLoading = true;
        $resource('/api/playertype').query(function (response) {
            angular.copy(response, vm.playerTypes);
            vm.isLoading = false;
        });

        vm.edit = function (type) {
            angular.copy(type, vm.editedEntity);
            type.editMode = true;
            vm.editMode = true;
        };

        vm.save = function (type) {
            if (type.id) {
                $resource('/api/playertype/:id',
                    { id: type.id },
                    { update: { method: 'PUT' } }).update(type);
            } else {
                type.id = 0;
                $resource('/api/playertype').save(type, function(response) {
                    type.id = response.id;
                });
            }

            type.editMode = false;
            vm.editMode = false;
        }

        vm.cancel = function (type) {
            type.editMode = false;
            vm.editMode = false;
            if (!type.id) {
                var index = vm.playerTypes.indexOf(type);
                vm.playerTypes.splice(index, 1);
            } else {
                type.type = vm.editedEntity.type;
                vm.editedEntity = {};
            }
        }

        vm.delete = function (type) {
            if (confirm("Do you want to delete this row?")) {
                $resource('/api/playertype/:id').delete({ id: type.id });
                var index = vm.playerTypes.indexOf(type);
                vm.playerTypes.splice(index, 1);
            }
        }

        vm.insert = function () {
            var type = {};
            vm.playerTypes.push(type);
            type.editMode = true;
            vm.editMode = true;
        };
    }

    angular.module('admin-main').controller('playerTypes', playerTypesController);
})();