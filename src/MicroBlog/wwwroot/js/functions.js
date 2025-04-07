export function createPostDiv(id, username, createdAt, content, likes) {
    return `<div id="${id}" class="post">
        <div class="post-header"><strong>${username}</strong> - ${createdAt}</div>
        
        <div class="post-body">${content}</div>
        
        <div class="post-footer">
            <button>
                <span class="material-symbols-outlined">favorite</span>
                ${likes}
            </button>
        </div>
    </div>
    `;
}

export function formatDate(date) {
    const dateObj = new Date(date);

    const year = dateObj.getFullYear();
    const month = (dateObj.getMonth() + 1) < 10 ? `0${dateObj.getMonth() + 1}` : dateObj.getMonth() + 1;
    const day = (dateObj.getDay() + 1) < 10 ? `0${dateObj.getDay() + 1}` : dateObj.getDay() + 1;
    const hour = dateObj.getHours() < 10 ? `0${dateObj.getHours()}` : dateObj.getHours();
    const minute = dateObj.getMinutes() < 10 ? `0${dateObj.getMinutes()}` : dateObj.getMinutes();

    return `${year}/${month}/${day} at ${hour}:${minute}`;
}
