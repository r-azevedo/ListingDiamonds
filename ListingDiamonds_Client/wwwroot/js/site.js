// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/*api:  https://localhost:44318/api/ItemPhotoPropertySets/
        https://localhost:44318/api/ItemPhotos/
        https://localhost:44318/api/Items/
        https://localhost:44318/api/Properties/
        https://localhost:44318/api/TypePropertySet/
        https://localhost:44318/api/Types/

*/

const API_UploadImage = "https://localhost:44318/api/ItemPhotos/UploadImage?id=";
const API_GetPhoto = "https://localhost:44318/Photos/";
const API_GetItemPhotoPropertySet = "https://localhost:44318/api/ItemPhotoPropertySets/GetItemPhotoPropertySet";

window.addEventListener('load', (event) => {
    loadIntoTable(API_GetItemPhotoPropertySet);
});


async function loadIntoTable(url) {
    var table = document.querySelector("table");
    const tableHead = table.querySelector("thead");
    const tableBody = table.querySelector("tbody");



    //clear table
    tableHead.innerHtml = "<tr><th></th></tr>";
    tableBody.innerHtml = "";

    const result = await fetch(url,
        {
            method: 'get',
            headers: { 'Content-Type': 'application/json' }
        }).then(function (response) {
            return response.json();
        }).then(function (data) {
            var header = new Set();
            var rows = new Set();
            var numOfDifferentData = new Set();

            for (const id of data) {
                if (!numOfDifferentData.has(id.itemPhotoId)){
                    numOfDifferentData.add(id.itemPhotoId); /*Creates set with different items that exist on JSON data*/
                }
                if (id.propertyId === 1) {
                    if (header.has(id.value)) {
                        continue;
                    }
                    else {
                        header.add(id.value);
                    }
                }
                else if (id.propertyId === 2) {
                    if (rows.has(id.value)) {
                        continue;
                    }
                    else {
                        rows.add(id.value);
                    }
                }
            }

            table = document.querySelector("table");

            if (header && header.size > 0) {
                header = Array.from(header);
                for (let text of header) {
                    const headerElement = document.createElement("th");
                    const tableHead = table.querySelector("thead");

                    headerElement.textContent = text;

                    tableHead.querySelector("tr").appendChild(headerElement);
                }
            }

            if (rows && rows.size > 0) {
                rows = Array.from(rows);
                for (let rowText of rows) {
                    const rowElement = document.createElement("th");
                    const tableBody = table.querySelector("tbody");
                    const newRow = document.createElement("tr");

                    rowElement.textContent = rowText;

                    tableBody.appendChild(newRow);
                    tableBody.querySelector("tr:last-child").appendChild(rowElement);
                    for (let cell of header) {
                        const createCell = document.createElement("td");

                        newRow.appendChild(createCell);
                    }
                }
            }


            numOfDifferentData = Array.from(numOfDifferentData);

            var allValues = Array.from(data);

            for (let diffData of numOfDifferentData) {
                var filteredValues = allValues.filter(item => item.itemPhotoId === diffData);

                var column = 1;
                var row = 1;

                var tableColHeaders = document.querySelectorAll("thead tr th");
                var tableColRows = document.querySelectorAll("tbody tr th");

                var rowSelected, columnSelected = false;

                for (let propertyValue of filteredValues) {
                    for (var i = 1; i < tableColHeaders.length; i++) {
                         if (tableColHeaders[i].innerHTML == propertyValue.value) {
                             column = i;
                             columnSelected = true;
                             break;
                            }
                    }
                    for (var j = 0; j < tableColRows.length; j++) {
                         if (tableColRows[j].innerHTML == propertyValue.value) {
                             row = j + 1;
                             rowSelected = true;
                             break;
                            }
                    }

                    if (columnSelected && rowSelected) {
                        var btn = document.createElement('span');
                        btn.innerHTML = "<br> <input id=" + propertyValue.itemPhotos.id + "\ type='file' value='Edit' onChange='uploadFile(this)' />";
                        /*
                        btn.type = "file";
                        btn.innerHTML = 'Edit';
                        btn.onclick = function (id) { uploadFile(id); } ;
                        btn.id = propertyValue.itemPhotos.ItemId;*/
                        document.querySelector("table").rows[row].cells[column].innerHTML = '<img src="' + API_GetPhoto + propertyValue.itemPhotos.fileName + '" id="img_' + propertyValue.itemPhotos.id + '" />';
                        document.querySelector("table").rows[row].cells[column].appendChild(btn);

                        columnSelected, rowSelected = false;
                    }
                }
            }

            table.removeAttribute('hidden');

            return data;
        });
}

async function uploadFile(e) {
    var uploadAPI = API_UploadImage + e.id;

    var data = new FormData();
    data.append('formFile', e.files[0]);
    data.append('fileName', e.files[0].name);


    await fetch(uploadAPI, {
        method: 'POST',
        body: data
    }).then(
        response => console.log(response)
    ).then(
        ok => {
            var img = document.getElementById("img_" + e.id);
            img.setAttribute('src', API_GetPhoto + e.files[0].name);

            window.location.href = window.location.href
        }
    ).catch(
        error => console.log(error)
    );    
}
