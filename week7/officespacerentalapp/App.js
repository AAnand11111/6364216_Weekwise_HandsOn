import './App.css';
import officeImage from './office-space.jpg'; // We will add this image in the next step

function App() {
  // Create an object to display details for a single office
  const officeDetails = {
    Name: "DBS",
    Rent: 50000,
    Address: "Chennai"
  };

  // Style object for the rent price
  const rentStyle = {
    color: officeDetails.Rent <= 60000 ? 'red' : 'green'
  };

  return (
    <div className="App">
      {/* Create an element to display the heading */}
      <h1>Office Space, at Affordable Range</h1>

      {/* Attribute to display the image */}
      <img src={officeImage} alt="Modern office space" width="300" />

      {/* Display details from the office object */}
      <h2>Name: {officeDetails.Name}</h2>

      {/* Apply inline CSS to change the rent color */}
      <h3 style={rentStyle}>Rent: Rs. {officeDetails.Rent}</h3>
      <h3>Address: {officeDetails.Address}</h3>
    </div>
  );
}

export default App;