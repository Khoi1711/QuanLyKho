$(document).ready(function () {
    $('#sort-asc').on('click', function () {
        var url = '@Url.Action("Index", "SANPHAMs", new { sortOrder = "asc" })';
        window.location.href = url;
    });
    $('#sort-desc').on('click', function () {
        var url = '@Url.Action("Index", "SANPHAMs", new { sortOrder = "desc" })';
        window.location.href = url
    });
});

/* Bắt sự kiện click đơn giá sắp xếp giảm/tăng dần theo giá*/
$(document).ready(function () {
    $('#sort-price-asc').on('click', function () {
        var url = '@Url.Action("Index", "SanPham", new { sortOrder = "__sortOrder__", filterStock = ViewBag.FilterStock, filterPrice = ViewBag.FilterPrice })';
        url = url.replace("__sortOrder__", "asc");
        window.location.href = url;
    });
    $('#sort-price-desc').on('click', function () {
        var url = '@Url.Action("Index", "SanPham", new { sortOrder = "__sortOrder__", filterStock = ViewBag.FilterStock, filterPrice = ViewBag.FilterPrice })';
        url = url.replace("__sortOrder__", "desc");
        window.location.href = url;
    });
});
/*bắt sự kiện xóa các mục đã chọn bangr nhân viên*/
$('#deleteSelectedNV').click(function () {
    var selectedIds = $('.checkbox:checked').map(function () {
        return $(this).val();
    }).get();

    if (selectedIds.length === 0) {
        alert('Vui lòng chọn ít nhất một mục để xóa.');
    } else {
        var confirmed = confirm('Bạn có chắc muốn xóa các mục đã chọn?');

        if (confirmed) {
            $.ajax({
                url: '/NHANVIENs/DeleteSelected',
                type: 'POST',
                data: { selectedIds: selectedIds },
                success: function () {
                    location.reload();
                },
                error: function () {
                    alert('Đã xảy ra lỗi khi xóa các mục đã chọn.');
                }
            });
        }
    }
});
/*bắt sự kiện xóa các mục đã chọn bảng sản phẩm*/
$('#deleteSelectedSP').click(function () {
    var selectedIds = $('.checkbox:checked').map(function () {
        return $(this).val();
    }).get();

    if (selectedIds.length === 0) {
        alert('Vui lòng chọn ít nhất một mục để xóa.');
    } else {
        var confirmed = confirm('Bạn có chắc muốn xóa các mục đã chọn?');

        if (confirmed) {
            $.ajax({
                url: '/SANPHAMs/DeleteSelected',
                type: 'POST',
                data: { selectedIds: selectedIds },
                success: function () {
                    location.reload();
                },
                error: function () {
                    alert('Đã xảy ra lỗi khi xóa các mục đã chọn.');
                }
            });
        }
    }
});
/*bắt sự kiện xóa các mục đã chọn bảng nhom sản phẩm*/
$('#deleteSelectedNSP').click(function () {
    var selectedIds = $('.checkbox:checked').map(function () {
        return $(this).val();
    }).get();

    if (selectedIds.length === 0) {
        alert('Vui lòng chọn ít nhất một mục để xóa.');
    } else {
        var confirmed = confirm('Bạn có chắc muốn xóa các mục đã chọn?');

        if (confirmed) {
            $.ajax({
                url: '/NHOMSANPHAMs/DeleteSelected',
                type: 'POST',
                data: { selectedIds: selectedIds },
                success: function () {
                    location.reload();
                },
                error: function () {
                    alert('Đã xảy ra lỗi khi xóa các mục đã chọn.');
                }
            });
        }
    }
});
/*bắt sự kiện xóa các mục đã chọn bảng chức vụ*/
$('#deleteSelectedCV').click(function () {
    var selectedIds = $('.checkbox:checked').map(function () {
        return $(this).val();
    }).get();

    if (selectedIds.length === 0) {
        alert('Vui lòng chọn ít nhất một mục để xóa.');
    } else {
        var confirmed = confirm('Bạn có chắc muốn xóa các mục đã chọn?');

        if (confirmed) {
            $.ajax({
                url: '/CHUCVUs/DeleteSelected',
                type: 'POST',
                data: { selectedIds: selectedIds },
                success: function () {
                    location.reload();
                },
                error: function () {
                    alert('Đã xảy ra lỗi khi xóa các mục đã chọn.');
                }
            });
        }
    }
});

/*bắt sự kiện xóa các mục đã chọn bảng kho hàng*/
$('#deleteSelectedKH').click(function () {
    var selectedIds = $('.checkbox:checked').map(function () {
        return $(this).val();
    }).get();

    if (selectedIds.length === 0) {
        alert('Vui lòng chọn ít nhất một mục để xóa.');
    } else {
        var confirmed = confirm('Bạn có chắc muốn xóa các mục đã chọn?');

        if (confirmed) {
            $.ajax({
                url: '/KHOHANGs/DeleteSelected',
                type: 'POST',
                data: { selectedIds: selectedIds },
                success: function () {
                    location.reload();
                },
                error: function () {
                    alert('Đã xảy ra lỗi khi xóa các mục đã chọn.');
                }
            });
        }
    }
});

/*bắt sự kiện xóa các mục đã chọn bảng vị trí kho hàng*/
$('#deleteSelectedVTK').click(function () {
    var selectedIds = $('.checkbox:checked').map(function () {
        return $(this).val();
    }).get();

    if (selectedIds.length === 0) {
        alert('Vui lòng chọn ít nhất một mục để xóa.');
    } else {
        var confirmed = confirm('Bạn có chắc muốn xóa các mục đã chọn?');

        if (confirmed) {
            $.ajax({
                url: '/VITRIKHOes/DeleteSelected',
                type: 'POST',
                data: { selectedIds: selectedIds },
                success: function () {
                    location.reload();
                },
                error: function () {
                    alert('Đã xảy ra lỗi khi xóa các mục đã chọn.');
                }
            });
        }
    }
});

/*bắt sự kiện xóa các mục đã chọn bảng vị trí Sản Phẩm*/
$('#deleteSelectedVTSP').click(function () {
    var selectedIds = $('.checkbox:checked').map(function () {
        return $(this).val();
    }).get();

    if (selectedIds.length === 0) {
        alert('Vui lòng chọn ít nhất một mục để xóa.');
    } else {
        var confirmed = confirm('Bạn có chắc muốn xóa các mục đã chọn?');

        if (confirmed) {
            $.ajax({
                url: '/VITRISPs/DeleteSelected',
                type: 'POST',
                data: { selectedIds: selectedIds },
                success: function () {
                    location.reload();
                },
                error: function () {
                    alert('Đã xảy ra lỗi khi xóa các mục đã chọn.');
                }
            });
        }
    }
});

/*bắt sự kiện xóa các mục đã chọn bảng nha cung cap*/
$('#deleteSelectedNCC').click(function () {
    var selectedIds = $('.checkbox:checked').map(function () {
        return $(this).val();
    }).get();

    if (selectedIds.length === 0) {
        alert('Vui lòng chọn ít nhất một mục để xóa.');
    } else {
        var confirmed = confirm('Bạn có chắc muốn xóa các mục đã chọn?');

        if (confirmed) {
            $.ajax({
                url: '/NHACUNGCAPs/DeleteSelected',
                type: 'POST',
                data: { selectedIds: selectedIds },
                success: function () {
                    location.reload();
                },
                error: function () {
                    alert('Đã xảy ra lỗi khi xóa các mục đã chọn.');
                }
            });
        }
    }
});
/*bắt sự kiện xóa các mục đã chọn bảng nha cung cap*/
$('#deleteSelectedCTNhap').click(function () {
    var selectedIds = $('.checkbox:checked').map(function () {
        return $(this).val();
    }).get();

    if (selectedIds.length === 0) {
        alert('Vui lòng chọn ít nhất một mục để xóa.');
    } else {
        var confirmed = confirm('Bạn có chắc muốn xóa các mục đã chọn?');

        if (confirmed) {
            $.ajax({
                url: '/CTPHIEUNHAPKHOes/DeleteSelected',
                type: 'POST',
                data: { selectedIds: selectedIds },
                success: function () {
                    location.reload();
                },
                error: function () {
                    alert('Đã xảy ra lỗi khi xóa các mục đã chọn.');
                }
            });
        }
    }
});

/*chọn tất cả */
$(document).ready(function () {
    // Xử lý sự kiện khi checkbox "check all" được chọn/deselect
    $('#checkAll').change(function () {
        var isChecked = $(this).is(':checked');
        $('.checkbox').prop('checked', isChecked);
    });
});