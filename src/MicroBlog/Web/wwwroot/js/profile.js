import { getUserPostsPath, addLikePostEvent, renderPosts } from "./functions.js";

window.addEventListener("load", () => {
    const username = $('#user-name')[0].innerText;

    $.get(getUserPostsPath(username), (data) => {
        renderPosts(data);
        
        addLikePostEvent();
    })
    .fail((jqXHR, textStatus, error) => console.error(error));
});