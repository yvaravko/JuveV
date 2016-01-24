(function() {
	function navCtrl() {
    	var vm = this;
    	vm.isActive = function (viewLocation) {
    		var result = window.location.href.indexOf(viewLocation) > 0;
	        return result;
	    }
    };

	angular.module('admin-main').controller('navCtrl', navCtrl);
})();