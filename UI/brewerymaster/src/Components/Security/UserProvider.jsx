import React, { createContext, useContext, useState, useEffect } from 'react';

const UserContext = createContext();

export const UserProvider = ({ children }) => {

  const [user, setUser] = useState(() => {
    const savedUser = sessionStorage.getItem('user');
    return JSON.parse(savedUser);
  });

  useEffect(() => {
    sessionStorage.setItem('user', JSON.stringify(user));
  }, [user]);

  return (
    <UserContext.Provider value={{ user, setUser }}>
      {children}
    </UserContext.Provider>
  );
};

export const useUser = () => useContext(UserContext);
