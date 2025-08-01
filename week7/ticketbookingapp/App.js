import React, { useState } from 'react';
import './App.css';

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);
  const [bookingStatus, setBookingStatus] = useState('');

  // Sample flight data
  const flights = [
    {
      id: 1,
      from: 'New York',
      to: 'Los Angeles',
      departure: '10:00 AM',
      arrival: '1:00 PM',
      price: '$299',
      airline: 'SkyWings'
    },
    {
      id: 2,
      from: 'Chicago',
      to: 'Miami',
      departure: '2:30 PM',
      arrival: '6:45 PM',
      price: '$189',
      airline: 'AirFlow'
    },
    {
      id: 3,
      from: 'Seattle',
      to: 'Boston',
      departure: '8:15 AM',
      arrival: '4:30 PM',
      price: '$349',
      airline: 'CloudLine'
    }
  ];

  const handleLogin = () => {
    setIsLoggedIn(true);
    setBookingStatus('');
  };

  const handleLogout = () => {
    setIsLoggedIn(false);
    setBookingStatus('');
  };

  const handleBookTicket = (flight) => {
    setBookingStatus(`Ticket booked successfully for ${flight.from} to ${flight.to}!`);
  };

  // Element variable for conditional rendering
  let navigationButton;
  if (isLoggedIn) {
    navigationButton = (
      <button 
        onClick={handleLogout}
        className="logout-btn"
      >
        Logout
      </button>
    );
  } else {
    navigationButton = (
      <button 
        onClick={handleLogin}
        className="login-btn"
      >
        Login
      </button>
    );
  }

  // Guest Component - Only displays flight information
  const GuestPage = () => {
    return (
      <div className="guest-page">
        <div className="container">
          <div className="page-header">
            <h1>Flight Information</h1>
            <p>Browse available flights (Login required to book tickets)</p>
          </div>
          
          <div className="flights-grid">
            {flights.map(flight => (
              <div key={flight.id} className="flight-card">
                <div className="flight-header">
                  <h3>{flight.airline}</h3>
                  <span className="price">{flight.price}</span>
                </div>
                
                <div className="flight-details">
                  <div className="detail-row">
                    <span>From:</span>
                    <span>{flight.from}</span>
                  </div>
                  <div className="detail-row">
                    <span>To:</span>
                    <span>{flight.to}</span>
                  </div>
                  <div className="detail-row">
                    <span>Departure:</span>
                    <span>{flight.departure}</span>
                  </div>
                  <div className="detail-row">
                    <span>Arrival:</span>
                    <span>{flight.arrival}</span>
                  </div>
                </div>
                
                <button 
                  disabled
                  className="book-btn disabled"
                >
                  Login Required to Book
                </button>
              </div>
            ))}
          </div>
        </div>
      </div>
    );
  };

  // User Component - Displays flight information with booking capability
  const UserPage = () => {
    return (
      <div className="user-page">
        <div className="container">
          <div className="page-header">
            <h1>Book Your Flight</h1>
            <p>Welcome! You can now book tickets for available flights</p>
          </div>

          {bookingStatus && (
            <div className="booking-status">
              {bookingStatus}
            </div>
          )}
          
          <div className="flights-grid">
            {flights.map(flight => (
              <div key={flight.id} className="flight-card">
                <div className="flight-header">
                  <h3>{flight.airline}</h3>
                  <span className="price user-price">{flight.price}</span>
                </div>
                
                <div className="flight-details">
                  <div className="detail-row">
                    <span>From:</span>
                    <span>{flight.from}</span>
                  </div>
                  <div className="detail-row">
                    <span>To:</span>
                    <span>{flight.to}</span>
                  </div>
                  <div className="detail-row">
                    <span>Departure:</span>
                    <span>{flight.departure}</span>
                  </div>
                  <div className="detail-row">
                    <span>Arrival:</span>
                    <span>{flight.arrival}</span>
                  </div>
                </div>
                
                <button 
                  onClick={() => handleBookTicket(flight)}
                  className="book-btn active"
                >
                  Book Ticket
                </button>
              </div>
            ))}
          </div>
        </div>
      </div>
    );
  };

  return (
    <div className="App">
      {/* Header with Navigation */}
      <header className="app-header">
        <div className="container">
          <div className="header-content">
            <div className="app-title">
              <h1>✈️ Ticket Booking App</h1>
              <span className="user-status">
                {isLoggedIn ? 'Logged in as User' : 'Guest Mode'}
              </span>
            </div>
            
            {/* Element variable usage for conditional rendering */}
            {navigationButton}
          </div>
        </div>
      </header>

      {/* Main Content - Conditional Rendering */}
      <main>
        {isLoggedIn ? <UserPage /> : <GuestPage />}
      </main>

      {/* Footer */}
      <footer className="app-footer">
        <div className="container">
          <p>
            This app demonstrates conditional rendering in React - 
            {isLoggedIn ? ' User can book tickets' : ' Guest can only view flights'}
          </p>
        </div>
      </footer>
    </div>
  );
}

export default App;