using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriorityQueue
{
    private int[] _arguments;
    private int  _sizeOfHeap;

    public int SizeOfHeap => _sizeOfHeap;

    public PriorityQueue(int size)
    {
        _arguments = new int[size + 1];
        _sizeOfHeap = 0;
        Debug.Log("Heap created");
    }
    
    public int PeekOfHeap()  
    {
        if (_sizeOfHeap == 0)
        {
            return 0;
        }
        else
        {
            return _arguments[1];  
        }
    }

    public void EnqueueElement(int value)
    {
        _arguments[_sizeOfHeap + 1] = value;
        _sizeOfHeap++;
        HeapifyBottomToTop(_sizeOfHeap);
    }
    
    public void HeapifyBottomToTop(int index) {  
        int parent = index / 2;  
        // We are at root of the tree. Hence no more Heapifying is required.  
        if (index <= 1) {  
            return;  
        }  
        // If Current value is smaller than its parent, then we need to swap  
        if (arr[index] < arr[parent]) {  
            int tmp = arr[index];  
            arr[index] = arr[parent];  
            arr[parent] = tmp;  
        }  
        HeapifyBottomToTop(parent);  
    }
}
