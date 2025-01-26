import {
  Container,
  Nav,
  Navbar,
} from "react-bootstrap";

import "bootstrap/dist/css/bootstrap.min.css";

import { useNavigation } from "./helpers/useNavigation";
import { useUser } from "../Security/UserProvider";

function Navigation() {
  const { user } = useUser();

  const { navigationModules } = useNavigation();

  return (
    <Navbar bg="dark" data-bs-theme="dark">
      <Container>
        {navigationModules.homePage}
        <Nav className="me-auto">
          {navigationModules.employee}
          {navigationModules.supervisor}
          {navigationModules.brewer}
          {navigationModules.manager}
        </Nav>

        {user?.isAuthenticated && navigationModules.logoutButton}
        {navigationModules.languageSwitch}
      </Container>
    </Navbar>
  );
}

export default Navigation;
