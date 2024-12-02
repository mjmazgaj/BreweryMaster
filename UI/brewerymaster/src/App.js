import Home from './Components/Basic/Home';
import Navigation from './Components/Basic/Navigation';

import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';

import './App.css';
import React, { useState, useEffect } from 'react';

import Register from './Components/General/Register';
import Login from './Components/General/Login';

import Address from './Components/User/Address/Address';
import Client from './Components/User/Client/Client';
import Employee from './Components/User/Employee/Employee';

import ProspectOrder from './Components/Order/ProspectOrder';

import Kanban from './Components/Work/Kanban/Kanban';

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
      <Navigation isAuthenticated={isAuthenticated} />
      <Router>
        <div className="App">
          <Routes>
            <Route exact path="/" element={<Home />} />
            <Route path="*" element={<Navigate to="/" />} />

            <Route path="/register" element={<Register />} />
            <Route path="/login" element={<Login />} />

            <Route exact path="/ProspectOrder" element={<ProspectOrder />} />
            <Route exact path="/Address" element={<Address />} />
            <Route exact path="/Client" element={<Client />} />
            <Route exact path="/Employee" element={<Employee />} />

            <Route
              path="/kanban"
              element={
                <Authorize
                  component={Kanban}
                  isAuthenticated={isAuthenticated}
                  setIsAuthenticated={setIsAuthenticated}
                />
              }
            ></Route>
          </Routes>

          {isAuthenticated && (
            <LogoutButton setIsAuthenticated={setIsAuthenticated} />
          )}
        </div>
      </Router>
    </>
  );
};

export default App;
