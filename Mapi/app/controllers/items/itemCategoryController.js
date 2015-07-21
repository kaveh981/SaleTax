



angular.module('SaleTax')
    .controller('itemCategoryController', ['$scope', 'itemFactory',
        function ($scope, itemFactory) {

            getItemCategories();

            function getItemCategories() {
                itemFactory.getItemCategories()
                    .success(function (itemCategories) {
                        $scope.itemCategories = itemCategories;
                    })
                    .error(function (error) {
                        $scope.status = 'Unable to load item categories data: ' + error.message;
                    });
            }
        

            $scope.insertItemCategory = function () {
                var itemCategory = {
                    Category: $scope.itemCategory,
                    SaleTax: $scope.saleTax

                };
                itemFactory.insertItemCategory(itemCategory)
                    .success(function () {
                        getItemCategories();
                        $scope.itemCategory.push(itemCategory);
                    }).
                    error(function (error) {
                        alert(error.message);
                        $scope.status = 'Unable to insert item Category: ' + error.message;
                    });
            };

            $scope.updateItemCategory = function (data, id) {
                var itemCategory = {
                    Id: id,
                    Category: data.category,
                    SaleTax: data.saleTax

                };
                itemFactory.updateItemCategory(itemCategory)
                    .success(function () {
                        getItemCategories();
                        $scope.itemCategory.push(itemCategory);
                    }).
                    error(function (error) {
                        alert(error.message);
                        $scope.status = 'Unable to update item Category: ' + error.message;
                    });
            };

            $scope.deleteItemCategory = function (id) {
                itemFactory.deleteItemCategory(id)
                    .success(function () {
                        getItemCategories();
                        $scope.itemCategory.push(itemCategory);
                    }).
                    error(function (error) {
                        alert(error.message);
                        $scope.status = 'Unable to delete item Category: ' + error.message;
                    });
            };

        }]);