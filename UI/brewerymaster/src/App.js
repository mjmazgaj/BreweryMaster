import React, { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

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
    <Router>
      <div>
        <Routes>
          <Route path="/register" element={<Register/>} />
          <Route path="/login" element={<Login/>} />
          <Route path="/kanban" element={<Kanban/>} />
          <Route path="/dashboard" element={<Authorize component={Dashboard} isAuthenticated={isAuthenticated} setIsAuthenticated={setIsAuthenticated}/>}></Route>
        </Routes>
          {isAuthenticated && <LogoutButton setIsAuthenticated={setIsAuthenticated} />}
      </div>
    </Router>
  );
};

export default App;
