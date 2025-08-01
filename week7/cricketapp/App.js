import React from 'react';
import './App.css';
import ListofPlayers from './ListofPlayers';
import IndianPlayers from './IndianPlayers';

function App() {
  // Set this flag to false to switch to the IndianPlayers view
  const flag = false;

  // Conditional rendering based on the flag
  if (flag) {
    return (
      <div className="App">
        <ListofPlayers />
      </div>
    );
  } else {
    return (
      <div className="App">
        <IndianPlayers />
      </div>
    );
  }
}

export default App;