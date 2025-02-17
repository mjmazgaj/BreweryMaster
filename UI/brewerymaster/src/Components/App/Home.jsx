import BackgroundDetails from "../Shared/BackgroundDetails";
import "./App.css";

import HomeGuest from "./AppComponents/HomeGuest"

import { useUser } from "../Security/UserProvider";
import HomeUser from "./AppComponents/HomeUser";
function Home() {
  const { user } = useUser();


  return (
    <>
      <BackgroundDetails />
      <div className="home_container">
        {user?.isAuthenticated ? <HomeUser /> : <HomeGuest />}
      </div>
    </>
  );
}

export default Home;
