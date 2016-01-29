(function () {
    angular.module('admin-main').factory('countriesService', function ($resource) {
        return {
            getAllCountries: function() {
                return $resource('/api/country').query();
            }
        }
    })
})();