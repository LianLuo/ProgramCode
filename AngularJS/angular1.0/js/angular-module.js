var myapp = angular.module("HelloAngular",[]);
myapp.controller("helloAngular",['$scope',function(){
	function HelloAngular($scope)
	{
		$scope.greeting = {
			text:"Hello"
		};
	}
}]);