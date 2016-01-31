(
    function() {
        angular.module('admin-main').controller('teamsController', teamsController);

        function teamsController($resource, $window, countriesService) {
            var vm = this;
            vm.teams = [];
            vm.editMode = false;
            vm.editedEntity = {};
            vm.isLoading = true;
            vm.players = [];

            vm.countries = countriesService.getAllCountries();

            $resource('/api/team').query(function(response) {
                angular.copy(response, vm.teams);
                vm.isLoading = false;
            });

            vm.edit = function (type) {
                angular.copy(type, vm.editedEntity);
                type.editMode = true;
                vm.editMode = true;
            };

            vm.cancel = function (type) {
                type.editMode = false;
                vm.editMode = false;
                if (!type.id) {
                    var index = vm.teams.indexOf(type);
                    vm.teams.splice(index, 1);
                } else {
                    type.name = vm.editedEntity.name;
                    type.country = vm.editedEntity.country;
                    vm.editedEntity = {};
                }
                vm.$apply();
            }

            vm.delete = function (type) {
                if (confirm("Do you want to delete this row?")) {
                    $resource('/api/team/:id').delete({ id: type.id });
                    var index = vm.teams.indexOf(type);
                    vm.teams.splice(index, 1);
                }
            }

            vm.save = function (type) {
                if (type.id) {
                    type.countryId = type.country.id;
                    $resource('/api/team/:id',
                    { id: type.id },
                    { update: { method: 'PUT' } }).update(type);
                } else {
                    type.id = 0;
                    $resource('/api/team').save(type, function(response) {
                        type.id = response.id;
                    });
                };

                type.editMode = false;
                vm.editMode = false;
            };

            vm.insert = function () {
                var type = {};
                vm.teams.push(type);
                type.editMode = true;
                vm.editMode = true;
            };

            vm.search = function (keyEvent) {
                if (keyEvent.which === 13) {
                    $resource('/api/team/search/:value', { value: vm.searchValue }).query(function (response) {
                        angular.copy(response, vm.teams);
                    });
                }
            }

            vm.selectRow = function(type) {
                vm.selectedTeam = type.name;
                vm.players = [{ id: 1, fname: 'Lionel', lname: 'Messi' }, { id: 2, fname: 'Luis', lname: 'Suarez' }, { id: 3, fname: 'Serchio', lname: 'Buskets' }];
            }
           

            angular.element($window).bind("keydown", function ($event) {
                if ($event.ctrlKey && $event.keyCode == 83) {
                    $event.preventDefault();
                    if (vm.editMode) {
                        var typeInEdit = _.filter(vm.teams, function (element) {
                            return element.editMode;
                        });

                        if (typeInEdit.length = 1) {
                            vm.save(typeInEdit[0]);
                        }
                    }
                }
            });

        }
    }
)();