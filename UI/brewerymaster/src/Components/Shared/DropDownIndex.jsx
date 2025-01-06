import {React} from 'react';
import { Form } from 'react-bootstrap';

const DropDownIndex = ({
  id,
  data,
  selectedOption,
  setSelectedOption,
  isReadOnly,
  label
}) => {
  return (
    <div className="form-dropdown">
      {data && data.length > 0 ? (
        <>
          <Form.Label>{label}</Form.Label>
          <Form.Select
            id={id}
            value={selectedOption}
            onChange={setSelectedOption}
            disabled={isReadOnly}
            placeholder="xd"
          >
            <option key={0} value={0}></option>
            {data.map((item) => (
              <option key={item.id} value={item.id}>
                {item.name}
              </option>
            ))}
          </Form.Select>
        </>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
};

export default DropDownIndex;
