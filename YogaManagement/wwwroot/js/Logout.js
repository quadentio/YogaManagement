//# sourceURL=Logout.js

var LogoutHandler = {

    execLogout: function (event) {
        event.preventDefault();
        $('#logoutForm').submit();
    },

    init: function () {
        $('#btnLogout').unbind().on('click', LogoutHandler.execLogout);
    }
};

$(document).ready(function () {
    LogoutHandler.init();
});