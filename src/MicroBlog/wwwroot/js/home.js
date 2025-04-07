import { formatDate, createPostDiv } from "./functions.js";

window.addEventListener("load", () => {
    fetch("/api/posts/get_posts")
    .then(response => {
        if (response.ok)
            return response.json();
        throw new Error("Response not ok!");
    })
    .then(posts => {    
        const postsDiv = document.querySelector("#posts");

        if (posts.length != 0) {
            for (let post of posts) {
                postsDiv.innerHTML += createPostDiv(post.id, post.username, formatDate(post.createdAt), post.content, post.likes);
            }
        } else {
            postsDiv.innerHTML = "<p> ~ No posts...</p>";
        }
    })
    .catch(e => console.error(e));
});
