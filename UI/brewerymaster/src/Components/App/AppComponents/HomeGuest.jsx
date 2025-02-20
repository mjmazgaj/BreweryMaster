import "../App.css";
import NavigateButton from "../NavigateButton";
import { useTranslation } from "react-i18next";

function HomeGuest() {
  const { t } = useTranslation();

  return (
    <>
      <div className="home-guest_container">
        <h1>{t("homePage.title")}</h1>
        <h6>{t("homePage.subTitle")}</h6>
        <div className="home-guest-navigation_container">
          <div className="home-guest_info">
            <h3>{t("homePage.guestZone")}</h3>
            <hr />
            <h6>{t("homePage.costTitle")}</h6>
            <p>{t("homePage.costText")}</p>
            <NavigateButton
              path="/ProspectOrder"
              name={t("button.calculator")}
              variant="dark"
            />
            <hr />
            <h6>{t("homePage.cooperationTitle")}</h6>
            <p>{t("homePage.cooperationText")}</p>
            <NavigateButton
              path="/ProspectOrder"
              name={t("button.form")}
              variant="dark"
            />
          </div>
          <div className="home-user_info">
            <h3>{t("homePage.userZone")}</h3>
            <hr />
            <h6>{t("homePage.loginTitle")}</h6>
            <p>{t("homePage.loginText")}</p>
            <NavigateButton path="/Login" name={t("button.login")} variant="dark" />
            <hr />
            <h6>{t("homePage.registerTitle")}</h6>
            <p>{t("homePage.registerText")}</p>
            <NavigateButton
              path="/Register"
              name={t("button.register")}
              variant="dark"
            />
          </div>
        </div>
      </div>
    </>
  );
}

export default HomeGuest;
