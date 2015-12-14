app.service( 'RIOMSService', function ( $http )
{
    this.GetReceipt = function ()
    {
        return $http.get( 'Receipt/Receipt' );
    }
    this.SaveReceipts = function (receipts)
    {
        return $http.post( "Registers/SaveReceipts", { receipts: receipts } );
    }
    this.SaveReceipt = function ( receipt )
    {
        return $http.post( "Receipt/Save", { receipt: receipt } );
    }
    this.GetKhata = function ( khataNo, villageId,fyear )
    {
        return $http.get( 'Receipt/GetKhata?khataNo=' + khataNo + '&villageId=' + villageId+'&fyear='+fyear );
    }
    this.GetReceiptByNo = function (receiptNo)
    {
        return $http.get( 'Receipt/GetReceiptByNo?receiptNo='+receiptNo);
    }
    this.GetLedger = function ( khataNo, villageId,fyear )
    {
        return $http.get( '/rioms/ledger/getkhata?khataNo=' + khataNo + '&villageId=' + villageId+'&fyear='+fyear );
    }
    this.UpdateLedger = function (khata,fyear)
    {
        return $http.post( '/rioms/ledger/UpdateLedger', { khata: khata, fyear: fyear } )
    }
    } );