import Navigation from "./Components/App/Navigation";
import "react-toastify/dist/ReactToastify.css";

import {
  BrowserRouter as Router,
  Route,
  Routes,
  Navigate,
} from "react-router-dom";

import "./Components/App/App.css";
import React from "react";

import ProtectedRoute from "./Components/Security/SecurityComponents/ProtectedRoute";

import { I18nextProvider } from "react-i18next";
import { ToastContainer } from "react-toastify";
import i18n from "./i18n";
import Footer from "./Components/App/Footer.jsx";
import { useApp } from "./Components/App/helpers/useApp.jsx";
const App = () => {
  const { routes, protectedRoutes } = useApp();

  return (
    <>
      <I18nextProvider i18n={i18n}>
        <ToastContainer />
        <Navigation />
        <Router>
          <div className="App">
            <Routes>
              <Route path="*" element={<Navigate to="/" />} />

              {routes.map(({ path, element }, index) => (
                <Route key={index} exact path={path} element={element} />
              ))}

              {protectedRoutes.map(({ path, roles, element }, index) => (
                <Route
                  key={index}
                  exact
                  path={path}
                  element={
                    <ProtectedRoute roles={roles}>{element}</ProtectedRoute>
                  }
                />
              ))}
            </Routes>
          </div>
        </Router>
        <Footer />
      </I18nextProvider>
    </>
  );
};

export default App;
