using MONGOLABB3.UI;
using MONGOLABB3.DAO;
using MongoDB.Bson;
using MongoDB.Driver;
using MONGOLABB3;

IUI io;
IProduct productDAO;
io = new TextIO();
productDAO = new Database("BassesFiskeShop", "mongodb+srv://Cyrcut:Twenty1Passwords@cluster0.fmqr5tm.mongodb.net/test");
FishingProductController pController = new FishingProductController(io, productDAO);
pController.start();
    