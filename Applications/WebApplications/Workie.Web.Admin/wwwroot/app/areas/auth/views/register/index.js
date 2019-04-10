var RegisterResultModule = (function () {

    function init() {
        viewRegister();
    }

    function verifyEmail() {
        $('#VerifyEmailTableForm').submit();
    }

    function viewRegister() {
        $('#ViewRegisterTableForm').submit();
    }

    ////////////////////////////////////
    // VIEW CALLBACKS
    ////////////////////////////////////

    function onViewRegisterSubmitBegin() {
        //App.startPageLoading();
        console.log('Submit began...');
    }

    function onViewRegisterSubmitSuccess(data) {
        //App.stopPageLoading();
        console.log('Submit Success!');
    }

    function onViewRegisterSubmitFailure(ajaxContext) {
        //App.stopPageLoading();
        console.log('Submit Failure, server error!');
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
        onViewRegisterSubmitBegin: onViewRegisterSubmitBegin,
        onViewRegisterSubmitSuccess: onViewRegisterSubmitSuccess,
        onViewRegisterSubmitFailure: onViewRegisterSubmitFailure,
        onVerifyEmailSubmitBegin: onVerifyEmailSubmitBegin,
        onVerifyEmailSubmitSuccess: onVerifyEmailSubmitSuccess,
        onVerifyEmailSubmitFailure: onVerifyEmailSubmitFailure,
    };

})();

$(function () {
    RegisterResultModule.init();
});