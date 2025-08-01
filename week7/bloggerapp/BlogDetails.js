import React from 'react';

// Data for blogs
const blogs = [
  { id: 1, title: 'React Learning', author: 'Stephen Biz', content: 'Welcome to learning React!' },
  { id: 2, title: 'Installation', author: 'Schewzdenier', content: 'You can install React from npm.' },
];

function BlogDetails() {
  return (
    <div className="component-container">
      <h2>Blog Details</h2>
      {blogs.map(blog => (
        <div key={blog.id} className="item-container">
          <h3>{blog.title}</h3>
          {/* Example of Conditional Rendering: Logical && Operator */}
          {blog.author && <p className="author">By: {blog.author}</p>}
          <p>{blog.content}</p>
        </div>
      ))}
    </div>
  );
}

export default BlogDetails;