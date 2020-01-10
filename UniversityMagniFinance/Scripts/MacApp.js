var app = angular.module("Myapp", []);
app.controller("SubjectController", function ($scope, $http) {
    $http({
        method: 'GET',
        url: '/Subject/GetTeachers'
    }).then(function (result) {
        $scope.teachers = result.data;
    })

    $http({
        method: 'GET',
        url: '/Subject/GetCourses'
    }).then(function (result) {
        $scope.courses = result.data;
    })
})