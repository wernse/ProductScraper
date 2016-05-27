(function () {
    'use strict';
    angular.module('landing')
        .factory('landingFactory', [
            '$http',
            '$rootScope',
            '$q',
            landingFactory
        ]);


    function landingFactory($http, $rootScope, $q) {
        var landingFactory = {
            getProducts: getProducts,
            scrapeData: scrapeData,
            deleteData: deleteData
        };

        return landingFactory;

        //Sends ajax GET to a URL, rejects if error
        function get(url) {
            var deferred = $q.defer();
            $http.get(url)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function getProducts() {
            console.log("api/GetData")
            return get("api/GetData");
        }
        function scrapeData() {
            console.log("api/ScrapeData")
            return get("api/ScrapeData");
        }
        function deleteData() {
            console.log("api/DeleteData")
            return get("api/DeleteData");
        }
   
    }
})();