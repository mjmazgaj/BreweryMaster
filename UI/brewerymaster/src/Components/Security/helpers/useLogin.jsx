
import { login, currentUserRoles } from '../Endpoints';
import { useNavigate } from 'react-router-dom';
import { useUser } from '../UserProvider';

export const useLogin = ({data, setErrorMessage}) => {
    const { setUser } = useUser();
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();
        try {
            console.log(data);

          const loginResult = await login(data);
          sessionStorage.setItem('token', loginResult.accessToken);
    
          const roles = await currentUserRoles();
          setUser({
            token: loginResult.accessToken,
            roles: roles,
            isAuthenticated: loginResult.accessToken ? true : false,
          });
    
          navigate("/kanban")
          setErrorMessage("");
        } catch (error) {
          setErrorMessage(error.response?.data?.message || 'Logowanie nie powiodło się. Spróbuj ponownie.');
        }
      };
  return {
    handleLogin
  };
};