var dropdown = (function () {

    var initialize = function () {
        initializeDropdown();
    };

    var initializeDropdown = function () {
        $.get("/users/index", data => {
            data.forEach(user => {
                var dropdownItem = `<option value="${user.id}">${user.firstName} ${user.lastName}</option >`;
                $("#dropdownUsersMenu").append(dropdownItem);
            });
            $("#dropdownUsersMenu").on("change", list.loadDataTable);
        });
    };

    return {
        initialize
    };
}(dropdown));

$(document).ready(function () {
    dropdown.initialize();
});