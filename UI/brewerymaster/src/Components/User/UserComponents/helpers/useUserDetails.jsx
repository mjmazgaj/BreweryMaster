import { useState, useEffect } from "react";

import { useTranslation } from "react-i18next";

import { apiEndpoints, fetchData } from "../../../Shared/api";
import securityFormFieldsProvider from "../../../Security/helpers/securityFormFieldsProvider";

export const useUserDetails = ({
  id,
  userData,
  setUserData,
  setShowModal,
  setModalData,
  setModalType,
}) => {
  const { t } = useTranslation();
  const [addressTypes, setAddressTypes] = useState({});

  const handleEditAddress = (modalType) => {
    setModalType("addressEditInfo");
    setModalData({ ...userData[modalType] });
    setShowModal(true);
  };
  const handleAddAddress = (modalType) => {
    setModalType("addressAddInfo");
    setModalData({ ...userData[modalType] });
    setShowModal(true);
  };

  const handleEditUser = () => {
    setModalType("userInfo");
    setModalData({ ...userData.companyUser, ...userData.individualUser });
    setShowModal(true);
  };

  const userModalObject = {
    submitFunction: async (data) => {
      console.log(data);
    },
    buttons: [
      {
        isSubmit: false,
        label: t("button.save"),
      },
    ],
    title: t("user.edditUserInfo"),
  };

  const addressEditModalObject = {
    submitFunction: async (data) => {
      console.log(data);
    },
    buttons: [
      {
        isSubmit: false,
        label: t("button.save"),
      },
    ],
    title: t("user.editDeliveryAddress"),
    className: "address-modal",
  };

  const addressAddModalObject = {
    submitFunction: async (data) => {
      console.log(data);
    },
    buttons: [
      {
        isSubmit: false,
        label: t("button.add"),
      },
    ],
    title: t("user.addDeliveryAddress"),
    className: "address-modal",
  };

  const addressEditModalFields = {
    control: securityFormFieldsProvider(t).address,
  };

  const addressAddModalFields = {
    control: securityFormFieldsProvider(t).address,
    dropdown: [
      {
        data: addressTypes,
        name: "typeId",
        label: t("name.brewery.type"),
      },
    ],
  };

  const userModalFields = {
    control: securityFormFieldsProvider(t).individualUserInfo,
  };

  const modalDataProvider = {
    addressEditInfo: {
      object: addressEditModalObject,
      fields: addressEditModalFields,
    },
    addressAddInfo: {
      object: addressAddModalObject,
      fields: addressAddModalFields,
    },
    userInfo: {
      object: userModalObject,
      fields: userModalFields,
    },
  };

  const fetchUserDataById = () => {
    fetchData(`${apiEndpoints.user}/${id}`, setUserData);
  };

  const fetchCurrentUserData = () => {
    fetchData(apiEndpoints.userDetails, setUserData);
  };

  useEffect(() => {
    if (id) {
      fetchUserDataById();
    } else {
      fetchCurrentUserData();
    }
    fetchData(apiEndpoints.addressType, setAddressTypes);
  }, []);

  return {
    modalDataProvider,
    handleEditAddress,
    handleAddAddress,
    handleEditUser,
    fetchUserDataById,
  };
};
