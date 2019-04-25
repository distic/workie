var QuickbarTodoIndexModule = (function () {

    var taskIdArray;

    function init() {
        $('#TodoTableForm').submit();
        handleDeleteTodo();
    }

    /* Add Task Block (QuickBar) */
    function addTaskBlockQB(title) {
        $('#dt-table-empty-part').remove();
        var taskView = $('#TaskViewTemplate');
        taskView.find('.ms-card-title').text(title);
        $('.ms-quickbar-container .ms-todo-list').prepend(taskView.html());
    }

    /* Add a Task to Block */
    function addTask() {
        $('.ms-todo-list').on('click', '.ms-add-task-to-block', function () {
            var taskBlock = $(this).parent().next().find('.ms-task-block');
            taskBlock.append($('#SubtaskEditTemplate').html());
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
            $(this).replaceWith('<span>' + taskInput.val() + '</span><button class="close"><i class="flaticon-trash ms-delete-trigger"></i></button>');

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

    function onAddEditTaskSubmitBegin() {
        var taskBlock = $("#task-block");

        if (taskBlock.val() == '') {
            alert('Empty fields are not allowed.');
            return;
        }

        addTaskBlockQB(taskBlock.val());
        taskBlock.val('');
    }

    function onAddEditTaskSubmitSuccess(data) {

    }

    function onAddEditTaskSubmitFailure(ajaxContent) {
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
        onAddEditTaskSubmitBegin: onAddEditTaskSubmitBegin,
        onAddEditTaskSubmitSuccess: onAddEditTaskSubmitSuccess,
        onAddEditTaskSubmitFailure: onAddEditTaskSubmitFailure
    };

})();

$(function () {
    QuickbarTodoIndexModule.init();
});