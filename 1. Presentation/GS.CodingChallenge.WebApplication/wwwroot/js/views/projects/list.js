var list = (function () {

    var loadDataTable = function () {
        $("#tableProjects tbody").empty();
        let userId = $(this).val();
        let url = `/projects/list/${userId}`;
        $.get(url, function (data) {
            data.forEach(project => {
                let startDate = new Date(project.startDate);
                let endDate = new Date(project.endDate);
                let tableRow = `<tr><td>${project.id}</td>`;
                tableRow += `<td>${startDate.toLocaleDateString("en-US")}</td>`;
                tableRow += `<td>${project.timeToStart}</td>`;
                tableRow += `<td>${endDate.toLocaleDateString("en-US")}</td>`;
                tableRow += `<td>${project.credits}</td>`;
                tableRow += `<td>${project.status}</td></tr>`;

                $("#tableProjects tbody").append(tableRow);
            });
        });
    };

    return {
        loadDataTable
    };
}(list));