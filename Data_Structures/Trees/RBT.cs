using System.IO.Compression;
using RBT;
namespace RBT
{
    enum color { Red, Black }

    class RBNode<T> where T : IComparable<T>
    {
        public T val { get; internal set; }
        public RBNode<T> left { get; internal set; }
        public RBNode<T> right { get; internal set; }
        public RBNode<T> parent { get; internal set; }

        public color color { get; internal set; }

        public RBNode(T val)
        {
            this.val = val;
            this.color = color.Red;
        }
    }

    class Rbt<T> where T : IComparable<T>
    {
        private RBNode<T> root;
        private readonly RBNode<T> NIL;

        public Rbt()
        {
            NIL = new RBNode<T>(default)
            {
                color = color.Black,
                left = null,
                right = null,
                parent = null
            };
            root = NIL;
            root.parent = NIL;
        }

        private void Rotateleft(RBNode<T> x)
        {
            var newRoot = x.right;
            x.right = newRoot.left;
            if (newRoot.left != NIL)
                newRoot.left.parent = x;
            newRoot.parent = x.parent;
            if (x.parent == NIL)
                root = newRoot;
            else if (x == x.parent.left)
                x.parent.left = newRoot;
            else
                x.parent.right = newRoot;
            newRoot.left = x;
            x.parent = newRoot;
        }

        private void Rotateright(RBNode<T> y)
        {
            var newRoot = y.left;
            y.left = newRoot.right;
            if (newRoot.right != NIL)
                newRoot.right.parent = y;
            newRoot.parent = y.parent;
            if (y.parent == NIL)
                root = newRoot;
            else if (y == y.parent.right)
                y.parent.right = newRoot;
            else
                y.parent.left = newRoot;
            newRoot.right = y;
            y.parent = newRoot;
        }

        public void Insert(T val)
        {
            RBNode<T> z = new RBNode<T>(val)
            {
                left = NIL,
                right = NIL,
                parent = NIL
            };
            RBNode<T> x = root;
            RBNode<T> y = NIL;
            while (x != NIL)
            {
                y = x;
                if (x.val.CompareTo(val) < 0)
                    x = x.right;
                else
                    x = x.left;
            }
            z.parent = y;
            if (y == NIL)
                root = z;
            else if (y.val.CompareTo(val) < 0)
                y.right = z;
            else
                y.left = z;

            z.left = NIL;
            z.right = NIL;
            z.color = color.Red;
            InsertFixUp(z);
        }
        private void InsertFixUp(RBNode<T> node)
        {
            while (node.parent.color == color.Red)
            {
                if (node.parent == node.parent.parent.left)
                {
                    var uncle = node.parent.parent.right;
                    if (uncle.color == color.Red)
                    {
                        //Case 1
                        node.parent.color = color.Black;
                        uncle.color = color.Black;
                        node.parent.parent.color = color.Red;
                    }
                    else
                    {
                        // Case 2 
                        if (node == node.parent.right)
                        {
                            node = node.parent;
                            Rotateleft(node);
                        }
                        // Case 3
                        node.parent.color = color.Black;
                        node.parent.parent.color = color.Red;
                        Rotateright(node.parent.parent);
                    }
                }
                else
                {
                    var uncle = node.parent.parent.left;
                    if (uncle.color == color.Red)
                    {
                        //Case 1
                        node.parent.color = color.Black;
                        uncle.color = color.Black;
                        node.parent.parent.color = color.Red;
                    }
                    else
                    {
                        if (node == node.parent.left)
                        {
                            node = node.parent;
                            Rotateright(node);
                        }
                        node.parent.color = color.Black;
                        node.parent.parent.color = color.Red;
                        Rotateleft(node.parent.parent);
                    }
                }
                node = node.parent.parent;
            }
            root.color = color.Black;
        }
        public void Print()
        {
            PrintHelper(root);
        }
        public void PrintHelper(RBNode<T> root)
        {
            if (root == NIL) return;
            PrintHelper(root.left);
            Console.WriteLine($"{root.val} - ({root.color})");
            PrintHelper(root.right);
        }
        private RBNode<T> Minimum(RBNode<T> node)
        {
            while (node.left != NIL)
            {
                node = node.left;
            }
            return node;
        }
        public RBNode<T> Search(RBNode<T> node)
        {
            return SearchHelper(root, node);
        }

        private RBNode<T> SearchHelper(RBNode<T> root, RBNode<T> node)
        {
            if (node == NIL) return NIL;
            while (root != NIL)
            {
                if (root.val.CompareTo(node.val) < 0)
                    root = root.right;
                else if (root.val.CompareTo(node.val) > 0)
                    root = root.left;
                else
                    return root;
            }
            return NIL;
        }

        private void Transplant(RBNode<T> u, RBNode<T> v)
        {
            if (u.parent == NIL)
                root = v;
            else if (u == u.parent.left)
                u.parent.left = v;
            else
                u.parent.right = v;
            v.parent = u.parent;
        }

        public void Delete(RBNode<T> node)
        {
            RBNode<T> z = Search(node);
            if (z == NIL)
            {
                Console.WriteLine($"There is not any node with value {node.val}");
                return;
            }
            RBNode<T> y = z;
            color originalcolor = y.color;
            RBNode<T> x; // for double-black
            if (z.left == NIL)
            {
                x = z.right;
                Transplant(z, z.right);
            }
            else if (z.right == NIL)
            {
                x = z.left;
                Transplant(z, z.left);
            }
            else // if the node has 2 child
            {
                y = Minimum(z.right);
                originalcolor = y.color;
                x = y.right;

                if (y.parent == z)
                    x.parent = y;
                else
                {
                    Transplant(y, y.right);
                    y.right = z.right;
                    y.right.parent = y;
                }
                Transplant(z, y);
                y.left = z.left;
                y.left.parent = y;
                y.color = z.color;
            }
            if (originalcolor == color.Black)
                DeleteFixUp(x);
        }

        private void DeleteFixUp(RBNode<T> x)
        {
            while (x != root && x.color == color.Black)
            {
                if (x == x.parent.left)
                {
                    RBNode<T> w = x.parent.right;
                    if (w.color == color.Red) // case 1
                    {
                        w.color = color.Black;
                        w.parent.color = color.Red;
                        Rotateleft(w.parent);
                        w = x.parent.right;
                    }

                    if (w.left.color == color.Black && w.right.color == color.Black) //case 2(both children are blaack)
                    {
                        w.color = color.Red;
                        x = x.parent;
                    }

                    else // case 3
                    {
                        if (w.right.color == color.Black)// (when right child  is not red)
                        {
                            w.left.color = color.Black;
                            w.color = color.Red;
                            Rotateright(w);
                            w = x.parent.right;
                        }

                        w.color = x.parent.color;
                        x.parent.color = color.Black;
                        w.right.color = color.Black;
                        Rotateleft(x.parent);
                        x = root;
                    }
                }
                else // mirror case 
                {
                    RBNode<T> w = x.parent.left;
                    if (w.color == color.Red)
                    {
                   
                        w.color = color.Black;
                        x.parent.color = color.Red;
                        Rotateright(x.parent);
                        w = x.parent.left;
                    }

                    if (w.right.color == color.Black && w.left.color == color.Black)
                    {
                        
                        w.color = color.Red;
                        x = x.parent;
                    }
                    else
                    {
                        if (w.left.color == color.Black)
                        {
                         
                            w.right.color = color.Black;
                            w.color = color.Red;
                            Rotateleft(w);
                            w = x.parent.left;
                        }

                        w.color = x.parent.color;
                        x.parent.color = color.Black;
                        w.left.color = color.Black;
                        Rotateright(x.parent);
                        x = root;
                    }
                }
            }
            x.color = color.Black;
        }
    }
}

static class Program
{
    static void Main(string[] args)
    {
        Rbt<int> tree = new();
        tree.Insert(10);
        tree.Insert(20);
        tree.Insert(5);
        tree.Insert(18);
        tree.Insert(3);
        tree.Insert(1);
        tree.Print();
    }
}

