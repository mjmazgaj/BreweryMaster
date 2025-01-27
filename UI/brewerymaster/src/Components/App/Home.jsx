import BackgroundDetails from "../Shared/BackgroundDetails";
import "./App.css";

import HomeGuest from "./AppComponents/HomeGuest"
import HomeAuthenticated from "./AppComponents/HomeAuthenticated"

import { useUser } from "../Security/UserProvider";
function Home() {
  const { user } = useUser();


  return (
    <>
      <BackgroundDetails />
      <div className="home_container">
        {user?.isAuthenticated ? <HomeAuthenticated /> : <HomeGuest />}
      </div>
    </>
  );
}

export default Home;
