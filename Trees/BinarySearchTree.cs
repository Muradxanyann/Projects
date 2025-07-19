namespace BinarySearchTree
{
    class TreeNode<T> where T : IComparable<T>
    {
        public T val { get; internal set; }
        public TreeNode<T> left { get; set; }
        public TreeNode<T> right { get; set; }

        public TreeNode(T val = default, TreeNode<T> left = null, TreeNode<T> right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    class BinarySearchTree<T> where T : IComparable<T>
    {
        public TreeNode<T> root { get; private set; } = null;
        public BinarySearchTree(TreeNode<T> node = default)
        {
            root = node;
        }

        public bool Contains(T val)
        {
            return ContainsHelper(root, val);
        }
        private bool ContainsHelper(TreeNode<T> root, T val)
        {
            if (root == null) return false;
            if (val.Equals(root.val)) return true;
            if (val.CompareTo(root.val) > 0)
                return ContainsHelper(root.right, val);
            if (val.CompareTo(root.val) < 0)
                return ContainsHelper(root.left, val);
            return false;
        }

        public void Insert(T val)
        {
            root = InsertHelper(root, val);
        }

        private TreeNode<T> InsertHelper(TreeNode<T> root, T val)
        {
            if (root == null) return new TreeNode<T>(val);
            if (val.CompareTo(root.val) < 0)
                root.left = InsertHelper(root.left, val);
            else
                root.right = InsertHelper(root.right, val);
            return root;
        }


        public void Print()
        {
            Console.WriteLine("Choose the way to print");
            Console.Write("1 - PreOrder || 2 - InOrder || 3 - PostOrder || 4 - LevelOrder");
            Console.WriteLine();
            int result = 0;
            int.TryParse(Console.ReadLine(), out result);
            switch (result)
            {
                case 1:
                    PrintPreTraversalHelper(root);
                    break;
                case 2:
                    PrintInTraversalHelper(root);
                    break;
                case 3:
                    PrintPostTraversalHelper(root);
                    break;
                case 4:
                    PrintLevelOrderTraversal(root);
                    break;
            }
        }
        private void PrintPreTraversalHelper(TreeNode<T> root)
        {
            if (root == null) return;
            Console.WriteLine(root.val);
            PrintPreTraversalHelper(root.left);
            PrintPreTraversalHelper(root.right);
        }
        private void PrintInTraversalHelper(TreeNode<T> root)
        {
            if (root == null) return;
            PrintInTraversalHelper(root.left);
            Console.WriteLine(root.val);
            PrintInTraversalHelper(root.right);
        }
        private void PrintPostTraversalHelper(TreeNode<T> root)
        {
            if (root == null) return;
            PrintPostTraversalHelper(root.left);
            PrintPostTraversalHelper(root.right);
            Console.WriteLine(root.val);
        }
        private static void PrintLevelOrderTraversal(TreeNode<T> root)
        {
            Queue<TreeNode<T>> tree = new();
            tree.Enqueue(root);
            while (tree.Count > 0)
            {
                var node = tree.Dequeue();
                Console.WriteLine(node.val);
                if (node.left != null)
                    tree.Enqueue(node.left);
                if (node.right != null)
                    tree.Enqueue(node.right);
            }
        }

        public void Remove(T val)
        {
            root = RemoveHelper(root, val);
        }

        private TreeNode<T> RemoveHelper(TreeNode<T> root, T val)
        {
            if (root == null) return null;
            if (val.CompareTo(root.val) < 0)
                root.left = RemoveHelper(root.left, val);
            else if (val.CompareTo(root.val) > 0)
                root.right = RemoveHelper(root.right, val);
            else
            {
                if (root.left == null)
                    return root.right;

                if (root.right == null)
                    return root.left;

                var min = GetMin(root.right);
                root.val = min.val;
                root.right = RemoveHelper(root.right, min.val);
            }
            return root;
        }
        private static TreeNode<T> GetMin(TreeNode<T> root)
        {
            while (root.left != null)
            {
                root = root.left;
            }

            return root;
        }
        private static TreeNode<T> GetMax(TreeNode<T> root)
        {
            while (root.right != null)
                root = root.right;
            return root;
        }
    }

}
