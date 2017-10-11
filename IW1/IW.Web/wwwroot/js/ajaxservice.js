// ajaxService
// Depends on scripts:
//                    jQuery

(function (ajx) {
    "use strict";

    ajx.ajaxService = (function () {
        var errorText = app.errorMessageText;
        var
            ajaxGetJson = function (uri, jsonIn, callback) {
                //app.clearError();
                $.ajax({
                    url: uri,
                    type: "GET",
                    data: ko.toJSON(jsonIn),
                    dataType: "json",
                    contentType: "application/json",
                    success: function (json) {
                        callback(json);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = app.parseError(XMLHttpRequest);
                        if (error.indexOf('**') > -1) {
                            $('#errorMessage2').text(app.getRecordsError);
                        }
                    }
                });
            },
            ajaxPostJson = function (uri, jsonIn, callback) {
                //app.clearError();
                $.ajax({
                    url: uri,
                    type: "POST",
                    data: ko.toJSON(jsonIn),
                    success: function (json) {
                        var formattedJson = JSON.stringify(json);
                        callback(json);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        console.log(XMLHttpRequest);
                        console.log(textStatus);
                        console.log(errorThrown);
                        var error = app.parseError(XMLHttpRequest);
                    }
                });
            },
            ajaxPutJson = function (uri, jsonIn, id, callback) {
                //app.clearError();
                $.ajax({
                    url: uri/id,
                    type: "PUT",
                    data: ko.toJSON(jsonIn),
                    dataType: "json",
                    contentType: "application/json",
                    success: function (json) {
                        callback(json);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = app.parseError(XMLHttpRequest);
                        if (error.indexOf('**') > -1) {
                            $('#errorMessage').text(app.saveRecordError);
                            $('#errorMessage2').text(app.saveRecordError);
                        }
                    }
                });
            },
            ajaxDeleteJson = function (uri, jsonIn, id, callback) {
                //app.clearError();
                $.ajax({
                    url: uri/id,
                    type: "DELETE",
                    data: ko.toJSON(jsonIn),
                    dataType: "json",
                    contentType: "application/json",
                    xhrFields: {
                        withCredentials: true
                    },
                    success: function (json) {
                        callback(json);
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        var error = app.parseError(XMLHttpRequest);
                        if (error.indexOf('**') > -1) {
                            $('#errorMessage').text(app.deleteRecordError);
                        }
                    }
                });
            }

        return {
            ajaxGetJson: ajaxGetJson,
            ajaxPostJson: ajaxPostJson,
            ajaxPutJson: ajaxPutJson,
            ajaxDeleteJson: ajaxDeleteJson,
        };

    })();

}(ajx));