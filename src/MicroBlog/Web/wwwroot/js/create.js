import { getPostsPath } from "./functions.js";

$("#send").on("click", () => {
    const userId = $("#user-id")[0].innerText;
    const content = $("#content")[0].value;

    fetch(getPostsPath, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            'userid': userId,
            'content': content
        })
    })
    .then(r => {
        if (r.ok)
            window.history.back();
        
        throw new Error("Error! Response not ok.");
    })
    .catch(e => console.error(e));
});