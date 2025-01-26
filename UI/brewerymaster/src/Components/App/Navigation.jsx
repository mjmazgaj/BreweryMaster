import {useState} from 'react';
import {Button, ButtonGroup, Container, Nav, Navbar, NavDropdown} from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useTranslation } from 'react-i18next';

import RequireRole from '../Security/RequireRole'

function Navigation(isAuthenticated) {
  const { t, i18n } = useTranslation();

  const [currentLanguage, setCurrentLanguage] = useState("en");

  const changeLanguage = (lng) => () => {
    i18n.changeLanguage(lng);
    localStorage.setItem("language", lng);
    setCurrentLanguage(lng);
  };

  return (
    <Navbar bg="dark" data-bs-theme="dark">
      <Container>
        <Navbar.Brand href="/">Navbar</Navbar.Brand>
        <Nav className="me-auto">
          <RequireRole roles={["employee"]}>
            <Nav.Link href="/Kanban">Kanban</Nav.Link>
          </RequireRole>

          <RequireRole roles={["supervisor"]}>
            <Nav.Link href="/Order">Order</Nav.Link>
            <Nav.Link href="/ProspectOrderSummary">
              ProspectOrderSummary
            </Nav.Link>
          </RequireRole>

          <RequireRole>
            <Nav.Link href="/ProspectOrder">ProspectOrder</Nav.Link>
          </RequireRole>

          <RequireRole roles={["manager"]}>
            <NavDropdown title="User" id="navbarScrollingDropdown">
              <NavDropdown.Item href="/User">User</NavDropdown.Item>
              <NavDropdown.Item href="/Client">Client</NavDropdown.Item>
            </NavDropdown>
          </RequireRole>

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
        </Nav>

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
        <Nav>
          <Nav.Link href="/Login">Login</Nav.Link>
          <Nav.Link href="/Register">Register</Nav.Link>
        </Nav>
      </Container>
    </Navbar>
  );
}

export default Navigation;
