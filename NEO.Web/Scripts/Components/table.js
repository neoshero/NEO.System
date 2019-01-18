Vue.component("v-table",{
    data: function() {
        return {
            msg: "这是一个错误的组件"
        }
    },
    props:['datas'],
    template: '<table><tr v-for="item in datas"><td>{{item.Name}}</td></tr></table>'
});

Vue.component("v-button", {
    data: function () {
        return {
            count:0
        }
    },
    template: '<button v-on:click="count++;">叠加数量{{count}}</button>'
});                        