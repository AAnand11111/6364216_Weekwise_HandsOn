import React from 'react';

// Helper component for Odd players using array destructuring
function OddPlayers({ players }) {
  const [first, , third, , fifth] = players;
  return (
    <div>
      <h2>Odd Players</h2>
      <ul>
        <li>First : {first}</li>
        <li>Third : {third}</li>
        <li>Fifth : {fifth}</li>
      </ul>
    </div>
  );
}

// Helper component for Even players using array destructuring
function EvenPlayers({ players }) {
  const [, second, , fourth, , sixth] = players;
  return (
    <div>
      <h2>Even Players</h2>
      <ul>
        <li>Second : {second}</li>
        <li>Fourth : {fourth}</li>
        <li>Sixth : {sixth}</li>
      </ul>
    </div>
  );
}

// Main component to display Indian players
function IndianPlayers() {
  const IndianTeam = ['Sachin1', 'Dhoni2', 'Virat3', 'Rohit4', 'Yuvraj5', 'Raina6'];

  // Declare two arrays to be merged
  const T20Players = ['First Player', 'Second Player', 'Third Player'];
  const RanjiTrophyPlayers = ['Fourth Player', 'Fifth Player', 'Sixth Player'];

  // Merge arrays using the ES6 spread operator
  const ListofIndianPlayers = [...T20Players, ...RanjiTrophyPlayers];

  return (
    <div>
      <h1>Indian Team</h1>
      <OddPlayers players={IndianTeam} />
      <EvenPlayers players={IndianTeam} />
      <hr />
      <h1>List of Indian Players Merged:</h1>
      <ul>
        {ListofIndianPlayers.map((player, index) => (
          <li key={index}>Mr. {player}</li>
        ))}
      </ul>
    </div>
  );
}

export default IndianPlayers;