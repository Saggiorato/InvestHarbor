Vue.component("select2", {
    data: function () {
        return {
            Idaux: ""
        }
    },
    props: {
        options: Array,
        value: String,
        id: String,
        selectedText: String,
    },
    template: "\
            <select :id=\"id\" style='width: 100%'>\
                <slot></slot>\
            </select>"
    ,
    mounted: function () {
        var vm = this;
        $(this.$el)
            .val(this.value)
            // init select2
            .select2({ data: this.options })
            // emit event on change.
            .on("change", function () {
                vm.$emit("input", this.value);
                //console.log($(this).select2('data').text);
                if (vm.id) {
                    // var textS = $("#" + vm.id + " option:selected").text();
                    //vm.selectedText = textS;
                    //console.log(textS);
                }

            });
    },
    watch: {
        value: function (value) {
            // update value          
            var select = $(this.$el).select2();
            select.val(value).trigger("change");

            if (value !== "") {
                this.Idaux = value;
            }

        },
        options: function (options) {
            var vm = this;

            // update options
            $(this.$el).select2({ data: options });

            //pra garantir que a lista carregue antes de selecionar o id ao editar
            if (this.value === "") {
                this.$emit("input", this.Idaux);
            }

            //console.log(this.options);
            for (var i in this.options) {

                if (this.options[i].id === this.value) {

                    //var descricao = this.options[i].text;
                    //$(this.$el).select2("val", descricao);
                    // vm.value = this.Idaux;
                    vm.$emit("input", this.Idaux);
                };
            }
        }
    },
    destroyed: function () {
        $(this.$el).off().select2("destroy");
    }
})