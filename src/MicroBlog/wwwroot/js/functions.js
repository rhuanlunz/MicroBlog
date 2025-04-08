const likePostPath = "/api/posts/like_post";

export const getPostsPath = "/api/posts/get_posts";
export const getUserPostsPath = (userId) => `${getPostsPath}/${userId}`;

export function renderPosts(posts) {
    const postsDiv = document.querySelector("#posts");

    if (posts.length != 0) {
        posts.forEach(post => {
            postsDiv.innerHTML += createPostDiv(post.id, post.username, formatDate(post.createdAt), post.content, post.likes);
        });
    } else {
        postsDiv.innerHTML = "<p> ~ No posts...</p>";
    }
}

export function addLikePostEvent() {
    const postLikeBtns = document.querySelectorAll(".post-like-btn");
        
    postLikeBtns.forEach(btn => {
        btn.addEventListener("click", function() {
            const postDiv = this.parentNode.parentNode;
            const postId = postDiv.id;

            fetch(likePostPath, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(postId)
            })
            .then(r => {
                if (r.ok)
                    return r.json();
                throw new Error("Response not ok!");
            })
            .then(data => {
                this.querySelector(".post-likes").innerHTML = data;
            })
            .catch(e => console.error(e));
        });
    })
}

function createPostDiv(id, username, createdAt, content, likes) {
    return `<div id="${id}" class="post">
        <div class="post-header"><strong>${username}</strong> - ${createdAt}</div>
        
        <div class="post-body">${content}</div>
        
        <div class="post-footer">
            <button class="post-like-btn">
                <span class="material-symbols-outlined">favorite</span>
                <div class="post-likes">${likes}<div>
            </button>
        </div>
    </div>
    `;
}

function formatDate(date) {
    const dateObj = new Date(date);

    const year = dateObj.getFullYear();
    const month = (dateObj.getMonth() + 1) < 10 ? `0${dateObj.getMonth() + 1}` : dateObj.getMonth() + 1;
    const day = (dateObj.getDay() + 1) < 10 ? `0${dateObj.getDay() + 1}` : dateObj.getDay() + 1;
    const hour = dateObj.getHours() < 10 ? `0${dateObj.getHours()}` : dateObj.getHours();
    const minute = dateObj.getMinutes() < 10 ? `0${dateObj.getMinutes()}` : dateObj.getMinutes();

    return `${year}/${month}/${day} at ${hour}:${minute}`;
}
