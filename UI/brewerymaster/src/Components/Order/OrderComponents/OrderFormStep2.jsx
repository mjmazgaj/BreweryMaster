import React, { useEffect, useState } from "react";
import { fetchData } from "../../Shared/api";
import FormBasic from "../../Shared/FormBasic";

import { useTranslation } from "react-i18next";

import fieldsProvider from "./helpers/fieldsProvider";

const OrderFormStep2 = ({ data, setData, setIsValid }) => {
  const { t } = useTranslation();

  const [containers, setContainers] = useState([]);
  const [fields, setFields] = useState({});

  useEffect(() => {
    fetchData("Entity/Container", setContainers);
  }, []);

  useEffect(() => {
    setFields({
      control: fieldsProvider(t).orderFields.control,
      dropdown: [
        {
          data: containers,
          name: "containerId",
          label: "Container",
        },
      ],
      datePicker: [
        {
          name: "targetDate",
          label: t("name.brewery.targetDate"),
        },
      ],
    });
  }, [containers]);

  return (
    <div>
      <FormBasic fields={fields} data={data} setData={setData} setIsValid={setIsValid}/>
    </div>
  );
};

export default OrderFormStep2;
