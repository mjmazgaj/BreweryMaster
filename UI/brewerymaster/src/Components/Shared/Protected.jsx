import React from 'react';
import  { Navigate } from 'react-router-dom'

const Protected = ({setData, result }) => {
  (console.log(result))
  if (result) {
    setData(result);
  console.log(result)
  }
  else return <Navigate to='/error'  />;
};

export default Protected;
