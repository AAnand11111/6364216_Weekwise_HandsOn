const CalculateScore = ({ name, school, total, goal }) => {
    let percentage = (total / 500) * 100;
    return (
        <div className="student-info">
            <div className="header">
                <h1>Student Details</h1>
            </div>
            <p><strong>Name:</strong> {name}</p>
            <p><strong>School:</strong> {school}</p>
            <p><strong>Total:</strong> {total}</p>
            <p><strong>Percentage:</strong> {percentage}%</p>
            <p><strong>Goal:</strong> {goal}</p>
        </div>
    );
};
export default CalculateScore;