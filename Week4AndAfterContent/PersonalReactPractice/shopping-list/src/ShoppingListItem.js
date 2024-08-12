import React from 'react';

//2 props, item object and method to remove item from list
function ShoppingListItem({ item, removeItem }) {
  return (
    //Each item will have its name, then a remove button
    <li>
      {item.name}
      <button onClick={() => removeItem(item.id)}>Remove</button>
    </li>
  );
}

export default ShoppingListItem;