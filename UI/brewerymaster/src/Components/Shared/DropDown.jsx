import {React} from 'react';
import { Form } from 'react-bootstrap';

const DropDown = ({
  id,
  data,
  selectedOption,
  setSelectedOption
}) => {
  return (
    <div className='form-dropdown'>
      {data && data.length > 0 ? (
        <Form.Select
          id={id}
          value={selectedOption}
          onChange={(e) => setSelectedOption(e.target.value)}
        >
          {data.map((item, index) => (
            <option key={index} value={item}>
              {item}
            </option>
          ))}
        </Form.Select>
      ) : (
        <p>Loading...</p>
      )}
    </div>
  );
};

export default DropDown;
