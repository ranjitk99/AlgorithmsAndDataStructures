//Find the element that appears once in a sorted array where all other elements appear twice one after another. Find that element in 0(logn) complexity

class GFG { 
      
    // A Binary Search based 
    // method to find the element 
    // that appears only once 
    public static void search(int[] arr,  
                              int low,  
                              int high) 
    {           
        if(low > high) 
            return; 
        if(low == high) 
        { 
            Console.WriteLine("The required element is "
                                             +arr[low]); 
            return; 
        } 
          
        // Find the middle point 
        int mid = (low + high)/2; 
          
        // If mid is even and element 
        // next to mid is same as mid 
        // then output element lies on 
        // right side, else on left side 
        if(mid % 2 == 0) 
        { 
            if(arr[mid] == arr[mid + 1]) 
                search(arr, mid + 2, high); 
            else
                search(arr, low, mid); 
        } 
          
        // If mid is odd 
        else if(mid % 2 == 1) 
        { 
            if(arr[mid] == arr[mid - 1]) 
                search(arr, mid + 1, high); 
            else
                search(arr, low, mid - 1); 
        } 
    } 
  
    // Driver Code 
    public static void Main(String[] args)  
    { 
        int[] arr = {1, 1, 2, 4, 4, 5, 5, 6, 6}; 
        search(arr, 0, arr.Length - 1); 
    }  
} 

//Given a sorted array of n integers that has been rotated an unknown number of times, write code to find an element in the array. You may assume that the array was originally sorted in increasing order
//Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
//(i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).
//You are given a target value to search. If found in the array return its index, otherwise return -1.
//You may assume no duplicate exists in the array.
//Your algorithm's runtime complexity must be in the order of O(log n).

public class Solution {
    public int Search(int[] nums, int target) {
         if (null == nums || nums.Length == 0)
        {
            return -1;
        }

        //Entry to recursion.
        return BinarySearchInRotatedArray(0, nums.Length - 1, nums, target);
    }
    
       private static int BinarySearchInRotatedArray(int low, int high, int[] nums, int target)
    {
        //Base case for NOT FOUND. 
        if (low > high)
        {
            return -1;
        }

        int mid = low + ((high - low) / 2);

        //Base case for FOUND. 
        if (nums[mid] == target)
        {
            return mid;
        }

        //IMPORTANT: When pivoting at mid, one side (including mid) will be in sorted order.
        //So we apply the process of elimination by: 
        //finding which side is sorted and if the target is present on the sorted side.

        //Entry here means left to mid is sorted.
        if (nums[low] <= nums[mid])
        {               
            if (target >= nums[low] && target < nums[mid])
            {
                return BinarySearchInRotatedArray(low, mid - 1, nums, target);
            }
            else
            {
                return BinarySearchInRotatedArray(mid + 1, high, nums, target);
            }
        }
        //Entry here means right to mid is sorted.
        if (nums[mid] <= nums[high])
        {               
            if (target > nums[mid] && target <= nums[high])
            {
                return BinarySearchInRotatedArray(mid + 1, high, nums, target);
            }
            else
            {
                return BinarySearchInRotatedArray(low, mid - 1, nums, target);
            }
        }

        return -1;
    }
}


///Given an array that contains numbers from 1 to n-1 and exactly 1 duplicate, find that duplicate.

class GFG 
{ 
    static void printRepeating(int []arr, 
                            int size) 
    { 
        int i;  
          
        Console.Write("The repeating" +  
                       " elements are : "); 
      
        for (i = 0; i < size; i++) 
        { 
            if (arr[Math.Abs(arr[i])] >= 0) 
                arr[Math.Abs(arr[i])] = 
                    -arr[Math.Abs(arr[i])]; 
            else
                Console.Write(Math.Abs(arr[i]) + " "); 
        }          
    }  
  
    // Driver program  
    public static void Main()  
    { 
        int []arr = {1, 2, 3, 1, 3, 6, 6}; 
        int arr_size = arr.Length; 
  
        printRepeating(arr, arr_size); 
    } 
} 