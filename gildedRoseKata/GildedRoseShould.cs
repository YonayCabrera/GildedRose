using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace gildedRoseKata{
    [TestFixture]
    public class GildedRoseShould{
        private Item item;
        private List<Item> items;
        private GildedRose gildedRose;

        [SetUp]
        public void SetUp(){
            items = new List<Item>();
            gildedRose = new GildedRose(items);
        }

        private void CreateItem(string name, int sellIn, int quality){
            item = new Item(){Name = name, SellIn = sellIn, Quality = quality};
        }

        [Test]
        public void when_sell_expired_quality_degrades_twice_as_fast(){
            CreateItem(name:"chair",sellIn:-1,quality: 4);
            items.Add(item);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(2,item.Quality);
        }
        
        [Test]
        public void have_not_a_negative_quality(){
            CreateItem(name:"chair",sellIn:-1,quality: 0);
            items.Add(item);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(0,item.Quality);
        }
        
        [Test]
        public void increases_quality_item_aged_brie_when_decrement_sellin(){
            CreateItem(name:"Aged Brie", sellIn:10, quality:4);
            items.Add(item);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(5,item.Quality);
        }
        
        [Test]
        public void have_not_quality_item_more_than_50(){
            CreateItem(name:"Aged Brie", sellIn:10, quality:50);
            items.Add(item);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(50,item.Quality);
        }
    }
}
