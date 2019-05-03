using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeClassLibrary
{
    public class Solution
    {
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public int RangeSumBST(TreeNode root, int L, int R)
        {
            int result = 0;
            if (root.left != null && root.val >= L)
                result += RangeSumBST(root.left, L, R);
            if (root.right != null && root.val <= R)
                result += RangeSumBST(root.right, L, R);
            if (root.val >= L && root.val <= R)
                result += root.val;
            return result;
        }
    }
}
