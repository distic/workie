var QuickbarTodoIndexModule = (function () {

    function init() {
        $('#TodoTableForm').submit();
        handleDeleteTodo();
    }

    /* Add Task Block (QuickBar) */
    function addTaskBlockQB(title) {
        $('#dt-table-empty-part').remove();
        $(".ms-quickbar-container .ms-todo-list").prepend(
            '<div class="ms-card ms-qa-card ms-deletable"> <div class="ms-card-header clearfix">' +
            '<h6 class="ms-card-title">' + title + '</h6> <button data-toggle="tooltip" data-placement="left" title="Add a Task to this block" class="ms-add-task-to-block ms-btn-icon float-right">' +
            '<i class="material-icons">add</i> </button> </div> <div class="ms-card-body"> <ul class="ms-list ms-task-block"> </ul></div>' +
            '<div class="ms-card-footer clearfix"><a href="#" class="text-disabled mr-2"> <i class="flaticon-archive"> </i> Archive </a><a href="#" class="text-disabled ms-delete-trigger float-right">' +
            '<i class="flaticon-trash"> </i> Delete </a> </div> </div>');
    }

    function handleDeleteTodo(id) {
        $('body').on('click', '.ms-delete-trigger', function () {

            var handle = $(this);
            var id = $(this).attr('value');

            $.ajax({
                url: window.getDeleteTodoByIdUrl(id),
                success: function (result) {
                    handle.closest('.ms-deletable').slideUp('slow', function () {
                        handle.closest('.ms-deletable').remove();
                    });
                }
            });
        });
    }

    function onRefreshTodoTableSubmitBegin() {

    }

    function onRefreshTodoTableSubmitSuccess(data) {

    }

    function onRefreshTodoTableSubmitFailure(ajaxContent) {

    }

    function onAddOrModifyTodoViewSubmitBegin() {
        var taskBlock = $("#task-block");

        if (taskBlock.val() == '') {
            alert('Empty fields are not allowed.');
            return;
        }

        addTaskBlockQB(taskBlock.val());
        taskBlock.val('');
    }

    function onAddOrModifyTodoViewSubmitSuccess(data) {

    }

    function onAddOrModifyTodoViewSubmitFailure(ajaxContent) {
    }

    // Reveal public pointers to private functions and properties
    return {
        init: init,
        addTaskBlockQB: addTaskBlockQB,
        handleDeleteTodo: handleDeleteTodo,
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