using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This is a complete reconstruction of my teachers priority queue which oyu can look at in my milestone 5 repository.
public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> _items;
    private IComparer<T> _comparer;

    //comstructor
    public PriorityQueue(IComparer<T> comparer = null)
    {
        _items = new List<T>();
        if(comparer == null)
        {
            _comparer = new GenericComparer<T>();
        }
    }

    public PriorityQueue(List<T> unsorted, IComparer<T> comparer = null)
        : this(comparer)
    {
        for (int i = 0; i < unsorted.Count; i++)
        {
            _items.Add(unsorted[i]);
        }
        BuildHeap();
    }

    //Function to build the heap
    private void BuildHeap()
    {
        for (int i = _items.Count / 2; i >= 0; i--)
        {
            adjustHeap(i);
        }
    }

    //function that adjusts the heap after something is taken out
    private void adjustHeap(int index)
    {
        if(_items.Count == 0)
        {
            return;
        }

        T item = _items[index];

        int end_location = _items.Count;

        int smallest_index = index;

        while(index < end_location)
        {
            int left_child_index = (2 * index) + 1;
            int right_child_index = left_child_index + 1;

            if(left_child_index < end_location)
            {
                smallest_index = left_child_index;

                if(right_child_index < end_location)
                {
                    smallest_index = (_comparer.Compare(_items[left_child_index], _items[right_child_index]) < 0)
                        ? left_child_index
                        : right_child_index;
                }
            }

            if(_comparer.Compare(_items[index], _items[smallest_index]) > 0)
            {
                T temp = _items[index];
                _items[index] = _items[smallest_index];
                _items[smallest_index] = temp;

                index = smallest_index;
            }
            else
            {
                break;
            }
        }
    }


    //see if it is empty
    public bool IsEmpty()
    {
        return _items.Count == 0;
    }


    //get its count
    public int GetSize()
    {
        return _items.Count;
    }

    //add something to the back of the priority queue
    public void enqueue(T item)
    {
        int current_pos = _items.Count;
        int parent_pos = (current_pos - 1) / 2;

        _items.Add(item);
        T parent = default(T);
        if(parent_pos >= 0)
        {
            parent = _items[parent_pos];

            while(_comparer.Compare(parent, item) > 0 && current_pos > 0)
            {

                _items[current_pos] = parent;

                current_pos = parent_pos;
                parent_pos = (current_pos - 1) / 2;

                if (parent_pos >= 0)
                    parent = _items[parent_pos];
            }
        }
        _items[current_pos] = item;
    }

    //get first item in priority queue
    public T GetFirst()
    {
        return _items[0];
    }

    //dequeue item at the front of the priority queue
    public T Dequeue()
    {
        int last_pos = _items.Count - 1;
        T last_item = _items[last_pos];
        T top = _items[0];
        _items[0] = last_item;
        _items.RemoveAt(_items.Count - 1);

        adjustHeap(0);
        return top;
    }

    //the magic comparer that will compare things so we can bubble them up or percolate them down
    private class GenericComparer<TInner> : IComparer<TInner> where TInner : IComparable<TInner>
    {
        public int Compare(TInner x, TInner y)
        {
            return x.CompareTo(y);
        }
    }

}
