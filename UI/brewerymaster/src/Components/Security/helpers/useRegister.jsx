
import { useNavigate } from 'react-router-dom';

import {register} from '../Endpoints'

import securityFormFieldsProvider from './securityFormFieldsProvider';
import { useState } from 'react';

import { useTranslation } from 'react-i18next';
import FormControls from '../../Shared/FormControls';
import UserInfo from '../SecurityComponents/UserInfo';

export const useRegister = ({setErrorMessage, setIsValid}) => {
  const { t } = useTranslation();
  const navigate = useNavigate();

  const handleRegister = async (e) => {
    e.preventDefault();
    try {

      const userObject = {
        userAuthInfo: {
          email: userAuthInfo.email,
          password: userAuthInfo.password,
          confirmPassword: userAuthInfo.confirmPassword,
        },
        address: {
          street: address.street,
          houseNumber: address.houseNumber,
          apartamentNumber: address.apartamentNumber,
          postalCode: address.postalCode,
          city: address.city,
          commune: address.commune,
          region: address.region,
          country: address.country,
        },
        isCompany : isCompany,
        individualUserInfo: !isCompany
          ? {
              forename: individualUserInfo.forename,
              surname: individualUserInfo.surname,
            }
          : null,
        companyUserInfo: isCompany
          ? {
              companyName: companyUserInfo.companyName,
              nip: companyUserInfo.nip,
              invoiceAddress: {
                street: companyUserInfo.invoiceAddress?.street,
                houseNumber: companyUserInfo.invoiceAddress?.houseNumber,
                apartamentNumber:
                  companyUserInfo.invoiceAddress?.apartamentNumber,
                postalCode: companyUserInfo.invoiceAddress?.postalCode,
                city: companyUserInfo.invoiceAddress?.city,
                commune: companyUserInfo.invoiceAddress?.commune,
                region: companyUserInfo.invoiceAddress?.region,
                country: companyUserInfo.invoiceAddress?.country,
              },
            }
          : null,
      };

      await register(userObject);
      setErrorMessage('');
      navigate('/login');
    } catch (error) {
      setErrorMessage(error.response?.data?.message || 'Rejestracja nie powiodła się. Spróbuj ponownie.');
    }
  };

  const [userAuthInfo, setUserAuthInfo] = useState({});
  const [address, setAddress] = useState({});
  const [individualUserInfo, setIndividualUserInfo] = useState({});
  const [companyUserInfo, setCompanyUserInfo] = useState({});
  const [isCompany, setIsCompany] = useState(false);

  const steps = [
    {
      key: "userAuthInfo",
      name: "Dane użytkownika",
      component: (
        <FormControls
          fields={securityFormFieldsProvider(t).userAuthInfo}
          data={userAuthInfo}
          setData={setUserAuthInfo}
          setIsValid={setIsValid}
        />
      ),
    },
    {
      key: "address",
      name: "Address",
      component: (
        <FormControls
          fields={securityFormFieldsProvider(t).address}
          data={address}
          setData={setAddress}
          setIsValid={setIsValid}
        />
      ),
    },
    {
      key: "userInfo",
      name: "User Info",
      component: (
        <UserInfo
          individualUserInfo={individualUserInfo}
          setIndividualUserInfo={setIndividualUserInfo}
          companyUserInfo={companyUserInfo}
          setCompanyUserInfo={setCompanyUserInfo}
          isCompany={isCompany}
          setIsCompany={setIsCompany}
          setIsValid={setIsValid}
        />
      ),
    },
  ];

  return {
    handleRegister,
    steps
  };
};