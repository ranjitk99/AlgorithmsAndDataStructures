//7. Find missing parenthesis in a given expression – 2 * ( 3 + 5(sasdfasdfasd)
static string isBalanced(string s)
        {
            Stack<char> stk = new Stack<char>();
            try
            {
                foreach (char c in s)
                {
                    if (c == ')')
                        if (stk.Peek() == '(')
                        {
                            stk.Pop();
                            continue;
                        }
                        else
                            return "NO";

                    if (c == ']')
                        if (stk.Peek() == '[')
                        {
                            stk.Pop();
                            continue;
                        }
                        else
                            return "NO";

                    if (c == '}')
                        if (stk.Peek() == '{')
                        {
                            stk.Pop();
                            continue;
                        }
                        else
                            return "NO";

                    stk.Push(c);
                }
            }
            catch
            {
                return "NO";
            }

            if (stk.Count != 0)
                return "NO";

            return "YES";
        }


/*
Evaluate an expression given only single digits and only 2 operators * and +.
2*3+1
2+3*1
hints
using stack
save value to stack structure
if is multiple sign, pop out element multiply next element
save the value into stack
add up all the value in the stack

String.prototype.evaluate = function() {
  // initialize variables
  var stack  = [];
  var sum = 0;

  // core code
  for (var i = 0; i < this.length; i++) {

    if (parseInt(this.charAt(i))) {
      stack.push(parseInt(this.charAt(i)));
    }

    if (this.charAt(i) === '*') {
      stack.push(stack.pop() * this.charAt(i + 1));
      i = i + 1;
    }
  }

  while (stack.length) {
    sum += stack.pop();
  }
  return sum;
};

'2*3+4'.evaluate();

 */


 /*

 Reverse a stack and put the reversed value back in the same stack. You can use only one other stack and a temp variable.
 
 o(2n)

 plan is to pop all values and store it in a List

 and then push all the values to stack while looping the list from the end

  */
//----------------------------------------------------------------------------------------------------------------------------
  /*
  Implement QUEUE using Stacks
  
   */

   public class MyQueue {

    // Push element x to the back of queue.
Stack input = new Stack();
Stack output = new Stack();
public void Push(int x) {
    input.Push(x);
}

// Removes the element from front of queue.
public int Pop() {
    Peek();
    return Convert.ToInt32(output.Pop());
}

// Get the front element.
public int Peek() {
    if(output.Count==0){
        while(input.Count!=0){
            output.Push(input.Pop());
        }
    }
    return Convert.ToInt32(output.Peek());
}

// Return whether the queue is empty.
public bool Empty() {
    if(input.Count==0&&output.Count==0)return true;
    else return false;
}
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */