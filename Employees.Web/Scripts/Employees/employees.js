(function (exports, app, $, Promise) {
    'use strict';
       
    function getEmployees() {

        var url = app.config.urlEmployeesApi + $("#txtEmployeeId").val();

        $.ajax({
            url: url,
            contentType: "application/json; charset=UTF-8",
            success: function (response) {
                var datatable = $('#tblEmployees').DataTable();
                datatable.clear();
                datatable.rows.add(response);
                datatable.draw();
            },
            error: function (error) {
                var errorMessage = error.responseJSON.Message;
                alert(errorMessage);
            }
        });
    }

    /**
     * Configure view events
     */
    function bindEvents() {
        $('#btnGetEmployees').on('click', getEmployees);
    }

    /**
     * Configure controls
     */
    function configureControls() {
        $('#tblEmployees').DataTable({
            columns: [
                { "data": "Name" },
                { "data": "ContractTypeName" },
                { "data": "RoleId" },
                { "data": "RoleName" },
                { "data": "RoleDescription" },
                { "data": "HourlySalary" },
                { "data": "MonthlySalary" },
                { "data": "AnnualSalary" }
            ]
        });
    }

    $(function () {
        configureControls();
        bindEvents();
    });

})(window.app.employees, window.app, window.$, window.Promise);