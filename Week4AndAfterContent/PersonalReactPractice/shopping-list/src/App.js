import React, { useState } from 'react';
import ShoppingList from './ShoppingList';
import './App.css';

function App() {
  //State variable that holds array of items, and function to update state
  const [items, setItems] = useState([]);
  //State variable that holds value of new item, and fucntion to update state
  const [newItem, setNewItem] = useState('');

  const addItem = () => {
    //If string is not empty...
    if (newItem.trim() !== '') 
    {
      //Add item to list, using Date.now() for id
      setItems([...items, { id: Date.now(), name: newItem }]);
      //Resetting text input
      setNewItem('');
    }
  };

  const removeItem = (id) => 
  {
    //Setting array to all items that don't match the passed in id
    setItems(items.filter(item => item.id !== id));
  };

  return (
    <div className="App">
      <h1>Shopping List</h1>
      <input 
        type="text" 
        value={newItem} 
        onChange={(e) => setNewItem(e.target.value)} 
      />
      <button onClick={addItem}>Add</button>
      <ShoppingList items={items} removeItem={removeItem} />
    </div>
  );
}

export default App;