app.controller("ReceiptController", function ($scope, RIOMSService) {
    init();
    var receipt;
    var cess;
    var landRevenue;
    var waterTax;
    var miscRevenue;
    var others;
    $scope.Receipts = [];
    function init() {
        RIOMSService.GetReceipt().then(function (response) {
            console.log(response.data);
            receipt = JSON.parse(JSON.stringify(response.data));
            cess = JSON.parse(JSON.stringify(response.data.CollectionCess));
            landRevenue = JSON.parse(JSON.stringify(response.data.CollectionLandRevenue));
            waterTax = JSON.parse(JSON.stringify(response.data.CollectionWaterTax));
            miscRevenue = JSON.parse(JSON.stringify(response.data.CollectionMiscRevenue));
            others = JSON.parse(JSON.stringify(response.data.CollectionOther));
            receipt.CollectionOther = null;
            //receipt.CollectionCess = null;
            receipt.CollectionWaterTax = null;
            receipt.CollectionLandRevenue = null;
            receipt.CollectionMiscRevenue = null;

            receipt.HasLandRevenue = false;
            receipt.HasWaterTax = false;
            receipt.CollectionOther = null;
            receipt.HasOthers = false;
            //receipt.HasCess = false;
            receipt.HasMiscRevenue = false;
            $scope.Receipt = JSON.parse(JSON.stringify(receipt));
        });
    }
    $scope.LoadLR = function (receipt) {
        if (receipt.CollectionLandRevenue == null) {
            receipt.CollectionLandRevenue = JSON.parse(JSON.stringify(landRevenue));
        }
        else {
            receipt.CollectionLandRevenue = null;
        }
    }
    $scope.LoadCess = function (receipt) {
        if (receipt.CollectionCess == null) {
            receipt.CollectionCess = JSON.parse(JSON.stringify(cess));
        }
        else {
            receipt.CollectionCess = null;
        }
    }
    $scope.LoadCBWR = function (receipt) {
        if (receipt.CollectionWaterTax == null) {
            receipt.CollectionWaterTax = JSON.parse(JSON.stringify(waterTax));
        }
        else {
            receipt.CollectionWaterTax = null;
        }
    }
    $scope.LoadMiscRevenue = function (receipt) {
        if (receipt.CollectionMiscRevenue == null) {
            receipt.CollectionMiscRevenue = JSON.parse(JSON.stringify(miscRevenue));
        }
        else {
            receipt.CollectionMiscRevenue = null;
        }
    }
    $scope.LoadOthers = function (receipt) {
        if (receipt.CollectionOther == null) {
            receipt.CollectionOther = JSON.parse(JSON.stringify(others));
        }
        else {
            receipt.CollectionOther = null;
        }
    }
    $scope.CalcIntMoreThanThree = function (amount) {
        $scope.Receipt.CollectionCess.IntMoreThanThree = CalcCessMoreThenThreeInterest(amount, $scope.Receipt.CollectionCess.Current);
    }
    $scope.CalcIntThird = function (amount) {
        $scope.Receipt.CollectionCess.IntThird = CalcCessInterest(amount, 3);
    }
    $scope.CalcIntSecond = function (amount) {
        $scope.Receipt.CollectionCess.IntSecond = CalcCessInterest(amount, 2);
    };
    $scope.CalcIntPrevious = function (amount) {
        $scope.Receipt.CollectionCess.IntPrevious = CalcCessMoreThenThreeInterest(amount, $scope.Receipt.CollectionCess.Current);
    };
    $scope.CalcInt = function () {
        $scope.Receipt.CollectionCess.InterestTotal = parseFloat($scope.Receipt.CollectionCess.IntPrevious)
            + parseFloat($scope.Receipt.CollectionCess.IntSecond)
            + parseFloat($scope.Receipt.CollectionCess.IntThird)
            + parseFloat($scope.Receipt.CollectionCess.IntMoreThanThree);
    };
    $scope.Total = function (head) {
        if (head != null) {
            return parseFloat(head.MoreThanThree) + parseFloat(head.Third) + parseFloat(head.Second) + parseFloat(head.Previous) + parseFloat(head.Current);
        }
        else {
            return 0;
        }
    };

    $scope.YTotal = function (yearNo) {
        var total = 0;
        if ($scope.Receipt != undefined || $scope.Receipt != null) {
            switch (yearNo) {
                case 0:
                    total = ($scope.Receipt.HasCess ? parseFloat($scope.Receipt.CollectionCess.Current) : 0) + ($scope.Receipt.HasLandRevenue ? parseFloat($scope.Receipt.CollectionLandRevenue.Current) : 0)
                        + ($scope.Receipt.HasWaterTax ? parseFloat($scope.Receipt.CollectionWaterTax.Current) : 0);
                    break;
                case 1:

                    total = ($scope.Receipt.HasCess ? parseFloat($scope.Receipt.CollectionCess.Previous) + parseFloat($scope.Receipt.CollectionCess.IntPrevious) : 0)
                        + ($scope.Receipt.HasLandRevenue ? parseFloat($scope.Receipt.CollectionLandRevenue.Previous) + parseFloat($scope.Receipt.CollectionLandRevenue.IntPrevious) : 0)
                        + ($scope.Receipt.HasWaterTax ? parseFloat($scope.Receipt.CollectionWaterTax.Previous) + + parseFloat($scope.Receipt.CollectionWaterTax.IntPrevious) : 0);
                    break;

                case 2:

                    total = ($scope.Receipt.HasCess ? parseFloat($scope.Receipt.CollectionCess.Second)
                        + parseFloat($scope.Receipt.CollectionCess.IntSecond) : 0)
                        + ($scope.Receipt.HasLandRevenue ? parseFloat($scope.Receipt.CollectionLandRevenue.Second)
                            + parseFloat($scope.Receipt.CollectionLandRevenue.IntSecond) : 0)
                        + ($scope.Receipt.HasWaterTax ? parseFloat($scope.Receipt.CollectionWaterTax.Second)
                            + parseFloat($scope.Receipt.CollectionWaterTax.IntSecond) : 0);
                    break;
                case 3:

                    total = ($scope.Receipt.HasCess ? parseFloat($scope.Receipt.CollectionCess.Third)
                        + parseFloat($scope.Receipt.CollectionCess.IntThird) : 0)
                        + ($scope.Receipt.HasLandRevenue ? parseFloat($scope.Receipt.CollectionLandRevenue.Third)
                            + parseFloat($scope.Receipt.CollectionLandRevenue.IntThird) : 0)
                        + ($scope.Receipt.HasWaterTax ? parseFloat($scope.Receipt.CollectionWaterTax.Third)
                            + parseFloat($scope.Receipt.CollectionWaterTax.IntThird) : 0);
                    break;
                case 4:

                    total = ($scope.Receipt.HasCess ? parseFloat($scope.Receipt.CollectionCess.MoreThanThree)
                        + parseFloat($scope.Receipt.CollectionCess.IntMoreThanThree) : 0)
                        + ($scope.Receipt.HasLandRevenue ? parseFloat($scope.Receipt.CollectionLandRevenue.MoreThanThree)
                            + parseFloat($scope.Receipt.CollectionLandRevenue.IntMoreThanThree) : 0)
                        + ($scope.Receipt.HasWaterTax ? parseFloat($scope.Receipt.CollectionWaterTax.MoreThanThree)
                            + parseFloat($scope.Receipt.CollectionWaterTax.IntMoreThanThree) : 0);
                    break;
                default:
                    break;
            }
        }
        return total;
    }
    $scope.GrantTotal = function (receipt) {
        if ($scope.Receipt != undefined || $scope.Receipt != null) {
            return $scope.Total(receipt.CollectionLandRevenue) + $scope.Total(receipt.CollectionWaterTax)
                + $scope.Total(receipt.CollectionCess) + (receipt.HasLandRevenue ? receipt.CollectionLandRevenue.InterestTotal : 0)
                + (receipt.HasWaterTax ? receipt.CollectionWaterTax.InterestTotal : 0)
                + (receipt.HasCess ? receipt.CollectionCess.InterestTotal : 0);
        }
    }
    $scope.AddReceipt = function () {
        if ($scope.CurrentDate != undefined) {
            var r = JSON.parse(JSON.stringify(receipt));
            if ($scope.Receipts.length > 0) {
                r.ReceiptNo = parseInt($scope.Receipts[$scope.Receipts.length - 1].ReceiptNo) + 1;
            }
            else {
                r.ReceiptNo = 1;
            }
            r.Date = $scope.CurrentDate;
            $scope.Receipts.push(r);
        }
        else {
            alert("Select the date first");
        }
    }
    $scope.SaveReceipts = function () {
        RIOMSService.SaveReceipts($scope.Receipts).then(function (responsedata) {
            if (responsedata.success) {
                receipt.ReceiptNo = $scope.Receipt.ReceiptNo + 1;
                $scope.Receipt = JSON.parse(JSON.stringify(receipt));
            }
        });
    }
    $scope.SaveReceipt = function () {
        RIOMSService.SaveReceipt($scope.Receipt).then(function (response) {
            if (response.data.success) {
                receipt.ReceiptNo = parseInt($scope.Receipt.ReceiptNo) + 1;
                receipt.Date = $scope.CurrentDate;
                receipt.VillageId = $scope.Receipt.VillageId;
                receipt.ActualVillageId = $scope.Receipt.ActualVillageId;
                receipt.HasCess = true;
                $scope.NewReceipt = true;
                $scope.Receipt = JSON.parse(JSON.stringify(receipt));
            }
        });
    }
    $scope.GetKhata = function (receipt) {
        if (receipt != undefined) {
            receipt.ActualVillageId = receipt.VillageId;
            if (receipt.KhataNo != null && receipt.ActualVillageId != null) {
                RIOMSService.GetKhata(receipt.KhataNo, receipt.VillageId, '2020-2021').then(function (response) {
                    receipt.NameOfRT = response.data.NameOfRT;
                    receipt.TotalArea = response.data.TotalArea;
                    $scope.KhataNo = response.data.KhataNo;
                    receipt.IsPaid = response.data.Receipts.length > 0 ? true : false;
                    if (response.data.BalanceCess != null || response.data.BalanceCess != undefined) {
                        receipt.CollectionCess.Current = response.data.BalanceCess.Current;
                        receipt.CollectionCess.Previous = response.data.BalanceCess.Previous;
                        receipt.CollectionCess.Second = response.data.BalanceCess.Second;
                        receipt.CollectionCess.Third = response.data.BalanceCess.Third;
                        receipt.CollectionCess.MoreThanThree = response.data.BalanceCess.MoreThanThree;
                    }

                    receipt.CollectionCess.IntPrevious = CalcCessInterest(receipt.CollectionCess.Previous, 1);
                    receipt.CollectionCess.IntSecond = CalcCessInterest(receipt.CollectionCess.Second, 2);
                    receipt.CollectionCess.IntThird = CalcCessInterest(receipt.CollectionCess.Third, 3);
                    receipt.CollectionCess.IntMoreThanThree = CalcCessMoreThenThreeInterest(receipt.CollectionCess.MoreThanThree, receipt.CollectionCess.Current);
                    receipt.CollectionCess.InterestTotal = receipt.CollectionCess.IntPrevious + receipt.CollectionCess.IntSecond + receipt.CollectionCess.IntThird + receipt.CollectionCess.IntMoreThanThree;
                }
                );
            }
        }
    }
    function CalcCessInterest(amount, noOfYear) {
        amount = amount * 100;
        if (amount > 0) {
            var actInterest = ((0.12 * amount) * noOfYear)
            var amountToAdd = 5 - (parseInt(actInterest) % 5);

            return (parseInt(actInterest) + amountToAdd) / 100;
        }
        else {
            return 0;
        }
    }
    function CalcCessMoreThenThreeInterest(amount, annual) {
        amount = amount * 100;
        annual = annual * 100;
        if (amount > 0) {
            var remminder = amount % annual;
            var noOfYears = parseInt(amount / annual);
            var factor;
            var actInterest
            if (remminder == 0) {
                factor = (((noOfYears) * (noOfYears + 1)) / 2);
                actInterest = parseInt(((.12 * annual) * factor));
            }
            else {
                noOfYears;
                factor = (((noOfYears) * (noOfYears + 1)) / 2);
                actInterest = parseInt(((.12 * annual) * factor) + (.48 * remminder));
            }

            amountToAdd = 5 - (parseInt(actInterest) % 5);

            return (parseInt(actInterest) + amountToAdd) / 100;
        }
        else {
            return 0;
        }
    }
    $scope.ChangeDate = function () {
        $scope.Receipt.Date = $scope.CurrentDate;
    }
    $scope.GetReceiptByNo = function (receiptNo) {
        RIOMSService.GetReceiptByNo(receiptNo).then(function (response) {
            if (response.data != '') {
                console.log(response.data);
                $scope.Receipt = response.data;
            }
        }
        );
    }
});