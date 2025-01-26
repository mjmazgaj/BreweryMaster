import 'bootstrap/dist/css/bootstrap.min.css';
import { Button } from 'react-bootstrap';

function Unauthorized() {
  return (
    <>
      <h1>Strona niedostepna</h1>
      <p>Brak wystarczajacych uprawnien</p>

      <Button href='/Login'>
        Login
      </Button>
    </>
  );
}

export default Unauthorized;
