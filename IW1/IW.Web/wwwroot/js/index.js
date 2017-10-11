$(function (hp) {
    "use strict";

    // The Model
    hp.SearchParams = function (data) {
        var self = this;

        self.od1 = ko.observable();
        self.od2 = ko.observable();
        self.dd1 = ko.observable();
        self.dd2 = ko.observable();
        self.sd1 = ko.observable();
        self.sd2 = ko.observable();
    };
   
   
    // The ViewModel
    hp.vm = (function () {
        var
            metadata = {
                pageTitle: "Home",
            },
            isLoadingRecords = ko.observable(false),
            errorsExist = ko.observable(false),
            loadRecords = function () {
                isLoadingRecords(true);
                hideTemplates();

                $('#pnlList').show();
                isLoadingRecords(false);
            },
            loadRecordsCallback = function (json) {
                window.location.href = '/Home/SearchResults';
            },
            hideTemplates = function () {
                $('#inputError').hide();
                $('#serverError').hide();
                $("#pnlDetail").hide();
            },
            search = function () {
                //var od1 = $('#orderdaterange').val(picker.startDate.format('MM/DD/YYYY'));
                //var od2 = $('#orderdaterange').val(picker.endDate.format('MM/DD/YYYY'));
                //var dd1 = $('#duedaterange').val(picker.startDate.format('MM/DD/YYYY'));
                //var dd2 = $('#duedaterange').val(picker.endDate.format('MM/DD/YYYY'));
                //var sd1 = $('#shipdaterange').val(picker.startDate.format('MM/DD/YYYY'));
                //var sd2 = $('#shipdaterange').val(picker.endDate.format('MM/DD/YYYY'));

                var od1 = $('#orderstartdate').val();
                var od2 = $('#orderenddate').val();
                var dd1 = $('#duestartdate').val();
                var dd2 = $('#dueenddate').val();
                var sd1 = $('#shipstartdate').val();
                var sd2 = $('#shipenddate').val();

                var searchParams = new hp.SearchParams();
                //searchParams.od1 = od1;
                //searchParams.od2 = od2;
                //searchParams.dd1 = dd1;
                //searchParams.od2 = dd2;
                //searchParams.sd1 = sd1;
                //searchParams.sd2 = sd2;
                searchParams.od1 = "07/01/2005";
                searchParams.od2 = "07/31/2008";
                searchParams.dd1 = "07/13/2005";
                searchParams.dd2 = "08/12/2008";
                searchParams.sd1 = "07/08/2005";;
                searchParams.sd2 = "08/07/2008";

                var uri = "/Orders/GetCustomerOrders";
                ds.dataService.getCustomerOrders(uri, searchParams, hp.vm.loadRecordsCallback);
            },
            validateData = function (inputData, scenarioType) {
                //if (typeof inputData == 'undefined') { return false; }

                var isValid = true;
                return isValid;
            };


        return {
            metadata: metadata,
            isLoadingRecords: isLoadingRecords,
            hideTemplates: hideTemplates,
            loadRecords: loadRecords,
            loadRecordsCallback: loadRecordsCallback,
            errorsExist: errorsExist,
            validateData: validateData,
            search: search
        };
    })();

    //hp.vm.loadRecords();
    ko.applyBindings(hp.vm);

    $(document).ready(function () {
        //$('input[name="orderdaterange"]').daterangepicker();
        //$('input[name="duedaterange"]').daterangepicker();
        //$('input[name="shipdaterange"]').daterangepicker();

        $('#orderstartdate').datepicker();
        $('#orderenddate').datepicker();
        $('#duestartdate').datepicker();
        $('#dueenddate').datepicker();
        $('#shipstartdate').datepicker();
        $('#shipenddate').datepicker();

    });

}(hp));


