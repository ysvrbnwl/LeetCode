public class Solution
{
    TreeNode answer = null;

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        DFS(root,p,q);
        return answer;
    }


    public int DFS(TreeNode root,TreeNode p, TreeNode q){
        int count = 0;
        if(root != null){
            if(root.val == p.val || root.val == q.val){
                count++;
            }             

            if(count<2){
                count += DFS(root.left,p,q);
                count += DFS(root.right,p,q);  
            }

            if(count == 2){
                count++;
                answer = root;
            }                        
        }
        return count;
    }

    public TreeNode LowestCommonAncestor2(TreeNode root, TreeNode p, TreeNode q)
    {
        var pChain = findNode(root, p);
        var qChain = findNode(root, q);

        TreeNode parent = new TreeNode(0);
        int count = pChain.Count >= qChain.Count ? qChain.Count : pChain.Count;
        for (int i = 0; i < count; i++){
            if (pChain[i].val == qChain[i].val)
            {
                parent = pChain[i];
            }
            else
            {
                break;
            }
        }
        return parent;
    }
    public List<TreeNode> findNode(TreeNode root, TreeNode node)
    {
        if (root == null)
        {
            return new List<TreeNode>();
        }
        if (root.val == node.val)
        {
            return new List<TreeNode>() { root };
        }

        var leftTail = findNode(root.left, node);
        var rightTail = findNode(root.right, node);

        List<TreeNode> list = new List<TreeNode>() { root };

        if (leftTail.Count == rightTail.Count)
        {
            return new List<TreeNode>();
        }

        if (leftTail.Count > rightTail.Count())
        {
            list.AddRange(leftTail);
        }
        else
        {
            list.AddRange(rightTail);
        }
        return list;
    }
}
