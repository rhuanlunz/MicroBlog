import { getPostsPath, renderPosts, addLikePostEvent } from "./functions.js";

window.addEventListener("load", () => {
    fetch(getPostsPath)
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
