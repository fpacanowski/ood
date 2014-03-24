using System.Text;
using System.IO;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class StateTest
{
    VendorMachine vm;
    [SetUp]
    public void setupVendorMachin() {
        vm = new VendorMachine();
    }
    [Test]
    public void OrderingCoffee() {
        vm.OrderCoffee();
        Assert.IsInstanceOfType(typeof(WaitingForMoney), vm.state);
    }
    [Test]
    public void PayForCoffee() {
        vm.OrderCoffee();
        vm.InsertCoin(100);
        Assert.IsInstanceOfType(typeof(WaitingForMoney), vm.state);
        vm.InsertCoin(50);
        Assert.IsInstanceOfType(typeof(WaitingForMoney), vm.state);
        vm.InsertCoin(50);
        Assert.IsInstanceOfType(typeof(CoffeeReady), vm.state);
    }
    [Test]
    public void WholeTransaction() {
        vm.OrderCoffee();
        vm.InsertCoin(200);
        vm.TakeCoffee();
        Assert.IsInstanceOfType(typeof(WaitingForOrder), vm.state);
    }
    [Test]
    [ExpectedException]
    public void TakeCoffeeBeforeOrdering() {
        vm.TakeCoffee();
    }
}
