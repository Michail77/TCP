using System;
using System.Collections.Generic;
using System.Text;

namespace TreeList
{
    class GenTreeList<T> where T : IComparable
    {
        private ListNode first;
        private TreeNode root;
        private bool list;

        public GenTreeList()
        {
            first = null;
            root = null;
            list = true;
        }

        public int Count
        {
            get
            {
                int cnt = 0;
                if (list)
                {
                    if (first != null)
                    {
                        cnt++;
                        ListNode temp = first;
                        while (temp.next != null)
                        {
                            temp = temp.next;
                            cnt++;
                        }
                    }
                }
                else
                { }
                return cnt;
            }
        }

        public bool IsList()
        {
            return list;
        }

        public bool IsTree()
        {
            return !list;
        }

        public void Add(T item)
        {
            if (list)
            {
                if (first == null)
                {
                    first = new ListNode();
                    first.value = item;
                    first.next = null;
                }
                else
                {
                    ListNode temp = first;
                    while (temp.next != null)
                        temp = temp.next;
                    ListNode new_node = new ListNode();
                    new_node.value = item;
                    temp.next = new_node;
                }
            }
            else
            {
                TreeNode node = new TreeNode();
                node.value = item;
                if (root == null)
                {
                    root = node;
                    return;
                }
                AddNode(root, node);
            }
        }

        private void AddNode(TreeNode current, TreeNode node)
        {
            if (EqualityComparer<T>.Default.Equals(node.value, current.value))
                throw new ArgumentException("Hodnota existuje");

            if (node.value.ToString().CompareTo(current.value.ToString()) < 0)
            {
                if (current.left != null)
                    AddNode(current.left, node);
                else
                    current.left = node;
            }
            else
            {
                if (current.right != null)
                    AddNode(current.right, node);
                else
                    current.right = node;
            }
        }

        public override string ToString()
        {
            string temp = "";
            if (list)
            {
                if (first != null)
                {
                    ListNode node = first;
                    temp += node.value.ToString() + ";";
                    while (node.next != null)
                    {
                        node = node.next;
                        temp += node.value.ToString() + ";";
                    }
                }
            }
            else
                temp += ToStringRecursive(root);
            return temp;
        }

        private string ToStringRecursive(TreeNode uzel)
        {
            string vysledek = "";
            if (uzel != null)
            {
                vysledek += uzel.value + ";";
                if (uzel.left != null)
                    vysledek += ToStringRecursive(uzel.left) + ";";
                if (uzel.right != null)
                    vysledek += ToStringRecursive(uzel.right) + ";";
            }
            return vysledek;
        }

        public bool Contains(T item)
        {
            if (list)
            {
                ListNode temp = first;
                if (EqualityComparer<T>.Default.Equals(temp.value, item))
                    return true;
                while (temp.next != null)
                {
                    temp = temp.next;
                    if (EqualityComparer<T>.Default.Equals(temp.value, item))
                        return true;
                }
            }
            else
            { }
            return false;
        }

        public bool Remove(T item)
        {
            if (list)
            {
                ListNode temp = first;
                ListNode previous = first;
                if (EqualityComparer<T>.Default.Equals(temp.value, item))
                {
                    first = first.next;
                    return true;
                }
                while (temp.next != null)
                {
                    previous = temp;
                    temp = temp.next;
                    if (EqualityComparer<T>.Default.Equals(temp.value, item))
                    {
                        previous.next = temp.next;
                        return true;
                    }
                }
            }
            else
            { }
            return false;
        }

        public void TransformToList()
        {
            if (!list)
            {

                list = true;
            }
        }

        public void TransformToTree()
        {
            if (list)
            {

                list = false;
            }
        }

        internal class ListNode
        {
            public T value;
            public ListNode next;
        }

        internal class TreeNode
        {
            public T value;
            public TreeNode left, right;
        }
    }
}
