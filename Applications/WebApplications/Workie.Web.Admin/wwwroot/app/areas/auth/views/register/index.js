var RegisterResultModule = (function () {

    function init() {

    }

    function verifyEmail() {
        $('#VerifyEmailTableForm').submit();
    }

    ////////////////////////////////////
    // Verify CALLBACKS
    ////////////////////////////////////

    function onVerifyEmailSubmitBegin() {
        //App.startPageLoading();
        console.log('Submit began...');
    }

    function onVerifyEmailSubmitSuccess(data) {
        //App.stopPageLoading();
        console.log('Submit Success!');
    }

    function onVerifyEmailSubmitFailure(ajaxContext) {
        //App.stopPageLoading();
        console.log('Submit Failure, server error!');
    }

   

    // Reveal public pointers to private functions and properties
    return {
        init: init,
        verifyEmail: verifyEmail,
        onVerifyEmailSubmitBegin: onVerifyEmailSubmitBegin,
        onVerifyEmailSubmitSuccess: onVerifyEmailSubmitSuccess,
        onVerifyEmailSubmitFailure: onVerifyEmailSubmitFailure,
    };

})();

$(function () {
    RegisterResultModule.init();
});