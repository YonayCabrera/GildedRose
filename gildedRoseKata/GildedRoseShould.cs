﻿using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace gildedRoseKata{
    [TestFixture]
    public class GildedRoseShould{
        private Item item;
        private List<Item> items;
        private GildedRose gildedRose;
        private string bactstage = "Backstage passes to a TAFKAL80ETC concert";
        private string sulfuras = "Sulfuras, Hand of Ragnaros";
        private string agedBrie = "Aged Brie";
        private string chair= "chair";

        [SetUp]
        public void SetUp(){
            items = new List<Item>();
            gildedRose = new GildedRose(items);

        }


        [Test]
        public void when_sell_expired_quality_degrades_twice_as_fast(){
            CreateItem(name:chair,sellIn:-1,quality: 4);
            items.Add(item);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(2,item.Quality);
        }
        
        [Test]
        public void have_not_a_negative_quality(){
            CreateItem(name:chair,sellIn:-1,quality: 0);
            items.Add(item);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(0,item.Quality);
        }
        
        [Test]
        public void increases_quality_item_aged_brie_when_decrement_sellin(){
            CreateItem(name:agedBrie, sellIn:10, quality:4);
            items.Add(item);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(5,item.Quality);
        }
        
        [Test]
        public void have_not_quality_item_more_than_50(){
            CreateItem(name:agedBrie, sellIn:10, quality:50);
            items.Add(item);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(50,item.Quality);
        }
        
        [Test]
        public void have_not_drecreases_in_quality_item_sulfuras(){
            CreateItem(name:sulfuras, sellIn:10, quality:80);
            items.Add(item);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(80,item.Quality);
        }
        
        [Test]
        public void have_to_increment_by_2_quality_item_Backstage_when_sellIn_is_10_days_or_less(){
            CreateItem(name:bactstage, sellIn:10, quality:40);
            items.Add(item);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(42,item.Quality);
        }
        
        [Test]
        public void have_to_increment_by_3_quality_item_Backstage_when_sellIn_is_5_days_or_less(){
            CreateItem(name:bactstage, sellIn:5, quality:40);
            items.Add(item);
            
            gildedRose.UpdateQuality();
            
            Assert.AreEqual(43,item.Quality);
        }
        
        
        private void CreateItem(string name, int sellIn, int quality){
            item = new Item(){Name = name, SellIn = sellIn, Quality = quality};
        }
    }
}
