///<reference path="jquery-1.10.2.js" />
///<reference path="jquery.signalR-2.2.2.js" />
///<reference path="angular.js" />
(function () {
    var app = angular.module('chat_app', []);
    app.controller('ChatController', function ($scope, $filter) {
        //alert('Controller');
        $scope.name = prompt('Enter your name', 'Guest_');
        $scope.message = '';
        $scope.allMessages = [];
        $scope.chatHub = $.connection.myChatHub;
        $.connection.hub.start();
        $('#message').keypress(function (e) {

            if (e.keyCode === 13) {
                $('#btnSend').click();
            }
        });

        //$scope.chatHub.client.broadcastMessage = function (name, message) {
        $scope.chatHub.client.broadcastMessage = function (name, message, sentTime) {//next
            //alert('message broadcusting');
            var st = '';
            st = '(' + $filter('date')(sentTime, 'yyyy-MM-dd hh:mm:ss a') + ')';
            var myMessage = name + ' says ' + st + ' :--> ' + message;

            $scope.allMessages.push(myMessage);
            $scope.$apply();
        };
        $scope.newMessage = function () {
            if ($('#userName').val() !== '' && $('#message').val() !== '') {
                $scope.chatHub.server.sendMessage($scope.name, $scope.message);
                $scope.message = '';
                $scope.message.focus();
            }

            else {
                alert('Enter your name and message');
            }
        };

    });
}());