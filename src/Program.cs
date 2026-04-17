using InventoryManagement.Data;
using InventoryManagement.Helper;
using InventoryManagement.Interfaces;
using InventoryManagement.Services;

IProductRepository repo = new JsonProductRepository();
var input = new UserInput();
var manager = new InventoryManager(repo, input);
var mainMenu = new Menu(manager);

mainMenu.UserMenuChoice();
