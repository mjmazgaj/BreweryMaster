
import { useState } from "react";
import {
    Button,
    ButtonGroup,
    Nav,
    NavDropdown,
    Navbar,
  } from "react-bootstrap";
  
import RequireRole from "../../Security/RequireRole";

import { logout } from "../../Security/Endpoints";

import { useUser } from "../../Security/UserProvider";
import { useTranslation } from "react-i18next";

export const useNavigation = () => {
    const [currentLanguage, setCurrentLanguage] = useState("en");
  const { setUser } = useUser();
  const { t, i18n } = useTranslation();

  const handleLogout = async () => {
    await logout();
    window.location.href = "/";
    setUser({
      token: [],
      roles: "",
      isAuthenticated: false,
    });
  };

  const changeLanguage = (lng) => () => {
    i18n.changeLanguage(lng);
    localStorage.setItem("language", lng);
    setCurrentLanguage(lng);
  };

  const navigationModules = {
    homePage: <Navbar.Brand href="/">Strona główna</Navbar.Brand>,
    employee: (
      <RequireRole roles={["employee"]}>
        <Nav.Link href="/Kanban">Kanban</Nav.Link>
      </RequireRole>
    ),
    supervisor: (
      <RequireRole roles={["supervisor"]}>
        <Nav.Link href="/Order">Order</Nav.Link>
        <Nav.Link href="/ProspectOrderSummary">ProspectOrderSummary</Nav.Link>
      </RequireRole>
    ),
    manager: (
      <RequireRole roles={["manager"]}>
        <NavDropdown title="User" id="navbarScrollingDropdown">
          <NavDropdown.Item href="/User">User</NavDropdown.Item>
          <NavDropdown.Item href="/Client">Client</NavDropdown.Item>
        </NavDropdown>
      </RequireRole>
    ),
    brewer: (
      <RequireRole roles={["brewer"]}>
        <Nav.Link href="/Recipe">Recipe</Nav.Link>
        <NavDropdown title="Info" id="navbarScrollingDropdown">
          <NavDropdown.Item href="/FermentingIngredients">
            Fermenting Ingredients
          </NavDropdown.Item>
          <NavDropdown.Item href="/FermentingIngredients">
            Hops
          </NavDropdown.Item>
          <NavDropdown.Item href="/FermentingIngredients">
            Yeast
          </NavDropdown.Item>
          <NavDropdown.Item href="/FermentingIngredients">
            Extras
          </NavDropdown.Item>
          <NavDropdown.Item href="/FermentingIngredients">
            Tanks
          </NavDropdown.Item>
        </NavDropdown>
      </RequireRole>
    ),
    logoutButton: (
      <Button
        style={{ marginRight: "1rem" }}
        variant="light"
        onClick={handleLogout}
      >
        Wyloguj
      </Button>
    ),
    languageSwitch: (
      <ButtonGroup>
        <Button
          onClick={changeLanguage("en")}
          variant={currentLanguage === "en" ? "light" : "secondary"}
        >
          EN
        </Button>
        <Button
          onClick={changeLanguage("pl")}
          variant={currentLanguage === "pl" ? "light" : "secondary"}
        >
          PL
        </Button>
      </ButtonGroup>
    ),
  };

  return {
    handleLogout,
    changeLanguage,
    navigationModules
  };
};
