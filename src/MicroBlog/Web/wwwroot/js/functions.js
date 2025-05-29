const likePostPath = (postId) => `/api/posts/${postId}/like`;

export const getPostsPath = "/api/posts";
export const getUserPostsPath = (userId) => `${getPostsPath}/${userId}`;

export function renderPosts(posts) {
    const postsDiv = document.querySelector("#posts");

    if (posts.length != 0) {
        posts.data.forEach((post) => {
            postsDiv.innerHTML += createPostDiv(post.id, post.username, formatDate(post.createdAt), post.content, post.totalLikes);
        });

        postsDiv.innerHTML += "<p id='end'>~ The End. ~</p>";
    } else {
        postsDiv.innerHTML = "<p> ~ No posts...</p>";
    }
}

export function addLikePostEvent() {
    const postLikeBtns = document.querySelectorAll(".post-like-btn");
        
    postLikeBtns.forEach(btn => {
        btn.addEventListener("click", function() {
            const postDiv = this.parentNode.parentNode.parentNode;
            const postId = postDiv.id;

            fetch(likePostPath(postId), {
                method: "PUT",
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
                this.innerHTML = `${data.data} Likes`;
            })
            .catch(e => console.error(e));
        });
    })
}

function createPostDiv(id, username, createdAt, content, likes) {
    return `
    <div id="${id}" class="post">
        <div class="post-image">
            <img src="/images/profile-placeholder.jpg" class="post-profile-pic" alt="profile-picture">
        </div>

        <div class="post-content">
            <div class="post-header">
                <a href="/profile/${username}" class="post-username">${username}</a>
                <div class="post-date">- ${createdAt}</div>
            </div>
        
            <div class="post-body">${content}</div>
        
            <div class="post-footer">
                <button class="post-like-btn">
                    ${likes} Likes
                </button>
            </div>
        </div>
    </div>
    `;
}

function formatDate(date) {
    const dateObj = new Date(date);

    const year = dateObj.getFullYear();
    const month = (dateObj.getMonth() + 1) < 10 ? `0${dateObj.getMonth() + 1}` : dateObj.getMonth() + 1;
    const day = dateObj.getDate() < 10 ? `0${dateObj.getDate()}` : dateObj.getDate();
    const hour = dateObj.getHours() < 10 ? `0${dateObj.getHours()}` : dateObj.getHours();
    const minute = dateObj.getMinutes() < 10 ? `0${dateObj.getMinutes()}` : dateObj.getMinutes();

    return `${year}/${month}/${day} at ${hour}:${minute}`;
}
