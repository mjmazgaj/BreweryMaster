import BackgroundDetails from "../Shared/BackgroundDetails";
import "./App.css";

import HomeGuest from "./AppComponents/HomeGuest"
import UserDetails from "../User/UserDetails";

import { useUser } from "../Security/UserProvider";
function Home() {
  const { user } = useUser();


  return (
    <>
      <BackgroundDetails />
      <div className="home_container">
        {user?.isAuthenticated ? <UserDetails /> : <HomeGuest />}
      </div>
    </>
  );
}

export default Home;
