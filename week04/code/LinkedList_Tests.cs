using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

[TestClass]
public class LinkedList_Tests
{
    [TestMethod]
    public void InsertTail_AddsElementsToEnd()
    {
        var list = new LinkedList();
        list.InsertTail(10);
        list.InsertTail(20);
        list.InsertTail(30);

        var expected = new List<int> { 10, 20, 30 };
        CollectionAssert.AreEqual(expected, list.ToList());
    }

    [TestMethod]
    public void RemoveTail_RemovesLastElement()
    {
        var list = new LinkedList();
        list.InsertTail(1);
        list.InsertTail(2);
        list.InsertTail(3);
        list.RemoveTail();

        var expected = new List<int> { 1, 2 };
        CollectionAssert.AreEqual(expected, list.ToList());
    }

    [TestMethod]
    public void Remove_RemovesFirstOccurrence()
    {
        var list = new LinkedList();
        list.InsertTail(5);
        list.InsertTail(10);
        list.InsertTail(5);
        list.Remove(5);

        var expected = new List<int> { 10, 5 };
        CollectionAssert.AreEqual(expected, list.ToList());
    }

    [TestMethod]
    public void Replace_ReplacesAllOccurrences()
    {
        var list = new LinkedList();
        list.InsertTail(1);
        list.InsertTail(2);
        list.InsertTail(1);
        list.InsertTail(3);
        list.Replace(1, 9);

        var expected = new List<int> { 9, 2, 9, 3 };
        CollectionAssert.AreEqual(expected, list.ToList());
    }

    [TestMethod]
    public void Reverse_ReturnsItemsInReverseOrder()
    {
        var list = new LinkedList();
        list.InsertTail(1);
        list.InsertTail(2);
        list.InsertTail(3);

        var reversed = list.Reverse().Cast<int>().ToList();
        var expected = new List<int> { 3, 2, 1 };

        CollectionAssert.AreEqual(expected, reversed);
    }

    [TestMethod]
    public void RemoveTail_SingleElement_ListBecomesEmpty()
    {
        var list = new LinkedList();
        list.InsertTail(7);
        list.RemoveTail();

        Assert.IsTrue(list.HeadAndTailAreNull());
    }

    [TestMethod]
    public void RemoveTail_TwoElements_RemovesLastCorrectly()
    {
        var list = new LinkedList();
        list.InsertTail(4);
        list.InsertTail(5);
        list.RemoveTail();

        var expected = new List<int> { 4 };
        CollectionAssert.AreEqual(expected, list.ToList());
    }
}
