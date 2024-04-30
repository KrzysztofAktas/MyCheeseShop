namespace MyCheeseShop.Model
{
    public class ShoppingCart
    {
        public event Action? OnCartUpdated;
        private List<CartItem> _items;

        public ShoppingCart()
        {
            _items = [];
        }

        public void AddItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item == null)
            {
                _items.Add(new CartItem { Cheese = cheese, Quantity = quantity });
            }
            else
                item.Quantity += quantity;

            OnCartUpdated?.Invoke();
        }
        public IEnumerable<CartItem> GetItems()
        {
            return _items;
        }

        public int Count()
        {
            // return the number of items in the cart
            return _items.Count;
        }
        public void RemoveItem(Cheese cheese)
        {
            // remove the cheese from the cart
            _items.RemoveAll(item => item.Cheese.Id == cheese.Id);
            OnCartUpdated?.Invoke();
        }

        public void RemoveItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item is not null)
            {
                item.Quantity -= quantity;
                if (item.Quantity <= 0)
                    _items.Remove(item);
            }
            OnCartUpdated?.Invoke();
        }
        public decimal Total()
        {
            // sum the price of all items in the cart
            return _items.Sum(item => item.Cheese.Price * item.Quantity);
        }

        public int GetQuantity(Cheese cheese)
        {
            // return the quantity of the cheese in the cart
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            return item?.Quantity ?? 0;
        }
        public void SetItems(IEnumerable<CartItem> items)
        {
            // set the items in the cart
            _items = items.ToList();
            OnCartUpdated?.Invoke();
        }

        public void Clear()
        {
            // remove all items from the cart
            _items.Clear();
            OnCartUpdated?.Invoke();
        }
    }
}
