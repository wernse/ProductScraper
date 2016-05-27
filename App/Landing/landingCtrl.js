(function () {
    'use strict';
    angular.module('landing')
        .controller('landingCtrl', [
            '$scope',
            'landingFactory',
            landingCtrl
        ])
    //Landing Controller for the initial page
    function landingCtrl($scope, landingFactory) {
        var ctrl = this;
        ctrl.getData = getData
        ctrl.scrapeData = scrapeData
        ctrl.deleteData = deleteData

        init()

        //Initializes the data for page
        function init() {
            getData()
        };

        //Gets the data and stores in ctrl.products
        function getData() {
            landingFactory.getProducts()
               .then(function (data) {
                   console.log(data);
                   ctrl.products = data;
               }).catch(function (error) {
                   console.error("error", error);
               });
        }

        //Forces the app to scape new data
        function scrapeData() {
            landingFactory.scrapeData()
                .then(function (data) {
                    console.log(data.data)
                    ctrl.msg = data.data;
                }).catch(function (error) {
                    console.error("error", error);
                });
        }

        //Forces the app to delete products
        function deleteData() {
            landingFactory.deleteData()
                .then(function (data) {
                    console.log(data.data)
                    ctrl.msg = data.data;
                }).catch(function (error) {
                    console.error("error", error);
                });
        }
        return ctrl;
    }
})();