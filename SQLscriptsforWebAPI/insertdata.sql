INSERT INTO Users (Username, PasswordHash, Email, LastLoginTime, CreatedAt, UpdatedAt)
VALUES
('vijay', 'passwordhash1', 'vijay@gmail.com', '2024-06-01 12:00:00', '2024-06-01 12:00:00', '2024-06-01 12:00:00'),
('rahul', 'passwordhash2', 'rahul@yahoo.com', '2024-06-02 12:00:00', '2024-06-02 12:00:00', '2024-06-02 12:00:00'),
('anita', 'passwordhash3', 'anita@hotmail.com', '2024-06-03 12:00:00', '2024-06-03 12:00:00', '2024-06-03 12:00:00'),
('arjun', 'passwordhash4', 'arjun@gmail.com', '2024-06-04 12:00:00', '2024-06-04 12:00:00', '2024-06-04 12:00:00'),
('deepika', 'passwordhash5', 'deepika@yahoo.com', '2024-06-05 12:00:00', '2024-06-05 12:00:00', '2024-06-05 12:00:00'),
('manoj', 'passwordhash6', 'manoj@hotmail.com', '2024-06-06 12:00:00', '2024-06-06 12:00:00', '2024-06-06 12:00:00');

INSERT INTO Roles (Name, IsActive)
VALUES
('Admin', 1),
('User', 1),
('Editor', 1),
('Contributor', 1);

INSERT INTO Permissions (Name, MenuUrl)
VALUES
('Create', NULL),
('Edit', NULL),
('Delete', NULL),
('View', NULL),
('Publish', NULL),
('Unpublish', NULL);

INSERT INTO Categories (Name)
VALUES
('Technology'),
('Health'),
('Lifestyle'),
('Education'),
('Entertainment');

INSERT INTO Tags (Name)
VALUES
('Tech'),
('Health'),
('Life'),
('Edu'),
('Fun');

INSERT INTO Articles (Title, Content, AuthorId, CreatedAt, UpdatedAt)
VALUES
('First Article', 'Content of the first article', 1, '2024-06-01 12:00:00', '2024-06-01 12:00:00'),
('Second Article', 'Content of the second article', 2, '2024-06-02 12:00:00', '2024-06-02 12:00:00'),
('Third Article', 'Content of the third article', 3, '2024-06-03 12:00:00', '2024-06-03 12:00:00'),
('Fourth Article', 'Content of the fourth article', 4, '2024-06-04 12:00:00', '2024-06-04 12:00:00'),
('Fifth Article', 'Content of the fifth article', 5, '2024-06-05 12:00:00', '2024-06-05 12:00:00'),
('Sixth Article', 'Content of the sixth article', 6, '2024-06-06 12:00:00', '2024-06-06 12:00:00');

INSERT INTO Comments (ArticleId, Content, AuthorId, CreatedAt, UpdatedAt)
VALUES
(1, 'Great article!', 2, '2024-06-02 13:00:00', '2024-06-02 13:00:00'),
(2, 'Very informative.', 1, '2024-06-03 14:00:00', '2024-06-03 14:00:00'),
(3, 'Well written.', 3, '2024-06-04 15:00:00', '2024-06-04 15:00:00'),
(4, 'Loved it!', 4, '2024-06-05 16:00:00', '2024-06-05 16:00:00'),
(5, 'Interesting read.', 5, '2024-06-06 17:00:00', '2024-06-06 17:00:00'),
(6, 'Good insights.', 6, '2024-06-07 18:00:00', '2024-06-07 18:00:00');

INSERT INTO ArticleCategories (ArticleId, CategoryId)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 1);

INSERT INTO ArticleTags (ArticleId, TagId)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 5),
(6, 1);

INSERT INTO UserRoles (UserId, RoleId)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4),
(5, 2),
(6, 2);

INSERT INTO RolePermissions (RoleId, PermissionId)
VALUES
(1, 1),
(1, 2),
(1, 3),
(1, 4),
(1, 5),
(1, 6),
(2, 1),
(2, 2),
(2, 4),
(3, 1),
(3, 2),
(3, 4),
(3, 5),
(4, 1),
(4, 2),
(4, 4);
