<template>
    <div>
        <h2 class="content-block">Home</h2>
        <div class="content-block">
            <div class="dx-card responsive-paddings">
                <DxHtmlEditor
                        v-model="valueContent"
                        :value-type="editorValueType"
                        :height="300"
                        :media-resizing="enabled"
                        :mentions="mentions"
                >
                    <DxToolbar>
                        <DxItem format-name="undo"/>
                        <DxItem format-name="redo"/>
                        <DxItem format-name="separator"/>
                        <DxItem
                                :format-values="sizeValues"
                                format-name="size"
                        />
                        <DxItem
                                :format-values="fontValues"
                                format-name="font"
                        />
                        <DxItem format-name="separator"/>
                        <DxItem format-name="bold"/>
                        <DxItem format-name="italic"/>
                        <DxItem format-name="strike"/>
                        <DxItem format-name="underline"/>
                        <DxItem format-name="separator"/>
                        <DxItem format-name="alignLeft"/>
                        <DxItem format-name="alignCenter"/>
                        <DxItem format-name="alignRight"/>
                        <DxItem format-name="alignJustify"/>
                        <DxItem format-name="separator"/>
                        <DxItem
                                :format-values="headerValues"
                                format-name="header"
                        />
                        <DxItem format-name="separator"/>
                        <DxItem format-name="orderedList"/>
                        <DxItem format-name="bulletList"/>
                        <DxItem format-name="separator"/>
                        <DxItem format-name="color"/>
                        <DxItem format-name="background"/>
                        <DxItem format-name="separator"/>
                        <DxItem format-name="link"/>
                        <DxItem format-name="image"/>
                        <DxItem format-name="separator"/>
                        <DxItem format-name="clear"/>
                        <DxItem format-name="codeBlock"/>
                        <DxItem format-name="blockquote"/>
                    </DxToolbar>
                </DxHtmlEditor>

                <div class="options">
                    <DxButtonGroup :selected-items.sync="selectedItems">
                        <DxButtonGroupItem text="Html"/>
                        <DxButtonGroupItem text="Markdown"/>
                    </DxButtonGroup>
                    <div class="value-content">{{ valueContent }}</div>
                </div>
                <DxButton text="Open Document" @click="onClick"/>
            </div>
        </div>
    </div>
</template>
<script>
    import {
        DxHtmlEditor,
        DxToolbar,
        DxItem
    } from 'devextreme-vue/html-editor';
    import {
        DxButtonGroup,
        DxItem as DxButtonGroupItem
    } from 'devextreme-vue/button-group';
    import {DxButton} from 'devextreme-vue';
    import 'devextreme/ui/html_editor/converters/markdown';

    export default {
        components: {
            DxHtmlEditor,
            DxToolbar,
            DxItem,
            DxButtonGroup,
            DxButtonGroupItem,
            DxButton
        },
        data() {
            return {
                valueContent:
                    "            <span\n" +
                    "                    class=\"dx-mention\"\n" +
                    "                    spellcheck=\"false\"\n" +
                    "                    data-marker=\"@\"\n" +
                    "                    data-mention-value=\"Kevin Carter\"\n" +
                    "            ><h5>Hi</h5></span>",
                sizeValues: ['8pt', '10pt', '12pt', '14pt', '18pt', '24pt', '36pt'],
                fontValues: ['Arial', 'Courier New', 'Georgia', 'Impact', 'Lucida Console', 'Tahoma', 'Times New Roman', 'Verdana'],
                headerValues: [false, 1, 2, 3, 4, 5],
                enabled: {
                    enabled: true
                },
                selectedItems: [{text: 'Html'}],
                mentions: [{
                    dataSource: [{"text": "Ляховский"}, {"text": "Карпов"}, {"text": "Проценков"}],
                    searchExpr: 'text',
                    displayExpr: 'text'
                }],
                variables: ["{FirstName}", "{LastName}", "{Company}"],
                url:null,

            };
        },
        methods:{
            onClick: function () {
                window.open(`api/documents?htmlText=${this.valueContent}`)
            }
        },
        computed: {
            editorValueType: function () {
                return this.selectedItems[0].text.toLowerCase();
            }
        }
    };
</script>
<style lang="scss">
    .logos-container {
        margin: 20px 0 40px 0;
        text-align: center;

        svg {
            display: inline-block;
        }
    }

    .devextreme-logo {
        width: 200px;
        height: 34px;
        margin-bottom: 17px;
    }

    .vue-logo {
        width: 180px;
        height: 62px;
    }

    .plus {
        margin: 20px 10px;
        width: 22px;
        height: 22px;
    }

    .screen-x-small .logos-container {
        svg {
            width: 100%;
            display: block;

            &.plus {
                margin: 0;
            }
        }
    }
</style>
