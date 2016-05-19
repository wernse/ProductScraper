﻿(function () {
    'use strict';

    angular
        .module('landing')
        .component('mainTable', {
            templateUrl: '/App/Landing/directives/mainTable/mainTable.html',
            controller: mainTableController,
            bindings: {
                data: '<',
            }
        });
    mainTable.$inject = ['$scope'];

    function mainTableController($scope) {
        var ctrl = this;
        console.log(ctrl.data)
    }

})();