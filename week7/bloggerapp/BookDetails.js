import React from 'react';

// Data for books [cite: 47]
const books = [
  { id: 101, bname: 'Master React', price: 670 },
  { id: 102, bname: 'Deep Dive into Angular 11', price: 800 },
  { id: 103, bname: 'Mongo Essentials', price: 450 },
];

function BookDetails() {
  return (
    <div className="component-container">
      <h2>Book Details</h2>
      {/* Map through books array and use a key for each item */}
      {books.map(book => (
        <div key={book.id} className="item-container">
          <h3>{book.bname}</h3>
          <p>{book.price}</p>
          {/* Example of Conditional Rendering: Ternary Operator */}
          {book.price > 700 ? <span className="highlight">Bestseller!</span> : null}
        </div>
      ))}
    </div>
  );
}

export default BookDetails;