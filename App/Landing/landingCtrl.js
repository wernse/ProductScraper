(function () {
    'use strict';

    angular
        .module('landing')
        .controller('landingCtrl', ['$scope', 'landingFactory', function ($scope, landingFactory) {
            var ctrl = this;
            ctrl.getData = getData
            ctrl.scrapeData = scrapeData
            ctrl.deleteData = deleteData

            console.log("hello");
            init()

            function init() {
                getData()
            };

            function getData() {
                landingFactory.getProducts()
                   .then(function (data) {
                       console.log(data.data);
                       ctrl.products = data.data;
                   }).catch(function (error) {
                       console.error("error", error);
                   });
            }
            function scrapeData() {
                landingFactory.scrapeData()
                    .then(function (data) {
                        console.log(data.data)
                        ctrl.msg = data.data;
                    }).catch(function (error) {
                        console.error("error", error);
                    });
            }
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
        }])

})