
import Home from '../Home';
import Register from '../../Security/Register';
import Login from '../../Security/Login';
import ProspectOrderForm from '../../Order/ProspectOrderForm';
import ProspectOrderSummary from '../../Order/ProspectOrderSummary';
import Order from '../../Order/Order';
import Recipe from '../../Recipe/Recipe';
import RecipeDetails from '../../Recipe/RecipeDetails';
import Client from '../../User/Client/Client';
import FermentingIngredients from '../../Info/FermentingIngredients/FermentingIngredients';
import User from '../../User/User';
import Kanban from '../../Work/Kanban';
import Unauthorized from '../Unuthorized';
import Error from '../../Shared/Error';


export const useApp = () => {
    const routes = [
      { path: "/", element: <Home /> },
      { path: "/register", element: <Register /> },
      { path: "/login", element: <Login /> },
      { path: "/ProspectOrder", element: <ProspectOrderForm /> },
      { path: "/ProspectOrderSummary", element: <ProspectOrderSummary /> },
      { path: "/Error", element: <Error /> },
      { path: "/Unauthorized", element: <Unauthorized /> },
    ];

    const protectedRoutes = [
      { path: "/Order", roles:["supervisor"], element: <Order /> },
      { path: "/Recipe", roles:["brewer"], element: <Recipe /> },
      { path: "/Recipe/:id", roles:["brewer"], element: <RecipeDetails /> },
      { path: "/FermentingIngredients", roles:["supervisor"], element: <FermentingIngredients /> },
      { path: "/Client", roles:["manager"], element: <Client /> },
      { path: "/User", roles:["manager"], element: <User /> },
      { path: "/Kanban", roles:["employee"], element: <Kanban /> },
    ];

    return {
      routes,
      protectedRoutes
    };
  };
  