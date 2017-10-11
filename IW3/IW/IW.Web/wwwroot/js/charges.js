$(function (chg) {
    "use strict";

    // The Model
    chg.PrintJob = function (data) {
        var self = this;
        self.jobId = ko.observable();
        self.jobName = ko.observable();
        self.jobType = ko.observable();
        self.jobCost = ko.observable().extend({ numeric: 2 });
        
        self.total = ko.observable().extend({ numeric: 2 });
        
        self.nametype = ko.computed(function () {
            return self.jobName + " " + self.jobType;
        });

        self.printItems = ko.observableArray([new chg.PrintItem()]);
    };

    chg.PrintItem = function (data) {
        var self = this;
        self.jobId = ko.observable();
        self.itemName = ko.observable();
        self.applyTax = ko.observable();
        self.cost = ko.observable();
    };

    // The ViewModel
    chg.vm = (function () {
        var
            metadata = {
                pageTitle: "Customer Charges"
            },
            records = ko.observableArray(),
            printItems = ko.observableArray(),
            isLoadingRecords = ko.observable(false),
            selectedRecord = ko.observable(),
            errorsExist = ko.observable(false),
            recordId = ko.observable(),
            selectRecord = function (r) {
                if (app.isInt(r.orderId())) {
                    selectedRecord(r);
                }
            },
            viewRecord = function (r) {
                selectedRecord(r);
                var id = r.id;
                window.location.href = '/Home/Details/';
            },
            sortFunction = function (a, b) {
                return a.lname().toLowerCase() > b.lname().toLowerCase() ? 1 : -1;
            },
            loadRecordsCallback = function (json) {
                $.each(json, function (i, r) {
                    records.push(new chg.PrintJob(selectedRecord)
                        .jobId(i)
                        .jobName(r.jobName || "")
                        .jobType(r.jobType || "")
                        .jobCost(r.jobCost || "")
                       );
                });
            },
            loadRecords = function () {
                isLoadingRecords(true);
                var params = "Jobs";

                var uri = "api/Charges/GetCharges";
                ds.dataService.getCustomerCharges(uri, params, chg.vm.loadRecordsCallback);

                isLoadingRecords(false);
            },
            hideTemplates = function () {
                $('#inputEerror').hide();
                $('#serverError').hide();
            };
           

        return {
            metadata: metadata,
            records: records,
            selectedRecord: selectedRecord,
            selectRecord: selectRecord,
            isLoadingRecords: isLoadingRecords,
            errorsExist: errorsExist,
            loadRecords: loadRecords,
            loadRecordsCallback: loadRecordsCallback,
            viewRecord: viewRecord,
            sortFunction: sortFunction,
            hideTemplates: hideTemplates
        };
    })();

    chg.vm.loadRecords();
    ko.applyBindings(chg.vm);

    $(document).ready(function () {
       
    });

}(chg));



