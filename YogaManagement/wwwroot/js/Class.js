//# sourceURL=Class.js

var ClassHanlder = {

    getClassData: function () {
        // Call ajax to get class data viewmodel
        let data = {};
        let ajaxParams = $.extend({}, AJAX_PARAM_DEFAULT);
        ajaxParams[AJAX_PARAM_NAME.URL] = '';
        ajaxParams[AJAX_PARAM_NAME.DATA_TYPE] = AJAX_DATA_TYPE.JSON;
        ajaxParams[AJAX_PARAM_NAME.REQUEST_TYPE] = AJAX_REQUEST_TYPE.POST;
        ajaxParams[AJAX_PARAM_NAME.DATA] = data;
        ajaxParams[AJAX_PARAM_NAME.CALLBACK_SUCCESS] = function () { };

        doAjax(ajaxParams);
    },

    init: function () {

    }
}

$(document).ready(function () {
    ClassHanlder.init();
});