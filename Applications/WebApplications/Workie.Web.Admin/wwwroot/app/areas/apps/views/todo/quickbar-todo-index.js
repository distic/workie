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
            '<div class="ms-card-footer clearfix"><a href="#" class="text-disabled mr-2"> <i class="flaticon-archive"> </i> Archive </a><a value="0" href="#" class="text-disabled ms-delete-trigger float-right">' +
            '<i class="flaticon-trash"> </i> Delete </a> </div> </div>');
    }

    /* Add a Task to Block */
    function addTask() {
        $('.ms-todo-list').on('click', '.ms-add-task-to-block', function () {
            var taskBlock = $(this).parent().next().find('.ms-task-block');
            taskBlock.append(
                '<li class="ms-list-item ms-to-do-task ms-deletable">' +
                '<label class="ms-checkbox-wrap ms-todo-complete" for="">' +
                '<input type="checkbox" name="" value="">' +
                '<i class="ms-checkbox-check"></i>' +
                '</label>' +
                '<form class="ms-confirm-task-form"> <input type="text" class="ms-task-input ms-task-edit"/>' +
                '<button type="submit" class="close"><i class="material-icons fs-16 ms-confirm-trigger">check</i></button></form>' +
                '</li>'
            );
            taskBlock.find('.ms-task-edit').focus();
        });
    }

    /* Notes Remove */
    function deleteSubtask() {
        $('body').on('click', '.ms-delete-trigger', function () {
            var handle = $(this);

            var par = handle.parent();

            $.ajax({
                url: window.getDeleteSubtaskUrl('', ''),
                success: function (result) {
                    $(this).closest('.ms-deletable').slideUp('slow', function () {
                        $(this).closest('.ms-deletable').remove();
                    });
                }
            });
        });
    }

    /* Confirm task after adding */
    function confirmTask() {
        $(".ms-todo-list").on('submit', '.ms-confirm-task-form', function (e) {
            e.preventDefault();
            var confirmBtn = $(this).find('i');
            var taskInput = $(this).find('.ms-task-input');
            confirmBtn.removeClass('material-icons fs-14 ms-confirm-trigger');
            confirmBtn.addClass('');
            confirmBtn.text('');
            $(this).replaceWith('<span>' + taskInput.val() + '</span><button class="close"><i class="flaticon-trash ms-delete-trigger"> </i></button>');

            $.ajax({
                url: window.getAddEditSubtaskUrl('', '', taskInput.val()),
                success: function (result) {
                    alert('saved!');
                }
            });

        });
    }

    /* Complete To-Do Task */
    function taskComplete() {
        $(".ms-todo-list").on('click', '.ms-todo-complete', function () {
            $(this).parent().toggleClass('task-complete');
        });
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
        addTask();
        confirmTask();
        taskComplete();
        deleteSubtask();
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
        addTask: addTask,
        confirmTask: confirmTask,
        deleteSubtask: deleteSubtask,
        taskComplete: taskComplete,
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