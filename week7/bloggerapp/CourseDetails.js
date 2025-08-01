import React from 'react';

// Data for courses
const courses = [
  { id: 1, name: 'Angular', date: '4/5/2021' },
  { id: 2, name: 'React', date: '6/3/2020' },
];

function CourseDetails() {
  return (
    <div className="component-container">
      <h2>Course Details</h2>
      {/* Map through the courses array to display each one */}
      {courses.map(course => (
        <div key={course.id} className="item-container">
          <h3>{course.name}</h3>
          <p>{course.date}</p>
        </div>
      ))}
    </div>
  );
}

export default CourseDetails;