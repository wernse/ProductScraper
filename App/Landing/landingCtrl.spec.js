describe('Controller: landingCtrl', function () {
    var scope, $http;

    beforeEach(function () {
        var mockLandingFactory = {};
        module('landing', function ($provide) {
            $provide.value('landingFactory', mockLandingFactory);
        });
        inject(function ($q) {
            mockLandingFactory.data = [
              {
                  Category: "Meat",
                  DateSaved: "/Date(1463986895163)/",
                  PreviousPrice: 15.989999771118164,
                  Price: 13.989999771118164,
                  ProductID: 63,
                  ProductName: "Regal Wood Roasted Portions Smoked Salmon Mi...",
                  Store: "countdown",
              }
            ];
            mockLandingFactory.getProducts = function () {
                var defer = $q.defer();
                defer.resolve(this.data);
                return defer.promise;
            }
        });
    });

    beforeEach(inject(function ($controller, $rootScope, _landingFactory_) {
        scope = $rootScope.$new();

        landingFactory = _landingFactory_
        $controller('landingCtrl as landing', { $scope: scope, landingFactory: landingFactory });

        scope.$digest();
    }));

    it('it should return products in the meat category', function () {
        expect(scope.landing.products[0].Category).toEqual("Meat");
    });


});