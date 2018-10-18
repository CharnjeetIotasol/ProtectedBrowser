(function () {
    var commonService = angular.module("common.services");
    commonService.factory("CommonUtils", commonUtils);
    commonUtils.$inject = ["$resource", "CONSTANTS", "localStorageService", "$translate"];

    function commonUtils($resource, CONSTANTS, localStorageService, $translate) {
        var chosenLanguage = CONSTANTS.DEFAULT_LANGUAGE;
        return {
            logging: logging,
            setChosenLanguage: setChosenLanguage,
            getChosenLanguage: getChosenLanguage
        };

        function logging(type, message, functionName, fileName) {
            if (!CONSTANTS.IS_PRODUCTION) {
                console.log("Type:" + type + " In Function:" + functionName + " In File: " + fileName);
                console.log(message);
            }
        }

        function setChosenLanguage(language) {
            $translate.use(language);
            localStorageService.set('chosenLanguage', language);
            chosenLanguage = language;
        }

        function getChosenLanguage() {
/*            if (localStorageService.get('chosenLanguage') !== null) {
                chosenLanguage = localStorageService.get('chosenLanguage');
            }*/
            return chosenLanguage;
        }
    }
}());
