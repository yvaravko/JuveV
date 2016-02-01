(function() {
    function addNewRow() {
        return {
            restrict: 'A',
            templateUrl: '/views/addNewRow.html',
            replace: true
        }    
    };

    function crudButtons() {
        return {
            restrict: 'A',
            templateUrl: '/views/crudButtons.html',
            replace: true
        }
    };

    function focusOn() {
        return function(scope, elem, attr) {
            scope.$on('focusOn', function (e, name) {
                if (name === attr.focusOn) {
                    elem[0].focus();
                }
            });
        }
    };

    var main = angular.module('admin-main');

    main.directive('addNewRow', addNewRow);
    main.directive('crudButtons', crudButtons);
    main.directive('focusOn', focusOn);

    main.factory('focus', function ($rootScope, $timeout) {
        return function (name) {
            $timeout(function () {
                $rootScope.$broadcast('focusOn', name);
            });
        }
    });
})();