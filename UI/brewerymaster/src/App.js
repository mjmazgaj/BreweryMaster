import Home from './Components/Home/Home';
import Navigation from './Components/App/Navigation';

import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';

import './App.css';
import React, { useState, useEffect } from 'react';

import Register from './Components/Basic/Register';
import Login from './Components/Basic/Login';
import Error from './Components/Shared/Error';

import Address from './Components/User/Address/Address';
import Client from './Components/User/Client/Client';
import Employee from './Components/User/Employee/Employee';
import User from './Components/User/User.jsx';

import Order from './Components/Order/Order';
import ProspectOrder from './Components/Order/ProspectOrder/ProspectOrder';
import Recipe from './Components/Recipe/Recipe';
import FermentingIngredients from './Components/Info/FermentingIngredients/FermentingIngredients';

import Kanban from './Components/Work/Kanban';

import Authorize from './Components/Basic/Authorize';
import LogoutButton from './Components/Basic/LogoutButton'


import { I18nextProvider } from 'react-i18next';
import i18n from './i18n';

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
      <I18nextProvider i18n={i18n}>
        <Navigation isAuthenticated={isAuthenticated} />
        <Router>
          <div className="App">
            <Routes>
              <Route exact path="/" element={<Home />} />
              <Route path="*" element={<Navigate to="/" />} />

              <Route path="/register" element={<Register />} />
              <Route path="/login" element={<Login setIsAuthenticated={setIsAuthenticated}/>} />
              <Route path="/error" element={<Error />} />

              <Route exact path="/ProspectOrder" element={<ProspectOrder />} />
              <Route exact path="/Order" element={<Order />} />
              <Route exact path="/Recipe" element={<Recipe />} />
              <Route exact path="/FermentingIngredients" element={<FermentingIngredients />} />

              <Route exact path="/Address" element={<Address />} />
              <Route exact path="/Client" element={<Client />} />
              <Route exact path="/Employee" element={<Employee />} />
              <Route exact path="/User" element={<User />} />

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
      </I18nextProvider>
    </>
  );
};

export default App;
