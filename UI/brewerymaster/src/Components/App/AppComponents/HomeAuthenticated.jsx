import "../App.css";

import { useUser } from "../../Security/UserProvider";

function HomeAuthenticated() {
  const { user } = useUser();


  return (
    <>
      <div className="home-authenticated_container">
        <h2>Jestes zalogowany jako:</h2>
        <p>{user?.email}</p>
      </div>
    </>
  );
}

export default HomeAuthenticated;
