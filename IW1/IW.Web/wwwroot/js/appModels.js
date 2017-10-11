(function (appModels) {

    appModels.SelectList = function (selectedItem) {
        var self = this;
        self.Value = ko.observable();
        self.Text = ko.observable();
    };

}(appModels));
