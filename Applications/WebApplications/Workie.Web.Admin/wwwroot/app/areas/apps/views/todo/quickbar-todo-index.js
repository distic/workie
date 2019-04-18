var QuickbarTodoIndexModule = (function () {

    function addOrModifyTodoView(id) {

        $.getJSON(window.getAddOrModifyTodoView(id), function () {

        }).done(function (data) {
            if (data.result === true) {
                alert('Successfully added a ToDo :-)');
            } else {
                alert('Could not add ToDo !!');
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log('getJSON request failed! ' + textStatus);
        }).always(function () {
            console.log('getJSON request ended!');
        });
    }

    function deleteTodo(id) {

        $.getJSON(window.getDeleteTodoUrl(id), function () {

        }).done(function (data) {
            if (data.result === true) {
                alert('Successfully deleted ToDo :-)');
            } else {
                alert('Could not delete ToDo !!');
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            console.log('getJSON request failed! ' + textStatus);
        }).always(function () {
            console.log('getJSON request ended!');
        });
    }

    // Reveal public pointers to private functions and properties
    return {
        addOrModifyTodoView: addOrModifyTodoView,
        deleteTodo: deleteTodo
    };

})();