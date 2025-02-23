import { useState } from "react";
import { Button, ButtonGroup, Nav, NavDropdown, Navbar } from "react-bootstrap";

import RequireRole from "../../Security/SecurityComponents/RequireRole";

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
    homePage: <Navbar.Brand href="/">{t("navigation.homePage")}</Navbar.Brand>,
    employee: (
      <RequireRole roles={["employee"]}>
        <Nav.Link href="/Kanban">{t("navigation.kanban")}</Nav.Link>
      </RequireRole>
    ),
    customer: (
      <RequireRole roles={["customer"]}>
        <Nav.Link href="/Order">{t("navigation.order")}</Nav.Link>
      </RequireRole>
    ),
    supervisor: (
      <RequireRole roles={["supervisor"]}>
        <Nav.Link href="/Order">{t("navigation.order")}</Nav.Link>
        <Nav.Link href="/ProspectOrderSummary">
          {t("navigation.prospectOrder")}
        </Nav.Link>
      </RequireRole>
    ),
    manager: (
      <RequireRole roles={["manager"]}>
        <NavDropdown title={t("navigation.user")} id="navbarScrollingDropdown">
          <NavDropdown.Item href="/User">
            {t("navigation.user")}
          </NavDropdown.Item>
          <NavDropdown.Item href="/Client">
            {t("navigation.client")}
          </NavDropdown.Item>
        </NavDropdown>
      </RequireRole>
    ),
    brewer: (
      <RequireRole roles={["brewer"]}>
        <Nav.Link href="/Recipe">{t("navigation.recipe")}</Nav.Link>
        <NavDropdown title={t("navigation.info")} id="navbarScrollingDropdown">
          <NavDropdown.Item href="/FermentingIngredients">
            {t("navigation.fermentingIngredient")}
          </NavDropdown.Item>
          <NavDropdown.Item href="/FermentingIngredients">
            {t("navigation.hops")}
          </NavDropdown.Item>
          <NavDropdown.Item href="/FermentingIngredients">
            {t("navigation.yeast")}
          </NavDropdown.Item>
          <NavDropdown.Item href="/FermentingIngredients">
            {t("navigation.extras")}
          </NavDropdown.Item>
          <NavDropdown.Item href="/FermentingIngredients">
            {t("navigation.equipment")}
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
        {t("button.logout")}
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
    navigationModules,
  };
};
