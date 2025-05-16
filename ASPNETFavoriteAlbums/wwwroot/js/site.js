// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

addListeners();

function addListeners() {
    addResetTagListener();
    addFilterByTagListener();
}

function addResetTagListener() {
    $(".tag-reset-button").click(function () {
        showAllAlbumRows();
    });
}

function addFilterByTagListener() {
    $(".tag-button").click(function () {
        showAllAlbumRows();
        let tagId = $(this).val();
        hideAlbumRowsWithoutTagId(tagId);
    });
}

function showAllAlbumRows() {
    $(".album-row").removeClass("d-none");
}

function hideAlbumRowsWithoutTagId(tagId) {
    $(".album-row").each(function () {
        let row = $(this);
        if (rowDoesNotContainTagId(row, tagId)) {
            row.addClass("d-none");
        }
    });
}

function rowDoesNotContainTagId(row, tagId) {
    return row.find(".tag-" + tagId).length == 0;
}