app.controller( "ReceiptController", function ( $scope, RIOMSService )
{
    init();
    var receipt;
    var cess;
    var landRevenue;
    var waterTax;
    var miscRevenue;
    var others;
    $scope.Receipts = [];
    function init()
    {
        
        RIOMSService.GetReceipt().then( function ( response )
        {
            console.log( response.data );
            receipt = JSON.parse( JSON.stringify( response.data ) );
            cess = JSON.parse( JSON.stringify( response.data.CollectionCess ) );
            landRevenue = JSON.parse( JSON.stringify( response.data.CollectionLandRevenue ) );
            waterTax = JSON.parse( JSON.stringify( response.data.CollectionWaterTax ) );
            miscRevenue = JSON.parse( JSON.stringify( response.data.CollectionMiscRevenue ) );
            others = JSON.parse( JSON.stringify( response.data.CollectionOther ) );
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
            $scope.Receipt = JSON.parse( JSON.stringify(receipt));
        } );
    }
        $scope.LoadLR = function (receipt)
    {
        
        if ( receipt.CollectionLandRevenue==null )
        {
            receipt.CollectionLandRevenue = JSON.parse( JSON.stringify( landRevenue ) );
        }
        else
        {
            receipt.CollectionLandRevenue = null;
        }
        
    }
    $scope.LoadCess = function ( receipt )
    {
        if ( receipt.CollectionCess==null )
        {
            receipt.CollectionCess = JSON.parse( JSON.stringify( cess ) );
        }
        else
        {
            receipt.CollectionCess = null;
        }
    }
    $scope.LoadCBWR = function ( receipt )
    {
        if ( receipt.CollectionWaterTax == null )
        {
            receipt.CollectionWaterTax = JSON.parse( JSON.stringify( waterTax ) );
        }
        else
        {
            receipt.CollectionWaterTax = null;
        }
    }
    $scope.LoadMiscRevenue = function ( receipt )
    {
        if ( receipt.CollectionMiscRevenue == null )
        {
            receipt.CollectionMiscRevenue = JSON.parse( JSON.stringify( miscRevenue ) );
        }
        else
        {
            receipt.CollectionMiscRevenue = null;
        }
    }
    $scope.LoadOthers = function (receipt)
    {
        if ( receipt.CollectionOther == null )
        {
            receipt.CollectionOther = JSON.parse( JSON.stringify(others) );
        }
        else
        {
            receipt.CollectionOther = null;
        }
    }
    $scope.CalcInt = function ()
    {
        
        
        $scope.Receipt.CollectionCess.InterestTotal =parseFloat($scope.Receipt.CollectionCess.IntPrevious) + parseFloat($scope.Receipt.CollectionCess.IntSecond) + parseFloat($scope.Receipt.CollectionCess.IntThird) +parseFloat($scope.Receipt.CollectionCess.IntMoreThanThree);
    }
    $scope.Total = function ( head )
    {

        return parseFloat( head.MoreThanThree ) + parseFloat( head.Third ) + parseFloat( head.Second ) + parseFloat( head.Previous ) + parseFloat( head.Current );
    }
    $scope.GrantTotal = function (receipt)
    {
       return $scope.Total( receipt.CollectionLandRevenue ) + $scope.Total( receipt.CollectionWaterTax ) + $scope.Total( receipt.CollectionCess ) + receipt.CollectionLandRevenue.InterestTotal + receipt.CollectionWaterTax.InterestTotal+ receipt.CollectionCess.InterestTotal
    }
    $scope.AddReceipt = function ()
    {
        if ( $scope.CurrentDate != undefined )
        {


            var r = JSON.parse( JSON.stringify( receipt ) );
            if ( $scope.Receipts.length > 0 )
            {
                r.ReceiptNo = parseInt( $scope.Receipts[$scope.Receipts.length - 1].ReceiptNo ) + 1;
            }
            else
            {
                r.ReceiptNo = 1;
            }
            r.Date = $scope.CurrentDate;
            $scope.Receipts.push( r );
        }
        else
        {
            alert( "Select the date first" );
        }
    }
    $scope.SaveReceipts = function ()
    {

        RIOMSService.SaveReceipts( $scope.Receipts ).then( function ( responsedata )
        {
            if ( responsedata.success )
            {
                receipt.ReceiptNo = $scope.Receipt.ReceiptNo + 1;
                $scope.Receipt = JSON.parse( JSON.stringify( receipt ) );
            }
            
        } );
    }
    $scope.SaveReceipt = function ()
    {
        RIOMSService.SaveReceipt( $scope.Receipt ).then( function ( response )
        {
            if ( response.data.success )
            {

                receipt.ReceiptNo = parseInt($scope.Receipt.ReceiptNo) + 1;
                receipt.Date = $scope.CurrentDate;
                receipt.HasCess = true;
                $scope.NewReceipt = true;
                $scope.Receipt = JSON.parse( JSON.stringify( receipt ) );
                
            }

        } );
    }
    $scope.GetKhata = function (receipt)
    {
        
        if ( receipt!=undefined )
        {
            receipt.ActualVillageId = receipt.VillageId;
            if ( receipt.KhataNo != null && receipt.ActualVillageId != null )
            {
                RIOMSService.GetKhata( receipt.KhataNo, receipt.VillageId,'2015-2016' ).then( function ( response )
                {
                    receipt.NameOfRT = response.data.NameOfRT;
                    receipt.CollectionCess.Current = response.data.BalanceCess.Current;
                    receipt.CollectionCess.Previous = response.data.BalanceCess.Previous;
                    receipt.CollectionCess.Second = response.data.BalanceCess.Second;
                    receipt.CollectionCess.Third = response.data.BalanceCess.Third;
                    receipt.CollectionCess.MoreThanThree = response.data.BalanceCess.MoreThanThree;
                    receipt.CollectionCess.IntPrevious = CalcCessInterest( receipt.CollectionCess.Previous, 1 );
                    receipt.CollectionCess.IntSecond = CalcCessInterest( receipt.CollectionCess.Second, 2 );
                    receipt.CollectionCess.IntThird = CalcCessInterest( receipt.CollectionCess.Third, 3 );
                    receipt.CollectionCess.IntMoreThanThree = CalcCessMoreThenThreeInterest( receipt.CollectionCess.MoreThanThree, receipt.CollectionCess.Current );
                    receipt.CollectionCess.InterestTotal = receipt.CollectionCess.IntPrevious + receipt.CollectionCess.IntSecond + receipt.CollectionCess.IntThird + receipt.CollectionCess.IntMoreThanThree;
                }
                );
            }
            
        }
    }
    function CalcCessInterest(amount,noOfYear ) {
       
        if ( amount>0 )
        {
            var actInterest = ( ( 12 * amount ) * noOfYear )
            var amountToAdd = 5 - ( parseInt( actInterest ) % 5 );
            return ( parseInt( actInterest ) + amountToAdd ) / 100;
        }
        else
        {
            return 0;
        }
    }
    function CalcCessMoreThenThreeInterest(amount,annual)
    {
        if ( amount>0 )
        {
            var noOfYears = ( amount / annual );
            var factor = ( ( ( noOfYears + 3 ) * ( noOfYears + 4 ) ) / 2 ) - 6
            var actInterest = parseInt(( ( 12 * annual ) * factor ) );
            var amountToAdd = 5 - ( parseInt( actInterest ) % 5 );
            return ( parseInt( actInterest ) + amountToAdd ) / 100;
        }
        else
        {
            return 0;
        }
    }
    $scope.ChangeDate = function ()
    {
        $scope.Receipt.Date = $scope.CurrentDate;
    }
    $scope.GetReceiptByNo = function (receiptNo)
    {
        RIOMSService.GetReceiptByNo( receiptNo ).then( function ( response )
        {
            if ( response.data!='')
            {
                console.log( response.data );
                $scope.Receipt = response.data;
            }

           
        }
        );
    }
} );