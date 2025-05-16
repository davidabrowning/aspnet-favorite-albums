// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(".tag-reset-button").click(function () {
    showAllAlbumRows();
});
$(".tag-button").click(function () {
    showAllAlbumRows();
    let tagId = $(this).val();
    $(".album-row").each(function () {
        let $row = $(this);
        if ($row.find(".tag-" + tagId).length == 0) {
            $row.addClass("d-none");
        }
    });
});

function showAllAlbumRows() {
    $(".album-row").removeClass("d-none");
}