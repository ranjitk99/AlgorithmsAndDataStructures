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
class main { 
  
    // Searches an element key in a 
    // pivoted sorted array arrp[] 
    // of size n 
    static int pivotedBinarySearch(int[] arr, 
                                int n, int key) 
    { 
        int pivot = findPivot(arr, 0, n - 1); 
  
        // If we didn't find a pivot, then 
        // array is not rotated at all 
        if (pivot == -1) 
            return binarySearch(arr, 0, n - 1, key); 
  
        // If we found a pivot, then first 
        // compare with pivot and then 
        // search in two subarrays around pivot 
        if (arr[pivot] == key) 
            return pivot; 
  
        if (arr[0] <= key) 
            return binarySearch(arr, 0, pivot - 1, key); 
  
        return binarySearch(arr, pivot + 1, n - 1, key); 
    } 
  
    /* Function to get pivot. For array  
    3, 4, 5, 6, 1, 2 it returns 
    3 (index of 6) */
    static int findPivot(int[] arr, int low, int high) 
    { 
        // base cases 
        if (high < low) 
            return -1; 
        if (high == low) 
            return low; 
  
        /* low + (high - low)/2; */
        int mid = (low + high) / 2; 
  
        if (mid < high && arr[mid] > arr[mid + 1]) 
            return mid; 
  
        if (mid > low && arr[mid] < arr[mid - 1]) 
            return (mid - 1); 
  
        if (arr[low] >= arr[mid]) 
            return findPivot(arr, low, mid - 1); 
  
        return findPivot(arr, mid + 1, high); 
    } 
  
    /* Standard Binary Search function */
    static int binarySearch(int[] arr, int low, 
                            int high, int key) 
    { 
        if (high < low) 
            return -1; 
  
        /* low + (high - low)/2; */
        int mid = (low + high) / 2; 
  
        if (key == arr[mid]) 
            return mid; 
        if (key > arr[mid]) 
            return binarySearch(arr, (mid + 1), high, key); 
  
        return binarySearch(arr, low, (mid - 1), key); 
    } 
  
    // Driver Code 
    public static void Main() 
    { 
        // Let us search 3 in below array 
        int[] arr1 = { 5, 6, 7, 8, 9, 10, 1, 2, 3 }; 
        int n = arr1.Length; 
        int key = 3; 
        Console.Write("Index of the element is : "
                    + pivotedBinarySearch(arr1, n, key)); 
    } 
} 
