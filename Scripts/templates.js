angular.module("templates", []).run(["$templateCache", function($templateCache) {$templateCache.put("Landing/landing.html","<div>hello this is the landing page </div>\r\n<div>\r\n    <div class=\"header\">Products</div>\r\n    <div class=\"btn-group\">\r\n        <div class=\"btn btn-lg btn-primary\" ng-click=\"landing.getData()\">Get Data</div>\r\n        <div class=\"btn btn-lg btn-default\" ng-click=\"landing.scrapeData()\">Scrape Data</div>\r\n        <div class=\"btn btn-lg btn-danger\" ng-click=\"landing.deleteData()\">Delete Data</div>\r\n    </div>\r\n    <div class=\"container\">\r\n        <main-table data=\"landing.products\"></main-table>\r\n    </div>\r\n</div>\r\n");
$templateCache.put("Landing/directives/mainTable/mainTable.html","<table class=\"table table-condensed table-striped\">\r\n    <thead>\r\n        <tr>\r\n            <th ng-click=\"$ctrl.sortVar = \'ProductName\'; $ctrl.sortDir = !$ctrl.sortDir\">\r\n                Name\r\n                <span ng-if=\"$ctrl.sortVar == \'ProductName\'\">\r\n                    <span ng-if=\"$ctrl.sortDir\" class=\"glyphicon glyphicon-triangle-top\"></span>\r\n                    <span ng-if=\"!$ctrl.sortDir\" class=\"glyphicon glyphicon-triangle-bottom\"></span>\r\n                </span>\r\n            </th>\r\n            <th ng-click=\"$ctrl.sortVar = \'Price\'; $ctrl.sortDir = !$ctrl.sortDir\">\r\n                Price\r\n                <span ng-if=\"$ctrl.sortVar == \'Price\'\">\r\n                    <span ng-if=\"$ctrl.sortDir\" class=\"glyphicon glyphicon-triangle-top\"></span>\r\n                    <span ng-if=\"!$ctrl.sortDir\" class=\"glyphicon glyphicon-triangle-bottom\"></span>\r\n                </span>\r\n            </th>\r\n            <th ng-click=\"$ctrl.sortVar = \'PreviousPrice\'; $ctrl.sortDir = !$ctrl.sortDir\">\r\n                PreviousPrice\r\n                <span ng-if=\"$ctrl.sortVar == \'PreviousPrice\'\">\r\n                    <span ng-if=\"$ctrl.sortDir\" class=\"glyphicon glyphicon-triangle-top\"></span>\r\n                    <span ng-if=\"!$ctrl.sortDir\" class=\"glyphicon glyphicon-triangle-bottom\"></span>\r\n                </span>\r\n            </th>\r\n            <th ng-click=\"$ctrl.sortVar = \'Store\'; $ctrl.sortDir = !$ctrl.sortDir\">\r\n                Store\r\n                <span ng-if=\"$ctrl.sortVar == \'Store\'\">\r\n                    <span ng-if=\"$ctrl.sortDir\" class=\"glyphicon glyphicon-triangle-top\"></span>\r\n                    <span ng-if=\"!$ctrl.sortDir\" class=\"glyphicon glyphicon-triangle-bottom\"></span>\r\n                </span>\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n        <tr ng-repeat=\"product in $ctrl.data | orderBy:$ctrl.sortVar:$ctrl.sortDir \">\r\n            <td>\r\n                {{product.ProductName}}\r\n            </td>\r\n            <td>\r\n                ${{product.Price | number:2}}\r\n            </td>\r\n            <td>\r\n                <span ng-if=\"product.PreviousPrice != 0.00\">${{product.PreviousPrice | number:2}}</span>\r\n            </td>\r\n            <td>\r\n                {{product.Store}}\r\n            </td>\r\n        </tr>\r\n    </tbody>\r\n</table>\r\n");}]);