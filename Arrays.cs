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
//O(n). Modification of the array is allowed and  O(1) extra space
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


/////Given an array that contains numbers from 1 to n-1 and exactly 1 duplicate, find that duplicate.
// Should be less than O(n^2). Modification of the array is *NOT* allowed
/*
Note:
Input: [1,3,4,2,2]
Output: 2
You must not modify the array (assume the array is read only).
You must use only constant, O(1) extra space.
Your runtime complexity should be less than O(n^2).
There is only one duplicate number in the array, but it could be repeated more than once.
 */
public int findDuplicate(int[] nums) {
        
        if (nums.Length > 1)
	    {
		int slow = nums[0];
		int fast = nums[nums[0]];
		while (slow != fast)
		{
			slow = nums[slow];
			fast = nums[nums[fast]];
		}

		fast = 0;
		while (fast != slow)
		{
			fast = nums[fast];
			slow = nums[slow];
		}
		return slow;
	    }
	        return -1;
    }


////5. Search an element in an array where difference between adjacent elements is 1.
///For example: arr[] = {8, 7, 6, 7, 6, 5, 4, 3, 2, 3, 4, 3}
//Search for 3 and Output: Found at index 7
public class GFG  
{ 
      
    // in arr[0..n-1] 
    static int search(int []arr, int n, 
                      int x) 
    { 
          
        // Travers the given array starting  
        // from leftmost element 
        int i = 0; 
        while (i < n) 
        { 
              
            // If x is found at index i 
            if (arr[i] == x) 
                return i; 
      
            // Jump the difference between  
            // current array element and x 
            i = i + Math.Abs(arr[i] - x); 
        } 
      
        Console.WriteLine ("number is not" + 
                           " present!"); 
  
        return -1; 
    } 
  
    // Driver code 
    public static void Main()  
    { 
          
        int []arr = {8 ,7, 6, 7, 6, 5, 
                     4,3, 2, 3, 4, 3 }; 
        int n = arr.Length; 
        int x = 3; 
        Console.WriteLine("Element " + x +  
                        " is present at index "
                        + search(arr, n, 3)); 
    } 
} 

//Given an array of numbers, split the array into two where one array contains the sum of n-1 numbers 
//and the other array with all the n-1 elements
//// C# program to split an array  
// into Two equal sum subarrays 
//Time Complexity : O(n)
//Auxiliary Space : O(1)

class GFG { 
   
    // Returns split point. If not possible, then 
    // return -1. 
    static int findSplitPoint(int []arr, int n) 
    { 
       
    // traverse array element and compute sum 
    // of whole array 
    int leftSum = 0; 
       
    for (int i = 0 ; i < n ; i++) 
        leftSum += arr[i]; 
   
    // again traverse array and compute right  
    // sum and also check left_sum equal to  
    // right sum or not 
    int rightSum = 0; 
       
    for (int i = n-1; i >= 0; i--) 
    { 
        // add current element to right_sum 
        rightSum += arr[i]; 
   
        // exclude current element to the left_sum 
        leftSum -= arr[i] ; 
   
        if (rightSum == leftSum) 
            return i ; 
    } 
   
    // if it is not possible to split array 
    // into two parts. 
    return -1; 
    } 
   
    // Prints two parts after finding split  
    // point using findSplitPoint() 
    static void printTwoParts(int []arr, int n) 
    { 
        int splitPoint = findSplitPoint(arr, n); 
       
        if (splitPoint == -1 || splitPoint == n ) 
        { 
            Console.Write("Not Possible" ); 
            return; 
        } 
        for (int i = 0; i < n; i++) 
        { 
            if(splitPoint == i) 
                 Console.WriteLine(); 
                   
             Console.Write(arr[i] + " "); 
        } 
    } 
   
    // Driver program 
    public static void Main (String[] args) { 
       
    int []arr = {1 , 2 , 3 , 4 , 5 , 5 }; 
    int n = arr.Length; 
       
    printTwoParts(arr, n); 
           
    } 
} 

//Given a sorted array consisting of only integers where every element appears twice except for one element which appears once. 
//Find this single element that appears only once
//Input: [1,1,2,3,3,4,4,8,8]
//Output: 2
// O(log n) time complexity
public class Solution {
    public int singleNonDuplicate(int[] nums) {
        //Length of the array would be odd or else the constraint fails
        int n = nums.length;
        if (n == 1) return nums[1];
        
        for (int i=0,j=1;i<n-1;i+=2){
            if (nums[i]!=nums[j]){
                return nums[i];
            }
            j+=2;
        }
        return nums[n-1];
        
    }
}
/*
Given an array nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position. Return the max sliding window.
Example:
Input: nums = [1,3,-1,-3,5,3,6,7], and k = 3
Output: [3,3,5,5,6,7] 
Explanation: 
 */
 public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
       int j, max; 
        List<int> result = new List<int>();
        if(nums.Length==0)
        {
           return new int[]{};
        }
		for (int i = 0; i <= nums.Length - k; i++) { 
			
			max = nums[i]; 

			for (j = 1; j < k; j++) 
			{ 
				if (nums[i + j] > max) 
					max = nums[i + j]; 
			} 
			result.Add(max);
		} 
        
        return result.ToArray();
    }
}

/*
Given an array of size n and an integer k, return the of count of distinct numbers in all windows of size k.
Example:

Input:  arr[] = {1, 2, 1, 3, 4, 2, 3};
            k = 4
Output:
3
4
4
3

Time complexity of the above solution is O(n).
 */

  class Program
    {
        static void countDistinct(int[] arr, int k)
        {
            // Creates an empty hashMap hM 
            Dictionary<int,int> hM =
                          new Dictionary<int,int>();

            // initialize distinct element  count for 
            // current window 
            int dist_count = 0;

            // Traverse the first window and store count 
            // of every element in hash map 
            for (int i = 0; i < k; i++)
            {
                if (!hM.ContainsKey(arr[i]))
                {
                    hM.Add(arr[i], 1);
                    dist_count++;
                }
                else
                {
                    int count = hM[arr[i]];
                    hM[arr[i]]= count + 1;
                }
            }

            // Print count of first window 
           Console.WriteLine(dist_count);

            // Traverse through the remaining array 
            for (int i = k; i < arr.Length; i++)
            {

                // Remove first element of previous window 
                // If there was only one occurrence, then 
                // reduce distinct count. 
                if (hM[arr[i - k]] == 1)
                {
                    hM.Remove(arr[i - k]);
                    dist_count--;
                }
                else // reduce count of the removed element 
                {
                    int count = hM[arr[i - k]];
                    hM[arr[i - k]]= count - 1;
                }

                // Add new element of current window 
                // If this element appears first time, 
                // increment distinct element count 
                if (!hM.ContainsKey(arr[i]))
                {
                    hM.Add(arr[i], 1);
                    dist_count++;
                }
                else // Increment distinct element count 
                {
                    int count = hM[arr[i]];
                    hM[arr[i]]=count + 1;
                }

                // Print count of current window 
                Console.WriteLine(dist_count);
                
            }
            Console.ReadKey();
        }

    }
