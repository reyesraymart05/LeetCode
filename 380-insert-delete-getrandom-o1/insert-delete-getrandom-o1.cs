using System;
using System.Collections.Generic;

public class RandomizedSet {
    private Dictionary<int, int> dict;
    private List<int> list;
    private Random rand;    

     public RandomizedSet() {
        dict = new Dictionary<int, int>();
        list = new List<int>();
        rand = new Random();
    }

    public bool Insert(int val) {
        if (dict.ContainsKey(val)) return false;

        list.Add(val);
        dict[val] = list.Count - 1;
        return true;
    }

    public bool Remove(int val) {
        if (!dict.ContainsKey(val)) return false;

        int indexToRemove = dict[val];
        int lastElement = list[list.Count - 1];

        // Swap the element to remove with the last element
        list[indexToRemove] = lastElement;
        dict[lastElement] = indexToRemove;

        // Remove last element
        list.RemoveAt(list.Count - 1);
        dict.Remove(val);

        return true;
    }

    public int GetRandom() {
        int index = rand.Next(list.Count);
        return list[index];
    }
}

/**
 * Your RandomizedSet object will be instantiated and called as such:
 * RandomizedSet obj = new RandomizedSet();
 * bool param_1 = obj.Insert(val);
 * bool param_2 = obj.Remove(val);
 * int param_3 = obj.GetRandom();
 */