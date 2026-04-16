var productRepo = new ProductRepository();
var inputHandler = new UserInput(productRepo);

var manager = new InventoryManager(productRepo, inputHandler);
var mainMenu = new Menu(manager);

mainMenu.UserMenuChoice();
