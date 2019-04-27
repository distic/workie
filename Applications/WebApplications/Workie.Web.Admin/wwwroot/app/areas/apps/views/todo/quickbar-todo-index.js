var QuickbarTodoIndexModule = (function () {

    function init() {
        $('#TodoTableForm').submit();
    }

    function addTaskBlockQB(id, title) {
        $('#dt-table-empty-part').remove();
        var taskView = $('#TaskViewTemplate');
        taskView.find('.ms-card-title').text(title);
        taskView.find('#TaskId').val(id);
        return $('.ms-quickbar-container .ms-todo-list').prepend(taskView.html());
    }

    function addSubtaskView(id, desc, taskView) {
        var taskBlock = taskView.find('.ms-task-block');
        var subtask = $('#SubtaskViewTemplate');
        subtask.find('#subtask-description').text(desc);
        subtask.find('#SubtaskId').val(id);
        taskBlock.append(subtask.html());
    }

    /* === HANDLERS === */

    function handleAddSubtaskEdit() {
        $('.ms-todo-list').on('click', '.ms-add-task-to-block', function () {
            var taskBlock = $(this).parent().next().find('.ms-task-block');
            taskBlock.append($('#SubtaskEditTemplate').html());
            taskBlock.find('.ms-task-edit').focus();
        });
    }

    function deleteSubtask(e) {
        var handle = $(e);

        var taskId = handle.closest("ul").parent().parent().find('#TaskId').val();
        var subtaskId = handle.parent().find('#SubtaskId').val();

        var x = 1;
        $.ajax({
            url: window.getDeleteSubtaskUrl(taskId, subtaskId),
            success: function (result) {
                $(this).closest('.ms-deletable').slideUp('slow', function () {
                    $(this).closest('.ms-deletable').remove();
                });
            }
        });
    }

    function deleteTodo(e) {
        var handle = $(e);
        var taskId = handle.parent().parent().find('#TaskId').val();
        $.ajax({
            url: window.getDeleteTodoByIdUrl(taskId),
            success: function (result) {
                handle.closest('.ms-deletable').slideUp('slow', function () {
                    handle.closest('.ms-deletable').remove();
                });
            }
        });
    }

    function handleConfirmTask() {
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

    function handleTaskComplete() {
        $(".ms-todo-list").on('click', '.ms-todo-complete', function () {
            $(this).parent().toggleClass('task-complete');
        });
    }


    /* === Refresh Todo Table === */

    function onRefreshTodoTableSubmitBegin() {

    }

    function onRefreshTodoTableSubmitSuccess(data) {

        if (data.result == false) {
            return;
        }

        $.each(data.list, function (index, task) {
            var taskView = addTaskBlockQB(task.Id, task.Title);
            $.each(task.SubtaskList, function (index, subtask) {
                addSubtaskView(subtask._id, subtask.Description, taskView);
            });
        });

        handleAddSubtaskEdit();
        handleConfirmTask();
        handleTaskComplete();
        // handleDeleteSubtask();
    }

    function onRefreshTodoTableSubmitFailure(ajaxContent) {

    }

    /* === AddEditTask === */

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
        addSubtaskView: addSubtaskView,
        handleAddSubtaskEdit: handleAddSubtaskEdit,
        handleConfirmTask: handleConfirmTask,
        deleteSubtask: deleteSubtask,
        handleTaskComplete: handleTaskComplete,
        deleteTodo: deleteTodo,
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