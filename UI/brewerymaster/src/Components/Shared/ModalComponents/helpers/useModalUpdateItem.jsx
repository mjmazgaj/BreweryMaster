import { useTranslation } from 'react-i18next';

export const useModalUpdateItem = (data, setShow) => {
  const { t } = useTranslation(); 

  const handleCloseOnClick = () => {
    setShow(false);
  }
  const handleConfirmOnClick = () => {
    console.log(data);
  };


  return {
    handleCloseOnClick,
    handleConfirmOnClick
  };
};