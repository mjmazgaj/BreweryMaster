
import Home from '../Home';
import Register from '../../Security/Register';
import Login from '../../Security/Login';
import ProspectOrder from '../../Order/ProspectOrder';
import ProspectOrderSummary from '../../Order/ProspectOrderSummary';
import Order from '../../Order/Order';
import Recipe from '../../Recipe/Recipe';
import RecipeDetails from '../../Recipe/RecipeDetails';
import FermentingIngredients from '../../Info/FermentingIngredients/FermentingIngredients';
import User from '../../User/User';
import UserDetails from '../../User/UserDetails';
import Kanban from '../../Work/Kanban';
import Unauthorized from '../Unuthorized';
import Error from '../../Shared/Error';
import OrderDetails from '../../Order/OrderDetails';


export const useApp = () => {
    const routes = [
      { path: "/", element: <Home /> },
      { path: "/register", element: <Register /> },
      { path: "/login", element: <Login /> },
      { path: "/ProspectOrder", element: <ProspectOrder /> },
      { path: "/ProspectOrderSummary", element: <ProspectOrderSummary /> },
      { path: "/Error", element: <Error /> },
      { path: "/Unauthorized", element: <Unauthorized /> },
    ];

    const protectedRoutes = [
      { path: "/Order", roles:["supervisor"], element: <Order /> },
      { path: "/Order/:id", roles:["supervisor"], element: <OrderDetails /> },
      { path: "/Recipe", roles:["brewer"], element: <Recipe /> },
      { path: "/Recipe/:id", roles:["brewer"], element: <RecipeDetails /> },
      { path: "/FermentingIngredients", roles:["supervisor"], element: <FermentingIngredients /> },
      { path: "/User", roles:["manager"], element: <User /> },
      { path: "/User/:id", roles:["manager"], element: <UserDetails /> },
      { path: "/Kanban", roles:["employee"], element: <Kanban /> },
    ];

    return {
      routes,
      protectedRoutes
    };
  };
  