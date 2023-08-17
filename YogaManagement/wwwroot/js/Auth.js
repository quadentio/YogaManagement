//# sourceURL=AuthHandler.js

var AuthHandler = {

    disableAutocomplete: function () {
        $('#UserName').val('');
        $('#Password').val('');
    },

    init: function () {
        AuthHandler.disableAutocomplete();
    }
};

$(document).ready(function () {
    AuthHandler.init();
});