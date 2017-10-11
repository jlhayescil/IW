// ds.dataService
// Depends on scripts:
//                    ajaxservice.js
(function (ds) {
    "use strict";
    ds.dataService = {
        getCustomerCharges: function (uri, params, callback) {
            ajx.ajaxService.ajaxPostJson(uri, params, callback);
        },
        getCustomerOrders: function (uri, params, callback) {
            ajx.ajaxService.ajaxPostJson(uri, params, callback);
        },
        getOrderDetails: function (uri, id, callback) {
            ajx.ajaxService.ajaxGetJson(uri, id, callback);
        }

    };
}(ds));