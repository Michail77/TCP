import React from 'react'
import AsideDeck from './AsideDeck'
import Desk from './Desk'
import Stats from "./Stats"
import './App.css'

const App = () => {
  return (
      <div className="App">
        <h1>SuMaxer Game</h1>
        <Stats />
        <div className="table">
          <AsideDeck />
          <Desk />
        </div>
      </div>
  );
};

export default App;