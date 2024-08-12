import React from 'react';
import ShoppingListItem from './ShoppingListItem';

//2 props, array of items and method to remove item from list
function ShoppingList({ items, removeItem }) {
  return (
    //Iterating over array, each item returns a shopping list item component.
    <ul>
      {items.map(item => (
        <ShoppingListItem key={item.id} item={item} removeItem={removeItem} />
      ))}
    </ul>
  );
}

export default ShoppingList;