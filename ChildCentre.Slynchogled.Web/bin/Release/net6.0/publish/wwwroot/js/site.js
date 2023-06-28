(function ($) {
    var slynchogledFunctions = function () {
        var _this = this;

        _this.openModal = function () {
            alert("open modal");
        }

        _this.closeModal = function () {
            alert("close modal");
        }
    }

    slynchogled = new slynchogledFunctions();
})($);