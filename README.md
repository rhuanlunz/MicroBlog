# μBlog

*μBlog* is an **ASPNET Core MVC** application developed for learning about web development, including front-end and back-end technologies, user authentication, and database management.

***The project is still in development.***

## Sumary

* [Description](#description)
* [Features](#features)
* [Technologies](#technologies)
* [Controllers](#controllers)
* [Gallery](#gallery)

---

## Description

A microblogging application is a platform for sharing short content, usually with a character limit. It allows quick communication through posts, images, and links. Examples include Twitter and Tumblr, featuring user interactions like comments, likes, and hashtags for categorization. It's commonly used for real-time updates and discussions.

The idea behind this project is to create a microblog-like application to learn about ASPNET. 

This application will serve as a hands-on platform for exploring key concepts such as user authentication, database integration, and real-time updates.

---

## Features

- [x] Account registration, login, and profile editing
- [x] Post creation
- [x] Ability to like user posts
- [x] View other users profiles
- [ ] Account deletion
- [ ] Post editing and deletion
- [ ] Search for other users profiles
- [ ] Post comments
- [ ] Follow users

---

## Technologies

### Front-End

* HTML
* CSS
* JavaScript

### Back-End

* .NET 9.0
* ASPNET Identity
* Entity Framework
* SQLite3

---

## Controllers

### Home

Handles interactions that do not require authentication. Currently, it only displays the index page.

**Route:** `/`

### Account

Handle account registration, login and log out.

**Route:** `/account`

### Profile

Handle profile visualization, post creation and profile editing.

**Route:** `/profile`

### Posts API 

Handle every post interaction.

**Route:** `/api/posts`

#### Not require authentication
* `/api/posts/get_posts`
    - Return all posts from **Posts** table.

#### Require authentication
* `/api/posts/get_posts/{userId}`
    - Return all posts of especified **userId** from **Posts** table.

* `/api/posts/create_post`
    - Create new post.

* `/api/posts/like_post`
    - Like post.

---

## Gallery

![register page](images/1.png)
![login page](images/2.png)
![edit user profile page](images/3.png)
![user profile page](images/4.png)
![create post page](images/5.png)
![home page](images/6.png)
![another user profile page](images/7.png)