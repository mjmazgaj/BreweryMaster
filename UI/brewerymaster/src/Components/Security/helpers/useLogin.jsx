import { login, currentUserRoles, fetchInfo } from "../Endpoints";
import { useNavigate } from "react-router-dom";
import { useUser } from "../UserProvider";

export const useLogin = ({ data, setErrorMessage }) => {
  const { setUser } = useUser();
  const navigate = useNavigate();

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      console.log(data);

      const loginResult = await login(data);
      sessionStorage.setItem("token", loginResult.accessToken);

      const info = await fetchInfo();
      setUser({
        token: loginResult.accessToken,
        email: info.email,
        roles: info.roles,
        isAuthenticated: loginResult.accessToken ? true : false,
      });

      navigate("/");
      setErrorMessage("");
    } catch (error) {
      setErrorMessage(
        error.response?.data?.message ||
          "Logowanie nie powiodło się. Spróbuj ponownie."
      );
    }
  };
  return {
    handleLogin,
  };
};
