// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


document.addEventListener('DOMContentLoaded', function () {

    handleProfilImageUpload()

})


function handleProfilImageUpload() {

    try {


        let fileUploader = document.querySelector('#fileUploader')

        if (fileUploader != undefined) {

            fileUploader.addEventListener('change', function () {

                if (this.files.length > 0)
                    this.form.submit()

            })

        }

    }
    catch { }

}