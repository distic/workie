var ProfileModule = (function () {

    function init() {
        viewProfile();
    }

    function editProfile() {
        $('#EditProfileTableForm').submit();
    }

    function viewProfile() {
        $('#ViewProfileTableForm').submit();
    }

    ////////////////////////////////////
    // EDIT CALLBACKS
    ////////////////////////////////////

    function onEditProfileSubmitBegin() {
        //App.startPageLoading();
        console.log('Submit began...');
    }

    function onEditProfileSubmitSuccess(data) {
        //App.stopPageLoading();
        console.log('Submit Success!');
    }

    function onEditProfileSubmitFailure(ajaxContext) {
        //App.stopPageLoading();
        console.log('Submit Failure, server error!');
    }

    ////////////////////////////////////
    // VIEW CALLBACKS
    ////////////////////////////////////

    function onViewProfileSubmitBegin() {
        //App.startPageLoading();
        console.log('Submit began...');
    }

    function onViewProfileSubmitSuccess(data) {
        //App.stopPageLoading();
        console.log('Submit Success!');
    }

    function onViewProfileSubmitFailure(ajaxContext) {
        //App.stopPageLoading();
        console.log('Submit Failure, server error!');
    }

    ////////////////////////////////////
    // UPDATE CALLBACKS
    ////////////////////////////////////

    function onUpdateProfileSubmitBegin() {
        //App.startPageLoading();
        console.log('Submit began...');
    }

    function onUpdateProfileSubmitSuccess(data) {
        //App.stopPageLoading();
        console.log('Submit Success!');
        viewProfile();
    }

    function onUpdateProfileSubmitFailure(ajaxContext) {
        //App.stopPageLoading();
        console.log('Submit Failure, server error!');
    }

    // Reveal public pointers to private functions and properties
    return {
        init: init,
        editProfile: editProfile,
        viewProfile: viewProfile,
        onEditProfileSubmitBegin: onEditProfileSubmitBegin,
        onEditProfileSubmitSuccess: onEditProfileSubmitSuccess,
        onEditProfileSubmitFailure: onEditProfileSubmitFailure,
        onViewProfileSubmitBegin: onViewProfileSubmitBegin,
        onViewProfileSubmitSuccess: onViewProfileSubmitSuccess,
        onViewProfileSubmitFailure: onViewProfileSubmitFailure,
        onUpdateProfileSubmitBegin: onUpdateProfileSubmitBegin,
        onUpdateProfileSubmitSuccess: onUpdateProfileSubmitSuccess,
        onUpdateProfileSubmitFailure: onUpdateProfileSubmitFailure
    };

})();

$(function () {
    ProfileModule.init();
});