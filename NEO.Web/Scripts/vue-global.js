function ViewModel(options) {
    var vm = new Vue({
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
        methods: {
            dataAdded: function () {
                this.jcWindow = $.dialog({
                    title: "添加" + options.title,
                    container: "#jquery-container",
                    type: "purple",
                    useBootstrap: false,
                    content: "url:" + options.dataCreateUrlAccessor,
                    onContentReady: function () {

                    }
                });
            },
            dataAdding: function (data) {
                $.ajax({
                    url: this.dataCreateUrlAccessor,
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
                    content: "url:" + options.dataModifyAccessor,
                    onContentReady: function () {

                    }
                });
            },
            dataUpdating: function (data) {
                $.ajax({
                    url: this.dataModifyAccessor,
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
                    url: this.dataDeleteAccessor,
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
                    url: this.dataQueryUrlAccessor,
                    data: this.pager,
                    type: "get",
                    success: function (response) {
                        vm.pager.records = [];
                        vm.pager.records.push(response.Data);
                        vm.pager.totalPage = response.TotalPage;
                    }
                });
            }
        },
        mounted: function () {
            this.dataQuery();
        }
    });
    return vm;
}