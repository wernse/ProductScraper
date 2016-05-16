(function () {
    'use strict';

    angular
        .module('app')
        .factory('landingFactory', landingFactory);

    landingFactory.$inject = ['$http'];

    function landingFactory($http) {
        var landingFactory = {
            getProducts: getProducts,
            scrapeData: scrapeData,
            deleteData: deleteData
        };

        return landingFactory;

        function getProducts() {
            console.log("api/GetData")
            return $http.get('api/GetData');
        }
        function scrapeData() {
            console.log("api/ScrapeData")
            return $http.get('api/ScrapeData');
        }
        function deleteData() {
            console.log("api/DeleteData")
            return $http.get('api/DeleteData');
        }
   
    }
})();