import Navigation from './Components/Basic/Navigation';

import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';

import './App.css';

function App() {
  return (
    <>
      <Navigation />
      <Router>
        <div className="App">
          <Routes>
          </Routes>
        </div>
      </Router>
    </>
  );
}

export default App;
