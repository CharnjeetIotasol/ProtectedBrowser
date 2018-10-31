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
            vm.pageCount = [];
            vm.paginateData = [];
            vm.isCropInProcess = false;
            vm.currentViewFileType = '';
            vm.paginationValue = 200;
            vm.cropper;
            vm.jcropApi;
            vm.cropApi;
            prepareCanvasForAreaSelect();
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
            if (!vm.pageCount[hrefVal])
                vm.pageCount[hrefVal] = 0;

            var html = ``,
                startFrom = (vm.pageCount[hrefVal] * vm.paginationValue + (vm.pageCount[hrefVal] > 0 ? 1 : 0)),
                endTo = ((vm.pageCount[hrefVal] + 1) * vm.paginationValue);

            if (vm.paginateData[hrefVal].length < endTo)
                endTo = vm.paginateData[hrefVal].length;

            for (var i = startFrom; i < endTo; i++) {
                html += `<li class="file-li"><span class="full-display" ng-click='vm.viewFile("` + encrypt(vm.paginateData[hrefVal][i].Path) + `" , "` + vm.paginateData[hrefVal][i].Ext + `", "` + vm.paginateData[hrefVal][i].Name + `", $event);$event.stopPropagation();$event.preventDefault();'><img class ="height-17 margin-right-5"  src="images/file.png" /><span>` + vm.paginateData[hrefVal][i].Name + `</span></span></li>`
            }

            $('#' + hrefVal + ' #load-more').remove();

            if (vm.paginateData[hrefVal].length > endTo)
                html += `<li id="load-more" ng-click='vm.loadHtmlWithPagination("` + hrefVal + `", "");$event.stopPropagation();$event.preventDefault();'> Load More +</li>`;

            vm.pageCount[hrefVal]++;

            if (callFrom == 'innerCall')
                return html;

            $("#" + hrefVal).append($compile(html)($scope));
        }

        function appendChildHtml(data, stringToAppend, hrefVal, element) {
            var html = ``;
            html += `<ul id="${hrefVal}" class ="collapse in">`;

            /*Folder append*/
            if (data.Folders.length > 0) {
                for (var i = 0; i < data.Folders.length; i++) {
                    var path = (stringToAppend ? decodeURIComponent(stringToAppend) + '\\\\' : '') + data.Folders[i].Name + "";
                    html += `<li><a data-toggle="collapse" href=` + '#child-' + vm.childLevel + '-' + i + `><span class="full-display" ng-click='vm.getChildFolderDetails("` + encodeURIComponent(path) + `" , "child-` + vm.childLevel + `-` + i + `", $event);$event.stopPropagation();$event.preventDefault();'><img class ="height-25 margin-right-5" src="images/folder.png" /><span>` + data.Folders[i].Name + `</span></span></a></li>`
                }
            }

            /*Files append*/
            if (data.Files.length > 0) {
                if (data.Files.length > vm.paginationValue) {
                    vm.paginateData[hrefVal] = data.Files;
                    html += loadHtmlWithPagination(hrefVal, 'innerCall');
                }
                else {
                    for (var i = 0; i < data.Files.length; i++) {
                        html += `<li class="file-li"><span class="full-display" ng-click='vm.viewFile("` + encrypt(data.Files[i].Path) + `", "` + data.Files[i].Ext + `", "` + data.Files[i].Name + `", $event);$event.stopPropagation();$event.preventDefault();'><img class ="height-17 margin-right-5" src="images/file.png" /><span>` + data.Files[i].Name + `</span></span></li>`
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

        function viewFile(path, ext, name, object) {
            var html = ``,
                memeType = '';

            var element = angular.element(object.target);
            showMiniLoader(element);
            CustomRepository.getFile({ sDir: decrypt(path), ext: ext, name: name }, function (response) {
                if (!response.status)
                    return;

                $("#file-container").html('');
                $("#c").remove();
                $("#file-container").after('<canvas id="c"></canvas>');
                prepareCanvasForAreaSelect();

                if (ext == 'jpg' || ext == 'tif' || ext == 'png') {
                    var id = 'image';
                    vm.currentViewFileType = '#' + id;
                    b64toBlob(response.data.stream, 'image/png').then(function (resp) {
                        vm.currentBase = URL.createObjectURL(resp);

                        // Grab the Canvas and Drawing Context
                        var canvas = document.getElementById('c');
                        var ctx = canvas.getContext('2d');

                        // Create an image element
                        var img = document.createElement('IMG');

                        // When the image is loaded, draw it
                        img.onload = function () {
                            $('#c').attr('width', img.width);
                            $('#c').attr('height', img.height);

                            ctx.drawImage(img, 0, 0);

                            var panzoom = $('#c').panzoom({
                                $reset: $("#revertZoom"),
                                maxZoom: 1,
                                minZoom: 0.1
                            });

                            panzoom.parent().on('mousewheel.focal', function (e) {
                                e.preventDefault();
                                var delta = e.delta || e.originalEvent.wheelDelta;
                                var zoomOut = delta ? delta < 0 : e.originalEvent.deltaY > 0;
                                panzoom.panzoom('zoom', zoomOut, {
                                    increment: 0.1,
                                    focal: e
                                });
                            });
                        }
                        img.src = vm.currentBase;
                    });
                }

                if (ext == 'pdf') {
                    vm.currentViewFileType = 'canvas';
                    b64toBlob(response.data.stream, 'application/pdf').then(function (resp) {
                        var blobUrl = URL.createObjectURL(resp);
                        $scope.pdfUrl = blobUrl;
                        html = `<ng-pdf template-url="wwwroot/viewer.html"></ng-pdf>`;
                        $("#file-container").html($compile(html)($scope));
                    });
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

        function _base64ToArrayBuffer(base64) {
            var deferred = $q.defer();
            var binary_string = window.atob(base64);
            var len = binary_string.length;
            var bytes = new Uint8Array(len);
            for (var i = 0; i < len; i++) {
                bytes[i] = binary_string.charCodeAt(i);
            }
            deferred.resolve(bytes.buffer);
            return deferred.promise;
        }

        function b64toBlob(b64Data, contentType, sliceSize) {
            var deferred = $q.defer();
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
            deferred.resolve(blob);
            return deferred.promise;
        }

        function showMiniLoader(object) {
            vm.isCropInProcess = false;
            clearCrop();

            $('#crop-viewer').css('display', 'none');
            $('canvas').css('display', 'inline-block');
            $(object).parent('.full-display').children('img').remove();
            $(object).prepend('<i class="margin-right-5 font-size-15 fa fa-spinner fa-spin"></i>');
        }

        function hideMiniLoader(object, callFrom) {
            $(object).children('i').remove();
            $(object).parent('.full-display').prepend(callFrom == "folder" ? '<img class="margin-right-5 height-25" src="images/folder.png" />' : '<img class="margin-right-5 height-17" src="images/file.png" />');
            closeNav();
        }

        function updatePreviewForPdf(c) {
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

        function updatePreviewForTif(selection) {
            if (!selection.width || !selection.height) {
                return;
            }
            var canvas = $('#c'),
				tempCanvas = document.createElement("canvas"),
				tCtx = tempCanvas.getContext("2d");

            tempCanvas.width = 640;
            tempCanvas.height = 480;

            tCtx.drawImage(canvas[0], selection.x1, selection.y1, selection.width, selection.height, 0, 0, selection.width, selection.height);
            var img = tempCanvas.toDataURL("image/png");
            $('#crop-viewer').attr('src', img).css('display', 'block');
        }


        function prepareCanvasForAreaSelect() {
            vm.cropApi = $('#c').imgAreaSelect({
                instance: true,
                handles: true,
                disable: true,
                onSelectEnd: function (img, selection) {
                    updatePreviewForTif(selection);
                },
                onSelectStart: function (img, selection) {
                    updatePreviewForTif(selection);
                },
                onSelectChange: function (img, selection) {
                    updatePreviewForTif(selection);
                }
            });
        }
        

        function cropImage() {
            vm.isCropInProcess = true;
            if (vm.currentViewFileType == '#image') {
                $('#c').panzoom("reset");
                $('#c').panzoom("disable");
                // $('#c')[0].style.cssText = "";
                vm.cropApi.setOptions({ enable: true });
                return;
            }

            vm.jcropApi = $.Jcrop(vm.currentViewFileType, {
                onChange: updatePreviewForPdf,
                onSelect: updatePreviewForPdf,
                allowSelect: true,
                allowMove: true,
                allowResize: true,
                aspectRatio: 0
            });
        }

        function clearCrop() {
            // Disable crop Pdf's
            if (vm.jcropApi)
                vm.jcropApi.destroy();

            // Disable crop Images
            vm.cropApi.setOptions({ hide: true, disable: true });
            $('#c').panzoom("enable");
        }

        function openNav() {
            $('#mySidenav').css('width', '65px');
        }

        function closeNav() {
            $('#mySidenav').css('width', '0');
        }
    }

}());