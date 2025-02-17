import "../App.css"

import { useUser } from "../../Security/UserProvider";
import UserDetails from "../../User/UserDetails";
import { Button } from "react-bootstrap";

const HomeUser = () => {
  const { user } = useUser();

  return (
    <div className="home-user_container">
        <h3>You are logged as:</h3>
        <p>{user?.email}</p>
        <Button variant="dark">Change password</Button>
        <UserDetails />
    </div>
  );
};

export default HomeUser;
