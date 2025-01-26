import Home from './Components/App/Home';
import Navigation from './Components/App/Navigation';

import { BrowserRouter as Router, Route, Routes, Navigate } from 'react-router-dom';

import './App.css';
import React, { useState, useEffect } from 'react';

import Register from './Components/Basic/Register';
import Login from './Components/Basic/Login';
import Error from './Components/Shared/Error';

import Client from './Components/User/Client/Client';
import User from './Components/User/User.jsx';

import Order from './Components/Order/Order';
import Recipe from './Components/Recipe/Recipe';
import FermentingIngredients from './Components/Info/FermentingIngredients/FermentingIngredients';

import Kanban from './Components/Work/Kanban';

import LogoutButton from './Components/Basic/LogoutButton'

import ProtectedRoute from './Components/Basic/ProtectedRoute'

import { I18nextProvider } from 'react-i18next';
import i18n from './i18n';
import ProspectOrderForm from './Components/Order/ProspectOrderForm.jsx';
import ProspectOrderSummary from './Components/Order/ProspectOrderSummary.jsx';
import Unauthorized from './Components/App/Unuthorized';

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
              <Route
                path="/login"
                element={<Login setIsAuthenticated={setIsAuthenticated} />}
              />

              <Route
                exact
                path="/ProspectOrder"
                element={<ProspectOrderForm />}
              />
              <Route
                exact
                path="/ProspectOrderSummary"
                element={<ProspectOrderSummary />}
              />

              <Route
                exact
                path="/Order"
                element={
                  <ProtectedRoute roles={["supervisor"]}>
                    <Order />
                  </ProtectedRoute>
                }
              />
              <Route
                exact
                path="/Recipe"
                element={
                  <ProtectedRoute roles={["brewer"]}>
                    <Recipe />
                  </ProtectedRoute>
                }
              />

              <Route
                exact
                path="/FermentingIngredients"
                element={
                  <ProtectedRoute roles={["supervisor"]}>
                    <FermentingIngredients />
                  </ProtectedRoute>
                }
              />

              <Route
                exact
                path="/Client"
                element={
                  <ProtectedRoute roles={["manager"]}>
                    <Client />
                  </ProtectedRoute>
                }
              />
              <Route
                exact
                path="/User"
                element={
                  <ProtectedRoute roles={["manager"]}>
                    <User />
                  </ProtectedRoute>
                }
              />

              <Route exact path="/Error" element={<Error />} />
              <Route exact path="/Unauthorized" element={<Unauthorized />} />

              <Route
                path="/Kanban"
                element={
                  <ProtectedRoute roles={["employee"]}>
                    <Kanban />
                  </ProtectedRoute>
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
