import Home from './Components/Basic/Home';
import Navigation from './Components/Basic/Navigation';

import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';

import './App.css';
import Address from './Components/User/Address';

function App() {
  return (
    <>
      <Navigation />
      <Router>
        <div className="App">
          <Routes>
            <Route exact path="/" element={<Home/>} />
            <Route exact path="/Address" element={<Address/>} />
            <Route path="*" element={<Navigate to ="/"/>} />
          </Routes>
        </div>
      </Router>
    </>
  );
}

export default App;
