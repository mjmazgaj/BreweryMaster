import React from "react";

import { Button } from "react-bootstrap";
import FormControlsReadOnly from "../FormControlsReadOnly";

import { useTranslation } from "react-i18next";

const ControlsCard = ({
  className,
  title,
  data,
  fields,
  path,
  emptyMessage,
}) => {
  const { t } = useTranslation();

    const handleEdit = () =>{
        console.log("Edit works");
        console.log("Path");
        console.log(path);
    }

  return (
    <div className={className}>
      <h3>{title}</h3>

      {data ? (
        <>
          <FormControlsReadOnly fields={fields} data={data} />
          <div className="buttons_container">
            <Button variant="dark" onClick={handleEdit}>{t("button.edit")}</Button>
          </div>
        </>
      ) : (
        <>
          <p>{emptyMessage}</p>
          <Button variant="dark">{t("button.addNow")}</Button>
        </>
      )}
    </div>
  );
};

export default ControlsCard;
