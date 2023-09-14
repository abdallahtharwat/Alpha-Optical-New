﻿function DuplicateRow($url) {
    return new  swal({
        title: "Your Item will be Duplicate!",
        text: "Are you sure to proceed?",
        type: "success",
        buttons: true,
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Duplicate My Item!",
        cancelButtonText: "I am not sure!",
        closeOnConfirm: false,
        closeOnCancel: false
    }).then((isConfirm) => {
        if (isConfirm) {
            $.ajax({
                type: "POST",
                url: $url,
                success: function (data) {
                    if (data == "Duplicated") {
                        new  swal("Item Duplicated!", "Your Item is Duplicated!", "success");
                        setTimeout(function () {
                            location.reload();
                        }, 500);
                    } else {
                        new  swal("Hurray", "Item is not Duplicated!", "error");
                    }

                }
            });

        }
        else {
            new swal("Hurray", "Item is not Duplicated!", "error");
        }
    });

}
function DeleteRow($url) {
    return new swal({
        title: "Your Item will be deleted!",
        text: "Are you sure to proceed?",
        type: "warning",
        buttons: true,
        showCancelButton: true,
        cancelButtonColor: "#DD6B55",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Remove My Item!",
        cancelButtonText: "I am not sure!",
        closeOnConfirm: false,
        closeOnCancel: false
    }).then((isConfirm) => {
        if (isConfirm) {
            $.ajax({
                type: "POST",
                url: $url,
                success: function (data) {
                    if (data == "Removed") {
                        setTimeout(function () {
                            location.reload();
                        }, 500);
                    } else {
                        new    swal("Item Removed!", "Your Item is removed!", "success");

                    }

                }
            });
            new swal("Item Removed!", "Your Item is removed!", "success");

        }
        else {
            new swal("Hurray", "Item is not removed!", "error");
        }
    });

}

$(function () {
    if ($('input.tag').length > 0) {
        $('input.tag').each(
            function (i, obj) {
                $(obj).selectize({
                    plugins: ['remove_button'],
                    persist: false,
                    createOnBlur: true,
                    create: true
                });
            });
    }
});




