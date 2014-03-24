using System;
using System.Collections.Generic;

public abstract class State {
    protected VendorMachine vendorMachine;
    protected int coffeeCost = 200;
    protected int insertedMoney = 0;
    public virtual void OrderCoffee() {
        throw new Exception("Operation invalid in current state");
    }
    public virtual void InsertCoin(int amount) {
        throw new Exception("Operation invalid in current state");
    }
    public virtual void TakeCoffee() {
        throw new Exception("Operation invalid in current state");
    }
}

public class VendorMachine {
    public State state;
    public VendorMachine() {
        state = new WaitingForOrder(this);
    }
    public void OrderCoffee() {
        state.OrderCoffee();
    }
    public void InsertCoin(int amount) {
        state.InsertCoin(amount);
    }
    public void TakeCoffee() {
        state.TakeCoffee();
    }
}

public class WaitingForOrder : State {
    public WaitingForOrder(VendorMachine vm){
        vendorMachine = vm;
    }
    public override void OrderCoffee() {
        vendorMachine.state = new WaitingForMoney(vendorMachine);
    }
}

public class WaitingForMoney : State {
    public WaitingForMoney(VendorMachine vm){
        vendorMachine = vm;
    }
    public override void InsertCoin(int amount) {
        insertedMoney += amount;
        if(insertedMoney >= coffeeCost)
            vendorMachine.state = new CoffeeReady(vendorMachine);
    }
}


public class CoffeeReady : State {
    public CoffeeReady(VendorMachine vm){
        vendorMachine = vm;
    }
    public override void TakeCoffee() {
        vendorMachine.state = new WaitingForOrder(vendorMachine);
    }
}
