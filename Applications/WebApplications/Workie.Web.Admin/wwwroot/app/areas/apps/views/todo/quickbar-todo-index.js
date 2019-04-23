var QuickbarTodoIndexModule = (function () {

    function init() {
        $('#TodoTableForm').submit();
    }

    /* Add Task Block (QuickBar) */
    function addTaskBlockQB(title) {
        $(".ms-quickbar-container .ms-todo-list").prepend(
            '<div class="ms-card ms-qa-card ms-deletable"> <div class="ms-card-header clearfix">' +
            '<h6 class="ms-card-title">' + title + '</h6> <button data-toggle="tooltip" data-placement="left" title="Add a Task to this block" class="ms-add-task-to-block ms-btn-icon float-right">' +
            '<i class="material-icons">add</i> </button> </div> <div class="ms-card-body"> <ul class="ms-list ms-task-block"> </ul></div>' +
            '<div class="ms-card-footer clearfix"><a href="#" class="text-disabled mr-2"> <i class="flaticon-archive"> </i> Archive </a><a href="#" class="text-disabled ms-delete-trigger float-right">' +
            '<i class="flaticon-trash"> </i> Delete </a> </div> </div>');
    }

    function deleteById(id) {

    }

    function onRefreshTodoTableSubmitBegin() {

    }

    function onRefreshTodoTableSubmitSuccess(data) {

    }

    function onRefreshTodoTableSubmitFailure(ajaxContent) {

    }

    function onAddOrModifyTodoViewSubmitBegin() {
        addTaskBlockQB($("#task-block").val());
    }

    function onAddOrModifyTodoViewSubmitSuccess(data) {
        
    }

    function onAddOrModifyTodoViewSubmitFailure(ajaxContent) {
    }

    // Reveal public pointers to private functions and properties
    return {
        init: init,
        addTaskBlockQB: addTaskBlockQB,
        deleteById: deleteById,
        onRefreshTodoTableSubmitBegin: onRefreshTodoTableSubmitBegin,
        onRefreshTodoTableSubmitSuccess: onRefreshTodoTableSubmitSuccess,
        onRefreshTodoTableSubmitFailure: onRefreshTodoTableSubmitFailure,
        onAddOrModifyTodoViewSubmitBegin: onAddOrModifyTodoViewSubmitBegin,
        onAddOrModifyTodoViewSubmitSuccess: onAddOrModifyTodoViewSubmitSuccess,
        onAddOrModifyTodoViewSubmitFailure: onAddOrModifyTodoViewSubmitFailure
    };

})();

$(function () {
    QuickbarTodoIndexModule.init();
});