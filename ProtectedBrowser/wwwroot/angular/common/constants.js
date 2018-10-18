(function () {
    var constantsService = angular.module("applicationApp");
    constantsService.constant("CONSTANTS", {  
    	IS_PRODUCTION: false,
        LANG_ENGLISH: "en-US",
        LANG_ITALIAN: "it-IT",
        DEFAULT_LANGUAGE: "en-US",
        VIEW_USER_MAPPING : {
             		"DirectoryAddButton": {
                    SHOW_TO_ROLE: ["ADMIN"],
                    ENABLED_FOR_ROLE: ["ADMIN"],
                },  
                "DirectoryEditButton": {
                    SHOW_TO_ROLE: ["ADMIN"],
                    ENABLED_FOR_ROLE: ["ADMIN"],
                },
                "DirectoryDeleteButton": {
                    SHOW_TO_ROLE: ["ADMIN"],
                    ENABLED_FOR_ROLE: ["ADMIN"],
                },
                "DirectoryCancelButton": {
                    SHOW_TO_ROLE: ["ADMIN"],
                    ENABLED_FOR_ROLE: ["ADMIN"],
                },
                "DirectorySelectButton": {
                    SHOW_TO_ROLE: ["ADMIN"],
                    ENABLED_FOR_ROLE: ["ADMIN"],
                },
                "DirectoryList": {
                    SHOW_TO_ROLE: ["ADMIN"],
                    ENABLED_FOR_ROLE: ["ADMIN"],
                },  
                "DirectoryEditFields": {
                    SHOW_TO_ROLE: ["ADMIN"],
                    ENABLED_FOR_ROLE: ["ADMIN"],
                }, 
           		"accountSettings": {
		            SHOW_TO_ROLE: ["ADMIN"],
		            ENABLED_FOR_ROLE: ["ADMIN"],
		        },
		        "changePassword": {
		            SHOW_TO_ROLE: ["ADMIN"],
		            ENABLED_FOR_ROLE: ["ADMIN"],
		        },
		         "logout": {
		            SHOW_TO_ROLE: ["ADMIN"],
		            ENABLED_FOR_ROLE: ["ADMIN"],
		        },
		         "contactList": {
		            SHOW_TO_ROLE: ["ADMIN"],
		            ENABLED_FOR_ROLE: ["ADMIN"],
		        }
            }
    });
        
}());

