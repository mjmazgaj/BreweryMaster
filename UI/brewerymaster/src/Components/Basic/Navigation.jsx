import {useState} from 'react';
import {Button, ButtonGroup, Container, Nav, Navbar, NavDropdown} from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';
import { useTranslation } from 'react-i18next';

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
          <Nav.Link href="/Kanban">Kanban</Nav.Link>
          <Nav.Link href="/ProspectOrder">ProspectOrder</Nav.Link>
          <Nav.Link href="/Order">Order</Nav.Link>
          <Nav.Link href="/Recipe">Recipe</Nav.Link>
          <Nav.Link href="/Info">Info</Nav.Link>

          <NavDropdown title="User" id="navbarScrollingDropdown">
            <NavDropdown.Item href="/Client">Client</NavDropdown.Item>
            <NavDropdown.Item href="/Address">Address</NavDropdown.Item>
            <NavDropdown.Item href="/Employee">Employee</NavDropdown.Item>
          </NavDropdown>
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
