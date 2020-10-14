app.controller("RoRController", function ($scope, RIOMSService) {
    function init() {
        $scope.IsEditable = false;
    }

    $scope.GetRoR = function (khataNo, villageId) {
        RIOMSService.GetRoR(khataNo, villageId).then(function (response) {
            if (response.data != '') {
                console.log(response.data);
                $scope.Khata = response.data;
            }
            else {
                alert("No RoR Found")
            }
        });
    }
    $scope.GetRTList = function (villageId) {
        RIOMSService.GetRTList(villageId).then(function (response) {
            if (response.data != '') {
                $scope.Khatas = response.data;
                console.log(response.data);
            }
            else {
                alert("No RoR Found")
            }
        });
    }
});