import {Container, Nav, Navbar, NavDropdown} from 'react-bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

function Navigation(isAuthenticated) {
  return (
      <Navbar bg="dark" data-bs-theme="dark">
        <Container>
          <Navbar.Brand href="/">Navbar</Navbar.Brand>
          <Nav className="me-auto">      
            <Nav.Link href="/Kanban">Kanban</Nav.Link>      
            <NavDropdown title="User" id="navbarScrollingDropdown">
              <NavDropdown.Item href="/Client">Client</NavDropdown.Item>
              <NavDropdown.Item href="/Address">Address</NavDropdown.Item>
              <NavDropdown.Item href="/Employee">Employee</NavDropdown.Item>
            </NavDropdown>
          </Nav>
          <Nav>      
            <Nav.Link href="/Login">Login</Nav.Link>
            <Nav.Link href="/Register">Register</Nav.Link>
          </Nav>
        </Container>
      </Navbar>
  );
}

export default Navigation;
