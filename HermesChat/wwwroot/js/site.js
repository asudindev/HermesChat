﻿var createRoomButton = document.getElementById('create-room-btn');
var createRoomModal = document.getElementById('create-room-modal');

createRoomButton.addEventListener('click', function () {
    createRoomModal.classList.add('active')
});

var closeModal = function () {
    createRoomModal.classList.remove('active')
};
