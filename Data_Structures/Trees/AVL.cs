    namespace AVL
    {
        class TreeNode<T> where T : IComparable<T>
        {
            public TreeNode<T> left { get; internal set; }
            public TreeNode<T> right { get; internal set; }

            public int Height { get; internal set; }

            public T val { get; internal set; }

            public TreeNode(T val = default, TreeNode<T> left = null, TreeNode<T> right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
                Height = 1;
            }
        }

        class AVL<T> where T : IComparable<T>
        {
            private TreeNode<T> root = null;
            public void Insert(T val)
            {
                root = InsertHelper(root, val);
            }
            private TreeNode<T> InsertHelper(TreeNode<T> root, T val)
            {
                if (root == null) return new TreeNode<T>(val);
                if (root.val.CompareTo(val) > 0)
                    root.left = InsertHelper(root.left, val);
                else
                    root.right = InsertHelper(root.right, val);

                UpdateHeight(root);
                int bf = GetBalance(root);
                if (bf > 1 && root.left.val.CompareTo(val) > 0)
                    return RightRotate(root);
                if (bf > 1 && root.left.val.CompareTo(val) < 0)
                {
                    root.left = LeftRotate(root.left);
                    return RightRotate(root);
                }

                if (bf < -1 && root.right.val.CompareTo(val) < 0)
                    return LeftRotate(root);
                if (bf < -1 && root.right.val.CompareTo(val) > 0)
                {
                    root.right = RightRotate(root.right);
                    return LeftRotate(root);
                }
                return root;

            }

            private TreeNode<T> RightRotate(TreeNode<T> root)
            {
                var newRoot = root.left;
                TreeNode<T> T3 = newRoot.right;
                newRoot.right = root;
                root.left = T3;

                UpdateHeight(root);
                UpdateHeight(newRoot);
                return newRoot;
            }

            private TreeNode<T> LeftRotate(TreeNode<T> root)
            {
                var newRoot = root.right;
                var T3 = newRoot.left;

                newRoot.left = root;
                root.right = T3;

                UpdateHeight(root);
                UpdateHeight(newRoot);
                return newRoot;
            }

            public bool Contains(T val)
            {
                return ContainsHelper(root, val);
            }

            private bool ContainsHelper(TreeNode<T> root, T val)
            {
                if (root == null) return false;
                if (root.val.CompareTo(val) > 0)
                    return ContainsHelper(root.left, val);
                else if (root.val.CompareTo(val) < 0)
                    return ContainsHelper(root.right, val);
                else
                    return true;
            }
            private int GetBalance(TreeNode<T> root)
            {
                return root == null ? 0 : GetHeight(root.left) - GetHeight(root.right);
            }
            private int GetHeight(TreeNode<T> root)
            {
                return root == null ? 0 : root.Height;
            }

            private void UpdateHeight(TreeNode<T> root)
            {
                root.Height = Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
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
                if (root == null) return;
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
                if (root.val.CompareTo(val) > 0)
                    root.left = RemoveHelper(root.left, val);
                else if (root.val.CompareTo(val) < 0)
                    root.right = RemoveHelper(root.right, val);
                else
                {
                    if (root.left == null)
                        return root.right;
                    if (root.right == null)
                        return root.left;
                    var temp = GetMin(root.right);
                    root.val = temp.val;
                    root.right = RemoveHelper(root.right, temp.val);
                }
                UpdateHeight(root);
                int bf = GetBalance(root);
                if (bf > 1 && GetBalance(root.left) >= 0)
                    return RightRotate(root);
                if (bf > 1 && GetBalance(root.left) < 0)
                {
                    root.left = LeftRotate(root.left);
                    return RightRotate(root);
                }

                if (bf < -1 && GetBalance(root.right) < 0)
                    return LeftRotate(root);
                if (bf < -1 && GetBalance(root.right) >= 0)
                {
                    root.right = RightRotate(root.right);
                    return LeftRotate(root);
                }
                return root;
            }

            private TreeNode<T> GetMin(TreeNode<T> root)
            {
                while (root.left != null)
                    root = root.left;
                return root;
            }
        }

    
    }
