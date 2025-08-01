import React, { useState } from 'react';

// Component for the User's welcome message
function UserGreeting() {
  return <h2>Welcome back</h2>;
}

// Component for the Guest's sign-up message
function GuestGreeting() {
  return <h2>Please sign up.</h2>;
}

// This component decides which greeting to display
function Greeting(props) {
  const isLoggedIn = props.isLoggedIn;
  if (isLoggedIn) {
    return <UserGreeting />;
  }
  return <GuestGreeting />;
}

// Button components
function LoginButton(props) {
  return <button onClick={props.onClick}>Login</button>;
}

function LogoutButton(props) {
  return <button onClick={props.onClick}>Logout</button>;
}

// This is the main stateful component that controls the UI
function LoginControl() {
  // We use the 'useState' hook to keep track of login status
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  // Event handlers to update the state
  const handleLoginClick = () => {
    setIsLoggedIn(true);
  };

  const handleLogoutClick = () => {
    setIsLoggedIn(false);
  };

  return (
    <div>
      {/* The Greeting component shows the correct message */}
      <Greeting isLoggedIn={isLoggedIn} />

      {/* Here we use conditional rendering to show the correct button */}
      {isLoggedIn
        ? <LogoutButton onClick={handleLogoutClick} />
        : <LoginButton onClick={handleLoginClick} />
      }
    </div>
  );
}

export default LoginControl;