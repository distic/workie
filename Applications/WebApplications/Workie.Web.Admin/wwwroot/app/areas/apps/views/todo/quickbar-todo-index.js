var QuickbarTodoIndexModule = (function () {

    function addOrModifyTodoView() {
        console.log('Hit me!');
    }

    function deleteTodo(id) {
        console.log('Delete');
        // window.location.href = window.getDeleteTodoUrl(id);
    }

    // Reveal public pointers to private functions and properties
    return {
        addOrModifyTodoView: addOrModifyTodoView,
        deleteTodo: deleteTodo
    };

})();