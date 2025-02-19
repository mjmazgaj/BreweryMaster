import "../App.css";
import NavigateButton from "../NavigateButton";

function HomeGuest() {
  return (
    <>
      <div className="home-guest_container">
        <h1>Browar rzemieślniczy</h1>
        <h6>Zamów swoje piwo!</h6>
        <div className="home-guest-navigation_container">
          <div className="home-guest_info">
            <h3>Strefa gościa</h3>
            <hr />
            <h6>Ile to kosztuje?</h6>
            <p>Skorzystaj z naszego kalkulatora do oszacowania kosztów</p>
            <NavigateButton
              path="/ProspectOrder"
              name="Kalkulator"
              variant="dark"
            />
            <hr />
            <h6>Jesteś zainteresowany współpracą?</h6>
            <p>Wypełnij formularz, a my skontaktujemy się z tobą</p>
            <NavigateButton
              path="/ProspectOrder"
              name="Formularz"
              variant="dark"
            />
          </div>
          <div className="home-user_info">
            <h3>Strefa użytkownika</h3>
            <hr />
            <h6>Masz już konto?</h6>
            <p>Zaloguj się do systemu</p>
            <NavigateButton path="/Login" name="Zaloguj" variant="dark" />
            <hr />
            <h6>Chcesz założyć konto?</h6>
            <p>Zarejestruj się i uzyskaj dostęp do tworzenia zamówień</p>
            <NavigateButton
              path="/Register"
              name="Zarejestruj"
              variant="dark"
            />
          </div>
        </div>
      </div>
    </>
  );
}

export default HomeGuest;
