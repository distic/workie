var LoginModule = (function () {

    function init() {

    }

    function onResetPasswordSubmitBegin() {

    }

    function onResetPasswordSubmitSuccess() {
        $('#title-forgot-password').remove();
        $('#description-forgot-password').remove();
        $('#ResetPasswordTableForm').remove();

        $('#title-success').removeClass('collapse');
        $('#description-success').removeClass('collapse');
    }

    function onResetPasswordSubmitFailure() {

    }

    // Reveal public pointers to private functions and properties
    return {
        init: init,
        onResetPasswordSubmitBegin: onResetPasswordSubmitBegin,
        onResetPasswordSubmitSuccess: onResetPasswordSubmitSuccess,
        onResetPasswordSubmitFailure: onResetPasswordSubmitFailure
    };

})();

$(function () {
    LoginModule.init();
});