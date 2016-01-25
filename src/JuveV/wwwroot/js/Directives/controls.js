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

    angular.module('admin-main').directive('addNewRow', addNewRow);
    angular.module('admin-main').directive('crudButtons', crudButtons);
})();