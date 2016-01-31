(function () {
	angular.module('admin-main').service('PlayerTypesService', ['$resource', function ($resource) {
		this.getAll = function() {
		    return $resource('/api/playerType').query();
		}

    	//return $resource('/api/playerType', { id: '@id' }, { 'update': { method: 'PUT' } });
    }]);
})();