/*
 * Constants for error code
 * */
const ERROR_CODE = {
    ERROR_EXCEPTION_CODE: 1,
    ERROR_TIMEOUT_CODE: 2,
    ERROR_SHOW_MESSAGE_CODE: 3,
    SHOW_NORMAL_MESSAGE_CODE: 4,
    ERROR_FORGERY_TOKEN: 5
};

/**
 * Constants for popup
 * */
const POPUP_CONST = {
    HEIGHT_130: 130,
    HEIGHT_150: 150,
    HEIGHT_160: 160,
    HEIGHT_170: 170,
    HEIGHT_190: 190,
    WIDTH_360: 360,
    WIDTH_400: 400,
    WIDTH_450: 450
};

/**
 * Common function
 * */
var COMMON_FUNCTION = {
    /**
     * Check response return from ajax
     * @param {any} result Object
     * @returns {any} Object
     */
    checkResponse: function (result) {
        if (result !== null) {
            var objResult = JSON.parse(result);

            if (objResult) {
                return objResult;
            } else {
                // Result null
                return null;
            }
        } else {
            // Result null
            return null;
        }
    },

    checkResponseHtml: function (result) {
        if (result.getResponseHeader('content-type').indexOf('text/html') >= 0) {
            return true;
        } else {
            return false;
        }
    },

    showErrorAjax: function (result) {
        if (result != '') {
            alert(result);
        }
    },

    checkValueIsValid: function (lstParam) {
        // Create an object:
        var resultObj = {
            isValid: true,
            message: ""
        };
        // Create format common
        var format = /[`*+{};':"|,<>~]/;
        $.each(lstParam, function (key, value) {

            if (format.test(value) == true) {
                // is not valid
                resultObj.isValid = false;
                resultObj.message = "テキストコンテンツに無効な文字が含まれています。";
                // return and break loop
                return resultObj;
            }
        });
        // is valid
        return resultObj;
    },

    showMessageInvalidInput: function (objError) {
        if (objError.divParent && objError.divParent != "") {
            $(objError.divParent).show();
        }
        $(objError.idValidateMessage).text('');
        if (objError.isValid == false) {
            $(objError.idValidateMessage).append(objError.message);
            $(objError.idValidateMessage).append($('<br>'));
            $(objError.idValidateMessage).append($('<br>'));
        }
    },

    hideMessageInvalidInput: function (objError) {
        if (objError.divParent && objError.divParent != "") {
            $(objError.divParent).hide();
        }
        $(objError.idValidateMessage).text('');
    },

    refreshAntiForgeryToken: function () {
        // AJAX get token and update __RequestVerificationToken
        let ajaxParams = $.extend({}, AJAX_PARAM_DEFAULT);
        ajaxParams[AJAX_PARAM_NAME.URL] = urlRefreshToken;
        ajaxParams[AJAX_PARAM_NAME.DATA_TYPE] = AJAX_DATA_TYPE.HTML;
        ajaxParams[AJAX_PARAM_NAME.REQUEST_TYPE] = AJAX_REQUEST_TYPE.POST;
        ajaxParams[AJAX_PARAM_NAME.CALLBACK_SUCCESS] = function (result, textStatus, jqXHR) {
            if (result !== null && result !== '') {
                // Check result including HTML or Json
                if (COMMON_FUNCTION.checkResponseHtml(jqXHR)) {

                    var tokenValue = $('<div>').html(result).find('input[type="hidden"]').val();
                    $('input[name=__RequestVerificationToken]').val(tokenValue);

                } else {
                    // Ajax not return HTML (Timeout Error)
                    let objParsedData = checkResponse(result);
                    if (objParsedData === null) return;
                }
            } else {
                // Response null (DO NOTHING)
                return;
            }
        };
        return doAjax(ajaxParams);
    },

    hideElement: function (id) {
        $(id).addClass("hidden");
    },

    showElement: function (id) {
        $(id).removeClass("hidden");
    },

    disableElement: function (id) {
        $(id).attr('disabled', 'disabled');
    },

    enableElement: function (id) {
        $(id).removeAttr('disabled');
    },

    lockAlwayElement: function (id) {
        $(id).addClass('LOCKED');
    },

    checkLockElement: function (id) {
        return $(id).hasClass('LOCKED');
    }
};

/**
 * Format function
 * */
var FORMAT_FUNCTION = {
    inputConvertNumberFullSizeToHalfSize: function () {
        $(this).val(convertNumberFullSizeToHalfSize($.trim($(this).val())));
        $(this).val($(this).val().replace(/\D/g, ''));
    },

    onlyAllowInputNumberHalfSize: function (e) {
        // Only number key is allowed
        if (!/[0-9]/.test(String.fromCharCode(e.which))) {
            e.preventDefault();
        }
    },

    inputConvertNumberFullSizeToHalfSizeMonthDay: function () {
        $(this).val(convertNumberFullSizeToHalfSize($.trim($(this).val())));
        $(this).val($(this).val().replace(/\D/g, ''));
        $(this).val(addZeroToNumber($(this).val(), 2));
    },

    formatDateDashToDateDot: function (date) {
        var originalDate = date;
        var d, month, day, year;

        d = new Date(date);
        month = '' + (d.getMonth() + 1);
        day = '' + d.getDate();
        year = d.getFullYear();

        if (month.length < 2) month = '0' + month;
        if (day.length < 2) day = '0' + day;

        if ((year || month || day) === 'NaN')
            return originalDate;

        return [year, month, day].join('.');
    },

    convertFullsizeNumberToHalfsizeNumber: function ($input) {
        $input.val(convertNumberFullSizeToHalfSize($.trim($input.val())));
        $input.val($input.val().replace(/\D/g, ''));
    }
};

var DATE_FUNCTION = {
    /**
     * Get current date
     * @returns {string} - Date
     */
    getCurrentDate: function () {
        var d = new Date();
        var month = d.getMonth() + 1;
        var day = d.getDate();
        var output = d.getFullYear() + '-' + String(month).padStart(2, '0') + '-' + String(day).padStart(2, '0');
        return parseISO8601(output);
    },

    /**
     * Get current date in format yyyy.MM.dd
     * @returns {Date} - yyyy.MM.dd
     * */
    getCurrentDateDot: function () {
        return DATE_FUNCTION.parseDateObjectToDateWithSplitChar(new Date(), '.');
    },

    /**
     * Get current time in format HH:mm
     * @returns {Date} - HH:mm
     * */
    getCurrentTimeHHMM: function () {
        let currentDate = new Date();
        let currentHour = currentDate.getHours();
        let currentMinute = currentDate.getMinutes();
        let displayTime = String(currentHour).padStart(2, '0') + ":" + String(currentMinute).padStart(2, '0');
        return displayTime;
    },

    /**
     * Parse string date from yyyy-MM-dd to string format yyyy{0}MM{0}dd
     * @param {string} date - yyyy-MM-dd
     * @param {string} splitChar - {-}, {/}, {.}
     * @returns {Date} - DateString
     */
    parseDateStringToDateWithSplitChar: function (date, splitChar) {
        var originalDate = date;
        var d, month, day, year;

        d = new Date(date);
        month = '' + (d.getMonth() + 1);
        day = '' + (d.getDate());
        year = (d.getFullYear());

        month = String(month).padStart(2, '0');
        day = String(day).padStart(2, '0');

        if ((year || month || day) === 'NaN')
            return originalDate;

        return [year, month, day].join(splitChar);
    },

    /**
     * Parse date object to string format yyyy{0}MM{0}dd
     * @param {string} d - DateObject
     * @param {string} splitChar - {-}, {/}, {.}
     * @returns {Date} - DateString
     */
    parseDateObjectToDateWithSplitChar: function (d, splitChar) {
        var month, day, year;

        month = '' + (d.getMonth() + 1);
        day = '' + (d.getDate());
        year = (d.getFullYear());

        month = String(month).padStart(2, '0');
        day = String(day).padStart(2, '0');

        if ((year || month || day) === 'NaN')
            return '';

        return [year, month, day].join(splitChar);
    }
};

var POPUP_RESULT_FUNCTION = {
    initPopup: function (width, height) {
        // Init popup
        $('#dialog-notification').attr('fixed-height', height);

        let dialogParams = $.extend({}, DIALOG_PARAM_DEFAULT);
        dialogParams[DIALOG_PARAM_NAME.ID] = "dialog-notification";
        dialogParams[DIALOG_PARAM_NAME.IS_KEEP_HTML] = true;
        dialogParams[DIALOG_PARAM_NAME.HEIGHT] = height;
        dialogParams[DIALOG_PARAM_NAME.WIDTH] = width;

        popupResult = doInitDialog(dialogParams);
    },

    showPopup: function (callbackOK, message) {
        // Show popup
        $('#dialog-notification #dialogContent').text(message);

        // Set event close dialog
        $('#dialog-notification #btnPopupOk').unbind('click').on('click', function () {
            doCloseDialog(popupResult);
            if (typeof callbackOK === "function") {
                callbackOK();
            }
        });
        doOpenDialog(popupResult);
        // Resize after show (jquery auto add new line at bottom popup)
        popupResult.dialog("option", "height", $('#dialog-notification').attr('fixed-height'));
    }
};

var POPUP_CONFIRM_FUNCTION = {
    initPopup: function (width, height) {
        // Init popup
        $('#dialog-confirm').attr('fixed-height', height);

        let dialogParams = $.extend({}, DIALOG_PARAM_DEFAULT);
        dialogParams[DIALOG_PARAM_NAME.ID] = "dialog-confirm";
        dialogParams[DIALOG_PARAM_NAME.IS_KEEP_HTML] = true;
        dialogParams[DIALOG_PARAM_NAME.HEIGHT] = height;
        dialogParams[DIALOG_PARAM_NAME.WIDTH] = width;

        popupConfirm = doInitDialog(dialogParams);
    },

    showPopup: function (callbackYes, callbackNo, message) {
        // Show popup
        $('#dialog-confirm #dialogContent').html(message);

        $('#dialog-confirm #yesConfirm').unbind('click').on('click', function () {
            doCloseDialog(popupConfirm);
            if (typeof callbackYes === "function") {
                callbackYes();
            }
        });

        $('#dialog-confirm #noConfirm').unbind('click').on('click', function () {
            doCloseDialog(popupConfirm);
            if (typeof callbackNo === "function") {
                callbackNo();
            }
        });

        doOpenDialog(popupConfirm);
        // Resize after show (jquery auto add new line at bottom popup)
        popupConfirm.dialog("option", "height", $('#dialog-confirm').attr('fixed-height'));
    }
};