(function () {
    'use strict';

    angular
        .module('landing')
        .component('mainTable', {
            templateUrl: '/App/Landing/directives/mainTable/mainTable.html',
            controller: ['$scope',mainTableController],
            bindings: {
                data: '<',
            }
        });

    function mainTableController($scope) {
        var ctrl = this;
        console.log(ctrl.data)
    }

})();