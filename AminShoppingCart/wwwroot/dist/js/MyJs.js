$("#cbHot").click(function () {
    if ($(this).is(':checked')) {
        $('[name="IsHot2"]').val(true);
    }
});

$("#cbHotDetail").click(function () {
    $('[name="IsHot2"]').val(true);
});

if ($('#cbHotDetail').is(':checked')) {
    $('[name="IsHot2"]').val(true);
}