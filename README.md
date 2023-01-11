# Bookstore
This repository implements the Repository Design Pattern to provide a clean and organized way of interacting with the database. The following APIs are available for use:

Author APIs
1 - GetAll: This API retrieves all authors from the database.
2 - GetAuthorsWithBooks: This API retrieves all authors with their linked books from the database and its Cumulative Total Prices .
3 - GetByID: This API retrieves an author from the database by their ID.
4 - SearchByName: This API searches for authors by matching letters in their name.
Book APIs
[GET Methods]
1 - GetAll: This API retrieves all books from the database.
2 - GetByID: This API retrieves a book from the database by its ID.
3 - GetBooksWithAuthors: This API retrieves all books from the database with their linked authors.
4 - GetByCategory: This API retrieves all books from the database with their associated category.
5 - GetByRating: This API retrieves all books from the database by rating.
[Post Methods]
1 - AddBook: This API adds a book data into  the database.
To use the APIs, send a GET request to the corresponding endpoint. The APIs return data in JSON format.
