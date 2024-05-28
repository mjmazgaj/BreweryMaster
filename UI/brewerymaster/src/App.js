import Home from './Components/Basic/Home';
import Navigation from './Components/Basic/Navigation';

import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';

import './App.css';
import Address from './Components/User/Address';
import React, { useState, useEffect } from 'react';

import Kanban from './Components/Kanban/Kanban';

import Register from './Components/General/Register';
import Login from './Components/General/Login';
import Dashboard from './Components/Authorization/Dashboard';
import Authorize from './Components/Authorization/Authorize';
import LogoutButton from './Components/General/LogoutButton'

const App = () => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);
  
  useEffect(() => {
    const token = sessionStorage.getItem('token');
    if (token) {
      setIsAuthenticated(true); 
    }
    else {
      setIsAuthenticated(false);
    }
  }, []);
  
  return (
    <>
      <Navigation />
      <Router>
        <div className="App">
          <Routes>
            <Route exact path="/" element={<Home/>} />
            <Route exact path="/Address" element={<Address/>} />
            <Route path="*" element={<Navigate to ="/"/>} />
                      <Route path="/register" element={<Register/>} />
          <Route path="/login" element={<Login/>} />
          <Route path="/kanban" element={<Kanban/>} />
          <Route path="/dashboard" element={<Authorize component={Dashboard} isAuthenticated={isAuthenticated} setIsAuthenticated={setIsAuthenticated}/>}></Route>
          </Routes>
                    {isAuthenticated && <LogoutButton setIsAuthenticated={setIsAuthenticated} />}
        </div>
      </Router>
    </>
  );
};

export default App;
