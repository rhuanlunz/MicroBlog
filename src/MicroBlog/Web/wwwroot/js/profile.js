import { getUserPostsPath, addLikePostEvent, renderPosts } from "./functions.js";

window.addEventListener("load", () => {
    const userId = document.querySelector("#user-id").value;

    fetch(getUserPostsPath(userId))
    .then(response => {
        if (response.ok)
            return response.json();
        throw new Error("Response not ok!");
    })
    .then(posts => {
        renderPosts(posts);

        addLikePostEvent();
    })
    .catch(e => console.error(e));
});