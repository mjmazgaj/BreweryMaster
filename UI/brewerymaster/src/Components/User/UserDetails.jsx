import React, { useState, useEffect, Fragment } from "react";
import "./user.css";

import { useTranslation } from "react-i18next";
import { useParams } from "react-router-dom";

import userFieldsProvider from "../User/helpers/userFieldsProvider";
import { fetchData, apiEndpoints } from "../Shared/api";

import ControlsCard from "../Shared/ControlComponents/ControlsCard";
import UserRoles from "./UserComponents/UserRoles";

import { useUserDetails } from "./UserComponents/helpers/useUserDetails";
import ModalFormBasic from "../Shared/ModalComponents/ModalFormBasic";
import { Button } from "react-bootstrap";

const UserDetails = () => {
  const { t } = useTranslation();
  const { id } = useParams();

  const [modalData, setModalData] = useState({});
  const [showModal, setShowModal] = useState(false);
  const [modalType, setModalType] = useState("addressEditInfo");
  const [userData, setUserData] = useState({});

  const {
    modalDataProvider,
    handleEditAddress,
    handleAddAddress,
    handleEditUser,
    fetchUserDataById,
  } = useUserDetails({
    id,
    userData,
    setUserData,
    setShowModal,
    setModalData,
    setModalType,
  });

  return (
    <div className="user-details_container">
      {id && (
        <Fragment>
          <h2>{t("name.brewery.users")}</h2>
          <h4>{t("name.general.details")}</h4>
        </Fragment>
      )}
      <div className="info_container">
        <div className="user-info_container">
          <ControlsCard
            className="user-info-card_container"
            title={t("user.userInfoTitle")}
            data={{ ...userData?.individualUser, email: userData?.email }}
            fields={userFieldsProvider(t).infoFields.control}
            path="User"
            emptyMessage={t("user.userInfoEmptyMsg")}
            handleEdit={() => handleEditUser()}
          />
          <Button
            className="button-add-address"
            variant="dark"
            onClick={() => handleAddAddress()}
          >
            Dodaj adres
          </Button>
        </div>
        <ControlsCard
          className="home-address-info_container"
          title={t("user.homeAddressTitle")}
          data={userData?.homeAddress}
          fields={userFieldsProvider(t).addressInfoFields.control}
          path="Address"
          emptyMessage={t("user.homeAddressMsg")}
          handleEdit={() => handleEditAddress("homeAddress")}
        />
        <ControlsCard
          className="delivery-address-info_container"
          title={t("user.deliveryAddressTitle")}
          data={userData?.deliveryAddress}
          fields={userFieldsProvider(t).addressInfoFields.control}
          path="Address"
          emptyMessage={t("user.deliveryAddressMsg")}
          handleEdit={() => handleEditAddress("deliveryAddress")}
        />
        <div className="user-details-modal_container">
          <ModalFormBasic
            fields={modalDataProvider[modalType].fields}
            data={modalData}
            setData={setModalData}
            show={showModal}
            setShow={setShowModal}
            modalCustomizationObject={modalDataProvider[modalType].object}
          />
        </div>

        {id && (
          <UserRoles userData={userData} refreshPageData={fetchUserDataById} />
        )}
      </div>
    </div>
  );
};

export default UserDetails;
