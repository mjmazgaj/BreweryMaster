import React from 'react';
import { Button } from 'react-bootstrap';
import { useNavigate } from 'react-router-dom';

function NavigateButton({path, name, variant}) {
  const navigate = useNavigate();

  const handleNavigate = () => {
    navigate(path);
  };

  return (
    <Button variant={variant} onClick={handleNavigate}>
      {name}
    </Button>
  );
}

export default NavigateButton;
