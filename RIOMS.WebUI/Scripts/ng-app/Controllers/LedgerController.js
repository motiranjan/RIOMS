app.controller( "LedgerController", function ( $scope, RIOMSService )
{

    function init()
    {
        $scope.IsEditable = false;
    }
   
    $scope.GetLedger = function (khataNo,villageId,fyear)
    {
        RIOMSService.GetLedger(khataNo,villageId,fyear).then( function ( response )
        {
            if ( response.data!='' )
            {
                console.log( response.data );
                $scope.Khata = response.data;
            }
            else
            {
                alert("No Demant Found")
            }
        } );
    }
    $scope.AllowEdit = function ()
    {
        $scope.IsEditable = true;
    }
    $scope.Update = function ()
    {

        $scope.IsEditable = false;
        RIOMSService.UpdateLedger($scope.Khata,$scope.Year).then( function ( response )
        {
            if ( response.data !='' )
            {
                $scope.IsEditable = false;
                $scope.Khata = response.data;
            }
        } );
    }
    $scope.NextKhata= function ( khataNo, villageId,fyear )
    {
        if ( khataNo.indexOf('/')>-1 )
        {
            var arr = khataNo.split( '/' );
            khataNo = arr[0] + '/' + ( parseInt( arr[1] ) + 1 )
        }
        else
        {
            khataNo = parseInt( khataNo ) + 1;
        }
        $scope.KhataNo = khataNo.toString();
        RIOMSService.GetLedger( khataNo, villageId,fyear ).then( function ( response )
        {
            if ( response.data != '' )
            {
                console.log( response.data );
                $scope.Khata = response.data;
            }
            else
            {
                alert( "No Demant Found" )
            }
        } );
    }
} );