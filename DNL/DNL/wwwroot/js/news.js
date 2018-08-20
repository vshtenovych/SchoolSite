jQuery(document).ready(function () {


    $("#FileInput").change(function () {
        if (this.files && this.files[0]) {
            var reader = new FileReader();

            var filename = $('#FileInput').val();
            $('#NameNewsPhoto').text(filename);

            reader.onload = function (e) {
                $('.name-event-photo').attr('src', e.target.result);
                $('#PictureSource').val(e.target.result.replace(/^data:image\/(png|jpg|jpeg);base64,/, ""));
            }

            reader.readAsDataURL(this.files[0]);
        }
    });

});