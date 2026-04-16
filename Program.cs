ProductRepository product = new ProductRepository();
UserInput userInput = new UserInput(product);

InventoryManager manager = new InventoryManager(product, userInput);

Menu menu = new Menu(manager);

menu.UserMenuChoice();
