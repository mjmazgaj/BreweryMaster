import { v4 as uuidv4 } from 'uuid';
export const data = [
  {
    id: '1',
    Task: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Praesent.',
    DueDate: '25-May-2020',
    OwnerId: '3',
    Owner: 'John Smith',
  },
  {
    id: '2',
    Task: 'Fix Styling',
    DueDate: '26-May-2020',
    OwnerId: '3',
    Owner: 'John Smith',
  },
  {
    id: '3',
    Task: 'Handle Door Specs',
    DueDate: '27-May-2020',
    OwnerId: '3',
    Owner: 'John Smith',
  },
  {
    id: '4',
    Task: 'morbi',
    DueDate: '23-Aug-2020',
    OwnerId: '3',
    Owner: 'John Smith',
  },
  {
    id: '5',
    Task: 'proin',
    DueDate: '05-Jan-2021',
    OwnerId: '3',
    Owner: 'John Smith',
  },
];

export const columnsFromBackend = {
  [uuidv4()]: {
    status: '0',
    title: 'todo',
    items: data,
  },
  [uuidv4()]: {
    status: '1',
    title: 'inProgress',
    items: [],
  },
  [uuidv4()]: {
    status: '2',
    title: 'done',
    items: [],
  },
};
