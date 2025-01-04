import {React} from 'react';
import { Form } from 'react-bootstrap';

const DropDownIndex = ({
  id,
  data,
  selectedOption,
  setSelectedOption,
  isReadOnly
}) => {
  return (
    <div className='form-dropdown'>
      {data && data.length > 0 ? (
        <Form.Select
          id={id}
          value={selectedOption}
          onChange={setSelectedOption}
          disabled={isReadOnly}
        >
          {data.map((item) => (
            <option key={item.id} value={item.name}>
              {item.name}
            </option>
          ))}
        </Form.Select>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
};

export default DropDownIndex;
