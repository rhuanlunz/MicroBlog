import { getPostsPath, renderPosts, addLikePostEvent } from "./functions.js";

window.addEventListener("load", () => {
    $.get(getPostsPath, (data) => {
        renderPosts(data);

        addLikePostEvent();
    })
    .fail((jqXHR, textStatus, error) => console.error(error));
});
