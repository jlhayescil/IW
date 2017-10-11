(function (app) {
    //app.currentDate = moment().toDate();
    app.baseref = "/";


    app.errorMessage = "We apologize, but an error has occurred.";
    app.modelInvalid = "**We were unable to save your record. Please check your input.**";
    app.antixssErrorMessage = "**It appears that the input contains invalid characters.**";
    app.authorizationErrorMessage = "**We apologize, but an authorization error has occurred.**";
    app.getRecordsError = "An error has occurred in retrieving your results. ";
    app.saveRecordError = "An error has occurred in saving your record. ";
    app.deleteRecordError = "An error has occurred in deleting your record. ";
    app.error400 = "**We apologize, but an error has occurred.**";
    app.error401 = "**We apologize, but an authorization error has occurred.**";
    app.error404 = "**We apologize, but we have been unable to locate your record.**";
    app.isAdmin = Boolean($('#lblIsAdmin').text());
    //app.isAdmin = false;

    app.parseError = function (request) {
        var response = request.responseText;
        var errorMessage = app.errorMessage;
       
        if (request.status == 400) {
            errorMessage = app.error400;
        }
        else if (request.status == 401) {
            errorMessage = app.error401;
        }
        else if (request.status == 404) {
            errorMessage = app.error404;
        }

        app.displayError(errorMessage);
        return errorMessage;
    };
    app.clearError = function (request) {
        $('#errorMessage').text("");
        $('#errorMessage2').text("");
    }
    app.displayError = function (errorMessage) {
        $('#errorMessage').text(errorMessage);
        $('#errorMessage2').text(errorMessage);
    }

    app.isInt = function (value) {
        if ((parseFloat(value) == parseInt(value)) && !isNaN(value)) {
            return true;
        }
        return false;
    };

    app.isIE = function () {
        var myNav = navigator.userAgent.toLowerCase();
        return (myNav.indexOf('msie') != -1) ? parseInt(myNav.split('msie')[1]) : false;
    }
    app.isSafari = function () {
        var myNav = navigator.userAgent.toLowerCase();
        return (myNav.indexOf('safari') != -1) ? parseInt(myNav.split('safari')[1]) : false;
    }

    app.convertJSONToCSV = function (JSONData,fileName,ShowLabel) {
        var arrData = typeof JSONData != 'object' ? JSON.parse(JSONData) : JSONData;
        var CSV = '';
        if (ShowLabel) {
            var row = "";
            for (var index in arrData[0]) {
                row += index + ',';
            }
            row = row.slice(0, -1);
            CSV += row + '\r\n';
        }
        for (var i = 0; i < arrData.length; i++) {
            var row = "";
            for (var index in arrData[i]) {
                var arrValue = arrData[i][index] == null ? "" : '="' + arrData[i][index] + '"';
                row += arrValue + ',';
            }
            row.slice(0, row.length - 1);
            CSV += row + '\r\n';
        }
        if (CSV == '') {
            growl.error("Invalid data");
            return;
        }
        
        if (app.isIE()) {
            var IEwindow = window.open();
            IEwindow.document.write('sep=,\r\n' + CSV);
            IEwindow.document.close();
            IEwindow.document.execCommand('SaveAs', true, fileName + ".csv");
            IEwindow.close();
        } else if (app.isSafari()) {
            var blob = new Blob([csv]);
            var a = window.document.createElement("a");
            a.href = window.URL.createObjectURL(blob, { type: "text/plain" });
            a.download = fileName + ".csv";
            document.body.appendChild(a);
            a.click();
            document.body.removeChild(a);
        }
        else {
            var uri = 'data:application/csv;charset=utf-8,' + escape(CSV);
            var link = document.createElement("a");
            link.href = uri;
            link.style = "visibility:hidden";
            link.download = fileName + ".csv";
            document.body.appendChild(link);
            link.click();
            document.body.removeChild(link);
        }
    }


    app.formatCurrency = function (num) {
        num = num.toString().replace(/\$|\,/g, '');
        if (isNaN(num))
            num = "0";
        sign = (num == (num = Math.abs(num)));
        num = Math.floor(num * 100 + 0.50000000001);
        cents = num % 100;
        num = Math.floor(num / 100).toString();
        if (cents < 10)
            cents = "0" + cents;
        for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3) ; i++)
            num = num.substring(0, num.length - (4 * i + 3)) + ',' +
            num.substring(num.length - (4 * i + 3));
        return (((sign) ? '' : '-') + '$ ' + num + '.' + cents);
    }


    app.truncateDecimals = function (number, digits) {
        var multiplier = Math.pow(10, digits),
            adjustedNum = number * multiplier,
            truncatedNum = Math[adjustedNum < 0 ? 'ceil' : 'floor'](adjustedNum);

        return truncatedNum / multiplier;
    };

    app.loadEditor = function () {
        $("textarea.htmlEditor")
        .each(function () {

            var editorId = $(this).attr("id");

            try {
                var instance = CKEDITOR.instances[editorId];
                if (instance) { instance.destroy(true); }

            }
            catch (e) { }
            finally {
                CKEDITOR.replace(editorId,
                {
                    bodyClass: 'cke_body',
                    filebrowserImageBrowseUrl: '/ckeditor/ImageBrowser.aspx',
                    filebrowserImageUploadUrl: '/Home/UploadImage',
                    filebrowserBrowseUrl: '/ckeditor/LinkBrowser.aspx',
                    filebrowserUploadUrl: '/Home/UploadDocument',
                    filebrowserImageWindowWidth: '640',
                    filebrowserImageWindowHeight: '480',
                    filebrowserImageWindowWidth: '780',
                    filebrowserImageWindowHeight: '720',
                    filebrowserBrowseUrl: '/ckeditor/LinkBrowser.aspx',
                    filebrowserWindowWidth: '500',
                    filebrowserWindowHeight: '650'
                });
            }
        });
    };

    app.TrimTrailingWhitespace = function (content) {
        var regexString = "\s+$";
        var cleanedString = content.replace(regexString, "");
        return cleanedString;
    };

    app.TrimLeft = function (str, n) {
        if (n <= 0)
            return "";
        else if (n > String(str).length)
            return str;
        else
            return String(str).substring(0, n);
    };
    app.TrimRight = function (str, n) {
        if (n <= 0)
            return "";
        else if (n > String(str).length)
            return str;
        else {
            var iLen = String(str).length;
            return String(str).substring(iLen, iLen - n);
        }
    };

    app.validateMomentDate = function (dateStr) {
        if (typeof (dateStr) != "undefined" && dateStr != null) {
            var isValid = false;
            var date1 = moment(dateStr, 'MM/DD/YYYY');
            var date2 = moment(dateStr, 'MM/DD/YYYY');
            if (ko.validation.utils.isEmptyVal(dateStr) || moment(dateStr, 'MM/DD/YYYY').isValid())
            { isValid = true; }
            return isValid;
        }
        else { return true; }
    };

}(app));

