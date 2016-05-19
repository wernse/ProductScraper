// Tests here

describe('Controller: landingCtrl', function () {
    var scope, $http, $location;

    beforeEach(function () {
        var mockRestService = {};
        module('landing', function ($provide) {
            $provide.value('landingFactory', mockRestService);
        });
        inject(function ($q) {
            mockRestService.data = [
              {
                  id: 0,
                  name: 'Angular'
              }
            ];
            mockRestService.getProducts = function () {
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

    it('should retrieve values at startup', function () {
        expect(scope.landing.products).toEqual([
          {
              id: 0,
              name: 'Angular'
          }
        ]);
    });


});