var app = angular.module('app', ['ngRoute']);

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
    .when('/', {
        templateUrl: '/App/Landing/landing.html',
        controller: 'landingCtrl',
        controllerAs : 'landing'
    })
    .otherwise({
        redirectTo: '/'
    });
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
}]);