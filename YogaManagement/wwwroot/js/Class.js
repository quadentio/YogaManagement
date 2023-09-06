//# sourceURL=Class.js

var ClassComponents = {
    TypeOptions: ["Three", "Five", "Mix"],
    MonthOptions: [...Array(12)].map((_, index) => index + 1),
};

var RegisterViewModel = {
    ClassName: '',
    ClassType: '',
    MonthPeriod: '',
};

var ClassHandler = {

    getClassData: function () {
        // Call ajax to get class data viewmodel
        let data = {};
        let ajaxParams = $.extend({}, AJAX_PARAM_DEFAULT);
        ajaxParams[AJAX_PARAM_NAME.URL] = '';
        ajaxParams[AJAX_PARAM_NAME.DATA_TYPE] = AJAX_DATA_TYPE.JSON;
        ajaxParams[AJAX_PARAM_NAME.REQUEST_TYPE] = AJAX_REQUEST_TYPE.POST;
        ajaxParams[AJAX_PARAM_NAME.DATA] = data;
        ajaxParams[AJAX_PARAM_NAME.CALLBACK_SUCCESS] = function (result) {
            let objParsedData = COMMON_FUNCTION.checkResponse(result);
            if (objParsedData == null) {
                //alert('Error while');
                return;
            }
        };

        doAjax(ajaxParams);
    },

    init: function () {

    }
}

var ClassPopupHandler = {

    // Init register class popup screen
    initAddClass: function () {
        classTypeId = 'ClassType';
        monthPeriodId = 'MonthPeriod';
        let classtype = optionBuilder(classTypeId, ClassComponents.TypeOptions, true);
        let MonthPeriod = optionBuilder(monthPeriodId, ClassComponents.MonthOptions, true);
    },

    registerClass: function () {
        // AJAX
        let data = $.extend({}, RegisterViewModel);
        data['ClassName'] = $('#ClassName').val() ?? "";
        data['ClassType'] = $('#ClassType').val() ?? "";
        data['MonthPeriod'] = $('#MonthPeriod').val() ?? "";

        let ajaxParams = $.extend({}, AJAX_PARAM_DEFAULT);
        ajaxParams[AJAX_PARAM_NAME.URL] = registerClassDataUrl;
        ajaxParams[AJAX_PARAM_NAME.DATA_TYPE] = AJAX_DATA_TYPE.JSON;
        ajaxParams[AJAX_PARAM_NAME.REQUEST_TYPE] = AJAX_REQUEST_TYPE.POST;
        ajaxParams[AJAX_PARAM_NAME.DATA] = data;
        ajaxParams[AJAX_PARAM_NAME.CALLBACK_SUCCESS] = function (result) {
            let objParsedData = COMMON_FUNCTION.checkResponse(result);
            if (objParsedData == null) {
                alert("Register data fail, please try again!!");
                return null;
            }

            if (objParsedData.Errors.length > 0) {
                // Process errors
                ErrorHandler.displayError(objParsedData.Errors);
            }
        };

        doAjax(ajaxParams);
    },

    eventClickRegisterButton: function (event) {
        event.preventDefault();

        // Main Process
        ClassPopupHandler.registerClass();
    },

    init: function () {
        ClassPopupHandler.initAddClass();
        $('#btnConfirm').unbind('click').on('click', ClassPopupHandler.eventClickRegisterButton);
    }
}

var ErrorHandler = {
    displayError: function (errors) {
        let errorDiv = $(`#errorsValidation`);
        errorDiv.prop('hidden', false);

        // Not a good practice!!!
        let ul = $('<ul>');
        for (let error of errors) {
            for (let message of error.Messages) {
                let li = $('<li>').text(message);
                li.addClass('text-red');
                ul.append(li);
            }
        }

        errorDiv.empty();
        errorDiv.append(ul);
    },

    clearError: function () {
        let errorDiv = $('#errorsValidation');
        errorDiv.prop('hidden', true);
        errorDiv.empty();
    }
};

/**
 * Take option id
 * id: id of select
 * arrayOptions: array list contain options value and text
 * appendHead: append null select at head
 * return => DOM select with options (value and text are same)
 * require: JQuery
 */
var optionBuilder = function (id = "", arrayOptions = [], appendHead = false, headText = "Choose your option") {
    if (!id || arrayOptions.length == 0) { return null; }

    let selector = `#${id}`;
    let select = $(selector);

    if (appendHead === true) {
        let head = $('<option>').val("").text(headText)
            .prop('disabled', true)
            .prop('selected', true);
        select.append(head);
    }

    for (let item of arrayOptions) {
        let option = $('<option>').val(item).text(item);
        select.append(option);
    }

    return select;
}

$(document).ready(function () {
    ClassHandler.init();
    ClassPopupHandler.init();
});