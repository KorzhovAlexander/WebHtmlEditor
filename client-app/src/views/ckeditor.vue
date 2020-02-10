<template>
    <div>
        <h2 class="content-block">Home</h2>
        <div class="content-block">
            <div class="dx-card responsive-paddings">
                <DxButton text="Open Document" @click="onClick"/>
                <ckeditor :editor="editor" v-model="editorData"/>
                <button v-on:click="emptyEditor()">Empty the editor</button>

                <h2>Editor data</h2>
                <code>{{ editorData }}</code>
            </div>
        </div>
    </div>
</template>
<script>
    import {DxButton} from 'devextreme-vue';
    import ClassicEditor from '@ckeditor/ckeditor5-build-classic';

    export default {
        name: 'ckeditor-temp',
        components: {
            DxButton,
        },
        data() {
            return {
                editor: ClassicEditor,
                editorData: '<p>Content of the editor.</p>',
                editorConfig: {
                    // The configuration of the editor.
                }
            };
        },
        methods:{
            onClick: function () {
                window.open(`api/documents?htmlText=${this.editorData}`)
            },
            emptyEditor() {
                this.editorData = '';
            }
        },
    };
</script>
