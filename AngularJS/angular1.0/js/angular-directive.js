var myapp = angular.module("MyModule",[]);
myapp.controller("HelloAngular",function($scope){
	$scope.greeting = {
		text:"Hello"
	};
});
myapp.directive("hello",function(){
	return {
		restrict:"E",
		template:'<div>Hi Everyone!</div>',
		replace:true
	};
});