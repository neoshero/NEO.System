function ViewModel(options) {
    var vm = {
        el: options.Id == undefined ? "#container" : options.Id,
        data: {
            title: options.title,
            pager: { 
                totalPage: 0,
                pageIndex: 1
            },
            records: [],
            dataQueryUrlAccessor: options.dataQueryUrlAccessor,
            dataCreateUrlAccessor: options.dataCreateUrlAccessor,
            dataModifyAccessor: options.dataModifyAccessor,
            dataDeleteAccessor: options.dataDeleteAccessor,
            jcWindow: {}
        },
        computed: options.computed,
        methods:  {
            dataAdded: function () {
                this.jcWindow = $.dialog({
                    title: "添加" + options.title,
                    container: "#jquery-container",
                    type: "purple",
                    useBootstrap: false,
                    content: "url:" + vm.data.dataCreateUrlAccessor,
                    onContentReady: function () {
                        $("#save").on("click", function () {
                            var formData = $("#formCreate").serialize();
                            vm.methods.dataAdding(formData);
                        });

                        $("#cancel").on("click", function () {
                            vm.data.jcWindow.close();
                        });
                    }
                });
            },
            dataAdding: function (data) {
                $.ajax({
                    url: vm.data.dataCreateUrlAccessor,
                    type: "post",
                    data: data,
                    success: function (response) {
                        if (response === 1) {
                            vm.jcWindow.close();

                        } else {
                            $.alert(response.Message);
                        }
                    }
                });
            },
            dataUpdated: function () {
                $.dialog({
                    title: "更新" + options.title,
                    container: "#jquery-container",
                    type: "purple",
                    useBootstrap: false,
                    content: "url:" + vm.data.dataModifyAccessor,
                    onContentReady: function () {

                    }
                });
            }, 
            dataUpdating: function (data) {
                $.ajax({
                    url: vm.data.dataModifyAccessor,
                    type: "post",
                    data: data,
                    success: function (response) {
                        if (response === 0) {
                            layer.closeAll();

                        } else {
                            layer.alert(response.Message);
                        }
                    }
                });
            },
            dataDeleting: function (data) {
                $.ajax({
                    url: vm.data.dataDeleteAccessor,
                    type: "post",
                    data: data,
                    success: function (response) {
                        if (response === 0) {
                            layer.closeAll();

                        } else {
                            layer.alert(response.Message);
                        }
                    }
                });
            },
            search: function () {
                this.dataQuery(1);
            },
            dataQuery: function (pageIndex) {
                if (pageIndex != undefined) {
                    this.pager.PageIndex = pageIndex;
                }
                $.ajax({
                    url: vm.data.dataQueryUrlAccessor,
                    data: this.pager,
                    type: "get",
                    success: function (response) {                                                                   
                        vm.data.records = response.Data;
                        vm.data.totalPage = response.TotalPage;
                    }
                });
            }
        },
        components:options.components,
        mounted: function () {
            this.dataQuery();
        }
    };
    return vm;
}

$(function() {
    var check = $("#checkAll");
    //table attach checkAll event
    if (check.length === 1) {
        check.on("change", function () {
            var inputs = $(this).parents("table").find("input");
            var checked = $(this).prop("checked");
            if (checked) {
                inputs.prop("checked", "checked");
            } else {
                inputs.prop("checked", "");
            }
        });
    }
})