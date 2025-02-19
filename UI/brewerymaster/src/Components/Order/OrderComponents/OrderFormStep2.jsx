import React, { useEffect, useState } from "react";
import { fetchData } from "../../Shared/api";
import FormBasic from "../../Shared/ModalComponents/FormBasic";

import { useTranslation } from "react-i18next";

import fieldsProvider from "./helpers/fieldsProvider";

const OrderFormStep2 = ({ data, setData }) => {
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
      datePicker:[
        {
          name: "targetDate",
          label: "Expected Date",
        },
      ]
    });
  }, [containers]);

  return (
    <div>
      <FormBasic
        fields={fields}
        data={data}
        setData={setData}
      />
    </div>
  );
};

export default OrderFormStep2;
