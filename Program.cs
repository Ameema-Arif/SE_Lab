using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternn
{
    public interface Item
    {
        String name();
        Packing packing();
        float price();
    }
    public interface Packing
    {
        string pack();
    }

    public class Wrapper : Packing
    {
        public String pack()
        { return "wrapper"; }
    }

    public class Box : Packing
    {
        public String pack()
        { return "box"; }
    }

    public abstract class Toys : Item
    {
        public Packing packing()
        { return new Wrapper(); }
        public abstract float price();
        public abstract String name();
    }
    public abstract class ShowPieces : Item
    {
        public Packing packing()
        { return new Box(); }
        public abstract float price();
        public abstract String name();
    }
    public abstract class HandmadeGifts : Item
    {
        public Packing packing()
        { return new Box(); }
        public abstract float price();
        public abstract String name();
    }

    public class Doll : Toys 
    {
        public override float price()
        { return 30.0f; }
        public override String name()
        { return "Doll"; }
    }
    public class Car : Toys
    {
        public override float price()
        { return 40.0f; }
        public override String name()
        { return "Car"; }
    }
    public class WoodenShip : ShowPieces
    {
        public override float price()
        { return 45.0f; }
        public override String name()
        { return "wooden ship"; }
    }
    public class CrystalBeadedPot : ShowPieces
    {
        public override float price()
        { return 60.0f; }
        public override String name()
        { return "Crystal Beaded Pot"; }
    }
    public class ExplosionBox : HandmadeGifts
    {
        public override float price()
        { return 50.0f; }
        public override String name()
        { return "Explosion Box "; }
    }
    public class Mugs : HandmadeGifts
    {
        public override float price()
        { return 25.5f; }
        public override String name()
        { return "Hand Painted Mugs"; }
    }
    public class Gift
    {
        private List<Item> items = new List<Item>();
        public void addItem(Item item)
        { items.Add(item); }

        public float getCost()
        {
            float cost = 0.0f;
            foreach (Item item in items)
            { cost += item.price(); }
            return cost;
        }
        public void showItems()
        {
            foreach (Item item in items)
            {
                System.Console.WriteLine("Item : " + item.name());
                System.Console.WriteLine("Packing : " + item.packing().pack());
                System.Console.WriteLine("Price : " + item.price());
                System.Console.ReadKey();
            }
        }
    }

    public class GiftPack
    {
        public Gift ComboPack1()
        {
            Gift gift = new Gift();
            gift.addItem(new Doll());
            gift.addItem(new CrystalBeadedPot());
            gift.addItem(new ExplosionBox());
            return gift;
        }
        public Gift ComboPack2()
        {
            Gift gift = new Gift();
            gift.addItem(new Car());
            gift.addItem(new WoodenShip());
            gift.addItem(new Mugs());
            return gift;
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            GiftPack giftpack = new GiftPack();
            Gift combo1 = giftpack.ComboPack1();
            System.Console.WriteLine("Combo Pack 1");
            Console.ReadKey();
            combo1.showItems();
            System.Console.WriteLine("Total Cost: " + combo1.getCost());
            Console.ReadKey();
            Gift combo2 = giftpack.ComboPack2();
            System.Console.WriteLine("\n\n Combo Pack 2");
            Console.ReadKey();
            combo2.showItems();
            System.Console.WriteLine("Total Cost: " + combo2.getCost());
            Console.ReadKey();
        }
    }






}


