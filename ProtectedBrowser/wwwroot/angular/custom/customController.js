(function () {
    "use strict";

    var applicationApp = angular.module("applicationApp");

    applicationApp.controller("CustomController", customController);
    customController.$inject = ["$compile", "$scope", "$state", "$timeout", "$rootScope", "CustomRepository", "FileUploader", "localStorageService", "$window", "$q"];

    function customController($compile, $scope, $state, $timeout, $rootScope, CustomRepository, FileUploader, localStorageService, $window, $q) {
        var vm = this;
        vm.getChildFolderDetails = getChildFolderDetails;
        vm.appendChildHtml = appendChildHtml;
        vm.viewFile = viewFile;
        vm.encrypt = encrypt;
        vm.decrypt = decrypt;
        vm.showMiniLoader = showMiniLoader;
        vm.hideMiniLoader = hideMiniLoader;
        vm.loadHtmlWithPagination = loadHtmlWithPagination;
        vm.cropImage = cropImage;
        vm.print = print;
        vm.openNav = openNav;
        vm.closeNav = closeNav;
        vm.clearCrop = clearCrop;
        init();

        function init() {
            vm.folderData = [];
            vm.childLevel = 0;
            vm.currentBase = '';
            CustomRepository.getRootPath({}, function (response) {
                if (!response.status)
                    return;

                vm.path = encodeURIComponent(response.data.rootPath);
                getFolderDetails(vm.path, true, null, null, null);
            });
            vm.pdfUrl = '';
            vm.isProcessInrequesting = false;
            vm.pageCount = 0;
            vm.paginateData = [];
            vm.isCropInProcess = false;
            vm.currentViewFileType = '';
            vm.paginationValue = 500;
            vm.cropper;
            closeNav();
        }

        function getFolderDetails(path, isRootCall, stringToAppend, hrefVal, element) {
            vm.isProcessInrequesting = true;
            CustomRepository.getFolderJson({ sDir: decodeURIComponent(path) }, function (response) {
                if (!response.status) {
                    showTost("Error:", response.message, "danger");
                    return;
                }

                if (isRootCall) {
                    vm.folderData = response.data;
                    vm.isProcessInrequesting = false;
                }
                else {
                    vm.childLevel += 1;
                    vm.appendChildHtml(response.data, stringToAppend, hrefVal, element);
                }
            });
        }

        function loadHtmlWithPagination(hrefVal, callFrom) {
            var html = ``,
                startFrom = (vm.pageCount * vm.paginationValue + (vm.pageCount > 0 ? 1 : 0)),
                endTo = ((vm.pageCount + 1) * vm.paginationValue);

            if (vm.paginateData.length < endTo) {
                endTo = vm.paginateData.length;
            }

            for (var i = startFrom; i < endTo; i++) {
                html += `<li class="file-li" ng-click='vm.viewFile("` + encrypt(vm.paginateData[i].Path) + `" , "` + vm.paginateData[i].Ext + `", $event);$event.stopPropagation();$event.preventDefault();'><span><img class ="height-17" src="images/file.png" />` + vm.paginateData[i].Name + `</span></li>`
            }

            $('#load-more').remove();
            if (vm.paginateData.length > endTo) {
                html += `<li id="load-more" ng-click='vm.loadHtmlWithPagination("` + hrefVal + `", "");$event.stopPropagation();$event.preventDefault();'> Load More +</li>`;
            }
            vm.pageCount++;

            if (callFrom == 'innerCall') {
                return html;
            }

            $("[href=#" + hrefVal + "]").parent('li').append($compile(html)($scope));
        }

        function appendChildHtml(data, stringToAppend, hrefVal, element) {
            var html = ``;
            html += `<ul id="${hrefVal}" class ="collapse in">`;

            /*Folder append*/
            if (data.Folders.length > 0) {
                for (var i = 0; i < data.Folders.length; i++) {
                    var path = (stringToAppend ? decodeURIComponent(stringToAppend) + '\\\\' : '') + data.Folders[i].Name + "";
                    html += `<li ng-click='vm.getChildFolderDetails("` + encodeURIComponent(path) + `" , "child-` + vm.childLevel + `-` + i + `", $event);$event.stopPropagation();$event.preventDefault();'><a data-toggle="collapse" href=` + '#child-' + vm.childLevel + '-' + i + `><span><img class ="height-25" src="images/folder.png" />` + data.Folders[i].Name + `</span></a></li>`
                }
            }

            /*Files append*/
            if (data.Files.length > 0) {
                if (data.Files.length > vm.paginationValue) {
                    vm.paginateData = data.Files;
                    html += loadHtmlWithPagination(hrefVal, 'innerCall');
                }
                else {
                    for (var i = 0; i < data.Files.length; i++) {
                        html += `<li class="file-li" ng-click='vm.viewFile("` + encrypt(data.Files[i].Path) + `" , "` + data.Files[i].Ext + `", $event);$event.stopPropagation();$event.preventDefault();'><span><img class ="height-17" src="images/file.png" />` + data.Files[i].Name + `</span></li>`
                    }
                }
            }
            html += `</ul>`;
            $("[href=#" + hrefVal + "]").parent('li').append($compile(html)($scope));
            vm.isProcessInrequesting = false;
            hideMiniLoader(element, 'folder');
        }

        function getChildFolderDetails(stringToAppend, hrefVal, object) {
            var element = angular.element(object.target);
            showMiniLoader(element);
            if ($('#' + hrefVal + '').length > 0) {
                $('#' + hrefVal + '').toggle();
                hideMiniLoader(element, 'folder');
                return;
            }
            var path = vm.path + '\\' + stringToAppend;
            getFolderDetails(path, false, stringToAppend, hrefVal, element);
        }

        function viewFile(path, ext, object) {
            var html = ``,
                memeType = '';

            var element = angular.element(object.target);
            showMiniLoader(element);
            CustomRepository.getFile({ sDir: decrypt(path) }, function (response) {
                if (!response.status)
                    return;

                if (ext == 'jpg') {
                    var id = 'image';
                    vm.currentViewFileType = '#' + id;
                    memeType = "data:image/png;base64,";
                    vm.currentBase = memeType + response.data.stream;
                    html = `<img id="` + id + `" src="` + vm.currentBase + `" />`
                    
                    $("#file-container").html($compile(html)($scope));
                    //var viewer = new Viewer(document.getElementById('image'), {
                    //    inline: true,
                    //    viewed: function () {
                    //        viewer.zoomTo(1);
                    //    }
                    //});
                }

                if (ext == 'pdf') {
                    vm.currentViewFileType = 'canvas';
                    var blob = b64toBlob(response.data.stream, 'application/pdf');
                    var blobUrl = URL.createObjectURL(blob);
                    $scope.pdfUrl = blobUrl;
                    html = `<ng-pdf template-url="wwwroot/viewer.html"></ng-pdf>`;
                    $("#file-container").html($compile(html)($scope));
                }

                if (ext == 'tif') {
                    vm.currentViewFileType = 'canvas';
                    memeType = "data:image/tiff;base64,";
                    vm.currentBase = memeType + response.data.stream;
                    Tiff.initialize({TOTAL_MEMORY: 19777216 * 10});
                    var xhr = new XMLHttpRequest();
                    xhr.responseType = 'arraybuffer';
                    xhr.open('GET', vm.currentBase);
                    xhr.onload = function (e) {
                        var tiff = new Tiff({ buffer: xhr.response });
                        var canvas = tiff.toCanvas();
                        $("#file-container").html(canvas);
                    };
                    xhr.send();
                }
                hideMiniLoader(element, 'file');
            });
        }

        function print() {
            var html = '';
            html += '<html><head><title></title>';
            html += '</head><body>';
            html += '<img src="' + $('#crop-viewer').attr('src') + '"/>';
            html += '</body></html>';
            setTimeout(() => {
                var myWindow = window.open('', 'PRINT', 'height=400,width=600');
                myWindow.document.write(html);
                myWindow.print();
                myWindow.close();
                vm.isCropInProcess = false;
                $('#crop-viewer').css('display', 'none');
                $('canvas').css('display', 'inline-block');
            }, 1000);
        }


        function encrypt(data) {
            return btoa(JSON.stringify(data));
        };

        function decrypt(data) {
            return JSON.parse(atob(data));
        };

        function b64toBlob(b64Data, contentType, sliceSize) {
            contentType = contentType || '';
            sliceSize = sliceSize || 512;

            var byteCharacters = atob(b64Data);
            var byteArrays = [];

            for (var offset = 0; offset < byteCharacters.length; offset += sliceSize) {
                var slice = byteCharacters.slice(offset, offset + sliceSize);

                var byteNumbers = new Array(slice.length);
                for (var i = 0; i < slice.length; i++) {
                    byteNumbers[i] = slice.charCodeAt(i);
                }

                var byteArray = new Uint8Array(byteNumbers);
                byteArrays.push(byteArray);
            }

            var blob = new Blob(byteArrays, { type: contentType });
            return blob;
        }

        function showMiniLoader(object) {
            vm.isCropInProcess = false;
            $('#crop-viewer').css('display', 'none');
            $('canvas').css('display', 'inline-block');
            $(object).children('img').remove();
            $(object).prepend('<i class="margin-right-5 font-size-15 fa fa-spinner fa-spin"></i>');
        }

        function hideMiniLoader(object, callFrom) {
            $(object).children('i').remove();
            $(object).prepend(callFrom == "folder" ? '<img class="margin-right-5 height-25" src="images/folder.png" />' : '<img class="margin-right-5 height-17" src="images/file.png" />');
        }

        function updatePreview(c) {
            if (parseInt(c.w) > 0) {
                var canvas = $(vm.currentViewFileType),
                    tempCanvas = document.createElement("canvas"),
                    tCtx = tempCanvas.getContext("2d");

                tempCanvas.width = 640;
                tempCanvas.height = 480;

                tCtx.drawImage(canvas[0], c.x, c.y, c.w, c.h, 0, 0, c.w, c.h);
                var img = tempCanvas.toDataURL("image/png");
                $('#crop-viewer').attr('src', img).css('display', 'block');
            }
        }

        function cropImage() {
            vm.isCropInProcess = true;            
            $(vm.currentViewFileType).Jcrop({
                onChange: updatePreview,
                onSelect: updatePreview,
                allowSelect: true,
                allowMove: true,
                allowResize: true,
                aspectRatio: 0
            });
        }

        function openNav() {
            $('#mySidenav').css('width', '65px');
        }

        function closeNav() {
            $('#mySidenav').css('width', '0');
        }

        function clearCrop() {
            vm.isCropInProcess = false;
        }

        
        function bytetobase(buffer) {
            var binary = '';
            var bytes = new Uint8Array(buffer);
            var len = bytes.byteLength;
            for (var i = 0; i < len; i++) {
                binary += String.fromCharCode(bytes[i]);
            }
            return window.btoa(binary);
        };
    }
   
}());