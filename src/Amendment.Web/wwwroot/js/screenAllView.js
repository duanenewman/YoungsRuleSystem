﻿
function initScreenViewModel(htmlId, languageId, amendment, amendmentBody, languageName) {
    var ScreenViewModel = function () {
        var self = this;
        self.hub = ScreenViewHub(languageId);
        self.amendmentIsLive = ko.observable(amendment.isLive);
        self.amendmentBodyIsLive = ko.observable(amendmentBody.isLive);
        self.amendmentBody = ko.observable(amendmentBody.amendBodyHtml);
        self.language = languageName;
        self.languageId = languageId;
        self.isLive = ko.computed(function () {
            return self.amendmentIsLive() && self.amendmentBodyIsLive();
        });

        $(document).on("screen.amendmentBodyChange." + self.languageId, function (evt, results) {
            self.amendmentBody(results.amendBodyHtml);
            self.amendmentBodyIsLive(results.isLive);
        });

        $(document).on("screen.amendmentChange." + self.languageId, function (evt, results) {
            self.amendmentIsLive(results.isLive);
        });

        $(document).on("screen.clearScreens." + self.languageId, function (evt) {
            self.amendmentIsLive(false);
            self.amendmentBodyIsLive(false);
        });
    };
    ko.applyBindings(new ScreenViewModel(), document.getElementById(htmlId));    
}